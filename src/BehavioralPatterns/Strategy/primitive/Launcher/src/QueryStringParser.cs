namespace Launcher.src;

public class QueryStringParser
{
    public static Dictionary<string, List<string>> Parse(string queryString)
    {
        var queryMap = new Dictionary<string, List<string>>();

        if (string.IsNullOrWhiteSpace(queryString)) return queryMap;
        
        if(queryString.StartsWith("?")) 
            queryString = queryString.Substring(1);
        
        var pairs = queryString.Split(new []{ '&' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        
        foreach (var pair in pairs)
        {
            var keyValue = pair.Split(new[] { '=' }, 2);
            if (keyValue.Length == 0)
                continue;

            var key = DecodeUrl(keyValue[0]);
            var value = keyValue.Length > 1 ? DecodeUrl(keyValue[1]) : string.Empty;

            if (queryMap.TryGetValue(key, out var values))
            {
                values.Add(value);
            }
            else
            {
                queryMap[key] = new List<string> { value };
            }
        }

        return queryMap;
    }
    
    private static string DecodeUrl(string value)
    {
        return Uri.UnescapeDataString(value.Replace('+', ' '));
    }
}