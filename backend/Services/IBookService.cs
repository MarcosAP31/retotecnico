using Backend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookReadDto>> GetAllAsync(string? search = null);
        Task<BookReadDto> GetByIdAsync(int id);
        Task<BookReadDto> CreateAsync(BookCreateDto dto);
        Task UpdateAsync(int id, BookCreateDto dto);
        Task DeleteAsync(int id);
    }
}
