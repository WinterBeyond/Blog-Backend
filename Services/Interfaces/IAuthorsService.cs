using BlogBackend.Models;

namespace BlogBackend.Services.Interfaces
{
    /// <summary>
    /// The service that manages <see cref="Author"/>s.
    /// </summary>
    public interface IAuthorsService
    {
        /// <summary>
        /// Get list of all <see cref="Author"/>s.
        /// </summary>
        Task<IEnumerable<Author>> GetAuthors();

        /// <summary>
        /// Get a specific <see cref="Author"/>.
        /// </summary>
        /// <param name="id">Id of author.</param>
        Task<Author?> GetAuthor(string id);

        /// <summary>
        /// Create a new <see cref="Author"/>.
        /// </summary>
        /// <param name="newAuthor">Author object.</param>
        Task CreateAuthor(Author newAuthor);

        /// <summary>
        /// Delete a <see cref="Author"/>.
        /// </summary>
        /// <param name="id">Id of the author.</param>
        Task DeleteAuthor(string id);
    }
}
