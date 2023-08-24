using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Internals.Profile;
using System.Threading.Tasks;
using System.Net;
using System.Collections.ObjectModel;

namespace BarberiaApp.Models
{
    public class Custumer
    {

        [JsonIgnore]
        public RestRequest Request { get; set; }

        public Custumer()
        {
            Active = true;
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string? Correo { get; set; }
        public string? Celular { get; set; }
        public bool? Active { get; set; }

        public string FullName => $"{Nombre} {Apellidos}";



        public async Task<bool> AddCustumerAsync()
        {
            try
            {
                string RouteSufix = string.Format("Clientes");

                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Post);

                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);

                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);


                string SerializedModel = JsonConvert.SerializeObject(this);
                Request.AddBody(SerializedModel, GlobalObjects.MimeType);

                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }

        }

        public async Task<ObservableCollection<Custumer>> GetAllCustumers()
        {
            try
            {

                string RouteSufix = string.Format("Clientes");

                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);


                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);


                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<ObservableCollection<Custumer>>(response.Content);
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

        public async Task<ObservableCollection<Custumer>> GetCustumerByNameOrGmail()
        {
            try
            {
                
                string RouteSufix = string.Format("Clientes/GetClienteByEmailOrName?Nombre={0}", this.Nombre);
                
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
                    var list = JsonConvert.DeserializeObject<ObservableCollection<Custumer>>(response.Content);


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




        public async Task<bool> UpdateCustumerAsync()
        {
            try
            {

                string RouteSufix = string.Format("Clientes/{0}", this.ClienteId);

                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Put);


                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);


                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);



                string SerializedModelObject = JsonConvert.SerializeObject(this);


                Request.AddBody(SerializedModelObject, GlobalObjects.MimeType);


                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
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
