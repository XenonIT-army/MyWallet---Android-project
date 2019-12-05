using MyWalletProject.Infrastructure;
using MyWalletProject.Interface;
using MyWalletProject.Model;
using MyWalletProject.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyWalletProject.ViewModel
{
    public class MainViewModel : Notifier
    {
        public IService<PaymentCategories> paymentService;
        public IService<History> historyService;
        ObservableCollection<PaymentCategories> payments = new ObservableCollection<PaymentCategories>();
        ObservableCollection<PaymentCategories> editPayments = new ObservableCollection<PaymentCategories>();
        History historyPayments = new History();
        Сalculations categories = new Сalculations();
        public string _addSum;
        public bool visible = false;
        public bool isEnabled = true;
        public string allPercent;
        public string allMonney;
        public PaymentCategories takeOff;
        public string takeOffSum;
        public string nameCategory = "";

        public MainViewModel(IService<PaymentCategories> paymentService, IService<History> historyService)
        {
            this.paymentService = paymentService;
            this.historyService = historyService;
            GetDate();
            OpenBoxCommand = new Command(() => OpenAddBox());
            AddMonney = new Command(() => { MonneyAdd(); });
            OpenEditCategorysBox = new Command(() => { OpenEditBox(); });
            SaveProcentCommand = new Command(() => { SaveProcent(); AllMonney = categories.GetAllMonney(payments); CloseBox(); });
            CloseBoxMesage = new Command(() => { CloseBox(); Visible = false; TakeOffSum = null; AddSum = null; IsEnabled = true; });
            EditCategorys = new Command(() => { AllPercent = "100"; EditPayments = categories.ResetCategorys(EditPayments); CloseBox(); });
            OpenSaveBoxCommand = new Command(() =>{ AllPercentVisible();OpenSaveBox(); });
            OpenTakeOffBoxCommand = new Command(() => { OpenTakeOffBox(); });
            TakeOffCategoryCommand = new Command(() => { TakeOffCategory(); AllMonney = categories.GetAllMonney(payments); });
            DeleteCategoryCommand = new Command(() => { DeleteCategory(); });
            OpenAddCategoryCommand = new Command(() => { OpenAddCategory(); });
            AddCategoryCommand = new Command(() => { AddCategory(); CloseBox(); });
        }

        #region methods

        private void AllPercentVisible()
        {
            AllPercent = categories.RefreshCategorys(EditPayments).ToString();
            if (AllPercent != "0")
            {
                Visible = true;
                IsEnabled = false;
            }
        }

        private void MonneyAdd()
        {
            if (AddSum == "")
                AddSum = "0";

            if (Convert.ToInt32(AllMonney) + Convert.ToInt32(AddSum) >= 0)
            {
                AllMonney = (Convert.ToInt32(AllMonney) + Convert.ToInt32(AddSum)).ToString();
                Payments = categories.RefreshBalance(payments, AddSum);
                AddSum = null;

                foreach (var res in Payments)
                {
                    paymentService.Delete(res);
                    paymentService.Create(res);
                }
                paymentService.Save();

                Visible = false;
                CloseBox();
            }
            else { Visible = true; }
        }

        private void OpenAddBox()
        {
            PopupNavigation.Instance.PushAsync(new PopupView(this));
        }

        private async void GetDate()
        {
            Payments = (await paymentService.GetAll()).ToObservableCollection();
            EditPayments = (await paymentService.GetAll()).ToObservableCollection();
            AllPercent = (100 - categories.GetPercent(payments)).ToString();
            AllMonney = categories.GetAllMonney(payments);

        }

        private void SaveProcent()
        {
            foreach (var i in editPayments)
            {
                foreach (var res in payments)
                {
                    if (i.Name == res.Name)
                    {
                        res.Balance = i.Balance;
                        res.Percent = i.Percent;
                    }
                }
            }
            foreach (var res in Payments)
            {
                paymentService.Delete(res);
                paymentService.Save();
            }

            foreach (var res in Payments)
            {
                paymentService.Create(res);

            }
            paymentService.Save();
        }

        private void OpenTakeOffBox()
        {
            PopupNavigation.Instance.PushAsync(new TakeOffSumCategory(this));
        }

        private void OpenAddCategory()
        {
            PopupNavigation.Instance.PushAsync(new AddCategory(this));
        }

        private async void AddCategory()
        {
            PaymentCategories add = new PaymentCategories();
            add.Name = NameCategory;

            add.Balance = "0";
            add.Percent = "0";
            Payments.Add(add);
            EditPayments.Add(add);

            await paymentService.Create(add);
            await paymentService.Save();
            GetDate();
            NameCategory = "";
        }
        private void OpenSaveBox()
        {
            PopupNavigation.Instance.PushAsync(new SaveProces(this));
        }
        private async void DeleteCategory()
        {
            await paymentService.Delete(TakeOff);
            await paymentService.Save();
            GetDate();
        }

        private void OpenEditBox()
        {
            PopupNavigation.Instance.PushAsync(new EditCategorysBox(this));
        }

        private async void TakeOffCategory()
        {
            if (TakeOffSum == null)
                TakeOffSum = "0";
            int takeSum = Convert.ToInt32(TakeOffSum);

            int sum = (Convert.ToInt32(TakeOff.Balance) - takeSum);
            if (takeSum >= 0)
            {
                Visible = false;
                TakeOff.Balance = sum.ToString();
                foreach (var res in payments)
                {
                    if (res.Name == TakeOff.Name)
                    {
                        res.Balance = TakeOff.Balance;
                        await paymentService.Delete(res);
                        await paymentService.Save();
                        await paymentService.Create(res);
                        await paymentService.Save();
                        AddHisstory();
                        await historyService.Create(historyPayments);
                        await historyService.Save();
                    }
                }
                TakeOffSum = null;
                CloseBox();

            }
            else
            {
                Visible = true;
            }
        }
        private void CloseBox()
        {
            PopupNavigation.Instance.PopAsync();
        }

        private void AddHisstory()
        {
            historyPayments.Name = TakeOff.Name;
            historyPayments.Sum = TakeOffSum;
            historyPayments.Date = DateTime.Now;
        }
        #endregion


        #region properties
        public ObservableCollection<PaymentCategories> Payments
        {
            get => payments;
            set
            {
                if (value != payments)
                {
                    payments = value;

                    Notify();
                }

            }
        }

        public ObservableCollection<PaymentCategories> EditPayments
        {
            get => editPayments;
            set
            {
                if (value != editPayments)
                {
                    editPayments = value;

                    Notify();
                }

            }
        }

        public PaymentCategories TakeOff
        {
            get => takeOff;
            set
            {
                if (value != takeOff)
                {
                    takeOff = value;
                    foreach (var res in payments)
                    {
                        if (res.Name == takeOff.Name)
                            res.IsVisible = true;
                        else
                        {
                            res.IsVisible = false;
                        }
                    }
                    Notify();
                }
            }
        }

        public string AddSum
        {
            get => _addSum;
            set
            {
                if (value != _addSum)
                {
                    _addSum = value;
                    Notify();
                }

            }
        }

        public bool Visible
        {
            get => visible;
            set
            {

                visible = value;
                Notify();

            }
        }

        public bool IsEnabled
        {
            get => isEnabled;
            set
            {

                isEnabled = value;
                Notify();

            }
        }

        public string AllPercent
        {
            get => allPercent;
            set
            {
                if (value != allPercent)
                {
                    allPercent = value;

                    Notify();
                }



            }
        }

        public string AllMonney
        {
            get => allMonney;
            set
            {
                if (value != allMonney)
                {
                    allMonney = value;
                    Notify();
                }
            }
        }

        public string TakeOffSum
        {
            get => takeOffSum;
            set
            {
                if (value != takeOffSum)
                {
                    takeOffSum = value;
                    Notify();
                }
            }
        }

        public string NameCategory
        {
            get => nameCategory;
            set
            {
                if (value != nameCategory)
                {
                    nameCategory = value;
                    Notify();
                }
            }
        }
        #endregion


        #region commands
        public ICommand OpenBoxCommand { private set; get; }
        public ICommand OpenEditCategorysBox { private set; get; }

        public ICommand SaveProcentCommand { private set; get; }
        public ICommand OpenTakeOffBoxCommand { private set; get; }
        public ICommand AddMonney { private set; get; }

        public ICommand CloseBoxMesage { private set; get; }

        public ICommand AddPercent { private set; get; }

        public ICommand EditCategorys { private set; get; }

        public ICommand OpenSaveBoxCommand { private set; get; }

        public ICommand CloseSaveBoxCommand { private set; get; }

        public ICommand TakeOffCategoryCommand { private set; get; }

        public ICommand DeleteCategoryCommand { private set; get; }

        public ICommand OpenAddCategoryCommand { private set; get; }

        public ICommand AddCategoryCommand { private set; get; }

        #endregion


    }
}
