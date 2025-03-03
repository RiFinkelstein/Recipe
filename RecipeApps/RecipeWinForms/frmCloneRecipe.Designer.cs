namespace RecipeWinForms
{
    partial class frmCloneRecipe
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
            lstRecipename = new ComboBox();
            btnClone = new Button();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            tblMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(lstRecipename, 0, 0);
            tblMain.Controls.Add(btnClone, 0, 1);
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(670, 245);
            tblMain.TabIndex = 0;
            // 
            // lstRecipename
            // 
            lstRecipename.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstRecipename.FormattingEnabled = true;
            lstRecipename.Location = new Point(3, 3);
            lstRecipename.Name = "lstRecipename";
            lstRecipename.Size = new Size(664, 28);
            lstRecipename.TabIndex = 0;
            // 
            // btnClone
            // 
            btnClone.Anchor = AnchorStyles.Top;
            btnClone.ImageAlign = ContentAlignment.TopCenter;
            btnClone.Location = new Point(285, 44);
            btnClone.Margin = new Padding(10);
            btnClone.Name = "btnClone";
            btnClone.Size = new Size(100, 50);
            btnClone.TabIndex = 1;
            btnClone.Text = "Clone";
            btnClone.UseVisualStyleBackColor = true;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // frmCloneRecipe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 243);
            Controls.Add(tblMain);
            Name = "frmCloneRecipe";
            Text = "Clone a Recipe";
            tblMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private ComboBox lstRecipe;
        private Button btnClone;
        private ComboBox lstRecipename;
    }
}