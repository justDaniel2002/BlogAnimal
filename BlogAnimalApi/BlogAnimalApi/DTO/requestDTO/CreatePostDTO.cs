namespace BlogAnimalApi.DTO.requestDTO
{
    public class CreatePostDTO
    {
        public CreatePostDTO()
        {
        }
        public string? Title { get; set; }
        /*public string Images { get; set; }*/
        public string Content { get; set; } = null!;
        public string? AccountId { get; set; }
    }
}
