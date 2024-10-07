namespace RecipeWinForms
{
    partial class frmMain
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
            mnuMain = new MenuStrip();
            mnuRecipe = new ToolStripMenuItem();
            mnuSearchRecipe = new ToolStripMenuItem();
            mnuNewRecipe = new ToolStripMenuItem();
            mnuMain.SuspendLayout();
            SuspendLayout();
            // 
            // mnuMain
            // 
            mnuMain.Font = new Font("Segoe UI", 12F);
            mnuMain.ImageScalingSize = new Size(20, 20);
            mnuMain.Items.AddRange(new ToolStripItem[] { mnuRecipe });
            mnuMain.Location = new Point(0, 0);
            mnuMain.Name = "mnuMain";
            mnuMain.Size = new Size(800, 36);
            mnuMain.TabIndex = 1;
            mnuMain.Text = "menuStrip1";
            // 
            // mnuRecipe
            // 
            mnuRecipe.DropDownItems.AddRange(new ToolStripItem[] { mnuSearchRecipe, mnuNewRecipe });
            mnuRecipe.Name = "mnuRecipe";
            mnuRecipe.Size = new Size(83, 32);
            mnuRecipe.Text = "Recipe";
            // 
            // mnuSearchRecipe
            // 
            mnuSearchRecipe.Name = "mnuSearchRecipe";
            mnuSearchRecipe.Size = new Size(224, 32);
            mnuSearchRecipe.Text = "Search";
            // 
            // mnuNewRecipe
            // 
            mnuNewRecipe.Name = "mnuNewRecipe";
            mnuNewRecipe.Size = new Size(224, 32);
            mnuNewRecipe.Text = "New Recipe";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mnuMain);
            IsMdiContainer = true;
            MainMenuStrip = mnuMain;
            Name = "frmMain";
            Text = "Recipe";
            mnuMain.ResumeLayout(false);
            mnuMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuMain;
        private ToolStripMenuItem mnuRecipe;
        private ToolStripMenuItem mnuSearchRecipe;
        private ToolStripMenuItem mnuNewRecipe;
    }
}