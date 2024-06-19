using GerenDeCadeiraDeDentista.Domain.Entities;
using GerenDeCadeiraDeDentista.Domain.Interfaces;
using GerenDeCadeiraDeDentista.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenDeCadeiraDeDentista.Infrastructure.Repositories
{
    public class CadeiraDentistaRepository : ICadeiraDentistaRepository
    {
        private readonly CadeiraDentistaContext _context;

        public CadeiraDentistaRepository(CadeiraDentistaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CadeiraDentista>> GetAllAsync()
        {
            return await _context.CadeiraDentistas.ToListAsync();
        }

        public async Task<CadeiraDentista> GetByIdAsync(int id)
        {
            return await _context.CadeiraDentistas.FindAsync(id);
        }

        public async Task CreateAsync(CadeiraDentista dentistaCadeira)
        {
            await _context.CadeiraDentistas.AddAsync(dentistaCadeira);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CadeiraDentista dentistaCadeira)
        {
            _context.CadeiraDentistas.Update(dentistaCadeira);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dentistaCadeira = await _context.CadeiraDentistas.FindAsync(id);
            _context.CadeiraDentistas.Remove(dentistaCadeira);
            await _context.SaveChangesAsync();
        }
    }
}
