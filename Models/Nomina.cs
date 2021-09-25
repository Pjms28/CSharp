using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectoRazor.Models
{
    public class Nomina
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
        public double AFP { get; set; }
        public double ARS { get; set; }
        public double IRS { get; set; }
        public double DescuentoTotal { get; set; }
        public double SalarioNeto { get; set; }
    }
}
