using BarberiaApp.Services;
using BarberiaApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarberiaApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new AppLoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
