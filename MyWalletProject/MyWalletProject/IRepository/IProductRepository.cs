using MyWalletProject.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletProject.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<PaymentCategories>> GetPaymentAsync();

        Task<PaymentCategories> GetPaymentByIdAsync(int id);

        Task<bool> AddProductAsync(PaymentCategories payment);
        Task<bool> UpdateProductAsync(PaymentCategories payment);
        Task<bool> RemoceProductAsync(int id);
    }
}
