using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using VacunAppFinal.AdminData;
using VacunAppFinal.Core;
using VacunAppFinal.Models;
using VacunAppFinal.Views;
using Xamarin.Forms;

namespace VacunAppFinal.ViewModels
{
    public class RegistroNuevaCuentaViewModel : ObjetoNotificacion
    {
        public Command GuardarNuevoTutorCommand { get; }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value;
                OnPropertyChanged();
            }
        }
        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value;
                OnPropertyChanged();
            }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value;
                OnPropertyChanged();
            }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set {
                password = value;
                OnPropertyChanged();
            }
        }


        public RegistroNuevaCuentaViewModel()
        {
            GuardarNuevoTutorCommand = new Command(async () =>
              {
                  //controlamos que los cuatro campos hayan sido cargados
                  if (nombre!=null && apellido != null &&
                    email != null && password != null) 
                  {
                      //controlamos los caracteres del password
                      if (password.Length >= 4)
                      {
                          var dbAdminTutores = new DbAdminTutores();
                          _ = dbAdminTutores.Agregar(nombre, apellido, email, password);
                          MessagingCenter.Send<object>(this, "IniciarSesion");
                      } else
                          MessagingCenter.Send<object>(this, "ErrorRestriccionPasswordInicioSesion");
                  } else
                      MessagingCenter.Send<object>(this, "CamposIncompletosInicioSesion");

              }
            );
        }
    }
}
