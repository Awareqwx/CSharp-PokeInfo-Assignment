using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace PokeInfo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("pokemon/{pokeid}")]
        public IActionResult Index(int pokeid)
        {
            var pokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse => 
            {
                pokeInfo = ApiResponse;
            }).Wait();
            ViewBag.pokeInfo = pokeInfo;
            return View();
        }
    }
}
