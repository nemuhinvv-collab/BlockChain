using Blockchain.Application.Models;

namespace Blockchain.Application.Contracts
{
    public interface IBlockHistoryWriteOnlyRepository
    {
        void AddDefaultBlockHistory(DefaultBlockHistoryModel blockHistory);
        void AddEtheriumBlockHistory(EtheriumBlockHistoryModel blockHistory);
        Task SaveChangesAsync(CancellationToken token);

    }
}
