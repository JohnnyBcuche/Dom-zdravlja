using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomZdravlja.Models
{
    public class FilePath
    {
        public int FilePathId { get; set; } // primarni kljuc
        public string FileName { get; set; }
        public FileType FileType { get; set; } // poziv enuma FileType
        public int PacijentId { get; set; } // spoljni kljuc
        public virtual Pacijent Pacijents { get; set; } // navigaciono svojstvo ka modelu Film

    }
}
