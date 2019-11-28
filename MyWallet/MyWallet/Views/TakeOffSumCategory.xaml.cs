﻿using MyWallet.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyWallet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TakeOffSumCategory
    {
        public TakeOffSumCategory(MainViewModel main)
        {
            InitializeComponent();
            BindingContext = main;
        }
    }
}