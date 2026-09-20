using BlockChain.Application.Contracts;
using BlockChain.Application.Models.BaseModels;
using BlockChain.Application.Queries;
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
