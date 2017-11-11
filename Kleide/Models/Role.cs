using System;
using System.Collections.Generic;

namespace Kleide.Models
{
    public partial class Role
    {
        public string Pavadinimas { get; set; }
        public int? Lygis { get; set; }
        public int IdRole { get; set; }
        public int FkVartotojasidVartotojas { get; set; }

        public Vartotojas FkVartotojasidVartotojasNavigation { get; set; }
    }
}
