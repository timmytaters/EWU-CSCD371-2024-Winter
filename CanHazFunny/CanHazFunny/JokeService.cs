using System.Net.Http;

namespace CanHazFunny;

public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
        while (joke.Contains("Chuck Norris") || joke.Contains("chuck norris"))
        {
            joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
        }
        return joke;
    }
}
