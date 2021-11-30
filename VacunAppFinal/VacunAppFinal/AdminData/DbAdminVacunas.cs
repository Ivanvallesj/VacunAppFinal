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
        const string Url = "https://sanjustosoft.ar/api/apiVacunas";

        public async Task<IEnumerable<Vacuna>> ObtenerTodos()
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            string result = await client.GetStringAsync(Url + "/tutor/" + Inicio.TutorLogueado.Id);
            return JsonConvert.DeserializeObject<IEnumerable<Vacuna>>(result);
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
        public async Task Eliminar(int id)
        {
            HttpClient client = Helper.ObtenerClienteHttp();
            await client.DeleteAsync(Url + "/" + id);
        }
    }
}
