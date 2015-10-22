using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using Mia.Core.Players;

namespace Mia.Core
{
	public abstract class StockEngine
	{
		private static Random _random = new Random();

		public abstract IEnumerable<Quote> LookupPrices(IEnumerable<string> symbols);
		public abstract Quote LookupPrice(string symbol);

		public virtual IEnumerable<string> LoadSymbolsFromTextFile(string path)
		{
			IEnumerable<string> results = File.ReadAllText(path).Split(new string[]{ "\n" }, StringSplitOptions.RemoveEmptyEntries);
			return results.Select(r => r.Trim());
		}

		public void InsertQuote(Quote quote)
		{
			using (DbConnection connection = Db.CreateConnection())
			{
				connection.Open();
				connection.Insert<Quote>(quote);
			}
		}

		public void InsertQuotes(IEnumerable<Quote> quotes)
		{
			using (DbConnection connection = Db.CreateConnection())
			{
				connection.Open();
				connection.Insert<Quote>(quotes.Where(q => q != null));
			}		
		}

		public virtual IEnumerable<Quote> AllQuotes()
		{
			using (DbConnection connection = Db.CreateConnection())
			{
				connection.Open();
				return connection.GetList<Quote>();
			}
		}

		public virtual IEnumerable<Quote> AllQuotesAfter(DateTime afterDate)
		{
			using (DbConnection connection = Db.CreateConnection())
			{
				connection.Open();
				IFieldPredicate predicate = Predicates.Field<Quote>(x => x.CreateDate, Operator.Gt, afterDate);
				return connection.GetList<Quote>(predicate);
			}
		}

		public virtual IEnumerable<Quote> AllQuotesForPlayersAfter(DateTime afterDate)
		{
			List<string> symbols = new List<string>();
			foreach (string player in GetAllPlayers().Select(x => x.Name))
			{
				string sqlSymbol = string.Format("'{0}'", GetCurrentQuoteForPlayer(player).Symbol);
				symbols.Add(sqlSymbol);
			}

			string sql = "SELECT * FROM Quotes WHERE Symbol IN (";
			sql += string.Join(",", symbols);
			sql += ") AND CreateDate > @AfterDate";
			
			using (DbConnection connection = Db.CreateConnection())
			{
				connection.Open();
				return connection.Query<Quote>(sql, new { AfterDate = afterDate });
			}
		}

		public bool SellInvestment(Guid investmentId, decimal sellPrice, SellReason sellReason, DateTime sellDate)
		{
			using (DbConnection connection = Db.CreateConnection())
			{
				connection.Open();

				Investment investment = connection.Get<Investment>(investmentId);
				if (investment == null)
				{
					Log.Error("Unable to find investment with id {0} (sellreason: {1})", investmentId, sellReason.ToString());
					return false;
				}

				investment.SellDate = sellDate;
				investment.SellPrice = sellPrice;
				investment.SellReason = sellReason;

				return connection.Update<Investment>(investment);
			}
		}

		public string PickRandomSymbol(IEnumerable<string> symbols)
		{
			int randomNumber = _random.Next(0, symbols.Count() -1);
			return symbols.ToList()[randomNumber];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="player"></param>
		/// <param name="quote"></param>
		/// <param name="walletSize">The size of your wallet, in £</param>
		public void InitializePlayer(Player player, Quote quote, decimal walletSize)
		{
			walletSize *= 100;
			int quantity = (int)(walletSize / quote.LastTradePrice.Value);

			Investment investment = new Investment()
			{
				Id = Guid.NewGuid(),
				PlayerName = player.GetType().Name,
				PurchaseDate = DateTime.Now,
				PurchasePrice = quote.LastTradePrice.Value,
				Quantity = quantity, 
				Symbol = quote.Symbol
			};

			using (DbConnection connection = Db.CreateConnection())
			{
				connection.Open();
				connection.Insert<Investment>(investment);

				Log.Information("Initialized {0} with symbol {1}", investment.PlayerName, investment.Symbol);
			}
		}

		public Investment GetCurrentInvestmentForPlayer(string playerName)
		{
			using (DbConnection connection = Db.CreateConnection())
			{
				connection.Open();

				return connection.Query<Investment>("SELECT TOP 1 * FROM Investments WHERE PlayerName=@PlayerName ORDER BY PurchaseDate DESC",
					new { PlayerName = playerName }).FirstOrDefault();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="player"></param>
		/// <param name="quote"></param>
		/// <param name="walletSize">The size of your wallet, in £</param>
		public void ReInitializeAllPlayers(decimal walletSize)
		{
			IEnumerable<string> symbols = LoadSymbolsFromTextFile("aim.txt");

			foreach (Player player in GetAllPlayers())
			{
				string symbol = PickRandomSymbol(symbols);
				InitializePlayer(player, LookupPrice(symbol), walletSize);
			}
		}

		public IEnumerable<Investment> GetInvestments()
		{
			using (DbConnection connection = Db.CreateConnection())
			{
				connection.Open();
				return connection.GetList<Investment>();
			}
		}

		public IEnumerable<Quote> LookupQuotesForPlayers(params string[] playerNames)
		{
			List<Quote> quotes = new List<Quote>();

			foreach (string player in playerNames)
			{
				Investment investment = GetCurrentInvestmentForPlayer(player);

				if (investment != null)
					quotes.Add(LookupPrice(investment.Symbol));
			}

			return quotes;
		}

		public Quote GetCurrentQuoteForPlayer(string playerName)
		{
			using (DbConnection connection = Db.CreateConnection())
			{
				connection.Open();

				// Get the player's current investment
				Investment investment = connection.Query<Investment>("SELECT TOP 1 * FROM Investments WHERE PlayerName=@PlayerName ORDER BY PurchaseDate DESC",
					new { PlayerName = playerName }).FirstOrDefault();

				// Get the current quote
				IFieldPredicate predicate = Predicates.Field<Quote>(x => x.Symbol, Operator.Eq, investment.Symbol);
				ISort sort = Predicates.Sort<Quote>(x => x.CreateDate, false);
				List<ISort> sorting = new List<ISort>();
				sorting.Add(sort);

				return connection.GetList<Quote>(predicate, sorting).FirstOrDefault();
			}
		}

		public IEnumerable<Player> GetAllPlayers()
		{
			List<Player> players = new List<Player>();
			players.Add(new Chris());
			players.Add(new Fiona());
			players.Add(new Wilson());
			players.Add(new Katherine());
			players.Add(new Jon());

			return players;
		}

		public IEnumerable<Investment> GetInvestmentHistoryForPlayer(string playerName)
		{
			string sql = @"SELECT I.*, Q.LastTradePrice FROM Investments I
				INNER JOIN Quotes Q ON
					Q.Symbol = I.Symbol
			WHERE PlayerName = @PlayerName
			ORDER BY I.PurchaseDate";

			using (DbConnection connection = Db.CreateConnection())
			{
				connection.Open();

				return connection.Query<Investment>("SELECT * FROM Investments WHERE PlayerName = @PlayerName ORDER BY PurchaseDate DESC",
					new { PlayerName = playerName });
			}
		}

		public IEnumerable<Quote> GetQuoteHistory(string symbol)
		{
			using (DbConnection connection = Db.CreateConnection())
			{
				connection.Open();

				return connection.Query<Quote>("SELECT * FROM Quotes WHERE Symbol = @Symbol ORDER BY CreateDate DESC",
					new { Symbol = symbol });
			}
		}
	}
}
