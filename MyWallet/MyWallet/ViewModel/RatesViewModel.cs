using MyWallet.ApiModel;
using MyWallet.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyWallet.ViewModel
{
    public class RatesViewModel : Notifier
    {

        RatesManager wm = new RatesManager();
        ObservableCollection<RatesPrivatBank> ratesApi = new ObservableCollection<RatesPrivatBank>();
        ObservableCollection<RatesMonobank> ratesApiMonobank = new ObservableCollection<RatesMonobank>();
        
        public RatesViewModel()
        {
            GetRates();
            RefreshDateCommand = new Command(() => { IsRefresh = true; GetRates(); });
        }
        private async void GetRates()
        {
            try
            {
                IsVisible = false;
                RatesApi = (await wm.GetRatesPrivatbank()).ToObservableCollection();
                RatesApiMonobank = (await wm.GetRatesMonobank()).ToObservableCollection();
                IsRefresh = false;
            }
            catch
            {
                RatesApi = null;
                RatesApiMonobank = null;
                IsVisible = true;
                IsRefresh = false;
            }
        }
        public ICommand RefreshDateCommand { private set; get; }

        public ObservableCollection<RatesPrivatBank> RatesApi
        {
            get => ratesApi;
            set
            {
                ratesApi = value;
                Notify();
            }
        }
        public ObservableCollection<RatesMonobank> RatesApiMonobank
        {
            get => ratesApiMonobank;
            set
            {
                ratesApiMonobank = value;
                Notify();
            }
        }

        private bool isVisible = false;
        public bool IsVisible
        {
            get => isVisible;
            set
            {
                isVisible = value;
                Notify();
            }
        }

        private bool isRefresh = false;
        public bool IsRefresh
        {
            get => isRefresh;
            set
            {
                isRefresh = value;
                Notify();
            }
        }
    }
}
