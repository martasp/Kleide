using System;
using System.Collections.Generic;

namespace Kleide.Models
{
    public partial class Preke
    {
        public string Pavadinimas { get; set; }
        public string Dydis { get; set; }
        public string Spalva { get; set; }
        public string Aprasymas { get; set; }
        public string Nuotrauka { get; set; }
        public DateTime? PridejimoData { get; set; }
        public int? NuomosSkaicius { get; set; }
        public string Bukle { get; set; }
        public int Kaina { get; set; }
        public string PagaminimoSalis { get; set; }
        public bool? ArRankuDarbo { get; set; }
        public string RezervavimoTipas { get; set; }
        public int IdPreke { get; set; }
        public int? FkPirkimasuzsakymoNumeris { get; set; }
        public int? FkNuomanuomosNumeris { get; set; }
        public int? FkSandelysidSandelys { get; set; }

        public Nuoma FkNuomanuomosNumerisNavigation { get; set; }
        public Pirkimas FkPirkimasuzsakymoNumerisNavigation { get; set; }
        public Sandelys FkSandelysidSandelysNavigation { get; set; }
        public Aksesuaras Aksesuaras { get; set; }
        public Avalyne Avalyne { get; set; }
        public Draudimas Draudimas { get; set; }
        public Suknele Suknele { get; set; }
    }
}
