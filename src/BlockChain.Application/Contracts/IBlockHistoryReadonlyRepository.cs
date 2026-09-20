using Blockchain.Application.Models.BaseModels;
using Blockchain.Application.Queries;


namespace Blockchain.Application.Contracts
{
    public interface IBlockHistoryReadonlyRepository
    {
        Task<IList<BlockHistoryBaseModel>> GetBlockHistoryPaged(GetHistoryEntryPageQuery query);
    }
}
