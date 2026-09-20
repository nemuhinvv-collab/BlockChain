
using BlockChain.Application.Contracts;
using BlockChain.Application.Requests;
using BlockChain.Application.Responses;
using BlockChain.Application.Mappers;
using BlockChain.Application.Responses.BaseResponse;

namespace BlockChain.Application.Services
{
    public class BlockHistoryService : IBlockHistoryService
    {
        private readonly IBlockHistoryWriteOnlyUOW _writeOnlyRepository;
        private readonly IBlockHistoryReadonlyRepository _readOnlyRepository;
        private readonly IBlockCypherRepository _cypherRepository;
        private readonly TimeProvider _timeProvider;

        public BlockHistoryService(IBlockCypherRepository cypherRepository, IBlockHistoryWriteOnlyUOW writeOnlyRepository,
            IBlockHistoryReadonlyRepository readOnlyRepository,
            TimeProvider timeProvider)
        {
            _cypherRepository = cypherRepository;
            _writeOnlyRepository = writeOnlyRepository;
            _timeProvider = timeProvider;
            _readOnlyRepository = readOnlyRepository;
        }

        public async Task<BlockHistoryBaseResponse?> GetBlockCypher(CypherRequest request, CancellationToken token)
        {
            var blockHistoryEntry = await _cypherRepository.GetBaseBlockHistoryAsync(request, token);
            switch (blockHistoryEntry)
            {
                case EtheriumBlockHistoryResponse:
                    var etheriumBlockHistoryEntry = blockHistoryEntry as EtheriumBlockHistoryResponse;
                    await _writeOnlyRepository.SaveEtheriumBlockHistoryAsync(etheriumBlockHistoryEntry.MapToEtheriumBlockHistoryModel(_timeProvider.GetUtcNow()), token);
                    break;
                case DefaultBlockHistoryResponse:
                    var defaultBlockHistoryEntry = blockHistoryEntry as DefaultBlockHistoryResponse;
                    await _writeOnlyRepository.SaveDefaultBlockHistoryAsync(defaultBlockHistoryEntry.MapToDefaultBlockHistoryModel(_timeProvider.GetUtcNow()), token);
                    break;
                default:
                    break;
            }
            return blockHistoryEntry;
        }
    }
}
