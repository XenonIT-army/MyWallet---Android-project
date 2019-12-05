using MyWalletProject.Moduls;
using MyWalletProject.Views;
using Ninject;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyWalletProject
{
    public partial class App : Application
    {
        public static StandardKernel Container { get; set; }
        public App()
        {
            InitializeComponent();

            var settings = new Ninject.NinjectSettings() { LoadExtensions = false };
            var kernel = new StandardKernel(settings, new PaymentNinjectModule());

            
            App.Container = kernel;
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
