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
    public partial class ListCustumerPage : ContentPage
    {
        CustumerViewModel viewModel;
        public ListCustumerPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CustumerViewModel();

            LoadCustumers();
        }

        private async void LoadCustumers() 
        {
            
           LvList.ItemsSource = await viewModel.GetCustumersAsync();

        }


        private async void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtSearch.Text.Length >= 3)
            {
                BindingContext = viewModel = new CustumerViewModel();
                LvList.ItemsSource = await viewModel.GetCustumersByNameAsync(TxtSearch.Text.Trim());
            }


            if (TxtSearch.Text.Length < 3)
            {
                BindingContext = viewModel = new CustumerViewModel();
                LoadCustumers();
            }
        }


        private async void ButtonUpdate_Clicked(object sender, EventArgs e)
        {
            if (LvList.SelectedItem != null)
            {
                Custumer selectedCustumer = LvList.SelectedItem as Custumer;

                GlobalObjects.MyLocalCustumer = selectedCustumer;
                //await DisplayAlert("Alert", $"The value of 's' is {nombre}", "OK");
                await Navigation.PushAsync(new UpdateCustumerPage());

            }
            else
            {
                // Display a message to the user indicating that no item is selected
                await DisplayAlert("Error", "Please select a customer to update.", "OK");
            }
            
            
        }

        private async void ButtonCreate_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCustumerPage());
            
        }

        private async void ButtonCreateCita_Clicked(object sender, EventArgs e)
        {
            if (LvList.SelectedItem != null)
            {
                Custumer selectedCustumer = LvList.SelectedItem as Custumer;

                GlobalObjects.MyLocalCustumer = selectedCustumer;
                //await DisplayAlert("Alert", $"The value of 's' is {nombre}", "OK");
                await Navigation.PushAsync(new AddAppointmentPage());

            }
            else
            {
                // Display a message to the user indicating that no item is selected
                await DisplayAlert("Error", "Please select a customer to create an appointment.", "OK");
            }
        }
    }
}