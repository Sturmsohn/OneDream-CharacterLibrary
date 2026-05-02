using System.ComponentModel.DataAnnotations;

namespace CharacterLibrary.Models
{
    /// <summary>
    /// A single character in the library. All 1:1 fields are flattened here
    /// (Appearance + Personality + Other). Tags are a separate many-to-many
    /// relationship through CharacterTag.
    ///
    /// Natural unique key: Name (configured in DbContext).
    /// A character can be flagged as Realistic, Anime, both, or neither.
    /// </summary>
    public class Character
    {
        // --- Identity ---
        public int Id { get; set; }

        // --- Basic ---
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public bool IsRealistic { get; set; }
        public bool IsAnime { get; set; }

        // long (Int64) instead of int so "absurd" ages (ancient beings, eldritch,
        // etc.) always fit. Regular int maxes out around 2.1 billion which is
        // usually enough, but long costs nothing extra in SQLite.
        public long Age { get; set; }

        // --- Appearance ---
        [MaxLength(250)]   public string? HairStyle { get; set; }
        [MaxLength(25)]    public string? BodyType { get; set; }
        [MaxLength(25)]    public string? SkinTone { get; set; }
        [MaxLength(25)]    public string? BreastSize { get; set; }
        [MaxLength(50)]    public string? Ethnicity { get; set; }
        [MaxLength(50)]    public string? ButtSize { get; set; }
        [MaxLength(100)]   public string? EyeColor { get; set; }
        [MaxLength(100)]   public string? HairColor { get; set; }
        [MaxLength(2000)]  public string? CustomPhysicalDetails { get; set; }
        [MaxLength(2000)]  public string? CustomFaceDetails { get; set; }

        // --- Personality ---
        [MaxLength(4000)]  public string? Occupation { get; set; }
        [MaxLength(4000)]  public string? Relationship { get; set; }
        [MaxLength(4000)]  public string? Hobby { get; set; }
        [MaxLength(4000)]  public string? Fetish { get; set; }
        [MaxLength(10000)] public string? PublicDescription { get; set; }
        [MaxLength(10000)] public string? Greeting { get; set; }
        [MaxLength(100)]   public string? FirstReplySuggestion { get; set; }
        [MaxLength(50000)] public string? Scenario { get; set; }
        [MaxLength(50000)] public string? AdditionalPersonalityDetails { get; set; }
        [MaxLength(100000)] public string? ExtraDetails { get; set; }

        // --- Media ---
        // Relative paths (e.g. "Images/abc123.png") into the app's Images folder.
        [MaxLength(500)]   public string? ImagePath { get; set; }       // Realistic portrait
        [MaxLength(500)]   public string? AnimeImagePath { get; set; }  // Anime portrait

        // --- Timestamps ---
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        // --- Navigation ---
        public List<CharacterTag> CharacterTags { get; set; } = new();
    }
}
