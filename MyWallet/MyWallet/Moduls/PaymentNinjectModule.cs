using Microsoft.EntityFrameworkCore;
using MyWallet.Abstructions;
using MyWallet.Interface;
using MyWallet.Model;
using MyWallet.Service;
using Ninject.Modules;
using SqlliteApp.Standard.Context;
using SqlliteApp.Standard.Entities;
using SqlliteApp.Standard.Interface;
using SqlliteApp.Standard.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWallet.Moduls
{
    public class PaymentNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Payment>>().To<PaymentRepository>();
            Bind<IService<PaymentCategories>>().To<PaymentService>();

            Bind<IRepository<PurchaseHistory>>().To<HitoryRepository>();
            Bind<IService<History>>().To<HitoryService>();

            Bind<DbContext>().To<MobileContext>();
        }
    }
}
