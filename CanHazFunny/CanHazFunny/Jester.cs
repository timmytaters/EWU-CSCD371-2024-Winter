using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//Implement the Jester class. It should take in both interfaces as dependencies. These dependencies should be null checked. ✔❌
//The Jester class TellJoke() method should retrieve a joke from the JokeService. If the joke contains "Chuck Norris", skip it and get another.
//The joke should be written to the output dependency. ✔❌
namespace CanHazFunny;

public class Jester
{
    private IJokePrint jokePrint;
    private IJokeService jokeService;
    //Supressed because the exceptions below ensure that they are not null
#pragma warning disable CS8618 
    public Jester(IJokePrint jokePrint, IJokeService jokeService)
#pragma warning restore CS8618 
    {
        ArgumentNullException.ThrowIfNull(jokePrint);
        ArgumentNullException.ThrowIfNull(jokeService);
        JokePrint = jokePrint;
        JokeService = jokeService;
    }

    public IJokeService JokeService { get => jokeService; set => jokeService = value; }
    public IJokePrint JokePrint { get => jokePrint; set => jokePrint = value; }

    public void TellJoke()
    {
        JokePrint.PrintJoke(JokeService.GetJoke());
    }
}
