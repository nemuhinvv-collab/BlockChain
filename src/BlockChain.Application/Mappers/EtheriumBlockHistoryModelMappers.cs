

using BlockChain.Application.Models;
using BlockChain.Application.Responses;

namespace BlockChain.Application.Mappers
{
    internal static class EtheriumBlockHistoryModelMappers
    {
        internal static EtheriumBlockHistoryModel MapToEtheriumBlockHistoryModel(this EtheriumBlockHistoryResponse dto, DateTimeOffset createdAt)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto));

            return new EtheriumBlockHistoryModel
            {
                Hash = dto.Hash,
                Height = dto.Height,
                LastForkHash = dto.LastForkHash,
                LastForkHeight = dto.LastForkHeight,
                LatestUrl = dto.LatestUrl,
                CreatedAt = createdAt,
                PeerCount = dto.PeerCount,
                PreviousHash = dto.PreviousHash,
                Name = dto.Name,
                PreviousUrl = dto.PreviousUrl,
                Time = dto.Time,
                UnconfirmedCount = dto.UnconfirmedCount,
                HighGasPrice = dto.HighGasPrice,
                MediumGasPrice = dto.MediumGasPrice,
                LowGasPrice = dto.LowGasPrice,
                HighPriorityFee = dto.HighPriorityFee,
                MediumPriorityFee = dto.MediumPriorityFee,
                LowPriorityFee = dto.LowPriorityFee
            };
        }
    }
}
