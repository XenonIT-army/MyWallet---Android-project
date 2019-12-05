using MyWalletProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyWalletProject.Model
{
    public class PaymentCategories : Notifier
    {
        public int Id { get; set; }

        public string name;
        public string Name
        {
            get => name;
            set
            {
                if (value != name)
                {
                    name = value;
                    Notify();
                }

            }
        }
        public string balance;
        public string Balance
        {
            get => balance;
            set
            {
                if (value != balance)
                {
                    balance = value;
                    Notify();
                }

            }
        }
        public string percent;
        public string Percent
        {
            get => percent;
            set
            {
                if (value != percent)
                {
                    percent = value;
                    Notify();
                }

            }
        }

        public bool isVisible = false;
        public bool IsVisible
        {
            get => isVisible;
            set
            {
                if (value != isVisible)
                {
                    isVisible = value;
                    Notify();
                }

            }
        }

       
        

    }
}
