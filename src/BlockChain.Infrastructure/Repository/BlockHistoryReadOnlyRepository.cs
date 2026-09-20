using Blockchain.Application.Contracts;
using Blockchain.Application.Models;
using Blockchain.Application.Models.BaseModels;
using Blockchain.Application.Queries;
using BlockChain.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BlockChain.Infrastructure.Repository
{
    internal class BlockHistoryReadOnlyRepository : IBlockHistoryReadonlyRepository
    {
        private readonly ReadOnlyBaseHistoryContext _context;
        
        public BlockHistoryReadOnlyRepository(ReadOnlyBaseHistoryContext context)
        {
            _context = context;
        }

        public async Task<IList<BlockHistoryBaseModel>> GetBlockHistoryPaged(GetHistoryEntryPageQuery query) 
        {
            return await _context.BlockHistories
                .OrderByDescending(b => b.CreatedAt)
                .Skip((query.pageNumber - 1) * query.pageSize)
                .Take(query.pageSize)
                .ToListAsync();
        }

    }
}
