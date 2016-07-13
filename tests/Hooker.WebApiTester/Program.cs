using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Hooker.WebApiTester
{
    internal class Program
    {
        private static void Main()
        {
            PostToBuildServer().Wait();
        }

        static async Task PostToBuildServer()
        {
            const string baseAddress = "https://buildservertmit.cloudapp.net:443/";
            const string requestUri = "bitbucket-hook";
            const string userName = "TimMurphy";
            const string password = "u06NCJSM0KrTnQqVZpRVzL7Vd0w9pyVa"; // todo: move to app secrets

            var postValue = new { test = "this is a test" };
            var encoded = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{userName}:{password}"));

            try
            {
                Console.WriteLine("Creating HTTP client...");
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encoded);

                    Console.WriteLine("POST {0}...", requestUri);
                    using (var response = await client.PostAsJsonAsync(requestUri, postValue))
                    {
                        Console.WriteLine("Response: {0}", response.StatusCode);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exception);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}