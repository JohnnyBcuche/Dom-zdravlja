using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DomZdravlja.Models
{
    public class Dijagnoza
    {
        public int DijagnozaId { get; set; } 

        [Required(ErrorMessage = "Polje je obavezno!")] 
        [StringLength(50)] 
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")] 
        [StringLength(150)] 
        [DataType(DataType.MultilineText)] 
        public string Opis { get; set; }

        public int PacijentId { get; set; } 
        public virtual Pacijent Pacijents { get; set; } 
    }
}
