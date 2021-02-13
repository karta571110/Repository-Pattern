using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityModels.Models
{
   public class merch
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public int Id { get; set; }     
        public string Name { get; set; }
        
        public string Description { get; set; }
        public string Detail { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
