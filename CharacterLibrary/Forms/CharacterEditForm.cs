using CharacterLibrary.Data;
using CharacterLibrary.Models;
using CharacterLibrary.Services;
using Microsoft.EntityFrameworkCore;

namespace CharacterLibrary.Forms
{
    /// <summary>
    /// Form for creating or editing a single Character. Lay out with TabControl
    /// to keep the 20+ fields organized and give the three 50k-character fields
    /// each their own full-size tab.
    /// </summary>
    public class CharacterEditForm : Form
    {
        private readonly int? _editingId;

        // Basic tab
        private readonly TextBox _nameBox;
        private readonly CheckBox _isRealisticCheck;
        private readonly CheckBox _isAnimeCheck;
        private readonly NumericUpDown _ageNum;
        private readonly TextBox _firstReplyBox;

        // Realistic image
        private readonly TextBox _imagePathBox;
        private readonly Button _browseImageBtn;
        private readonly Button _clearImageBtn;
        private readonly PictureBox _imagePreview;

        // Anime image
        private readonly TextBox _animeImagePathBox;
        private readonly Button _browseAnimeImageBtn;
        private readonly Button _clearAnimeImageBtn;
        private readonly PictureBox _animeImagePreview;

        private readonly CheckedListBox _tagList;
        private readonly TextBox _newTagBox;
        private readonly Button _addTagBtn;
        private readonly Label _tagCountLabel;

        // Appearance
        private readonly TextBox _hairStyle, _bodyType, _skinTone, _breastSize, _ethnicity, _buttSize, _eyeColor, _hairColor;
        private readonly TextBox _customPhysical, _customFace;

        // Personality short
        private readonly TextBox _occupation, _relationship, _hobby, _fetish, _publicDesc, _greeting;

        // Long fields
        private readonly TextBox _scenarioBox;
        private readonly TextBox _additionalBox;
        private readonly RichTextBox _extraBox;

        public CharacterEditForm(int? editingId = null)
        {
            _editingId = editingId;
            Text = editingId.HasValue ? "Edit Character" : "New Character";
            Width = 1000;
            Height = 780;
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(850, 600);

            var tabs = new TabControl { Dock = DockStyle.Fill };

            // ---- Basic tab ----
            var basicTab = new TabPage("Basic");
            var basicLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                Padding = new Padding(10),
                AutoScroll = true
            };
            basicLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180));
            basicLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            _nameBox = new TextBox { Dock = DockStyle.Fill, MaxLength = 100 };

            // Type checkboxes in a flow panel
            var typePanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = true
            };
            _isRealisticCheck = new CheckBox { Text = "Realistic", AutoSize = true, Margin = new Padding(0, 3, 16, 0) };
            _isAnimeCheck = new CheckBox { Text = "Anime", AutoSize = true, Margin = new Padding(0, 3, 0, 0) };
            typePanel.Controls.Add(_isRealisticCheck);
            typePanel.Controls.Add(_isAnimeCheck);

            _ageNum = new NumericUpDown
            {
                Dock = DockStyle.Fill,
                Minimum = 0,
                Maximum = long.MaxValue,
                ThousandsSeparator = true
            };

            _firstReplyBox = new TextBox { Dock = DockStyle.Fill, MaxLength = 100 };

            // --- Realistic image row ---
            var realImageRow = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, Height = 28, Margin = new Padding(0) };
            realImageRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            realImageRow.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            realImageRow.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            _imagePathBox = new TextBox { Dock = DockStyle.Fill, ReadOnly = true };
            _browseImageBtn = new Button { Text = "Browse…", AutoSize = true };
            _browseImageBtn.Click += (s, e) => PickImage(false);
            _clearImageBtn = new Button { Text = "Clear", AutoSize = true };
            _clearImageBtn.Click += (s, e) => { _imagePathBox.Text = ""; _imagePreview.Image?.Dispose(); _imagePreview.Image = null; };
            realImageRow.Controls.Add(_imagePathBox, 0, 0);
            realImageRow.Controls.Add(_browseImageBtn, 1, 0);
            realImageRow.Controls.Add(_clearImageBtn, 2, 0);

            _imagePreview = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill,
                Height = 220,
                BorderStyle = BorderStyle.FixedSingle
            };

            // --- Anime image row ---
            var animeImageRow = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, Height = 28, Margin = new Padding(0) };
            animeImageRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            animeImageRow.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            animeImageRow.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            _animeImagePathBox = new TextBox { Dock = DockStyle.Fill, ReadOnly = true };
            _browseAnimeImageBtn = new Button { Text = "Browse…", AutoSize = true };
            _browseAnimeImageBtn.Click += (s, e) => PickImage(true);
            _clearAnimeImageBtn = new Button { Text = "Clear", AutoSize = true };
            _clearAnimeImageBtn.Click += (s, e) => { _animeImagePathBox.Text = ""; _animeImagePreview.Image?.Dispose(); _animeImagePreview.Image = null; };
            animeImageRow.Controls.Add(_animeImagePathBox, 0, 0);
            animeImageRow.Controls.Add(_browseAnimeImageBtn, 1, 0);
            animeImageRow.Controls.Add(_clearAnimeImageBtn, 2, 0);

            _animeImagePreview = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill,
                Height = 220,
                BorderStyle = BorderStyle.FixedSingle
            };

            // --- Side-by-side image container (2 columns, 2 rows) ---
            // Row 0: path+browse+clear for each
            // Row 1: preview for each
            var imageContainer = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2,
                Margin = new Padding(0)
            };
            imageContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            imageContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            imageContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
            imageContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            // Sub-headers inside the container
            var realHeader = new Label { Text = "Realistic:", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold) };
            var animeHeader = new Label { Text = "Anime:", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold), Margin = new Padding(6, 0, 0, 0) };

            // Wrap each image row with its header in a small panel
            var realTop = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1, Margin = new Padding(0) };
            realTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));
            realTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            realTop.Controls.Add(realHeader, 0, 0);
            realTop.Controls.Add(realImageRow, 1, 0);

            var animeTop = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1, Margin = new Padding(0) };
            animeTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55));
            animeTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            animeTop.Controls.Add(animeHeader, 0, 0);
            animeTop.Controls.Add(animeImageRow, 1, 0);

            imageContainer.Controls.Add(realTop, 0, 0);
            imageContainer.Controls.Add(animeTop, 1, 0);
            imageContainer.Controls.Add(_imagePreview, 0, 1);
            imageContainer.Controls.Add(_animeImagePreview, 1, 1);

            AddRow(basicLayout, "Name *", _nameBox);
            AddRow(basicLayout, "Type", typePanel);
            AddRow(basicLayout, "Age", _ageNum);
            AddRow(basicLayout, "First Reply Suggestion", _firstReplyBox);
            AddRow(basicLayout, "Images", imageContainer, rowHeight: 258);

            // Tags area
            _tagList = new CheckedListBox
            {
                Dock = DockStyle.Fill,
                CheckOnClick = true,
                IntegralHeight = false
            };
            _tagCountLabel = new Label { AutoSize = true, Margin = new Padding(6, 6, 0, 0) };
            _tagList.ItemCheck += (s, e) =>
            {
                int n = 0;
                for (int i = 0; i < _tagList.Items.Count; i++)
                {
                    bool willBeChecked = (i == e.Index)
                        ? (e.NewValue == CheckState.Checked)
                        : _tagList.GetItemChecked(i);
                    if (willBeChecked) n++;
                }
                _tagCountLabel.Text = $"{n} / 20 selected";
                _tagCountLabel.ForeColor = n > 20 ? Color.Red : SystemColors.ControlText;
            };

            _newTagBox = new TextBox { Dock = DockStyle.Fill, MaxLength = 25, PlaceholderText = "New tag…" };
            _newTagBox.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; AddInlineTag(); } };
            _addTagBtn = new Button { Text = "Add Tag", AutoSize = true };
            _addTagBtn.Click += (s, e) => AddInlineTag();

            var tagBottom = new TableLayoutPanel { Dock = DockStyle.Bottom, Height = 32, ColumnCount = 3 };
            tagBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tagBottom.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tagBottom.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tagBottom.Controls.Add(_newTagBox, 0, 0);
            tagBottom.Controls.Add(_addTagBtn, 1, 0);
            tagBottom.Controls.Add(_tagCountLabel, 2, 0);

            var tagPanel = new Panel { Dock = DockStyle.Fill, Height = 200 };
            tagPanel.Controls.Add(_tagList);
            tagPanel.Controls.Add(tagBottom);

            AddRow(basicLayout, "Tags (max 20)", tagPanel, rowHeight: 200);

            basicTab.Controls.Add(basicLayout);
            tabs.TabPages.Add(basicTab);

            // ---- Appearance tab ----
            var appearanceTab = new TabPage("Appearance");
            var appLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                Padding = new Padding(10),
                AutoScroll = true
            };
            appLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180));
            appLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            _hairStyle  = MakeTb(250);
            _bodyType   = MakeTb(25);
            _skinTone   = MakeTb(25);
            _breastSize = MakeTb(25);
            _ethnicity  = MakeTb(50);
            _buttSize   = MakeTb(50);
            _eyeColor   = MakeTb(100);
            _hairColor  = MakeTb(100);
            _customPhysical = MakeTb(2000, multiline: true);
            _customFace     = MakeTb(2000, multiline: true);

            AddRow(appLayout, "Hair Style (250)", _hairStyle);
            AddRow(appLayout, "Body Type (25)", _bodyType);
            AddRow(appLayout, "Ethnicity (50)", _ethnicity);
            AddRow(appLayout, "Breast Size (25)", _breastSize);
            AddRow(appLayout, "Butt Size (50)", _buttSize);
            AddRow(appLayout, "Eye Color (100)", _eyeColor);
            AddRow(appLayout, "Hair Color (100)", _hairColor);
            AddRow(appLayout, "Skin Tone (25)", _skinTone);
            AddRow(appLayout, "Custom Physical Details (2000)", _customPhysical, rowHeight: 100);
            AddRow(appLayout, "Custom Face Details (2000)", _customFace, rowHeight: 100);

            appearanceTab.Controls.Add(appLayout);
            tabs.TabPages.Add(appearanceTab);

            // ---- Personality tab ----
            var personalityTab = new TabPage("Personality");
            var persLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                Padding = new Padding(10),
                AutoScroll = true
            };
            persLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180));
            persLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            _occupation   = MakeTb(4000, multiline: true);
            _relationship = MakeTb(4000, multiline: true);
            _hobby        = MakeTb(4000, multiline: true);
            _fetish       = MakeTb(4000, multiline: true);
            _publicDesc   = MakeTb(10000, multiline: true);
            _greeting     = MakeTb(10000, multiline: true);

            AddRow(persLayout, "Occupation (4000)", _occupation, rowHeight: 80);
            AddRow(persLayout, "Relationship (4000)", _relationship, rowHeight: 80);
            AddRow(persLayout, "Hobby (4000)", _hobby, rowHeight: 80);
            AddRow(persLayout, "Fetish (4000)", _fetish, rowHeight: 80);
            AddRow(persLayout, "Public Description (10000)", _publicDesc, rowHeight: 120);
            AddRow(persLayout, "Greeting (10000)", _greeting, rowHeight: 120);

            personalityTab.Controls.Add(persLayout);
            tabs.TabPages.Add(personalityTab);

            // ---- Scenario (50k) ----
            _scenarioBox = MakeTb(50000, multiline: true);
            _scenarioBox.Dock = DockStyle.Fill;
            var scenarioTab = new TabPage("Scenario (50,000)");
            scenarioTab.Controls.Add(_scenarioBox);
            scenarioTab.Padding = new Padding(10);
            tabs.TabPages.Add(scenarioTab);

            // ---- Additional Personality Details (50k) ----
            _additionalBox = MakeTb(50000, multiline: true);
            _additionalBox.Dock = DockStyle.Fill;
            var additionalTab = new TabPage("Additional Personality (50,000)");
            additionalTab.Controls.Add(_additionalBox);
            additionalTab.Padding = new Padding(10);
            tabs.TabPages.Add(additionalTab);

            // ---- Extra Details (100k) ----
            _extraBox = MakeRtb(100000);
            _extraBox.Dock = DockStyle.Fill;
            var extraTab = new TabPage("Extra Details (100,000)");
            extraTab.Controls.Add(_extraBox);
            extraTab.Padding = new Padding(10);
            tabs.TabPages.Add(extraTab);

            // ---- Save / Cancel buttons ----
            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 46,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(10)
            };
            var cancelBtn = new Button { Text = "Cancel", AutoSize = true, DialogResult = DialogResult.Cancel };
            cancelBtn.Click += (s, e) => Close();
            var saveBtn = new Button { Text = "Save", AutoSize = true };
            saveBtn.Click += (s, e) => SaveAndClose();
            buttonPanel.Controls.Add(cancelBtn);
            buttonPanel.Controls.Add(saveBtn);
            AcceptButton = saveBtn;
            CancelButton = cancelBtn;

            Controls.Add(tabs);
            Controls.Add(buttonPanel);

            LoadTagsIntoList();

            if (_editingId.HasValue)
                LoadExisting(_editingId.Value);

            UpdateTagCount();
        }

        // ---------- UI helpers ----------

        private static TextBox MakeTb(int maxLen, bool multiline = false)
        {
            var tb = new TextBox
            {
                Dock = DockStyle.Fill,
                MaxLength = maxLen,
                Multiline = multiline,
                ScrollBars = multiline ? ScrollBars.Vertical : ScrollBars.None,
                AcceptsReturn = multiline,
                WordWrap = multiline
            };
            return tb;
        }

        private static RichTextBox MakeRtb(int maxLen)
        {
            var rtb = new RichTextBox
            {
                Dock = DockStyle.Fill,
                MaxLength = maxLen,
                ScrollBars = RichTextBoxScrollBars.Vertical,
                WordWrap = true
            };
            return rtb;
        }

        private static void AddRow(TableLayoutPanel panel, string label, Control control, int rowHeight = 26)
        {
            int row = panel.RowCount;
            panel.RowCount = row + 1;
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight + 8));

            var lbl = new Label
            {
                Text = label,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopLeft,
                AutoEllipsis = true,
                Margin = new Padding(0, 6, 8, 6)
            };
            panel.Controls.Add(lbl, 0, row);
            panel.Controls.Add(control, 1, row);
        }

        private void PickImage(bool anime)
        {
            using var dlg = new OpenFileDialog
            {
                Title = anime ? "Choose anime image" : "Choose realistic image",
                Filter = "Image files|*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.webp|All files|*.*"
            };
            if (dlg.ShowDialog(this) != DialogResult.OK) return;
            try
            {
                var rel = ImageService.ImportImage(dlg.FileName);
                if (anime)
                {
                    _animeImagePathBox.Text = rel;
                    LoadImagePreview(rel, _animeImagePreview);
                }
                else
                {
                    _imagePathBox.Text = rel;
                    LoadImagePreview(rel, _imagePreview);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not import image:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void LoadImagePreview(string? relativePath, PictureBox preview)
        {
            preview.Image?.Dispose();
            preview.Image = null;
            var abs = ImageService.ResolveAbsolute(relativePath);
            if (abs == null) return;
            try
            {
                using var fs = new FileStream(abs, FileMode.Open, FileAccess.Read, FileShare.Read);
                preview.Image = Image.FromStream(fs);
            }
            catch
            {
                // Ignore preview failures; stored path is still valid.
            }
        }

        // ---------- Tag list ----------

        private void LoadTagsIntoList()
        {
            _tagList.Items.Clear();
            using var db = new CharacterDbContext();
            var tags = db.Tags.AsNoTracking().OrderBy(t => t.Name).ToList();
            foreach (var t in tags)
                _tagList.Items.Add(new TagItem(t.Id, t.Name), false);
        }

        private void AddInlineTag()
        {
            var name = _newTagBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(name)) return;
            if (name.Length > 25)
            {
                MessageBox.Show("Tag name can't exceed 25 characters.", "Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var db = new CharacterDbContext();
            var tag = db.Tags.FirstOrDefault(t => t.Name == name);
            if (tag == null)
            {
                tag = new Tag { Name = name };
                db.Tags.Add(tag);
                db.SaveChanges();
            }

            var previouslyChecked = GetCheckedTagIds().ToHashSet();
            previouslyChecked.Add(tag.Id);

            LoadTagsIntoList();
            for (int i = 0; i < _tagList.Items.Count; i++)
            {
                var item = (TagItem)_tagList.Items[i]!;
                if (previouslyChecked.Contains(item.Id))
                    _tagList.SetItemChecked(i, true);
            }

            _newTagBox.Clear();
            UpdateTagCount();
        }

        private IEnumerable<int> GetCheckedTagIds()
        {
            for (int i = 0; i < _tagList.Items.Count; i++)
            {
                if (_tagList.GetItemChecked(i))
                    yield return ((TagItem)_tagList.Items[i]!).Id;
            }
        }

        private void UpdateTagCount()
        {
            int n = 0;
            for (int i = 0; i < _tagList.Items.Count; i++)
                if (_tagList.GetItemChecked(i)) n++;
            _tagCountLabel.Text = $"{n} / 20 selected";
            _tagCountLabel.ForeColor = n > 20 ? Color.Red : SystemColors.ControlText;
        }

        private class TagItem
        {
            public int Id { get; }
            public string Name { get; }
            public TagItem(int id, string name) { Id = id; Name = name; }
            public override string ToString() => Name;
        }

        // ---------- Load / Save ----------

        private void LoadExisting(int id)
        {
            using var db = new CharacterDbContext();
            var c = db.Characters
                .AsNoTracking()
                .Include(x => x.CharacterTags)
                .FirstOrDefault(x => x.Id == id);
            if (c == null) return;

            _nameBox.Text = c.Name;
            _isRealisticCheck.Checked = c.IsRealistic;
            _isAnimeCheck.Checked = c.IsAnime;
            _ageNum.Value = c.Age < 0 ? 0 : c.Age;
            _firstReplyBox.Text = c.FirstReplySuggestion ?? "";

            _imagePathBox.Text = c.ImagePath ?? "";
            LoadImagePreview(c.ImagePath, _imagePreview);
            _animeImagePathBox.Text = c.AnimeImagePath ?? "";
            LoadImagePreview(c.AnimeImagePath, _animeImagePreview);

            _hairStyle.Text  = c.HairStyle ?? "";
            _bodyType.Text   = c.BodyType ?? "";
            _skinTone.Text   = c.SkinTone ?? "";
            _breastSize.Text = c.BreastSize ?? "";
            _ethnicity.Text  = c.Ethnicity ?? "";
            _buttSize.Text   = c.ButtSize ?? "";
            _eyeColor.Text   = c.EyeColor ?? "";
            _hairColor.Text  = c.HairColor ?? "";
            _customPhysical.Text = c.CustomPhysicalDetails ?? "";
            _customFace.Text     = c.CustomFaceDetails ?? "";

            _occupation.Text   = c.Occupation ?? "";
            _relationship.Text = c.Relationship ?? "";
            _hobby.Text        = c.Hobby ?? "";
            _fetish.Text       = c.Fetish ?? "";
            _publicDesc.Text   = c.PublicDescription ?? "";
            _greeting.Text     = c.Greeting ?? "";

            _scenarioBox.Text   = c.Scenario ?? "";
            _additionalBox.Text = c.AdditionalPersonalityDetails ?? "";
            _extraBox.Text      = c.ExtraDetails ?? "";

            var mine = (c.CharacterTags ?? new List<CharacterTag>())
                .Select(ct => ct.TagId)
                .ToHashSet();

            for (int i = 0; i < _tagList.Items.Count; i++)
            {
                var it = (TagItem)_tagList.Items[i]!;
                if (mine.Contains(it.Id))
                    _tagList.SetItemChecked(i, true);
            }
        }

        private void SaveAndClose()
        {
            if (string.IsNullOrWhiteSpace(_nameBox.Text))
            {
                MessageBox.Show("Name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var checkedIds = GetCheckedTagIds().ToList();
            if (checkedIds.Count > 20)
            {
                MessageBox.Show("A character can have at most 20 tags.", "Too many tags",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var db = new CharacterDbContext();

            var name = _nameBox.Text.Trim();

            // Enforce unique Name
            var conflict = db.Characters.Any(c =>
                c.Name == name &&
                (!_editingId.HasValue || c.Id != _editingId.Value));
            if (conflict)
            {
                MessageBox.Show($"A character named \"{name}\" already exists.",
                    "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Character entity;
            if (_editingId.HasValue)
            {
                entity = db.Characters
                    .Include(c => c.CharacterTags)
                    .First(c => c.Id == _editingId.Value);
            }
            else
            {
                entity = new Character();
                db.Characters.Add(entity);
            }

            entity.Name = name;
            entity.IsRealistic = _isRealisticCheck.Checked;
            entity.IsAnime = _isAnimeCheck.Checked;
            entity.Age = (long)_ageNum.Value;
            entity.FirstReplySuggestion = NullIfEmpty(_firstReplyBox.Text);
            entity.ImagePath = NullIfEmpty(_imagePathBox.Text);
            entity.AnimeImagePath = NullIfEmpty(_animeImagePathBox.Text);

            entity.HairStyle  = NullIfEmpty(_hairStyle.Text);
            entity.BodyType   = NullIfEmpty(_bodyType.Text);
            entity.SkinTone   = NullIfEmpty(_skinTone.Text);
            entity.BreastSize = NullIfEmpty(_breastSize.Text);
            entity.Ethnicity  = NullIfEmpty(_ethnicity.Text);
            entity.ButtSize   = NullIfEmpty(_buttSize.Text);
            entity.EyeColor   = NullIfEmpty(_eyeColor.Text);
            entity.HairColor  = NullIfEmpty(_hairColor.Text);
            entity.CustomPhysicalDetails = NullIfEmpty(_customPhysical.Text);
            entity.CustomFaceDetails     = NullIfEmpty(_customFace.Text);

            entity.Occupation   = NullIfEmpty(_occupation.Text);
            entity.Relationship = NullIfEmpty(_relationship.Text);
            entity.Hobby        = NullIfEmpty(_hobby.Text);
            entity.Fetish       = NullIfEmpty(_fetish.Text);
            entity.PublicDescription = NullIfEmpty(_publicDesc.Text);
            entity.Greeting          = NullIfEmpty(_greeting.Text);
            entity.Scenario                     = NullIfEmpty(_scenarioBox.Text);
            entity.AdditionalPersonalityDetails = NullIfEmpty(_additionalBox.Text);
            entity.ExtraDetails                 = NullIfEmpty(_extraBox.Text);

            db.SaveChanges();

            // Sync tags
            if (entity.CharacterTags.Count > 0)
            {
                db.CharacterTags.RemoveRange(entity.CharacterTags);
                db.SaveChanges();
            }
            foreach (var tagId in checkedIds)
            {
                db.CharacterTags.Add(new CharacterTag
                {
                    CharacterId = entity.Id,
                    TagId = tagId
                });
            }
            db.SaveChanges();

            DialogResult = DialogResult.OK;
            Close();
        }

        private static string? NullIfEmpty(string? s) =>
            string.IsNullOrWhiteSpace(s) ? null : s;
    }
}
