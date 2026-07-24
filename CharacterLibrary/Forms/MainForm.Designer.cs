namespace CharacterLibrary.Forms
{
    partial class MainForm
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
            _topPanel = new TableLayoutPanel();
            _searchLabel = new Label();
            _searchBox = new TextBox();
            _typeFilter = new ComboBox();
            _tagFilter = new ComboBox();
            _refreshBtn = new Button();
            _grid = new DataGridView();
            _bottomPanel = new FlowLayoutPanel();
            _addNewBtn = new Button();
            _editBtn = new Button();
            _duplicateBtn = new Button();
            _deleteBtn = new Button();
            _spacer1 = new Label();
            _manageTagsBtn = new Button();
            _spacer2 = new Label();
            _exportAllBtn = new Button();
            _exportSelectedBtn = new Button();
            _importBtn = new Button();
            _statusStrip = new StatusStrip();
            _statusLabel = new ToolStripStatusLabel();
            _topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
            _bottomPanel.SuspendLayout();
            _statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // _topPanel
            // 
            _topPanel.ColumnCount = 5;
            _topPanel.ColumnStyles.Add(new ColumnStyle());
            _topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _topPanel.ColumnStyles.Add(new ColumnStyle());
            _topPanel.ColumnStyles.Add(new ColumnStyle());
            _topPanel.ColumnStyles.Add(new ColumnStyle());
            _topPanel.Controls.Add(_searchLabel, 0, 0);
            _topPanel.Controls.Add(_searchBox, 1, 0);
            _topPanel.Controls.Add(_typeFilter, 2, 0);
            _topPanel.Controls.Add(_tagFilter, 3, 0);
            _topPanel.Controls.Add(_refreshBtn, 4, 0);
            _topPanel.Dock = DockStyle.Top;
            _topPanel.Location = new Point(0, 0);
            _topPanel.Name = "_topPanel";
            _topPanel.Padding = new Padding(6);
            _topPanel.RowCount = 1;
            _topPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            _topPanel.Size = new Size(1134, 44);
            _topPanel.TabIndex = 0;
            // 
            // _searchLabel
            // 
            _searchLabel.AutoSize = true;
            _searchLabel.Location = new Point(9, 15);
            _searchLabel.Margin = new Padding(3, 9, 6, 0);
            _searchLabel.Name = "_searchLabel";
            _searchLabel.Size = new Size(45, 15);
            _searchLabel.TabIndex = 0;
            _searchLabel.Text = "Search:";
            // 
            // _searchBox
            // 
            _searchBox.Dock = DockStyle.Fill;
            _searchBox.Location = new Point(63, 9);
            _searchBox.Name = "_searchBox";
            _searchBox.PlaceholderText = "Name or description…";
            _searchBox.Size = new Size(659, 23);
            _searchBox.TabIndex = 0;
            _searchBox.TextChanged += SearchBox_TextChanged;
            // 
            // _typeFilter
            // 
            _typeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            _typeFilter.Location = new Point(731, 9);
            _typeFilter.Margin = new Padding(6, 3, 0, 0);
            _typeFilter.Name = "_typeFilter";
            _typeFilter.Size = new Size(130, 23);
            _typeFilter.TabIndex = 1;
            _typeFilter.SelectedIndexChanged += TypeFilter_SelectedIndexChanged;
            // 
            // _tagFilter
            // 
            _tagFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            _tagFilter.Location = new Point(867, 9);
            _tagFilter.Margin = new Padding(6, 3, 0, 0);
            _tagFilter.Name = "_tagFilter";
            _tagFilter.Size = new Size(180, 23);
            _tagFilter.TabIndex = 2;
            _tagFilter.SelectedIndexChanged += TagFilter_SelectedIndexChanged;
            // 
            // _refreshBtn
            // 
            _refreshBtn.AutoSize = true;
            _refreshBtn.Location = new Point(1053, 7);
            _refreshBtn.Margin = new Padding(6, 1, 0, 0);
            _refreshBtn.Name = "_refreshBtn";
            _refreshBtn.Size = new Size(75, 25);
            _refreshBtn.TabIndex = 3;
            _refreshBtn.Text = "Refresh";
            _refreshBtn.Click += RefreshBtn_Click;
            // 
            // _grid
            // 
            _grid.AllowUserToAddRows = false;
            _grid.AllowUserToDeleteRows = false;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _grid.BackgroundColor = SystemColors.Window;
            _grid.Dock = DockStyle.Fill;
            _grid.Location = new Point(0, 44);
            _grid.MultiSelect = false;
            _grid.Name = "_grid";
            _grid.ReadOnly = true;
            _grid.RowHeadersVisible = false;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.Size = new Size(1134, 549);
            _grid.TabIndex = 1;
            _grid.CellDoubleClick += Grid_CellDoubleClick;
            _grid.KeyDown += Grid_KeyDown;
            // 
            // _bottomPanel
            // 
            _bottomPanel.Controls.Add(_addNewBtn);
            _bottomPanel.Controls.Add(_editBtn);
            _bottomPanel.Controls.Add(_duplicateBtn);
            _bottomPanel.Controls.Add(_deleteBtn);
            _bottomPanel.Controls.Add(_spacer1);
            _bottomPanel.Controls.Add(_manageTagsBtn);
            _bottomPanel.Controls.Add(_spacer2);
            _bottomPanel.Controls.Add(_exportAllBtn);
            _bottomPanel.Controls.Add(_exportSelectedBtn);
            _bottomPanel.Controls.Add(_importBtn);
            _bottomPanel.Dock = DockStyle.Bottom;
            _bottomPanel.Location = new Point(0, 593);
            _bottomPanel.Name = "_bottomPanel";
            _bottomPanel.Padding = new Padding(6);
            _bottomPanel.Size = new Size(1134, 46);
            _bottomPanel.TabIndex = 2;
            // 
            // _addNewBtn
            // 
            _addNewBtn.AutoSize = true;
            _addNewBtn.Location = new Point(9, 9);
            _addNewBtn.Name = "_addNewBtn";
            _addNewBtn.Padding = new Padding(6, 2, 6, 2);
            _addNewBtn.Size = new Size(87, 29);
            _addNewBtn.TabIndex = 0;
            _addNewBtn.Text = "Add New…";
            _addNewBtn.Click += AddNewBtn_Click;
            // 
            // _editBtn
            // 
            _editBtn.AutoSize = true;
            _editBtn.Location = new Point(102, 9);
            _editBtn.Name = "_editBtn";
            _editBtn.Padding = new Padding(6, 2, 6, 2);
            _editBtn.Size = new Size(75, 29);
            _editBtn.TabIndex = 1;
            _editBtn.Text = "Edit…";
            _editBtn.Click += EditBtn_Click;
            // 
            // _duplicateBtn
            // 
            _duplicateBtn.AutoSize = true;
            _duplicateBtn.Location = new Point(183, 9);
            _duplicateBtn.Name = "_duplicateBtn";
            _duplicateBtn.Padding = new Padding(6, 2, 6, 2);
            _duplicateBtn.Size = new Size(79, 29);
            _duplicateBtn.TabIndex = 2;
            _duplicateBtn.Text = "Duplicate";
            _duplicateBtn.Click += DuplicateBtn_Click;
            // 
            // _deleteBtn
            // 
            _deleteBtn.AutoSize = true;
            _deleteBtn.Location = new Point(268, 9);
            _deleteBtn.Name = "_deleteBtn";
            _deleteBtn.Padding = new Padding(6, 2, 6, 2);
            _deleteBtn.Size = new Size(75, 29);
            _deleteBtn.TabIndex = 3;
            _deleteBtn.Text = "Delete";
            _deleteBtn.Click += DeleteBtn_Click;
            // 
            // _spacer1
            // 
            _spacer1.Location = new Point(349, 6);
            _spacer1.Name = "_spacer1";
            _spacer1.Size = new Size(20, 23);
            _spacer1.TabIndex = 4;
            // 
            // _manageTagsBtn
            // 
            _manageTagsBtn.AutoSize = true;
            _manageTagsBtn.Location = new Point(375, 9);
            _manageTagsBtn.Name = "_manageTagsBtn";
            _manageTagsBtn.Padding = new Padding(6, 2, 6, 2);
            _manageTagsBtn.Size = new Size(108, 29);
            _manageTagsBtn.TabIndex = 5;
            _manageTagsBtn.Text = "Manage Tags…";
            _manageTagsBtn.Click += ManageTagsBtn_Click;
            // 
            // _spacer2
            // 
            _spacer2.Location = new Point(489, 6);
            _spacer2.Name = "_spacer2";
            _spacer2.Size = new Size(20, 23);
            _spacer2.TabIndex = 6;
            // 
            // _exportAllBtn
            // 
            _exportAllBtn.AutoSize = true;
            _exportAllBtn.Location = new Point(515, 9);
            _exportAllBtn.Name = "_exportAllBtn";
            _exportAllBtn.Padding = new Padding(6, 2, 6, 2);
            _exportAllBtn.Size = new Size(127, 29);
            _exportAllBtn.TabIndex = 7;
            _exportAllBtn.Text = "Export All (JSON)…";
            _exportAllBtn.Click += ExportAllBtn_Click;
            // 
            // _exportSelectedBtn
            // 
            _exportSelectedBtn.AutoSize = true;
            _exportSelectedBtn.Location = new Point(648, 9);
            _exportSelectedBtn.Name = "_exportSelectedBtn";
            _exportSelectedBtn.Padding = new Padding(6, 2, 6, 2);
            _exportSelectedBtn.Size = new Size(157, 29);
            _exportSelectedBtn.TabIndex = 8;
            _exportSelectedBtn.Text = "Export Selected (JSON)…";
            _exportSelectedBtn.Click += ExportSelectedBtn_Click;
            // 
            // _importBtn
            // 
            _importBtn.AutoSize = true;
            _importBtn.Location = new Point(811, 9);
            _importBtn.Name = "_importBtn";
            _importBtn.Padding = new Padding(6, 2, 6, 2);
            _importBtn.Size = new Size(105, 29);
            _importBtn.TabIndex = 9;
            _importBtn.Text = "Import JSON…";
            _importBtn.Click += ImportBtn_Click;
            // 
            // _statusStrip
            // 
            _statusStrip.Items.AddRange(new ToolStripItem[] { _statusLabel });
            _statusStrip.Location = new Point(0, 639);
            _statusStrip.Name = "_statusStrip";
            _statusStrip.Size = new Size(1134, 22);
            _statusStrip.TabIndex = 3;
            // 
            // _statusLabel
            // 
            _statusLabel.Name = "_statusLabel";
            _statusLabel.Size = new Size(0, 17);
            // 
            // MainForm
            // 
            ClientSize = new Size(1134, 661);
            Controls.Add(_grid);
            Controls.Add(_bottomPanel);
            Controls.Add(_topPanel);
            Controls.Add(_statusStrip);
            MinimumSize = new Size(900, 500);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Character Library";
            _topPanel.ResumeLayout(false);
            _topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
            _bottomPanel.ResumeLayout(false);
            _bottomPanel.PerformLayout();
            _statusStrip.ResumeLayout(false);
            _statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _topPanel;
        private System.Windows.Forms.Label _searchLabel;
        private System.Windows.Forms.TextBox _searchBox;
        private System.Windows.Forms.ComboBox _typeFilter;
        private System.Windows.Forms.ComboBox _tagFilter;
        private System.Windows.Forms.Button _refreshBtn;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colTags;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colModified;
        private System.Windows.Forms.FlowLayoutPanel _bottomPanel;
        private System.Windows.Forms.Button _addNewBtn;
        private System.Windows.Forms.Button _editBtn;
        private System.Windows.Forms.Button _duplicateBtn;
        private System.Windows.Forms.Button _deleteBtn;
        private System.Windows.Forms.Label _spacer1;
        private System.Windows.Forms.Button _manageTagsBtn;
        private System.Windows.Forms.Label _spacer2;
        private System.Windows.Forms.Button _exportAllBtn;
        private System.Windows.Forms.Button _exportSelectedBtn;
        private System.Windows.Forms.Button _importBtn;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _statusLabel;
    }
}
