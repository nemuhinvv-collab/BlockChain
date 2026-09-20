using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
