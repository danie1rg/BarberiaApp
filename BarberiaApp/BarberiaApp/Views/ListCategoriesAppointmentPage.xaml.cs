using BarberiaApp.Models;
using BarberiaApp.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarberiaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListCategoriesAppointmentPage : ContentPage
    {
        CategoryAppointmentViewModel viewModel;
        public ListCategoriesAppointmentPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CategoryAppointmentViewModel();

            LoadCategories();
        }


        private async void LoadCategories()
        {

            LvList.ItemsSource = await viewModel.GetCategoriesAsync();

        }


        private async void ButtonUpdate_Clicked(object sender, EventArgs e)
        {
            if (LvList.SelectedItem != null)
            {
                CategoryAppoinment selectedCategory = LvList.SelectedItem as CategoryAppoinment;

                GlobalObjects.MyLocalCategory = selectedCategory;
                //await DisplayAlert("Alert", $"The value of 's' is {nombre}", "OK");
                await Navigation.PushAsync(new UpdateCategoryPage());

            }
            else
            {
                // Display a message to the user indicating that no item is selected
                await DisplayAlert("Error", "Please select a category to update.", "OK");
            }
        }

        private async void ButtonCreate_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCategoryAppointment());
        }
    }
}