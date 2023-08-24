using BarberiaApp.Models;
using BarberiaApp.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Xamarin.Forms.Internals.Profile;

namespace BarberiaApp.ViewModels
{
    public class AppoinmentViewModel : BaseViewModel
    {
        public Appoinment MyAppointment { get; set; }
        public User MyUser { get; set; }

        public CitaDTO MyCita { get; set; }

        public CategoryAppoinment MyCategory { get; set; }


        public AppoinmentViewModel() 
        {
            MyAppointment = new Appoinment();
            MyUser = new User();
            MyCategory = new CategoryAppoinment();
            MyCita = new CitaDTO();

           
        }

        public async Task<bool> AddAppointmentAsync(string pDescription, DateTime pFecha, string pHora, int pUsuario, int pCliente, int pCategory)
        {

            if(IsBusy)
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyAppointment.Description = pDescription;
                MyAppointment.Fecha = pFecha;
                MyAppointment.Hora = pHora;
                MyAppointment.UserId = pUsuario;
                MyAppointment.CategoriaCitaId = pCategory;
                MyAppointment.ClienteId = pCliente;


                bool R = await MyAppointment.AddCitaAsync();

                return R;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<ObservableCollection<CitaDTO>> GetCitasAsync(int pUserID)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                ObservableCollection<CitaDTO> protocols = new ObservableCollection<CitaDTO>();

                MyCita.IdUser = pUserID;


                protocols = await MyCita.GetCitaListByUserID();

                if (protocols == null) { return null; }
                return protocols;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public async Task<bool> UpdateAppointment(Appoinment pCita)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyAppointment = pCita;


                bool R = await MyAppointment.UpdateCitaAsync();

                return R;

            }
            catch
            (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
        }

        public async Task<bool> DeleteAppointment(Appoinment pCita)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyAppointment = pCita;
                MyAppointment.Active = false;


                bool R = await MyAppointment.DeleteCitaAsync();

                return R;

            }
            catch
            (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
        }






    }
}
