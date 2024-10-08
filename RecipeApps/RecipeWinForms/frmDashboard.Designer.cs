namespace RecipeWinForms
{
    partial class frmDashboard
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
            lblTitle = new Label();
            lblDescription = new Label();
            tblDetails = new TableLayoutPanel();
            lblType = new Label();
            lblNumber = new Label();
            lblRecipes = new Label();
            lblMeals = new Label();
            lblCookbooks = new Label();
            lblRecipesNum = new Label();
            lblMealsnum = new Label();
            lblCookbooksnum = new Label();
            tblListButtons = new TableLayoutPanel();
            btnRecipeList = new Button();
            btnMealList = new Button();
            btnCookbookList = new Button();
            tblMain.SuspendLayout();
            tblDetails.SuspendLayout();
            tblListButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(lblTitle, 0, 0);
            tblMain.Controls.Add(lblDescription, 0, 1);
            tblMain.Controls.Add(tblDetails, 0, 2);
            tblMain.Controls.Add(tblListButtons, 0, 3);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.Size = new Size(800, 450);
            tblMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 25F);
            lblTitle.Location = new Point(132, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(535, 57);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Hearty Health Desktop App";
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top;
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 16F);
            lblDescription.Location = new Point(17, 57);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(765, 74);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Welcome to the Hearty Health desktop app. In this app you can create recipes and cookbooks. ";
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblDetails
            // 
            tblDetails.Anchor = AnchorStyles.None;
            tblDetails.ColumnCount = 2;
            tblDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblDetails.Controls.Add(lblType, 0, 0);
            tblDetails.Controls.Add(lblNumber, 1, 0);
            tblDetails.Controls.Add(lblRecipes, 0, 1);
            tblDetails.Controls.Add(lblMeals, 0, 2);
            tblDetails.Controls.Add(lblCookbooks, 0, 3);
            tblDetails.Controls.Add(lblRecipesNum, 1, 1);
            tblDetails.Controls.Add(lblMealsnum, 1, 2);
            tblDetails.Controls.Add(lblCookbooksnum, 1, 3);
            tblDetails.Location = new Point(275, 148);
            tblDetails.Name = "tblDetails";
            tblDetails.RowCount = 4;
            tblDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblDetails.Size = new Size(250, 125);
            tblDetails.TabIndex = 2;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.BackColor = Color.FromArgb(255, 224, 192);
            lblType.Dock = DockStyle.Fill;
            lblType.Font = new Font("Segoe UI", 12F);
            lblType.Location = new Point(3, 0);
            lblType.Name = "lblType";
            lblType.Size = new Size(119, 31);
            lblType.TabIndex = 0;
            lblType.Text = "Type";
            lblType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.BackColor = Color.FromArgb(255, 224, 192);
            lblNumber.Dock = DockStyle.Fill;
            lblNumber.Font = new Font("Segoe UI", 12F);
            lblNumber.Location = new Point(128, 0);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(119, 31);
            lblNumber.TabIndex = 1;
            lblNumber.Text = "Number";
            lblNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRecipes
            // 
            lblRecipes.AutoSize = true;
            lblRecipes.Dock = DockStyle.Fill;
            lblRecipes.Font = new Font("Segoe UI", 12F);
            lblRecipes.Location = new Point(3, 31);
            lblRecipes.Name = "lblRecipes";
            lblRecipes.Size = new Size(119, 31);
            lblRecipes.TabIndex = 2;
            lblRecipes.Text = "Recipes";
            lblRecipes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMeals
            // 
            lblMeals.AutoSize = true;
            lblMeals.Dock = DockStyle.Fill;
            lblMeals.Font = new Font("Segoe UI", 12F);
            lblMeals.Location = new Point(3, 62);
            lblMeals.Name = "lblMeals";
            lblMeals.Size = new Size(119, 31);
            lblMeals.TabIndex = 3;
            lblMeals.Text = "Meals";
            lblMeals.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCookbooks
            // 
            lblCookbooks.AutoSize = true;
            lblCookbooks.Dock = DockStyle.Fill;
            lblCookbooks.Font = new Font("Segoe UI", 12F);
            lblCookbooks.Location = new Point(3, 93);
            lblCookbooks.Name = "lblCookbooks";
            lblCookbooks.Size = new Size(119, 32);
            lblCookbooks.TabIndex = 4;
            lblCookbooks.Text = "Cookbooks";
            lblCookbooks.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRecipesNum
            // 
            lblRecipesNum.AutoSize = true;
            lblRecipesNum.Dock = DockStyle.Fill;
            lblRecipesNum.Font = new Font("Segoe UI", 12F);
            lblRecipesNum.Location = new Point(128, 31);
            lblRecipesNum.Name = "lblRecipesNum";
            lblRecipesNum.Size = new Size(119, 31);
            lblRecipesNum.TabIndex = 5;
            lblRecipesNum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMealsnum
            // 
            lblMealsnum.AutoSize = true;
            lblMealsnum.Dock = DockStyle.Fill;
            lblMealsnum.Font = new Font("Segoe UI", 12F);
            lblMealsnum.Location = new Point(128, 62);
            lblMealsnum.Name = "lblMealsnum";
            lblMealsnum.Size = new Size(119, 31);
            lblMealsnum.TabIndex = 6;
            lblMealsnum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCookbooksnum
            // 
            lblCookbooksnum.AutoSize = true;
            lblCookbooksnum.Dock = DockStyle.Fill;
            lblCookbooksnum.Font = new Font("Segoe UI", 12F);
            lblCookbooksnum.Location = new Point(128, 93);
            lblCookbooksnum.Name = "lblCookbooksnum";
            lblCookbooksnum.Size = new Size(119, 32);
            lblCookbooksnum.TabIndex = 7;
            lblCookbooksnum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblListButtons
            // 
            tblListButtons.Anchor = AnchorStyles.Top;
            tblListButtons.AutoSize = true;
            tblListButtons.ColumnCount = 3;
            tblListButtons.ColumnStyles.Add(new ColumnStyle());
            tblListButtons.ColumnStyles.Add(new ColumnStyle());
            tblListButtons.ColumnStyles.Add(new ColumnStyle());
            tblListButtons.Controls.Add(btnRecipeList, 0, 0);
            tblListButtons.Controls.Add(btnMealList, 1, 0);
            tblListButtons.Controls.Add(btnCookbookList, 2, 0);
            tblListButtons.Location = new Point(211, 293);
            tblListButtons.Name = "tblListButtons";
            tblListButtons.RowCount = 1;
            tblListButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblListButtons.Size = new Size(378, 44);
            tblListButtons.TabIndex = 3;
            // 
            // btnRecipeList
            // 
            btnRecipeList.AutoSize = true;
            btnRecipeList.Font = new Font("Segoe UI", 12F);
            btnRecipeList.Location = new Point(3, 3);
            btnRecipeList.Name = "btnRecipeList";
            btnRecipeList.Size = new Size(113, 38);
            btnRecipeList.TabIndex = 0;
            btnRecipeList.Text = "Recipe List";
            btnRecipeList.UseVisualStyleBackColor = true;
            // 
            // btnMealList
            // 
            btnMealList.AutoSize = true;
            btnMealList.Font = new Font("Segoe UI", 12F);
            btnMealList.Location = new Point(122, 3);
            btnMealList.Name = "btnMealList";
            btnMealList.Size = new Size(99, 38);
            btnMealList.TabIndex = 1;
            btnMealList.Text = "Meal List";
            btnMealList.UseVisualStyleBackColor = true;
            // 
            // btnCookbookList
            // 
            btnCookbookList.AutoSize = true;
            btnCookbookList.Font = new Font("Segoe UI", 12F);
            btnCookbookList.Location = new Point(227, 3);
            btnCookbookList.Name = "btnCookbookList";
            btnCookbookList.Size = new Size(148, 38);
            btnCookbookList.TabIndex = 2;
            btnCookbookList.Text = "Cookbook List";
            btnCookbookList.UseVisualStyleBackColor = true;
            // 
            // frmDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblMain);
            Name = "frmDashboard";
            Text = "Dashboard";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblDetails.ResumeLayout(false);
            tblDetails.PerformLayout();
            tblListButtons.ResumeLayout(false);
            tblListButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblTitle;
        private Label lblDescription;
        private TableLayoutPanel tblDetails;
        private Label lblType;
        private Label lblNumber;
        private Label lblRecipes;
        private Label lblMeals;
        private Label lblCookbooks;
        private Label lblRecipesNum;
        private Label lblMealsnum;
        private Label lblCookbooksnum;
        private TableLayoutPanel tblListButtons;
        private Button btnRecipeList;
        private Button btnMealList;
        private Button btnCookbookList;
    }
}