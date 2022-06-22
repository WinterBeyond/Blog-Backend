using BlogBackend.Models;
using BlogBackend.Services.Interfaces;
using BlogBackend.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BlogBackend.Controllers
{
    /// <summary>
    /// The authors API controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService) =>
            _authorsService = authorsService;

        /// <summary>
        /// Get list of all <see cref="Author"/>s.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<Author>> GetAuthors() =>
            await _authorsService.GetAuthors();

        /// <summary>
        /// Get a specific <see cref="Author"/>.
        /// </summary>
        /// <param name="id">Id of author.</param>
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Author>> GetAuthor(string id)
        {
            if (!HexUtil.IsHex(id))
                return BadRequest();

            Author? author = await _authorsService.GetAuthor(id);

            if (author == null)
                return NotFound();

            return author;
        }

        /// <summary>
        /// Create a new <see cref="Author"/>.
        /// </summary>
        /// <param name="newAuthor">Author object.</param>
        [HttpPost]
        public async Task<IActionResult> CreateAuthor(Author newAuthor)
        {
            await _authorsService.CreateAuthor(newAuthor);

            return CreatedAtAction(nameof(GetAuthor), new { id = newAuthor.Id }, newAuthor);
        }

        /// <summary>
        /// Delete a <see cref="Author"/>.
        /// </summary>
        /// <param name="id">Id of the author.</param>
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteAuthor(string id)
        {
            if (!HexUtil.IsHex(id))
                return BadRequest();

            Author? author = await _authorsService.GetAuthor(id);

            if (author == null)
                return NotFound();

            await _authorsService.DeleteAuthor(id);

            return Ok();
        }
    }
}
