using BlockChain.Application.Contracts;
using BlockChain.Infrastructure.Configurations;
using BlockChain.Infrastructure.Context;
using BlockChain.Infrastructure.Repository;
using BlockChain.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BlockChain.Infrastructure.Registration
{
    public static class InfrastructureServiceRegistration
    {
        public static void RegisterInfrastructure(this IServiceCollection services, ConfigurationManager configuration) 
        {
            services.Configure<CypherConfiguration>(configuration.GetSection(CypherConfiguration.ConfigurationName));
            var cypherConfiguration = configuration.GetSection(CypherConfiguration.ConfigurationName).Get<CypherConfiguration>();
            services.AddScoped<IBlockCypherRepository, BlockCypherRepository>();
            services.AddHttpClient<IBlockCypherRepository, BlockCypherRepository>(p => {
                p.BaseAddress = new Uri(cypherConfiguration.Url);
            });
            services.AddDbContext<SaveOnlyBlockHistoryContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("BlockChainSaveOnly"));
            });
            services.AddDbContext<ReadOnlyBaseHistoryContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("BlockChainReadOnly"),
                    o => o.EnableRetryOnFailure(5));
            });
            services.AddHealthChecks().AddNpgSql(configuration.GetConnectionString("BlockChainSaveOnly"));
            services.AddScoped<IBlockHistoryReadonlyRepository, BlockHistoryReadOnlyRepository>();
            services.AddScoped<IBlockHistoryWriteOnlyRepository, BlockHistoryWriteOnlyRepository>();
            services.AddScoped<IBlockHistoryWriteOnlyUOW, BlockHistoryWriteOnlyUOW>();
        }
    }
}
