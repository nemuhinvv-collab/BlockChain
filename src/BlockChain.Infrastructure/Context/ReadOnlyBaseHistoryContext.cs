using Microsoft.EntityFrameworkCore;

namespace BlockChain.Infrastructure.Context
{
    internal class ReadOnlyBaseHistoryContext : BlockHistoryBaseContext
    {
        public ReadOnlyBaseHistoryContext(DbContextOptions<ReadOnlyBaseHistoryContext> options) 
            : base(options)
        {
        }
    }
}
