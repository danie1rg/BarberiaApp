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
    public partial class UserManagementPage : ContentPage
    {

        UserViewModel viewModel;
        public UserManagementPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();

            LoadUserInfo();

        }

        private void LoadUserInfo()
        {
            TxtID.Text = GlobalObjects.MyLocalUser.UserId.ToString();
            TxtEmail.Text = GlobalObjects.MyLocalUser.Email;
            TxtName.Text = GlobalObjects.MyLocalUser.Name;
            TxtPhoneNumber.Text = GlobalObjects.MyLocalUser.PhoneNumber;
            TxtBackUpEmail.Text = GlobalObjects.MyLocalUser.BackUpEmail;
            TxtAddress.Text = GlobalObjects.MyLocalUser.Address;
        }

        private bool ValidateFields()
        {
            bool R = false;

            if (TxtName.Text != null && !string.IsNullOrEmpty(TxtName.Text.Trim()) &&
                TxtBackUpEmail.Text != null && !string.IsNullOrEmpty(TxtBackUpEmail.Text.Trim()) &&
                TxtPhoneNumber.Text != null && !string.IsNullOrEmpty(TxtPhoneNumber.Text.Trim()))
            {

                R = true;
            }
            else
            {
                if (TxtName.Text == null || string.IsNullOrEmpty(TxtName.Text.Trim()))
                {
                    DisplayAlert("Validation Failed!", "The Name is required", "OK");
                    TxtName.Focus();
                    return false;
                }

                if (TxtBackUpEmail.Text == null || string.IsNullOrEmpty(TxtBackUpEmail.Text.Trim()))
                {
                    DisplayAlert("Validation Failed!", "The Backup Email is required", "OK");
                    TxtBackUpEmail.Focus();
                    return false;
                }

                if (TxtPhoneNumber.Text == null || string.IsNullOrEmpty(TxtPhoneNumber.Text.Trim()))
                {
                    DisplayAlert("Validation Failed!", "The Phone Number is required", "OK");
                    TxtPhoneNumber.Focus();
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
                    GlobalObjects.MyLocalUser.Name = TxtName.Text.Trim();
                    GlobalObjects.MyLocalUser.BackUpEmail = TxtBackUpEmail.Text.Trim();
                    GlobalObjects.MyLocalUser.PhoneNumber = TxtPhoneNumber.Text.Trim();
                    GlobalObjects.MyLocalUser.Address = TxtAddress.Text.Trim();

                    var answer = await DisplayAlert("???", "Are you sure to continue updating user info?", "Yes", "No");

                    if (answer)
                    {
                        bool R = await viewModel.UpdateUser(GlobalObjects.MyLocalUser);

                        if (R)
                        {
                            await DisplayAlert(":)", "User Updated!!!", "OK");
                            await Navigation.PopAsync();
                            BtnEdit.IsVisible = true;
                        }
                        else
                        {
                            await DisplayAlert(":(", "Something went wrong...", "OK");
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

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void ButtonEdit_Clicked(object sender, EventArgs e)
        {
            TxtAddress.IsEnabled = true;
            TxtBackUpEmail.IsEnabled = true;
            TxtPhoneNumber.IsEnabled = true;
            TxtName.IsEnabled = true;
            BtnUpdate.IsVisible = true;
            BtnEdit.IsVisible = false;
            BtnUpdatePass.IsVisible = false;
            BtnUpdate.IsEnabled = true;

        }

        private async void BtnUpdatePass_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdatePasswordPage());
        }
    }
}