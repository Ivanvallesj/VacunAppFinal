using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VacunAppFinal.Core;
using VacunAppFinal.Models;

namespace VacunAppFinal.AdminData
{
    public class DbAdminLogin { 

        const string Url = "https://sanjustosoft.ar/api/apiLogins";



        public async Task<IEnumerable<Tutor>> ObtenerTodos()
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Tutor>>(result);
        }

        public async Task<Tutor> ObtenerTutorLogueado(string ema, string pas)
        {
            Login login = new Login()
            {
                Id=0,
                Email = ema,
                Password = Helper.ObtenerSha256Hash(pas)
            };

            HttpClient client = Helper.ObtenerClienteHttp();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(login),
                    Encoding.UTF8, "application/json"));
            var jsonContenidoRespuesta =
            response.Content.ReadAsStringAsync();
            Tutor tutorLogueado = JsonConvert.DeserializeObject<Tutor>(await jsonContenidoRespuesta);

            return tutorLogueado;
        }

        public async Task Actualizar(Tutor tutor)
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            await client.PutAsync(Url + "/" + tutor.Id,
                new StringContent(
                    JsonConvert.SerializeObject(tutor),
                    Encoding.UTF8, "application/json"));
        }

        public async Task Eliminar(int id)
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            await client.DeleteAsync(Url + "/" + id);
        }
    }
}
