using Blockchain.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace BlockChain.Infrastructure.Context.Configurations
{
    internal class DefaultBlockHistoryModelConfiguration : BlockHistoryBaseModelConfiguration<DefaultBlockHistoryModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DefaultBlockHistoryModel> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.HighFeePerKb)
                .IsRequired();
            builder.Property(p => p.MediumFeePerKb)
                .IsRequired();
            builder.Property(p => p.LowFeePerKb)
                .IsRequired();
        }
    }
}
