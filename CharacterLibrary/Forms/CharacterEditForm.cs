using System.ComponentModel;
using System.Runtime.InteropServices;
using CharacterLibrary.Data;
using CharacterLibrary.Models;
using CharacterLibrary.Services;
using Microsoft.EntityFrameworkCore;

namespace CharacterLibrary.Forms
{
    /// <summary>
    /// Form for creating or editing a single Character. Laid out with TabControl
    /// to keep the 20+ fields organized and give the three 50k-character fields
    /// each their own full-size tab.
    /// </summary>
    public partial class CharacterEditForm : Form
    {
        private readonly int? _editingId;

        public CharacterEditForm(int? editingId = null)
        {
            _editingId = editingId;
            InitializeComponent();
            Text = editingId.HasValue ? "Edit Character" : "New Character";

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                LoadTagsIntoList();
                if (_editingId.HasValue)
                    LoadExisting(_editingId.Value);
                UpdateTagCount();
            }
        }

        // ---------- Event handlers ----------

        private void BrowseImageBtn_Click(object? sender, EventArgs e) => PickImage(false);

        private void ClearImageBtn_Click(object? sender, EventArgs e)
        {
            _imagePathBox.Text = "";
            if (_imagePreview != null)
            {
                _imagePreview.Image?.Dispose();
                _imagePreview.Image = null;
            }
        }

        private void BrowseAnimeImageBtn_Click(object? sender, EventArgs e) => PickImage(true);

        private void ClearAnimeImageBtn_Click(object? sender, EventArgs e)
        {
            _animeImagePathBox.Text = "";
            if (_animeImagePreview != null)
            {
                _animeImagePreview.Image?.Dispose();
                _animeImagePreview.Image = null;
            }
        }

        private void TagList_ItemCheck(object? sender, ItemCheckEventArgs e)
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
        }

        private void NewTagBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; AddInlineTag(); }
        }

        private void AddTagBtn_Click(object? sender, EventArgs e) => AddInlineTag();
        private void CancelBtn_Click(object? sender, EventArgs e) => Close();
        private void SaveBtn_Click(object? sender, EventArgs e) => SaveAndClose();

        // RichTextBox has no AcceptsReturn; without this, Enter in the Extra
        // Details box activates the form's AcceptButton (Save) instead of
        // inserting a newline.
        private void ExtraBox_Enter(object? sender, EventArgs e) => AcceptButton = null;
        private void ExtraBox_Leave(object? sender, EventArgs e) => AcceptButton = _saveBtn;

        // ---------- Image handling ----------

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
            _firstReplyBox.Text = Normalize(c.FirstReplySuggestion);

            _imagePathBox.Text = c.ImagePath ?? "";
            LoadImagePreview(c.ImagePath, _imagePreview);
            _animeImagePathBox.Text = c.AnimeImagePath ?? "";
            LoadImagePreview(c.AnimeImagePath, _animeImagePreview);

            _hairStyle.Text = Normalize(c.HairStyle);
            _bodyType.Text = Normalize(c.BodyType);
            _skinTone.Text = Normalize(c.SkinTone);
            _breastSize.Text = Normalize(c.BreastSize);
            _ethnicity.Text = Normalize(c.Ethnicity);
            _buttSize.Text = Normalize(c.ButtSize);
            _eyeColor.Text = Normalize(c.EyeColor);
            _hairColor.Text = Normalize(c.HairColor);
            _customPhysical.Text = Normalize(c.CustomPhysicalDetails);
            _customFace.Text = Normalize(c.CustomFaceDetails);

            _occupation.Text = Normalize(c.Occupation);
            _relationship.Text = Normalize(c.Relationship);
            _hobby.Text = Normalize(c.Hobby);
            _fetish.Text = Normalize(c.Fetish);
            _publicDesc.Text = Normalize(c.PublicDescription);
            _greeting.Text = Normalize(c.Greeting);

            _scenarioBox.Text = Normalize(c.Scenario);
            _additionalBox.Text = Normalize(c.AdditionalPersonalityDetails);
            SetTextWithoutRedraw(_extraBox, Normalize(c.ExtraDetails));

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
            entity.FirstReplySuggestion = DenormalizeForStorage(_firstReplyBox.Text);
            entity.ImagePath = NullIfEmpty(_imagePathBox.Text);
            entity.AnimeImagePath = NullIfEmpty(_animeImagePathBox.Text);

            entity.HairStyle = DenormalizeForStorage(_hairStyle.Text);
            entity.BodyType = DenormalizeForStorage(_bodyType.Text);
            entity.SkinTone = DenormalizeForStorage(_skinTone.Text);
            entity.BreastSize = DenormalizeForStorage(_breastSize.Text);
            entity.Ethnicity = DenormalizeForStorage(_ethnicity.Text);
            entity.ButtSize = DenormalizeForStorage(_buttSize.Text);
            entity.EyeColor = DenormalizeForStorage(_eyeColor.Text);
            entity.HairColor = DenormalizeForStorage(_hairColor.Text);
            entity.CustomPhysicalDetails = DenormalizeForStorage(_customPhysical.Text);
            entity.CustomFaceDetails = DenormalizeForStorage(_customFace.Text);

            entity.Occupation = DenormalizeForStorage(_occupation.Text);
            entity.Relationship = DenormalizeForStorage(_relationship.Text);
            entity.Hobby = DenormalizeForStorage(_hobby.Text);
            entity.Fetish = DenormalizeForStorage(_fetish.Text);
            entity.PublicDescription = DenormalizeForStorage(_publicDesc.Text);
            entity.Greeting = DenormalizeForStorage(_greeting.Text);
            entity.Scenario = DenormalizeForStorage(_scenarioBox.Text);
            entity.AdditionalPersonalityDetails = DenormalizeForStorage(_additionalBox.Text);
            entity.ExtraDetails = DenormalizeForStorage(_extraBox.Text);

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

        /// <summary>
        /// Normalize stored line endings (LF) to CRLF for display in WinForms text controls.
        /// Handles LF, CR, and existing CRLF without doubling.
        /// </summary>
        private static string Normalize(string? s) =>
            s == null ? "" : s.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");

        /// <summary>
        /// Convert CRLF (from WinForms text controls) back to LF for storage.
        /// Keeps the DB canonical with what the target website expects.
        /// </summary>
        private static string? DenormalizeForStorage(string? s) =>
            string.IsNullOrEmpty(s) ? null : s.Replace("\r\n", "\n");

        private static string? NullIfEmpty(string? s) =>
            string.IsNullOrWhiteSpace(s) ? null : s;

        // ---------- Large-text load performance ----------

        private const int WM_SETREDRAW = 0x000B;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, bool wParam, IntPtr lParam);

        /// <summary>
        /// Suspends repaint while replacing a large amount of text (e.g. the 100k-char
        /// Extra Details box); avoids the visible stall/redraw-per-line cost on load.
        /// </summary>
        private static void SetTextWithoutRedraw(RichTextBox box, string text)
        {
            SendMessage(box.Handle, WM_SETREDRAW, false, IntPtr.Zero);
            try
            {
                box.Text = text;
            }
            finally
            {
                SendMessage(box.Handle, WM_SETREDRAW, true, IntPtr.Zero);
                box.Invalidate();
            }
        }
    }
}
