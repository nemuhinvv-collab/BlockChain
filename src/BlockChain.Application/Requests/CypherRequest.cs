using Blockchain.Domain.Enums;

namespace Blockchain.Application.Requests
{
    public sealed class CypherRequest
    {
        public BlockChainModeType BlockChainMode { get; set; }
        public BlockChainTypeEnum BlockChainType { get; set; }
    }
}
