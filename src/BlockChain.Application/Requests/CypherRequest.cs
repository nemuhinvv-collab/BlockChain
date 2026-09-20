using BlockChain.Domain.Enums;

namespace BlockChain.Application.Requests
{
    public sealed class CypherRequest
    {
        public BlockChainModeType BlockChainMode { get; set; }
        public BlockChainTypeEnum BlockChainType { get; set; }
    }
}
