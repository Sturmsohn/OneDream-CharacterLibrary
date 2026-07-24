using System.ComponentModel;
using CharacterLibrary.Data;
using CharacterLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CharacterLibrary.Forms
{
    public partial class TagManagerForm : Form
    {
        public TagManagerForm()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                LoadTags();
        }

        private void NewTagBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; AddTag(); }
        }

        private void AddBtn_Click(object? sender, EventArgs e) => AddTag();
        private void CloseBtn_Click(object? sender, EventArgs e) => Close();
        private void DeleteBtn_Click(object? sender, EventArgs e) => DeleteSelected();
        private void RenameBtn_Click(object? sender, EventArgs e) => RenameSelected();

        private void LoadTags()
        {
            _list.Items.Clear();
            using var db = new CharacterDbContext();
            var rows = db.Tags
                .AsNoTracking()
                .OrderBy(t => t.Name)
                .Select(t => new
                {
                    t.Id,
                    t.Name,
                    t.CreatedAt,
                    Count = t.CharacterTags.Count
                })
                .ToList();

            foreach (var r in rows)
            {
                var item = new ListViewItem(r.Name) { Tag = r.Id };
                item.SubItems.Add(r.Count.ToString());
                item.SubItems.Add(r.CreatedAt.ToLocalTime().ToString("yyyy-MM-dd HH:mm"));
                _list.Items.Add(item);
            }
        }

        private void AddTag()
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
            if (db.Tags.Any(t => t.Name == name))
            {
                MessageBox.Show("A tag with that name already exists.", "Duplicate",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            db.Tags.Add(new Tag { Name = name });
            db.SaveChanges();

            _newTagBox.Clear();
            LoadTags();
        }

        private int? SelectedTagId()
        {
            if (_list.SelectedItems.Count == 0) return null;
            return (int)_list.SelectedItems[0].Tag;
        }

        private void RenameSelected()
        {
            var id = SelectedTagId();
            if (id == null) return;

            using var db = new CharacterDbContext();
            var tag = db.Tags.Find(id.Value);
            if (tag == null) return;

            var newName = Prompt.ShowDialog("Rename tag:", "Rename", tag.Name, 25);
            if (string.IsNullOrWhiteSpace(newName) || newName == tag.Name) return;

            if (db.Tags.Any(t => t.Name == newName && t.Id != tag.Id))
            {
                MessageBox.Show("A tag with that name already exists.", "Duplicate",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            tag.Name = newName.Trim();
            db.SaveChanges();
            LoadTags();
        }

        private void DeleteSelected()
        {
            var id = SelectedTagId();
            if (id == null) return;

            using var db = new CharacterDbContext();
            var tag = db.Tags.Include(t => t.CharacterTags).FirstOrDefault(t => t.Id == id.Value);
            if (tag == null) return;

            var used = tag.CharacterTags.Count;
            var msg = used == 0
                ? $"Delete tag \"{tag.Name}\"?"
                : $"Delete tag \"{tag.Name}\"? It's currently applied to {used} character(s); those associations will be removed.";

            if (MessageBox.Show(msg, "Delete tag",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            db.Tags.Remove(tag);
            db.SaveChanges();
            LoadTags();
        }
    }

    /// <summary>
    /// Lightweight input-prompt dialog used by the tag manager.
    /// </summary>
    internal static class Prompt
    {
        public static string ShowDialog(string prompt, string title, string initial = "", int maxLength = 100)
        {
            using var form = new Form
            {
                Width = 400,
                Height = 150,
                Text = title,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false
            };
            var label = new Label { Left = 12, Top = 12, Text = prompt, AutoSize = true };
            var input = new TextBox { Left = 12, Top = 36, Width = 360, Text = initial, MaxLength = maxLength };
            var ok = new Button { Text = "OK", Left = 216, Width = 75, Top = 70, DialogResult = DialogResult.OK };
            var cancel = new Button { Text = "Cancel", Left = 297, Width = 75, Top = 70, DialogResult = DialogResult.Cancel };
            form.AcceptButton = ok;
            form.CancelButton = cancel;
            form.Controls.AddRange(new Control[] { label, input, ok, cancel });
            return form.ShowDialog() == DialogResult.OK ? input.Text.Trim() : string.Empty;
        }
    }
}
