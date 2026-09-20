using BlockChain.Domain.BaseEntity;


namespace BlockChain.Application.Models.BaseModels
{
    public class BlockHistoryBaseModel : BlockHistoryBaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
