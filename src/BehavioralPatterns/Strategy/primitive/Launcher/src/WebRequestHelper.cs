namespace Launcher.src;

public class WebRequestHelper
{
    public static async Task<string> SendGetRequestAsync(string url)
    {
        using var client = new HttpClient();
        
        var responseMessage = await client.GetAsync(url);
        
        return await responseMessage.Content.ReadAsStringAsync();
    }

    public static async Task<string> SendPostRequestAsync(string url, string body)
    {
        using var client = new HttpClient();
        
        var httpContent = new StringContent(body);
        
        var responseMessage = await client.PostAsync(url, httpContent);

        return await responseMessage.Content.ReadAsStringAsync();
    }
}