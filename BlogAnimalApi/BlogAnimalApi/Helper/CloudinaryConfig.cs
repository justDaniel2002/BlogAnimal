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
                "hwZfrhZFzbCNYafvv3E0pgLiaJg");

            cloudinary = new Cloudinary(account);
        }
    }
}
