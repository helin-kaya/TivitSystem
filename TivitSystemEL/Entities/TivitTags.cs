using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TivitSystemEL.Entities
{
    [Table("TIVITTAGS")]
    public class TivitTags:BaseNumeric<int>
    {
        
        public string Name  { get; set; }
        public int  UserTivitId { get; set; }

        public bool isDeleted { get; set; }
        [ForeignKey("UserTivitId")]
        public virtual UserTivit UserTivit { get; set; }
    }
}
