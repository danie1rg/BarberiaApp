using RestSharp;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Xamarin.Forms.Internals.Profile;
using System.Collections.ObjectModel;

namespace BarberiaApp.Models
{
    public class CategoryAppoinment
    {

        [JsonIgnore]
        public RestRequest Request { get; set; }
        public CategoryAppoinment()
        {
            
        }

        public int CategoriaCitaID { get; set; }
        public string Description { get; set; } = null!;



        public async Task<bool> AddCategoryAsync()
        {
            try
            {
                string RouteSufix = string.Format("CategoriaCitums");
                //armamos la ruta completa al endpoint en el API 
                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Post);

                //agregamos mecanismo de seguridad, en este caso API key
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);

                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

                //en el caso de una operación POST debemos serializar el objeto para pasarlo como 
                //json al API

                string SerializedModel = JsonConvert.SerializeObject(this);
                //agregamos el objeto serializado el el cuuerpo del request. 
                Request.AddBody(SerializedModel, GlobalObjects.MimeType);

                //ejecutar la llamada al API 
                RestResponse response = await client.ExecuteAsync(Request);

                //saber si las cosas salieron bien 
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

        public async Task<ObservableCollection<CategoryAppoinment>> GetAllCategories()
        {
            try
            {

                string RouteSufix = string.Format("CategoriaCitums");

                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);


                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);


                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<ObservableCollection<CategoryAppoinment>>(response.Content);
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

        public async Task<bool> UpdateCategoryAsync()
        {
            try
            {


                string RouteSufix = string.Format("CategoriaCitums/{0}", this.CategoriaCitaID);

                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Put);

                //agregamos la llave de seguridad, en este caso API KEY

                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);


                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);


                //en el caso de una operación POSS debemos serializar el objecto para pasarlo como json al API

                string SerializedModelObject = JsonConvert.SerializeObject(this);

                //agregamos el objecto serializado en el cuerpo del request


                Request.AddBody(SerializedModelObject, GlobalObjects.MimeType);


                //ejecutar la llamada al API

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
