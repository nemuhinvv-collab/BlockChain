namespace BlockChain.Domain.Contracts
{
    public interface IDefaultBlockHistoryEntity
    {
        public int HighFeePerKb { get; set; }
        public int MediumFeePerKb { get; set; }
        public int LowFeePerKb { get; set; }
    }
}
