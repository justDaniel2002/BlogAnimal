namespace BlogAnimalApi.DTO
{
    public class BlogTypeDTO
    {
        public BlogTypeDTO()
        {
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string? Image { get; set; }

    }
}
