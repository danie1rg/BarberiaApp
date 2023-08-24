using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberiaApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Acr.UserDialogs;


namespace BarberiaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppLoginPage : ContentPage
    {

        UserViewModel viewModel;

        public AppLoginPage()
        {
            InitializeComponent();
            this.BindingContext = viewModel =  new UserViewModel();
        }

        private void SwShowPassword_Toggled(object sender, ToggledEventArgs e)
        {
            if (SwShowPassword.IsToggled)
            {
                TxtPassword.IsPassword = false;
            }
            else
            {
                TxtPassword.IsPassword = true;
            }
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            if (TxtUserName.Text != null && !string.IsNullOrEmpty(TxtUserName.Text.Trim()) &&
               TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                try
                {
                    //UserDialogs.Instance.ShowLoading("Loading");
                    UserDialogs.Instance.ShowLoading("Loading...");
                    

                    string username = TxtUserName.Text.Trim();
                    string password = TxtPassword.Text.Trim();

                    bool R = await viewModel.UserAccessValidation(username, password);

                    if (R)
                    {


                       GlobalObjects.MyLocalUser = await viewModel.GetUserDataAsync(TxtUserName.Text.Trim());

                        await Navigation.PushAsync(new MainPage());
                        return;
                    }
                    else
                    {

                        await DisplayAlert("User Access Denied", "Username or Password are incorrect", "OK");
                        return;
                    }


                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    UserDialogs.Instance.HideLoading();
                    TxtPassword.Text = null;
                }


            }
            else
            {
                await DisplayAlert("Data required", "Username and Password are required...", "OK");
                return;
            }
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        
    }
}