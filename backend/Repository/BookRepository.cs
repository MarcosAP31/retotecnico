using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _db;

        public BookRepository(AppDbContext db) => _db = db;

        public async Task<IEnumerable<Book>> GetAllAsync(string? search = null)
        {
            var query = _db.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(b => EF.Functions.Like(b.Title, $"%{search}%") ||
                                         EF.Functions.Like(b.Author, $"%{search}%"));
            }

            return await query.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _db.Books.FindAsync(id);
        }

        public async Task<Book> CreateAsync(Book book)
        {
            _db.Books.Add(book);
            await _db.SaveChangesAsync();
            return book;
        }

        public async Task UpdateAsync(Book book)
        {
            _db.Books.Update(book);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
        }
    }
}
