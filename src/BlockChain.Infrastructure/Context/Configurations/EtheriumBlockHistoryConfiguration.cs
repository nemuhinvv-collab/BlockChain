using Blockchain.Application.Models;

namespace BlockChain.Infrastructure.Context.Configurations
{
    internal class EtheriumBlockHistoryConfiguration : BlockHistoryBaseModelConfiguration<EtheriumBlockHistoryModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EtheriumBlockHistoryModel> builder)
        {
            base.Configure(builder);
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
