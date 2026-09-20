using BlockChain.Infrastructure.Context;
using BlockChain.Application.Models;
using BlockChain.Application.Contracts;

namespace BlockChain.Infrastructure.Repository
{
    internal class BlockHistoryWriteOnlyRepository : IBlockHistoryWriteOnlyRepository
    {
        private readonly SaveOnlyBlockHistoryContext _context;
        public BlockHistoryWriteOnlyRepository(SaveOnlyBlockHistoryContext context)
        {
            _context = context;
        }

        public void AddDefaultBlockHistory(DefaultBlockHistoryModel blockHistory)
        {
            _context.DefaultBlockHistories.Add(blockHistory);
        }

        public void AddEtheriumBlockHistory(EtheriumBlockHistoryModel blockHistory)
        {
            _context.EtheriumBlockHistories.Add(blockHistory);
        }

        public async Task SaveChangesAsync(CancellationToken token)
        {
            await _context.SaveChangesAsync(token);
        }
    }
}
