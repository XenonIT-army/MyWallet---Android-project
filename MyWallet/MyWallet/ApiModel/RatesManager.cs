using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.ApiModel
{
    class RatesManager
    {
        NetworkManager networkManager;
        public RatesManager()
        {
            networkManager = new NetworkManager();
        }

        public Task<IList<RatesMonobank>> GetRatesMonobank()
        {
            return Task.Run(() =>
            {
                IList<RatesMonobank> searchResults = new List<RatesMonobank>();
                string urlRates = $"https://api.monobank.ua//bank/currency";
                string json = networkManager.GetJson(urlRates);
                JArray array = JArray.Parse(json);
                 
                foreach (JToken jToken in array)
                {
                    RatesMonobank rates = jToken.ToObject<RatesMonobank>();
                    if (rates.Сurrency == "840" && searchResults.Count<3)
                    {
                        rates.Сurrency = "USD";
                        rates.BaseCurrency = "UAH";
                        searchResults.Add(rates);

                    }
                    else if (rates.Сurrency == "978" && searchResults.Count < 3)
                    {
                        rates.Сurrency = "EUR";
                        rates.BaseCurrency = "UAH";
                        searchResults.Add(rates);
                    }
                    else if (rates.Сurrency == "643" && searchResults.Count < 3)
                    {
                        rates.Сurrency = "RUR";
                        rates.BaseCurrency = "UAH";
                        searchResults.Add(rates);
                    }
                }
                return searchResults;
            });
        }
        public Task<IList<RatesPrivatBank>> GetRatesPrivatbank()
        {
            return Task.Run(() =>
            {
                IList<RatesPrivatBank> searchResults = new List<RatesPrivatBank>();
                string urlRates = $"https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5";
                string json = networkManager.GetJson(urlRates);
                JArray array = JArray.Parse(json);
                foreach (JToken jToken in array)
                {
                    RatesPrivatBank rates = jToken.ToObject<RatesPrivatBank>();
                    searchResults.Add(rates);
                }
                return searchResults;
            });
        }
    }
}
