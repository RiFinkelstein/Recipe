namespace RecipeWinForms
{
    partial class frmChangeRecipeStatus
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
            lblRecipeName = new Label();
            tblStatus = new TableLayoutPanel();
            lblCurrentStatus = new Label();
            lblRecipeStatus = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblStatusDates = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            lblDrafted = new Label();
            lblDraftedDate = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            lblPublished = new Label();
            lblPublishedDate = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            lblArchived = new Label();
            lblArchivedDate = new Label();
            tblButtons = new TableLayoutPanel();
            btnDraft = new Button();
            btnPublish = new Button();
            btnArchive = new Button();
            tblMain.SuspendLayout();
            tblStatus.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tblButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(lblRecipeName, 0, 0);
            tblMain.Controls.Add(tblStatus, 0, 1);
            tblMain.Controls.Add(tableLayoutPanel1, 0, 2);
            tblMain.Controls.Add(tblButtons, 0, 3);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblMain.Size = new Size(800, 450);
            tblMain.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            lblRecipeName.AutoSize = true;
            lblRecipeName.Dock = DockStyle.Fill;
            lblRecipeName.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecipeName.Location = new Point(3, 0);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(794, 112);
            lblRecipeName.TabIndex = 0;
            lblRecipeName.Text = "Recipe Name";
            lblRecipeName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblStatus
            // 
            tblStatus.ColumnCount = 2;
            tblStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblStatus.Controls.Add(lblCurrentStatus, 0, 0);
            tblStatus.Controls.Add(lblRecipeStatus, 1, 0);
            tblStatus.Dock = DockStyle.Fill;
            tblStatus.Location = new Point(3, 115);
            tblStatus.Name = "tblStatus";
            tblStatus.RowCount = 1;
            tblStatus.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblStatus.Size = new Size(794, 106);
            tblStatus.TabIndex = 1;
            // 
            // lblCurrentStatus
            // 
            lblCurrentStatus.AutoSize = true;
            lblCurrentStatus.Dock = DockStyle.Fill;
            lblCurrentStatus.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentStatus.Location = new Point(3, 0);
            lblCurrentStatus.Name = "lblCurrentStatus";
            lblCurrentStatus.Size = new Size(391, 106);
            lblCurrentStatus.TabIndex = 0;
            lblCurrentStatus.Text = "Current Status:";
            lblCurrentStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblRecipeStatus
            // 
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.Dock = DockStyle.Fill;
            lblRecipeStatus.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecipeStatus.Location = new Point(400, 0);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(391, 106);
            lblRecipeStatus.TabIndex = 1;
            lblRecipeStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(lblStatusDates, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 2, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 227);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(794, 106);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // lblStatusDates
            // 
            lblStatusDates.AutoSize = true;
            lblStatusDates.Dock = DockStyle.Fill;
            lblStatusDates.Font = new Font("Segoe UI", 14F);
            lblStatusDates.Location = new Point(3, 0);
            lblStatusDates.Name = "lblStatusDates";
            lblStatusDates.Size = new Size(192, 106);
            lblStatusDates.TabIndex = 0;
            lblStatusDates.Text = "Status Dates";
            lblStatusDates.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(lblDrafted, 0, 0);
            tableLayoutPanel2.Controls.Add(lblDraftedDate, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(201, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(192, 100);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // lblDrafted
            // 
            lblDrafted.AutoSize = true;
            lblDrafted.Dock = DockStyle.Fill;
            lblDrafted.Font = new Font("Segoe UI", 14F);
            lblDrafted.Location = new Point(3, 0);
            lblDrafted.Name = "lblDrafted";
            lblDrafted.Size = new Size(186, 50);
            lblDrafted.TabIndex = 0;
            lblDrafted.Text = "Drafted";
            lblDrafted.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDraftedDate
            // 
            lblDraftedDate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDraftedDate.AutoSize = true;
            lblDraftedDate.Font = new Font("Segoe UI", 14F);
            lblDraftedDate.Location = new Point(3, 50);
            lblDraftedDate.Name = "lblDraftedDate";
            lblDraftedDate.Size = new Size(186, 50);
            lblDraftedDate.TabIndex = 1;
            lblDraftedDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(lblPublished, 0, 0);
            tableLayoutPanel3.Controls.Add(lblPublishedDate, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(399, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(192, 100);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // lblPublished
            // 
            lblPublished.AutoSize = true;
            lblPublished.Dock = DockStyle.Fill;
            lblPublished.Font = new Font("Segoe UI", 14F);
            lblPublished.Location = new Point(3, 0);
            lblPublished.Name = "lblPublished";
            lblPublished.Size = new Size(186, 50);
            lblPublished.TabIndex = 0;
            lblPublished.Text = "Published";
            lblPublished.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPublishedDate
            // 
            lblPublishedDate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblPublishedDate.AutoSize = true;
            lblPublishedDate.Font = new Font("Segoe UI", 14F);
            lblPublishedDate.Location = new Point(3, 50);
            lblPublishedDate.Name = "lblPublishedDate";
            lblPublishedDate.Size = new Size(186, 50);
            lblPublishedDate.TabIndex = 1;
            lblPublishedDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(lblArchived, 0, 0);
            tableLayoutPanel4.Controls.Add(lblArchivedDate, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Font = new Font("Segoe UI", 14F);
            tableLayoutPanel4.Location = new Point(597, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(194, 100);
            tableLayoutPanel4.TabIndex = 3;
            // 
            // lblArchived
            // 
            lblArchived.AutoSize = true;
            lblArchived.Dock = DockStyle.Fill;
            lblArchived.Font = new Font("Segoe UI", 14F);
            lblArchived.Location = new Point(3, 0);
            lblArchived.Name = "lblArchived";
            lblArchived.Size = new Size(188, 50);
            lblArchived.TabIndex = 0;
            lblArchived.Text = "Archived";
            lblArchived.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblArchivedDate
            // 
            lblArchivedDate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblArchivedDate.AutoSize = true;
            lblArchivedDate.Font = new Font("Segoe UI", 14F);
            lblArchivedDate.Location = new Point(3, 50);
            lblArchivedDate.Name = "lblArchivedDate";
            lblArchivedDate.Size = new Size(188, 50);
            lblArchivedDate.TabIndex = 1;
            lblArchivedDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblButtons
            // 
            tblButtons.ColumnCount = 3;
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblButtons.Controls.Add(btnDraft, 0, 0);
            tblButtons.Controls.Add(btnPublish, 1, 0);
            tblButtons.Controls.Add(btnArchive, 2, 0);
            tblButtons.Dock = DockStyle.Fill;
            tblButtons.Location = new Point(3, 339);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 1;
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblButtons.Size = new Size(794, 108);
            tblButtons.TabIndex = 3;
            // 
            // btnDraft
            // 
            btnDraft.Dock = DockStyle.Fill;
            btnDraft.Font = new Font("Segoe UI", 14F);
            btnDraft.Location = new Point(20, 20);
            btnDraft.Margin = new Padding(20);
            btnDraft.Name = "btnDraft";
            btnDraft.Size = new Size(224, 68);
            btnDraft.TabIndex = 0;
            btnDraft.Text = "Draft";
            btnDraft.UseVisualStyleBackColor = true;
            // 
            // btnPublish
            // 
            btnPublish.Dock = DockStyle.Fill;
            btnPublish.Font = new Font("Segoe UI", 14F);
            btnPublish.Location = new Point(284, 20);
            btnPublish.Margin = new Padding(20);
            btnPublish.Name = "btnPublish";
            btnPublish.Size = new Size(224, 68);
            btnPublish.TabIndex = 1;
            btnPublish.Text = "Publish";
            btnPublish.UseVisualStyleBackColor = true;
            // 
            // btnArchive
            // 
            btnArchive.Dock = DockStyle.Fill;
            btnArchive.Font = new Font("Segoe UI", 14F);
            btnArchive.Location = new Point(548, 20);
            btnArchive.Margin = new Padding(20);
            btnArchive.Name = "btnArchive";
            btnArchive.Size = new Size(226, 68);
            btnArchive.TabIndex = 2;
            btnArchive.Text = "Archive";
            btnArchive.UseVisualStyleBackColor = true;
            // 
            // frmChangeRecipeStatus
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblMain);
            Name = "frmChangeRecipeStatus";
            Text = "Recipe - Change Status";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblStatus.ResumeLayout(false);
            tblStatus.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tblButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblRecipeName;
        private TableLayoutPanel tblStatus;
        private Label lblCurrentStatus;
        private Label lblRecipeStatus;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblStatusDates;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblDrafted;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Label lblDraftedDate;
        private Label lblPublished;
        private Label lblPublishedDate;
        private Label lblArchived;
        private Label lblArchivedDate;
        private TableLayoutPanel tblButtons;
        private Button btnDraft;
        private Button btnPublish;
        private Button btnArchive;
    }
}