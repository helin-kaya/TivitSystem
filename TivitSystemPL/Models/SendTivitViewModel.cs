using System.ComponentModel.DataAnnotations;
using TivitSystemEL.IdentityModels;
using TivitSystemEL.ViewModels;

namespace TivitSystemPL.Models
{
    public class SendTivitViewModel
    {

		public int Id { get; set; }
        public DateTime InsertedDate { get; set; }
        [StringLength(500)]
        [MinLength(2)]
        public string TivitDetail { get; set; }

        public string UserId { get; set; }

        public bool IsDefaultTivit { get; set; } // ekstra

        public bool IsDeleted { get; set; }

        public AppUser? AppUser { get; set; }

        public List<IFormFile>? TivitPictures { get; set; }
        public List<UserTivitMediaViewModel>? TivitMedias { get; set;}


    }
}
