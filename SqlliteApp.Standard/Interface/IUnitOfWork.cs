using System;
using System.Collections.Generic;
using System.Text;

namespace SqlliteApp.Standard.Interface
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
