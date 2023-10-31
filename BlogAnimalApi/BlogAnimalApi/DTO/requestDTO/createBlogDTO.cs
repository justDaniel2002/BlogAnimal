using BlogAnimalApi.Entity;

namespace BlogAnimalApi.DTO.requestDTO
{
    public class createBlogDTO
    {
        public createBlogDTO()
        {
        }
        public string? BlogId { get; set; }
        public string Title { get; set; }   
        public string Content { get; set; }
        public string AccountId { get; set; }
        public int BlogTypeId { get; set;}
    }
}
