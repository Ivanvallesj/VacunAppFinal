using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VacunAppFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrearCuenta : ContentPage
    {
        public CrearCuenta()
        {
            InitializeComponent();
        }
        private void AbrirPantallaCrearCuenta(object sender, EventArgs e)
        {
            _ = Navigation.PushAsync(new RegistroNuevaCuenta());
        }
    }
}