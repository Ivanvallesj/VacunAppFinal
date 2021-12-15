using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacunAppFinal.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public SexoEnum Sexo { get; set; }
        public bool Prematuro { get; set; }
        public double Peso { get; set; }
        public string Domicilio { get; set; }
        public int TutorId { get; set; }
        public Tutor Tutor { get; set; }
        public int? CalendarioId { get; set; }
        public Calendario Calendario { get; set; }

    }
}
