namespace RecipeWinForms
{
    partial class frmCookbookList
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
            btnNewcookbook = new Button();
            gCookbooklist = new DataGridView();
            tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gCookbooklist).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(btnNewcookbook, 0, 0);
            tblMain.Controls.Add(gCookbooklist, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Size = new Size(800, 450);
            tblMain.TabIndex = 0;
            // 
            // btnNewcookbook
            // 
            btnNewcookbook.AutoSize = true;
            btnNewcookbook.Font = new Font("Segoe UI", 12F);
            btnNewcookbook.Location = new Point(20, 20);
            btnNewcookbook.Margin = new Padding(20);
            btnNewcookbook.Name = "btnNewcookbook";
            btnNewcookbook.Size = new Size(158, 38);
            btnNewcookbook.TabIndex = 0;
            btnNewcookbook.Text = "New Cookbook";
            btnNewcookbook.UseVisualStyleBackColor = true;
            // 
            // gCookbooklist
            // 
            gCookbooklist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gCookbooklist.Dock = DockStyle.Fill;
            gCookbooklist.Location = new Point(3, 81);
            gCookbooklist.Name = "gCookbooklist";
            gCookbooklist.RowHeadersWidth = 51;
            gCookbooklist.Size = new Size(794, 366);
            gCookbooklist.TabIndex = 1;
            // 
            // frmCookbookList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblMain);
            Name = "frmCookbookList";
            Text = "Cookbook List";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gCookbooklist).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Button btnNewcookbook;
        private DataGridView gCookbooklist;
    }
}