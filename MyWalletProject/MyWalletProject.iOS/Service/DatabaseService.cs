using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using MyWalletProject;
using MyWalletProject.iOS.Service;
using SqlliteApp.Standard.Interface;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace MyWalletProject.iOS.Service
{
    public class DatabaseService : IDatabaseService
    {
        public string GetDatabasePath()
        {
            return Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments),
                "..",
                "Library",
                AppSettings.DatabaseName);
        }
    }
}