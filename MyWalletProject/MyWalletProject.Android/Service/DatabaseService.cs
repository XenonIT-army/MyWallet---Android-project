using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyWalletProject.Droid.Services;
using SqlliteApp.Standard.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace MyWalletProject.Droid.Services
{

    public class DatabaseService : IDatabaseService
    {
        public string GetDatabasePath()
        {
            return Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                AppSettings.DatabaseName);
        }
    }
}