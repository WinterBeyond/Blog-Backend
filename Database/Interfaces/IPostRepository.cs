using BlogBackend.Models;

namespace BlogBackend.Database.Interfaces
{
    /// <summary>
    /// Interface for post related database operations.
    /// </summary>
    public interface IPostRepository : ICrudRepository<Post>
    {
        /// <summary>
        /// Add a <see cref="Comment"/>.
        /// </summary>
        /// <param name="postId">The post id.</param>
        /// <param name="newComment">Comment object.</param>
        Task AddComment(string postId, Comment newComment);

        /// <summary>
        /// Delete a <see cref="Comment"/>.
        /// </summary>
        /// <param name="postId">The post id.</param>
        /// <param name="id">The comment id.</param>
        Task DeleteComment(string postId, string id);
    }
}
