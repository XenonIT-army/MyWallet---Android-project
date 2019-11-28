using MyWallet.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyWallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : CarouselPage
    {
        public Page1()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
            var pages = Children.GetEnumerator();
            pages.MoveNext();
            pages.MoveNext();
            CurrentPage = pages.Current;
            
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            
        }
    }
}