using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWalletProject.ApiModel
{
    public class RatesMonobank
    {
        [JsonProperty(PropertyName = "currencyCodeA")]
        public string Сurrency { get; set; }
        [JsonProperty(PropertyName = "currencyCodeB")]
        public string BaseCurrency { get; set; }

        [JsonProperty(PropertyName = "rateBuy")]
        public string Buy { get; set; }

        [JsonProperty(PropertyName = "rateSell")]
        public string Sale { get; set; }
       
    }
}
