using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Core.Players
{
	/// <summary>
	/// He buys and sells when the prices goes up or down by 5%. If nothing happens after a 7 days, he sells.
	/// </summary>
	public class Chris : Player
	{
		private static readonly int LOWPERCENTAGE = 5;
		private static readonly int HIGHPERCENTAGE = 5;
		private static readonly int DAYS = 7;

		public override string Description
		{
			get
			{
				return "He buys and sells when the prices goes up or down by 5%. If nothing happens after a 7 days, he sells.";
			}
		}

		public override bool ShouldSellInvestment(Quote quote, Investment investment)
		{
			return ShouldSellInvestment(quote, investment, HIGHPERCENTAGE, LOWPERCENTAGE, DAYS);
		}
	}
}
