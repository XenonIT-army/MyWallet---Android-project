using AutoMapper;
using MyWallet.Interface;
using MyWallet.Model;
using SqlliteApp.Standard.Entities;
using SqlliteApp.Standard.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Service
{
    class HitoryService : IService<History>
    {
        private PaymentUnitOfWork uow;
        IMapper mapper;

        public HitoryService(PaymentUnitOfWork uow)
        {
            this.uow = uow;
            var config = new MapperConfiguration(cfg =>
            {
                cfg
                .CreateMap<PurchaseHistory, History>()
                .ReverseMap();
            });
            mapper = config.CreateMapper();
        }

        public Task<bool> UpdateRange(IEnumerable<History> dto)
        {
            return Task.Run(() =>
            {
                try
                {
                    var entity = mapper.Map<IEnumerable<PurchaseHistory>>(dto);
                    uow.PurchaseHistory.UpdateRange(entity);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public Task<History> Create(History dto)
        {
            return Task.Run(() =>
            {
                var entity = mapper.Map<PurchaseHistory>(dto);
                var newEntity = uow.PurchaseHistory.Create(entity);
                return mapper.Map<History>(newEntity);

            });
          
        }

        public Task<bool> Delete(History dto)
        {
            return Task.Run(() =>
            {
                try
                {
                    var entity = uow.PurchaseHistory.Get(dto.Id);
                    uow.PurchaseHistory.Delete(entity);
                    return true;
                }
                catch
                {
                    return false;
                }
               
            });
        }

        public Task<History> Get(int id)
        {
            return Task.Run(() =>
            {
                var entity = uow.PurchaseHistory.Get(id);
                return mapper.Map<History>(entity);
            });
        }

        public Task<IEnumerable<History>> GetAll()
        {
            return Task.Run(() =>
            {
                var res = uow.PurchaseHistory
                .GetAll()
                .ToList()
                .Select(entity => mapper.Map<History>(entity));
                return res;
            });
        }

        public Task<bool> Save()
        {
            return Task.Run(() =>
            {
                try
                {
                    uow.PurchaseHistory.Save();
                    uow.Save();
                    return true;
                }
                catch
                {
                    return false;
                }
               
            });
               
        }

        public Task<bool> Update(History dto)
        {
            return Task.Run(() =>
            {
                try
                {
                    var entity = mapper.Map<PurchaseHistory>(dto);
                    uow.PurchaseHistory.Update(entity);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
               
        }
    }
}
