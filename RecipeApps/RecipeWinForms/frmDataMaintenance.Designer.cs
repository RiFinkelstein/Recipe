namespace RecipeWinForms
{
    partial class frmDataMaintenance
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
            tblOptionButtons = new TableLayoutPanel();
            optUsers = new RadioButton();
            optCuisines = new RadioButton();
            optIngredients = new RadioButton();
            optMeasurements = new RadioButton();
            optCourses = new RadioButton();
            gData = new DataGridView();
            btnSave = new Button();
            tblMain.SuspendLayout();
            tblOptionButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gData).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.Controls.Add(tblOptionButtons, 0, 0);
            tblMain.Controls.Add(gData, 1, 0);
            tblMain.Controls.Add(btnSave, 1, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 75.53517F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 24.4648323F));
            tblMain.Size = new Size(800, 450);
            tblMain.TabIndex = 0;
            // 
            // tblOptionButtons
            // 
            tblOptionButtons.ColumnCount = 1;
            tblOptionButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblOptionButtons.Controls.Add(optUsers, 0, 0);
            tblOptionButtons.Controls.Add(optCuisines, 0, 1);
            tblOptionButtons.Controls.Add(optIngredients, 0, 2);
            tblOptionButtons.Controls.Add(optMeasurements, 0, 3);
            tblOptionButtons.Controls.Add(optCourses, 0, 4);
            tblOptionButtons.Dock = DockStyle.Fill;
            tblOptionButtons.Location = new Point(3, 3);
            tblOptionButtons.Name = "tblOptionButtons";
            tblOptionButtons.RowCount = 5;
            tblMain.SetRowSpan(tblOptionButtons, 2);
            tblOptionButtons.RowStyles.Add(new RowStyle());
            tblOptionButtons.RowStyles.Add(new RowStyle());
            tblOptionButtons.RowStyles.Add(new RowStyle());
            tblOptionButtons.RowStyles.Add(new RowStyle());
            tblOptionButtons.RowStyles.Add(new RowStyle());
            tblOptionButtons.Size = new Size(250, 444);
            tblOptionButtons.TabIndex = 0;
            // 
            // optUsers
            // 
            optUsers.AutoSize = true;
            optUsers.Location = new Point(3, 3);
            optUsers.Name = "optUsers";
            optUsers.Size = new Size(65, 24);
            optUsers.TabIndex = 0;
            optUsers.TabStop = true;
            optUsers.Text = "Users";
            optUsers.UseVisualStyleBackColor = true;
            // 
            // optCuisines
            // 
            optCuisines.AutoSize = true;
            optCuisines.Location = new Point(3, 33);
            optCuisines.Name = "optCuisines";
            optCuisines.Size = new Size(77, 24);
            optCuisines.TabIndex = 1;
            optCuisines.TabStop = true;
            optCuisines.Text = "Cuisine";
            optCuisines.UseVisualStyleBackColor = true;
            // 
            // optIngredients
            // 
            optIngredients.AutoSize = true;
            optIngredients.Location = new Point(3, 63);
            optIngredients.Name = "optIngredients";
            optIngredients.Size = new Size(104, 24);
            optIngredients.TabIndex = 2;
            optIngredients.TabStop = true;
            optIngredients.Text = "Ingredients";
            optIngredients.UseVisualStyleBackColor = true;
            // 
            // optMeasurements
            // 
            optMeasurements.AutoSize = true;
            optMeasurements.Location = new Point(3, 93);
            optMeasurements.Name = "optMeasurements";
            optMeasurements.Size = new Size(126, 24);
            optMeasurements.TabIndex = 3;
            optMeasurements.TabStop = true;
            optMeasurements.Text = "Measurements";
            optMeasurements.UseVisualStyleBackColor = true;
            // 
            // optCourses
            // 
            optCourses.AutoSize = true;
            optCourses.Location = new Point(3, 123);
            optCourses.Name = "optCourses";
            optCourses.Size = new Size(81, 24);
            optCourses.TabIndex = 4;
            optCourses.TabStop = true;
            optCourses.Text = "Courses";
            optCourses.UseVisualStyleBackColor = true;
            // 
            // gData
            // 
            gData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gData.Dock = DockStyle.Fill;
            gData.Location = new Point(259, 3);
            gData.Name = "gData";
            gData.RowHeadersWidth = 51;
            gData.Size = new Size(538, 333);
            gData.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(686, 401);
            btnSave.Margin = new Padding(20);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // frmDataMaintenance
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblMain);
            Name = "frmDataMaintenance";
            Text = "Data Maintenance";
            tblMain.ResumeLayout(false);
            tblOptionButtons.ResumeLayout(false);
            tblOptionButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblOptionButtons;
        private RadioButton optUsers;
        private RadioButton optCuisines;
        private RadioButton optIngredients;
        private RadioButton optMeasurements;
        private RadioButton optCourses;
        private DataGridView gData;
        private Button btnSave;
    }
}