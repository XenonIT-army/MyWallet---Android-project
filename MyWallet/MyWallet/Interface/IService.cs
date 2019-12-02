using System;
using System.Collections.Generic;
using System.Text;

namespace MyWallet.Interface
{
    public interface IService<TEntityDto>
    {
        IEnumerable<TEntityDto> GetAll();
        TEntityDto Get(int id);

        void UpdateRange(IEnumerable<TEntityDto> dto);
        TEntityDto Create(TEntityDto dto);
        void Update(TEntityDto dto);
        void Delete(TEntityDto dto);
        void Save();
    }
}
