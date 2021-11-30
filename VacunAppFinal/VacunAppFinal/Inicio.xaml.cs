using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacunAppFinal.Models;
using VacunAppFinal.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VacunAppFinal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        public static Tutor TutorLogueado;
        public Inicio()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<object>(this, "RegistroDeHijos", (obj) =>
            {
                _ = Navigation.PushAsync(new RegistroDeHijos());
            });
            MessagingCenter.Subscribe<object>(this, "NuevaVacuna", (obj) =>
            {
                _ = Navigation.PushAsync(new CargarVacunacionPaciente());
            });
            MessagingCenter.Subscribe<object>(this, "NuevoHijo", (obj) =>
            {
                _ = Navigation.PushAsync(new NuevoHijo());
            });
            MessagingCenter.Subscribe<object,Paciente>(this, "ModificarHijo", (obj,hijoSeleccionado) =>
            {
                _ = Navigation.PushAsync(new NuevoHijo(hijoSeleccionado));
            });
            MessagingCenter.Subscribe<object>(this, "IniciarSesion", (obj) =>
            {
                _ = Navigation.PushAsync(new IniciarSesion());
            });
            MessagingCenter.Subscribe<object>(this, "InicioLogueado", (obj) =>
            {
                _ = Navigation.PushAsync(new InicioLogueado());
            });
            MessagingCenter.Subscribe<object>(this, "LoginInválido", (obj) =>
            {
                _ = DisplayAlert("Mensaje", "Datos inválidos", "Ok");
            });
            MessagingCenter.Subscribe<object>(this, "CamposIncompletosInicioSesion", (obj) =>
            {
                _ = DisplayAlert("Campo/s incompleto/s", "Debe cargar todos los campos de la pantalla", "Ok");
            });
            MessagingCenter.Subscribe<object>(this, "ErrorRestriccionPasswordInicioSesion", (obj) =>
            {
                _ = DisplayAlert("Error en contraseña", "La contraseña debe tener al menos 4 caracteres", "Ok");
            });
            MessagingCenter.Subscribe<object>(this, "CamposIncompletosCargaHijo", (obj) =>
            {
                _ = DisplayAlert("Campos incompletos", "Debe ingresar obligatoriamente Nombre, Apellido, DNI, Fecha de nacimiento y Sexo del hijo que quiera registrar", "Ok");
            });

        }
        private void AbrirPantallaRegistrarme(object sender, EventArgs e)
        {
            _ = Navigation.PushAsync(new CrearCuenta());
        }

        private void AbrirPantallaIniciarSesion(object sender, EventArgs e)
        {
            _ = Navigation.PushAsync(new IniciarSesion());
        }
    }
}
