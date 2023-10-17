using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TivitSystemEL.Entities;

namespace TivitSystemEL.ViewModels
{
    public class UserTivitMediaViewModel
    {
        public int Id { get; set; }
        public DateTime InsertedDate { get; set; }
        public string? MediaPath { get; set; }
        public int UserTivitId { get; set; }
        public UserTivitViewModel? UserTivit { get; set; }
    }
}
