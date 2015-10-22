using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mia.Core.Google;
using Newtonsoft.Json;
using RestSharp;

namespace Mia.Core
{
	public class GoogleStockEngine : StockEngine
	{
		private static readonly string GOOGLE_FINANCE_BASEURL = "http://finance.google.com";
		private static readonly string GOOGLE_FINANCE_PATH = "/finance/info?client=ig&q={query}";
		private static readonly int QUERYSIZE = 100;

		public override IEnumerable<string> LoadSymbolsFromTextFile(string path)
		{
			IEnumerable<string> list = base.LoadSymbolsFromTextFile(path);
			return list.Select(x => x.Replace(".L", "").Insert(0, "LON:"));
		}

		public override Quote LookupPrice(string symbol)
		{
			List<string> symbols = new List<string>();
			symbols.Add(symbol);

			return LookupPrices(symbols).FirstOrDefault();
		}

		public override IEnumerable<Quote> LookupPrices(IEnumerable<string> symbols)
		{
			List<Quote> quotes = new List<Quote>();
			List<JsonQuote> jsonQuotes = new List<JsonQuote>();
			List<string> symbolsList = symbols.ToList();

			if (symbolsList.Count <= QUERYSIZE)
			{
				RestClient client = new RestClient(GOOGLE_FINANCE_BASEURL);
				RestRequest request = new RestRequest(GOOGLE_FINANCE_PATH, Method.GET);
				request.AddUrlSegment("query", string.Join(",", symbolsList));
				request.RequestFormat = DataFormat.Json;

				IRestResponse response = client.Execute(request);

				try
				{
					jsonQuotes = JsonConvert.DeserializeObject<List<JsonQuote>>(response.Content.Remove(0, 3)); // remove the "//"
				}
				catch (Exception e)
				{
					Log.Error("Exception occurred with Google JSON lookup for URI {0}, status: {1}, content: '{2}', exception : {3}", response.ResponseUri, response.StatusCode, response.Content, e);
				}
			}
			else
			{
				int i = 0;
				List<string> currentSymbols = symbols.Skip(i).Take(QUERYSIZE).ToList();

				while (currentSymbols.Count > 0 && i < symbolsList.Count)
				{
					RestClient client = new RestClient(GOOGLE_FINANCE_BASEURL);
					RestRequest request = new RestRequest(GOOGLE_FINANCE_PATH, Method.GET);
					request.AddUrlSegment("query", string.Join(",", currentSymbols));

					IRestResponse response = client.Execute(request);

					try
					{
						jsonQuotes.AddRange(JsonConvert.DeserializeObject<List<JsonQuote>>(response.Content.Remove(0, 3)));
					}
					catch (Exception e)
					{
						Log.Error("Exception occurred with Google JSON lookup for URI {0}, status: {1}, content: '{2}', exception : {3}", response.ResponseUri, response.StatusCode, response.Content, e);
					}

					i += QUERYSIZE;
					currentSymbols = symbols.Skip(i).Take(QUERYSIZE).ToList();
				}
			}

			foreach (JsonQuote jsonQuote in jsonQuotes)
			{
				quotes.Add(new Quote()
				{
					Id = Guid.NewGuid(),
					Symbol = jsonQuote.Symbol +".L", // temporary hack
					Name = jsonQuote.Symbol,
					LastTradePrice = jsonQuote.Price,
					LastTradeDate = jsonQuote.LastTrade,
					
				});
			}

			return quotes;
		}
    }
}
