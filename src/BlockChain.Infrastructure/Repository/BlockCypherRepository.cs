using BlockChain.Application.Responses.BaseResponse;
using BlockChain.Application.Requests;
using BlockChain.Application.Contracts;
using BlockChain.Infrastructure.Extensions;
using System.Net.Http.Json;


namespace BlockChain.Infrastructure.Repository
{
    internal class BlockCypherRepository : IBlockCypherRepository
    {
        private readonly HttpClient _httpClient;
        public BlockCypherRepository(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<BlockHistoryBaseResponse?> GetBaseBlockHistoryAsync(CypherRequest request, CancellationToken token) 
        {
            using var cypherResponse = await _httpClient.GetAsync($"{request.BlockChainType
                .ToString()
                .ToLowerInvariant()}/{request.BlockChainMode.ToString().ToLowerInvariant()}", token);
            if (cypherResponse.IsSuccessStatusCode)
            {   
                return await cypherResponse.Content
                    .ReadFromJsonAsync<BlockHistoryBaseResponse>(JsonOptionExtension.AddSnakeCaseNamingPolicyWithTypeResolveConverter(),
                    token);
            }
            return default; 
        }
    }
}
