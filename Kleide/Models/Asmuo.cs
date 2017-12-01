using System;
using System.Collections.Generic;

namespace Kleide.Models
{
    public partial class Asmuo
    {
        public Asmuo()
        {
            NuomaFkAsmuoasmensKodas1Navigation = new HashSet<Nuoma>();
            NuomaFkAsmuoasmensKodasNavigation = new HashSet<Nuoma>();
            PirkimasFkAsmuoasmensKodas1Navigation = new HashSet<Pirkimas>();
            PirkimasFkAsmuoasmensKodasNavigation = new HashSet<Pirkimas>();
        }
        public string AsmesnsId { get; set; }
        public int AsmensKodas { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public string Telefonas { get; set; }
        public string Miestas { get; set; }
        public string Salis { get; set; }
        public string Adresas { get; set; }
        public string PastoKodas { get; set; }

        public Vartotojas Vartotojas { get; set; }
        public ICollection<Nuoma> NuomaFkAsmuoasmensKodas1Navigation { get; set; }
        public ICollection<Nuoma> NuomaFkAsmuoasmensKodasNavigation { get; set; }
        public ICollection<Pirkimas> PirkimasFkAsmuoasmensKodas1Navigation { get; set; }
        public ICollection<Pirkimas> PirkimasFkAsmuoasmensKodasNavigation { get; set; }
    }
}
