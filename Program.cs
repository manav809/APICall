//Manav Minesh Patel
using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebAPIClient 
{
    class House
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("region")]
        public string? Region { get; set; }

        [JsonProperty("words")]
        public string? Words { get; set; }

    }


    class Program
    {
        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }
        private static async Task ProcessRepositories()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter random digit to get information on a House in Game of Thrones. Press Enter without writing a digit to quit the program.");

                    var regionCode = Console.ReadLine();

                    if (string.IsNullOrEmpty(regionCode))
                    {
                        break;
                    }
                    var result = await client.GetAsync("https://anapioficeandfire.com/api/houses/" + regionCode);
                    var resultRead = await result.Content.ReadAsStringAsync();

                    var house = JsonConvert.DeserializeObject<House>(resultRead);

                    Console.WriteLine("----");
                    Console.WriteLine("House Name: " + house.Name);
                    Console.WriteLine("House Region: " + house.Region);
                    Console.WriteLine("House Motto: " + house.Words);
                    Console.WriteLine("\n----");


                }
                catch (Exception)
                {
                    Console.WriteLine("Error. Please enter a random id!\n");
                }
            }

        }
        private static readonly HttpClient client = new HttpClient();
    }
}