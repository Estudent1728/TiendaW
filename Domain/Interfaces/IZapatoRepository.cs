using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IZapatoRepository
    {
        Task<IEnumerable<Zapato>> GetAllAsync();
        Task<Zapato?> GetByIdAsync(int id);
        Task AddAsync(Zapato zapato);
        Task UpdateAsync(Zapato zapato);
        Task DeleteAsync(int id);
    }
}