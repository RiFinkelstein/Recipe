namespace RecipeWinForms
{
    partial class frmSearch
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
            tblSearchBar = new TableLayoutPanel();
            lblRecipeName = new Label();
            txtRecipeName = new TextBox();
            btnSearch = new Button();
            gRecipe = new DataGridView();
            btnNew = new Button();
            tblMain.SuspendLayout();
            tblSearchBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipe).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(tblSearchBar, 0, 0);
            tblMain.Controls.Add(gRecipe, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(800, 450);
            tblMain.TabIndex = 0;
            // 
            // tblSearchBar
            // 
            tblSearchBar.AutoSize = true;
            tblSearchBar.ColumnCount = 4;
            tblSearchBar.ColumnStyles.Add(new ColumnStyle());
            tblSearchBar.ColumnStyles.Add(new ColumnStyle());
            tblSearchBar.ColumnStyles.Add(new ColumnStyle());
            tblSearchBar.ColumnStyles.Add(new ColumnStyle());
            tblSearchBar.Controls.Add(lblRecipeName, 0, 0);
            tblSearchBar.Controls.Add(txtRecipeName, 1, 0);
            tblSearchBar.Controls.Add(btnSearch, 2, 0);
            tblSearchBar.Controls.Add(btnNew, 3, 0);
            tblSearchBar.Location = new Point(3, 3);
            tblSearchBar.Name = "tblSearchBar";
            tblSearchBar.RowCount = 1;
            tblSearchBar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblSearchBar.Size = new Size(360, 36);
            tblSearchBar.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            lblRecipeName.AutoSize = true;
            lblRecipeName.Dock = DockStyle.Fill;
            lblRecipeName.Location = new Point(3, 0);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(98, 36);
            lblRecipeName.TabIndex = 0;
            lblRecipeName.Text = "Recipe Name";
            lblRecipeName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtRecipeName
            // 
            txtRecipeName.Location = new Point(107, 3);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(125, 27);
            txtRecipeName.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Location = new Point(238, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(63, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // gRecipe
            // 
            gRecipe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gRecipe.Dock = DockStyle.Fill;
            gRecipe.Location = new Point(3, 45);
            gRecipe.Name = "gRecipe";
            gRecipe.RowHeadersWidth = 51;
            gRecipe.Size = new Size(794, 402);
            gRecipe.TabIndex = 1;
            // 
            // btnNew
            // 
            btnNew.AutoSize = true;
            btnNew.Location = new Point(307, 3);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(49, 30);
            btnNew.TabIndex = 3;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // frmSearch
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblMain);
            Name = "frmSearch";
            Text = "Search";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblSearchBar.ResumeLayout(false);
            tblSearchBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipe).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblSearchBar;
        private Label lblRecipeName;
        private TextBox txtRecipeName;
        private Button btnSearch;
        private DataGridView gRecipe;
        private Button btnNew;
    }
}