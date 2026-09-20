using System;
using System.Threading;
using System.Threading.Tasks;
using Blockchain.Application.Contracts;
using Blockchain.Application.Requests;
using BlockChain.Application.Responses;
using BlockChain.Application.Services;
using BlockChain.Application.Models;
using Xunit;

namespace BlockChain.UnitTests
{
    public class BlockHistoryServiceTests
    {
        private class FakeCypherRepository : IBlockCypherRepository
        {
            private readonly BlockHistoryBaseResponse? _response;
            public FakeCypherRepository(BlockHistoryBaseResponse? response) => _response = response;
            public Task<BlockHistoryBaseResponse?> GetBaseBlockHistoryAsync(CypherRequest request, CancellationToken token) => Task.FromResult(_response);
        }

        private class FakeWriteOnlyUOW : IBlockHistoryWriteOnlyUOW
        {
            public DefaultBlockHistoryModel? SavedDefault { get; private set; }
            public EtheriumBlockHistoryModel? SavedEtherium { get; private set; }

            public Task SaveDefaultBlockHistoryAsync(DefaultBlockHistoryModel blockHistory, CancellationToken token)
            {
                SavedDefault = blockHistory;
                return Task.CompletedTask;
            }

            public Task SaveEtheriumBlockHistoryAsync(EtheriumBlockHistoryModel blockHistory, CancellationToken token)
            {
                SavedEtherium = blockHistory;
                return Task.CompletedTask;
            }
        }

        private class FixedTimeProvider : TimeProvider
        {
            private readonly DateTimeOffset _now;
            public FixedTimeProvider(DateTimeOffset now) => _now = now;
            public override DateTimeOffset GetUtcNow() => _now;
        }

        [Fact]
        public async Task GetBlockCypher_DefaultResponse_SavesDefaultModel()
        {
            var now = DateTimeOffset.UtcNow;
            var response = new DefaultBlockHistoryResponse
            {
                Hash = "hash1",
                Height = 123,
                HighFeePerKb = 10,
                MediumFeePerKb = 5,
                LowFeePerKb = 1
            };

            var fakeRepo = new FakeCypherRepository(response);
            var fakeUow = new FakeWriteOnlyUOW();
            var timeProvider = new FixedTimeProvider(now);

            var service = new BlockHistoryService(fakeRepo, fakeUow, timeProvider);

            var result = await service.GetBlockCypher(new CypherRequest(), CancellationToken.None);

            Assert.Same(response, result);
            Assert.NotNull(fakeUow.SavedDefault);
            Assert.Equal(response.Hash, fakeUow.SavedDefault!.Hash);
            Assert.Equal(response.Height, fakeUow.SavedDefault.Height);
            Assert.Equal(response.HighFeePerKb, fakeUow.SavedDefault.HighFeePerKb);
            Assert.Equal(now, fakeUow.SavedDefault.CreatedAt);
        }

        [Fact]
        public async Task GetBlockCypher_EtheriumResponse_SavesEtheriumModel()
        {
            var now = DateTimeOffset.UtcNow;
            var response = new EtheriumBlockHistoryResponse
            {
                Hash = "h2",
                Height = 999,
                HighGasPrice = 1000,
                LowGasPrice = 10,
                MediumGasPrice = 100
            };

            var fakeRepo = new FakeCypherRepository(response);
            var fakeUow = new FakeWriteOnlyUOW();
            var timeProvider = new FixedTimeProvider(now);

            var service = new BlockHistoryService(fakeRepo, fakeUow, timeProvider);

            var result = await service.GetBlockCypher(new CypherRequest(), CancellationToken.None);

            Assert.Same(response, result);
            Assert.NotNull(fakeUow.SavedEtherium);
            Assert.Equal(response.Hash, fakeUow.SavedEtherium!.Hash);
            Assert.Equal(response.Height, fakeUow.SavedEtherium.Height);
            Assert.Equal(response.HighGasPrice, fakeUow.SavedEtherium.HighGasPrice);
            Assert.Equal(now, fakeUow.SavedEtherium.CreatedAt);
        }
    }
}
