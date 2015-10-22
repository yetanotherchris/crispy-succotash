using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mia.Core;
using Mia.Core.Players;

namespace Mia.Site
{
	public class PlayerViewModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Symbol { get; set; }
		public string CompanyName { get; set; }
		public decimal CurrentPrice { get; set; }
		public decimal PurchasePrice { get; set; }
		public DateTime PurchasedOn { get; set; }
		public double PercentageChange { get; set; }
		public int ShareQuantity { get; set; }

		public int StockAge
		{
			get
			{
				return (DateTime.Now - PurchasedOn).Days;
			}
		}

		public PlayerViewModel(Investment investment, Quote latestQuote, Player player)
		{
			Name = player.Name;
			Description = player.Description;
			Symbol = investment.Symbol;
			CompanyName = latestQuote.Name;
			CurrentPrice = latestQuote.LastTradePrice.Value / 100;
			PurchasePrice = investment.PurchasePrice / 100;
			PurchasedOn = investment.PurchaseDate;
			ShareQuantity = investment.Quantity;

			PercentageChange = (double) ((CurrentPrice - PurchasePrice) / PurchasePrice);
		}
	}
}