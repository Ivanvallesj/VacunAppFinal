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
        public Command CargarVacunacionPacienteCommand { get; }
        readonly DbAdminVacunas dbAdminVacunas = new DbAdminVacunas();
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
            set
            {
                vacunas = value;
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
        public CargarVacunacionPacienteViewModel()
        {
            nombreTutor = Inicio.TutorLogueado.Apellido + " " + Inicio.TutorLogueado.Nombre;
            int idCalendario = 0;
            CargarVacunacionPacienteCommand = new Command(async =>
            {
               
                ObtenerHijos(this, new EventArgs());
                ObtenerVacunas(this, new EventArgs(), idCalendario);
            });

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
        public async void ObtenerVacunas(object sender, EventArgs e, int idCalendario)
        {
            vacunas.Clear();
            var vacunasCollection = await dbAdminVacunas.ObtenerTodos(1);

            foreach (Vacuna vacuna in vacunasCollection)
            {
                vacunas.Add(vacuna);
            }
        }

    }
}
