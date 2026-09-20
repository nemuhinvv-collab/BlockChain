
using BlockChain.Api.Policies;
using BlockChain.Application.Registration;
using BlockChain.Infrastructure.Registration;

namespace BlockChain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateSlimBuilder(args);
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                      .AddEnvironmentVariables();
            builder.Services.RegisterApplication();
            builder.Services.RegisterInfrastructure(builder.Configuration);
            builder.Services.AddControllers();

            builder.Services.AddOpenApiDocument(configure =>
            {
                configure.Title = "BlockChain API";
                configure.Version = "v1";
                configure.Description = "A simple blockchain API built with .NET 10 and C# 14.";
            });
            builder.Services.AddCors(DefaultCorsPolicy.ConfigureCorsPolicy);

            var app = builder.Build();

            app.MapControllers(); 
            app.UseCors(DefaultCorsPolicy.PolicyName);
            app.MapHealthChecks("/health");
            app.UseOpenApi();
            app.UseSwaggerUi();

            app.Run();
        }
    }
}
