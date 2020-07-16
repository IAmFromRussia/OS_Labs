using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SandBox
{
    class Currensies
    {
        [JsonProperty("Valute")]
        public string valuteName { get; set; }
        
        [JsonProperty("ID")]
        public int Id { get; set; }
        
        [JsonProperty("NumCode")]
        public int NumCode { get; set; }
        
        [JsonProperty("CharCode")]
        public string CharCode { get; set; }
        
        [JsonProperty("Nominal")]
        public int Nominal { get; set; }
        
        [JsonProperty("Name")]
        public string Name { get; set; }
        
        [JsonProperty("Value")]
        public decimal Value { get; set; }
        
        [JsonProperty("Previous")]
        public decimal Previous { get; set; }
    }

    class Valute
    {
        [JsonProperty("Valute")]
        public string Name { get; set; }
    }
    
    
    class Program
    {
        static async Task Main(string[] args)
        {
            using var client = new HttpClient();
            string uri = @"https://www.cbr-xml-daily.ru/daily_json.js";

            HttpResponseMessage responseMessage = await client.GetAsync(uri);
            responseMessage.EnsureSuccessStatusCode();
            var result = await responseMessage.Content.ReadAsStringAsync();
            
            
            var list = JsonConvert.DeserializeObject<List<Currensies>>(result);
            
            list.ForEach(Console.WriteLine);            

        }
    }
}