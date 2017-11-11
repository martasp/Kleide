using System;
using System.Collections.Generic;

namespace Kleide.Models
{
    public partial class AksesuaruKategorija
    {
        public AksesuaruKategorija()
        {
            Aksesuaras = new HashSet<Aksesuaras>();
        }

        public string Pavadinimas { get; set; }
        public int IdAksesuaruKategorija { get; set; }

        public ICollection<Aksesuaras> Aksesuaras { get; set; }
    }
}
