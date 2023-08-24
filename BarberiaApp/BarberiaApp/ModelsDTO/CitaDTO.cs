using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using BarberiaApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BarberiaApp.ModelsDTO
{
    public class CitaDTO
    {
        [JsonIgnore]
        public RestRequest Request { get; set; }

        public CitaDTO() { }

        public int Citaid { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fechad { get; set; }
        public string? Horad { get; set; }
        public bool? Actived { get; set; }
        public int IdUser { get; set; }
        public int IdCliente { get; set; }
        public int IdCategoriaCita { get; set; }

        public string NombreDeCliente { get; set; } = null!;
        public string ApellidosDeCliente { get; set; } = null!;
        public string? CorreoDeCliente { get; set; }
        public string? CelularDeCliente { get; set; }

        public string FullNombre => $"{NombreDeCliente} {ApellidosDeCliente}";

        public async Task<ObservableCollection<CitaDTO>> GetCitaListByUserID()
        {
            try
            {

                string RouteSufix = string.Format("Citums/GetCitasListByUsuario?id={0}", this.IdUser);

                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos la llave de seguridad, en este caso API KEY

                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

                //ejecutar la llamada al API

                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<ObservableCollection<CitaDTO>>(response.Content);


                    return list;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }




    }
}
