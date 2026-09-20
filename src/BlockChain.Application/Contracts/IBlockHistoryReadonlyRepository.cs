using BlockChain.Application.Models.BaseModels;
using BlockChain.Application.Queries;


namespace BlockChain.Application.Contracts
{
    public interface IBlockHistoryReadonlyRepository
    {
        Task<IList<BlockHistoryBaseModel>> GetBlockHistoryPaged(GetHistoryEntryPageQuery query);
    }
}
