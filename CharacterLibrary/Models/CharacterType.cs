namespace CharacterLibrary.Models
{
    /// <summary>
    /// The two allowed character types. Stored in the database as a string
    /// ("Realistic" / "Anime") for readability when inspecting the raw DB.
    /// </summary>
    public enum CharacterType
    {
        Realistic = 0,
        Anime = 1
    }
}
