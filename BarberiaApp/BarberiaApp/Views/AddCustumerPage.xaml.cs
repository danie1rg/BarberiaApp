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
    public partial class AddCustumerPage : ContentPage
    {
        CustumerViewModel viewModel;
        public AddCustumerPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CustumerViewModel();

        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            bool R = await viewModel.AddCustumerAsync(TxtNombre.Text.Trim(),
                TxtApellidos.Text.Trim(),
                TxtCorreo.Text.Trim(),
                TxtPhoneNumber.Text.Trim());

            if (R) 
            {
                await DisplayAlert(":)", "User created succesfully", "OK");
                await Navigation.PopAsync();
            }
            else 
            {
                await DisplayAlert(":(", "Something went wrong", "OK");
            }

        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}