using System;
using System.Collections.Generic;
using System.Text;

namespace MyWalletProject.IRepository
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
