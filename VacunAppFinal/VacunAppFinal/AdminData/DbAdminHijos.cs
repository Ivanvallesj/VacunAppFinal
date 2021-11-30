using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VacunAppFinal.Core;
using VacunAppFinal.Models;

namespace VacunAppFinal.AdminData
{
    public class DbAdminHijos    {
        const string Url = "https://sanjustosoft.ar/api/apiPacientes";



        public async Task<IEnumerable<Paciente>> ObtenerTodos()
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            string result = await client.GetStringAsync(Url+"/tutor/"+Inicio.TutorLogueado.Id);
            return JsonConvert.DeserializeObject<IEnumerable<Paciente>>(result);
        }
        
        public async Task<Paciente> Agregar(string nom, string ape, string dni, DateTime fechanac, SexoEnum sexo, bool prema, float peso, string domi)
        {
            Paciente paciente = new Paciente()
            {
                Nombre = nom,
                Apellido = ape,
                Dni = Convert.ToInt32(dni),
                FechaNacimiento=fechanac,
                Sexo=sexo,
                Prematuro=prema,
                Peso=peso,
                Domicilio=domi,
                TutorId=Inicio.TutorLogueado.Id,
                CalendarioId=obtenerIdCalendario(sexo,prema)
            };

            HttpClient client = Helper.ObtenerClienteHttp();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(paciente),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Paciente>(
                await response.Content.ReadAsStringAsync());
        }

        private int? obtenerIdCalendario(SexoEnum sexo, bool prema)
        {
            if (sexo == SexoEnum.Masculino)
                if (prema)
                    return 4;
                else
                    return 1;
            else
                if (prema)
                    return 3;
                else
                    return 2;
        }

        public async Task Actualizar(Paciente paciente)
        {
            paciente.CalendarioId = obtenerIdCalendario(paciente.Sexo, paciente.Prematuro);
            HttpClient client = Helper.ObtenerClienteHttp();
            await client.PutAsync(Url + "/" + paciente.Id,
                new StringContent(
                    JsonConvert.SerializeObject(paciente),
                    Encoding.UTF8, "application/json"));
        }

        public async Task Eliminar(int id)
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            await client.DeleteAsync(Url + "/" + id);
        }
    }
}
