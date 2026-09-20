using BlockChain.Application.Contracts;
using BlockChain.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlockChain.Application.Registration
{
    public static class ApplicationRegistration
    {
        public static void RegisterApplication(this IServiceCollection services) 
        {
            services.AddScoped<IBlockHistoryService, BlockHistoryService>();
            services.AddScoped<IBlockHistoryRequestService, BlockHistoryRequestService>();
            services.AddSingleton(TimeProvider.System);
        }
    }
}
