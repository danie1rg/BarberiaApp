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
    public partial class SignUpPage : ContentPage
    {
        UserViewModel viewModel;
        UserRoleViewModel roleViewModel;
        public SignUpPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();
            BindingContext = roleViewModel = new UserRoleViewModel();
            LoadUserRolesAsync();
        }

        private async void LoadUserRolesAsync()
        {
            PkrUserRole.ItemsSource = await roleViewModel.GetUserRolesAsync();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            UserRole SelectedUserRole = PkrUserRole.SelectedItem as UserRole;



            bool R = await viewModel.AddUserAsync(TxtEmail.Text.Trim(),
                                                  TxtPassword.Text.Trim(),
                                                  TxtName.Text.Trim(),
                                                  TxtBackUpEmail.Text.Trim(),
                                                  TxtPhoneNumber.Text.Trim(),
                                                  TxtAddress.Text.Trim(),
                                                  SelectedUserRole.UserRoleId);

            if (R)
            {
                await DisplayAlert(":)", "User created Ok!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Something went wrong...", "OK");
            }

        }


        

    }
}