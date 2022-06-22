using BlogBackend.Database.Interfaces;
using BlogBackend.Models;
using BlogBackend.Services.Interfaces;

namespace BlogBackend.Services
{
    /// <inheritdoc/>
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorRepository _authorRepository;

        /// <summary>
        /// The service that manages <see cref="Author"/>s.
        /// </summary>
        /// <param name="authorRepository">The author repository.</param>
        public AuthorsService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Author>> GetAuthors() => await _authorRepository.GetAll();

        /// <inheritdoc/>
        public async Task<Author?> GetAuthor(string id) => await _authorRepository.Get(id);

        /// <inheritdoc/>
        public async Task CreateAuthor(Author newAuthor) => await _authorRepository.Insert(newAuthor);

        /// <inheritdoc/>
        public async Task DeleteAuthor(string id) => await _authorRepository.Delete(id);
    }
}
