using System;
using System.Collections.Generic;

namespace Kleide.Models
{
    public partial class Aksesuaras
    {
        public string MetaloTipas { get; set; }
        public bool? ArSuGrandinele { get; set; }
        public bool? ArElektroninis { get; set; }
        public string Lytis { get; set; }
        public int IdAksesuaras { get; set; }
        public int FkAksesuaruKategorijaidAksesuaruKategorija { get; set; }
        public int FkPrekeidPreke { get; set; }

        public AksesuaruKategorija FkAksesuaruKategorijaidAksesuaruKategorijaNavigation { get; set; }
        public Preke FkPrekeidPrekeNavigation { get; set; }
    }
}
