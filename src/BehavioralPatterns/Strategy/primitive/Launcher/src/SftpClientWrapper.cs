using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace Launcher.src;

public class SftpClientWrapper
{
    private SftpClient _client;
    
    public SftpClientWrapper(string host, int port, string username, string password)
    {
        _client = new SftpClient(host, port, username, password);        
    }
    public void Connect()
    {
        if(_client.IsConnected) return;
        
        _client.Connect();
    }

    public void Disconnect()
    {
        _client.Disconnect();
        _client.Dispose();
    }
    
    //래퍼는 래퍼답게 기능제공만하고 
    //어떻게 사용할지는 외부에서 따로 로직을 더 작성하는게 맞는것 같다. 

    public void ConditionalDownloadFiles(string remoteDirPath, string localDirPath, Func<SftpFile, FileInfo, bool> predicate)
    {
        Connect();
        
        
        var sftpFiles =_client.ListDirectory(remoteDirPath);
        
        
        
    }

    private string CombinePath(params string[] paths)
    {
        // paths = paths.Distinct().ToArray();


        return "";
    }
    
    
}