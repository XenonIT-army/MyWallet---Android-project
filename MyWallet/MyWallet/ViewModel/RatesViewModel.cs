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
        private bool isVisible = false;
        private bool isRefresh = false;
        public RatesViewModel()
        {
            GetRates();
            RefreshDateCommand = new Command(() => { IsRefresh = true; GetRates(); });
        }

        #region commands
        public ICommand RefreshDateCommand { private set; get; }
        #endregion

        #region methods
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
        #endregion

        #region properties
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

        public bool IsVisible
        {
            get => isVisible;
            set
            {
                isVisible = value;
                Notify();
            }
        }

        public bool IsRefresh
        {
            get => isRefresh;
            set
            {
                isRefresh = value;
                Notify();
            }
        }
        #endregion
       
        
    }
}
