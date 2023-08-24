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
    public partial class UpdatePasswordPage : ContentPage
    {
        UserViewModel viewModel;
        public UpdatePasswordPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (ValidateFields())
            {


                try
                {
                    GlobalObjects.MyLocalUser.Password = TxtNewPassword.Text.Trim();


                    var answer = await DisplayAlert("???", "Are you sure to continue updating the password?", "Yes", "No");

                    if (answer)
                    {
                        bool R = await viewModel.UpdateUserPassword(GlobalObjects.MyLocalUser);

                        if (R)
                        {
                            await DisplayAlert(":)", "User Updated", "OK!");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert(":(", "Something went wrong!", "OK!");
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

        private bool ValidateFields()
        {
            bool R = false;
            if (TxtOldPassword != null && !string.IsNullOrEmpty(TxtOldPassword.Text.Trim()) &&
                TxtNewPassword.Text != null && !string.IsNullOrEmpty(TxtNewPassword.Text.Trim()) &&
                TxtConfirmPassword.Text != null && !string.IsNullOrEmpty(TxtConfirmPassword.Text.Trim()) &&
                TxtOldPassword.Text == GlobalObjects.MyLocalUser.Password &&
                TxtNewPassword.Text == TxtConfirmPassword.Text)
            {
                R = true;

            }
            else
            {
                if (TxtOldPassword.Text != GlobalObjects.MyLocalUser.Password)
                {
                    DisplayAlert("Validation Failed", "The old password is incorrect", "OK");
                    TxtOldPassword.Focus();
                    return false;
                }

                if (TxtOldPassword.Text == null || string.IsNullOrEmpty(TxtOldPassword.Text.Trim()))
                {
                    DisplayAlert("Validation Failed", "The old password is requeired", "OK");
                    TxtOldPassword.Focus();
                    return false;
                }

                if (TxtNewPassword.Text == null || string.IsNullOrEmpty(TxtNewPassword.Text.Trim()))
                {
                    DisplayAlert("Validation Failed", "The new password is requeired", "OK");
                    TxtNewPassword.Focus();
                    return false;
                }
                if (TxtConfirmPassword.Text == null || string.IsNullOrEmpty(TxtConfirmPassword.Text.Trim()))
                {
                    DisplayAlert("Validation Failed", "The Confirm Password is requeired", "OK");
                    TxtConfirmPassword.Focus();
                    return false;
                }
                if (TxtNewPassword.Text != TxtConfirmPassword.Text)
                {
                    DisplayAlert("Validation Failed", "The confirm password doesn't match with the new password", "OK");
                    TxtConfirmPassword.Focus();
                    return false;
                }

            }
            return R;

        }
    }
}