using GerenDeCadeiraDeDentista.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenDeCadeiraDeDentista.Application.interfaces
{
    public interface IServicoDeCadeiraDentista
    {
        Task<IEnumerable<CadeiraDentistaDTO>> GetAllAsync();
        Task<CadeiraDentistaDTO> GetByIdAsync(int id);
        Task CreateAsync(CadeiraDentistaDTO cadeiraDentistaDto);
        Task UpdateAsync(CadeiraDentistaDTO cadeiraDentistaDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<AlocacaoAutomaticaDTO>> AlocarCadeiras(DateTime inicio, DateTime fim, int encaixes);
    }
}
