using TivitSystemEL.IdentityModels;

namespace TivitSystemPL.Models
{
    public class ProfileViewModel : AppUser
    {
        //resim
        public IFormFile? ChosenPicture { get; set; }

        public string? ProfilePicture { get; set; }

    }
}
