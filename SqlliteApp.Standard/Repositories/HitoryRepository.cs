using Microsoft.EntityFrameworkCore;
using MyWalletProject.Abstructions;
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
