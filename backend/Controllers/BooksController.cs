using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;
        public BooksController(IBookService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReadDto>>> Get([FromQuery] string? search)
        {
            var list = await _service.GetAllAsync(search);
            return Ok(list);
        }

        [HttpGet("{id:int}", Name = "GetBookById")]
        public async Task<ActionResult<BookReadDto>> GetById(int id)
        {
            var book = await _service.GetByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtRoute("GetBookById", new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _service.UpdateAsync(id, dto); // NO lo asignas
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

    }
}
