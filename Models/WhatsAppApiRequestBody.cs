using System.Text.Json.Serialization;

namespace POC.WhatsAppApiIntegration.Models;

public class WhatsAppApiRequestBody
{
    [JsonPropertyName("messaging_product")]
    public string MessagingProduct { get; set; } = "whatsapp";
    public string Type { get; set; } = "template";
    public string To { get; set; } = string.Empty;
    public WhatsAppApiRequestBodyTemplate Template { get; set; } = new();
}