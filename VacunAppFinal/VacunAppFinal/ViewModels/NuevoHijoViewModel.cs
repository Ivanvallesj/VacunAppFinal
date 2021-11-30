using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VacunAppFinal.AdminData;
using VacunAppFinal.Core;
using VacunAppFinal.Models;
using VacunAppFinal.Views;
using Xamarin.Forms;

namespace VacunAppFinal.ViewModels
{
    public class NuevoHijoViewModel : ObjetoNotificacion
    {
        public Command GuardarNuevoHijoCommand { get; }
        public Paciente HijoModificado { get; set; }
        
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged();
            }
        }
        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set
            {
                apellido = value;
                OnPropertyChanged();
            }
        }
        private string dni;

        public string DNI
        {
            get { return dni; }
            set
            {
                dni = value;
                OnPropertyChanged();
            }
        }
        private DateTime fechanacimiento;

        public DateTime FechaNacimiento
        {
            get { return fechanacimiento; }
            set
            {
                fechanacimiento = value;
                OnPropertyChanged();
            }
        }
        private SexoEnum sexo;

        public SexoEnum Sexo
        {
            get { return sexo; }
            set { sexo = value;
                OnPropertyChanged();
            }
        }
        private bool prematuro;

        public bool Prematuro
        {
            get { return prematuro; }
            set { prematuro = value;
                OnPropertyChanged();
            }
        }

        private float peso;

        public float Peso
        {
            get { return peso; }
            set { peso = value;
                OnPropertyChanged();
            }
        }
        private string domicilio;

        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value;
                OnPropertyChanged();
            }
        }




        public void ActualizarPantalla()
        {
            Nombre = HijoModificado.Nombre;
            Apellido = HijoModificado.Apellido;
            DNI = HijoModificado.Dni.ToString();
            FechaNacimiento = HijoModificado.FechaNacimiento;
            Sexo = HijoModificado.Sexo;
            Prematuro = HijoModificado.Prematuro;
            Peso = (float)HijoModificado.Peso;
            Domicilio = HijoModificado.Domicilio;
        }

        public NuevoHijoViewModel()
        {
            GuardarNuevoHijoCommand = new Command(async () =>
            {
                
                //controlamos que los cuatro campos hayan sido cargados
                if (nombre != null && apellido != null &&
                  dni != null && fechanacimiento != null  )
                {
                    if (HijoModificado!=null&&HijoModificado.Id>0)
                        await ActualizarHijoAsync();
                    else { 
                        //hacemos asincrónica la carga del hijo
                        await AgregadoHijoAsync() ;
                    }
                    await RedirigiendoARegistroDeHijos();
                }
                else
                    MessagingCenter.Send<object>(this, "CamposIncompletosCargaHijo");
            }
            );
        }

        private async Task ActualizarHijoAsync()
        {
            await Task.Run(() =>
            {
                var dbAdminHijos = new DbAdminHijos();
                _ = dbAdminHijos.Actualizar(new Paciente() { Id = HijoModificado.Id, Nombre = nombre, Apellido = apellido, Dni = int.Parse(dni), FechaNacimiento = fechanacimiento, Sexo = sexo, Prematuro = prematuro, Peso = peso, Domicilio = domicilio, TutorId=Inicio.TutorLogueado.Id });
            });
        }

        private async Task RedirigiendoARegistroDeHijos()
        {
              MessagingCenter.Send<object>(this, "RegistroDeHijos");

        }

        private async Task AgregadoHijoAsync()
        {
            await Task.Run(() =>
            {
                var dbAdminHijos = new DbAdminHijos();
                _ = dbAdminHijos.Agregar(nombre, apellido, dni, fechanacimiento, sexo, prematuro, peso, domicilio);
            });
        }
    }
}

