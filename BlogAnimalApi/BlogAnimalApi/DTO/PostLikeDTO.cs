using BlogAnimalApi.Entity;

namespace BlogAnimalApi.DTO
{
    public class PostLikeDTO
    {
        public int LikeId { get; set; }
        public string? PostId { get; set; }
        public string? AccountId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual AccountDTO? Account { get; set; }
    }
}
