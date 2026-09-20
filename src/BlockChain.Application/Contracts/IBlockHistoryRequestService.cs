using BlockChain.Application.Requests;
using BlockChain.Application.Responses;


namespace BlockChain.Application.Contracts
{
    public interface IBlockHistoryRequestService
    {
        Task<IList<BlockHistoryQueryResponse>> GetBlockHistoryPaged(GetHistoryEntryPageRequest query);
    }
}
