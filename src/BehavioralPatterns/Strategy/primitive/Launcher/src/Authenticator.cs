using System.Text.Json;

namespace Launcher.src;

public class Authenticator
{
    public static async Task<AuthResponse> AuthenticateAsync(string url, string jwt)
    {
        AuthResponse authResponse = null;
        
        try
        {
            var response =
                await WebRequestHelper.SendPostRequestAsync(url, jwt);

            authResponse = JsonSerializer.Deserialize<AuthResponse>(response);
        }
        catch (JsonException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            if (authResponse == null)
            {
                authResponse = new AuthResponse()
                {
                    IsAuthenticated = false,
                };
            }
        }
       
        return authResponse;
    }
    
}
