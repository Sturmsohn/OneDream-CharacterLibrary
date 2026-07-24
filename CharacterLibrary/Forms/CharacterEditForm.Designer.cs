namespace CharacterLibrary.Forms
{
    partial class CharacterEditForm
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
            _tabs = new TabControl();
            _basicTab = new TabPage();
            _basicLayout = new TableLayoutPanel();
            _lblName = new Label();
            _nameBox = new TextBox();
            _lblType = new Label();
            _typePanel = new FlowLayoutPanel();
            _isRealisticCheck = new CheckBox();
            _isAnimeCheck = new CheckBox();
            _lblAge = new Label();
            _ageNum = new NumericUpDown();
            _lblFirstReply = new Label();
            _firstReplyBox = new TextBox();
            _lblImages = new Label();
            _imageContainer = new TableLayoutPanel();
            _realTop = new TableLayoutPanel();
            _realHeader = new Label();
            _realImageRow = new TableLayoutPanel();
            _imagePathBox = new TextBox();
            _browseImageBtn = new Button();
            _clearImageBtn = new Button();
            _animeTop = new TableLayoutPanel();
            _animeHeader = new Label();
            _animeImageRow = new TableLayoutPanel();
            _animeImagePathBox = new TextBox();
            _browseAnimeImageBtn = new Button();
            _clearAnimeImageBtn = new Button();
            _imagePreview = new PictureBox();
            _animeImagePreview = new PictureBox();
            _lblTags = new Label();
            _tagPanel = new Panel();
            _tagList = new CheckedListBox();
            _tagBottom = new TableLayoutPanel();
            _newTagBox = new TextBox();
            _addTagBtn = new Button();
            _tagCountLabel = new Label();
            _appearanceTab = new TabPage();
            _appLayout = new TableLayoutPanel();
            _lblHairStyle = new Label();
            _hairStyle = new TextBox();
            _lblBodyType = new Label();
            _bodyType = new TextBox();
            _lblEthnicity = new Label();
            _ethnicity = new TextBox();
            _lblBreastSize = new Label();
            _breastSize = new TextBox();
            _lblButtSize = new Label();
            _buttSize = new TextBox();
            _lblEyeColor = new Label();
            _eyeColor = new TextBox();
            _lblHairColor = new Label();
            _hairColor = new TextBox();
            _lblSkinTone = new Label();
            _skinTone = new TextBox();
            _lblCustomPhysical = new Label();
            _customPhysical = new TextBox();
            _lblCustomFace = new Label();
            _customFace = new TextBox();
            _personalityTab = new TabPage();
            _persLayout = new TableLayoutPanel();
            _lblOccupation = new Label();
            _occupation = new TextBox();
            _lblRelationship = new Label();
            _relationship = new TextBox();
            _lblHobby = new Label();
            _hobby = new TextBox();
            _lblFetish = new Label();
            _fetish = new TextBox();
            _lblPublicDesc = new Label();
            _publicDesc = new TextBox();
            _lblGreeting = new Label();
            _greeting = new TextBox();
            _scenarioTab = new TabPage();
            _scenarioBox = new TextBox();
            _additionalTab = new TabPage();
            _additionalBox = new TextBox();
            _extraTab = new TabPage();
            _extraBox = new RichTextBox();
            _buttonPanel = new FlowLayoutPanel();
            _cancelBtn = new Button();
            _saveBtn = new Button();
            _tabs.SuspendLayout();
            _basicTab.SuspendLayout();
            _basicLayout.SuspendLayout();
            _typePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_ageNum).BeginInit();
            _imageContainer.SuspendLayout();
            _realTop.SuspendLayout();
            _realImageRow.SuspendLayout();
            _animeTop.SuspendLayout();
            _animeImageRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_imagePreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_animeImagePreview).BeginInit();
            _tagPanel.SuspendLayout();
            _tagBottom.SuspendLayout();
            _appearanceTab.SuspendLayout();
            _appLayout.SuspendLayout();
            _personalityTab.SuspendLayout();
            _persLayout.SuspendLayout();
            _scenarioTab.SuspendLayout();
            _additionalTab.SuspendLayout();
            _extraTab.SuspendLayout();
            _buttonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // _tabs
            // 
            _tabs.Controls.Add(_basicTab);
            _tabs.Controls.Add(_appearanceTab);
            _tabs.Controls.Add(_personalityTab);
            _tabs.Controls.Add(_scenarioTab);
            _tabs.Controls.Add(_additionalTab);
            _tabs.Controls.Add(_extraTab);
            _tabs.Dock = DockStyle.Fill;
            _tabs.Location = new Point(0, 0);
            _tabs.Name = "_tabs";
            _tabs.SelectedIndex = 0;
            _tabs.Size = new Size(984, 695);
            _tabs.TabIndex = 0;
            // 
            // _basicTab
            // 
            _basicTab.Controls.Add(_basicLayout);
            _basicTab.Location = new Point(4, 24);
            _basicTab.Name = "_basicTab";
            _basicTab.Size = new Size(976, 667);
            _basicTab.TabIndex = 0;
            _basicTab.Text = "Basic";
            _basicTab.UseVisualStyleBackColor = true;
            // 
            // _basicLayout
            // 
            _basicLayout.AutoScroll = true;
            _basicLayout.ColumnCount = 2;
            _basicLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            _basicLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _basicLayout.Controls.Add(_lblName, 0, 0);
            _basicLayout.Controls.Add(_nameBox, 1, 0);
            _basicLayout.Controls.Add(_lblType, 0, 1);
            _basicLayout.Controls.Add(_typePanel, 1, 1);
            _basicLayout.Controls.Add(_lblAge, 0, 2);
            _basicLayout.Controls.Add(_ageNum, 1, 2);
            _basicLayout.Controls.Add(_lblFirstReply, 0, 3);
            _basicLayout.Controls.Add(_firstReplyBox, 1, 3);
            _basicLayout.Controls.Add(_lblImages, 0, 4);
            _basicLayout.Controls.Add(_imageContainer, 1, 4);
            _basicLayout.Controls.Add(_lblTags, 0, 5);
            _basicLayout.Controls.Add(_tagPanel, 1, 5);
            _basicLayout.Dock = DockStyle.Fill;
            _basicLayout.Location = new Point(0, 0);
            _basicLayout.Name = "_basicLayout";
            _basicLayout.Padding = new Padding(10);
            _basicLayout.RowCount = 6;
            _basicLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            _basicLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            _basicLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            _basicLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            _basicLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 266F));
            _basicLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 208F));
            _basicLayout.Size = new Size(976, 667);
            _basicLayout.TabIndex = 0;
            // 
            // _lblName
            // 
            _lblName.AutoEllipsis = true;
            _lblName.Dock = DockStyle.Fill;
            _lblName.Location = new Point(10, 16);
            _lblName.Margin = new Padding(0, 6, 8, 6);
            _lblName.Name = "_lblName";
            _lblName.Size = new Size(172, 22);
            _lblName.TabIndex = 0;
            _lblName.Text = "Name *";
            // 
            // _nameBox
            // 
            _nameBox.Dock = DockStyle.Fill;
            _nameBox.Location = new Point(193, 13);
            _nameBox.MaxLength = 100;
            _nameBox.Name = "_nameBox";
            _nameBox.Size = new Size(770, 23);
            _nameBox.TabIndex = 0;
            // 
            // _lblType
            // 
            _lblType.AutoEllipsis = true;
            _lblType.Dock = DockStyle.Fill;
            _lblType.Location = new Point(10, 50);
            _lblType.Margin = new Padding(0, 6, 8, 6);
            _lblType.Name = "_lblType";
            _lblType.Size = new Size(172, 22);
            _lblType.TabIndex = 1;
            _lblType.Text = "Type";
            // 
            // _typePanel
            // 
            _typePanel.AutoSize = true;
            _typePanel.Controls.Add(_isRealisticCheck);
            _typePanel.Controls.Add(_isAnimeCheck);
            _typePanel.Dock = DockStyle.Fill;
            _typePanel.Location = new Point(193, 47);
            _typePanel.Name = "_typePanel";
            _typePanel.Size = new Size(770, 28);
            _typePanel.TabIndex = 1;
            _typePanel.WrapContents = false;
            // 
            // _isRealisticCheck
            // 
            _isRealisticCheck.AutoSize = true;
            _isRealisticCheck.Location = new Point(0, 3);
            _isRealisticCheck.Margin = new Padding(0, 3, 16, 0);
            _isRealisticCheck.Name = "_isRealisticCheck";
            _isRealisticCheck.Size = new Size(69, 19);
            _isRealisticCheck.TabIndex = 0;
            _isRealisticCheck.Text = "Realistic";
            // 
            // _isAnimeCheck
            // 
            _isAnimeCheck.AutoSize = true;
            _isAnimeCheck.Location = new Point(85, 3);
            _isAnimeCheck.Margin = new Padding(0, 3, 0, 0);
            _isAnimeCheck.Name = "_isAnimeCheck";
            _isAnimeCheck.Size = new Size(61, 19);
            _isAnimeCheck.TabIndex = 1;
            _isAnimeCheck.Text = "Anime";
            // 
            // _lblAge
            // 
            _lblAge.AutoEllipsis = true;
            _lblAge.Dock = DockStyle.Fill;
            _lblAge.Location = new Point(10, 84);
            _lblAge.Margin = new Padding(0, 6, 8, 6);
            _lblAge.Name = "_lblAge";
            _lblAge.Size = new Size(172, 22);
            _lblAge.TabIndex = 2;
            _lblAge.Text = "Age";
            // 
            // _ageNum
            // 
            _ageNum.Dock = DockStyle.Fill;
            _ageNum.Location = new Point(193, 81);
            _ageNum.Name = "_ageNum";
            _ageNum.Size = new Size(770, 23);
            _ageNum.TabIndex = 2;
            _ageNum.ThousandsSeparator = true;
            // 
            // _lblFirstReply
            // 
            _lblFirstReply.AutoEllipsis = true;
            _lblFirstReply.Dock = DockStyle.Fill;
            _lblFirstReply.Location = new Point(10, 118);
            _lblFirstReply.Margin = new Padding(0, 6, 8, 6);
            _lblFirstReply.Name = "_lblFirstReply";
            _lblFirstReply.Size = new Size(172, 22);
            _lblFirstReply.TabIndex = 3;
            _lblFirstReply.Text = "First Reply Suggestion";
            // 
            // _firstReplyBox
            // 
            _firstReplyBox.Dock = DockStyle.Fill;
            _firstReplyBox.Location = new Point(193, 115);
            _firstReplyBox.MaxLength = 100;
            _firstReplyBox.Name = "_firstReplyBox";
            _firstReplyBox.Size = new Size(770, 23);
            _firstReplyBox.TabIndex = 3;
            // 
            // _lblImages
            // 
            _lblImages.AutoEllipsis = true;
            _lblImages.Dock = DockStyle.Fill;
            _lblImages.Location = new Point(10, 152);
            _lblImages.Margin = new Padding(0, 6, 8, 6);
            _lblImages.Name = "_lblImages";
            _lblImages.Size = new Size(172, 254);
            _lblImages.TabIndex = 4;
            _lblImages.Text = "Images";
            // 
            // _imageContainer
            // 
            _imageContainer.ColumnCount = 2;
            _imageContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _imageContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _imageContainer.Controls.Add(_realTop, 0, 0);
            _imageContainer.Controls.Add(_animeTop, 1, 0);
            _imageContainer.Controls.Add(_imagePreview, 0, 1);
            _imageContainer.Controls.Add(_animeImagePreview, 1, 1);
            _imageContainer.Dock = DockStyle.Fill;
            _imageContainer.Location = new Point(190, 146);
            _imageContainer.Margin = new Padding(0);
            _imageContainer.Name = "_imageContainer";
            _imageContainer.RowCount = 2;
            _imageContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            _imageContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _imageContainer.Size = new Size(776, 266);
            _imageContainer.TabIndex = 5;
            // 
            // _realTop
            // 
            _realTop.ColumnCount = 2;
            _realTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            _realTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _realTop.Controls.Add(_realHeader, 0, 0);
            _realTop.Controls.Add(_realImageRow, 1, 0);
            _realTop.Dock = DockStyle.Fill;
            _realTop.Location = new Point(0, 0);
            _realTop.Margin = new Padding(0);
            _realTop.Name = "_realTop";
            _realTop.RowCount = 1;
            _realTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            _realTop.Size = new Size(388, 32);
            _realTop.TabIndex = 0;
            // 
            // _realHeader
            // 
            _realHeader.Dock = DockStyle.Fill;
            _realHeader.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            _realHeader.Location = new Point(3, 0);
            _realHeader.Name = "_realHeader";
            _realHeader.Size = new Size(64, 32);
            _realHeader.TabIndex = 0;
            _realHeader.Text = "Realistic:";
            _realHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _realImageRow
            // 
            _realImageRow.ColumnCount = 3;
            _realImageRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _realImageRow.ColumnStyles.Add(new ColumnStyle());
            _realImageRow.ColumnStyles.Add(new ColumnStyle());
            _realImageRow.Controls.Add(_imagePathBox, 0, 0);
            _realImageRow.Controls.Add(_browseImageBtn, 1, 0);
            _realImageRow.Controls.Add(_clearImageBtn, 2, 0);
            _realImageRow.Dock = DockStyle.Fill;
            _realImageRow.Location = new Point(70, 0);
            _realImageRow.Margin = new Padding(0);
            _realImageRow.Name = "_realImageRow";
            _realImageRow.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            _realImageRow.Size = new Size(318, 32);
            _realImageRow.TabIndex = 1;
            // 
            // _imagePathBox
            // 
            _imagePathBox.Dock = DockStyle.Fill;
            _imagePathBox.Location = new Point(3, 3);
            _imagePathBox.Name = "_imagePathBox";
            _imagePathBox.ReadOnly = true;
            _imagePathBox.Size = new Size(150, 23);
            _imagePathBox.TabIndex = 0;
            // 
            // _browseImageBtn
            // 
            _browseImageBtn.AutoSize = true;
            _browseImageBtn.Location = new Point(159, 3);
            _browseImageBtn.Name = "_browseImageBtn";
            _browseImageBtn.Size = new Size(75, 25);
            _browseImageBtn.TabIndex = 1;
            _browseImageBtn.Text = "Browse…";
            _browseImageBtn.Click += BrowseImageBtn_Click;
            // 
            // _clearImageBtn
            // 
            _clearImageBtn.AutoSize = true;
            _clearImageBtn.Location = new Point(240, 3);
            _clearImageBtn.Name = "_clearImageBtn";
            _clearImageBtn.Size = new Size(75, 25);
            _clearImageBtn.TabIndex = 2;
            _clearImageBtn.Text = "Clear";
            _clearImageBtn.Click += ClearImageBtn_Click;
            // 
            // _animeTop
            // 
            _animeTop.ColumnCount = 2;
            _animeTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55F));
            _animeTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _animeTop.Controls.Add(_animeHeader, 0, 0);
            _animeTop.Controls.Add(_animeImageRow, 1, 0);
            _animeTop.Dock = DockStyle.Fill;
            _animeTop.Location = new Point(388, 0);
            _animeTop.Margin = new Padding(0);
            _animeTop.Name = "_animeTop";
            _animeTop.RowCount = 1;
            _animeTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            _animeTop.Size = new Size(388, 32);
            _animeTop.TabIndex = 1;
            // 
            // _animeHeader
            // 
            _animeHeader.Dock = DockStyle.Fill;
            _animeHeader.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            _animeHeader.Location = new Point(6, 0);
            _animeHeader.Margin = new Padding(6, 0, 0, 0);
            _animeHeader.Name = "_animeHeader";
            _animeHeader.Size = new Size(49, 32);
            _animeHeader.TabIndex = 0;
            _animeHeader.Text = "Anime:";
            _animeHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _animeImageRow
            // 
            _animeImageRow.ColumnCount = 3;
            _animeImageRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _animeImageRow.ColumnStyles.Add(new ColumnStyle());
            _animeImageRow.ColumnStyles.Add(new ColumnStyle());
            _animeImageRow.Controls.Add(_animeImagePathBox, 0, 0);
            _animeImageRow.Controls.Add(_browseAnimeImageBtn, 1, 0);
            _animeImageRow.Controls.Add(_clearAnimeImageBtn, 2, 0);
            _animeImageRow.Dock = DockStyle.Fill;
            _animeImageRow.Location = new Point(55, 0);
            _animeImageRow.Margin = new Padding(0);
            _animeImageRow.Name = "_animeImageRow";
            _animeImageRow.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            _animeImageRow.Size = new Size(333, 32);
            _animeImageRow.TabIndex = 1;
            // 
            // _animeImagePathBox
            // 
            _animeImagePathBox.Dock = DockStyle.Fill;
            _animeImagePathBox.Location = new Point(3, 3);
            _animeImagePathBox.Name = "_animeImagePathBox";
            _animeImagePathBox.ReadOnly = true;
            _animeImagePathBox.Size = new Size(165, 23);
            _animeImagePathBox.TabIndex = 0;
            // 
            // _browseAnimeImageBtn
            // 
            _browseAnimeImageBtn.AutoSize = true;
            _browseAnimeImageBtn.Location = new Point(174, 3);
            _browseAnimeImageBtn.Name = "_browseAnimeImageBtn";
            _browseAnimeImageBtn.Size = new Size(75, 25);
            _browseAnimeImageBtn.TabIndex = 1;
            _browseAnimeImageBtn.Text = "Browse…";
            _browseAnimeImageBtn.Click += BrowseAnimeImageBtn_Click;
            // 
            // _clearAnimeImageBtn
            // 
            _clearAnimeImageBtn.AutoSize = true;
            _clearAnimeImageBtn.Location = new Point(255, 3);
            _clearAnimeImageBtn.Name = "_clearAnimeImageBtn";
            _clearAnimeImageBtn.Size = new Size(75, 25);
            _clearAnimeImageBtn.TabIndex = 2;
            _clearAnimeImageBtn.Text = "Clear";
            _clearAnimeImageBtn.Click += ClearAnimeImageBtn_Click;
            // 
            // _imagePreview
            // 
            _imagePreview.BorderStyle = BorderStyle.FixedSingle;
            _imagePreview.Dock = DockStyle.Fill;
            _imagePreview.Location = new Point(3, 35);
            _imagePreview.Name = "_imagePreview";
            _imagePreview.Size = new Size(382, 228);
            _imagePreview.SizeMode = PictureBoxSizeMode.Zoom;
            _imagePreview.TabIndex = 2;
            _imagePreview.TabStop = false;
            // 
            // _animeImagePreview
            // 
            _animeImagePreview.BorderStyle = BorderStyle.FixedSingle;
            _animeImagePreview.Dock = DockStyle.Fill;
            _animeImagePreview.Location = new Point(391, 35);
            _animeImagePreview.Name = "_animeImagePreview";
            _animeImagePreview.Size = new Size(382, 228);
            _animeImagePreview.SizeMode = PictureBoxSizeMode.Zoom;
            _animeImagePreview.TabIndex = 3;
            _animeImagePreview.TabStop = false;
            // 
            // _lblTags
            // 
            _lblTags.AutoEllipsis = true;
            _lblTags.Dock = DockStyle.Fill;
            _lblTags.Location = new Point(10, 418);
            _lblTags.Margin = new Padding(0, 6, 8, 6);
            _lblTags.Name = "_lblTags";
            _lblTags.Size = new Size(172, 233);
            _lblTags.TabIndex = 6;
            _lblTags.Text = "Tags (max 20)";
            // 
            // _tagPanel
            // 
            _tagPanel.Controls.Add(_tagList);
            _tagPanel.Controls.Add(_tagBottom);
            _tagPanel.Dock = DockStyle.Fill;
            _tagPanel.Location = new Point(193, 415);
            _tagPanel.Name = "_tagPanel";
            _tagPanel.Size = new Size(770, 239);
            _tagPanel.TabIndex = 7;
            // 
            // _tagList
            // 
            _tagList.CheckOnClick = true;
            _tagList.Dock = DockStyle.Fill;
            _tagList.IntegralHeight = false;
            _tagList.Location = new Point(0, 0);
            _tagList.Name = "_tagList";
            _tagList.Size = new Size(770, 207);
            _tagList.TabIndex = 0;
            _tagList.ItemCheck += TagList_ItemCheck;
            // 
            // _tagBottom
            // 
            _tagBottom.ColumnCount = 3;
            _tagBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _tagBottom.ColumnStyles.Add(new ColumnStyle());
            _tagBottom.ColumnStyles.Add(new ColumnStyle());
            _tagBottom.Controls.Add(_newTagBox, 0, 0);
            _tagBottom.Controls.Add(_addTagBtn, 1, 0);
            _tagBottom.Controls.Add(_tagCountLabel, 2, 0);
            _tagBottom.Dock = DockStyle.Bottom;
            _tagBottom.Location = new Point(0, 207);
            _tagBottom.Name = "_tagBottom";
            _tagBottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            _tagBottom.Size = new Size(770, 32);
            _tagBottom.TabIndex = 1;
            // 
            // _newTagBox
            // 
            _newTagBox.Dock = DockStyle.Fill;
            _newTagBox.Location = new Point(3, 3);
            _newTagBox.MaxLength = 25;
            _newTagBox.Name = "_newTagBox";
            _newTagBox.PlaceholderText = "New tag…";
            _newTagBox.Size = new Size(677, 23);
            _newTagBox.TabIndex = 0;
            _newTagBox.KeyDown += NewTagBox_KeyDown;
            // 
            // _addTagBtn
            // 
            _addTagBtn.AutoSize = true;
            _addTagBtn.Location = new Point(686, 3);
            _addTagBtn.Name = "_addTagBtn";
            _addTagBtn.Size = new Size(75, 25);
            _addTagBtn.TabIndex = 1;
            _addTagBtn.Text = "Add Tag";
            _addTagBtn.Click += AddTagBtn_Click;
            // 
            // _tagCountLabel
            // 
            _tagCountLabel.AutoSize = true;
            _tagCountLabel.Location = new Point(770, 6);
            _tagCountLabel.Margin = new Padding(6, 6, 0, 0);
            _tagCountLabel.Name = "_tagCountLabel";
            _tagCountLabel.Size = new Size(0, 15);
            _tagCountLabel.TabIndex = 2;
            // 
            // _appearanceTab
            // 
            _appearanceTab.Controls.Add(_appLayout);
            _appearanceTab.Location = new Point(4, 24);
            _appearanceTab.Name = "_appearanceTab";
            _appearanceTab.Size = new Size(976, 667);
            _appearanceTab.TabIndex = 1;
            _appearanceTab.Text = "Appearance";
            _appearanceTab.UseVisualStyleBackColor = true;
            // 
            // _appLayout
            // 
            _appLayout.AutoScroll = true;
            _appLayout.ColumnCount = 2;
            _appLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            _appLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _appLayout.Controls.Add(_lblHairStyle, 0, 0);
            _appLayout.Controls.Add(_hairStyle, 1, 0);
            _appLayout.Controls.Add(_lblBodyType, 0, 1);
            _appLayout.Controls.Add(_bodyType, 1, 1);
            _appLayout.Controls.Add(_lblEthnicity, 0, 2);
            _appLayout.Controls.Add(_ethnicity, 1, 2);
            _appLayout.Controls.Add(_lblBreastSize, 0, 3);
            _appLayout.Controls.Add(_breastSize, 1, 3);
            _appLayout.Controls.Add(_lblButtSize, 0, 4);
            _appLayout.Controls.Add(_buttSize, 1, 4);
            _appLayout.Controls.Add(_lblEyeColor, 0, 5);
            _appLayout.Controls.Add(_eyeColor, 1, 5);
            _appLayout.Controls.Add(_lblHairColor, 0, 6);
            _appLayout.Controls.Add(_hairColor, 1, 6);
            _appLayout.Controls.Add(_lblSkinTone, 0, 7);
            _appLayout.Controls.Add(_skinTone, 1, 7);
            _appLayout.Controls.Add(_lblCustomPhysical, 0, 8);
            _appLayout.Controls.Add(_customPhysical, 1, 8);
            _appLayout.Controls.Add(_lblCustomFace, 0, 9);
            _appLayout.Controls.Add(_customFace, 1, 9);
            _appLayout.Dock = DockStyle.Fill;
            _appLayout.Location = new Point(0, 0);
            _appLayout.Name = "_appLayout";
            _appLayout.Padding = new Padding(10);
            _appLayout.RowCount = 10;
            _appLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            _appLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            _appLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            _appLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            _appLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            _appLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            _appLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            _appLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            _appLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 108F));
            _appLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 108F));
            _appLayout.Size = new Size(976, 667);
            _appLayout.TabIndex = 0;
            // 
            // _lblHairStyle
            // 
            _lblHairStyle.AutoEllipsis = true;
            _lblHairStyle.Dock = DockStyle.Fill;
            _lblHairStyle.Location = new Point(10, 16);
            _lblHairStyle.Margin = new Padding(0, 6, 8, 6);
            _lblHairStyle.Name = "_lblHairStyle";
            _lblHairStyle.Size = new Size(172, 22);
            _lblHairStyle.TabIndex = 0;
            _lblHairStyle.Text = "Hair Style (250)";
            // 
            // _hairStyle
            // 
            _hairStyle.Dock = DockStyle.Fill;
            _hairStyle.Location = new Point(193, 13);
            _hairStyle.MaxLength = 250;
            _hairStyle.Name = "_hairStyle";
            _hairStyle.Size = new Size(770, 23);
            _hairStyle.TabIndex = 0;
            // 
            // _lblBodyType
            // 
            _lblBodyType.AutoEllipsis = true;
            _lblBodyType.Dock = DockStyle.Fill;
            _lblBodyType.Location = new Point(10, 50);
            _lblBodyType.Margin = new Padding(0, 6, 8, 6);
            _lblBodyType.Name = "_lblBodyType";
            _lblBodyType.Size = new Size(172, 22);
            _lblBodyType.TabIndex = 1;
            _lblBodyType.Text = "Body Type (25)";
            // 
            // _bodyType
            // 
            _bodyType.Dock = DockStyle.Fill;
            _bodyType.Location = new Point(193, 47);
            _bodyType.MaxLength = 25;
            _bodyType.Name = "_bodyType";
            _bodyType.Size = new Size(770, 23);
            _bodyType.TabIndex = 1;
            // 
            // _lblEthnicity
            // 
            _lblEthnicity.AutoEllipsis = true;
            _lblEthnicity.Dock = DockStyle.Fill;
            _lblEthnicity.Location = new Point(10, 84);
            _lblEthnicity.Margin = new Padding(0, 6, 8, 6);
            _lblEthnicity.Name = "_lblEthnicity";
            _lblEthnicity.Size = new Size(172, 22);
            _lblEthnicity.TabIndex = 2;
            _lblEthnicity.Text = "Ethnicity (50)";
            // 
            // _ethnicity
            // 
            _ethnicity.Dock = DockStyle.Fill;
            _ethnicity.Location = new Point(193, 81);
            _ethnicity.MaxLength = 50;
            _ethnicity.Name = "_ethnicity";
            _ethnicity.Size = new Size(770, 23);
            _ethnicity.TabIndex = 2;
            // 
            // _lblBreastSize
            // 
            _lblBreastSize.AutoEllipsis = true;
            _lblBreastSize.Dock = DockStyle.Fill;
            _lblBreastSize.Location = new Point(10, 118);
            _lblBreastSize.Margin = new Padding(0, 6, 8, 6);
            _lblBreastSize.Name = "_lblBreastSize";
            _lblBreastSize.Size = new Size(172, 22);
            _lblBreastSize.TabIndex = 3;
            _lblBreastSize.Text = "Breast Size (25)";
            // 
            // _breastSize
            // 
            _breastSize.Dock = DockStyle.Fill;
            _breastSize.Location = new Point(193, 115);
            _breastSize.MaxLength = 25;
            _breastSize.Name = "_breastSize";
            _breastSize.Size = new Size(770, 23);
            _breastSize.TabIndex = 3;
            // 
            // _lblButtSize
            // 
            _lblButtSize.AutoEllipsis = true;
            _lblButtSize.Dock = DockStyle.Fill;
            _lblButtSize.Location = new Point(10, 152);
            _lblButtSize.Margin = new Padding(0, 6, 8, 6);
            _lblButtSize.Name = "_lblButtSize";
            _lblButtSize.Size = new Size(172, 22);
            _lblButtSize.TabIndex = 4;
            _lblButtSize.Text = "Butt Size (50)";
            // 
            // _buttSize
            // 
            _buttSize.Dock = DockStyle.Fill;
            _buttSize.Location = new Point(193, 149);
            _buttSize.MaxLength = 50;
            _buttSize.Name = "_buttSize";
            _buttSize.Size = new Size(770, 23);
            _buttSize.TabIndex = 4;
            // 
            // _lblEyeColor
            // 
            _lblEyeColor.AutoEllipsis = true;
            _lblEyeColor.Dock = DockStyle.Fill;
            _lblEyeColor.Location = new Point(10, 186);
            _lblEyeColor.Margin = new Padding(0, 6, 8, 6);
            _lblEyeColor.Name = "_lblEyeColor";
            _lblEyeColor.Size = new Size(172, 22);
            _lblEyeColor.TabIndex = 5;
            _lblEyeColor.Text = "Eye Color (100)";
            // 
            // _eyeColor
            // 
            _eyeColor.Dock = DockStyle.Fill;
            _eyeColor.Location = new Point(193, 183);
            _eyeColor.MaxLength = 100;
            _eyeColor.Name = "_eyeColor";
            _eyeColor.Size = new Size(770, 23);
            _eyeColor.TabIndex = 5;
            // 
            // _lblHairColor
            // 
            _lblHairColor.AutoEllipsis = true;
            _lblHairColor.Dock = DockStyle.Fill;
            _lblHairColor.Location = new Point(10, 220);
            _lblHairColor.Margin = new Padding(0, 6, 8, 6);
            _lblHairColor.Name = "_lblHairColor";
            _lblHairColor.Size = new Size(172, 22);
            _lblHairColor.TabIndex = 6;
            _lblHairColor.Text = "Hair Color (100)";
            // 
            // _hairColor
            // 
            _hairColor.Dock = DockStyle.Fill;
            _hairColor.Location = new Point(193, 217);
            _hairColor.MaxLength = 100;
            _hairColor.Name = "_hairColor";
            _hairColor.Size = new Size(770, 23);
            _hairColor.TabIndex = 6;
            // 
            // _lblSkinTone
            // 
            _lblSkinTone.AutoEllipsis = true;
            _lblSkinTone.Dock = DockStyle.Fill;
            _lblSkinTone.Location = new Point(10, 254);
            _lblSkinTone.Margin = new Padding(0, 6, 8, 6);
            _lblSkinTone.Name = "_lblSkinTone";
            _lblSkinTone.Size = new Size(172, 22);
            _lblSkinTone.TabIndex = 7;
            _lblSkinTone.Text = "Skin Tone (25)";
            // 
            // _skinTone
            // 
            _skinTone.Dock = DockStyle.Fill;
            _skinTone.Location = new Point(193, 251);
            _skinTone.MaxLength = 25;
            _skinTone.Name = "_skinTone";
            _skinTone.Size = new Size(770, 23);
            _skinTone.TabIndex = 7;
            // 
            // _lblCustomPhysical
            // 
            _lblCustomPhysical.AutoEllipsis = true;
            _lblCustomPhysical.Dock = DockStyle.Fill;
            _lblCustomPhysical.Location = new Point(10, 288);
            _lblCustomPhysical.Margin = new Padding(0, 6, 8, 6);
            _lblCustomPhysical.Name = "_lblCustomPhysical";
            _lblCustomPhysical.Size = new Size(172, 96);
            _lblCustomPhysical.TabIndex = 8;
            _lblCustomPhysical.Text = "Custom Physical Details (2000)";
            // 
            // _customPhysical
            // 
            _customPhysical.AcceptsReturn = true;
            _customPhysical.Dock = DockStyle.Fill;
            _customPhysical.Location = new Point(193, 285);
            _customPhysical.MaxLength = 2000;
            _customPhysical.Multiline = true;
            _customPhysical.Name = "_customPhysical";
            _customPhysical.ScrollBars = ScrollBars.Vertical;
            _customPhysical.Size = new Size(770, 102);
            _customPhysical.TabIndex = 8;
            // 
            // _lblCustomFace
            // 
            _lblCustomFace.AutoEllipsis = true;
            _lblCustomFace.Dock = DockStyle.Fill;
            _lblCustomFace.Location = new Point(10, 396);
            _lblCustomFace.Margin = new Padding(0, 6, 8, 6);
            _lblCustomFace.Name = "_lblCustomFace";
            _lblCustomFace.Size = new Size(172, 255);
            _lblCustomFace.TabIndex = 9;
            _lblCustomFace.Text = "Custom Face Details (2000)";
            // 
            // _customFace
            // 
            _customFace.AcceptsReturn = true;
            _customFace.Dock = DockStyle.Fill;
            _customFace.Location = new Point(193, 393);
            _customFace.MaxLength = 2000;
            _customFace.Multiline = true;
            _customFace.Name = "_customFace";
            _customFace.ScrollBars = ScrollBars.Vertical;
            _customFace.Size = new Size(770, 261);
            _customFace.TabIndex = 9;
            // 
            // _personalityTab
            // 
            _personalityTab.Controls.Add(_persLayout);
            _personalityTab.Location = new Point(4, 24);
            _personalityTab.Name = "_personalityTab";
            _personalityTab.Size = new Size(976, 667);
            _personalityTab.TabIndex = 2;
            _personalityTab.Text = "Personality";
            _personalityTab.UseVisualStyleBackColor = true;
            // 
            // _persLayout
            // 
            _persLayout.AutoScroll = true;
            _persLayout.ColumnCount = 2;
            _persLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            _persLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _persLayout.Controls.Add(_lblOccupation, 0, 0);
            _persLayout.Controls.Add(_occupation, 1, 0);
            _persLayout.Controls.Add(_lblRelationship, 0, 1);
            _persLayout.Controls.Add(_relationship, 1, 1);
            _persLayout.Controls.Add(_lblHobby, 0, 2);
            _persLayout.Controls.Add(_hobby, 1, 2);
            _persLayout.Controls.Add(_lblFetish, 0, 3);
            _persLayout.Controls.Add(_fetish, 1, 3);
            _persLayout.Controls.Add(_lblPublicDesc, 0, 4);
            _persLayout.Controls.Add(_publicDesc, 1, 4);
            _persLayout.Controls.Add(_lblGreeting, 0, 5);
            _persLayout.Controls.Add(_greeting, 1, 5);
            _persLayout.Dock = DockStyle.Fill;
            _persLayout.Location = new Point(0, 0);
            _persLayout.Name = "_persLayout";
            _persLayout.Padding = new Padding(10);
            _persLayout.RowCount = 6;
            _persLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            _persLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            _persLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            _persLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            _persLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 128F));
            _persLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 128F));
            _persLayout.Size = new Size(976, 667);
            _persLayout.TabIndex = 0;
            // 
            // _lblOccupation
            // 
            _lblOccupation.AutoEllipsis = true;
            _lblOccupation.Dock = DockStyle.Fill;
            _lblOccupation.Location = new Point(10, 16);
            _lblOccupation.Margin = new Padding(0, 6, 8, 6);
            _lblOccupation.Name = "_lblOccupation";
            _lblOccupation.Size = new Size(172, 76);
            _lblOccupation.TabIndex = 0;
            _lblOccupation.Text = "Occupation (4000)";
            // 
            // _occupation
            // 
            _occupation.AcceptsReturn = true;
            _occupation.Dock = DockStyle.Fill;
            _occupation.Location = new Point(193, 13);
            _occupation.MaxLength = 4000;
            _occupation.Multiline = true;
            _occupation.Name = "_occupation";
            _occupation.ScrollBars = ScrollBars.Vertical;
            _occupation.Size = new Size(770, 82);
            _occupation.TabIndex = 0;
            // 
            // _lblRelationship
            // 
            _lblRelationship.AutoEllipsis = true;
            _lblRelationship.Dock = DockStyle.Fill;
            _lblRelationship.Location = new Point(10, 104);
            _lblRelationship.Margin = new Padding(0, 6, 8, 6);
            _lblRelationship.Name = "_lblRelationship";
            _lblRelationship.Size = new Size(172, 76);
            _lblRelationship.TabIndex = 1;
            _lblRelationship.Text = "Relationship (4000)";
            // 
            // _relationship
            // 
            _relationship.AcceptsReturn = true;
            _relationship.Dock = DockStyle.Fill;
            _relationship.Location = new Point(193, 101);
            _relationship.MaxLength = 4000;
            _relationship.Multiline = true;
            _relationship.Name = "_relationship";
            _relationship.ScrollBars = ScrollBars.Vertical;
            _relationship.Size = new Size(770, 82);
            _relationship.TabIndex = 1;
            // 
            // _lblHobby
            // 
            _lblHobby.AutoEllipsis = true;
            _lblHobby.Dock = DockStyle.Fill;
            _lblHobby.Location = new Point(10, 192);
            _lblHobby.Margin = new Padding(0, 6, 8, 6);
            _lblHobby.Name = "_lblHobby";
            _lblHobby.Size = new Size(172, 76);
            _lblHobby.TabIndex = 2;
            _lblHobby.Text = "Hobby (4000)";
            // 
            // _hobby
            // 
            _hobby.AcceptsReturn = true;
            _hobby.Dock = DockStyle.Fill;
            _hobby.Location = new Point(193, 189);
            _hobby.MaxLength = 4000;
            _hobby.Multiline = true;
            _hobby.Name = "_hobby";
            _hobby.ScrollBars = ScrollBars.Vertical;
            _hobby.Size = new Size(770, 82);
            _hobby.TabIndex = 2;
            // 
            // _lblFetish
            // 
            _lblFetish.AutoEllipsis = true;
            _lblFetish.Dock = DockStyle.Fill;
            _lblFetish.Location = new Point(10, 280);
            _lblFetish.Margin = new Padding(0, 6, 8, 6);
            _lblFetish.Name = "_lblFetish";
            _lblFetish.Size = new Size(172, 76);
            _lblFetish.TabIndex = 3;
            _lblFetish.Text = "Fetish (4000)";
            // 
            // _fetish
            // 
            _fetish.AcceptsReturn = true;
            _fetish.Dock = DockStyle.Fill;
            _fetish.Location = new Point(193, 277);
            _fetish.MaxLength = 4000;
            _fetish.Multiline = true;
            _fetish.Name = "_fetish";
            _fetish.ScrollBars = ScrollBars.Vertical;
            _fetish.Size = new Size(770, 82);
            _fetish.TabIndex = 3;
            // 
            // _lblPublicDesc
            // 
            _lblPublicDesc.AutoEllipsis = true;
            _lblPublicDesc.Dock = DockStyle.Fill;
            _lblPublicDesc.Location = new Point(10, 368);
            _lblPublicDesc.Margin = new Padding(0, 6, 8, 6);
            _lblPublicDesc.Name = "_lblPublicDesc";
            _lblPublicDesc.Size = new Size(172, 116);
            _lblPublicDesc.TabIndex = 4;
            _lblPublicDesc.Text = "Public Description (10000)";
            // 
            // _publicDesc
            // 
            _publicDesc.AcceptsReturn = true;
            _publicDesc.Dock = DockStyle.Fill;
            _publicDesc.Location = new Point(193, 365);
            _publicDesc.MaxLength = 10000;
            _publicDesc.Multiline = true;
            _publicDesc.Name = "_publicDesc";
            _publicDesc.ScrollBars = ScrollBars.Vertical;
            _publicDesc.Size = new Size(770, 122);
            _publicDesc.TabIndex = 4;
            // 
            // _lblGreeting
            // 
            _lblGreeting.AutoEllipsis = true;
            _lblGreeting.Dock = DockStyle.Fill;
            _lblGreeting.Location = new Point(10, 496);
            _lblGreeting.Margin = new Padding(0, 6, 8, 6);
            _lblGreeting.Name = "_lblGreeting";
            _lblGreeting.Size = new Size(172, 155);
            _lblGreeting.TabIndex = 5;
            _lblGreeting.Text = "Greeting (10000)";
            // 
            // _greeting
            // 
            _greeting.AcceptsReturn = true;
            _greeting.Dock = DockStyle.Fill;
            _greeting.Location = new Point(193, 493);
            _greeting.MaxLength = 10000;
            _greeting.Multiline = true;
            _greeting.Name = "_greeting";
            _greeting.ScrollBars = ScrollBars.Vertical;
            _greeting.Size = new Size(770, 161);
            _greeting.TabIndex = 5;
            // 
            // _scenarioTab
            // 
            _scenarioTab.Controls.Add(_scenarioBox);
            _scenarioTab.Location = new Point(4, 24);
            _scenarioTab.Name = "_scenarioTab";
            _scenarioTab.Padding = new Padding(10);
            _scenarioTab.Size = new Size(192, 72);
            _scenarioTab.TabIndex = 3;
            _scenarioTab.Text = "Scenario (50,000)";
            _scenarioTab.UseVisualStyleBackColor = true;
            // 
            // _scenarioBox
            // 
            _scenarioBox.AcceptsReturn = true;
            _scenarioBox.Dock = DockStyle.Fill;
            _scenarioBox.Location = new Point(10, 10);
            _scenarioBox.MaxLength = 50000;
            _scenarioBox.Multiline = true;
            _scenarioBox.Name = "_scenarioBox";
            _scenarioBox.ScrollBars = ScrollBars.Vertical;
            _scenarioBox.Size = new Size(172, 52);
            _scenarioBox.TabIndex = 0;
            // 
            // _additionalTab
            // 
            _additionalTab.Controls.Add(_additionalBox);
            _additionalTab.Location = new Point(4, 24);
            _additionalTab.Name = "_additionalTab";
            _additionalTab.Padding = new Padding(10);
            _additionalTab.Size = new Size(192, 72);
            _additionalTab.TabIndex = 4;
            _additionalTab.Text = "Additional Personality (50,000)";
            _additionalTab.UseVisualStyleBackColor = true;
            // 
            // _additionalBox
            // 
            _additionalBox.AcceptsReturn = true;
            _additionalBox.Dock = DockStyle.Fill;
            _additionalBox.Location = new Point(10, 10);
            _additionalBox.MaxLength = 50000;
            _additionalBox.Multiline = true;
            _additionalBox.Name = "_additionalBox";
            _additionalBox.ScrollBars = ScrollBars.Vertical;
            _additionalBox.Size = new Size(172, 52);
            _additionalBox.TabIndex = 0;
            // 
            // _extraTab
            // 
            _extraTab.Controls.Add(_extraBox);
            _extraTab.Location = new Point(4, 24);
            _extraTab.Name = "_extraTab";
            _extraTab.Padding = new Padding(10);
            _extraTab.Size = new Size(192, 72);
            _extraTab.TabIndex = 5;
            _extraTab.Text = "Extra Details (100,000)";
            _extraTab.UseVisualStyleBackColor = true;
            // 
            // _extraBox
            // 
            _extraBox.DetectUrls = false;
            _extraBox.Dock = DockStyle.Fill;
            _extraBox.Location = new Point(10, 10);
            _extraBox.MaxLength = 100000;
            _extraBox.Name = "_extraBox";
            _extraBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            _extraBox.Size = new Size(172, 52);
            _extraBox.TabIndex = 0;
            _extraBox.Text = "";
            _extraBox.Enter += ExtraBox_Enter;
            _extraBox.Leave += ExtraBox_Leave;
            // 
            // _buttonPanel
            // 
            _buttonPanel.Controls.Add(_cancelBtn);
            _buttonPanel.Controls.Add(_saveBtn);
            _buttonPanel.Dock = DockStyle.Bottom;
            _buttonPanel.FlowDirection = FlowDirection.RightToLeft;
            _buttonPanel.Location = new Point(0, 695);
            _buttonPanel.Name = "_buttonPanel";
            _buttonPanel.Padding = new Padding(10);
            _buttonPanel.Size = new Size(984, 46);
            _buttonPanel.TabIndex = 1;
            // 
            // _cancelBtn
            // 
            _cancelBtn.AutoSize = true;
            _cancelBtn.DialogResult = DialogResult.Cancel;
            _cancelBtn.Location = new Point(886, 13);
            _cancelBtn.Name = "_cancelBtn";
            _cancelBtn.Size = new Size(75, 25);
            _cancelBtn.TabIndex = 0;
            _cancelBtn.Text = "Cancel";
            _cancelBtn.Click += CancelBtn_Click;
            // 
            // _saveBtn
            // 
            _saveBtn.AutoSize = true;
            _saveBtn.Location = new Point(805, 13);
            _saveBtn.Name = "_saveBtn";
            _saveBtn.Size = new Size(75, 25);
            _saveBtn.TabIndex = 1;
            _saveBtn.Text = "Save";
            _saveBtn.Click += SaveBtn_Click;
            // 
            // CharacterEditForm
            // 
            AcceptButton = _saveBtn;
            CancelButton = _cancelBtn;
            ClientSize = new Size(984, 741);
            Controls.Add(_tabs);
            Controls.Add(_buttonPanel);
            MinimumSize = new Size(850, 600);
            Name = "CharacterEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "New Character";
            _tabs.ResumeLayout(false);
            _basicTab.ResumeLayout(false);
            _basicLayout.ResumeLayout(false);
            _basicLayout.PerformLayout();
            _typePanel.ResumeLayout(false);
            _typePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_ageNum).EndInit();
            _imageContainer.ResumeLayout(false);
            _realTop.ResumeLayout(false);
            _realImageRow.ResumeLayout(false);
            _realImageRow.PerformLayout();
            _animeTop.ResumeLayout(false);
            _animeImageRow.ResumeLayout(false);
            _animeImageRow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_imagePreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)_animeImagePreview).EndInit();
            _tagPanel.ResumeLayout(false);
            _tagBottom.ResumeLayout(false);
            _tagBottom.PerformLayout();
            _appearanceTab.ResumeLayout(false);
            _appLayout.ResumeLayout(false);
            _appLayout.PerformLayout();
            _personalityTab.ResumeLayout(false);
            _persLayout.ResumeLayout(false);
            _persLayout.PerformLayout();
            _scenarioTab.ResumeLayout(false);
            _scenarioTab.PerformLayout();
            _additionalTab.ResumeLayout(false);
            _additionalTab.PerformLayout();
            _extraTab.ResumeLayout(false);
            _buttonPanel.ResumeLayout(false);
            _buttonPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl _tabs;

        private System.Windows.Forms.TabPage _basicTab;
        private System.Windows.Forms.TableLayoutPanel _basicLayout;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.TextBox _nameBox;
        private System.Windows.Forms.Label _lblType;
        private System.Windows.Forms.FlowLayoutPanel _typePanel;
        private System.Windows.Forms.CheckBox _isRealisticCheck;
        private System.Windows.Forms.CheckBox _isAnimeCheck;
        private System.Windows.Forms.Label _lblAge;
        private System.Windows.Forms.NumericUpDown _ageNum;
        private System.Windows.Forms.Label _lblFirstReply;
        private System.Windows.Forms.TextBox _firstReplyBox;
        private System.Windows.Forms.Label _lblImages;
        private System.Windows.Forms.TableLayoutPanel _imageContainer;
        private System.Windows.Forms.TableLayoutPanel _realTop;
        private System.Windows.Forms.Label _realHeader;
        private System.Windows.Forms.TableLayoutPanel _realImageRow;
        private System.Windows.Forms.TextBox _imagePathBox;
        private System.Windows.Forms.Button _browseImageBtn;
        private System.Windows.Forms.Button _clearImageBtn;
        private System.Windows.Forms.TableLayoutPanel _animeTop;
        private System.Windows.Forms.Label _animeHeader;
        private System.Windows.Forms.TableLayoutPanel _animeImageRow;
        private System.Windows.Forms.TextBox _animeImagePathBox;
        private System.Windows.Forms.Button _browseAnimeImageBtn;
        private System.Windows.Forms.Button _clearAnimeImageBtn;
        private System.Windows.Forms.PictureBox _imagePreview;
        private System.Windows.Forms.PictureBox _animeImagePreview;
        private System.Windows.Forms.Label _lblTags;
        private System.Windows.Forms.Panel _tagPanel;
        private System.Windows.Forms.CheckedListBox _tagList;
        private System.Windows.Forms.TableLayoutPanel _tagBottom;
        private System.Windows.Forms.TextBox _newTagBox;
        private System.Windows.Forms.Button _addTagBtn;
        private System.Windows.Forms.Label _tagCountLabel;

        private System.Windows.Forms.TabPage _appearanceTab;
        private System.Windows.Forms.TableLayoutPanel _appLayout;
        private System.Windows.Forms.Label _lblHairStyle;
        private System.Windows.Forms.TextBox _hairStyle;
        private System.Windows.Forms.Label _lblBodyType;
        private System.Windows.Forms.TextBox _bodyType;
        private System.Windows.Forms.Label _lblEthnicity;
        private System.Windows.Forms.TextBox _ethnicity;
        private System.Windows.Forms.Label _lblBreastSize;
        private System.Windows.Forms.TextBox _breastSize;
        private System.Windows.Forms.Label _lblButtSize;
        private System.Windows.Forms.TextBox _buttSize;
        private System.Windows.Forms.Label _lblEyeColor;
        private System.Windows.Forms.TextBox _eyeColor;
        private System.Windows.Forms.Label _lblHairColor;
        private System.Windows.Forms.TextBox _hairColor;
        private System.Windows.Forms.Label _lblSkinTone;
        private System.Windows.Forms.TextBox _skinTone;
        private System.Windows.Forms.Label _lblCustomPhysical;
        private System.Windows.Forms.TextBox _customPhysical;
        private System.Windows.Forms.Label _lblCustomFace;
        private System.Windows.Forms.TextBox _customFace;

        private System.Windows.Forms.TabPage _personalityTab;
        private System.Windows.Forms.TableLayoutPanel _persLayout;
        private System.Windows.Forms.Label _lblOccupation;
        private System.Windows.Forms.TextBox _occupation;
        private System.Windows.Forms.Label _lblRelationship;
        private System.Windows.Forms.TextBox _relationship;
        private System.Windows.Forms.Label _lblHobby;
        private System.Windows.Forms.TextBox _hobby;
        private System.Windows.Forms.Label _lblFetish;
        private System.Windows.Forms.TextBox _fetish;
        private System.Windows.Forms.Label _lblPublicDesc;
        private System.Windows.Forms.TextBox _publicDesc;
        private System.Windows.Forms.Label _lblGreeting;
        private System.Windows.Forms.TextBox _greeting;

        private System.Windows.Forms.TabPage _scenarioTab;
        private System.Windows.Forms.TextBox _scenarioBox;

        private System.Windows.Forms.TabPage _additionalTab;
        private System.Windows.Forms.TextBox _additionalBox;

        private System.Windows.Forms.TabPage _extraTab;
        private System.Windows.Forms.RichTextBox _extraBox;

        private System.Windows.Forms.FlowLayoutPanel _buttonPanel;
        private System.Windows.Forms.Button _cancelBtn;
        private System.Windows.Forms.Button _saveBtn;
    }
}
