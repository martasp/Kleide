using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kleide.Models
{
    public partial class Nuoma
    {
        public int NuomosNumeris { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Rezervavimo Data")]
        public DateTime? RezervavimoData { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Gražinimo Data")]
        public DateTime? GrazinimoData { get; set; }
        [Display(Name = "Kaina €")]
        [DataType(DataType.Currency)]
        public double? Kaina { get; set; }
        public double? Pvm { get; set; }
        public double? Kuponas { get; set; }
        public int FkMokejimasmokejimoId { get; set; }
        public int FkAsmuoasmensKodas { get; set; }
        public int FkAsmuoasmensKodas1 { get; set; }

        public Asmuo FkAsmuoasmensKodas1Navigation { get; set; }
        public Asmuo FkAsmuoasmensKodasNavigation { get; set; }
        public Mokejimas FkMokejimasmokejimo { get; set; }
        public Preke Preke { get; set; }
    }
}
