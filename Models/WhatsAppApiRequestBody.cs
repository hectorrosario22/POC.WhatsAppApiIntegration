using System.Text.Json.Serialization;

namespace POC.WhatsAppApiIntegration.Models;

public class WhatsAppApiRequestBody
{
    [JsonPropertyName("messaging_product")]
    public string MessagingProduct { get; set; } = "whatsapp";
    [JsonPropertyName("recipient_type")]
    public string RecipientType { get; set; } = "individual";
    public required string Type { get; set; }
    public required string To { get; set; } = string.Empty;
    public WhatsAppApiRequestBodyTemplate? Template { get; set; }
    public WhatsAppApiRequestBodyText? Text { get; set; }
}
