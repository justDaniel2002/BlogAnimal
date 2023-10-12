using BlogAnimalApi.Entity;

namespace BlogAnimalApi.DTO
{
    public class BlogDTO
    {
        public BlogDTO()
        {
            BlogComments = new HashSet<BlogCommentDTO>();
            Tags = new HashSet<TagDTO>();
        }

        public string BlogId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string? AccountId { get; set; }
        public int? PetTypeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? BlogTypeId { get; set; }

        public virtual AccountDTO? Account { get; set; }
        public virtual BlogTypeDTO? BlogType { get; set; }
        public virtual PetTypeDTO? PetType { get; set; }
        public virtual ICollection<BlogCommentDTO> BlogComments { get; set; }
        public virtual ICollection<TagDTO> Tags { get; set; }
    }
}
