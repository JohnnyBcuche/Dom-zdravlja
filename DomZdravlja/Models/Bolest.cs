using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DomZdravlja.Models
{
    public class Bolest
    {
        public int BolestId { get; set; } 

        [Required(ErrorMessage = "Polje je obavezno!")] 
        [StringLength(50)] 
        public string Naziv { get; set; }

    }
}
