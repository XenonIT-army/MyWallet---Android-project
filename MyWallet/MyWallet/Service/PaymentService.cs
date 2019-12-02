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
    class PaymentService : IService<PaymentCategories>
    {
        private PaymentUnitOfWork uow;
        IMapper mapper;


        public PaymentService(PaymentUnitOfWork uow)
        {
            this.uow = uow;
            var config = new MapperConfiguration(cfg =>
            {
                cfg
                .CreateMap<Payment, PaymentCategories>()
                .ReverseMap();
            });
            mapper = config.CreateMapper();
        }


        public void UpdateRange(IEnumerable<PaymentCategories> dto)
        {
                var entity = mapper.Map<IEnumerable<Payment>>(dto);
                uow.PaymentRepository.UpdateRange(entity);
        }

        public PaymentCategories Create(PaymentCategories dto)
        {
            var entity = mapper.Map<Payment>(dto);
            var newEntity = uow.PaymentRepository.Create(entity);
            return mapper.Map<PaymentCategories>(newEntity);
        }

        public void Delete(PaymentCategories dto)
        {
            var entity = uow.PaymentRepository.Get(dto.Id);
            uow.PaymentRepository.Delete(entity);
        }

        public PaymentCategories Get(int id)
        {
            var entity = uow.PaymentRepository.Get(id);
            return mapper.Map<PaymentCategories>(entity);
        }

        public IEnumerable<PaymentCategories> GetAll()
        {
            var res = uow.PaymentRepository
                 .GetAll()
                 .ToList()
                 .Select(entity => mapper.Map<PaymentCategories>(entity));
            return res;
        }

        public void Save()
        {
            uow.PaymentRepository.Save();
            uow.Save();
        }

        public void Update(PaymentCategories dto)
        {
            var entity = mapper.Map<Payment>(dto);
            uow.PaymentRepository.Update(entity);
        }
    }
}
