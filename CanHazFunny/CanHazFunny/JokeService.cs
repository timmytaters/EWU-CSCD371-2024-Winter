using System.Net.Http;

<<<<<<< HEAD
namespace CanHazFunny
{
    public class JokeService : IJokeService
    {
        private HttpClient HttpClient { get; } = new();

        public string GetJoke()
        {
            string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
            while(joke.Contains("Chuck Norris"))
            {
                joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
            }
            return joke;
        }
=======
namespace CanHazFunny;

public class JokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
        return joke;
>>>>>>> d7110209c32aafd7f0d4bd877409d09bf9f50e1a
    }
}
