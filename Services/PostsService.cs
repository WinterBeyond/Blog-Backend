using BlogBackend.Database.Interfaces;
using BlogBackend.Models;
using BlogBackend.Services.Interfaces;

namespace BlogBackend.Services
{
    /// <inheritdoc/>
    public class PostsService : IPostsService
    {
        private readonly IPostRepository _postRepository;

        /// <summary>
        /// The service that manages <see cref="Post"/>s and <see cref="Comment"/>s.
        /// </summary>
        /// <param name="postRepository">The post repository.</param>
        public PostsService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Post>> GetPosts() => await _postRepository.GetAll();

        /// <inheritdoc/>
        public async Task<Post?> GetPost(string id) => await _postRepository.Get(id);

        /// <inheritdoc/>
        public async Task CreatePost(Post newPost) => await _postRepository.Insert(newPost);

        /// <inheritdoc/>
        public async Task UpdatePost(string id, Post updatedPost) => await _postRepository.Update(id, updatedPost);

        /// <inheritdoc/>
        public async Task DeletePost(string id) => await _postRepository.Delete(id);

        /// <inheritdoc/>
        public async Task AddComment(string postId, Comment newComment) => await _postRepository.AddComment(postId, newComment);

        /// <inheritdoc/>
        public async Task DeleteComment(string postId, string id) => await _postRepository.DeleteComment(postId, id);
    }
}
