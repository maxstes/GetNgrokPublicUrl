using System;
using System.Net.Http;
using System.Threading.Tasks;
using GetNgrokUrlTunnel;
using Newtonsoft.Json;

class Program
{
    static HttpClient client = new HttpClient();

    static async Task Main(string[] args)

    {
        //URL Web Interface
        string ngrokApiUrl = "http://127.0.0.1:4040/api/tunnels";
        try
        {
            HttpResponseMessage? response = await client.GetAsync(ngrokApiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                NgrokTunnel? ngrokTunnel = JsonConvert.DeserializeObject<NgrokTunnel>(responseBody);

                foreach (var tunnel in ngrokTunnel.Tunnels)
                {
                    Console.WriteLine($"Name: {tunnel.name}, Public URL: {tunnel.public_url}");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        catch (HttpRequestException ex)
        {
            //Maybe you forgot to start ngok
            await Console.Out.WriteLineAsync(ex.Message);
        }
    }
}
