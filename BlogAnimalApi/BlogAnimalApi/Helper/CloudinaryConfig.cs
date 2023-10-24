using CloudinaryDotNet;

namespace BlogAnimalApi.Helper
{
    public class CloudinaryConfig
    {
        public Cloudinary cloudinary;
        public CloudinaryConfig()
        {
            Account account = new Account(
                "dddywpfov",
                "653594513686496",
                "***************************");

            cloudinary = new Cloudinary(account);
        }
    }
}
