using MyWallet.Infrastructure;
using MyWallet.Interface;
using MyWallet.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyWallet.ViewModel
{
    class HistoryViewModel : Notifier
    {
        public IService<History> historyService;
        ObservableCollection<History> histories = new ObservableCollection<History>();
        private bool isRefresh = false;
        public HistoryViewModel(IService<History> historyService)
        {
            this.historyService = historyService;
            Histories = historyService.GetAll().ToObservableCollection();

            RefreshData = new Command(() => { Histories = historyService.GetAll().ToObservableCollection(); IsRefresh = false; });
            RemoveHistory = new Command(() => { ClearAll(); Histories = null; });
        }

        private void ClearAll()
        {
            foreach (var res in Histories)
            { 
                historyService.Delete(res);
                historyService.Save();
            }
        }
        public ICommand RefreshData { private set; get; }

        public ICommand RemoveHistory { private set; get; }

        public ObservableCollection<History> Histories
        {
            get => histories;
            set
            {
                
                    histories = value;
                    Notify();

            }
        }

        public bool IsRefresh
        {
            get => isRefresh;
            set
            {
                if (value != isRefresh)
                {
                    isRefresh = value;

                    Notify();
                }

            }

        }
    }
}
