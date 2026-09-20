

using BlockChain.Application.Models.BaseModels;
using BlockChain.Application.Responses;

namespace BlockChain.Application.Mappers
{
    internal static class BlockHistoryQueryResponseMapper
    {
        internal static BlockHistoryQueryResponse MapToDefaultHistoryQueryResponse(this BlockHistoryBaseModel model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));
            return new BlockHistoryQueryResponse
            {
                Hash = model.Hash,
                Height = model.Height,
                LastForkHash = model.LastForkHash,
                LastForkHeight = model.LastForkHeight,
                LatestUrl = model.LatestUrl,
                CreatedAt = model.CreatedAt,
                PeerCount = model.PeerCount,
                PreviousHash = model.PreviousHash,
                Name = model.Name,
                PreviousUrl = model.PreviousUrl,
                Time = model.Time,
                UnconfirmedCount = model.UnconfirmedCount,
            };
        }
    }
}
