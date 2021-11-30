using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacunAppFinal.Models;
using VacunAppFinal.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VacunAppFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevoHijo : ContentPage
    {
        NuevoHijoViewModel nuevoHijoViewModel;
        public NuevoHijo()
        {
            InitializeComponent();
            nuevoHijoViewModel = (NuevoHijoViewModel)this.BindingContext;
        }
        public NuevoHijo(Paciente hijoSeleccionado)
        {
            InitializeComponent();
            nuevoHijoViewModel = (NuevoHijoViewModel)this.BindingContext;
            nuevoHijoViewModel.HijoModificado=hijoSeleccionado;
            nuevoHijoViewModel.ActualizarPantalla();
            //MostrarSexoSeleccionado();
        }

        //private void MostrarSexoSeleccionado()
        //{
        //    if (nuevoHijoViewModel.Sexo == SexoEnum.Masculino)
        //        RadioMasculino.IsChecked = true;
        //    else
        //        RadioFemenino.IsChecked = true;
        //}

        //private void SexoSeleccionado(object sender, EventArgs e)
        //{
        //    if (RadioMasculino.IsChecked)
        //        nuevoHijoViewModel.Sexo = SexoEnum.Masculino;
        //    if (RadioFemenino.IsChecked)
        //        nuevoHijoViewModel.Sexo = SexoEnum.Femenino;
        //}
    }
}