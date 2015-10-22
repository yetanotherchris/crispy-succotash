using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mia.Core;
using Mia.Core.Players;
using Mia.Core.Yahoo;
using NUnit.Framework;

// branch test
namespace Mia.Tests
{
	[TestFixture]
	public class PlayerTests
    {
        [SetUp]
        public void Setup()
        {
			Db.SetTestMode();
			Db.RecreateDb();
        }

		[Test]
		public void PickRandomSymbol()
		{
			// Arrange
			StockEngine engine = new YahooStockEngine();

			// Act		
			IEnumerable<string> symbols = engine.LoadSymbolsFromTextFile("aim.txt");
			string randomSymbol = engine.PickRandomSymbol(symbols);

			// Assert
			Console.WriteLine("Picked: {0}", randomSymbol);
			Assert.IsNotNullOrEmpty(randomSymbol);
		}

		[Test]
		public void InitializePlayer()
		{
			// Arrange
			StockEngine engine = new YahooStockEngine();	
			IEnumerable<string> symbols = engine.LoadSymbolsFromTextFile("aim.txt");
			string randomSymbol = engine.PickRandomSymbol(symbols);
			Quote quote = engine.LookupPrice(randomSymbol);
			decimal walletSize = 400; // £400

			Player player = new Chris();

			// Act
			engine.InsertQuote(quote);
			engine.InitializePlayer(player, quote, walletSize);

			// Assert
			Investment investment = engine.GetCurrentInvestmentForPlayer(player.Name);
			Assert.That(investment.Symbol, Is.EqualTo(randomSymbol));
			Assert.That(investment.PlayerName, Is.EqualTo(player.GetType().Name));
			Assert.That(investment.PurchaseDate, Is.GreaterThan(DateTime.Today));
			Assert.That(investment.PurchasePrice, Is.EqualTo(quote.LastTradePrice.Value));
		}

		[Test]
		public void ReInitializeAllPlayers()
		{
			// Arrange
			StockEngine engine = new YahooStockEngine();
			decimal walletSize = 400;

			// Act
			engine.ReInitializeAllPlayers(walletSize);

			// Assert
			List<Investment> investments = engine.GetInvestments().ToList();
			Assert.That(investments.Count, Is.EqualTo(5));
			Assert.NotNull(investments.FirstOrDefault(x => x.PlayerName == "Chris"));
			Assert.NotNull(investments.FirstOrDefault(x => x.PlayerName == "Fiona"));
			Assert.NotNull(investments.FirstOrDefault(x => x.PlayerName == "Wilson"));
			Assert.NotNull(investments.FirstOrDefault(x => x.PlayerName == "Katherine"));
			Assert.NotNull(investments.FirstOrDefault(x => x.PlayerName == "Jon"));
		}

		[Test]
		public void LookupQuotesForPlayers()
		{
			// Arrange
			StockEngine engine = new YahooStockEngine();
			decimal walletSize = 400;
			engine.ReInitializeAllPlayers(walletSize);

			// Act
			IEnumerable<Quote> quotes = engine.LookupQuotesForPlayers(engine.GetAllPlayers().Select(x => x.Name).ToArray());

			// Assert
			Assert.That(quotes.Count(), Is.EqualTo(5));
		}

		[Test]
		public void GetCurrentQuoteForPlayer()
		{
			// Arrange
			StockEngine engine = new YahooStockEngine();
			IEnumerable<string> symbols = engine.LoadSymbolsFromTextFile("aim.txt");
			string randomSymbol = engine.PickRandomSymbol(symbols);
			Quote quote = engine.LookupPrice(randomSymbol);
			decimal walletSize = 400; // £400

			Player player = new Chris();

			// Act
			engine.InsertQuote(quote);
			engine.InitializePlayer(player, quote, walletSize);
			Quote currentQuote = engine.GetCurrentQuoteForPlayer(player.Name);

			// Assert
			Assert.That(currentQuote.Id, Is.EqualTo(quote.Id));
			Assert.That(currentQuote.Symbol, Is.EqualTo(quote.Symbol));
			Assert.That(currentQuote.LastTradePrice, Is.EqualTo(quote.LastTradePrice));
		}

		[Test]
		public void SellInvestment()
		{
			// Arrange
			StockEngine engine = new YahooStockEngine();
			IEnumerable<Quote> stocks = engine.AllQuotes();
			
			Investment investment = new Investment() { Id = Guid.NewGuid() };
			decimal newPrice = 1.1m;

			// Act		
			engine.SellInvestment(investment.Id, newPrice, SellReason.HighPrice, DateTime.Today);

			// Assert
		}

		[Test]
		public void GetPlayerHistory()
		{
			// Arrange
			StockEngine engine = new YahooStockEngine();
			IEnumerable<string> symbols = engine.LoadSymbolsFromTextFile("aim.txt");
			string randomSymbol = engine.PickRandomSymbol(symbols);
			decimal walletSize = 400;

			Player player = new Chris();
			Quote quote1 = engine.LookupPrice(randomSymbol);
			engine.InitializePlayer(player, quote1, walletSize);

			Quote quote2 = engine.LookupPrice(randomSymbol);
			engine.InitializePlayer(player, quote2, walletSize);

			// Act		
			IEnumerable<Investment> investments = engine.GetInvestmentHistoryForPlayer(player.Name);

			// Assert
			Assert.That(investments.Count(), Is.EqualTo(2));
		}

		[Test]
		public void ShouldSellInvestment_High_Price()
		{
			// Arrange
			Investment investment = new Investment()
			{
				Symbol = "BLAH",
				PurchasePrice = 1.0m,
				PurchaseDate = DateTime.Today
			};
			Quote quote = new Quote() { Symbol = "BLAH", LastTradePrice = 1.3m };

			// Act
			StockEngine engine = new YahooStockEngine();

			foreach (Player player in engine.GetAllPlayers())
			{
				bool shouldSell = player.ShouldSellInvestment(quote, investment);

				// Assert
				Assert.True(shouldSell, "Failed ShouldSellInvestment being true for " + player.Name);
				Assert.That(investment.SellReason, Is.EqualTo(SellReason.HighPrice), "Failed SellReason being High for " + player.Name);
			}
		}

		[Test]
		public void ShouldSellInvestment_Low_Price()
		{
			// Arrange
			Investment investment = new Investment()
			{
				Symbol = "BLAH",
				PurchasePrice = 1.0m,
				PurchaseDate = DateTime.Today
			};
			Quote quote = new Quote() { Symbol = "BLAH", LastTradePrice = 0.7m };

			// Act
			StockEngine engine = new YahooStockEngine();

			foreach (Player player in engine.GetAllPlayers())
			{
				bool shouldSell = player.ShouldSellInvestment(quote, investment);

				// Assert
				Assert.True(shouldSell, "Failed ShouldSellInvestment being true for " + player.Name);
				Assert.That(investment.SellReason, Is.EqualTo(SellReason.LowPrice), "Failed SellReason being Low for " + player.Name);
			}
		}

		[Test]
		public void ShouldSellInvestment_No_Change()
		{
			// Arrange
			Investment investment = new Investment()
			{
				Symbol = "BLAH",
				PurchasePrice = 1.0m,
				PurchaseDate = DateTime.Today
			};
			Quote quote = new Quote() { Symbol = "BLAH", LastTradePrice = 1.0m };

			// Act
			StockEngine engine = new YahooStockEngine();

			foreach (Player player in engine.GetAllPlayers())
			{
				bool shouldSell = player.ShouldSellInvestment(quote, investment);

				// Assert
				Assert.False(shouldSell, "Failed ShouldSellInvestment being false for " + player.Name);
				Assert.IsNull(investment.SellReason, "Failed SellReason being null for " + player.Name);
			}
		}

		[Test]
		public void ShouldSellInvestment_Boundaries()
		{
			// Arrange
			Investment investment1 = new Investment() { Symbol = "", PurchasePrice = 1.0m, PurchaseDate = DateTime.Today };
			Investment investment2 = new Investment() { Symbol = "", PurchasePrice = 1.0m, PurchaseDate = DateTime.Today };
			Investment investment3 = new Investment() { Symbol = "", PurchasePrice = 1.0m, PurchaseDate = DateTime.Today };

			Investment investment4 = new Investment() { Symbol = "", PurchasePrice = 1.0m, PurchaseDate = DateTime.Today };
			Investment investment5 = new Investment() { Symbol = "", PurchasePrice = 1.0m, PurchaseDate = DateTime.Today };
			Investment investment6 = new Investment() { Symbol = "", PurchasePrice = 1.0m, PurchaseDate = DateTime.Today };

			Investment investment7 = new Investment() { Symbol = "", PurchasePrice = 1.0m, PurchaseDate = DateTime.Today };
			Investment investment8 = new Investment() { Symbol = "", PurchasePrice = 1.0m, PurchaseDate = DateTime.Today };
			Investment investment9 = new Investment() { Symbol = "", PurchasePrice = 1.0m, PurchaseDate = DateTime.Today };

			Quote highQuote1 = new Quote() { Symbol = "BLAH", LastTradePrice = 1.05m };
			Quote highQuote2 = new Quote() { Symbol = "BLAH", LastTradePrice = 1.06m };
			Quote highQuote3 = new Quote() { Symbol = "BLAH", LastTradePrice = 3.99m };

			Quote lowQuote1 = new Quote() { Symbol = "BLAH", LastTradePrice = 0.95m };
			Quote lowQuote2 = new Quote() { Symbol = "BLAH", LastTradePrice = 0.49m };
			Quote lowQuote3 = new Quote() { Symbol = "BLAH", LastTradePrice = 0 };

			Quote noChangeQuote1 = new Quote() { Symbol = "BLAH", LastTradePrice = 0.96m };
			Quote noChangeQuote2 = new Quote() { Symbol = "BLAH", LastTradePrice = 1.04m };
			Quote noChangeQuote3 = new Quote() { Symbol = "BLAH", LastTradePrice = null };

			// Act
			Chris chris = new Chris(); // 5% change
			bool shouldSellHigh1 = chris.ShouldSellInvestment(highQuote1, investment1);
			bool shouldSellHigh2 = chris.ShouldSellInvestment(highQuote2, investment2);
			bool shouldSellHigh3 = chris.ShouldSellInvestment(highQuote3, investment3);

			bool shouldSellLow1 = chris.ShouldSellInvestment(lowQuote1, investment4);
			bool shouldSellLow2 = chris.ShouldSellInvestment(lowQuote2, investment5);
			bool shouldSellLow3 = chris.ShouldSellInvestment(lowQuote3, investment6);

			bool shouldSellNoChange1 = chris.ShouldSellInvestment(noChangeQuote1, investment7);
			bool shouldSellNoChange2 = chris.ShouldSellInvestment(noChangeQuote2, investment8);
			bool shouldSellNoChange3 = chris.ShouldSellInvestment(noChangeQuote3, investment9);

			// Assert
			Assert.True(shouldSellHigh1, "High price 1 to 1.05"); Assert.That(investment1.SellReason, Is.EqualTo(SellReason.HighPrice));
			Assert.True(shouldSellHigh2, "High price 1 to 1.06"); Assert.That(investment2.SellReason, Is.EqualTo(SellReason.HighPrice));
			Assert.True(shouldSellHigh3, "High price 1 to 3.99"); Assert.That(investment3.SellReason, Is.EqualTo(SellReason.HighPrice));

			Assert.True(shouldSellLow1, "Low price 1 to 0.95"); Assert.That(investment4.SellReason, Is.EqualTo(SellReason.LowPrice));
			Assert.True(shouldSellLow2, "Low price 1 to 0.49"); Assert.That(investment5.SellReason, Is.EqualTo(SellReason.LowPrice));
			Assert.True(shouldSellLow3, "Low price 1 to 0"); Assert.That(investment6.SellReason, Is.EqualTo(SellReason.LowPrice));

			Assert.False(shouldSellNoChange1, "No change 1 to 0.96");
			Assert.False(shouldSellNoChange2, "No change 1 to 1.04");
			Assert.False(shouldSellNoChange3, "No change 1 to (null)");
		}

		[Test]
		public void ShouldSellInvestment_ExpiredInvestment()
		{

		}
    }
}
