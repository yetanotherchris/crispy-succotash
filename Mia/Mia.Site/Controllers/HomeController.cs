using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mia.Core;
using Mia.Core.Players;
using Mia.Core.Yahoo;

namespace Mia.Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
			List<PlayerViewModel> players = new List<PlayerViewModel>();
			StockEngine engine = new YahooStockEngine();
			
			// Chris
			Player player = new Chris();
			Investment investment = engine.GetCurrentInvestmentForPlayer(player.Name);
			Quote quote = engine.GetCurrentQuoteForPlayer(player.Name);
			PlayerViewModel model = new PlayerViewModel(investment, quote, player);
			players.Add(model);

			// Fiona
			player = new Fiona();
			investment = engine.GetCurrentInvestmentForPlayer(player.Name);
			quote = engine.GetCurrentQuoteForPlayer(player.Name);
			model = new PlayerViewModel(investment, quote, player);
			players.Add(model);

			// Wilson
			player = new Wilson();
			investment = engine.GetCurrentInvestmentForPlayer(player.Name);
			quote = engine.GetCurrentQuoteForPlayer(player.Name);
			model = new PlayerViewModel(investment, quote, player);
			players.Add(model);

			// Katherine
			player = new Katherine();
			investment = engine.GetCurrentInvestmentForPlayer(player.Name);
			quote = engine.GetCurrentQuoteForPlayer(player.Name);
			model = new PlayerViewModel(investment, quote, player);
			players.Add(model);

			// Jon
			player = new Jon();
			investment = engine.GetCurrentInvestmentForPlayer(player.Name);
			quote = engine.GetCurrentQuoteForPlayer(player.Name);
			model = new PlayerViewModel(investment, quote, player);
			players.Add(model);
			
            return View(players);
        }

		public ActionResult PlayerHistory(string playerName)
		{
			ViewData["PlayerName"] = playerName;

			List<PlayerViewModel> players = new List<PlayerViewModel>();
			StockEngine engine = new YahooStockEngine();
			IEnumerable<Investment> investments = engine.GetInvestmentHistoryForPlayer(playerName);
			IEnumerable<InvestmentViewModel> model = investments.Select(x => new InvestmentViewModel(x));

			return View(model);
		}

		public ActionResult QuoteHistory()
		{
			StockEngine engine = new YahooStockEngine();

			DateTime lastWeek = DateTime.Today.AddDays(-7);
			IEnumerable<QuoteViewModel> model = engine.AllQuotesAfter(lastWeek)
				.OrderByDescending(x => x.CreateDate)
				.OrderBy(x => x.Symbol)
				.Select(x => new QuoteViewModel(x));
			return View(model);
		}

		public ActionResult QuoteHistoryForPlayers()
		{
			StockEngine engine = new YahooStockEngine();

			DateTime lastWeek = DateTime.Today.AddDays(-7);
			IEnumerable<QuoteViewModel> model = engine.AllQuotesForPlayersAfter(lastWeek)
				.OrderByDescending(x => x.CreateDate)
				.OrderBy(x => x.Symbol)
				.Select(x => new QuoteViewModel(x));
			return View(model);
		}
    }
}
