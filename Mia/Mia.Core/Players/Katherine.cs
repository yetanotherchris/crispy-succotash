using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Core.Players
{
	/// <summary>
	/// She buys and sells at the smallest gain or loss, 2% for each. She waits 28 days for any change.
	/// </summary>
	public class Katherine : Player
	{
		private static readonly int LOWPERCENTAGE = 2;
		private static readonly int HIGHPERCENTAGE = 2;
		private static readonly int DAYS = 28;

		public override string Description
		{
			get
			{
				return "She buys and sells at the smallest gain or loss, 2% for each. She waits 28 days for any change.";
			}
		}

		public override bool ShouldSellInvestment(Quote quote, Investment investment)
		{
			return ShouldSellInvestment(quote, investment, HIGHPERCENTAGE, LOWPERCENTAGE, DAYS);
		}
	}
}
