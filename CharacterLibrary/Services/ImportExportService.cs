using System.Text.Json;
using System.Text.Json.Serialization;
using CharacterLibrary.Data;
using CharacterLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CharacterLibrary.Services
{
    /// <summary>
    /// Plain DTO used for JSON serialization. Kept separate from the entity so the
    /// export format isn't coupled to EF internals (navigation properties, Id, etc.).
    /// Tags are exported as a simple list of tag names.
    /// </summary>
    public class CharacterExportDto
    {
        public string Name { get; set; } = string.Empty;
        public bool IsRealistic { get; set; }
        public bool IsAnime { get; set; }
        public long Age { get; set; }

        public string? HairStyle { get; set; }
        public string? BodyType { get; set; }
        public string? SkinTone { get; set; }
        public string? BreastSize { get; set; }
        public string? Ethnicity { get; set; }
        public string? ButtSize { get; set; }
        public string? EyeColor { get; set; }
        public string? HairColor { get; set; }
        public string? CustomPhysicalDetails { get; set; }
        public string? CustomFaceDetails { get; set; }

        public string? Occupation { get; set; }
        public string? Relationship { get; set; }
        public string? Hobby { get; set; }
        public string? Fetish { get; set; }
        public string? PublicDescription { get; set; }
        public string? Greeting { get; set; }
        public string? FirstReplySuggestion { get; set; }
        public string? Scenario { get; set; }
        public string? AdditionalPersonalityDetails { get; set; }
        public string? ExtraDetails { get; set; }

        public string? ImagePath { get; set; }       // Realistic portrait
        public string? AnimeImagePath { get; set; }  // Anime portrait

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public List<string> Tags { get; set; } = new();
    }

    public record ImportResult(int Added, int Updated);

    public static class ImportExportService
    {
        private static readonly JsonSerializerOptions JsonOpts = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };

        // ---------- Export ----------

        public static void ExportAll(string path)
        {
            using var db = new CharacterDbContext();
            var dtos = LoadAll(db);
            File.WriteAllText(path, JsonSerializer.Serialize(dtos, JsonOpts));
        }

        public static void ExportOne(int characterId, string path)
        {
            using var db = new CharacterDbContext();
            var dto = LoadAll(db).FirstOrDefault(d => GetId(db, d) == characterId);
            if (dto == null) throw new InvalidOperationException($"Character {characterId} not found.");
            File.WriteAllText(path, JsonSerializer.Serialize(dto, JsonOpts));
        }

        private static int GetId(CharacterDbContext db, CharacterExportDto dto)
        {
            return db.Characters
                .Where(c => c.Name == dto.Name)
                .Select(c => c.Id)
                .FirstOrDefault();
        }

        private static List<CharacterExportDto> LoadAll(CharacterDbContext db)
        {
            return db.Characters
                .AsNoTracking()
                .Include(c => c.CharacterTags).ThenInclude(ct => ct.Tag)
                .OrderBy(c => c.Name)
                .Select(c => new CharacterExportDto
                {
                    Name = c.Name,
                    IsRealistic = c.IsRealistic,
                    IsAnime = c.IsAnime,
                    Age = c.Age,
                    HairStyle = c.HairStyle,
                    BodyType = c.BodyType,
                    SkinTone = c.SkinTone,
                    BreastSize = c.BreastSize,
                    Ethnicity = c.Ethnicity,
                    ButtSize = c.ButtSize,
                    EyeColor = c.EyeColor,
                    HairColor = c.HairColor,
                    CustomPhysicalDetails = c.CustomPhysicalDetails,
                    CustomFaceDetails = c.CustomFaceDetails,
                    Occupation = c.Occupation,
                    Relationship = c.Relationship,
                    Hobby = c.Hobby,
                    Fetish = c.Fetish,
                    PublicDescription = c.PublicDescription,
                    Greeting = c.Greeting,
                    FirstReplySuggestion = c.FirstReplySuggestion,
                    Scenario = c.Scenario,
                    AdditionalPersonalityDetails = c.AdditionalPersonalityDetails,
                    ExtraDetails = c.ExtraDetails,
                    ImagePath = c.ImagePath,
                    AnimeImagePath = c.AnimeImagePath,
                    CreatedAt = c.CreatedAt,
                    ModifiedAt = c.ModifiedAt,
                    Tags = c.CharacterTags.Select(ct => ct.Tag.Name).ToList()
                })
                .ToList();
        }

        // ---------- Import ----------

        /// <summary>
        /// Imports from a JSON file. File may contain a single object or an array.
        /// Matching is by Name (unique key). If a character with the same Name already
        /// exists it will be updated in place; otherwise a new one is created. Tag list
        /// is replaced wholesale with the imported set.
        /// </summary>
        public static ImportResult Import(string path)
        {
            var text = File.ReadAllText(path);
            var list = ParseFlexible(text);

            using var db = new CharacterDbContext();
            int added = 0, updated = 0;

            foreach (var dto in list)
            {
                if (string.IsNullOrWhiteSpace(dto.Name)) continue;

                var existing = db.Characters
                    .Include(c => c.CharacterTags)
                    .FirstOrDefault(c => c.Name == dto.Name);

                if (existing == null)
                {
                    existing = new Character { Name = dto.Name };
                    db.Characters.Add(existing);
                    added++;
                }
                else
                {
                    updated++;
                }

                existing.IsRealistic = dto.IsRealistic;
                existing.IsAnime = dto.IsAnime;
                existing.Age = dto.Age;
                existing.HairStyle = dto.HairStyle;
                existing.BodyType = dto.BodyType;
                existing.SkinTone = dto.SkinTone;
                existing.BreastSize = dto.BreastSize;
                existing.Ethnicity = dto.Ethnicity;
                existing.ButtSize = dto.ButtSize;
                existing.EyeColor = dto.EyeColor;
                existing.HairColor = dto.HairColor;
                existing.CustomPhysicalDetails = dto.CustomPhysicalDetails;
                existing.CustomFaceDetails = dto.CustomFaceDetails;
                existing.Occupation = dto.Occupation;
                existing.Relationship = dto.Relationship;
                existing.Hobby = dto.Hobby;
                existing.Fetish = dto.Fetish;
                existing.PublicDescription = dto.PublicDescription;
                existing.Greeting = dto.Greeting;
                existing.FirstReplySuggestion = dto.FirstReplySuggestion;
                existing.Scenario = dto.Scenario;
                existing.AdditionalPersonalityDetails = dto.AdditionalPersonalityDetails;
                existing.ExtraDetails = dto.ExtraDetails;
                existing.ImagePath = dto.ImagePath;
                existing.AnimeImagePath = dto.AnimeImagePath;

                db.SaveChanges(); // commit so we have an Id for new characters

                // Replace tag set
                if (existing.CharacterTags.Count > 0)
                {
                    db.CharacterTags.RemoveRange(existing.CharacterTags);
                    db.SaveChanges();
                }

                var desired = (dto.Tags ?? new())
                    .Where(n => !string.IsNullOrWhiteSpace(n))
                    .Select(n => n.Trim())
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .Take(20) // enforce 20-tag cap on import as well
                    .ToList();

                foreach (var tagName in desired)
                {
                    var tag = db.Tags.FirstOrDefault(t => t.Name == tagName);
                    if (tag == null)
                    {
                        tag = new Tag { Name = tagName };
                        db.Tags.Add(tag);
                        db.SaveChanges();
                    }
                    db.CharacterTags.Add(new CharacterTag
                    {
                        CharacterId = existing.Id,
                        TagId = tag.Id
                    });
                }
                db.SaveChanges();
            }

            return new ImportResult(added, updated);
        }

        private static List<CharacterExportDto> ParseFlexible(string json)
        {
            // Accept either a JSON array or a single object
            var trimmed = json.TrimStart();
            if (trimmed.StartsWith("["))
            {
                return JsonSerializer.Deserialize<List<CharacterExportDto>>(json, JsonOpts) ?? new();
            }
            var single = JsonSerializer.Deserialize<CharacterExportDto>(json, JsonOpts);
            return single == null ? new() : new List<CharacterExportDto> { single };
        }
    }
}
