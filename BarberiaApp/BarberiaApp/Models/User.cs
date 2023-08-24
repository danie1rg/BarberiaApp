using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Internals.Profile;
using System.Threading.Tasks;
using System.Net;

namespace BarberiaApp.Models
{
    public class User
    {

        [JsonIgnore]
        public RestRequest Request { get; set; }
        public User()
        {
            Active = true;
        }

        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string BackUpEmail { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }
        public bool? Active { get; set; }
        public int UserRoleId { get; set; }

        public virtual UserRole UserRole { get; set; } = null!;


        public async Task<bool> ValidateUserLogin()
        {
            try
            {


                string RouteSufix = string.Format("Users/ValidateLogin?username={0}&password={1}", this.Email, this.Password);

                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);


                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);


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

        public async Task<User> GetUserInfo(string Pemail)
        {
            try
            {

                string RouteSufix = string.Format("Users/GetUserInfoByEmail?Pemail={0}", Pemail);

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
                    var list = JsonConvert.DeserializeObject<List<User>>(response.Content);

                    var item = list[0];
                    return item;
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

        public async Task<bool> AddUserAsync()
        {
            try
            {
                string RouteSufix = string.Format("Users");
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


        public async Task<bool> UpdateUserAsync()
        {
            try
            {


                string RouteSufix = string.Format("Users/{0}", this.UserId);

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

        public async Task<bool> UpdateUserAsyncByPassword()
        {
            try
            {


                string RouteSufix = string.Format("Users/{0}", this.UserId);

                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Patch);

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
