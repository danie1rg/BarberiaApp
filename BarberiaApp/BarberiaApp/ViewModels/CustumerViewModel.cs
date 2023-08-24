using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using BarberiaApp.Models;

namespace BarberiaApp.ViewModels
{
    public class CustumerViewModel : BaseViewModel
    {
        public Custumer MyCustumer { get; set; }

        public CustumerViewModel() 
        {
            MyCustumer = new Custumer();
        }

        public async Task<bool> AddCustumerAsync(string pNombre, string pApellidos, string pCorreo, string pCelular)
        {

            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyCustumer.Nombre = pNombre;
                MyCustumer.Apellidos = pApellidos;
                MyCustumer.Correo = pCorreo;
                MyCustumer.Celular = pCelular;


                bool R = await MyCustumer.AddCustumerAsync();

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

        public async Task<ObservableCollection<Custumer>> GetCustumersAsync()
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                ObservableCollection<Custumer> custumers = new ObservableCollection<Custumer>();


                custumers =  await MyCustumer.GetAllCustumers();


                if (custumers == null) { return null; }
                return custumers;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public async Task<ObservableCollection<Custumer>> GetCustumersByNameAsync(string n)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                ObservableCollection<Custumer> custumers = new ObservableCollection<Custumer>();

                
                MyCustumer.Nombre = n;
                

                custumers = await MyCustumer.GetCustumerByNameOrGmail();

                if (custumers == null) { return null; }
                return custumers;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public async Task<bool> UpdateCustumer(Custumer pUser)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyCustumer = pUser;


                bool R = await MyCustumer.UpdateCustumerAsync();

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
