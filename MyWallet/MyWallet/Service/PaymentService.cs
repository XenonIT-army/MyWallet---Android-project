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


        public Task<bool> UpdateRange(IEnumerable<PaymentCategories> dto)
        {
            return Task.Run(() =>
            {
                try
                {
                    var entity = mapper.Map<IEnumerable<Payment>>(dto);
                    uow.PaymentRepository.UpdateRange(entity);

                    return true;
                }
                catch
                {
                    return false;
                }
            });
               
        }

        public Task<PaymentCategories> Create(PaymentCategories dto)
        {
            return Task.Run(() =>
            {

                var entity = mapper.Map<Payment>(dto);
                var newEntity = uow.PaymentRepository.Create(entity);
                return mapper.Map<PaymentCategories>(newEntity);

            });
        }

        public Task<bool> Delete(PaymentCategories dto)
        {
            return Task.Run(() =>
            {
                try
                {
                    var entity = uow.PaymentRepository.Get(dto.Id);
                    uow.PaymentRepository.Delete(entity);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public Task<PaymentCategories> Get(int id)
        {
            return Task.Run(() =>
            {
                var entity = uow.PaymentRepository.Get(id);
                return mapper.Map<PaymentCategories>(entity);
            });
        }

        public Task<IEnumerable<PaymentCategories>> GetAll()
        {
            return Task.Run(() =>
            {
                var res = uow.PaymentRepository
                .GetAll()
                .ToList()
                .Select(entity => mapper.Map<PaymentCategories>(entity));
                return res;
            });
        }

        public Task<bool> Save()
        {
            return Task.Run(() =>
            {
                try
                {
                    uow.PaymentRepository.Save();
                    uow.Save();
                    return true;
                }
                catch
                {
                    return false;
                }
               
            });
               
        }

        public Task<bool> Update(PaymentCategories dto)
        {
            return Task.Run(() =>
            {
                try
                {
                    var entity = mapper.Map<Payment>(dto);
                    uow.PaymentRepository.Update(entity);
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
