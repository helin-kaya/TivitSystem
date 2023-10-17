using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TivitSystemEL.IdentityModels;

namespace TivitSystemEL.ViewModels
{
    public class UserTivitViewModel
    {
        public int Id { get; set; }
        public DateTime InsertedDate { get; set; }
        public string TivitDetail { get; set; }
        public bool IsDefaultTivit { get; set; } // ekstra
        public string UserId { get; set; }
        public bool isDeleted { get; set; }

        public AppUser? AppUser { get; set; }
    }
}
