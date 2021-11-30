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
        public Command CargarVacunacionCommand { get; }
        readonly DbAdminVacunas dbAdminVacunas = new DbAdminVacunas();

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
        private ObservableCollection<Calendario> calendario;
        public ObservableCollection<Calendario> Calendarios
        {
            get { return calendario; }
            set
            {
                calendario = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Vacuna> vacuna;
        public ObservableCollection<Vacuna> Vacunas
        {
            get { return vacuna; }
            set
            {
                vacuna = value;
                OnPropertyChanged();
            }
        }
        public CargarVacunacionPacienteViewModel()
        {
            hijos = new ObservableCollection<Paciente>();
           
            CargarVacunacionCommand = new Command(async =>
            {
                MessagingCenter.Send<object>(this, "NuevaVacuna");
            });
        }
        
    }
}
