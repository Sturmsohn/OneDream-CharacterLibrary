using CharacterLibrary.Data;
using CharacterLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CharacterLibrary.Forms
{
    public class TagManagerForm : Form
    {
        private readonly ListView _list;
        private readonly TextBox _newTagBox;
        private readonly Button _addBtn;
        private readonly Button _renameBtn;
        private readonly Button _deleteBtn;
        private readonly Button _closeBtn;

        public TagManagerForm()
        {
            Text = "Manage Tags";
            Width = 500;
            Height = 500;
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(400, 300);

            _list = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                MultiSelect = false,
                GridLines = true
            };
            _list.Columns.Add("Tag", 250);
            _list.Columns.Add("Used by", 80);
            _list.Columns.Add("Created (UTC)", 140);

            var addPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 40,
                ColumnCount = 2,
                Padding = new Padding(6)
            };
            addPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            addPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            _newTagBox = new TextBox
            {
                Dock = DockStyle.Fill,
                MaxLength = 25,
                PlaceholderText = "New tag name (max 25 chars)…"
            };
            _newTagBox.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; AddTag(); } };

            _addBtn = new Button { Text = "Add", AutoSize = true };
            _addBtn.Click += (s, e) => AddTag();

            addPanel.Controls.Add(_newTagBox, 0, 0);
            addPanel.Controls.Add(_addBtn, 1, 0);

            var bottomPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 44,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(6)
            };
            _closeBtn = new Button { Text = "Close", AutoSize = true };
            _closeBtn.Click += (s, e) => Close();
            _deleteBtn = new Button { Text = "Delete", AutoSize = true };
            _deleteBtn.Click += (s, e) => DeleteSelected();
            _renameBtn = new Button { Text = "Rename", AutoSize = true };
            _renameBtn.Click += (s, e) => RenameSelected();
            bottomPanel.Controls.Add(_closeBtn);
            bottomPanel.Controls.Add(_deleteBtn);
            bottomPanel.Controls.Add(_renameBtn);

            Controls.Add(_list);
            Controls.Add(addPanel);
            Controls.Add(bottomPanel);

            LoadTags();
        }

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
