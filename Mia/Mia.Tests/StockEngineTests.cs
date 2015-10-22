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

// branch test 2
namespace Mia.Tests
{
	[TestFixture]
	public class StockEngineTests
    {
        [SetUp]
        public void Setup()
        {
			Db.SetTestMode();
			Db.RecreateDb();
        }

		private StockEngine GetEngine()
		{
			return new GoogleStockEngine();
		}

		[Test]
		public void LookUpPrice()
		{
			// Arrange
			StockEngine engine = GetEngine();

			// Act		
			Quote quote = engine.LookupPrice("CEO.L");

			// Assert
			Assert.NotNull(quote);
			Assert.That(quote.LastTradePrice, Is.Not.EqualTo(0m));
			Assert.That(quote.Symbol, Is.StringContaining("CEO"));
		}

		[Test]
		public void LookUpPrice_With_Bad_Symbol_Returns_Null()
		{
			// Arrange
			StockEngine engine = GetEngine();

			// Act		
			Quote quote = engine.LookupPrice("FARTYFART.L");

			// Assert
			Assert.Null(quote);
		}

		[Test]
		public void LookUpPrices()
		{
			// Arrange
			StockEngine engine = GetEngine();
			IEnumerable<string> symbols = new string[] { "BRK.L", "CEO.L" };

			// Act		
			IEnumerable<Quote> stocks = engine.LookupPrices(symbols);

			// Assert
			Assert.That(stocks.Count(), Is.GreaterThan(1));
		}

		[Test]
		public void LookUpPrices_With_Bad_Symbol_Returns_Empty_List()
		{
			// Arrange
			StockEngine engine = GetEngine();
			IEnumerable<string> symbols = new string[] { "FARTYFART1.L", "FARTYFART2.L" };

			// Act		
			IEnumerable<Quote> stocks = engine.LookupPrices(symbols);

			// Assert
			Assert.That(stocks.Count(), Is.EqualTo(0));
		}

		[Test]
		public void SaveToDatabase_And_LoadFromDatabase()
		{
			// Arrange
			StockEngine engine = GetEngine();
			List<Quote> stocks = new List<Quote>();
			Quote stock1 = new Quote("SYM1")
			{
				Id = Guid.NewGuid(),
				LastTradePrice = 1.50m,
			};

			Quote stock2 = new Quote("SYM2")
			{
				Id = Guid.NewGuid(),
				LastTradePrice = 2.50m
			};
			stocks.Add(stock1);
			stocks.Add(stock2);

			// Act        
			engine.InsertQuotes(stocks);
			List<Quote> stocksFromDb = engine.AllQuotes().ToList();

			// Assert
			Assert.That(stocksFromDb.Count, Is.EqualTo(2));

			Assert.That(stocksFromDb[0].Id, Is.EqualTo(stock1.Id));
			Assert.That(stocksFromDb[0].LastTradePrice, Is.EqualTo(stock1.LastTradePrice));
			Assert.That(stocksFromDb[0].Symbol, Is.EqualTo(stock1.Symbol));

			Assert.That(stocksFromDb[1].Id, Is.EqualTo(stock2.Id));
			Assert.That(stocksFromDb[1].LastTradePrice, Is.EqualTo(stock2.LastTradePrice));
			Assert.That(stocksFromDb[1].Symbol, Is.EqualTo(stock2.Symbol));
		}

		[Test]
		public void LoadSymbolsFromTextFile()
		{
			// Arrange
			StockEngine engine = GetEngine();

			// Act		
			IEnumerable<string> symbols = engine.LoadSymbolsFromTextFile("aim.txt");

			// Assert
			Assert.That(symbols.Count(), Is.EqualTo(674));
		}

		[Test]
		[Explicit]
		public void Query300Symbols()
		{
			// Arrange
			StockEngine engine = GetEngine();

			// Act		
			IEnumerable<string> symbols = engine.LoadSymbolsFromTextFile("aim.txt");

			IEnumerable<Quote> stocks = engine.LookupPrices(symbols.Take(300));
			engine.InsertQuotes(stocks);

			List<Quote> stocksFromDb = engine.AllQuotes().ToList();

			// Assert
			Assert.That(stocksFromDb.Count(), Is.GreaterThan(200));
		}

		[Test]
		[Explicit]
		public void PruneLowVolume()
		{
			// Arrange
			StockEngine engine = GetEngine();
			IEnumerable<string> symbols = engine.LoadSymbolsFromTextFile("aim.txt");

			// Act		
			IEnumerable<Quote> stocks = engine.LookupPrices(symbols);
			IEnumerable<Quote> prunedStocks = stocks.Where(q => q.AverageDailyVolume != null && q.AverageDailyVolume > 200);

			// Assert
			Assert.That(prunedStocks.Count(), Is.GreaterThan(100));

			StringBuilder builder = new StringBuilder();
			foreach (Quote quote in prunedStocks)
			{
				builder.AppendLine(quote.Symbol);
			}

			File.WriteAllText(@"d:\aimnew.txt", builder.ToString());
		}

		[Test]
		[Explicit]
		public void PruneLowPrice()
		{
			// Arrange
			StockEngine engine = GetEngine();
			IEnumerable<string> symbols = engine.LoadSymbolsFromTextFile("aim.txt");

			// Act		
			IEnumerable<Quote> stocks = engine.LookupPrices(symbols);
			IEnumerable<Quote> prunedStocks = stocks.Where(q => q.LastTradePrice != null && q.LastTradePrice > 5);

			// Assert
			Assert.That(prunedStocks.Count(), Is.GreaterThan(100));

			StringBuilder builder = new StringBuilder();
			foreach (Quote quote in prunedStocks)
			{
				builder.AppendLine(quote.Symbol);
			}

			File.WriteAllText(@"d:\aimnew.txt", builder.ToString());
		}

		[Test]
		public void GetQuoteHistory()
		{
			// Arrange
			StockEngine engine = GetEngine();
			string symbol = "CEO.L";
			Quote quote = engine.LookupPrice(symbol);
			engine.InsertQuote(quote);

			quote = engine.LookupPrice(symbol);
			engine.InsertQuote(quote);

			// Act		
			IEnumerable<Quote> quotes = engine.GetQuoteHistory(symbol);

			// Assert
			Assert.That(quotes.Count(), Is.GreaterThan(1));
		}
    }
}
