using BlogAnimalApi.Entity;

namespace BlogAnimalApi.DTO
{
    public class PetTypeDTO
    {
        public PetTypeDTO()
        {
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string? Image { get; set; }

    }
}
