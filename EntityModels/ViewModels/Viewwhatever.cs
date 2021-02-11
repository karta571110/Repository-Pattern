using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityModels.ViewModels
{
   public class Viewwhatever
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
    }
}
