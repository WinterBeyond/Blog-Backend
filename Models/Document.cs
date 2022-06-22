using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;

namespace BlogBackend.Models
{
    /// <summary>
    /// Abstract document containg id.
    /// </summary>
    public abstract class Document
    {
        /// <summary>
        /// The id of the document.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [SwaggerSchema(ReadOnly = true)]
        public string? Id { get; set; }
    }

}
