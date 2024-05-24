using POC.WhatsAppApiIntegration.Models;
using POC.WhatsAppApiIntegration.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IWhatsAppService, WhatsAppService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapPost("/sendmessage/template", async (SendMessageWithTemplateRequest sendMessageRequest, IWhatsAppService whatsAppService) =>
{
    WhatsAppApiRequestBody body = new()
    {
        To = sendMessageRequest.To,
        Type = WhatsAppConsts.Types.TEMPLATE,
        Template = new()
        {
            Name = sendMessageRequest.Template,
            Language = new()
            {
                Code = sendMessageRequest.Language,
            },
        }
    };

    var parameters = sendMessageRequest.Parameters
        .Select(p => new WhatsAppApiRequestBodyTemplateComponentParameter
        {
            Text = p
        }).ToList();
    if (parameters.Count != 0)
    {
        body.Template.Components.Add(new WhatsAppApiRequestBodyTemplateComponent
        {
            Parameters = parameters
        });
    }

    var response = await whatsAppService.SendMessage(body);
    return response;
})
.WithName("SendMessageWithTemplate")
.WithOpenApi();

app.MapPost("/sendmessage/text", async (SendMessageWithTextRequest sendMessageRequest, IWhatsAppService whatsAppService) =>
{
    WhatsAppApiRequestBody body = new()
    {
        To = sendMessageRequest.To,
        Type = WhatsAppConsts.Types.TEXT,
        Text = new()
        {
            Body = sendMessageRequest.Text
        }
    };
    var response = await whatsAppService.SendMessage(body);
    return response;
})
.WithName("SendMessageWithText")
.WithOpenApi();

app.Run();

record SendMessageRequest
{
    public required string To { get; init; }
}

record SendMessageWithTemplateRequest : SendMessageRequest
{
    public required string Template { get; init; }
    public required string Language { get; init; }
    public IList<string> Parameters { get; set; } = [];
}

record SendMessageWithTextRequest : SendMessageRequest
{
    public required string Text { get; init; }
}