using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityModels.ViewModels
{
   public class ViewMerch
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
