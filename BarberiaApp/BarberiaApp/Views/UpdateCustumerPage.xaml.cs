using BarberiaApp.Models;
using BarberiaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarberiaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateCustumerPage : ContentPage
    {
        CustumerViewModel viewModel;

        public UpdateCustumerPage()
        {
            InitializeComponent();
            
            BindingContext = viewModel = new CustumerViewModel();

            LoadCustumerInfo();
        }

        private void LoadCustumerInfo()
        {
            TxtNombre.Text = GlobalObjects.MyLocalCustumer.Nombre.ToString();
            TxtApellidos.Text = GlobalObjects.MyLocalCustumer.Apellidos.ToString();
            TxtCorreo.Text = GlobalObjects.MyLocalCustumer.Correo.ToString();
            TxtPhoneNumber.Text = GlobalObjects.MyLocalCustumer.Celular.ToString();

        }

        private bool ValidateFields()
        {
            bool R = false;
            if (TxtNombre.Text != null && !string.IsNullOrEmpty(TxtNombre.Text.Trim()) &&
                TxtApellidos.Text != null && !string.IsNullOrEmpty(TxtApellidos.Text.Trim()) &&
                TxtCorreo.Text != null && !string.IsNullOrEmpty(TxtCorreo.Text.Trim()) &&
                TxtPhoneNumber.Text != null && !string.IsNullOrEmpty(TxtPhoneNumber.Text.Trim()))
            {
                R = true;

            }
            else
            {
                if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()))
                {
                    DisplayAlert("Validation Failed", "The name is requeired", "OK");
                    TxtNombre.Focus();
                    return false;
                }

                if (TxtApellidos.Text == null || string.IsNullOrEmpty(TxtApellidos.Text.Trim()))
                {
                    DisplayAlert("Validation Failed", "The last name is requeired", "OK");
                    TxtApellidos.Focus();
                    return false;
                }
                if (TxtCorreo.Text == null || string.IsNullOrEmpty(TxtCorreo.Text.Trim()))
                {
                    DisplayAlert("Validation Failed", "The phone number is requeired", "OK");
                    TxtCorreo.Focus();
                    return false;
                }

                if (TxtPhoneNumber.Text == null || string.IsNullOrEmpty(TxtPhoneNumber.Text.Trim()))
                {
                    DisplayAlert("Validation Failed", "The phone number is requeired", "OK");
                    TxtPhoneNumber.Focus();
                    return false;
                }
            }
            return R;

        }



        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (ValidateFields())
            {

                

                try
                {
                    GlobalObjects.MyLocalCustumer.Nombre = TxtNombre.Text.Trim();
                    GlobalObjects.MyLocalCustumer.Apellidos = TxtApellidos.Text.Trim();
                    GlobalObjects.MyLocalCustumer.Correo = TxtCorreo.Text.Trim();
                    GlobalObjects.MyLocalCustumer.Celular = TxtPhoneNumber.Text.Trim();

                    var answer = await DisplayAlert("???", "Are you sure to continue updating custumer info?", "Yes", "No");

                    if (answer)
                    {
                        bool R = await viewModel.UpdateCustumer(GlobalObjects.MyLocalCustumer); ;

                        if (R)
                        {
                            await DisplayAlert(":(", "Something went wrong!", "OK!");
                        }
                        else
                        {
                            await DisplayAlert(":)", "Custumer Updated", "OK!");
                            await Navigation.PopAsync();

                           
                        }

                    }

                }
                catch (Exception)
                {
                    throw;

                }

            }
        }

    }
}