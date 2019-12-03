using MyWallet.ApiModel;
using MyWallet.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
        }
        private async void GetRates()
        {
            RatesApi = (await wm.GetRatesPrivatbank()).ToObservableCollection();
            RatesApiMonobank=(await wm.GetRatesMonobank()).ToObservableCollection();
        }

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
    }
}
