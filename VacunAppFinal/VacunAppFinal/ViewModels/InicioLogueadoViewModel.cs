using System;
using System.Collections.Generic;
using System.Text;
using VacunAppFinal.Core;
using VacunAppFinal.Models;
using Xamarin.Forms;

namespace VacunAppFinal.ViewModels
{
    public class InicioLogueadoViewModel: ObjetoNotificacion
    {
        public Command RegistroDeHijosCommand { get; }
        public Command CargarVacunacionPacienteCommand { get; }
        private string nombreTutor;

        public string NombreTutor
        {
            get { return nombreTutor; }
            set { nombreTutor = value;
                OnPropertyChanged();
            }
        }

        public InicioLogueadoViewModel()
        {

            nombreTutor = Inicio.TutorLogueado.Apellido + " " + Inicio.TutorLogueado.Nombre;
            
            
            
            RegistroDeHijosCommand = new Command(async =>
              {
                  MessagingCenter.Send<object>(this, "RegistroDeHijos");
              });


            CargarVacunacionPacienteCommand = new Command(async =>
            {
                MessagingCenter.Send<object>(this, "CargarVacunacionPaciente");
            });
        }
    }
}
