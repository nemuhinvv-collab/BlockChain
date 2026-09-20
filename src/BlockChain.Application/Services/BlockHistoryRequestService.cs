
using BlockChain.Application.Contracts;
using BlockChain.Application.Mappers;
using BlockChain.Application.Requests;
using BlockChain.Application.Responses;

namespace BlockChain.Application.Services
{
    public class BlockHistoryRequestService : IBlockHistoryRequestService
    {
        private readonly IBlockHistoryReadonlyRepository _readOnlyRepository;
        public BlockHistoryRequestService(IBlockHistoryReadonlyRepository readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
        }
        public async Task<IList<BlockHistoryQueryResponse>> GetBlockHistoryPaged(GetHistoryEntryPageRequest query)
        {
            var result = await _readOnlyRepository.GetBlockHistoryPaged(query.MapToGetHistoryEntryPageQuery());
            return result.Select(x => x.MapToDefaultHistoryQueryResponse()).ToList();
        }
    }
}
