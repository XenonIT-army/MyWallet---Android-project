using Microsoft.EntityFrameworkCore;
using SqlliteApp.Standard.Abstructions;
using SqlliteApp.Standard.Entities;
using SqlliteApp.Standard.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlliteApp.Standard.UnitOfWork
{
    public class PaymentUnitOfWork : BaseUnitOfWork
    {
        public IRepository<Payment> PaymentRepository { get; }

        public PaymentUnitOfWork(DbContext db,
                                 IRepository<Payment> paymentRepository) : base(db)
        {
            this.PaymentRepository = paymentRepository;
        }
    }
}
