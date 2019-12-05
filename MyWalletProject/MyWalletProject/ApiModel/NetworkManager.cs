using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MyWalletProject.ApiModel
{
    class NetworkManager
    {
       
            public string GetJson(string url)
            {
                HttpClient client = new HttpClient();
                var task = client.GetAsync(url).Result;
                return task.Content.ReadAsStringAsync().Result;
            }
    }
}
