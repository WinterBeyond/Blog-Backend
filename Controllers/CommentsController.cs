using BlogBackend.Models;
using BlogBackend.Services.Interfaces;
using BlogBackend.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BlogBackend.Controllers
{
    /// <summary>
    /// The comments API controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CommentsController : ControllerBase
    {
        private readonly IPostsService _postsService;

        public CommentsController(IPostsService postsService) =>
            _postsService = postsService;

        /// <summary>
        /// Add a <see cref="Comment"/>.
        /// </summary>
        /// <param name="postId">The post id.</param>
        /// <param name="newComment">Comment object.</param>
        [HttpPost("{postId:length(24)}")]
        public async Task<IActionResult> AddComment(string postId, Comment newComment)
        {
            if (!HexUtil.IsHex(postId) || !HexUtil.IsHex(newComment.Author))
                return BadRequest();

            Post? post = await _postsService.GetPost(postId);

            if (post == null)
                return NotFound();

            await _postsService.AddComment(postId, newComment);

            return Ok();
        }

        /// <summary>
        /// Delete a <see cref="Comment"/>.
        /// </summary>
        /// <param name="postId">The post id.</param>
        /// <param name="id">The comment id.</param>
        [HttpDelete("{postId:length(24)}/{id:length(24)}")]
        public async Task<IActionResult> DeleteComment(string postId, string id)
        {
            if (!HexUtil.IsHex(postId) || !HexUtil.IsHex(id))
                return BadRequest();

            Post? post = await _postsService.GetPost(postId);

            if (post == null)
                return NotFound();

            await _postsService.DeleteComment(postId, id);

            return Ok();
        }
    }
}
