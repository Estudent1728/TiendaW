using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ZapatoRepository : IZapatoRepository
    {
        private readonly AppDbContext _context;

        public ZapatoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Zapato zapato)
        {
            await _context.Zapatos.AddAsync(zapato);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var z = await _context.Zapatos.FindAsync(id);
            if (z != null)
            {
                _context.Zapatos.Remove(z);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Zapato>> GetAllAsync()
        {
            return await _context.Zapatos.AsNoTracking().ToListAsync();
        }

        public async Task<Zapato?> GetByIdAsync(int id)
        {
            return await _context.Zapatos.FindAsync(id);
        }

        public async Task UpdateAsync(Zapato zapato)
        {
            _context.Zapatos.Update(zapato);
            await _context.SaveChangesAsync();
        }
    }
}