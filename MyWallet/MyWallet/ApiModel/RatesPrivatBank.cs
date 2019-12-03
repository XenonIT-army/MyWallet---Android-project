using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWallet.ApiModel
{
    public class RatesPrivatBank
    {
        [JsonProperty(PropertyName = "ccy")]
        public string Сurrency { get; set; }
        [JsonProperty(PropertyName = "base_ccy")]
        public string BaseCurrency { get; set; }

        [JsonProperty(PropertyName = "buy")]
        public string Buy { get; set; }

        [JsonProperty(PropertyName = "sale")]
        public string Sale { get; set; }
    }
}
