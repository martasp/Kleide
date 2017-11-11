using System;
using System.Collections.Generic;

namespace Kleide.Models
{
    public partial class Draudimas
    {
        public DateTime? PradziosData { get; set; }
        public DateTime? PabaigosData { get; set; }
        public double? DraudimoSuma { get; set; }
        public string Tiekejas { get; set; }
        public string Pobudis { get; set; }
        public string DraudimoNumeris { get; set; }
        public int IdDraudimas { get; set; }
        public int FkPrekeidPreke { get; set; }

        public Preke FkPrekeidPrekeNavigation { get; set; }
    }
}
