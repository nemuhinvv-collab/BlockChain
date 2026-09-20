using Blockchain.Domain.BaseEntity;


namespace Blockchain.Application.Models.BaseModels
{
    public class BlockHistoryBaseModel : BlockHistoryBaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
