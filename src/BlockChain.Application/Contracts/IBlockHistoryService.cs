using BlockChain.Application.Requests;
using BlockChain.Application.Responses.BaseResponse;

namespace BlockChain.Application.Contracts
{
    public interface IBlockHistoryService
    {
        Task<BlockHistoryBaseResponse?> GetBlockCypher(CypherRequest request, CancellationToken token);
    }
}
