using BlogBackend.Models;

namespace BlogBackend.Services.Interfaces
{
    /// <summary>
    /// The service that manages <see cref="Post"/>s and <see cref="Comment"/>s.
    /// </summary>
    public interface IPostsService
    {
        /// <summary>
        /// Get list of all <see cref="Post"/>s.
        /// </summary>
        Task<IEnumerable<Post>> GetPosts();

        /// <summary>
        /// Get a specific <see cref="Post"/>.
        /// </summary>
        /// <param name="id">Id of post.</param>
        Task<Post?> GetPost(string id);

        /// <summary>
        /// Create a new <see cref="Post"/>.
        /// </summary>
        /// <param name="newPost">Post object.</param>
        Task CreatePost(Post newPost);

        /// <summary>
        /// Update a <see cref="Post"/>.
        /// </summary>
        /// <param name="id">The post id.</param>
        /// <param name="updatedPost">Post object.</param>
        Task UpdatePost(string id, Post updatedPost);

        /// <summary>
        /// Delete a <see cref="Post"/>.
        /// </summary>
        /// <param name="id">The post id.</param>
        Task DeletePost(string id);

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
