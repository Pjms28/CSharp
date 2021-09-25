using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectoRazor.Models;

namespace ProjectoRazor.Pages
{
    public class NominaModel : PageModel
    {

        public List<Nomina> NominaList = new List<Nomina>() {
            new Nomina(){Nombres = "Pedro Jose", Apellidos = "Martinez Sanchez", Cargo = "Front-end", Salario = 100000, AFP = 0, ARS = 0, DescuentoTotal = 0, IRS = 0, SalarioNeto = 0},
            new Nomina(){Nombres = "Carlos", Apellidos = "Ferrer Genao", Cargo = "DBA", Salario = 1000000, AFP = 0, ARS = 0, DescuentoTotal = 0, IRS = 0, SalarioNeto = 0},
            new Nomina(){Nombres = "Joswald", Apellidos = "Martinez", Cargo = "CEO Coke Cola", Salario = 50000000, AFP = 0, ARS = 0, DescuentoTotal = 0, IRS = 0, SalarioNeto = 0},
            new Nomina(){Nombres = "Yohan", Apellidos = "R19 Inhuman", Cargo = "Accionist T1", Salario = 10000000, AFP = 0, ARS = 0, DescuentoTotal = 0, IRS = 0, SalarioNeto = 0},
            new Nomina(){Nombres = "Carlos Daniel", Apellidos = "Quezada", Cargo = "Alorica", Salario = 500, AFP = 0, ARS = 0, DescuentoTotal = 0, IRS = 0, SalarioNeto = 0},
        };


        public void calculo( Nomina nomina)
        {
           var afpCalc = Math.Round(nomina.Salario * 0.0287);
            if (afpCalc > 7738.67)
            {
                nomina.AFP = 7738.67;
            }
            else
            {
                nomina.AFP = afpCalc;
            }

            var arsCalc = Math.Round(nomina.Salario * 0.0304);
            if (arsCalc > 4098.53)
            {
                nomina.ARS = 4098.53;
            }
            else
            {
                nomina.ARS = arsCalc;
            }

            var tax = 0.0;
            var salAnual = nomina.Salario * 12;
            if (salAnual > 416220.01 && salAnual < 624329)
            {
                tax = ((624329 - salAnual) * 0.15) / 12;
            }
            else if (salAnual > 624329.01 && salAnual < 867123)
            {
                tax = ((624329 - 416220.01) * 0.15);
                tax = (tax + ((867123 - salAnual) * 0.2)) / 12;
            }
            else if (salAnual > 867123.01) 
            {
                tax = ((624329 - 416220.01) * 0.15) + ((867123 - 624329.01) * 0.2);
                tax = (tax + ((salAnual - 867123.01) * 0.25) / 12);
            }

            nomina.IRS = tax;
            nomina.DescuentoTotal = nomina.AFP + nomina.ARS + nomina.IRS;
            nomina.SalarioNeto = nomina.Salario - nomina.DescuentoTotal;
        }

        public void OnGet()
        {
        }

       

    }

   /*public class Nomina
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
        public Nomina()
        {
        }
    }*/
}
