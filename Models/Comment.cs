using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace BlogBackend.Models
{
    /// <summary>
    /// The comment document.
    /// </summary>
    public class Comment
    {
        internal Comment()
        {
            Id = ObjectId.GenerateNewId().ToString();
            Created = DateTime.Now;
        }

        /// <summary>
        /// Id of the comment.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [SwaggerSchema(ReadOnly = true)]
        public string? Id { get; set; }

        /// <summary>
        /// The content in the comment.
        /// </summary>
        [Required]
        public string? Content { get; set; }

        /// <summary>
        /// Id of the author.
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Author { get; set; }

        /// <summary>
        /// The date that the comment was created.
        /// </summary>
        public DateTime? Created { get; private set; }
    }
}
