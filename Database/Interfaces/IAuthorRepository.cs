using BlogBackend.Models;

namespace BlogBackend.Database.Interfaces
{
    /// <summary>
    /// Interface for author related database operations.
    /// </summary>
    public interface IAuthorRepository : ICrudRepository<Author>
    {
    }
}
