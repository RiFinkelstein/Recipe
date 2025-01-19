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
            mnuFile = new ToolStripMenuItem();
            mnuDashboard = new ToolStripMenuItem();
            mnuRecipe = new ToolStripMenuItem();
            mnuListRecipe = new ToolStripMenuItem();
            mnuNewRecipe = new ToolStripMenuItem();
            mnuClonearecipe = new ToolStripMenuItem();
            mnuMeals = new ToolStripMenuItem();
            MnuMealsList = new ToolStripMenuItem();
            mnuCookbooks = new ToolStripMenuItem();
            MnuListOfCookbooks = new ToolStripMenuItem();
            mnuNewCookbook = new ToolStripMenuItem();
            mnuAutocreatecookbook = new ToolStripMenuItem();
            mnuDatamaintenance = new ToolStripMenuItem();
            mnuEditdata = new ToolStripMenuItem();
            mnuWindows = new ToolStripMenuItem();
            tsMain = new ToolStrip();
            mnuMain.SuspendLayout();
            SuspendLayout();
            // 
            // mnuMain
            // 
            mnuMain.Font = new Font("Segoe UI", 12F);
            mnuMain.ImageScalingSize = new Size(20, 20);
            mnuMain.Items.AddRange(new ToolStripItem[] { mnuFile, mnuRecipe, mnuMeals, mnuCookbooks, mnuDatamaintenance, mnuWindows });
            mnuMain.Location = new Point(0, 0);
            mnuMain.Name = "mnuMain";
            mnuMain.Size = new Size(800, 36);
            mnuMain.TabIndex = 1;
            mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuDashboard });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(56, 32);
            mnuFile.Text = "File";
            // 
            // mnuDashboard
            // 
            mnuDashboard.Name = "mnuDashboard";
            mnuDashboard.Size = new Size(224, 32);
            mnuDashboard.Text = "Dashboard";
            // 
            // mnuRecipe
            // 
            mnuRecipe.DropDownItems.AddRange(new ToolStripItem[] { mnuListRecipe, mnuNewRecipe, mnuClonearecipe });
            mnuRecipe.Name = "mnuRecipe";
            mnuRecipe.Size = new Size(83, 32);
            mnuRecipe.Text = "Recipe";
            // 
            // mnuListRecipe
            // 
            mnuListRecipe.Name = "mnuListRecipe";
            mnuListRecipe.Size = new Size(225, 32);
            mnuListRecipe.Text = "List";
            // 
            // mnuNewRecipe
            // 
            mnuNewRecipe.Name = "mnuNewRecipe";
            mnuNewRecipe.Size = new Size(225, 32);
            mnuNewRecipe.Text = "New Recipe";
            // 
            // mnuClonearecipe
            // 
            mnuClonearecipe.Name = "mnuClonearecipe";
            mnuClonearecipe.Size = new Size(225, 32);
            mnuClonearecipe.Text = "Clone a Recipe";
            // 
            // mnuMeals
            // 
            mnuMeals.DropDownItems.AddRange(new ToolStripItem[] { MnuMealsList });
            mnuMeals.Name = "mnuMeals";
            mnuMeals.Size = new Size(77, 32);
            mnuMeals.Text = "Meals";
            // 
            // MnuMealsList
            // 
            MnuMealsList.Name = "MnuMealsList";
            MnuMealsList.Size = new Size(127, 32);
            MnuMealsList.Text = "List";
            // 
            // mnuCookbooks
            // 
            mnuCookbooks.DropDownItems.AddRange(new ToolStripItem[] { MnuListOfCookbooks, mnuNewCookbook, mnuAutocreatecookbook });
            mnuCookbooks.Name = "mnuCookbooks";
            mnuCookbooks.Size = new Size(126, 32);
            mnuCookbooks.Text = "Cookbooks";
            // 
            // MnuListOfCookbooks
            // 
            MnuListOfCookbooks.Name = "MnuListOfCookbooks";
            MnuListOfCookbooks.Size = new Size(234, 32);
            MnuListOfCookbooks.Text = "List";
            // 
            // mnuNewCookbook
            // 
            mnuNewCookbook.Name = "mnuNewCookbook";
            mnuNewCookbook.Size = new Size(234, 32);
            mnuNewCookbook.Text = "New Cookbook";
            // 
            // mnuAutocreatecookbook
            // 
            mnuAutocreatecookbook.Name = "mnuAutocreatecookbook";
            mnuAutocreatecookbook.Size = new Size(234, 32);
            mnuAutocreatecookbook.Text = "Auto-Create";
            // 
            // mnuDatamaintenance
            // 
            mnuDatamaintenance.DropDownItems.AddRange(new ToolStripItem[] { mnuEditdata });
            mnuDatamaintenance.Name = "mnuDatamaintenance";
            mnuDatamaintenance.Size = new Size(184, 32);
            mnuDatamaintenance.Text = "Data Maintenance";
            // 
            // mnuEditdata
            // 
            mnuEditdata.Name = "mnuEditdata";
            mnuEditdata.Size = new Size(178, 32);
            mnuEditdata.Text = "Edit Data";
            // 
            // mnuWindows
            // 
            mnuWindows.Name = "mnuWindows";
            mnuWindows.Size = new Size(107, 32);
            mnuWindows.Text = "Windows";
            // 
            // tsMain
            // 
            tsMain.ImageScalingSize = new Size(20, 20);
            tsMain.Location = new Point(0, 36);
            tsMain.Name = "tsMain";
            tsMain.Size = new Size(800, 25);
            tsMain.TabIndex = 3;
            tsMain.Text = "toolStrip1";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tsMain);
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
        private ToolStripMenuItem mnuNewRecipe;
        private ToolStrip tsMain;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuMeals;
        private ToolStripMenuItem mnuCookbooks;
        private ToolStripMenuItem mnuDatamaintenance;
        private ToolStripMenuItem mnuWindows;
        private ToolStripMenuItem mnuDashboard;
        private ToolStripMenuItem mnuListRecipe;
        private ToolStripMenuItem mnuClonearecipe;
        private ToolStripMenuItem MnuMealsList;
        private ToolStripMenuItem MnuListOfCookbooks;
        private ToolStripMenuItem mnuNewCookbook;
        private ToolStripMenuItem mnuAutocreatecookbook;
        private ToolStripMenuItem mnuEditdata;
    }
}