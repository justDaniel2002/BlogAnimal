using System;
using System.Collections.Generic;

namespace BlogAnimalApi.Entity
{
    public partial class TradePost
    {
        public TradePost()
        {
            TradeComments = new HashSet<TradeComment>();
        }

        public string TradeId { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool? IsTrade { get; set; }
        public bool? IsSecure { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual ICollection<TradeComment> TradeComments { get; set; }
    }
}
