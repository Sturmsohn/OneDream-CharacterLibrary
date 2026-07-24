using System.ComponentModel;
using CharacterLibrary.Data;
using CharacterLibrary.Models;
using CharacterLibrary.Services;
using Microsoft.EntityFrameworkCore;

namespace CharacterLibrary.Forms
{
    public partial class MainForm : Form
    {
        // Filter values stored as strings for clarity
        private const string FilterAll = "All types";
        private const string FilterRealistic = "Realistic";
        private const string FilterAnime = "Anime";

        public MainForm()
        {
            InitializeComponent();

            _typeFilter.Items.Add(FilterAll);
            _typeFilter.Items.Add(FilterRealistic);
            _typeFilter.Items.Add(FilterAnime);
            _typeFilter.SelectedIndex = 0;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                LoadTagFilter();
                RefreshList();
            }
        }

        private void SearchBox_TextChanged(object? sender, EventArgs e) => RefreshList();
        private void TypeFilter_SelectedIndexChanged(object? sender, EventArgs e) => RefreshList();
        private void TagFilter_SelectedIndexChanged(object? sender, EventArgs e) => RefreshList();

        private void RefreshBtn_Click(object? sender, EventArgs e)
        {
            LoadTagFilter();
            RefreshList();
        }

        private void Grid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) EditSelected();
        }

        private void Grid_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) DeleteSelected();
            else if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; EditSelected(); }
        }

        private void AddNewBtn_Click(object? sender, EventArgs e) => AddNew();
        private void EditBtn_Click(object? sender, EventArgs e) => EditSelected();
        private void DuplicateBtn_Click(object? sender, EventArgs e) => DuplicateSelected();
        private void DeleteBtn_Click(object? sender, EventArgs e) => DeleteSelected();
        private void ManageTagsBtn_Click(object? sender, EventArgs e) => OpenTagManager();
        private void ExportAllBtn_Click(object? sender, EventArgs e) => ExportAll();
        private void ExportSelectedBtn_Click(object? sender, EventArgs e) => ExportSelected();
        private void ImportBtn_Click(object? sender, EventArgs e) => ImportJson();

        // ---------- Data loading ----------

        private class CharacterRow
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public bool IsRealistic { get; set; }
            public bool IsAnime { get; set; }
            public string TypeText => (IsRealistic, IsAnime) switch
            {
                (true,  true)  => "Realistic + Anime",
                (true,  false) => "Realistic",
                (false, true)  => "Anime",
                _              => "(none)"
            };
            public long Age { get; set; }
            public string AgeText => Age.ToString("N0");
            public string TagsText { get; set; } = "";
            public DateTime ModifiedAt { get; set; }
            public string ModifiedText => ModifiedAt.ToLocalTime().ToString("yyyy-MM-dd HH:mm");
        }

        private void LoadTagFilter()
        {
            var previous = _tagFilter.SelectedItem as string;

            _tagFilter.BeginUpdate();
            _tagFilter.Items.Clear();
            _tagFilter.Items.Add("All tags");

            using var db = new CharacterDbContext();
            foreach (var name in db.Tags.AsNoTracking().OrderBy(t => t.Name).Select(t => t.Name))
                _tagFilter.Items.Add(name);

            if (previous != null && _tagFilter.Items.Contains(previous))
                _tagFilter.SelectedItem = previous;
            else
                _tagFilter.SelectedIndex = 0;
            _tagFilter.EndUpdate();
        }

        private void RefreshList()
        {
            try
            {
                using var db = new CharacterDbContext();

                var query = db.Characters
                    .AsNoTracking()
                    .Include(c => c.CharacterTags).ThenInclude(ct => ct.Tag)
                    .AsQueryable();

                // Type filter
                var filterVal = _typeFilter.SelectedItem as string;
                if (filterVal == FilterRealistic)
                    query = query.Where(c => c.IsRealistic);
                else if (filterVal == FilterAnime)
                    query = query.Where(c => c.IsAnime);

                // Tag filter
                if (_tagFilter.SelectedIndex > 0)
                {
                    var tagName = _tagFilter.SelectedItem as string;
                    if (!string.IsNullOrEmpty(tagName))
                        query = query.Where(c => c.CharacterTags.Any(ct => ct.Tag.Name == tagName));
                }

                // Text search (name or public description)
                var term = _searchBox.Text.Trim();
                if (!string.IsNullOrEmpty(term))
                {
                    var like = $"%{term}%";
                    query = query.Where(c =>
                        EF.Functions.Like(c.Name, like) ||
                        (c.PublicDescription != null && EF.Functions.Like(c.PublicDescription, like)));
                }

                var rows = query
                    .OrderBy(c => c.Name)
                    .Select(c => new CharacterRow
                    {
                        Id = c.Id,
                        Name = c.Name,
                        IsRealistic = c.IsRealistic,
                        IsAnime = c.IsAnime,
                        Age = c.Age,
                        TagsText = string.Join(", ", c.CharacterTags.Select(ct => ct.Tag.Name)),
                        ModifiedAt = c.ModifiedAt
                    })
                    .ToList();

                _grid.DataSource = rows;
                _statusLabel.Text = $"{rows.Count} character(s)   —   DB: {Path.GetFileName(db.DbPath)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading characters:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? SelectedId()
        {
            if (_grid.SelectedRows.Count == 0) return null;
            var row = _grid.SelectedRows[0].DataBoundItem as CharacterRow;
            return row?.Id;
        }

        private string? SelectedName()
        {
            if (_grid.SelectedRows.Count == 0) return null;
            return (_grid.SelectedRows[0].DataBoundItem as CharacterRow)?.Name;
        }

        // ---------- Actions ----------

        private void AddNew()
        {
            using var form = new CharacterEditForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadTagFilter();
                RefreshList();
            }
        }

        private void EditSelected()
        {
            var id = SelectedId();
            if (id == null) return;
            using var form = new CharacterEditForm(id.Value);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadTagFilter();
                RefreshList();
            }
        }

        private void DuplicateSelected()
        {
            var id = SelectedId();
            if (id == null) return;

            using var db = new CharacterDbContext();
            var src = db.Characters
                .AsNoTracking()
                .Include(c => c.CharacterTags)
                .FirstOrDefault(c => c.Id == id.Value);
            if (src == null) return;

            // Find a non-colliding name: "<n> (Copy)", "<n> (Copy 2)", …
            string baseName = src.Name + " (Copy)";
            string candidate = baseName;
            int n = 2;
            while (db.Characters.Any(c => c.Name == candidate))
                candidate = $"{baseName} {n++}";

            var copy = new Character
            {
                Name = candidate,
                IsRealistic = src.IsRealistic,
                IsAnime = src.IsAnime,
                Age = src.Age,
                HairStyle = src.HairStyle,
                BodyType = src.BodyType,
                SkinTone = src.SkinTone,
                BreastSize = src.BreastSize,
                Ethnicity = src.Ethnicity,
                ButtSize = src.ButtSize,
                EyeColor = src.EyeColor,
                HairColor = src.HairColor,
                CustomPhysicalDetails = src.CustomPhysicalDetails,
                CustomFaceDetails = src.CustomFaceDetails,
                Occupation = src.Occupation,
                Relationship = src.Relationship,
                Hobby = src.Hobby,
                Fetish = src.Fetish,
                PublicDescription = src.PublicDescription,
                Greeting = src.Greeting,
                FirstReplySuggestion = src.FirstReplySuggestion,
                Scenario = src.Scenario,
                AdditionalPersonalityDetails = src.AdditionalPersonalityDetails,
                ExtraDetails = src.ExtraDetails,
                ImagePath = src.ImagePath,          // points to same image file; that's fine
                AnimeImagePath = src.AnimeImagePath  // same
            };
            db.Characters.Add(copy);
            db.SaveChanges();

            foreach (var ct in src.CharacterTags)
                db.CharacterTags.Add(new CharacterTag { CharacterId = copy.Id, TagId = ct.TagId });
            db.SaveChanges();

            RefreshList();
        }

        private void DeleteSelected()
        {
            var id = SelectedId();
            if (id == null) return;
            var name = SelectedName() ?? "this character";

            if (MessageBox.Show($"Delete \"{name}\"? This cannot be undone.", "Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            using var db = new CharacterDbContext();
            var c = db.Characters.Find(id.Value);
            if (c != null)
            {
                db.Characters.Remove(c);
                db.SaveChanges();
            }
            RefreshList();
        }

        private void OpenTagManager()
        {
            using var f = new TagManagerForm();
            f.ShowDialog(this);
            LoadTagFilter();
            RefreshList();
        }

        // ---------- Import / Export ----------

        private void ExportAll()
        {
            using var dlg = new SaveFileDialog
            {
                Title = "Export all characters",
                Filter = "JSON files|*.json",
                FileName = $"character-library-{DateTime.Now:yyyyMMdd-HHmm}.json"
            };
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                ImportExportService.ExportAll(dlg.FileName);
                MessageBox.Show($"Exported to:\n{dlg.FileName}", "Export complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportSelected()
        {
            var id = SelectedId();
            if (id == null) return;

            var name = SelectedName() ?? "character";
            var safe = string.Join("_", name.Split(Path.GetInvalidFileNameChars()));

            using var dlg = new SaveFileDialog
            {
                Title = "Export character",
                Filter = "JSON files|*.json",
                FileName = $"{safe}.json"
            };
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                ImportExportService.ExportOne(id.Value, dlg.FileName);
                MessageBox.Show($"Exported to:\n{dlg.FileName}", "Export complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportJson()
        {
            using var dlg = new OpenFileDialog
            {
                Title = "Import characters from JSON",
                Filter = "JSON files|*.json|All files|*.*"
            };
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                var result = ImportExportService.Import(dlg.FileName);
                MessageBox.Show(
                    $"Import complete.\n\nAdded: {result.Added}\nUpdated: {result.Updated}",
                    "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTagFilter();
                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Import failed:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
