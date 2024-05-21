using POC.WhatsAppApiIntegration.Models;

namespace POC.WhatsAppApiIntegration.Services;

public interface IWhatsAppService
{
    Task<string> SendMessage(WhatsAppApiRequestBody requestBody);
}
