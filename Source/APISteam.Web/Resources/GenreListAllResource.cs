using System.Text.Json.Serialization;

namespace APISteam.Web.Resources;

public class GenreListAllResource
{
    [JsonPropertyName("Type")]
    public int Type { get; set; }

    [JsonPropertyName("Image")]
    public string Image { get; set; }
}
