using BlockChain.Application.Contracts;
using BlockChain.Application.Requests;
using BlockChain.Application.Responses;
using BlockChain.Application.Responses.BaseResponse;
using BlockChain.Application.Models;
using BlockChain.Application.Services;
using Moq;
using Xunit;

namespace BlockChain.UnitTests
{
    public class BlockHistoryServiceTests
    {
        private readonly Mock<IBlockCypherRepository> _cypherMock;
        private readonly Mock<IBlockHistoryWriteOnlyUOW> _uowMock;
        private readonly Mock<TimeProvider> _timeProviderMock;
        private readonly Mock<IBlockHistoryReadonlyRepository> _readOnlyRepoMock;
        private readonly BlockHistoryService _service;

        public BlockHistoryServiceTests()
        {
            _cypherMock = new Mock<IBlockCypherRepository>();
            _uowMock = new Mock<IBlockHistoryWriteOnlyUOW>();
            _timeProviderMock = new Mock<TimeProvider>();
            _readOnlyRepoMock = new Mock<IBlockHistoryReadonlyRepository>();
            _service = new BlockHistoryService(_cypherMock.Object, 
                _uowMock.Object, 
                _readOnlyRepoMock.Object
                , _timeProviderMock.Object);
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

            _timeProviderMock.Setup(tp => tp.GetUtcNow()).Returns(now);
            _cypherMock.Setup(c => c.GetBaseBlockHistoryAsync(It.IsAny<CypherRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((BlockHistoryBaseResponse?)response);

            var result = await _service.GetBlockCypher(new CypherRequest(), CancellationToken.None);

            Assert.Same(response, result);
            _uowMock.Verify(u => u.SaveDefaultBlockHistoryAsync(It.Is<DefaultBlockHistoryModel>(m => m.Hash == response.Hash && m.Height == response.Height && m.HighFeePerKb == response.HighFeePerKb && m.CreatedAt == now), It.IsAny<CancellationToken>()), Times.Once);
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

            _timeProviderMock.Setup(tp => tp.GetUtcNow()).Returns(now);
            _cypherMock.Setup(c => c.GetBaseBlockHistoryAsync(It.IsAny<CypherRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((BlockHistoryBaseResponse?)response);

            var result = await _service.GetBlockCypher(new CypherRequest(), CancellationToken.None);

            Assert.Same(response, result);
            _uowMock.Verify(u => u.SaveEtheriumBlockHistoryAsync(It.Is<EtheriumBlockHistoryModel>(m => m.Hash == response.Hash && m.Height == response.Height && m.HighGasPrice == response.HighGasPrice && m.CreatedAt == now), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetBlockCypher_NullResponse_DoesNotSaveAndReturnsNull()
        {
            _cypherMock.Setup(c => c.GetBaseBlockHistoryAsync(It.IsAny<CypherRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((BlockHistoryBaseResponse?)null);

            var result = await _service.GetBlockCypher(new CypherRequest(), CancellationToken.None);

            Assert.Null(result);
            _uowMock.Verify(u => u.SaveDefaultBlockHistoryAsync(It.IsAny<DefaultBlockHistoryModel>(), It.IsAny<CancellationToken>()), Times.Never);
            _uowMock.Verify(u => u.SaveEtheriumBlockHistoryAsync(It.IsAny<EtheriumBlockHistoryModel>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task GetBlockCypher_UnknownResponseType_DoesNotSave()
        {
            var baseResponse = new BlockHistoryBaseResponse();
            _cypherMock.Setup(c => c.GetBaseBlockHistoryAsync(It.IsAny<CypherRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((BlockHistoryBaseResponse?)baseResponse);

            var result = await _service.GetBlockCypher(new CypherRequest(), CancellationToken.None);

            Assert.Same(baseResponse, result);
            _uowMock.Verify(u => u.SaveDefaultBlockHistoryAsync(It.IsAny<DefaultBlockHistoryModel>(), It.IsAny<CancellationToken>()), Times.Never);
            _uowMock.Verify(u => u.SaveEtheriumBlockHistoryAsync(It.IsAny<EtheriumBlockHistoryModel>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task GetBlockCypher_SaveThrows_PropagatesException()
        {
            var now = DateTimeOffset.UtcNow;
            var response = new DefaultBlockHistoryResponse
            {
                Hash = "hash-ex",
                Height = 1,
                HighFeePerKb = 2,
                MediumFeePerKb = 1,
                LowFeePerKb = 0
            };

            _timeProviderMock.Setup(tp => tp.GetUtcNow()).Returns(now);
            _cypherMock.Setup(c => c.GetBaseBlockHistoryAsync(It.IsAny<CypherRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((BlockHistoryBaseResponse?)response);

            _uowMock.Setup(u => u.SaveDefaultBlockHistoryAsync(It.IsAny<DefaultBlockHistoryModel>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new InvalidOperationException("save failed"));

            await Assert.ThrowsAsync<InvalidOperationException>(() => _service.GetBlockCypher(new CypherRequest(), CancellationToken.None));
        }
    }
}
