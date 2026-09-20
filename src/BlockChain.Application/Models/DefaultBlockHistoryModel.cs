using BlockChain.Domain.Contracts;
using BlockChain.Application.Models.BaseModels;

namespace BlockChain.Application.Models
{
    public sealed class DefaultBlockHistoryModel : BlockHistoryBaseModel, IDefaultBlockHistoryEntity
    { 
        public int HighFeePerKb { get; set; }
        public int MediumFeePerKb { get; set; }
        public int LowFeePerKb { get; set; } 
    }
}
