using Blockchain.Application.Requests;
using BlockChain.Application.Responses.BaseResponse;

namespace Blockchain.Application.Contracts
{
    public interface IBlockHistoryService
    {
        Task<BlockHistoryBaseResponse?> GetBlockCypher(CypherRequest request, CancellationToken token);
    }
}
