using BlockChain.Application.Models;

namespace BlockChain.Application.Contracts
{
    public interface IBlockHistoryWriteOnlyUOW
    {
        Task SaveDefaultBlockHistoryAsync(DefaultBlockHistoryModel blockHistory, CancellationToken token);
        Task SaveEtheriumBlockHistoryAsync(EtheriumBlockHistoryModel blockHistory, CancellationToken token);
    }
}
