using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using VacunAppFinal.AdminData;
using VacunAppFinal.Core;
using Xamarin.Forms;

namespace VacunAppFinal.ViewModels
{
    public class IniciarSesionViewModel : ObjetoNotificacion
    {
        public Command IniciarSesionCommand { get; }
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value;
                OnPropertyChanged();
            }
        }

        public IniciarSesionViewModel()
        {
            var dbAdminLogin = new DbAdminLogin();
           
            IniciarSesionCommand = new Command(async () =>
            {
                var tutorLogueado = await dbAdminLogin.ObtenerTutorLogueado(email, password);
                Debug.Print("la variable validacion está devolviendo >>>>>>>>>>>>>>>>>>>> " + tutorLogueado.Apellido+" "+tutorLogueado.Nombre);
                if (tutorLogueado.Id > 0)
                {
                    Inicio.TutorLogueado = tutorLogueado;
                    MessagingCenter.Send<object>(this, "InicioLogueado");
                }
                else
                    MessagingCenter.Send<object>(this, "LoginInválido");
            });
        }          
    }
}

