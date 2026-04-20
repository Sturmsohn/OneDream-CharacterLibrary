using System.ComponentModel.DataAnnotations;

namespace CharacterLibrary.Models
{
    /// <summary>
    /// A tag that can be applied to any number of characters.
    /// Tag names are unique and capped at 25 characters.
    /// </summary>
    public class Tag
    {
        public int Id { get; set; }

        [Required, MaxLength(25)]
        public string Name { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public List<CharacterTag> CharacterTags { get; set; } = new();
    }
}
