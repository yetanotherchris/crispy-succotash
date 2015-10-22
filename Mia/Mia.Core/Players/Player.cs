using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Core.Players
{
	public abstract class Player
	{
		public abstract bool ShouldSellInvestment(Quote quote, Investment investment);
		public abstract string Description { get; }

		public string Name
		{
			get { return GetType().Name; }
		}

		protected bool ShouldSellInvestment(Quote quote, Investment investment, decimal highPercentage, decimal lowPercentage, int expireDays)
		{
			//lowPercentage = lowPercentage / 100;
			//highPercentage = 1 + (highPercentage / 100);

			if (quote.LastTradePrice == null)
			{
				// Sound the alarm bells
				Log.Error("Quote.LastTradePrice is null for investment with symbol {0} for {1}", quote.Symbol, GetType().Name);
				return false;
			}
			else if (quote.LastTradePrice.Value != investment.PurchasePrice)
			{
				decimal percentageChange = ((quote.LastTradePrice.Value - investment.PurchasePrice) / investment.PurchasePrice) * 100;

				if (percentageChange <= -lowPercentage)
				{
					// Low
					investment.SellReason = SellReason.LowPrice;
					return true;
				}
				else if (percentageChange >= highPercentage)
				{
					// High
					investment.SellReason = SellReason.HighPrice;
					return true;
				}
				else if ((DateTime.Today - investment.PurchaseDate).TotalDays >= expireDays)
				{
					// Expired
					investment.SellReason = SellReason.Expired;
					return true;
				}
			}

			return false;
		}
	}
}
