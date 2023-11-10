using System;
using System.Collections.Generic;

namespace BlogAnimalApi.Entity
{
    public partial class TradeComment
    {
        public string Content { get; set; } = null!;
        public DateTime? CreateDate { get; set; }
        public string? AccountId { get; set; }
        public string? TradeId { get; set; }
        public string CommentId { get; set; } = null!;

        public virtual Account? Account { get; set; }
        public virtual TradePost? Trade { get; set; }
    }
}
