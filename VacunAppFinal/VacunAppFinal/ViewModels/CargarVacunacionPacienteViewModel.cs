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

        public Command ObtenerHijosCommand { get; }
        public Command CargarVacunacionPacienteCommand { get; }

        readonly DbAdminHijos dbAdminHijos = new DbAdminHijos();
        readonly DbAdminVacunas dbAdminVacunas = new DbAdminVacunas();

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
        private ObservableCollection<Vacuna> vacunas;

        public ObservableCollection<Vacuna> Vacunas
        {
            get { return vacunas; }
            set { vacunas = value;
                OnPropertyChanged();
            }
        }

        public CargarVacunacionPacienteViewModel()
        {
            int idCalendario = 0;
            hijos = new ObservableCollection<Paciente>();
            ObtenerHijos(this, new EventArgs());
            nombreTutor = Inicio.TutorLogueado.Apellido + " " + Inicio.TutorLogueado.Nombre;
            ObtenerHijosCommand = new Command(async =>
            {
                ObtenerHijos(this, new EventArgs());
            });
            CargarVacunacionPacienteCommand = new Command (async =>
            {
                ObtenerVacunas(this, new EventArgs(),idCalendario);
                //ObtenerHijos(this, new EventArgs());
            });
        }

        public async void ObtenerVacunas(object sender, EventArgs e, int idCalendario)
        {
            vacunas.Clear();
            var vacunasCollection = await dbAdminVacunas.ObtenerTodos(idCalendario);
            foreach (Vacuna vacuna in vacunasCollection)
            {
                vacunas.Add(vacuna);
            }
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
