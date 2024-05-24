namespace POC.WhatsAppApiIntegration.Models;

public class WhatsAppApiRequestBodyTemplate
{
    public required string Name { get; set; } = string.Empty;
    public WhatsAppApiRequestBodyTemplateLanguage Language { get; set; } = new();
    public ICollection<WhatsAppApiRequestBodyTemplateComponent> Components { get; set; } = [];
}

public class WhatsAppApiRequestBodyTemplateComponent
{
    public string Type { get; set; } = "body";
    public ICollection<WhatsAppApiRequestBodyTemplateComponentParameter> Parameters { get; set; } = [];
}

public class WhatsAppApiRequestBodyTemplateComponentParameter
{
    public string Type { get; set; } = "text";
    public required string Text { get; set; }
}
