using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokeInfo
{
    public class WebRequest
    {
        public static async Task GetPokemonDataAsync(int PokeId, Action<Dictionary<string, object>> Callback)
        {
            using(HttpClient Client = new HttpClient())
            {
                try
                {
                    Client.BaseAddress = new Uri($"http://pokeapi.co/api/v2/pokemon/{PokeId}");
                    HttpResponseMessage response = await Client.GetAsync("");
                    response.EnsureSuccessStatusCode();
                    string stringResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine( stringResponse);

                    Dictionary<string, object> JsonResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringResponse);
                    Callback(JsonResponse);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request Exception: {e.Message}");
                }
            }
        }
    }
}