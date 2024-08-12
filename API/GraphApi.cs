using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace PangoTest.API;

public class GraphApi
{
    private static readonly HttpClient _client = new HttpClient();
    
    
    public static async Task<string> GetAsync(string endpoint)
    {
        HttpResponseMessage response = await _client.GetAsync(endpoint);
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }
        return await response.Content.ReadAsStringAsync();
    }
    

    
    

    
}