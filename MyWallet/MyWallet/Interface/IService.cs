using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Interface
{
    public interface IService<TEntityDto>
    {
        Task<IEnumerable<TEntityDto>> GetAll();
        Task<TEntityDto> Get(int id);

        Task<bool> UpdateRange(IEnumerable<TEntityDto> dto);
        Task<TEntityDto> Create(TEntityDto dto);
        Task<bool> Update(TEntityDto dto);
        Task<bool> Delete(TEntityDto dto);
        Task<bool> Save();
    }
}
