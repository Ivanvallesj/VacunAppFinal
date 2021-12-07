using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacunAppFinal.Models
{
    public class Vacuna
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int PeriodoAplicacion { get; set; }
        public string Beneficios { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
