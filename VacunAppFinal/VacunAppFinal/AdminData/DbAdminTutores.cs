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
    public class DbAdminTutores
    {
        const string Url = "https://sanjustosoft.ar/api/apiTutores";



        public async Task<IEnumerable<Tutor>> ObtenerTodos()
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Tutor>>(result);
        }

        public async Task<Tutor> Agregar(string nom, string ape, string ema, string pas)
        {
            Tutor tutor = new Tutor()
            {
                Nombre = nom,
                Apellido = ape,
                Email = ema,
                Password = Helper.ObtenerSha256Hash(pas)
            };

            HttpClient client = Helper.ObtenerClienteHttp();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(tutor),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Tutor>(
                await response.Content.ReadAsStringAsync());
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
