using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Kleide.Models
{
    public partial class Vartotojas
    {
        public Vartotojas()
        {
            Role = new HashSet<Role>();
        }

        public string PrisijungimoVardas { get; set; }
        public string Slaptazodis { get; set; }
        public string IpAdresas { get; set; }
        public int IdVartotojas { get; set; }
        public int FkAsmuoasmensKodas { get; set; }

        public Asmuo FkAsmuoasmensKodasNavigation { get; set; }
        public ICollection<Role> Role { get; set; }
    }
}
