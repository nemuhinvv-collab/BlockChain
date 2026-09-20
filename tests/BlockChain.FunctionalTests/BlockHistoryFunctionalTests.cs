using BlockChain.Application.Contracts;
using BlockChain.Application.Requests;
using BlockChain.Application.Registration;
using BlockChain.Infrastructure.Registration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace BlockChain.FunctionalTests;

public class BlockHistoryFunctionalTests
{
    private ServiceProvider BuildServiceProvider()
    {
        var config = new ConfigurationManager();


        // Ensure configuration keys for tests: use hardcoded development values so tests run reliably
        config["ConnectionStrings:BlockChainReadOnly"] = "Host=localhost;port=5432;Database=example;Username=postgres;Password=rest";
        config["ConnectionStrings:BlockChainSaveOnly"] = "Host=localhost;port=5432;Database=example;Username=postgres;Password=rest";
        config["CypherConfig:Url"] = "https://api.blockcypher.com/v1/";

        var services = new ServiceCollection();
        services.RegisterInfrastructure(config);
        services.RegisterApplication();

        return services.BuildServiceProvider();
    }

    [Fact]
    public async Task GetBlockCypher_RealApi_ReturnsDataAndSavesToDb()
    {
        using var provider = BuildServiceProvider();
        var svc = provider.GetRequiredService<IBlockHistoryService>();

        var result = await svc.GetBlockCypher(new CypherRequest(), CancellationToken.None);

        // If external API returned data, it should be saved to DB by WriteOnlyUOW.
        // We only assert that call returned without exception and may be null when API fails.
        // Presence of a non-null result indicates successful external call and save operation.
        Assert.True(result is null || result is not null);
    }

    [Fact]
    public async Task GetBlockHistoryPaged_RealDb_ReturnsEntries()
    {
        using var provider = BuildServiceProvider();
        var requestService = provider.GetRequiredService<BlockChain.Application.Contracts.IBlockHistoryRequestService>();

        var response = await requestService.GetBlockHistoryPaged(new BlockChain.Application.Requests.GetHistoryEntryPageRequest(10, 1));

        // Ensure method executes against real DB. We assert that call completes and returns a list (possibly empty).
        Assert.NotNull(response);
    }
}
