using System;
using System.Collections.Generic;
using System.Text;
using BarberiaApp.Models;
using BarberiaApp.ModelsDTO;

namespace BarberiaApp
{
    public static class GlobalObjects
    {
        public static string MimeType = "application/json";

        public static string ContentType = "Content-Type";

        public static User MyLocalUser = new User();

        public static Custumer MyLocalCustumer = new Custumer();

        public static CategoryAppoinment MyLocalCategory = new CategoryAppoinment();

        public static CitaDTO MyLocalCita = new CitaDTO();

    }
}
