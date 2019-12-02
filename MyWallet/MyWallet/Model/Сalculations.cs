using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyWallet.Model
{
    class Сalculations
    {
        public ObservableCollection<PaymentCategories> GetPayments()
        {
            return new ObservableCollection<PaymentCategories>
           {
               new PaymentCategories {name="Products", balance="2000",percent="20"},
                //new PaymentCategories {name="Entertainment", balance="1000",percent="10",Id=1 },
                 new PaymentCategories {name="Clothes and shoes", balance="2000",percent="20" },
                  new PaymentCategories {name="Payment for services", balance="1000",percent="10" },
                   new PaymentCategories {name="utilities payments", balance="2000",percent="20" },
                    new PaymentCategories {name="pets", balance="500",percent="5" },
                     new PaymentCategories {name="vacation", balance="1000",percent="10"},
                      new PaymentCategories {name="other purchases", balance="0",percent="0"},
                       new PaymentCategories {name="transport", balance="500",percent="5"}

           };
        }

        public int GetPercent()
        {
            int allPercent = 0;
            var payments = GetPayments();
            foreach (var i in payments)
            {
                allPercent += Convert.ToInt32(i.percent);
            }
            return allPercent;
        }

        public int RefreshCategorys(ObservableCollection<PaymentCategories> payments)
        {
            int sum = 100;


            foreach (var i in payments)
            {
                sum -= Convert.ToInt32(i.percent);
            }
            return sum;

        }
        public ObservableCollection<PaymentCategories> ResetCategorys(ObservableCollection<PaymentCategories> payments)
        {
            foreach (var i in payments)
            {
                i.Percent = "0";
                i.Balance = "0";
            }
            return payments;
        }
        public string GetAllMonney(ObservableCollection<PaymentCategories> payments)
        {
            int count = 0;
            foreach (var i in payments)
            {
                count += Convert.ToInt32(i.Balance);
            }
            return count.ToString();
        }

        public ObservableCollection<PaymentCategories> RefreshBalance(ObservableCollection<PaymentCategories> payments, string addSum)
        {
            if (addSum != null)
            {
                int value = Convert.ToInt32(addSum);

                foreach (var i in payments)
                {
                    i.Balance = (Convert.ToInt32(i.Balance) + (((value * Convert.ToInt32(i.Percent)) / 100))).ToString();
                }
            }
            return payments;
        }
    }
}
