using BlockChain.Application.Responses.BaseResponse;
using Blockchain.Application.Requests;
using Blockchain.Application.Contracts;
using BlockChain.Infrastructure.Extensions;
using System.Net.Http.Json;
using System.Text.Json;





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
            var jsonOption = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            };
            jsonOption.Converters.Add(new BlockHistoryConverter());

            using var cypherResponse = await _httpClient.GetAsync($"{request.BlockChainType.ToString().ToLowerInvariant()}/{request.BlockChainMode.ToString().ToLowerInvariant()}", token);
            if (cypherResponse.IsSuccessStatusCode)
            {   
                return await cypherResponse.Content.ReadFromJsonAsync<BlockHistoryBaseResponse>(jsonOption, token);
            }
            return default; 
        }
    }
}
