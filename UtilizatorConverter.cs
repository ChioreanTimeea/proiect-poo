using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions; 
using System.Text.Json.Serialization;
namespace proiect_poo;
public class UtilizatorConverter : JsonConverter<Utilizator>
{
    public override Utilizator Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            var jsonObject = doc.RootElement;
            var tip = jsonObject.GetProperty("Tip").GetString();
            
            return tip switch
            {
                "Profesor" => JsonSerializer.Deserialize<Profesor>(jsonObject.GetRawText(), options),
                "Student" => JsonSerializer.Deserialize<Student>(jsonObject.GetRawText(), options),
                _ => throw new JsonException($"Tip necunoscut: {tip}")
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, Utilizator value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
    }
}