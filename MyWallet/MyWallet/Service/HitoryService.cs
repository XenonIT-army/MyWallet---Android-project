using AutoMapper;
using MyWallet.Interface;
using MyWallet.Model;
using SqlliteApp.Standard.Entities;
using SqlliteApp.Standard.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void UpdateRange(IEnumerable<History> dto)
        {
            var entity = mapper.Map<IEnumerable<PurchaseHistory>>(dto);
            uow.PurchaseHistory.UpdateRange(entity);
        }

        public History Create(History dto)
        {
            var entity = mapper.Map<PurchaseHistory>(dto);
            var newEntity = uow.PurchaseHistory.Create(entity);
            return mapper.Map<History>(newEntity);
        }

        public void Delete(History dto)
        {
            var entity = uow.PurchaseHistory.Get(dto.Id);
            uow.PurchaseHistory.Delete(entity);
        }

        public History Get(int id)
        {
            var entity = uow.PurchaseHistory.Get(id);
            return mapper.Map<History>(entity);
        }

        public IEnumerable<History> GetAll()
        {
            var res = uow.PurchaseHistory
                 .GetAll()
                 .ToList()
                 .Select(entity => mapper.Map<History>(entity));
            return res;
        }

        public void Save()
        {
            uow.PurchaseHistory.Save();
            uow.Save();
        }

        public void Update(History dto)
        {
            var entity = mapper.Map<PurchaseHistory>(dto);
            uow.PurchaseHistory.Update(entity);
        }
    }
}
