using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectoRazor.Models
{
    public class Prestamo
    {

        public double Monto { get; set; }
        public int Cuotas { get; set; }
        public double Interes { get; set; }
        public double Mensualidad { get; set; }
    }
}
