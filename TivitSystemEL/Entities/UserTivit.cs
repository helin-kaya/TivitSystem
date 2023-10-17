using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TivitSystemEL.IdentityModels;

namespace TivitSystemEL.Entities
{
    [Table("USERTIVIT")]
    public class UserTivit:BaseNumeric<int>
    {
        [StringLength(500)]
        [MinLength(2)]
        public string TivitDetail { get; set; }
        public bool IsDefaultTivit { get; set; } // ekstra
        public string UserId { get; set; }
        public bool isDeleted { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }
    }
}
