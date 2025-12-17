
using CManager.Domain.Models;
using System.Text.Json;

namespace CManager.Infrastructure.Serializations;

public class JsonFormatter
{

    private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };


    public static string SerializeObject<T>(T content)
    {
        var json = JsonSerializer.Serialize(content, _options);

        return json;
    }

    public static T? DeserializeObject<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, _options);
    }
}
