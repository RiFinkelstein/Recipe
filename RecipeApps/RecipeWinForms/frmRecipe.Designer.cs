namespace RecipeWinForms
{
    partial class frmRecipe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            tblMain = new TableLayoutPanel();
            lblCaptionCalories = new Label();
            txtCalories = new TextBox();
            lblCaptionRecipeName = new Label();
            txtRecipeName = new TextBox();
            lblCaptionCuisine = new Label();
            lstCuisineName = new ComboBox();
            tbRecipeChildRecords = new TabControl();
            tbIngredients = new TabPage();
            tblIngredients = new TableLayoutPanel();
            btnSaveIngredients = new Button();
            gIngredients = new DataGridView();
            tbSteps = new TabPage();
            tblSteps = new TableLayoutPanel();
            btnSaveRecipeDirections = new Button();
            gSteps = new DataGridView();
            tblRecipeButtons = new TableLayoutPanel();
            btnSaveRecipe = new Button();
            btnDeleteRecipe = new Button();
            btnChangeStatusRecipe = new Button();
            lblCaptionRecipeStatus = new Label();
            lblCaptionUser = new Label();
            lstUsersName = new ComboBox();
            tblStatus = new TableLayoutPanel();
            txtDraftedDate = new TextBox();
            lblStatusDates = new Label();
            lblCaptionDraftedDate = new Label();
            lblCaptionPublishedDate = new Label();
            txtArchivedDate = new TextBox();
            lblCaptionArchivedDate = new Label();
            txtPublishedDate = new TextBox();
            txtRecipeStatus = new TextBox();
            btnSave = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnDelete = new ToolStripButton();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            tblMain.SuspendLayout();
            tbRecipeChildRecords.SuspendLayout();
            tbIngredients.SuspendLayout();
            tblIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gIngredients).BeginInit();
            tbSteps.SuspendLayout();
            tblSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gSteps).BeginInit();
            tblRecipeButtons.SuspendLayout();
            tblStatus.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(lblCaptionCalories, 0, 4);
            tblMain.Controls.Add(txtCalories, 1, 4);
            tblMain.Controls.Add(lblCaptionRecipeName, 0, 1);
            tblMain.Controls.Add(txtRecipeName, 1, 1);
            tblMain.Controls.Add(lblCaptionCuisine, 0, 3);
            tblMain.Controls.Add(lstCuisineName, 1, 3);
            tblMain.Controls.Add(tbRecipeChildRecords, 0, 8);
            tblMain.Controls.Add(tblRecipeButtons, 0, 0);
            tblMain.Controls.Add(lblCaptionRecipeStatus, 0, 5);
            tblMain.Controls.Add(lblCaptionUser, 0, 2);
            tblMain.Controls.Add(lstUsersName, 1, 2);
            tblMain.Controls.Add(tblStatus, 0, 7);
            tblMain.Controls.Add(txtRecipeStatus, 1, 5);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(6);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 7;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(1976, 1343);
            tblMain.TabIndex = 0;
            // 
            // lblCaptionCalories
            // 
            lblCaptionCalories.Anchor = AnchorStyles.Left;
            lblCaptionCalories.AutoSize = true;
            lblCaptionCalories.Location = new Point(6, 288);
            lblCaptionCalories.Margin = new Padding(6, 0, 6, 0);
            lblCaptionCalories.Name = "lblCaptionCalories";
            lblCaptionCalories.Size = new Size(196, 41);
            lblCaptionCalories.TabIndex = 1;
            lblCaptionCalories.Text = "Num Calories";
            // 
            // txtCalories
            // 
            txtCalories.Anchor = AnchorStyles.Left;
            txtCalories.Location = new Point(994, 285);
            txtCalories.Margin = new Padding(6);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(877, 47);
            txtCalories.TabIndex = 7;
            // 
            // lblCaptionRecipeName
            // 
            lblCaptionRecipeName.Anchor = AnchorStyles.Left;
            lblCaptionRecipeName.AutoSize = true;
            lblCaptionRecipeName.Location = new Point(6, 107);
            lblCaptionRecipeName.Margin = new Padding(6, 0, 6, 0);
            lblCaptionRecipeName.Name = "lblCaptionRecipeName";
            lblCaptionRecipeName.Size = new Size(193, 41);
            lblCaptionRecipeName.TabIndex = 0;
            lblCaptionRecipeName.Text = "Recipe Name";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Anchor = AnchorStyles.Left;
            txtRecipeName.Location = new Point(994, 104);
            txtRecipeName.Margin = new Padding(6);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(877, 47);
            txtRecipeName.TabIndex = 6;
            // 
            // lblCaptionCuisine
            // 
            lblCaptionCuisine.Anchor = AnchorStyles.Left;
            lblCaptionCuisine.AutoSize = true;
            lblCaptionCuisine.Location = new Point(6, 228);
            lblCaptionCuisine.Margin = new Padding(6, 0, 6, 0);
            lblCaptionCuisine.Name = "lblCaptionCuisine";
            lblCaptionCuisine.Size = new Size(114, 41);
            lblCaptionCuisine.TabIndex = 21;
            lblCaptionCuisine.Text = "Cuisine";
            // 
            // lstCuisineName
            // 
            lstCuisineName.Anchor = AnchorStyles.Left;
            lstCuisineName.FormattingEnabled = true;
            lstCuisineName.Location = new Point(994, 224);
            lstCuisineName.Margin = new Padding(6);
            lstCuisineName.Name = "lstCuisineName";
            lstCuisineName.Size = new Size(877, 49);
            lstCuisineName.TabIndex = 24;
            // 
            // tbRecipeChildRecords
            // 
            tblMain.SetColumnSpan(tbRecipeChildRecords, 2);
            tbRecipeChildRecords.Controls.Add(tbIngredients);
            tbRecipeChildRecords.Controls.Add(tbSteps);
            tbRecipeChildRecords.Dock = DockStyle.Fill;
            tbRecipeChildRecords.Location = new Point(6, 501);
            tbRecipeChildRecords.Margin = new Padding(6);
            tbRecipeChildRecords.Name = "tbRecipeChildRecords";
            tblMain.SetRowSpan(tbRecipeChildRecords, 2);
            tbRecipeChildRecords.SelectedIndex = 0;
            tbRecipeChildRecords.Size = new Size(1964, 836);
            tbRecipeChildRecords.TabIndex = 25;
            // 
            // tbIngredients
            // 
            tbIngredients.Controls.Add(tblIngredients);
            tbIngredients.Location = new Point(10, 58);
            tbIngredients.Margin = new Padding(6);
            tbIngredients.Name = "tbIngredients";
            tbIngredients.Padding = new Padding(6);
            tbIngredients.Size = new Size(1944, 768);
            tbIngredients.TabIndex = 0;
            tbIngredients.Text = "Ingredients";
            tbIngredients.UseVisualStyleBackColor = true;
            // 
            // tblIngredients
            // 
            tblIngredients.ColumnCount = 1;
            tblIngredients.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblIngredients.Controls.Add(btnSaveIngredients, 0, 0);
            tblIngredients.Controls.Add(gIngredients, 0, 1);
            tblIngredients.Dock = DockStyle.Fill;
            tblIngredients.Location = new Point(6, 6);
            tblIngredients.Margin = new Padding(6);
            tblIngredients.Name = "tblIngredients";
            tblIngredients.RowCount = 2;
            tblIngredients.RowStyles.Add(new RowStyle());
            tblIngredients.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblIngredients.Size = new Size(1932, 756);
            tblIngredients.TabIndex = 0;
            // 
            // btnSaveIngredients
            // 
            btnSaveIngredients.AutoSize = true;
            btnSaveIngredients.Location = new Point(21, 20);
            btnSaveIngredients.Margin = new Padding(21, 20, 21, 20);
            btnSaveIngredients.Name = "btnSaveIngredients";
            btnSaveIngredients.Size = new Size(200, 105);
            btnSaveIngredients.TabIndex = 0;
            btnSaveIngredients.Text = "Save";
            btnSaveIngredients.UseVisualStyleBackColor = true;
            // 
            // gIngredients
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gIngredients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gIngredients.DefaultCellStyle = dataGridViewCellStyle2;
            gIngredients.Dock = DockStyle.Fill;
            gIngredients.Location = new Point(6, 151);
            gIngredients.Margin = new Padding(6);
            gIngredients.Name = "gIngredients";
            gIngredients.RowHeadersWidth = 51;
            gIngredients.Size = new Size(1920, 599);
            gIngredients.TabIndex = 1;
            // 
            // tbSteps
            // 
            tbSteps.Controls.Add(tblSteps);
            tbSteps.Location = new Point(10, 58);
            tbSteps.Margin = new Padding(6);
            tbSteps.Name = "tbSteps";
            tbSteps.Padding = new Padding(6);
            tbSteps.Size = new Size(1944, 768);
            tbSteps.TabIndex = 1;
            tbSteps.Text = "Steps";
            tbSteps.UseVisualStyleBackColor = true;
            // 
            // tblSteps
            // 
            tblSteps.ColumnCount = 1;
            tblSteps.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblSteps.Controls.Add(btnSaveRecipeDirections, 0, 0);
            tblSteps.Controls.Add(gSteps, 0, 1);
            tblSteps.Dock = DockStyle.Fill;
            tblSteps.Location = new Point(6, 6);
            tblSteps.Margin = new Padding(6);
            tblSteps.Name = "tblSteps";
            tblSteps.RowCount = 2;
            tblSteps.RowStyles.Add(new RowStyle());
            tblSteps.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblSteps.Size = new Size(1932, 756);
            tblSteps.TabIndex = 0;
            // 
            // btnSaveRecipeDirections
            // 
            btnSaveRecipeDirections.Location = new Point(21, 20);
            btnSaveRecipeDirections.Margin = new Padding(21, 20, 21, 20);
            btnSaveRecipeDirections.Name = "btnSaveRecipeDirections";
            btnSaveRecipeDirections.Size = new Size(200, 59);
            btnSaveRecipeDirections.TabIndex = 0;
            btnSaveRecipeDirections.Text = "Save";
            btnSaveRecipeDirections.UseVisualStyleBackColor = true;
            // 
            // gSteps
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            gSteps.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gSteps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            gSteps.DefaultCellStyle = dataGridViewCellStyle4;
            gSteps.Dock = DockStyle.Fill;
            gSteps.Location = new Point(6, 105);
            gSteps.Margin = new Padding(6);
            gSteps.Name = "gSteps";
            gSteps.RowHeadersWidth = 51;
            gSteps.Size = new Size(1920, 645);
            gSteps.TabIndex = 1;
            // 
            // tblRecipeButtons
            // 
            tblRecipeButtons.ColumnCount = 3;
            tblMain.SetColumnSpan(tblRecipeButtons, 2);
            tblRecipeButtons.ColumnStyles.Add(new ColumnStyle());
            tblRecipeButtons.ColumnStyles.Add(new ColumnStyle());
            tblRecipeButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblRecipeButtons.Controls.Add(btnSaveRecipe, 0, 0);
            tblRecipeButtons.Controls.Add(btnDeleteRecipe, 1, 0);
            tblRecipeButtons.Controls.Add(btnChangeStatusRecipe, 2, 0);
            tblRecipeButtons.Location = new Point(6, 6);
            tblRecipeButtons.Margin = new Padding(6);
            tblRecipeButtons.Name = "tblRecipeButtons";
            tblRecipeButtons.RowCount = 1;
            tblRecipeButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblRecipeButtons.Size = new Size(1964, 86);
            tblRecipeButtons.TabIndex = 27;
            // 
            // btnSaveRecipe
            // 
            btnSaveRecipe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnSaveRecipe.AutoSize = true;
            btnSaveRecipe.Location = new Point(21, 20);
            btnSaveRecipe.Margin = new Padding(21, 20, 21, 20);
            btnSaveRecipe.Name = "btnSaveRecipe";
            btnSaveRecipe.Size = new Size(200, 46);
            btnSaveRecipe.TabIndex = 0;
            btnSaveRecipe.Text = "Save";
            btnSaveRecipe.UseVisualStyleBackColor = true;
            // 
            // btnDeleteRecipe
            // 
            btnDeleteRecipe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnDeleteRecipe.AutoSize = true;
            btnDeleteRecipe.Location = new Point(263, 20);
            btnDeleteRecipe.Margin = new Padding(21, 20, 21, 20);
            btnDeleteRecipe.Name = "btnDeleteRecipe";
            btnDeleteRecipe.Size = new Size(242, 46);
            btnDeleteRecipe.TabIndex = 1;
            btnDeleteRecipe.Text = "Delete";
            btnDeleteRecipe.UseVisualStyleBackColor = true;
            // 
            // btnChangeStatusRecipe
            // 
            btnChangeStatusRecipe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnChangeStatusRecipe.AutoSize = true;
            btnChangeStatusRecipe.Location = new Point(1480, 20);
            btnChangeStatusRecipe.Margin = new Padding(21, 20, 21, 20);
            btnChangeStatusRecipe.Name = "btnChangeStatusRecipe";
            btnChangeStatusRecipe.Size = new Size(463, 46);
            btnChangeStatusRecipe.TabIndex = 2;
            btnChangeStatusRecipe.Text = "Change Status";
            btnChangeStatusRecipe.UseVisualStyleBackColor = true;
            // 
            // lblCaptionRecipeStatus
            // 
            lblCaptionRecipeStatus.AutoSize = true;
            lblCaptionRecipeStatus.Location = new Point(6, 338);
            lblCaptionRecipeStatus.Margin = new Padding(6, 0, 6, 0);
            lblCaptionRecipeStatus.Name = "lblCaptionRecipeStatus";
            lblCaptionRecipeStatus.Size = new Size(205, 41);
            lblCaptionRecipeStatus.TabIndex = 5;
            lblCaptionRecipeStatus.Text = "Current Status";
            // 
            // lblCaptionUser
            // 
            lblCaptionUser.AutoSize = true;
            lblCaptionUser.Location = new Point(6, 157);
            lblCaptionUser.Margin = new Padding(6, 0, 6, 0);
            lblCaptionUser.Name = "lblCaptionUser";
            lblCaptionUser.Size = new Size(78, 41);
            lblCaptionUser.TabIndex = 30;
            lblCaptionUser.Text = "User";
            // 
            // lstUsersName
            // 
            lstUsersName.FormattingEnabled = true;
            lstUsersName.Location = new Point(994, 163);
            lstUsersName.Margin = new Padding(6);
            lstUsersName.Name = "lstUsersName";
            lstUsersName.Size = new Size(877, 49);
            lstUsersName.TabIndex = 31;
            // 
            // tblStatus
            // 
            tblStatus.ColumnCount = 4;
            tblMain.SetColumnSpan(tblStatus, 2);
            tblStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.9950027F));
            tblStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.668335F));
            tblStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.668335F));
            tblStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.668335F));
            tblStatus.Controls.Add(txtDraftedDate, 0, 1);
            tblStatus.Controls.Add(lblStatusDates, 0, 0);
            tblStatus.Controls.Add(lblCaptionDraftedDate, 1, 0);
            tblStatus.Controls.Add(lblCaptionPublishedDate, 2, 0);
            tblStatus.Controls.Add(txtArchivedDate, 3, 1);
            tblStatus.Controls.Add(lblCaptionArchivedDate, 3, 0);
            tblStatus.Controls.Add(txtPublishedDate, 2, 1);
            tblStatus.Dock = DockStyle.Fill;
            tblStatus.Location = new Point(6, 403);
            tblStatus.Margin = new Padding(6);
            tblStatus.Name = "tblStatus";
            tblStatus.RowCount = 2;
            tblStatus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblStatus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblStatus.Size = new Size(1964, 86);
            tblStatus.TabIndex = 29;
            // 
            // txtDraftedDate
            // 
            txtDraftedDate.Dock = DockStyle.Fill;
            txtDraftedDate.Enabled = false;
            txtDraftedDate.Location = new Point(987, 49);
            txtDraftedDate.Margin = new Padding(6);
            txtDraftedDate.Name = "txtDraftedDate";
            txtDraftedDate.ReadOnly = true;
            txtDraftedDate.Size = new Size(315, 47);
            txtDraftedDate.TabIndex = 19;
            // 
            // lblStatusDates
            // 
            lblStatusDates.AutoSize = true;
            lblStatusDates.Dock = DockStyle.Fill;
            lblStatusDates.Location = new Point(6, 0);
            lblStatusDates.Margin = new Padding(6, 0, 6, 0);
            lblStatusDates.Name = "lblStatusDates";
            tblStatus.SetRowSpan(lblStatusDates, 2);
            lblStatusDates.Size = new Size(969, 86);
            lblStatusDates.TabIndex = 0;
            lblStatusDates.Text = "Status Dates";
            lblStatusDates.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCaptionDraftedDate
            // 
            lblCaptionDraftedDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCaptionDraftedDate.AutoSize = true;
            lblCaptionDraftedDate.Location = new Point(987, 0);
            lblCaptionDraftedDate.Margin = new Padding(6, 0, 6, 0);
            lblCaptionDraftedDate.Name = "lblCaptionDraftedDate";
            lblCaptionDraftedDate.Size = new Size(315, 41);
            lblCaptionDraftedDate.TabIndex = 1;
            lblCaptionDraftedDate.Text = "Drafted";
            lblCaptionDraftedDate.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblCaptionPublishedDate
            // 
            lblCaptionPublishedDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCaptionPublishedDate.AutoSize = true;
            lblCaptionPublishedDate.Location = new Point(1314, 0);
            lblCaptionPublishedDate.Margin = new Padding(6, 0, 6, 0);
            lblCaptionPublishedDate.Name = "lblCaptionPublishedDate";
            lblCaptionPublishedDate.Size = new Size(315, 41);
            lblCaptionPublishedDate.TabIndex = 2;
            lblCaptionPublishedDate.Text = "Published";
            lblCaptionPublishedDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtArchivedDate
            // 
            txtArchivedDate.Dock = DockStyle.Fill;
            txtArchivedDate.Enabled = false;
            txtArchivedDate.Location = new Point(1641, 49);
            txtArchivedDate.Margin = new Padding(6);
            txtArchivedDate.Name = "txtArchivedDate";
            txtArchivedDate.ReadOnly = true;
            txtArchivedDate.Size = new Size(317, 47);
            txtArchivedDate.TabIndex = 18;
            // 
            // lblCaptionArchivedDate
            // 
            lblCaptionArchivedDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCaptionArchivedDate.AutoSize = true;
            lblCaptionArchivedDate.Location = new Point(1641, 0);
            lblCaptionArchivedDate.Margin = new Padding(6, 0, 6, 0);
            lblCaptionArchivedDate.Name = "lblCaptionArchivedDate";
            lblCaptionArchivedDate.Size = new Size(317, 41);
            lblCaptionArchivedDate.TabIndex = 3;
            lblCaptionArchivedDate.Text = "Archived";
            lblCaptionArchivedDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtPublishedDate
            // 
            txtPublishedDate.Dock = DockStyle.Fill;
            txtPublishedDate.Enabled = false;
            txtPublishedDate.Location = new Point(1314, 49);
            txtPublishedDate.Margin = new Padding(6);
            txtPublishedDate.Name = "txtPublishedDate";
            txtPublishedDate.ReadOnly = true;
            txtPublishedDate.Size = new Size(315, 47);
            txtPublishedDate.TabIndex = 8;
            // 
            // txtRecipeStatus
            // 
            txtRecipeStatus.Enabled = false;
            txtRecipeStatus.Location = new Point(994, 344);
            txtRecipeStatus.Margin = new Padding(6);
            txtRecipeStatus.Name = "txtRecipeStatus";
            txtRecipeStatus.Size = new Size(261, 47);
            txtRecipeStatus.TabIndex = 32;
            // 
            // btnSave
            // 
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(23, 23);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 6);
            // 
            // btnDelete
            // 
            btnDelete.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(57, 24);
            btnDelete.Text = "Delete";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1976, 1343);
            Controls.Add(tblMain);
            Margin = new Padding(6);
            Name = "frmRecipe";
            Text = "Recipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tbRecipeChildRecords.ResumeLayout(false);
            tbIngredients.ResumeLayout(false);
            tblIngredients.ResumeLayout(false);
            tblIngredients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gIngredients).EndInit();
            tbSteps.ResumeLayout(false);
            tblSteps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gSteps).EndInit();
            tblRecipeButtons.ResumeLayout(false);
            tblRecipeButtons.PerformLayout();
            tblStatus.ResumeLayout(false);
            tblStatus.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblCaptionRecipeName;
        private Label lblCaptionCalories;
        private Label lblCaptionStatus;
        private TextBox txtCalories;
        private TextBox txtPublishedDate;
        private ToolStripButton btnSave;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnDelete;
        private DateTimePicker dtpPublishedDate;
        private TextBox txtArchivedDate;
        private TextBox txtRecipeName;
        private TextBox txtStatus;
        private Label lblCaptionCuisine;
        private ComboBox lstCuisineName;
        private TabControl tbRecipeChildRecords;
        private TabPage tbIngredients;
        private TabPage tbSteps;
        private TableLayoutPanel tblIngredients;
        private Button btnSaveIngredients;
        private DataGridView gIngredients;
        private TableLayoutPanel tblSteps;
        private Button btnSaveRecipeDirections;
        private DataGridView gSteps;
        private TableLayoutPanel tblRecipeButtons;
        private Button btnSaveRecipe;
        private Button btnDeleteRecipe;
        private Button btnChangeStatusRecipe;
        private Label lblCaptionRecipeStatus;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private TableLayoutPanel tblStatus;
        private Label lblStatusDates;
        private Label lblCaptionDraftedDate;
        private Label lblCaptionPublishedDate;
        private Label lblCaptionArchivedDate;
        private Label lblCaptionUser;
        private ComboBox lstUsersName;
        private TextBox txtRecipeStatus;
        private TextBox txtDraftedDate;
    }
}