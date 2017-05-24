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
        private static string uri = "http://localhost:57770/api/currenciesEF/";
        public List<Currency> getCurrencies()
        {
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

        public Boolean insertCurrency(Currency c)
        {
            using (HttpClient client = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(c);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> response = client.PostAsync(uri, frame);
                return response.Result.IsSuccessStatusCode;
            }
        }
        public Boolean updateCurrency(Currency c)
        {
            using (HttpClient client = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(c);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> response = client.PutAsync(uri, frame);
                return response.Result.IsSuccessStatusCode;
            }
        }
        public Boolean deleteCurrency(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                Task<HttpResponseMessage> response = client.DeleteAsync(uri+id);
                return response.Result.IsSuccessStatusCode;
            }
        }
    }
}