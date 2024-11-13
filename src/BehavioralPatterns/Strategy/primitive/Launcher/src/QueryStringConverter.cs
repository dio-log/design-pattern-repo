using System.Reflection;

namespace Launcher.src;

public class QueryStringConverter
{
    public static T ConvertTo<T>(string input) where T : new()
    {
        T obj = new T();

        var properties = typeof(T).GetProperties(BindingFlags.Public);
        
        var parsedQuery = QueryStringParser.Parse(input);
        
        foreach (var prop in properties)
        {
            if (parsedQuery.TryGetValue(prop.Name, out var values) && values.Count > 0)
            {
                string value = values[0];
                
                try
                {
                    var convertedValue = ConvertValue(value, prop.PropertyType);
                    prop.SetValue(obj, convertedValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"변환 실패: {prop.Name} = {value} ({ex.Message})");
                }
            }
        }


        return obj;
    }
    
    private static object ConvertValue(string value, Type targetType)
    {
        if (targetType == typeof(string))
            return value;

        if (targetType.IsEnum)
            return Enum.Parse(targetType, value, true);
        
        if (Nullable.GetUnderlyingType(targetType) != null)
        {
            targetType = Nullable.GetUnderlyingType(targetType);
        }

        return Convert.ChangeType(value, targetType);
    }
}