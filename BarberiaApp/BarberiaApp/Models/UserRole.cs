using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace BarberiaApp.Models
{
    public class UserRole
    {
        public RestRequest Request { get; set; }
        public UserRole()
        {
            
        }

        public int UserRoleId { get; set; }
        public string Description { get; set; } = null!;


        public async Task<List<UserRole>> GetAllUserRoles()
        {
            try
            {

                string RouteSufix = string.Format("UserRoles");

                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos la llave de seguridad, en este caso API KEY

                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);

                //ejecutar la llamada al API

                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<UserRole>>(response.Content);
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
