using BlockChain.Application.Requests;
using BlockChain.Application.Responses.BaseResponse;

namespace BlockChain.Application.Contracts
{
    public interface IBlockCypherRepository
    {
        Task<BlockHistoryBaseResponse?> GetBaseBlockHistoryAsync(CypherRequest request, CancellationToken token);
    }
}
