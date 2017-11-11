using System;
using System.Collections.Generic;

namespace Kleide.Models
{
    public partial class Sandelys
    {
        public Sandelys()
        {
            Preke = new HashSet<Preke>();
        }

        public int? Kiekis { get; set; }
        public string PrekesBukle { get; set; }
        public string Miestas { get; set; }
        public string PastoKodas { get; set; }
        public string GatvėsPavadinimas { get; set; }
        public string KontaktinisAsmuo { get; set; }
        public string Salis { get; set; }
        public int? SandelioDydis { get; set; }
        public int? DarbuotojuKiekis { get; set; }
        public int? DarboMasinosKiekis { get; set; }
        public string PrekesTipas { get; set; }
        public int IdSandelys { get; set; }

        public ICollection<Preke> Preke { get; set; }
    }
}
