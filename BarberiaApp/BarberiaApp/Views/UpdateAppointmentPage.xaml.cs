using BarberiaApp.Models;
using BarberiaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarberiaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateAppointmentPage : ContentPage
    {
        AppoinmentViewModel viewModel;
        CategoryAppointmentViewModel categoryAppointmentViewModel;
        public UpdateAppointmentPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AppoinmentViewModel();
            categoryAppointmentViewModel = new CategoryAppointmentViewModel();
            LoadCategories();
            LoadInfo();    
        }

        private async void LoadCategories()
        {
            PkrCategory.ItemsSource = await categoryAppointmentViewModel.GetCategoriesAsync();
        }

        private void LoadInfo() 
        {
            
            TxtDescription.Text = GlobalObjects.MyLocalCita.Descripcion.ToString();
            DtDate.Date = GlobalObjects.MyLocalCita.Fechad;
            TimeSpan parsedTime = TimeSpan.ParseExact(GlobalObjects.MyLocalCita.Horad, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
            TpTime.Time = parsedTime;
            PkrCategory.SelectedItem = GlobalObjects.MyLocalCita.IdCategoriaCita;
           
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (ValidateFields())
            {

                try
                {
                    CategoryAppoinment SelectedCategory = PkrCategory.SelectedItem as CategoryAppoinment;
                    Appoinment cita = new Appoinment();
                    cita.CitaID = GlobalObjects.MyLocalCita.Citaid;
                    cita.Description = TxtDescription.Text.Trim();
                    cita.Fecha = DtDate.Date;
                    cita.Hora = TpTime.Time.ToString(@"hh\:mm\:ss");
                    cita.CategoriaCitaId = SelectedCategory.CategoriaCitaID;

                    var answer = await DisplayAlert("???", "Are you sure to continue updating this appointment info?", "Yes", "No");

                    if (answer)
                    {
                        bool R = await viewModel.UpdateAppointment(cita);

                        if (R)
                        {
                            await DisplayAlert(":)", "Appointment Updated!!!", "OK");
                            await Navigation.PopAsync();
                            
                        }
                        else
                        {
                            await DisplayAlert(":(", "Something went wrong...", "OK");
                           
                        }

                    }

                }
                catch (Exception)
                {

                    throw;
                }



            }
        }
        private bool ValidateFields()
        {
            bool R = false;
            if (TxtDescription.Text != null && !string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {

                R = true;
            }
            else
            {
                if (TxtDescription.Text == null || string.IsNullOrEmpty(TxtDescription.Text.Trim()))
                {
                    DisplayAlert("Validation Failed!", "The Name is required", "OK");
                    TxtDescription.Focus();
                    return false;
                }

            }

            return R;
        }

    }
}