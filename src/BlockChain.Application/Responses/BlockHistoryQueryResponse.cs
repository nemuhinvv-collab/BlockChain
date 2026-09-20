using BlockChain.Application.Responses.BaseResponse;

namespace BlockChain.Application.Responses
{
    public class BlockHistoryQueryResponse : BlockHistoryBaseResponse
    {
        public DateTimeOffset CreatedAt { get; set; }
    }
}
