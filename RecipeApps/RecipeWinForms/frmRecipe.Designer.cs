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
            lblCaptionRecipeName = new Label();
            lblCaptionCalories = new Label();
            lblCaptionArchivedDate = new Label();
            lblCaptionStatus = new Label();
            txtRecipeName = new TextBox();
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
            tblMain.Controls.Add(lblCaptionRecipeName, 0, 1);
            tblMain.Controls.Add(lblCaptionCalories, 0, 2);
            tblMain.Controls.Add(lblCaptionArchivedDate, 0, 5);
            tblMain.Controls.Add(lblCaptionStatus, 0, 6);
            tblMain.Controls.Add(txtRecipeName, 1, 1);
            tblMain.Controls.Add(txtCalories, 1, 2);
            tblMain.Controls.Add(toolStrip1, 0, 0);
            tblMain.Controls.Add(dtpDraftedDate, 1, 3);
            tblMain.Controls.Add(txtArchivedDate, 1, 5);
            tblMain.Controls.Add(txtStatus, 1, 6);
            tblMain.Controls.Add(lblCaptionPublishedDate, 0, 4);
            tblMain.Controls.Add(txtPublishedDate, 1, 4);
            tblMain.Controls.Add(lblCaptionDraftedDate, 0, 3);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 7;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(800, 450);
            tblMain.TabIndex = 0;
            // 
            // lblCaptionRecipeName
            // 
            lblCaptionRecipeName.Anchor = AnchorStyles.Left;
            lblCaptionRecipeName.AutoSize = true;
            lblCaptionRecipeName.Location = new Point(3, 87);
            lblCaptionRecipeName.Name = "lblCaptionRecipeName";
            lblCaptionRecipeName.Size = new Size(98, 20);
            lblCaptionRecipeName.TabIndex = 0;
            lblCaptionRecipeName.Text = "Recipe Name";
            // 
            // lblCaptionCalories
            // 
            lblCaptionCalories.Anchor = AnchorStyles.Left;
            lblCaptionCalories.AutoSize = true;
            lblCaptionCalories.Location = new Point(3, 152);
            lblCaptionCalories.Name = "lblCaptionCalories";
            lblCaptionCalories.Size = new Size(62, 20);
            lblCaptionCalories.TabIndex = 1;
            lblCaptionCalories.Text = "Calories";
            // 
            // lblCaptionArchivedDate
            // 
            lblCaptionArchivedDate.Anchor = AnchorStyles.Left;
            lblCaptionArchivedDate.AutoSize = true;
            lblCaptionArchivedDate.Location = new Point(3, 347);
            lblCaptionArchivedDate.Name = "lblCaptionArchivedDate";
            lblCaptionArchivedDate.Size = new Size(103, 20);
            lblCaptionArchivedDate.TabIndex = 4;
            lblCaptionArchivedDate.Text = "Archived Date";
            // 
            // lblCaptionStatus
            // 
            lblCaptionStatus.AutoSize = true;
            lblCaptionStatus.Location = new Point(3, 390);
            lblCaptionStatus.Name = "lblCaptionStatus";
            lblCaptionStatus.Size = new Size(49, 20);
            lblCaptionStatus.TabIndex = 5;
            lblCaptionStatus.Text = "Status";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Anchor = AnchorStyles.Left;
            txtRecipeName.Location = new Point(403, 84);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(125, 27);
            txtRecipeName.TabIndex = 6;
            // 
            // txtCalories
            // 
            txtCalories.Anchor = AnchorStyles.Left;
            txtCalories.Location = new Point(403, 149);
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
            dtpDraftedDate.Location = new Point(403, 198);
            dtpDraftedDate.Name = "dtpDraftedDate";
            dtpDraftedDate.Size = new Size(125, 27);
            dtpDraftedDate.TabIndex = 13;
            // 
            // txtArchivedDate
            // 
            txtArchivedDate.Anchor = AnchorStyles.Left;
            txtArchivedDate.Location = new Point(403, 344);
            txtArchivedDate.Name = "txtArchivedDate";
            txtArchivedDate.Size = new Size(125, 27);
            txtArchivedDate.TabIndex = 18;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(403, 393);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(125, 27);
            txtStatus.TabIndex = 19;
            // 
            // lblCaptionPublishedDate
            // 
            lblCaptionPublishedDate.Anchor = AnchorStyles.Left;
            lblCaptionPublishedDate.AutoSize = true;
            lblCaptionPublishedDate.Location = new Point(3, 282);
            lblCaptionPublishedDate.Name = "lblCaptionPublishedDate";
            lblCaptionPublishedDate.Size = new Size(109, 20);
            lblCaptionPublishedDate.TabIndex = 3;
            lblCaptionPublishedDate.Text = "Published Date";
            // 
            // txtPublishedDate
            // 
            txtPublishedDate.Anchor = AnchorStyles.Left;
            txtPublishedDate.Location = new Point(403, 279);
            txtPublishedDate.Name = "txtPublishedDate";
            txtPublishedDate.Size = new Size(125, 27);
            txtPublishedDate.TabIndex = 8;
            // 
            // lblCaptionDraftedDate
            // 
            lblCaptionDraftedDate.Anchor = AnchorStyles.Left;
            lblCaptionDraftedDate.AutoSize = true;
            lblCaptionDraftedDate.Location = new Point(3, 217);
            lblCaptionDraftedDate.Name = "lblCaptionDraftedDate";
            lblCaptionDraftedDate.Size = new Size(96, 20);
            lblCaptionDraftedDate.TabIndex = 2;
            lblCaptionDraftedDate.Text = "Drafted Date";
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
    }
}