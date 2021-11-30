using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace VacunAppFinal.Models
{
    public class Calendario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public SexoEnum SexoPaciente { get; set; }
        public bool PrematuroPaciente { get; set; }


        public virtual ObservableCollection<DetalleCalendario> DetalleCalendarios { get; set; }

    }
}
