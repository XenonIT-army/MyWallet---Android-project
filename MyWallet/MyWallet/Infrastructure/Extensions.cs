using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyWallet.Infrastructure
{
    static class Extensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> obj)
        {
            return new ObservableCollection<T>(obj);
        }
    }
}
