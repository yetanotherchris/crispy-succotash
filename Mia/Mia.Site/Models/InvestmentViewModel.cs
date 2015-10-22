using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mia.Core;

namespace Mia.Site
{
	public class InvestmentViewModel
	{
		public string Symbol { get; set; }
		public string SellReason { get; set; }
		public DateTime PurchaseDate { get; set; }
		public decimal PurchasePrice { get; set; }
		public DateTime? SellDate { get; set; }
		public decimal? SellPrice { get; set; }
		public decimal? SellTotal { get; set; }
		public int Quantity { get; set; }
		public decimal PurchaseTotal { get; set; }
		public string LabelType { get; set; }
		public double PriceDifference { get; set; }
		public string PriceDifferenceLabel { get; set; }

		public InvestmentViewModel(Investment investment)
		{
			Symbol = investment.Symbol;
			PurchaseDate = investment.PurchaseDate;
			PurchasePrice = investment.PurchasePrice / 100;
			Quantity = investment.Quantity;
			PurchaseTotal = Quantity * PurchasePrice;

			if (investment.SellReason != null)
			{
				SellReason = investment.SellReason.ToString();

				if (investment.SellReason == Mia.Core.SellReason.HighPrice)
					LabelType = "label-success";
				else if (investment.SellReason == Mia.Core.SellReason.LowPrice)
					LabelType = "label-important";

				SellDate = investment.SellDate;
				SellPrice = investment.SellPrice / 100;
				SellTotal = Quantity * SellPrice;

				PriceDifference = (double)((SellPrice.Value - PurchasePrice) / PurchasePrice);
				PriceDifferenceLabel = (PriceDifference > 0) ? "label-success" : "label-important";
			}
			else
			{
				SellReason = "-";
			}
		}
	}
}