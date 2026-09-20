
using Blockchain.Application.Contracts;
using Blockchain.Application.Models;
using Blockchain.Application.Requests;
using Blockchain.Application.Responses;
using BlockChain.Application.Responses.BaseResponse;

namespace BlockChain.Application.Services
{
    internal class BlockHistoryService : IBlockHistoryService
    {
        private readonly IBlockHistoryWriteOnlyUOW _writeOnlyRepository;
        private readonly IBlockCypherRepository _cypherRepository;

        public BlockHistoryService(IBlockCypherRepository cypherRepository, IBlockHistoryWriteOnlyUOW writeOnlyRepository)
        {
            _cypherRepository = cypherRepository;
            _writeOnlyRepository = writeOnlyRepository;
        }

        public async Task<BlockHistoryBaseResponse> GetBlockCypher(CypherRequest request, CancellationToken token) 
        {
            var blockHistoryEntry = await _cypherRepository.GetBaseBlockHistoryAsync(request, token);
            switch(blockHistoryEntry)
            {
                case EtheriumBlockHistoryResponse:
                    
                    break;
                case DefaultBlockHistoryResponse:
                    
                    break;
                default:
                    break;
            }
            return blockHistoryEntry;
        }
    }
}
