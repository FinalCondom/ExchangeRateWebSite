using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRateDTO;
using System.Net.Http;
using Newtonsoft.Json;

namespace ExchangeRateBLL
{
    public class AccessWebAPI
    {
        public List<Currency> getWebAPICurrencies()
        {
            string uri = "http://localhost:57770/api/currency";
            List<Currency> res = new List<Currency>();
            //We use an using to be sure the connection will be closed at the end of the brackets
            //we can also open the connection on the beggining and close it at the end
            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync(uri);//We use Task since Async create a new Thread
                res = JsonConvert.DeserializeObject<List<Currency>>(response.Result);//Gérer packages NuGet et import Newtonsoft.Json sur le BLL et MVC
            }
            return res;
        }

        public void addCurrency(Currency c)
        {
            string uri = "http://localhost:57770/api/currency";

            using (HttpClient client = new HttpClient())
            {
                HttpContent request = new StringContent(JsonConvert.SerializeObject(c));
                Task<HttpResponseMessage> response = client.PostAsync(uri, request);
            }

        }
        public void updateCurrency(Currency c)
        {
            string uri = "http://localhost:57770/api/currency";

            using (HttpClient client = new HttpClient())
            {
                HttpContent request = new StringContent(JsonConvert.SerializeObject(c));
                Task<HttpResponseMessage> response = client.PutAsync(uri, request);
            }
        }
        public void deleteCurrency(int id)
        {
            string uri = "http://localhost:57770/api/currency";

            using (HttpClient client = new HttpClient())
            {
                HttpContent request = new StringContent(JsonConvert.SerializeObject(id));
                Task<HttpResponseMessage> response = client.DeleteAsync(uri, request);
            }
        }
    }
}
