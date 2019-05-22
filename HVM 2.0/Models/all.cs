using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HVM_2._0.Models
{
    public class all
    {
        public List<Creneau> crenaux { get; set; }
        public List<Patient> patients { get; set; }
        public List<Visiteur> visiteurs { get; set; }
        public List<Reserve> reserves { get; set; }

    }
}