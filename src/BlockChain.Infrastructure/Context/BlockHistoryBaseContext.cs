using Blockchain.Application.Models;
using Blockchain.Application.Models.BaseModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BlockChain.Infrastructure.Context
{
    internal class BlockHistoryBaseContext : DbContext
    {
        [RequiresUnreferencedCode("Calls Microsoft.EntityFrameworkCore.DbContext.DbContext(DbContextOptions)")]
        public BlockHistoryBaseContext(DbContextOptions options)
            : base(options)
        { }
        public DbSet<BlockHistoryBaseModel> BlockHistories { get; set; }
        public DbSet<DefaultBlockHistoryModel> DefaultBlockHistories { get; set; }
        public DbSet<EtheriumBlockHistoryModel> EtheriumBlockHistories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlockHistoryBaseModel>()
                .UseTptMappingStrategy()
                .ToTable("BlockHistory");
            modelBuilder.Entity<DefaultBlockHistoryModel>()
                .ToTable("DefaultBlockHistory");
            modelBuilder.Entity<EtheriumBlockHistoryModel>()
                .ToTable("EtheriumBlockHistory");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlockHistoryBaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
