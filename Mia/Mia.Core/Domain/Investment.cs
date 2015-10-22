using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Core
{
	public class Investment
	{
		public Guid Id { get; set; }
		public string PlayerName { get; set; }
		public string Symbol { get; set; }
		public int Quantity { get; set; }
		public DateTime PurchaseDate { get; set; }
		public DateTime? SellDate { get; set; }	
		public decimal PurchasePrice { get; set; }
		public decimal? SellPrice { get; set; }
		public SellReason? SellReason { get; set; }
	}
}
