using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace Mia.Core.Google
{
	internal class JsonQuote
	{
        private DateTime? _lastTrade;

		public Guid RowId { get; internal set; }

		[JsonProperty("id")]
		public string Id { get; internal set; }

		[JsonProperty("e")]
		public string Exchange { get; internal set; }

		[JsonProperty("l")]
		public decimal? Price { get; internal set; }

		[JsonProperty("lt")]
		internal string lt { get; set; }

		[JsonProperty("t")]
		public string Symbol { get; internal set; }

        public DateTime LastTrade
        {
            get
            {
                if (_lastTrade == null)
                {
                    if (string.IsNullOrEmpty(lt))
                    {
                        _lastTrade = DateTime.Today.AddDays(-1000);
                    }
                    else
                    {
                        // e.g. Dec 17, 3:41PM GMT - take everything before GMT
                        string date = lt.Substring(0, lt.IndexOf("GMT")).Trim();
                        _lastTrade = DateTime.Parse(date);//.ParseExact(date, "MMM dd, h:mmtt", CultureInfo.InvariantCulture);
                    }
                }

                return _lastTrade.Value;
            }
            internal set
            {
                _lastTrade = value;
            }
        }

		public DateTime UpdateDate { get; internal set; }
	}
}
