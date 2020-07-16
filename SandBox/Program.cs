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
        [JsonProperty("Date")]
        public DateTime Date { get; set; }
        
        [JsonProperty("PreviousDate")]
        public DateTime PreviousDate { get; set; }
        
        [JsonProperty("PreviuosUrl")]
        public string PreviuosUrl { get; set; }
        
        [JsonProperty("TimeStamp")]
        public DateTime TimeStamp { get; set; }
        
        // [JsonProperty("Valute")]
        // public ValuteMy Valute { get; set; }
        
        [JsonExtensionData]
        public Dictionary<string, object> ExtensionData { get; set; }
    }
    
    class ValuteMy
    {
        public string ValuteName { get; set; }

        public StandAloneValute Val { get; set; }
        
    }

    class StandAloneValute
    {
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
            
            
            var obj = JsonConvert.DeserializeObject<Root>(result);
            var myObj = JsonConvert.DeserializeObject<Data>(result);
            
            // Console.WriteLine(obj.Valute.EUR.CharCode);   
            Console.WriteLine(myObj.ExtensionData.Values.ToString());

        }
    }
}