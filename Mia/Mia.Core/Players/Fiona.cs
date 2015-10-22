using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Core.Players
{
	/// <summary>
	/// She sells after a 10% increase, and a 3% loss. If nothing happens after a 14 days, she sells.
	/// </summary>
	public class Fiona : Player
	{
		private static readonly int LOWPERCENTAGE = 3;
		private static readonly int HIGHPERCENTAGE = 10;
		private static readonly int DAYS = 14;

		public override string Description
		{
			get
			{
				return "She sells after a 10% increase, and a 3% loss. If nothing happens after a 14 days, she sells.";
			}
		}

		public override bool ShouldSellInvestment(Quote quote, Investment investment)
		{
			return ShouldSellInvestment(quote, investment, HIGHPERCENTAGE, LOWPERCENTAGE, DAYS);
		}
	}
}
