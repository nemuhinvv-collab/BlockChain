using Blockchain.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlockChain.Infrastructure.Context.Configurations
{
    internal class EtheriumBlockHistoryConfiguration : IEntityTypeConfiguration<EtheriumBlockHistoryModel>
    {
        public void Configure(EntityTypeBuilder<EtheriumBlockHistoryModel> builder)
        {
            builder.Property(p => p.HighGasPrice)
                .IsRequired();
            builder.Property(p => p.MediumGasPrice)
                .IsRequired();
            builder.Property(p => p.LowGasPrice)
                .IsRequired();
            builder.Property(p => p.HighPriorityFee)
                .IsRequired();
            builder.Property(p => p.MediumPriorityFee)
                .IsRequired();
            builder.Property(p => p.LowPriorityFee)
                .IsRequired();
        }
    }
}
