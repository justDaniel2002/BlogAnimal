using System;
using System.Collections.Generic;

namespace BlogAnimalApi.Entity
{
    public partial class BlogComment
    {
        public int CommentId { get; set; }
        public string Content { get; set; } = null!;
        public string? BlogId { get; set; }
        public string? AccountId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Blog? Blog { get; set; }
    }
}
