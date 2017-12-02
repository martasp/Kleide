using System;
using System.Collections.Generic;

namespace Kleide.Models
{
    public partial class Pirkimas
    {
        public int UzsakymoNumeris { get; set; }
        public DateTime? Data { get; set; }
        public double? Kaina { get; set; }
        public double? Pvm { get; set; }
        public double? Kuponas { get; set; }
        public bool? ArApdrausta { get; set; }
        public int? FkMokejimasmokejimoId { get; set; }
        public int? FkAsmuoasmensKodas { get; set; }
        public int? FkAsmuoasmensKodas1 { get; set; }

        public Asmuo FkAsmuoasmensKodas1Navigation { get; set; }
        public Asmuo FkAsmuoasmensKodasNavigation { get; set; }
        public Mokejimas FkMokejimasmokejimo { get; set; }
        public Preke Preke { get; set; }
    }
}
