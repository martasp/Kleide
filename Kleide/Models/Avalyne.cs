using System;
using System.Collections.Generic;

namespace Kleide.Models
{
    public partial class Avalyne
    {
        public string MedziagosTipas { get; set; }
        public bool? Uzsegimas { get; set; }
        public string Pobudis { get; set; }
        public bool? SuKulniuku { get; set; }
        public string Lytis { get; set; }
        public int IdAvalyne { get; set; }
        public int FkPrekeidPreke { get; set; }

        public Preke FkPrekeidPrekeNavigation { get; set; }
    }
}
