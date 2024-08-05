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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecipe));
            tblMain = new TableLayoutPanel();
            lblCaptionCalories = new Label();
            lblCaptionArchivedDate = new Label();
            lblCaptionStatus = new Label();
            txtCalories = new TextBox();
            toolStrip1 = new ToolStrip();
            btnSave1 = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnDelete1 = new ToolStripButton();
            dtpDraftedDate = new DateTimePicker();
            txtArchivedDate = new TextBox();
            txtStatus = new TextBox();
            lblCaptionPublishedDate = new Label();
            txtPublishedDate = new TextBox();
            lblCaptionDraftedDate = new Label();
            lblCaptionRecipeName = new Label();
            txtRecipeName = new TextBox();
            lblcaptionUser = new Label();
            lblCaptionCuisine = new Label();
            lstUsersName = new ComboBox();
            lstCuisineName = new ComboBox();
            btnSave = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnDelete = new ToolStripButton();
            tblMain.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(lblCaptionCalories, 0, 4);
            tblMain.Controls.Add(lblCaptionArchivedDate, 0, 7);
            tblMain.Controls.Add(lblCaptionStatus, 0, 8);
            tblMain.Controls.Add(txtCalories, 1, 4);
            tblMain.Controls.Add(toolStrip1, 0, 0);
            tblMain.Controls.Add(dtpDraftedDate, 1, 5);
            tblMain.Controls.Add(txtArchivedDate, 1, 7);
            tblMain.Controls.Add(txtStatus, 1, 8);
            tblMain.Controls.Add(lblCaptionPublishedDate, 0, 6);
            tblMain.Controls.Add(txtPublishedDate, 1, 6);
            tblMain.Controls.Add(lblCaptionDraftedDate, 0, 5);
            tblMain.Controls.Add(lblCaptionRecipeName, 0, 1);
            tblMain.Controls.Add(txtRecipeName, 1, 1);
            tblMain.Controls.Add(lblcaptionUser, 0, 2);
            tblMain.Controls.Add(lblCaptionCuisine, 0, 3);
            tblMain.Controls.Add(lstUsersName, 1, 2);
            tblMain.Controls.Add(lstCuisineName, 1, 3);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 9;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tblMain.Size = new Size(800, 450);
            tblMain.TabIndex = 0;
            // 
            // lblCaptionCalories
            // 
            lblCaptionCalories.Anchor = AnchorStyles.Left;
            lblCaptionCalories.AutoSize = true;
            lblCaptionCalories.Location = new Point(3, 215);
            lblCaptionCalories.Name = "lblCaptionCalories";
            lblCaptionCalories.Size = new Size(62, 20);
            lblCaptionCalories.TabIndex = 1;
            lblCaptionCalories.Text = "Calories";
            // 
            // lblCaptionArchivedDate
            // 
            lblCaptionArchivedDate.Anchor = AnchorStyles.Left;
            lblCaptionArchivedDate.AutoSize = true;
            lblCaptionArchivedDate.Location = new Point(3, 365);
            lblCaptionArchivedDate.Name = "lblCaptionArchivedDate";
            lblCaptionArchivedDate.Size = new Size(103, 20);
            lblCaptionArchivedDate.TabIndex = 4;
            lblCaptionArchivedDate.Text = "Archived Date";
            // 
            // lblCaptionStatus
            // 
            lblCaptionStatus.AutoSize = true;
            lblCaptionStatus.Location = new Point(3, 400);
            lblCaptionStatus.Name = "lblCaptionStatus";
            lblCaptionStatus.Size = new Size(49, 20);
            lblCaptionStatus.TabIndex = 5;
            lblCaptionStatus.Text = "Status";
            // 
            // txtCalories
            // 
            txtCalories.Anchor = AnchorStyles.Left;
            txtCalories.Location = new Point(403, 211);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(125, 27);
            txtCalories.TabIndex = 7;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnSave1, toolStripSeparator2, btnDelete1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(400, 27);
            toolStrip1.TabIndex = 20;
            // 
            // btnSave1
            // 
            btnSave1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnSave1.Image = (Image)resources.GetObject("btnSave1.Image");
            btnSave1.ImageTransparentColor = Color.Magenta;
            btnSave1.Name = "btnSave1";
            btnSave1.Size = new Size(44, 24);
            btnSave1.Text = "Save";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
            // 
            // btnDelete1
            // 
            btnDelete1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnDelete1.Image = (Image)resources.GetObject("btnDelete1.Image");
            btnDelete1.ImageTransparentColor = Color.Magenta;
            btnDelete1.Name = "btnDelete1";
            btnDelete1.Size = new Size(57, 24);
            btnDelete1.Text = "Delete";
            // 
            // dtpDraftedDate
            // 
            dtpDraftedDate.Format = DateTimePickerFormat.Short;
            dtpDraftedDate.Location = new Point(403, 253);
            dtpDraftedDate.Name = "dtpDraftedDate";
            dtpDraftedDate.Size = new Size(125, 27);
            dtpDraftedDate.TabIndex = 13;
            // 
            // txtArchivedDate
            // 
            txtArchivedDate.Anchor = AnchorStyles.Left;
            txtArchivedDate.Location = new Point(403, 361);
            txtArchivedDate.Name = "txtArchivedDate";
            txtArchivedDate.ReadOnly = true;
            txtArchivedDate.Size = new Size(125, 27);
            txtArchivedDate.TabIndex = 18;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(403, 403);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(125, 27);
            txtStatus.TabIndex = 19;
            // 
            // lblCaptionPublishedDate
            // 
            lblCaptionPublishedDate.Anchor = AnchorStyles.Left;
            lblCaptionPublishedDate.AutoSize = true;
            lblCaptionPublishedDate.Location = new Point(3, 315);
            lblCaptionPublishedDate.Name = "lblCaptionPublishedDate";
            lblCaptionPublishedDate.Size = new Size(109, 20);
            lblCaptionPublishedDate.TabIndex = 3;
            lblCaptionPublishedDate.Text = "Published Date";
            // 
            // txtPublishedDate
            // 
            txtPublishedDate.Anchor = AnchorStyles.Left;
            txtPublishedDate.Location = new Point(403, 311);
            txtPublishedDate.Name = "txtPublishedDate";
            txtPublishedDate.ReadOnly = true;
            txtPublishedDate.Size = new Size(125, 27);
            txtPublishedDate.TabIndex = 8;
            // 
            // lblCaptionDraftedDate
            // 
            lblCaptionDraftedDate.Anchor = AnchorStyles.Left;
            lblCaptionDraftedDate.AutoSize = true;
            lblCaptionDraftedDate.Location = new Point(3, 265);
            lblCaptionDraftedDate.Name = "lblCaptionDraftedDate";
            lblCaptionDraftedDate.Size = new Size(96, 20);
            lblCaptionDraftedDate.TabIndex = 2;
            lblCaptionDraftedDate.Text = "Drafted Date";
            // 
            // lblCaptionRecipeName
            // 
            lblCaptionRecipeName.Anchor = AnchorStyles.Left;
            lblCaptionRecipeName.AutoSize = true;
            lblCaptionRecipeName.Location = new Point(3, 65);
            lblCaptionRecipeName.Name = "lblCaptionRecipeName";
            lblCaptionRecipeName.Size = new Size(98, 20);
            lblCaptionRecipeName.TabIndex = 0;
            lblCaptionRecipeName.Text = "Recipe Name";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Anchor = AnchorStyles.Left;
            txtRecipeName.Location = new Point(403, 61);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(125, 27);
            txtRecipeName.TabIndex = 6;
            // 
            // lblcaptionUser
            // 
            lblcaptionUser.Anchor = AnchorStyles.Left;
            lblcaptionUser.AutoSize = true;
            lblcaptionUser.Location = new Point(3, 115);
            lblcaptionUser.Name = "lblcaptionUser";
            lblcaptionUser.Size = new Size(176, 20);
            lblcaptionUser.TabIndex = 22;
            lblcaptionUser.Text = "User Who created Recipe";
            // 
            // lblCaptionCuisine
            // 
            lblCaptionCuisine.Anchor = AnchorStyles.Left;
            lblCaptionCuisine.AutoSize = true;
            lblCaptionCuisine.Location = new Point(3, 165);
            lblCaptionCuisine.Name = "lblCaptionCuisine";
            lblCaptionCuisine.Size = new Size(91, 20);
            lblCaptionCuisine.TabIndex = 21;
            lblCaptionCuisine.Text = "Cuisine Type";
            // 
            // lstUsersName
            // 
            lstUsersName.Anchor = AnchorStyles.Left;
            lstUsersName.FormattingEnabled = true;
            lstUsersName.Location = new Point(403, 111);
            lstUsersName.Name = "lstUsersName";
            lstUsersName.Size = new Size(125, 28);
            lstUsersName.TabIndex = 23;
            // 
            // lstCuisineName
            // 
            lstCuisineName.Anchor = AnchorStyles.Left;
            lstCuisineName.FormattingEnabled = true;
            lstCuisineName.Location = new Point(403, 161);
            lstCuisineName.Name = "lstCuisineName";
            lstCuisineName.Size = new Size(125, 28);
            lstCuisineName.TabIndex = 24;
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
            ClientSize = new Size(800, 450);
            Controls.Add(tblMain);
            Name = "frmRecipe";
            Text = "Recipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
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
        private ToolStrip toolStrip1;
        private ToolStripButton btnSave;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnDelete;
        private DateTimePicker dtpDraftedDate;
        private DateTimePicker dtpPublishedDate;
        private TextBox txtArchivedDate;
        private ToolStripButton btnSave1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnDelete1;
        private TextBox txtRecipeName;
        private TextBox txtStatus;
        private Label lblCaptionCuisine;
        private Label lblcaptionUser;
        private ComboBox lstUsersName;
        private ComboBox lstCuisineName;
    }
}