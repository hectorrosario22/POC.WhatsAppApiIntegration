namespace POC.WhatsAppApiIntegration.Models;

public class WhatsAppApiRequestBodyTemplate
{
    public string Name { get; set; } = string.Empty;
    public WhatsAppApiRequestBodyTemplateLanguage Language { get; set; } = new();
}
