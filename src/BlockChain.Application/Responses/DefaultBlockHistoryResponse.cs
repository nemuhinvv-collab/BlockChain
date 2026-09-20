using BlockChain.Domain.BaseEntity;
using BlockChain.Domain.Contracts;
using BlockChain.Application.Responses.BaseResponse;

namespace BlockChain.Application.Responses
{
    public sealed class DefaultBlockHistoryResponse : BlockHistoryBaseResponse, IDefaultBlockHistoryEntity
    {
        public int HighFeePerKb { get; set; }
        public int MediumFeePerKb { get; set; }
        public int LowFeePerKb { get; set; }
    }
}
