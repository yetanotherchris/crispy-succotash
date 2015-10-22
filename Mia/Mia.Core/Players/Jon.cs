using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Core.Players
{
	/// <summary>
	/// He's optimistic, and doesn't sell when the price drops. He sells after a 20% increase.
	/// </summary>
	public class Jon : Player
	{
		private static readonly int LOWPERCENTAGE = 0;
		private static readonly int HIGHPERCENTAGE = 20;
		private static readonly int DAYS = 365;

		public override string Description
		{
			get
			{
				return "He's optimistic, and doesn't sell when the price drops. He sells after a 20% increase."; 
			}
		}

		public override bool ShouldSellInvestment(Quote quote, Investment investment)
		{
			return ShouldSellInvestment(quote, investment, HIGHPERCENTAGE, LOWPERCENTAGE, DAYS);
		}
	}
}
