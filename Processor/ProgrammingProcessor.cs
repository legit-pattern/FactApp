using Newtonsoft.Json;
using project_ramverket.DataProvider;
using project_ramverket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace project_ramverket.Processor
{
    class ProgrammingProcessor
    {
        public static async Task<ProgrammingModel> LoadFact()
        {
            const string url = "https://programming-quotes-api.herokuapp.com/quotes/random";
            ProgrammingModel fact = null;
            using (HttpResponseMessage resp = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (resp.IsSuccessStatusCode)
                {
                    var res = await resp.Content.ReadAsStringAsync();
                    fact = JsonConvert.DeserializeObject<ProgrammingModel>(res);
                }
                else
                {
                    throw new Exception(resp.ReasonPhrase);
                }
            }
            return fact;
        }
    }
}