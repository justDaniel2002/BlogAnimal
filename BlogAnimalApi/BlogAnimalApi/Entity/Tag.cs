using System;
using System.Collections.Generic;

namespace BlogAnimalApi.Entity
{
    public partial class Tag
    {
        public Tag()
        {
            Blogs = new HashSet<Blog>();
        }

        public int TagId { get; set; }
        public string TagName { get; set; } = null!;

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
