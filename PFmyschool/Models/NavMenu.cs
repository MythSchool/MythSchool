using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFmyschool.Models
{
    public class NavMenu
    {

       public IEnumerable<Escuelas> escuelas { get; set; }
        public Usuario usuario { get; set; }

    }
}
