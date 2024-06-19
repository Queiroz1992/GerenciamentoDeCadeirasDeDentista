using GerenDeCadeiraDeDentista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenDeCadeiraDeDentista.Domain.Interfaces
{
    public interface ICadeiraDentistaRepository
    {
        Task<IEnumerable<CadeiraDentista>> GetAllAsync();
        Task<CadeiraDentista> GetByIdAsync(int id);
        Task CreateAsync(CadeiraDentista cadeiraDentista);
        Task UpdateAsync(CadeiraDentista cadeiraDentista);
        Task DeleteAsync(int id);
    }
}
