using System;
using System.Collections.Generic;

namespace Kleide.Models
{
    public partial class Suknele
    {
        public int SuknelesNumeris { get; set; }
        public double? Ilgis { get; set; }
        public string Audinys { get; set; }
        public string ModelioTipas { get; set; }
        public int FkPrekeidPreke { get; set; }

        public Preke FkPrekeidPrekeNavigation { get; set; }
    }
}
