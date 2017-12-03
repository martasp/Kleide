using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Rezervavimo Data")]
        public DateTime? Data { get; set; }
        [Display(Name = "Sumokėta Suma")]
        [DataType(DataType.Currency)]
        public double? SumoketaSuma { get; set; }
        [Display(Name = "Atsiskaitymo Būdas")]
        public string AtsiskaitymoBūdas { get; set; }
        [Display(Name = "Draudimo Tipas")]
        public string DraudimoTipas { get; set; }
        [Display(Name = "Nuolaida")]
        [DataType(DataType.Currency)]
        public double? NuolaidosSuma { get; set; }
        [Display(Name = "Atsiėmimo Vieta")]
        public string AtsiėmimoVieta { get; set; }
        [Display(Name = "Mokejimo Busena")]
        public string MokejimoBusena { get; set; }

        public ICollection<Nuoma> Nuoma { get; set; }
        public ICollection<Pirkimas> Pirkimas { get; set; }
    }
}
