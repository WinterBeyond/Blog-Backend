using System.ComponentModel.DataAnnotations;

namespace BlogBackend.Models
{
    /// <summary>
    /// The author document.
    /// </summary>
    public class Author : Document
    {
        internal Author()
        {
            Created = DateTime.Now;
        }

        /// <summary>
        /// The name of the author.
        /// </summary>
        [Required]
        public string? Name { get; set; }

        /// <summary>
        /// The date that the author was created.
        /// </summary>
        public DateTime? Created { get; internal set; }
    }
}
