using Blockchain.Application.Models.BaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlockChain.Infrastructure.Context.Configurations
{
    internal class BlockHistoryBaseModelConfiguration : IEntityTypeConfiguration<BlockHistoryBaseModel> 
    {
        public void Configure(EntityTypeBuilder<BlockHistoryBaseModel> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.Height)
                .IsRequired();
            builder.Property(p => p.CreatedAt)
                .IsRequired();
            builder.Property(p => p.PeerCount)
                .IsRequired();
            builder.Property(p => p.Hash)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.PreviousHash)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.LatestUrl)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(p => p.PreviousUrl)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(p => p.Time)
                .IsRequired();
            builder.Property(p => p.LastForkHash)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.LastForkHeight)
                .IsRequired();
            builder.Property(p => p.UnconfirmedCount)
                .IsRequired();
        }
        
    }
}
