using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyWalletProject.Droid
{
    [Activity(Label = "MyWalletProject", Icon = "@mipmap/ic_launcher", Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    class SplashActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {


            base.OnCreate(savedInstanceState);

            this.StartActivity(typeof(MainActivity));
        }
    }
}