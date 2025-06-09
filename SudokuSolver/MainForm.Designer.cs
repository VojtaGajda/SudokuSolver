namespace SudokuSolver
{
    partial class MainForm
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.solveButton = new System.Windows.Forms.Button();
            this.aboutLabel = new System.Windows.Forms.Label();
            this.aboutButton = new System.Windows.Forms.Button();
            this.sudokuGrid = new SudokuSolver.SudokuGrid();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(436, 138);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(154, 48);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(436, 192);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(154, 48);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(436, 266);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(154, 48);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear Grid";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(436, 320);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(154, 48);
            this.solveButton.TabIndex = 4;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // aboutLabel
            // 
            this.aboutLabel.AutoSize = true;
            this.aboutLabel.Location = new System.Drawing.Point(433, 12);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(178, 32);
            this.aboutLabel.TabIndex = 5;
            this.aboutLabel.Text = "© 2025              Sudoku Solver\r\nAuthor:        Vojtěch Gajdušek";
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(436, 70);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(154, 48);
            this.aboutButton.TabIndex = 6;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // sudokuGrid
            // 
            this.sudokuGrid.BackColor = System.Drawing.Color.Black;
            this.sudokuGrid.Location = new System.Drawing.Point(12, 12);
            this.sudokuGrid.Name = "sudokuGrid";
            this.sudokuGrid.Size = new System.Drawing.Size(376, 375);
            this.sudokuGrid.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 423);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.aboutLabel);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.sudokuGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(660, 470);
            this.MinimumSize = new System.Drawing.Size(660, 470);
            this.Name = "MainForm";
            this.Text = "Sudoku Solver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SudokuGrid sudokuGrid;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Label aboutLabel;
        private System.Windows.Forms.Button aboutButton;
    }
}

