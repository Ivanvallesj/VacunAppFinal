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
 public class DbAdminVacunasColocadas
    {
        const string Url = "https://sanjustosoft.ar/api/apiVacunasColocadas";
        public async Task<IEnumerable<VacunaColocada>> ObtenerTodos()
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            string result = await client.GetStringAsync(Url + "/tutor/" + Inicio.TutorLogueado.Id);
            return JsonConvert.DeserializeObject<IEnumerable<VacunaColocada>>(result);
        }

        public async Task<VacunaColocada> Agregar(int vacId, int pacId, DateTime fecha)
        {
            VacunaColocada vacunaColocada = new VacunaColocada()
            {
                VacunaId = vacId,
                PacienteId = pacId,
                Fecha = fecha
            };

            HttpClient client = Helper.ObtenerClienteHttp();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(vacunaColocada),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<VacunaColocada>(
                await response.Content.ReadAsStringAsync());
        }
    }
}
