using BarberiaApp.Models;
using BarberiaApp.ModelsDTO;
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
    public partial class ListAppointmentsPage : ContentPage
    {
        AppoinmentViewModel viewModel;
        public ListAppointmentsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AppoinmentViewModel();
            LoadAppoinments();
        }

        private async void LoadAppoinments() 
        {
            LvList.ItemsSource = await viewModel.GetCitasAsync(GlobalObjects.MyLocalUser.UserId);
        }


        private async void ButtonUpdateCita_Clicked(object sender, EventArgs e)
        {
            if (LvList.SelectedItem != null)
            {
                CitaDTO selectedCita = LvList.SelectedItem as CitaDTO;

                GlobalObjects.MyLocalCita = selectedCita;
                //await DisplayAlert("Alert", $"The value of 's' is {nombre}", "OK");
                await Navigation.PushAsync(new UpdateAppointmentPage());

            }
            else
            {
                // Display a message to the user indicating that no item is selected
                await DisplayAlert("Error", "Please select an appointment to update.", "OK");
            }
        }

     



    }


}