using ExcelTest.API.Endpoints;
using ExcelTest.IoC;
using System.Security.Authentication;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddApplication(builder.Configuration, "ReadDB", "WriteDB");
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
    {
        config.AllowAnyMethod();
        config.AllowAnyHeader();
        config.AllowAnyOrigin();
    });
});
builder.Services.AddHttpClient("CustomHttpClient", c =>
{
    c.DefaultRequestHeaders.Add("Accept", "application/json");
}).ConfigurePrimaryHttpMessageHandler(() =>
{
    return new HttpClientHandler()
    {
        SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13
    };
});
var app = builder.Build();
//app.UseExceptionHandler(builder => builder.UseWebExceptionHandlerPresenter(app.Environment, app.Services.GetService<IExceptionPresenter>() ?? null!));
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors();
app.UseEndpoints();
await app.RunAsync();