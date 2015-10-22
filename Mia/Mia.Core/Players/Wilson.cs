using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Core.Players
{
	/// <summary>
	/// He gambles hard. He waits for a 20% price increase, or a 15% loss. If nothing happens after a 3 days, he sells.
	/// </summary>
	public class Wilson : Player
	{
		private static readonly int LOWPERCENTAGE = 15;
		private static readonly int HIGHPERCENTAGE = 20;
		private static readonly int DAYS = 3;

		public override string Description
		{
			get
			{
				return "He gambles hard. He waits for a 20% price increase, or a 15% loss. If nothing happens after a 3 days, he sells.";
			}
		}

		public override bool ShouldSellInvestment(Quote quote, Investment investment)
		{
			return ShouldSellInvestment(quote, investment, HIGHPERCENTAGE, LOWPERCENTAGE, DAYS);
		}
	}
}
