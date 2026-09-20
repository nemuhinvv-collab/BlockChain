
using BlockChain.Application.Contracts;
using BlockChain.Application.Models;

namespace BlockChain.Infrastructure.UnitOfWork
{
    public class BlockHistoryWriteOnlyUOW : IBlockHistoryWriteOnlyUOW
    {
        private IBlockHistoryWriteOnlyRepository _writeOnlyRepository;
        public BlockHistoryWriteOnlyUOW(IBlockHistoryWriteOnlyRepository writeOnlyRepository)
        {
            _writeOnlyRepository = writeOnlyRepository;
        }
        public Task SaveEtheriumBlockHistoryAsync(EtheriumBlockHistoryModel blockHistory, CancellationToken token)
        {
            _writeOnlyRepository.AddEtheriumBlockHistory(blockHistory);
            return _writeOnlyRepository.SaveChangesAsync(token);
        }

        public Task SaveDefaultBlockHistoryAsync(DefaultBlockHistoryModel blockHistory, CancellationToken token)
        {
            _writeOnlyRepository.AddDefaultBlockHistory(blockHistory);
            return _writeOnlyRepository.SaveChangesAsync(token);
        }
    }
}
