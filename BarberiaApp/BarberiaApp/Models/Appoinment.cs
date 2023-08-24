using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.ObjectModel;

namespace BarberiaApp.Models
{
    public class Appoinment
    {
        [JsonIgnore]
        public RestRequest Request { get; set; }
        public Appoinment()
        {
            Active = true;
        }

        public int CitaID { get; set; }
        public string? Description { get; set; }
        public DateTime Fecha { get; set; }
        public string? Hora { get; set; }
        public bool? Active { get; set; }
        public int UserId { get; set; }
        public int ClienteId { get; set; }
        public int CategoriaCitaId { get; set; }


        public virtual CategoryAppoinment? CategoryAppoinment { get; set; } = null!;
        public virtual Custumer? Custumer { get; set; } = null!;
        public virtual User? User { get; set; } = null!;


        public async Task<bool> AddCitaAsync()
        {
            try
            {
                string RouteSufix = string.Format("Citums");
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

       

        public async Task<bool> UpdateCitaAsync()
        {
            try
            {


                string RouteSufix = string.Format("Citums/{0}", this.CitaID);

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

        public async Task<bool> DeleteCitaAsync()
        {
            try
            {


                string RouteSufix = string.Format("Citums/Delete{0}", this.CitaID);

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
