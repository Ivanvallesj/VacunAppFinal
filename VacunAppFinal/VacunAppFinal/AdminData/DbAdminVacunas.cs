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
    public class DbAdminVacunas
    {
        const string Url = "https://sanjustosoft.ar/api/apiVacuna";

        public async Task<IEnumerable<Paciente>> ObtenerTodos()
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            string result = await client.GetStringAsync(Url + "/tutor/" + Inicio.TutorLogueado.Id);
            return JsonConvert.DeserializeObject<IEnumerable<Paciente>>(result);
        }
        public async Task<IEnumerable<Vacuna>> ObtenerTodos(int idCalendario)
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            string result = await client.GetStringAsync(Url + "/calendario/" + idCalendario);
            return JsonConvert.DeserializeObject<IEnumerable<Vacuna>>(result);
        }
    }
}
