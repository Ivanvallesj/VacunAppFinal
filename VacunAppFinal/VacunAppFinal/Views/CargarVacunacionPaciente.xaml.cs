using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacunAppFinal.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VacunAppFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CargarVacunacionPaciente : ContentPage
    {
         CargarVacunacionPacienteViewModel cargarVacunaViewModel ;
        private bool switchVacuna;

        public bool SwitchVacuna
        {
            get { return switchVacuna; }
            set 
            { 
                switchVacuna = value;
                OnPropertyChanged();
                cargarVacunaViewModel.AplicarVacuna(this, new EventArgs());
            }
        }

        public CargarVacunacionPaciente()
        {
            InitializeComponent();
            cargarVacunaViewModel = (CargarVacunacionPacienteViewModel)this.BindingContext;
        }
        void SwitchModificado(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            cargarVacunaViewModel.AplicarVacuna(this, new EventArgs());
        }
    }

}