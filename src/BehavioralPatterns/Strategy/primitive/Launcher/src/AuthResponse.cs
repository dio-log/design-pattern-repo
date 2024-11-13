using System.Text.Json.Serialization;

namespace Launcher.src;

public class AuthResponse
{
    public bool IsAuthenticated { get; set; }
    public string Code { get; set; }
    public string Message { get; set; }
    public string UserId { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}