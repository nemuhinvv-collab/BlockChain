using Microsoft.EntityFrameworkCore;


namespace BlockChain.Infrastructure.Context
{
    internal class SaveOnlyBlockHistoryContext : BlockHistoryBaseContext
    {
        public SaveOnlyBlockHistoryContext(DbContextOptions<SaveOnlyBlockHistoryContext> options)
            : base(options)
        {
        }
    }
}
