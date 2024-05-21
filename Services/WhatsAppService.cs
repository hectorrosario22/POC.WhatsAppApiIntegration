using System.Text.Json;
using System.Text.Json.Serialization;
using POC.WhatsAppApiIntegration.Models;

namespace POC.WhatsAppApiIntegration.Services;

public class WhatsAppService(IConfiguration configuration) : IWhatsAppService
{
    public async Task<string> SendMessage(WhatsAppApiRequestBody requestBody)
    {
        var token = configuration["WhatsApp:Token"];

        using HttpClient client = new();
        client.DefaultRequestHeaders.Authorization = new("Bearer", token);

        var response = await client.PostAsJsonAsync("https://graph.facebook.com/v19.0/310648222134959/messages", requestBody);
        var responseDynamic = await response.Content.ReadFromJsonAsync<dynamic>();
        var responseJson = JsonSerializer.Serialize(responseDynamic, new JsonSerializerOptions
        {
            WriteIndented = true,
        });

        return responseJson;
    }
}