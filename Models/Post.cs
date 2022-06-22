using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BlogBackend.Models
{
    /// <summary>
    /// The post document.
    /// </summary>
    public class Post : Document
    {
        internal Post()
        {
            Created = DateTime.Now;
            Comments = new List<Comment>();
        }

        /// <summary>
        /// The title of the post.
        /// </summary>
        [Required]
        public string? Title { get; set; }

        /// <summary>
        /// The category of the post.
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        /// The content in the post.
        /// </summary>
        [Required]
        public string? Content { get; set; }

        /// <summary>
        /// Id of the author.
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Author { get; set; }

        /// <summary>
        /// List of comments on the post.
        /// </summary>
        public IEnumerable<Comment> Comments { get; internal set; }

        /// <summary>
        /// The date that the post was created.
        /// </summary>
        public DateTime? Created { get; internal set; }

        /// <summary>
        /// The date that the post was updated.
        /// </summary>
        public DateTime? Updated { get; internal set; }
    }
}
