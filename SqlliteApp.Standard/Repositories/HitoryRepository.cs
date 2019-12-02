using Microsoft.EntityFrameworkCore;
using MyWallet.Abstructions;
using SqlliteApp.Standard.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlliteApp.Standard.Repositories
{
   public class HitoryRepository : BaseRepository<PurchaseHistory>
    {
        public HitoryRepository(DbContext db) : base(db)
        {

        }

    }
}
