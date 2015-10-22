using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mia.Core;
using Mia.Core.Players;
using Mia.Core.Yahoo;

namespace Mia
{
	class Program
	{
		static void Main(string[] args)
		{
			//args = new string[] { "--initialize" };

			try
			{
				if (args.Length > 0 && args[0] == "--initialize")
				{
					Initialize();
				}
				else
				{
					Scan();
				}
			}
			catch (Exception ex)
			{
				Log.Error("Error occured in the console app: {0}", ex.ToString());
				Console.WriteLine("An error occurred {0}", ex);
			}
			finally
			{
				Console.Write("Press any key to quit...");
				Console.Read();
			}
		}

		private static void Initialize()
		{
			StockEngine engine = new YahooStockEngine();
			engine.ReInitializeAllPlayers(400);
			IEnumerable<Quote> stocks = engine.LookupQuotesForPlayers(engine.GetAllPlayers().Select(x => x.Name).ToArray());
			engine.InsertQuotes(stocks);

			Log.Information("Saved {0} new stock prices to the database.", stocks.Count());
			Log.Information("Initialized all players");

			Console.WriteLine("Saved {0} new stock prices to the database.", stocks.Count());
			Console.WriteLine("Initialized all players");
		}

		private static void Scan()
		{
			StockEngine engine = new YahooStockEngine();

			IEnumerable<string> symbols = engine.LoadSymbolsFromTextFile("aim.txt");
			//IEnumerable<Quote> stocks = engine.LookupPrices(symbols); // Get everything
			string[] playerNames = engine.GetAllPlayers().Select(x => x.Name).ToArray();

			IEnumerable<Quote> stocks = engine.LookupQuotesForPlayers(playerNames);
			if (stocks.Count() < 1 || stocks.Any(s => s == null))
			{
				// Try Google
				Log.Information("No stocks found - switching to the Google API");
				engine = new GoogleStockEngine();
				symbols = engine.LoadSymbolsFromTextFile("aim.txt");
				stocks = engine.LookupQuotesForPlayers(playerNames);
			}

			engine.InsertQuotes(stocks);
			Log.Information("Saved {0} new stock prices to the database.", stocks.Count());

			//
			// Calculate if investments should be sold for each players
			//
			foreach (Player player in engine.GetAllPlayers())
			{
				Quote quote = engine.GetCurrentQuoteForPlayer(player.Name);
				Investment investment = engine.GetCurrentInvestmentForPlayer(player.Name);
				if (player.ShouldSellInvestment(quote, investment))
				{
					// Sell sell sell
					Log.Information("Selling {0}'s investment in {1} - ({2}) current price is {3}", player.Name, investment.Symbol, investment.SellReason, quote.LastTradePrice.Value);
					engine.SellInvestment(investment.Id, quote.LastTradePrice.Value, investment.SellReason.Value, DateTime.Now);

					// Buy buy buy
					string nextSymbol = engine.PickRandomSymbol(symbols);
					Quote nextQuote = engine.LookupPrice(nextSymbol);
					engine.InitializePlayer(player, nextQuote, 400);
					Log.Information("New investment set up for {0}. Bought {1} shares in {2} at price of {3}", player.Name, investment.Quantity, quote.Symbol, quote.LastTradePrice.Value);
				}
			}
		}
	}
}
