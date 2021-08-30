using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectoRazor.Pages
{
    public class NominaModel : PageModel
    {

        public List<Nomina> NominaList = new List<Nomina>() {

            new Nomina("Pedro Jose", "Martinez Sanchez", "Front-end", 100000, 0, 0, 0, 0, 0),
            new Nomina("Carlos", "Ferrer Genao", "DBA", 1000000, 0, 0, 0, 0, 0),
            new Nomina("Joswald", "Martinez", "CEO Coke Cola", 50000000, 0, 0, 0, 0, 0),
            new Nomina("Yohan", "R19 Inhuman", "Accionist T1", 10000000, 0, 0, 0, 0, 0),
            new Nomina("Carlos Daniel", "Quezada", "Alorica", 500, 0, 0, 0, 0, 0)
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
        public Nomina(string Nombres, string Apellidos, string Cargo, double Salario, double AFP, double ARS, double IRS, double DescuentoTotal, double SalarioNeto)
        {
            this.Nombres = Nombres;
            this.Apellidos = Apellidos;
            this.Cargo = Cargo;
            this.Salario = Salario;
            this.AFP = AFP;
            this.ARS = ARS;
            this.IRS = IRS;
            this.DescuentoTotal = DescuentoTotal;
            this.SalarioNeto = SalarioNeto;
        }
    }
}
