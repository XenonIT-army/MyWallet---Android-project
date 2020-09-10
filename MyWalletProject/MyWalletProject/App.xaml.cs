using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
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
            AppCenter.Start("android=10338f9c-5292-4d3c-b47e-6bb7548fcbf4;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes));
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
