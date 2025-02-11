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
            optCuisine = new RadioButton();
            optIngredient = new RadioButton();
            optMeasurements = new RadioButton();
            optCourse = new RadioButton();
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
            tblOptionButtons.Controls.Add(optCuisine, 0, 1);
            tblOptionButtons.Controls.Add(optIngredient, 0, 2);
            tblOptionButtons.Controls.Add(optMeasurements, 0, 3);
            tblOptionButtons.Controls.Add(optCourse, 0, 4);
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
            // optCuisine
            // 
            optCuisine.AutoSize = true;
            optCuisine.Location = new Point(3, 33);
            optCuisine.Name = "optCuisine";
            optCuisine.Size = new Size(77, 24);
            optCuisine.TabIndex = 1;
            optCuisine.TabStop = true;
            optCuisine.Text = "Cuisine";
            optCuisine.UseVisualStyleBackColor = true;
            // 
            // optIngredient
            // 
            optIngredient.AutoSize = true;
            optIngredient.Location = new Point(3, 63);
            optIngredient.Name = "optIngredient";
            optIngredient.Size = new Size(98, 24);
            optIngredient.TabIndex = 2;
            optIngredient.TabStop = true;
            optIngredient.Text = "Ingredient";
            optIngredient.UseVisualStyleBackColor = true;
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
            // optCourse
            // 
            optCourse.AutoSize = true;
            optCourse.Location = new Point(3, 123);
            optCourse.Name = "optCourse";
            optCourse.Size = new Size(75, 24);
            optCourse.TabIndex = 4;
            optCourse.TabStop = true;
            optCourse.Text = "Course";
            optCourse.UseVisualStyleBackColor = true;
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
        private RadioButton optCuisine;
        private RadioButton optIngredient;
        private RadioButton optMeasurements;
        private RadioButton optCourse;
        private DataGridView gData;
        private Button btnSave;
    }
}