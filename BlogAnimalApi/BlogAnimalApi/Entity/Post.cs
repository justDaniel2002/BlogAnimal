using System;
using System.Collections.Generic;

namespace BlogAnimalApi.Entity
{
    public partial class Post
    {
        public Post()
        {
            PostComments = new HashSet<PostComment>();
            PostLikes = new HashSet<PostLike>();
        }

        public string PostId { get; set; } = null!;
        public string? Title { get; set; }
        public string? Images { get; set; }
        public string Content { get; set; } = null!;
        public bool? IsSecure { get; set; }
        public string? AccountId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Account? Account { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }
        public virtual ICollection<PostLike> PostLikes { get; set; }
    }
}
