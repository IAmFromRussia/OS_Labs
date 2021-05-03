using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SandBox
{

    class Data
    {

        class Program
    {
        static async Task Main(string[] args)
        {
            using var client = new HttpClient();
            string uri = @"https://www.cbr-xml-daily.ru/daily_json.js";
            
            client.DefaultRequestHeaders.Add("User-Agent","C# console program");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage responseMessage = await client.GetAsync(uri);
            responseMessage.EnsureSuccessStatusCode();
            var result = await responseMessage.Content.ReadAsStringAsync();
            
            
            var myObj = JsonConvert.DeserializeObject<Data>(result);
            

        }
    }
}