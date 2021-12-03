using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VacunAppFinal.AdminData;
using VacunAppFinal.Core;
using VacunAppFinal.Models;
using Xamarin.Forms;

namespace VacunAppFinal.ViewModels
{
    public class CargarVacunacionPacienteViewModel : ObjetoNotificacion
    {
        public Command CargarHijoCommand { get; }
        public Command ModificarHijoCommand { get; }
        public Command EliminarHijoCommand { get; }
        public Command ObtenerHijosCommand { get; }

        readonly DbAdminHijos dbAdminHijos = new DbAdminHijos();
        private string nombreTutor;

        public string NombreTutor
        {
            get { return nombreTutor; }
            set
            {
                nombreTutor = value;
                OnPropertyChanged();
            }
        }
        private Paciente hijoSeleccionado;

        public Paciente HijoSeleccionado
        {
            get { return hijoSeleccionado; }
            set
            {
                hijoSeleccionado = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Paciente> hijos;
        public ObservableCollection<Paciente> Hijos
        {
            get { return hijos; }
            set
            {
                hijos = value;
                OnPropertyChanged();
            }
        }
        public CargarVacunacionPacienteViewModel()
        {
            hijos = new ObservableCollection<Paciente>();   
            ObtenerHijos(this, new EventArgs());
            nombreTutor = Inicio.TutorLogueado.Apellido + " " + Inicio.TutorLogueado.Nombre;
            ObtenerHijosCommand = new Command(async =>
            {
                ObtenerHijos(this, new EventArgs());
            });
            CargarHijoCommand = new Command(async =>
            {
                MessagingCenter.Send<object>(this, "NuevoHijo");
            });
            ModificarHijoCommand = new Command(execute: () =>
            {
                MessagingCenter.Send<object, Paciente>(this, "ModificarHijo", hijoSeleccionado);
            },
            canExecute: () =>
            {
                return hijoSeleccionado != null;
            }
            );
            EliminarHijoCommand = new Command(execute: async () =>
            {
                bool result = await Application.Current.MainPage.DisplayAlert("Pregunta importante", "Está seguro/a que quiere borrar el hijo seleccionado", "Sí", "No");
                if (result)
                {
                    _ = dbAdminHijos.Eliminar(hijoSeleccionado.Id);
                    ObtenerHijos(this, new EventArgs());
                }
            },
            canExecute: () =>
            {
                return hijoSeleccionado != null;
            }
            );
        }

        public async void ObtenerHijos(object sender, EventArgs e)
        {
            hijos.Clear();
            var hijosCollection = await dbAdminHijos.ObtenerTodos();

            foreach (Paciente hijo in hijosCollection)
            {
                hijos.Add(hijo);
            }
        }

    }
}
