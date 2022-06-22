using BlogBackend.Database.Interfaces;
using BlogBackend.Models;
using MongoDB.Driver;

namespace BlogBackend.Database
{
    /// <summary>
    /// CRUD implementation of a repository.
    /// </summary>
    /// <typeparam name="T">The object type.</typeparam>
    public abstract class MongoRepository<T> : ICrudRepository<T> where T : Document
    {
        /// <summary>
        /// The collection with all documents.
        /// </summary>
        protected readonly IMongoCollection<T> _collection;

        internal MongoRepository(IMongoCollection<T> collection)
        {
            _collection = collection;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> GetAll() => await _collection.Find(_ => true).ToListAsync();

        /// <inheritdoc/>
        public async Task<T?> Get(string id)
        {
            return await _collection.Find(doc => doc.Id!.Equals(id)).FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task Insert(T newDoc) => await _collection.InsertOneAsync(newDoc);

        /// <inheritdoc/>
        public async Task Update(string id, T updatedDoc)
        {
            await _collection.ReplaceOneAsync(doc => doc.Id!.Equals(id), updatedDoc);
        }

        /// <inheritdoc/>
        public async Task Delete(string id) => await _collection.DeleteOneAsync(doc => doc.Id!.Equals(id));
    }

}
