using BlockChain.Application.Models;
using BlockChain.Application.Responses; 

namespace BlockChain.Application.Mappers
{
    internal static class DefaultBlockHistoryModelMapper
    {
        internal static DefaultBlockHistoryModel MapToDefaultBlockHistoryModel(this DefaultBlockHistoryResponse dto, DateTimeOffset createdAt)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto));

            return new DefaultBlockHistoryModel
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
                HighFeePerKb = dto.HighFeePerKb,
                LowFeePerKb = dto.LowFeePerKb,
                MediumFeePerKb = dto.MediumFeePerKb
            };
        }
    }
}
