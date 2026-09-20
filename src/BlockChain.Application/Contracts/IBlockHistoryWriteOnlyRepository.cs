using BlockChain.Application.Models;

namespace BlockChain.Application.Contracts
{
    public interface IBlockHistoryWriteOnlyRepository
    {
        void AddDefaultBlockHistory(DefaultBlockHistoryModel blockHistory);
        void AddEtheriumBlockHistory(EtheriumBlockHistoryModel blockHistory);
        Task SaveChangesAsync(CancellationToken token);

    }
}
