using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomZdravlja.Models
{
    public class Pacijent
    {
        public int PacijentId { get; set; } 

        [Required(ErrorMessage = "Polje je obavezno!")] 
        [StringLength(50)] 
        public string Ime { get; set; }

        [Display(Name = "Godina rodjenja")] 
        public int Godiste { get; set; }

        [DataType(DataType.MultilineText)] 
        public string OpisBolesti { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")] 
        [StringLength(50)]
        public string Lekar { get; set; }

        public int BolestId { get; set; } 
        public virtual Bolest Bolests { get; set; } 

        public virtual ICollection<FilePath> FilePaths { get; set; } 

        public virtual ICollection<Dijagnoza> Dijagnozas { get; set; } 

    }
}