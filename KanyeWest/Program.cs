using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace KanyeSwansonAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            // API URL
            var kanyeURL = "https://api.kanye.rest";
            // Allows us to call the API
            var client = new HttpClient();
            // Stores the JSON response in a variable
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            // Parses through the response we received to get the value
            // associated with the NAME "quote"
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

            Console.WriteLine($"Kanye: {kanyeQuote}");

            // Ron Swanson URL
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = client.GetStringAsync(ronURL).Result;
            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
            Console.WriteLine($"Ron Swanson: {ronQuote}");
        }
    }
}
