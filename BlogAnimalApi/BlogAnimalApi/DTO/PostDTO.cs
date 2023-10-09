using BlogAnimalApi.Entity;

namespace BlogAnimalApi.DTO
{
    public class PostDTO
    {
        public PostDTO()
        {
            PostComments = new HashSet<PostCommentDTO>();
            PostLikes = new HashSet<PostLikeDTO>();
        }

        public string PostId { get; set; } = null!;
        public string? Title { get; set; }
        public string? Images { get; set; }
        public string Content { get; set; } = null!;
        public bool? IsSecure { get; set; }
        public string? AccountId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual AccountDTO? Account { get; set; }
        public virtual ICollection<PostCommentDTO> PostComments { get; set; }
        public virtual ICollection<PostLikeDTO> PostLikes { get; set; }
    }
}
