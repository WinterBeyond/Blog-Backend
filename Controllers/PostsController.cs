using BlogBackend.Models;
using BlogBackend.Services.Interfaces;
using BlogBackend.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BlogBackend.Controllers
{
    /// <summary>
    /// The posts API controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;

        public PostsController(IPostsService postsService) =>
            _postsService = postsService;

        /// <summary>
        /// Get list of all <see cref="Post"/>s.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<Post>> GetPosts() =>
            await _postsService.GetPosts();

        /// <summary>
        /// Get a specific <see cref="Post"/>.
        /// </summary>
        /// <param name="id">Id of post.</param>
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Post>> GetPost(string id)
        {
            if (!HexUtil.IsHex(id))
                return BadRequest();

            Post? post = await _postsService.GetPost(id);

            if (post == null)
                return NotFound();

            return post;
        }

        /// <summary>
        /// Create a new <see cref="Post"/>.
        /// </summary>
        /// <param name="newPost">Post object.</param>
        [HttpPost]
        public async Task<IActionResult> CreatePost(Post newPost)
        {
            if (!HexUtil.IsHex(newPost.Author))
                return BadRequest();

            await _postsService.CreatePost(newPost);

            return CreatedAtAction(nameof(GetPost), new { id = newPost.Id }, newPost);
        }

        /// <summary>
        /// Update a <see cref="Post"/>.
        /// </summary>
        /// <param name="id">The post id.</param>
        /// <param name="updatedPost">Post object.</param>
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdatePost(string id, Post updatedPost)
        {
            if (!HexUtil.IsHex(id))
                return BadRequest();

            Post? post = await _postsService.GetPost(id);

            if (post == null)
                return NotFound();

            updatedPost.Id = post.Id;
            updatedPost.Created = post.Created;
            updatedPost.Updated = DateTime.Now;

            await _postsService.UpdatePost(id, updatedPost);

            return Ok();
        }

        /// <summary>
        /// Delete a <see cref="Post"/>.
        /// </summary>
        /// <param name="id">The post id.</param>
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeletePost(string id)
        {
            if (!HexUtil.IsHex(id))
                return BadRequest();

            Post? post = await _postsService.GetPost(id);

            if (post == null)
                return NotFound();

            await _postsService.DeletePost(id);

            return Ok();
        }
    }
}
