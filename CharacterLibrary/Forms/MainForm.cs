using CharacterLibrary.Data;
using CharacterLibrary.Models;
using CharacterLibrary.Services;
using Microsoft.EntityFrameworkCore;

namespace CharacterLibrary.Forms
{
    public class MainForm : Form
    {
        private readonly DataGridView _grid;
        private readonly TextBox _searchBox;
        private readonly ComboBox _typeFilter;
        private readonly ComboBox _tagFilter;
        private readonly StatusStrip _statusStrip;
        private readonly ToolStripStatusLabel _statusLabel;

        public MainForm()
        {
            Text = "Character Library";
            Width = 1150;
            Height = 700;
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(900, 500);

            // ---- Top filter bar ----
            var topPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 44,
                ColumnCount = 5,
                Padding = new Padding(6)
            };
            topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            var searchLabel = new Label { Text = "Search:", AutoSize = true, Margin = new Padding(3, 9, 6, 0) };

            _searchBox = new TextBox
            {
                Dock = DockStyle.Fill,
                PlaceholderText = "Name or description…"
            };
            _searchBox.TextChanged += (s, e) => RefreshList();

            _typeFilter = new ComboBox { Width = 130, DropDownStyle = ComboBoxStyle.DropDownList, Margin = new Padding(6, 3, 0, 0) };
            _typeFilter.Items.Add("All types");
            _typeFilter.Items.Add(CharacterType.Realistic);
            _typeFilter.Items.Add(CharacterType.Anime);
            _typeFilter.SelectedIndex = 0;
            _typeFilter.SelectedIndexChanged += (s, e) => RefreshList();

            _tagFilter = new ComboBox { Width = 180, DropDownStyle = ComboBoxStyle.DropDownList, Margin = new Padding(6, 3, 0, 0) };
            _tagFilter.SelectedIndexChanged += (s, e) => RefreshList();

            var refreshBtn = new Button { Text = "Refresh", AutoSize = true, Margin = new Padding(6, 1, 0, 0) };
            refreshBtn.Click += (s, e) => { LoadTagFilter(); RefreshList(); };

            topPanel.Controls.Add(searchLabel, 0, 0);
            topPanel.Controls.Add(_searchBox, 1, 0);
            topPanel.Controls.Add(_typeFilter, 2, 0);
            topPanel.Controls.Add(_tagFilter, 3, 0);
            topPanel.Controls.Add(refreshBtn, 4, 0);

            // ---- Main grid ----
            _grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoGenerateColumns = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = SystemColors.Window
            };
            _grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CharacterRow.Id),
                HeaderText = "ID",
                Width = 50,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                FillWeight = 5
            });
            _grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CharacterRow.Name),
                HeaderText = "Name",
                FillWeight = 25
            });
            _grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CharacterRow.TypeText),
                HeaderText = "Type",
                FillWeight = 12
            });
            _grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CharacterRow.AgeText),
                HeaderText = "Age",
                FillWeight = 10
            });
            _grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CharacterRow.TagsText),
                HeaderText = "Tags",
                FillWeight = 33
            });
            _grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(CharacterRow.ModifiedText),
                HeaderText = "Modified",
                FillWeight = 15
            });
            _grid.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) EditSelected(); };
            _grid.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Delete) DeleteSelected();
                else if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; EditSelected(); }
            };

            // ---- Bottom action bar ----
            var bottomPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 46,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(6)
            };
            bottomPanel.Controls.Add(MakeBtn("Add New…", (s, e) => AddNew()));
            bottomPanel.Controls.Add(MakeBtn("Edit…", (s, e) => EditSelected()));
            bottomPanel.Controls.Add(MakeBtn("Duplicate", (s, e) => DuplicateSelected()));
            bottomPanel.Controls.Add(MakeBtn("Delete", (s, e) => DeleteSelected()));
            bottomPanel.Controls.Add(new Label { Width = 20 }); // spacer
            bottomPanel.Controls.Add(MakeBtn("Manage Tags…", (s, e) => OpenTagManager()));
            bottomPanel.Controls.Add(new Label { Width = 20 }); // spacer
            bottomPanel.Controls.Add(MakeBtn("Export All (JSON)…", (s, e) => ExportAll()));
            bottomPanel.Controls.Add(MakeBtn("Export Selected (JSON)…", (s, e) => ExportSelected()));
            bottomPanel.Controls.Add(MakeBtn("Import JSON…", (s, e) => ImportJson()));

            // ---- Status strip ----
            _statusStrip = new StatusStrip();
            _statusLabel = new ToolStripStatusLabel();
            _statusStrip.Items.Add(_statusLabel);

            Controls.Add(_grid);
            Controls.Add(bottomPanel);
            Controls.Add(topPanel);
            Controls.Add(_statusStrip);

            LoadTagFilter();
            RefreshList();
        }

        private static Button MakeBtn(string text, EventHandler onClick)
        {
            var b = new Button { Text = text, AutoSize = true, Padding = new Padding(6, 2, 6, 2) };
            b.Click += onClick;
            return b;
        }

        // ---------- Data loading ----------

        private class CharacterRow
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public CharacterType CharacterType { get; set; }
            public string TypeText => CharacterType.ToString();
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
                if (_typeFilter.SelectedItem is CharacterType t)
                    query = query.Where(c => c.CharacterType == t);

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
                    .ThenBy(c => c.CharacterType)
                    .Select(c => new CharacterRow
                    {
                        Id = c.Id,
                        Name = c.Name,
                        CharacterType = c.CharacterType,
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

            // Find a non-colliding name: "<Name> (Copy)", "<Name> (Copy 2)", …
            string baseName = src.Name + " (Copy)";
            string candidate = baseName;
            int n = 2;
            while (db.Characters.Any(c => c.Name == candidate && c.CharacterType == src.CharacterType))
                candidate = $"{baseName} {n++}";

            var copy = new Character
            {
                Name = candidate,
                CharacterType = src.CharacterType,
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
                ImagePath = src.ImagePath // points to same image file; that's fine
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
