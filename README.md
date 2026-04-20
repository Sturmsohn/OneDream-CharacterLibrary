# Character Library

A personal-use Windows desktop app for storing and maintaining a library of
AI chat characters. Fields are modeled after the specific site layout (not
SillyTavern / TavernAI character-card format), and all data is stored locally
in a single SQLite database file.

## Stack

- **.NET 8** / C# 12
- **WinForms** (UI)
- **Entity Framework Core 8** + **SQLite** (storage)
- **System.Text.Json** (import/export)

## Build & Run

1. Install the **.NET 8 SDK** (https://dotnet.microsoft.com/download/dotnet/8.0)
   — Visual Studio 2022 17.8+ already includes it.
2. Open `CharacterLibrary.sln` in Visual Studio 2022.
3. Press **F5** (Debug) or **Ctrl+F5** (Run without debugging).

On first run the app will:
- create `CharacterLibrary.db` (SQLite) next to the executable
- create an `Images/` folder next to the executable

Both live in `bin\Debug\net8.0-windows\` during development, or wherever you
publish the app. Back up the entire app folder (or just `CharacterLibrary.db`
+ `Images/`) to preserve your data.

## Project Layout

```
CharacterLibrary/
├─ Program.cs                          Entry point; EnsureCreated() + Application.Run
├─ Models/
│  ├─ Character.cs                     All 1:1 fields (Appearance + Personality + Other)
│  ├─ Tag.cs                           25-char unique tag names
│  ├─ CharacterTag.cs                  M:N join table, own identity PK
│  └─ CharacterType.cs                 enum { Realistic, Anime }
├─ Data/
│  └─ CharacterDbContext.cs            EF Core DbContext, unique indexes, auto timestamps
├─ Services/
│  ├─ ImageService.cs                  Copies picked images into ./Images/
│  └─ ImportExportService.cs           JSON in/out
└─ Forms/
   ├─ MainForm.cs                      Character list, search, all actions
   ├─ CharacterEditForm.cs             Tabbed editor for a single character
   └─ TagManagerForm.cs                Add/rename/delete tags, see usage counts
```

## Schema Notes

- `Character` has a **unique index on (Name, CharacterType)** so you can't have
  two Realistic "Aria"s but you *can* have one Realistic Aria and one Anime Aria.
- `CharacterType` is stored as a readable **string** in the DB (`"Realistic"` /
  `"Anime"`) rather than an int, so raw DB inspection is friendlier.
- `Age` is a `long` (Int64) to comfortably accommodate absurd ages.
- `ImagePath` stores a **relative path** like `Images/<guid>.png`. The actual
  file lives under the app's `Images/` folder.
- Tags are capped at **25 characters** per tag name, and each character can
  have at most **20 tags** (validated on save and on import).
- `CreatedAt` / `ModifiedAt` are stamped automatically in UTC by the DbContext
  on every SaveChanges.

## Features

- **Add / Edit / Duplicate / Delete** characters with a tabbed editor
  (Basic, Appearance, Personality, Scenario, Additional Personality, Extra Details)
- **Search** by name or public description (substring, case-insensitive)
- **Filter** by Character Type and/or Tag
- **Image picker** with preview (copies the file into `Images/` so the DB
  stays portable)
- **Tag manager** with usage counts; rename cascades automatically
- **JSON export** (all or one character) and **JSON import**
  (creates new or updates existing based on the Name + CharacterType key)

## Keyboard Shortcuts (main grid)

- **Enter** — edit selected character
- **Delete** — delete selected character (with confirmation)
- **Double-click** — edit row

## Switching to EF Core Migrations (optional)

This build uses `db.Database.EnsureCreated()` for first-run simplicity, which
is fine for personal use but doesn't support schema evolution. If you add or
change fields later and want a proper migration workflow:

```
dotnet tool install --global dotnet-ef          # once per machine
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Then replace `EnsureCreated()` in `Program.cs` with `db.Database.Migrate();`.
(You'll need to delete any existing `CharacterLibrary.db` first, since
EnsureCreated doesn't create the `__EFMigrationsHistory` table.)

## JSON Format

Export produces either a single object or an array of objects with this shape:

```json
{
  "Name": "Example",
  "CharacterType": "Realistic",
  "Age": 27,
  "HairStyle": "Long wavy",
  ...
  "Tags": ["tag1", "tag2"]
}
```

Import accepts either shape; existing characters (matched by Name +
CharacterType) are updated in place, tags are replaced wholesale. New tag
names found in the import are created automatically. The 20-tag cap is
enforced on import as well.
