

using Blockchain.Application.Models;
using Blockchain.Application.Responses;

namespace BlockChain.Application.Mappers
{
    internal static class BlockChainHistoryModelMappers
    {
        internal static EtheriumBlockHistoryModel MapToEtheriumBlockHistoryModel(this EtheriumBlockHistoryResponse dto, DateTimeOffset createdAt)
        {
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
