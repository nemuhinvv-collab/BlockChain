using BlockChain.Domain.Contracts;
using BlockChain.Application.Responses.BaseResponse;

namespace BlockChain.Application.Responses
{
    public sealed class EtheriumBlockHistoryResponse : BlockHistoryBaseResponse, IEtheriumBlockHistoryEntity
    {
        public long HighGasPrice { get; set; }
        public long MediumGasPrice { get; set; }
        public long LowGasPrice { get; set; }
        public long HighPriorityFee { get; set; }
        public long MediumPriorityFee { get; set; }
        public long LowPriorityFee { get; set; }
    }
}
