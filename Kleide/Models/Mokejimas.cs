using System;
using System.Collections.Generic;

namespace Kleide.Models
{
    public partial class Mokejimas
    {
        public Mokejimas()
        {
            Nuoma = new HashSet<Nuoma>();
            Pirkimas = new HashSet<Pirkimas>();
        }

        public int MokejimoId { get; set; }
        public DateTime? Data { get; set; }
        public double? SumoketaSuma { get; set; }
        public string AtsiskaitymoBūdas { get; set; }
        public string DraudimoTipas { get; set; }
        public double? NuolaidosSuma { get; set; }
        public string AtsiėmimoVieta { get; set; }
        public string MokejimoBusena { get; set; }

        public ICollection<Nuoma> Nuoma { get; set; }
        public ICollection<Pirkimas> Pirkimas { get; set; }
    }
}
