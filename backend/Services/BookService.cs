using Backend.DTOs;
using Backend.Models;
using Backend.Repository;
using Backend.Exceptions;  // <-- importa tus excepciones
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;

        public BookService(IBookRepository repo) => _repo = repo;

        public async Task<IEnumerable<BookReadDto>> GetAllAsync(string? search = null)
        {
            var books = await _repo.GetAllAsync(search);

            return books.Select(b => new BookReadDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Year = b.Year,
                Publisher = b.Publisher,
                Pages = b.Pages,
                Category = b.Category,
                Isbn = b.Isbn
            });
        }

        public async Task<BookReadDto> GetByIdAsync(int id)
        {
            var b = await _repo.GetByIdAsync(id);

            if (b == null)
                throw new NotFoundException($"El libro con ID {id} no existe.");

            return new BookReadDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Year = b.Year,
                Publisher = b.Publisher,
                Pages = b.Pages,
                Category = b.Category,
                Isbn = b.Isbn
            };
        }

        public async Task<BookReadDto> CreateAsync(BookCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                throw new DomainValidationException("El título es obligatorio.");

            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Year = dto.Year,
                Publisher = dto.Publisher,
                Pages = dto.Pages,
                Category = dto.Category,
                Isbn = dto.Isbn
            };

            var created = await _repo.CreateAsync(book);

            return new BookReadDto
            {
                Id = created.Id,
                Title = created.Title,
                Author = created.Author,
                Year = created.Year,
                Publisher = created.Publisher,
                Pages = created.Pages,
                Category = created.Category,
                Isbn = created.Isbn
            };
        }

        public async Task UpdateAsync(int id, BookCreateDto dto)
        {
            var book = await _repo.GetByIdAsync(id);

            if (book == null)
                throw new NotFoundException($"No se puede actualizar. El libro {id} no existe.");

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.Year = dto.Year;
            book.Publisher = dto.Publisher;
            book.Pages = dto.Pages;
            book.Category = dto.Category;
            book.Isbn = dto.Isbn;

            await _repo.UpdateAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _repo.GetByIdAsync(id);

            if (book == null)
                throw new NotFoundException($"No se puede eliminar. El libro {id} no existe.");

            await _repo.DeleteAsync(book);
        }

       
    }
}
