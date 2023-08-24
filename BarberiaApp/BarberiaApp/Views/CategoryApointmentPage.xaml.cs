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
    public partial class CategoryApointmentPage : ContentPage
    {
        public CategoryApointmentPage()
        {
            InitializeComponent();
        }

     
        private async void BtnAddCategories_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCategoryAppointment());
        }

        private async void BtnListCategories_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListCategoriesAppointmentPage());
        }
    }
}