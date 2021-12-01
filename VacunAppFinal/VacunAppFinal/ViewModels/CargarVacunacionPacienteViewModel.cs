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
            ObtenerHijos(this, new EventArgs());
            ObtenerVacunas(this, new EventArgs());
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
        public async void ObtenerVacunas(object sender, EventArgs e,int idCalendario)
        {
            vacunas.Clear();
            var vacunasCollection = await dbAdminVacunas.ObtenerTodos(idCalendario);

            foreach (Vacuna vacuna in vacunasCollection)
            {
                vacunas.Add(vacuna);
            }
        }

    }
}
