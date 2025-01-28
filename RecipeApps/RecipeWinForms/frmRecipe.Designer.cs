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
            tblMain = new TableLayoutPanel();
            lblCaptionCalories = new Label();
            lblCaptionArchivedDate = new Label();
            lblCaptionRecipeStatus = new Label();
            txtCalories = new TextBox();
            txtArchivedDate = new TextBox();
            txtRecipeStatus = new TextBox();
            lblCaptionPublishedDate = new Label();
            txtPublishedDate = new TextBox();
            lblCaptionDraftedDate = new Label();
            lblCaptionRecipeName = new Label();
            txtRecipeName = new TextBox();
            lblcaptionUser = new Label();
            lblCaptionCuisine = new Label();
            lstUsersName = new ComboBox();
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
            dtpDraftedDate = new DateTimePicker();
            btnSave = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnDelete = new ToolStripButton();
            tblMain.SuspendLayout();
            tbRecipeChildRecords.SuspendLayout();
            tbIngredients.SuspendLayout();
            tblIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gIngredients).BeginInit();
            tbSteps.SuspendLayout();
            tblSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gSteps).BeginInit();
            tblRecipeButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(lblCaptionCalories, 0, 4);
            tblMain.Controls.Add(lblCaptionArchivedDate, 0, 7);
            tblMain.Controls.Add(lblCaptionRecipeStatus, 0, 8);
            tblMain.Controls.Add(txtCalories, 1, 4);
            tblMain.Controls.Add(txtArchivedDate, 1, 7);
            tblMain.Controls.Add(txtRecipeStatus, 1, 8);
            tblMain.Controls.Add(lblCaptionPublishedDate, 0, 6);
            tblMain.Controls.Add(txtPublishedDate, 1, 6);
            tblMain.Controls.Add(lblCaptionDraftedDate, 0, 5);
            tblMain.Controls.Add(lblCaptionRecipeName, 0, 1);
            tblMain.Controls.Add(txtRecipeName, 1, 1);
            tblMain.Controls.Add(lblcaptionUser, 0, 2);
            tblMain.Controls.Add(lblCaptionCuisine, 0, 3);
            tblMain.Controls.Add(lstUsersName, 1, 2);
            tblMain.Controls.Add(lstCuisineName, 1, 3);
            tblMain.Controls.Add(tbRecipeChildRecords, 0, 9);
            tblMain.Controls.Add(tblRecipeButtons, 0, 0);
            tblMain.Controls.Add(dtpDraftedDate, 1, 5);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 10;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(930, 655);
            tblMain.TabIndex = 0;
            // 
            // lblCaptionCalories
            // 
            lblCaptionCalories.Anchor = AnchorStyles.Left;
            lblCaptionCalories.AutoSize = true;
            lblCaptionCalories.Location = new Point(3, 175);
            lblCaptionCalories.Name = "lblCaptionCalories";
            lblCaptionCalories.Size = new Size(62, 20);
            lblCaptionCalories.TabIndex = 1;
            lblCaptionCalories.Text = "Calories";
            // 
            // lblCaptionArchivedDate
            // 
            lblCaptionArchivedDate.Anchor = AnchorStyles.Left;
            lblCaptionArchivedDate.AutoSize = true;
            lblCaptionArchivedDate.Location = new Point(3, 274);
            lblCaptionArchivedDate.Name = "lblCaptionArchivedDate";
            lblCaptionArchivedDate.Size = new Size(103, 20);
            lblCaptionArchivedDate.TabIndex = 4;
            lblCaptionArchivedDate.Text = "Archived Date";
            // 
            // lblCaptionRecipeStatus
            // 
            lblCaptionRecipeStatus.AutoSize = true;
            lblCaptionRecipeStatus.Location = new Point(3, 301);
            lblCaptionRecipeStatus.Name = "lblCaptionRecipeStatus";
            lblCaptionRecipeStatus.Size = new Size(49, 20);
            lblCaptionRecipeStatus.TabIndex = 5;
            lblCaptionRecipeStatus.Text = "Status";
            // 
            // txtCalories
            // 
            txtCalories.Anchor = AnchorStyles.Left;
            txtCalories.Location = new Point(468, 172);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(125, 27);
            txtCalories.TabIndex = 7;
            // 
            // txtArchivedDate
            // 
            txtArchivedDate.Anchor = AnchorStyles.Left;
            txtArchivedDate.Location = new Point(468, 271);
            txtArchivedDate.Name = "txtArchivedDate";
            txtArchivedDate.ReadOnly = true;
            txtArchivedDate.Size = new Size(125, 27);
            txtArchivedDate.TabIndex = 18;
            // 
            // txtRecipeStatus
            // 
            txtRecipeStatus.Location = new Point(468, 304);
            txtRecipeStatus.Name = "txtRecipeStatus";
            txtRecipeStatus.ReadOnly = true;
            txtRecipeStatus.Size = new Size(125, 27);
            txtRecipeStatus.TabIndex = 19;
            // 
            // lblCaptionPublishedDate
            // 
            lblCaptionPublishedDate.Anchor = AnchorStyles.Left;
            lblCaptionPublishedDate.AutoSize = true;
            lblCaptionPublishedDate.Location = new Point(3, 241);
            lblCaptionPublishedDate.Name = "lblCaptionPublishedDate";
            lblCaptionPublishedDate.Size = new Size(109, 20);
            lblCaptionPublishedDate.TabIndex = 3;
            lblCaptionPublishedDate.Text = "Published Date";
            // 
            // txtPublishedDate
            // 
            txtPublishedDate.Anchor = AnchorStyles.Left;
            txtPublishedDate.Location = new Point(468, 238);
            txtPublishedDate.Name = "txtPublishedDate";
            txtPublishedDate.ReadOnly = true;
            txtPublishedDate.Size = new Size(125, 27);
            txtPublishedDate.TabIndex = 8;
            // 
            // lblCaptionDraftedDate
            // 
            lblCaptionDraftedDate.Anchor = AnchorStyles.Left;
            lblCaptionDraftedDate.AutoSize = true;
            lblCaptionDraftedDate.Location = new Point(3, 208);
            lblCaptionDraftedDate.Name = "lblCaptionDraftedDate";
            lblCaptionDraftedDate.Size = new Size(96, 20);
            lblCaptionDraftedDate.TabIndex = 2;
            lblCaptionDraftedDate.Text = "Drafted Date";
            // 
            // lblCaptionRecipeName
            // 
            lblCaptionRecipeName.Anchor = AnchorStyles.Left;
            lblCaptionRecipeName.AutoSize = true;
            lblCaptionRecipeName.Location = new Point(3, 74);
            lblCaptionRecipeName.Name = "lblCaptionRecipeName";
            lblCaptionRecipeName.Size = new Size(98, 20);
            lblCaptionRecipeName.TabIndex = 0;
            lblCaptionRecipeName.Text = "Recipe Name";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Anchor = AnchorStyles.Left;
            txtRecipeName.Location = new Point(468, 71);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(125, 27);
            txtRecipeName.TabIndex = 6;
            // 
            // lblcaptionUser
            // 
            lblcaptionUser.Anchor = AnchorStyles.Left;
            lblcaptionUser.AutoSize = true;
            lblcaptionUser.Location = new Point(3, 108);
            lblcaptionUser.Name = "lblcaptionUser";
            lblcaptionUser.Size = new Size(176, 20);
            lblcaptionUser.TabIndex = 22;
            lblcaptionUser.Text = "User Who created Recipe";
            // 
            // lblCaptionCuisine
            // 
            lblCaptionCuisine.Anchor = AnchorStyles.Left;
            lblCaptionCuisine.AutoSize = true;
            lblCaptionCuisine.Location = new Point(3, 142);
            lblCaptionCuisine.Name = "lblCaptionCuisine";
            lblCaptionCuisine.Size = new Size(91, 20);
            lblCaptionCuisine.TabIndex = 21;
            lblCaptionCuisine.Text = "Cuisine Type";
            // 
            // lstUsersName
            // 
            lstUsersName.Anchor = AnchorStyles.Left;
            lstUsersName.FormattingEnabled = true;
            lstUsersName.Location = new Point(468, 104);
            lstUsersName.Name = "lstUsersName";
            lstUsersName.Size = new Size(125, 28);
            lstUsersName.TabIndex = 23;
            // 
            // lstCuisineName
            // 
            lstCuisineName.Anchor = AnchorStyles.Left;
            lstCuisineName.FormattingEnabled = true;
            lstCuisineName.Location = new Point(468, 138);
            lstCuisineName.Name = "lstCuisineName";
            lstCuisineName.Size = new Size(125, 28);
            lstCuisineName.TabIndex = 24;
            // 
            // tbRecipeChildRecords
            // 
            tblMain.SetColumnSpan(tbRecipeChildRecords, 2);
            tbRecipeChildRecords.Controls.Add(tbIngredients);
            tbRecipeChildRecords.Controls.Add(tbSteps);
            tbRecipeChildRecords.Dock = DockStyle.Fill;
            tbRecipeChildRecords.Location = new Point(3, 337);
            tbRecipeChildRecords.Name = "tbRecipeChildRecords";
            tblMain.SetRowSpan(tbRecipeChildRecords, 3);
            tbRecipeChildRecords.SelectedIndex = 0;
            tbRecipeChildRecords.Size = new Size(924, 315);
            tbRecipeChildRecords.TabIndex = 25;
            // 
            // tbIngredients
            // 
            tbIngredients.Controls.Add(tblIngredients);
            tbIngredients.Location = new Point(4, 29);
            tbIngredients.Name = "tbIngredients";
            tbIngredients.Padding = new Padding(3);
            tbIngredients.Size = new Size(916, 282);
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
            tblIngredients.Location = new Point(3, 3);
            tblIngredients.Name = "tblIngredients";
            tblIngredients.RowCount = 2;
            tblIngredients.RowStyles.Add(new RowStyle());
            tblIngredients.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblIngredients.Size = new Size(910, 276);
            tblIngredients.TabIndex = 0;
            // 
            // btnSaveIngredients
            // 
            btnSaveIngredients.AutoSize = true;
            btnSaveIngredients.Location = new Point(10, 10);
            btnSaveIngredients.Margin = new Padding(10);
            btnSaveIngredients.Name = "btnSaveIngredients";
            btnSaveIngredients.Size = new Size(94, 30);
            btnSaveIngredients.TabIndex = 0;
            btnSaveIngredients.Text = "Save";
            btnSaveIngredients.UseVisualStyleBackColor = true;
            // 
            // gIngredients
            // 
            gIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gIngredients.Dock = DockStyle.Fill;
            gIngredients.Location = new Point(3, 53);
            gIngredients.Name = "gIngredients";
            gIngredients.RowHeadersWidth = 51;
            gIngredients.Size = new Size(904, 220);
            gIngredients.TabIndex = 1;
            // 
            // tbSteps
            // 
            tbSteps.Controls.Add(tblSteps);
            tbSteps.Location = new Point(4, 29);
            tbSteps.Name = "tbSteps";
            tbSteps.Padding = new Padding(3);
            tbSteps.Size = new Size(916, 282);
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
            tblSteps.Location = new Point(3, 3);
            tblSteps.Name = "tblSteps";
            tblSteps.RowCount = 2;
            tblSteps.RowStyles.Add(new RowStyle());
            tblSteps.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblSteps.Size = new Size(910, 276);
            tblSteps.TabIndex = 0;
            // 
            // btnSaveRecipeDirections
            // 
            btnSaveRecipeDirections.Location = new Point(10, 10);
            btnSaveRecipeDirections.Margin = new Padding(10);
            btnSaveRecipeDirections.Name = "btnSaveRecipeDirections";
            btnSaveRecipeDirections.Size = new Size(94, 29);
            btnSaveRecipeDirections.TabIndex = 0;
            btnSaveRecipeDirections.Text = "Save";
            btnSaveRecipeDirections.UseVisualStyleBackColor = true;
            // 
            // gSteps
            // 
            gSteps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gSteps.Dock = DockStyle.Fill;
            gSteps.Location = new Point(3, 52);
            gSteps.Name = "gSteps";
            gSteps.RowHeadersWidth = 51;
            gSteps.Size = new Size(904, 221);
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
            tblRecipeButtons.Location = new Point(3, 3);
            tblRecipeButtons.Name = "tblRecipeButtons";
            tblRecipeButtons.RowCount = 1;
            tblRecipeButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblRecipeButtons.Size = new Size(924, 62);
            tblRecipeButtons.TabIndex = 27;
            // 
            // btnSaveRecipe
            // 
            btnSaveRecipe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnSaveRecipe.Location = new Point(10, 10);
            btnSaveRecipe.Margin = new Padding(10);
            btnSaveRecipe.Name = "btnSaveRecipe";
            btnSaveRecipe.Size = new Size(94, 42);
            btnSaveRecipe.TabIndex = 0;
            btnSaveRecipe.Text = "Save";
            btnSaveRecipe.UseVisualStyleBackColor = true;
            // 
            // btnDeleteRecipe
            // 
            btnDeleteRecipe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnDeleteRecipe.Location = new Point(124, 10);
            btnDeleteRecipe.Margin = new Padding(10);
            btnDeleteRecipe.Name = "btnDeleteRecipe";
            btnDeleteRecipe.Size = new Size(94, 42);
            btnDeleteRecipe.TabIndex = 1;
            btnDeleteRecipe.Text = "Delete";
            btnDeleteRecipe.UseVisualStyleBackColor = true;
            // 
            // btnChangeStatusRecipe
            // 
            btnChangeStatusRecipe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnChangeStatusRecipe.AutoSize = true;
            btnChangeStatusRecipe.Location = new Point(801, 10);
            btnChangeStatusRecipe.Margin = new Padding(10);
            btnChangeStatusRecipe.Name = "btnChangeStatusRecipe";
            btnChangeStatusRecipe.Size = new Size(113, 42);
            btnChangeStatusRecipe.TabIndex = 2;
            btnChangeStatusRecipe.Text = "Change Status";
            btnChangeStatusRecipe.UseVisualStyleBackColor = true;
            // 
            // dtpDraftedDate
            // 
            dtpDraftedDate.Location = new Point(468, 205);
            dtpDraftedDate.Name = "dtpDraftedDate";
            dtpDraftedDate.Size = new Size(250, 27);
            dtpDraftedDate.TabIndex = 28;
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
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 655);
            Controls.Add(tblMain);
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
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblCaptionRecipeName;
        private Label lblCaptionCalories;
        private Label lblCaptionDraftedDate;
        private Label lblCaptionPublishedDate;
        private Label lblCaptionArchivedDate;
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
        private Label lblcaptionUser;
        private ComboBox lstUsersName;
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
        private TextBox txtRecipeStatus;
        private DateTimePicker dtpDraftedDate;
    }
}