namespace BlogAnimalApi.DTO.requestDTO
{
    public class UpdatePostDTO
    {
        public UpdatePostDTO()
        {
        }
        public string PostId { get; set; } = null!;
        public string? Title { get; set; }
        /*public string Images { get; set; }*/
        public string Content { get; set; } = null!;
        public string? AccountId { get; set; }
        public string? Images { get; set; }
        public bool? IsSecure { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
