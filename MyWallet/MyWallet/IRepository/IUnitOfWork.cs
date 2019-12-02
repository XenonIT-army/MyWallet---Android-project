using System;
using System.Collections.Generic;
using System.Text;

namespace MyWallet.IRepository
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
