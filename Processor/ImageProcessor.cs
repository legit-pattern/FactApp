using Newtonsoft.Json;
using project_ramverket.DataProvider;
using project_ramverket.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace project_ramverket.Processor
{
    public class ImageProcessor
    {
        public static async Task<ImageModel> LoadImage()
        {
            const string url = "https://api.thecatapi.com/v1/images/search";
            ImageModel img = null;
            using (HttpResponseMessage resp = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (resp.IsSuccessStatusCode)
                {
                    var res = await resp.Content.ReadAsStringAsync();
                    // Because res is a string in the form [{...}] ,
                    // so we remove the first and last bracket to prevent program from crashing...
                    res = res.Remove(res.Length - 1).Remove(0, 1);
                    img = JsonConvert.DeserializeObject<ImageModel>(res);
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