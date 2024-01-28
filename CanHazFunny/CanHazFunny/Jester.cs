using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//Implement the Jester class. It should take in both interfaces as dependencies. These dependencies should be null checked. ✔❌
//The Jester class TellJoke() method should retrieve a joke from the JokeService. If the joke contains "Chuck Norris", skip it and get another.
//The joke should be written to the output dependency. ✔❌
namespace CanHazFunny
{
    public class Jester(IJokePrint jokePrint, IJokeService jokeService) 
    {
        public IJokePrint jokePrint { get; set; } = jokePrint;
        public IJokeService jokeService { get; set; } = jokeService;
        private HttpClient HttpClient { get; } = new();
    }
}
