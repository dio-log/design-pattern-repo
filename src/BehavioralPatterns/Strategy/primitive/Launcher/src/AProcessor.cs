namespace Launcher.src;

public class AProcessor : IProcessor
{
    private const string _authUrl = "http://localhost:8081/auth";   
    private const string _sftpUrl = "http://localhost:8081/sftp";
    
    public async void Process(string queryString)
    {
        // IProgress<int>
        try
        {
            var args = QueryStringConverter.ConvertTo<AExeArguments>(queryString);
            
            var authResponse = await Authenticator.AuthenticateAsync(_authUrl, args.AccessToken);

            if (!authResponse.IsAuthenticated) return;

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        
    }
    
}