using BlockChain.Application.Queries;
using BlockChain.Application.Requests;

namespace BlockChain.Application.Mappers
{
    internal static class GetHistoryEntryPageRequestMapper
    {
        internal static GetHistoryEntryPageQuery MapToGetHistoryEntryPageQuery(this GetHistoryEntryPageRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));
            return new GetHistoryEntryPageQuery(request.pageCount, request.pageNumber);
        }
    }
}
