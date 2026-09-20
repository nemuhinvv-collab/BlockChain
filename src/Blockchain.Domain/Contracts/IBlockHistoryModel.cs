using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain.Domain.Contracts
{
    public interface IBlockHistoryModel
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
