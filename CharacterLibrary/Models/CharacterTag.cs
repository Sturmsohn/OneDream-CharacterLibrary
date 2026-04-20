namespace CharacterLibrary.Models
{
    /// <summary>
    /// Join table for the many-to-many relationship between Character and Tag.
    /// Given explicit integer identity PK per project convention; (CharacterId, TagId)
    /// is also a unique index so the same tag can't be added twice to a character.
    /// </summary>
    public class CharacterTag
    {
        public int Id { get; set; }

        public int CharacterId { get; set; }
        public int TagId { get; set; }

        public Character Character { get; set; } = null!;
        public Tag Tag { get; set; } = null!;
    }
}
