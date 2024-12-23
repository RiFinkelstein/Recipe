namespace RecipeWinForms
{
    partial class frmCookbook
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
            btnSave = new Button();
            btnDelete = new Button();
            label1lblCaptionCookbookName = new Label();
            lblCaptionUser = new Label();
            lblCaptionPrice = new Label();
            lblCaptionActive = new Label();
            txtCookbookName = new TextBox();
            lstUsersName = new ComboBox();
            tblPriceDateCreated = new TableLayoutPanel();
            lblCaptionDateCreated = new Label();
            txtPrice = new TextBox();
            dtpDateCreated = new DateTimePicker();
            ChbActive = new CheckBox();
            tblCookbookChildRecords = new TableLayoutPanel();
            btnSaveCookbookRecipe = new Button();
            gCookbookRecipe = new DataGridView();
            tblMain.SuspendLayout();
            tblPriceDateCreated.SuspendLayout();
            tblCookbookChildRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gCookbookRecipe).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(btnSave, 0, 0);
            tblMain.Controls.Add(btnDelete, 1, 0);
            tblMain.Controls.Add(label1lblCaptionCookbookName, 0, 1);
            tblMain.Controls.Add(lblCaptionUser, 0, 2);
            tblMain.Controls.Add(lblCaptionActive, 0, 4);
            tblMain.Controls.Add(txtCookbookName, 1, 1);
            tblMain.Controls.Add(lstUsersName, 1, 2);
            tblMain.Controls.Add(tblPriceDateCreated, 1, 3);
            tblMain.Controls.Add(ChbActive, 1, 4);
            tblMain.Controls.Add(lblCaptionPrice, 0, 3);
            tblMain.Controls.Add(tblCookbookChildRecords, 1, 5);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 6;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(800, 450);
            tblMain.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(10, 10);
            btnSave.Margin = new Padding(10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(151, 10);
            btnDelete.Margin = new Padding(10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // label1lblCaptionCookbookName
            // 
            label1lblCaptionCookbookName.AutoSize = true;
            label1lblCaptionCookbookName.Location = new Point(10, 59);
            label1lblCaptionCookbookName.Margin = new Padding(10);
            label1lblCaptionCookbookName.Name = "label1lblCaptionCookbookName";
            label1lblCaptionCookbookName.Size = new Size(121, 20);
            label1lblCaptionCookbookName.TabIndex = 2;
            label1lblCaptionCookbookName.Text = "Cookbook Name";
            // 
            // lblCaptionUser
            // 
            lblCaptionUser.AutoSize = true;
            lblCaptionUser.Location = new Point(10, 99);
            lblCaptionUser.Margin = new Padding(10);
            lblCaptionUser.Name = "lblCaptionUser";
            lblCaptionUser.Size = new Size(38, 20);
            lblCaptionUser.TabIndex = 3;
            lblCaptionUser.Text = "User";
            // 
            // lblCaptionPrice
            // 
            lblCaptionPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCaptionPrice.AutoSize = true;
            lblCaptionPrice.Location = new Point(10, 177);
            lblCaptionPrice.Margin = new Padding(10);
            lblCaptionPrice.Name = "lblCaptionPrice";
            lblCaptionPrice.Size = new Size(41, 20);
            lblCaptionPrice.TabIndex = 4;
            lblCaptionPrice.Text = "Price";
            // 
            // lblCaptionActive
            // 
            lblCaptionActive.AutoSize = true;
            lblCaptionActive.Location = new Point(10, 217);
            lblCaptionActive.Margin = new Padding(10);
            lblCaptionActive.Name = "lblCaptionActive";
            lblCaptionActive.Size = new Size(50, 20);
            lblCaptionActive.TabIndex = 5;
            lblCaptionActive.Text = "Active";
            // 
            // txtCookbookName
            // 
            txtCookbookName.Location = new Point(144, 52);
            txtCookbookName.Name = "txtCookbookName";
            txtCookbookName.Size = new Size(653, 27);
            txtCookbookName.TabIndex = 7;
            // 
            // lstUsersName
            // 
            lstUsersName.FormattingEnabled = true;
            lstUsersName.Location = new Point(144, 92);
            lstUsersName.Name = "lstUsersName";
            lstUsersName.Size = new Size(653, 28);
            lstUsersName.TabIndex = 8;
            // 
            // tblPriceDateCreated
            // 
            tblPriceDateCreated.ColumnCount = 2;
            tblPriceDateCreated.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblPriceDateCreated.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblPriceDateCreated.Controls.Add(lblCaptionDateCreated, 1, 0);
            tblPriceDateCreated.Controls.Add(txtPrice, 0, 1);
            tblPriceDateCreated.Controls.Add(dtpDateCreated, 1, 1);
            tblPriceDateCreated.Location = new Point(144, 132);
            tblPriceDateCreated.Name = "tblPriceDateCreated";
            tblPriceDateCreated.RowCount = 2;
            tblPriceDateCreated.RowStyles.Add(new RowStyle());
            tblPriceDateCreated.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblPriceDateCreated.Size = new Size(653, 72);
            tblPriceDateCreated.TabIndex = 6;
            // 
            // lblCaptionDateCreated
            // 
            lblCaptionDateCreated.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblCaptionDateCreated.AutoSize = true;
            lblCaptionDateCreated.Location = new Point(331, 5);
            lblCaptionDateCreated.Margin = new Padding(5);
            lblCaptionDateCreated.Name = "lblCaptionDateCreated";
            lblCaptionDateCreated.Size = new Size(317, 20);
            lblCaptionDateCreated.TabIndex = 0;
            lblCaptionDateCreated.Text = "Date Created:";
            lblCaptionDateCreated.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(3, 33);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(320, 27);
            txtPrice.TabIndex = 1;
            // 
            // dtpDateCreated
            // 
            dtpDateCreated.Location = new Point(329, 33);
            dtpDateCreated.Name = "dtpDateCreated";
            dtpDateCreated.Size = new Size(315, 27);
            dtpDateCreated.TabIndex = 2;
            // 
            // ChbActive
            // 
            ChbActive.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ChbActive.AutoSize = true;
            ChbActive.BackColor = SystemColors.ButtonFace;
            ChbActive.Location = new Point(144, 210);
            ChbActive.Name = "ChbActive";
            ChbActive.Size = new Size(653, 34);
            ChbActive.TabIndex = 9;
            ChbActive.UseVisualStyleBackColor = false;
            // 
            // tblCookbookChildRecords
            // 
            tblCookbookChildRecords.ColumnCount = 1;
            tblMain.SetColumnSpan(tblCookbookChildRecords, 2);
            tblCookbookChildRecords.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblCookbookChildRecords.Controls.Add(btnSaveCookbookRecipe, 0, 0);
            tblCookbookChildRecords.Controls.Add(gCookbookRecipe, 0, 1);
            tblCookbookChildRecords.Dock = DockStyle.Fill;
            tblCookbookChildRecords.Location = new Point(3, 270);
            tblCookbookChildRecords.Name = "tblCookbookChildRecords";
            tblCookbookChildRecords.RowCount = 2;
            tblCookbookChildRecords.RowStyles.Add(new RowStyle());
            tblCookbookChildRecords.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCookbookChildRecords.Size = new Size(794, 177);
            tblCookbookChildRecords.TabIndex = 10;
            // 
            // btnSaveCookbookRecipe
            // 
            btnSaveCookbookRecipe.Location = new Point(3, 3);
            btnSaveCookbookRecipe.Name = "btnSaveCookbookRecipe";
            btnSaveCookbookRecipe.Size = new Size(94, 29);
            btnSaveCookbookRecipe.TabIndex = 0;
            btnSaveCookbookRecipe.Text = "Save";
            btnSaveCookbookRecipe.UseVisualStyleBackColor = true;
            // 
            // gCookbookRecipe
            // 
            gCookbookRecipe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gCookbookRecipe.Dock = DockStyle.Fill;
            gCookbookRecipe.Location = new Point(3, 38);
            gCookbookRecipe.Name = "gCookbookRecipe";
            gCookbookRecipe.RowHeadersWidth = 51;
            gCookbookRecipe.Size = new Size(788, 136);
            gCookbookRecipe.TabIndex = 1;
            // 
            // frmCookbook
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblMain);
            Name = "frmCookbook";
            Text = "frmCookbook";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblPriceDateCreated.ResumeLayout(false);
            tblPriceDateCreated.PerformLayout();
            tblCookbookChildRecords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gCookbookRecipe).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Button btnSave;
        private Button btnDelete;
        private Label label1lblCaptionCookbookName;
        private Label lblCaptionUser;
        private Label lblCaptionPrice;
        private Label lblCaptionActive;
        private TableLayoutPanel tblPriceDateCreated;
        private Label lblCaptionDateCreated;
        private TextBox txtCookbookName;
        private ComboBox lstUsersName;
        private TextBox txtPrice;
        private DateTimePicker dtpDateCreated;
        private CheckBox ChbActive;
        private TableLayoutPanel tblCookbookChildRecords;
        private Button btnSaveCookbookRecipe;
        private DataGridView gCookbookRecipe;
    }
}