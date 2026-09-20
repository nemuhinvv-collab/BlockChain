using Blockchain.Application.Requests;
using BlockChain.Application.Responses.BaseResponse;

namespace Blockchain.Application.Contracts
{
    public interface IBlockCypherRepository
    {
        Task<BlockHistoryBaseResponse?> GetBaseBlockHistoryAsync(CypherRequest request, CancellationToken token);
    }
}
