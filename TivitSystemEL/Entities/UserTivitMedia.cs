using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TivitSystemEL.Entities
{
    public class UserTivitMedia:BaseNumeric<int>
    {
        public string MediaPath { get; set; }
        public int UserTivitId { get; set; }
        [ForeignKey("UserTivitId")]
        public virtual UserTivit UserTivit { get; set; }
    }
}
