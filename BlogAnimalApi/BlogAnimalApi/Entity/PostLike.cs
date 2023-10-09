using System;
using System.Collections.Generic;

namespace BlogAnimalApi.Entity
{
    public partial class PostLike
    {
        public int LikeId { get; set; }
        public string? PostId { get; set; }
        public string? AccountId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Post? Post { get; set; }
    }
}
