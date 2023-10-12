using System;
using System.Collections.Generic;

namespace BlogAnimalApi.Entity
{
    public partial class Blog
    {
        public Blog()
        {
            BlogComments = new HashSet<BlogComment>();
            BlogTags = new HashSet<BlogTag>();
        }

        public string BlogId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string? AccountId { get; set; }
        public int? PetTypeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? BlogTypeId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual BlogType? BlogType { get; set; }
        public virtual PetType? PetType { get; set; }
        public virtual ICollection<BlogComment> BlogComments { get; set; }
        public virtual ICollection<BlogTag> BlogTags { get; set; }
    }
}
