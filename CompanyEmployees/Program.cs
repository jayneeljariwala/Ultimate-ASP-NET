using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using NLog.Config;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile(
    Path.Combine(Directory.GetCurrentDirectory(), "nlog.config")
);

builder.Services.ConfigureCors();
builder.Services.ConfigureLoggerService();

// Add services to the container.
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddControllers(
    config =>
    {
        config.RespectBrowserAcceptHeader = true;
        config.ReturnHttpNotAcceptable = true;
    }
)
    .AddXmlDataContractSerializerFormatters()
    .AddApplicationPart(typeof(CompanyEmployees.Presentation.AssemblyReference).Assembly);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
