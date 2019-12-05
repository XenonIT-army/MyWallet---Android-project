using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyWalletProject.Model
{
    class Сalculations
    {
        public int GetPercent(ObservableCollection<PaymentCategories> payments)
        {
            int allPercent = 0;
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
