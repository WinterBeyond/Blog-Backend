using BlogBackend.Database.Interfaces;
using BlogBackend.Models;
using MongoDB.Driver;

namespace BlogBackend.Database
{
    /// <summary>
    /// Implementation of author related operations.
    /// </summary>
    public class AuthorRepository : MongoRepository<Author>, IAuthorRepository
    {
        /// <summary>
        /// The name of the collection.
        /// </summary>
        public static readonly string COLLECTION = "authors";

        internal AuthorRepository(IMongoCollection<Author> authors) : base(authors)
        {
        }
    }
}
