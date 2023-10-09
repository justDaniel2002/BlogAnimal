using System;
using System.Collections.Generic;

namespace BlogAnimalApi.Entity
{
    public partial class PetType
    {
        public PetType()
        {
            Blogs = new HashSet<Blog>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string? Image { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
