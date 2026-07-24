namespace CharacterLibrary.Forms
{
    partial class TagManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _list = new ListView();
            _tagColumnHeader = new ColumnHeader();
            _usedByColumnHeader = new ColumnHeader();
            _createdColumnHeader = new ColumnHeader();
            _addPanel = new TableLayoutPanel();
            _newTagBox = new TextBox();
            _addBtn = new Button();
            _bottomPanel = new FlowLayoutPanel();
            _closeBtn = new Button();
            _deleteBtn = new Button();
            _renameBtn = new Button();
            _addPanel.SuspendLayout();
            _bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // _list
            // 
            _list.Columns.AddRange(new ColumnHeader[] { _tagColumnHeader, _usedByColumnHeader, _createdColumnHeader });
            _list.Dock = DockStyle.Fill;
            _list.FullRowSelect = true;
            _list.GridLines = true;
            _list.Location = new Point(0, 40);
            _list.MultiSelect = false;
            _list.Name = "_list";
            _list.Size = new Size(484, 377);
            _list.TabIndex = 1;
            _list.UseCompatibleStateImageBehavior = false;
            _list.View = View.Details;
            // 
            // _tagColumnHeader
            // 
            _tagColumnHeader.Text = "Tag";
            _tagColumnHeader.Width = 250;
            // 
            // _usedByColumnHeader
            // 
            _usedByColumnHeader.Text = "Used by";
            _usedByColumnHeader.Width = 80;
            // 
            // _createdColumnHeader
            // 
            _createdColumnHeader.Text = "Created (UTC)";
            _createdColumnHeader.Width = 140;
            // 
            // _addPanel
            // 
            _addPanel.ColumnCount = 2;
            _addPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _addPanel.ColumnStyles.Add(new ColumnStyle());
            _addPanel.Controls.Add(_newTagBox, 0, 0);
            _addPanel.Controls.Add(_addBtn, 1, 0);
            _addPanel.Dock = DockStyle.Top;
            _addPanel.Location = new Point(0, 0);
            _addPanel.Name = "_addPanel";
            _addPanel.Padding = new Padding(6);
            _addPanel.RowCount = 1;
            _addPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            _addPanel.Size = new Size(484, 40);
            _addPanel.TabIndex = 0;
            // 
            // _newTagBox
            // 
            _newTagBox.Dock = DockStyle.Fill;
            _newTagBox.Location = new Point(9, 9);
            _newTagBox.MaxLength = 25;
            _newTagBox.Name = "_newTagBox";
            _newTagBox.PlaceholderText = "New tag name (max 25 chars)…";
            _newTagBox.Size = new Size(385, 23);
            _newTagBox.TabIndex = 0;
            _newTagBox.KeyDown += NewTagBox_KeyDown;
            // 
            // _addBtn
            // 
            _addBtn.AutoSize = true;
            _addBtn.Location = new Point(400, 9);
            _addBtn.Name = "_addBtn";
            _addBtn.Size = new Size(75, 22);
            _addBtn.TabIndex = 1;
            _addBtn.Text = "Add";
            _addBtn.Click += AddBtn_Click;
            // 
            // _bottomPanel
            // 
            _bottomPanel.Controls.Add(_closeBtn);
            _bottomPanel.Controls.Add(_deleteBtn);
            _bottomPanel.Controls.Add(_renameBtn);
            _bottomPanel.Dock = DockStyle.Bottom;
            _bottomPanel.FlowDirection = FlowDirection.RightToLeft;
            _bottomPanel.Location = new Point(0, 417);
            _bottomPanel.Name = "_bottomPanel";
            _bottomPanel.Padding = new Padding(6);
            _bottomPanel.Size = new Size(484, 44);
            _bottomPanel.TabIndex = 2;
            // 
            // _closeBtn
            // 
            _closeBtn.AutoSize = true;
            _closeBtn.Location = new Point(394, 9);
            _closeBtn.Name = "_closeBtn";
            _closeBtn.Size = new Size(75, 25);
            _closeBtn.TabIndex = 0;
            _closeBtn.Text = "Close";
            _closeBtn.Click += CloseBtn_Click;
            // 
            // _deleteBtn
            // 
            _deleteBtn.AutoSize = true;
            _deleteBtn.Location = new Point(313, 9);
            _deleteBtn.Name = "_deleteBtn";
            _deleteBtn.Size = new Size(75, 25);
            _deleteBtn.TabIndex = 1;
            _deleteBtn.Text = "Delete";
            _deleteBtn.Click += DeleteBtn_Click;
            // 
            // _renameBtn
            // 
            _renameBtn.AutoSize = true;
            _renameBtn.Location = new Point(232, 9);
            _renameBtn.Name = "_renameBtn";
            _renameBtn.Size = new Size(75, 25);
            _renameBtn.TabIndex = 2;
            _renameBtn.Text = "Rename";
            _renameBtn.Click += RenameBtn_Click;
            // 
            // TagManagerForm
            // 
            ClientSize = new Size(484, 461);
            Controls.Add(_list);
            Controls.Add(_addPanel);
            Controls.Add(_bottomPanel);
            MinimumSize = new Size(400, 300);
            Name = "TagManagerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Manage Tags";
            _addPanel.ResumeLayout(false);
            _addPanel.PerformLayout();
            _bottomPanel.ResumeLayout(false);
            _bottomPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListView _list;
        private System.Windows.Forms.ColumnHeader _tagColumnHeader;
        private System.Windows.Forms.ColumnHeader _usedByColumnHeader;
        private System.Windows.Forms.ColumnHeader _createdColumnHeader;
        private System.Windows.Forms.TableLayoutPanel _addPanel;
        private System.Windows.Forms.TextBox _newTagBox;
        private System.Windows.Forms.Button _addBtn;
        private System.Windows.Forms.FlowLayoutPanel _bottomPanel;
        private System.Windows.Forms.Button _closeBtn;
        private System.Windows.Forms.Button _deleteBtn;
        private System.Windows.Forms.Button _renameBtn;
    }
}
