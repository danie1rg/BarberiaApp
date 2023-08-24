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
    public partial class UpdateCategoryPage : ContentPage
    {
        CategoryAppointmentViewModel viewModel;
        public UpdateCategoryPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CategoryAppointmentViewModel();

            LoadCategoryInfo();

        }

        private void LoadCategoryInfo()
        {
            TxtDescription.Text = GlobalObjects.MyLocalCategory.Description.ToString();

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
                    DisplayAlert("Validation Failed", "The description is requeired", "OK");
                    TxtDescription.Focus();
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
                    GlobalObjects.MyLocalCategory.Description= TxtDescription.Text.Trim();
                    

                    var answer = await DisplayAlert("???", "Are you sure to continue updating category info?", "Yes", "No");

                    if (answer)
                    {
                        bool R = await viewModel.UpdateCategory(GlobalObjects.MyLocalCategory);

                        if (R)
                        {
                            await DisplayAlert(":(", $"Something went wrong!", "OK!");
                            await Navigation.PopAsync();
                            
                        }
                        else
                        {
                            await DisplayAlert(":)", "Category Updated", "OK!");
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