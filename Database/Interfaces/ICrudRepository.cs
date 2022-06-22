using BlogBackend.Models;

namespace BlogBackend.Database.Interfaces
{
    /// <summary>
    /// CRUD interface for database operations.
    /// </summary>
    /// <typeparam name="T">The object type.</typeparam>
    public interface ICrudRepository<T> where T : Document
    {
        /// <summary>
        /// Get all documents from collection.
        /// </summary>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Get one document from collection.
        /// </summary>
        /// <param name="id">The id of the document.</param>
        Task<T?> Get(string id);

        /// <summary>
        /// Insert new document into collection.
        /// </summary>
        /// <param name="newDoc">The new document.</param>
        Task Insert(T newDoc);

        /// <summary>
        /// Update document in collection.
        /// </summary>
        /// <param name="id">The id of the document.</param>
        /// <param name="updatedDoc">The updated document.</param>
        Task Update(string id, T updatedDoc);

        /// <summary>
        /// Delete document from collection.
        /// </summary>
        /// <param name="id">The id of the document.</param>
        Task Delete(string id);
    }
}
