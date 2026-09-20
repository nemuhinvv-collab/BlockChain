using BlockChain.Infrastructure.Configurations;
using BlockChain.Infrastructure.Context;
using BlockChain.Infrastructure.Repository;
using BlockChain.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Blockchain.Application.Contracts;

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
                options.UseNpgsql(configuration.GetConnectionString("BlockChainReadOnly"));
            });
            services.AddHealthChecks().AddNpgSql(configuration.GetConnectionString("BlockChainSaveOnly"));
            services.AddScoped<IBlockHistoryReadonlyRepository, BlockHistoryReadOnlyRepository>();
            services.AddScoped<IBlockHistoryWriteOnlyRepository, BlockHistoryWriteOnlyRepository>();
            services.AddScoped<IBlockHistoryWriteOnlyUOW, BlockHistoryWriteOnlyUOW>();
        }
    }
}
