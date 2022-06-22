using BlogBackend.Database.Interfaces;
using BlogBackend.Models;
using MongoDB.Driver;

namespace BlogBackend.Database
{
    /// <summary>
    /// Implementation of post related operations.
    /// </summary>
    public class PostRepository : MongoRepository<Post>, IPostRepository
    {
        /// <summary>
        /// The name of the collection.
        /// </summary>
        public static readonly string COLLECTION = "posts";

        internal PostRepository(IMongoCollection<Post> posts) : base(posts)
        {
        }

        /// <inheritdoc/>
        public async Task AddComment(string postId, Comment newComment)
        {
            Post? post = await Get(postId);
            if (post == null)
                return;

            List<Comment> newComments = post.Comments.ToList();
            newComments.Add(newComment);
            post.Comments = newComments;

            await _collection.ReplaceOneAsync(doc => doc.Id!.Equals(postId), post);
        }

        /// <inheritdoc/>
        public async Task DeleteComment(string postId, string id)
        {
            Post? post = await Get(postId);
            if (post == null)
                return;

            List<Comment> newComments = post.Comments.ToList();
            newComments.RemoveAll(comment => comment.Id!.Equals(id));
            post.Comments = newComments;

            await _collection.ReplaceOneAsync(doc => doc.Id!.Equals(postId), post);
        }
    }
}
