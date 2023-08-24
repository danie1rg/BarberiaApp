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
    public partial class AppointmentManagementPage : ContentPage
    {
        public AppointmentManagementPage()
        {
            InitializeComponent();
        }

        private async void BtnListCustumer_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListAppointmentsPage());
        }
    }
}