using Blockchain.Application.Models;

namespace Blockchain.Application.Contracts
{
    public interface IBlockHistoryWriteOnlyUOW
    {
        Task SaveDefaultBlockHistoryAsync(DefaultBlockHistoryModel blockHistory, CancellationToken token);
        Task SaveEtheriumBlockHistoryAsync(EtheriumBlockHistoryModel blockHistory, CancellationToken token);
    }
}
