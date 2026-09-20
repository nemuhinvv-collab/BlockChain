
namespace BlockChain.Domain.Contracts
{
    public interface IBlockHistoryModel
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
