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
    public partial class AddAppointmentPage : ContentPage
    {
        CategoryAppointmentViewModel viewModeCategory;
        AppoinmentViewModel viewModel;

        public AddAppointmentPage()
        {
            InitializeComponent();

            BindingContext = viewModeCategory = new CategoryAppointmentViewModel();
            viewModel = new AppoinmentViewModel();
            LoadCategories();
        }

        private async void LoadCategories() 
        {
            PkrCategory.ItemsSource = await viewModeCategory.GetCategoriesAsync();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            CategoryAppoinment SelectedCategory = PkrCategory.SelectedItem as CategoryAppoinment;

            DateTime Fecha = DtDate.Date;


            string formattedTime = TpTime.Time.ToString(@"hh\:mm\:ss");

           
            int cliente = GlobalObjects.MyLocalCustumer.ClienteId;
            int usuario = GlobalObjects.MyLocalUser.UserId;

            bool R = await viewModel.AddAppointmentAsync(
                TxtDescription.Text.Trim(),
                Fecha,
                formattedTime,
                usuario,
                cliente, 
                SelectedCategory.CategoriaCitaID);

            if (R)
            {
                await DisplayAlert(":)", "Appointment was created successfully!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Something went wrong...", "OK");
            }
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

       
    }
}