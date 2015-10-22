using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mia.Core;

namespace Mia.Site
{
	public class QuoteViewModel
	{
		public string Symbol { get; set; }
		public string Name { get; set; }
		public DateTime CreateDate { get; set; }
		public decimal LastTradePrice { get; set; }

		public QuoteViewModel(Quote quote)
		{
			Symbol = quote.Symbol;
			Name = quote.Name;
			CreateDate = quote.CreateDate;
			LastTradePrice = quote.LastTradePrice.Value / 100;
		}
	}
}
