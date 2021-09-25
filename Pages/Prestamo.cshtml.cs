using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectoRazor.Models;

namespace ProjectoRazor.Pages
{
    public class PrestamoModel : PageModel
    {
        [BindProperty]
        public Prestamo prestamoObj { get; set; }

        public PrestamoModel()
        {
            prestamoObj = new Prestamo();
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            this.prestamoObj.Interes = this.prestamoObj.Interes / 100;
            /*var operacionSup = this.prestamoObj.Interes * Math.Pow((1 + this.prestamoObj.Interes), this.prestamoObj.Cuotas);
            var operacionInf = Math.Pow((1 + this.prestamoObj.Interes), this.prestamoObj.Cuotas) - 1;
            this.prestamoObj.Mensualidad = this.prestamoObj.Monto * (operacionSup / operacionInf);*/

            var operacionInf = 1 - Math.Pow((1 + this.prestamoObj.Interes), -this.prestamoObj.Cuotas);
            this.prestamoObj.Mensualidad = this.prestamoObj.Monto * (this.prestamoObj.Interes / operacionInf);
        }
    }
}
