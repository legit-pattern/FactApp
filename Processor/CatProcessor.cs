﻿using Newtonsoft.Json;
using project_ramverket.DataProvider;
using project_ramverket.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace project_ramverket.Processor
{
    public class CatProcessor
    {
        public static async Task<FactModel> LoadFact()
        {
            const string url = "https://cat-fact.herokuapp.com/facts/random";
            FactModel fact = null;
            using (HttpResponseMessage resp = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (resp.IsSuccessStatusCode)
                {
                    var res = await resp.Content.ReadAsStringAsync();
                    fact = JsonConvert.DeserializeObject<FactModel>(res);
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
