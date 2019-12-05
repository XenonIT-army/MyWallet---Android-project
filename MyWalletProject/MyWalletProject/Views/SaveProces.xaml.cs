﻿using MyWalletProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyWalletProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaveProces 
    {
        public SaveProces(MainViewModel main)
        {
            InitializeComponent();
            BindingContext = main;
        }
    }
}