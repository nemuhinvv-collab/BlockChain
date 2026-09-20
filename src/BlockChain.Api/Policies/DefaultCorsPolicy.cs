namespace BlockChain.Api.Policies
{
    public static class DefaultCorsPolicy
    {
        public const string PolicyName = "DefaultCorsPolicy";
        public static void ConfigureCorsPolicy(Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions options)
        {
            options.AddPolicy("DefaultCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        }
    }
}
