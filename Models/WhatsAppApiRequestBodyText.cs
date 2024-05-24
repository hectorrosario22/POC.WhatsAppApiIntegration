using System.Text.Json.Serialization;

namespace POC.WhatsAppApiIntegration.Models;

public class WhatsAppApiRequestBodyText
{
    [JsonPropertyName("preview_url")]
    public bool PreviewUrl { get; set; }
    public required string Body { get; set; }
}
