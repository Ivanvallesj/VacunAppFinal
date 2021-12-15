using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using VacunAppFinal.AdminData;
using VacunAppFinal.Core;
using VacunAppFinal.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Core;

namespace VacunAppFinal.ViewModels
{
    public class CargarVacunacionPacienteViewModel : ObjetoNotificacion
    {

        public Command ObtenerHijosCommand { get; }
        public Command CargarVacunacionPacienteCommand { get; }
        public Command AplicarVacunaCommand { get; }

        public bool SwitchAplicarVacuna = false;

        readonly DbAdminHijos dbAdminHijos = new DbAdminHijos();
        readonly DbAdminVacunas dbAdminVacunas = new DbAdminVacunas();
        readonly DbAdminVacunasColocadas dbAdminVacunasColocadas = new DbAdminVacunasColocadas();

        private Vacuna vacunaSeleccionada;

        public Vacuna VacunaSeleccionada
        {
            get { return vacunaSeleccionada; }
            set { 
                vacunaSeleccionada = value;
                OnPropertyChanged();
            }
        }

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
                ObtenerVacunas(this, new EventArgs(), (int)(hijoSeleccionado.CalendarioId == null ? 0 : hijoSeleccionado.CalendarioId));
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
        private ObservableCollection<VacunaColocada> vacunaColocada;

        public ObservableCollection<VacunaColocada> VacunaColocada
        {
            get { return vacunaColocada; }
            set
            {
                vacunaColocada = value;
                OnPropertyChanged();
            }
        }

        public CargarVacunacionPacienteViewModel()
        {
            
            int idCalendario = 0;
            hijos = new ObservableCollection<Paciente>();
            vacunas = new ObservableCollection<Vacuna>();
            vacunaColocada = new ObservableCollection<VacunaColocada>();
            ObtenerHijos(this, new EventArgs());
            ObtenerVacunas(this, new EventArgs(), idCalendario);
            nombreTutor = Inicio.TutorLogueado.Apellido + " " + Inicio.TutorLogueado.Nombre;
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
        public async void AplicarVacuna(object sender, EventArgs e)
        {
            bool result = await Application.Current.MainPage.DisplayAlert("Confirmacion", "¿Estás seguro que deseas aplicar la vacuna", "Aceptar", "Cancelar");
            if (result)
            {
                await Task.Run(() =>
                {
                    var dbAdminVacunasColocadas = new DbAdminVacunasColocadas();
                    _ = dbAdminVacunasColocadas.Agregar(vacunaSeleccionada.Id, hijoSeleccionado.Id, DateTime.Now);
                });
            }
        }
    }
}
