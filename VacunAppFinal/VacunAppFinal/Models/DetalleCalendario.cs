using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacunAppFinal.Models
{
    public class DetalleCalendario
    {
        public int Id { get; set; }
        public int CalendarioId { get; set; }
        public virtual Calendario Calendario { get; set; }
        public int VacunaId { get; set; }
        public Vacuna Vacuna { get; set; }
    }
}
