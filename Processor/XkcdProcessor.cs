using Newtonsoft.Json;
using project_ramverket.DataProvider;
using project_ramverket.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace project_ramverket.Processor
{
    public class XkcdProcessor
    {
        public static async Task<XkcdModel> LoadImage()
        {
            Random rnd = new Random();
            var rndInt = rnd.Next(1, 1999);
            var url = "https://www.xkcd.com/" + rndInt + "/info.0.json";
            XkcdModel img = null;
            using (HttpResponseMessage resp = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (resp.IsSuccessStatusCode)
                {
                    var res = await resp.Content.ReadAsStringAsync();
                    img = JsonConvert.DeserializeObject<XkcdModel>(res);
                }
                else
                {
                    throw new Exception(resp.ReasonPhrase);
                }
            }
            return img;
        }
    }
}
