using System;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class TestLoader
    {
        public async Task<string> LoadTestFromServer()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://education.turgaliev.kz/maxim/tests/");
                    response.EnsureSuccessStatusCode();
                    string data = await response.Content.ReadAsStringAsync();

                    return data;
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
    }   }
}
