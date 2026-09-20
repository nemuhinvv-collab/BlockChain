using BlockChain.Domain.Contracts;
using BlockChain.Application.Models.BaseModels;

namespace BlockChain.Application.Models
{
    public sealed class EtheriumBlockHistoryModel : BlockHistoryBaseModel, IEtheriumBlockHistoryEntity
    {
        public long HighGasPrice { get; set; }
        public long MediumGasPrice { get; set; }
        public long LowGasPrice { get; set; }
        public long HighPriorityFee { get; set; }
        public long MediumPriorityFee { get; set; }
        public long LowPriorityFee { get; set; }
    }
}