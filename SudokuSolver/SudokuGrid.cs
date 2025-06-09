using System;
using System.Drawing;
using System.Windows.Forms;

namespace SudokuSolver
{
    /// <summary>
    /// Represents a 9x9 Sudoku grid as a Windows Forms user control.
    /// </summary>
    public class SudokuGrid : UserControl
    {
        /// <summary>TextBox controls representing each Sudoku cell.</summary>
        private TextBox[,] cells;
        /// <summary>Current state of the Sudoku grid.</summary>
        private int[,] grid;
        /// <summary>Original puzzle state for marking prefilled values.</summary>
        private int[,] originalGrid;

        public SudokuGrid()
        {
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            this.Size = new Size(375, 375);
            this.BackColor = Color.Black;

            cells = new TextBox[9, 9];
            grid = new int[9, 9];
            originalGrid = new int[9, 9];

            for (int row = 0; row < 9; row++) {
                for (int col = 0; col < 9; col++) {
                    TextBox cell = new TextBox();
                    cell.Size = new Size(35, 35);
                    cell.Location = new Point(
                        col * 40 + (col / 3) * 5 + 5,
                        row * 40 + (row / 3) * 5 + 5
                    );
                    cell.TextAlign = HorizontalAlignment.Center;
                    cell.Font = new Font("Arial", 14, FontStyle.Bold);
                    cell.MaxLength = 1;
                    cell.Tag = new Point(row, col);

                    cell.KeyPress += Cell_KeyPress;
                    cell.TextChanged += Cell_TextChanged;
                    cell.Enter += Cell_Enter;

                    cell.PreviewKeyDown += Cell_PreviewKeyDown;
                    cell.KeyDown += Cell_KeyDown;

                    cells[row, col] = cell;
                    this.Controls.Add(cell);
                }
            }

            UpdateCellColors();
        }

        private void Cell_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits 1-9 and control characters (like backspace)
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar) || e.KeyChar == '0')) {
                // Does not allow unwanted characters to proceed
                e.Handled = true;
            }
        }

        private void Cell_TextChanged(object sender, EventArgs e)
        {
            TextBox cell = sender as TextBox;
            Point pos = (Point)cell.Tag;

            if (string.IsNullOrEmpty(cell.Text)) {
                grid[pos.X, pos.Y] = 0;
            }
            else if (int.TryParse(cell.Text, out int value) && value >= 1 && value <= 9) {
                grid[pos.X, pos.Y] = value;

                // Automatically move to next cell to the right
                int nextRow = pos.X;
                int nextCol = pos.Y + 1;
                if (nextCol >= 9) {
                    nextCol = 0;
                    nextRow++;
                }
                if (nextRow < 9)
                    cells[nextRow, nextCol].Focus();
            }
            else {
                cell.Text = "";
                grid[pos.X, pos.Y] = 0;
            }

            UpdateCellColors();
        }

        private void Cell_Enter(object sender, EventArgs e)
        {
            // Selects all text when a cell gains focus for easier replacement.
            TextBox cell = sender as TextBox;
            cell.BeginInvoke((MethodInvoker)(() => cell.SelectAll()));
        }

        private void Cell_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // Mark arrow keys as input keys so KeyDown will fire
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right) {
                e.IsInputKey = true;
            }
        }

        private void Cell_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox cell = sender as TextBox;
            Point pos = (Point)cell.Tag;
            int row = pos.X;
            int col = pos.Y;

            switch (e.KeyCode) {
                case Keys.Left:
                    if (col > 0)
                        cells[row, col - 1].Focus();
                    break;
                case Keys.Right:
                    if (col < 8)
                        cells[row, col + 1].Focus();
                    break;
                case Keys.Up:
                    if (row > 0)
                        cells[row - 1, col].Focus();
                    break;
                case Keys.Down:
                    if (row < 8)
                        cells[row + 1, col].Focus();
                    break;
            }
        }



        /// <summary>
        /// Updates the background and foreground colors of all cells in the Sudoku grid.
        /// Highlights 3x3 blocks with alternating colors and marks cells with conflicts in red.
        /// </summary>
        private void UpdateCellColors()
        {
            for (int row = 0; row < 9; row++) {
                for (int col = 0; col < 9; col++) {
                    TextBox cell = cells[row, col];

                    // Set background color based on 3x3 blocks
                    if ((row / 3 + col / 3) % 2 == 0)
                        cell.BackColor = Color.LightGray;
                    else
                        cell.BackColor = Color.White;

                    cell.ForeColor = Color.Black;

                    // Highlight conflicts
                    if (grid[row, col] != 0 && HasConflict(row, col)) {
                        cell.BackColor = Color.LightCoral;
                    }
                }
            }
        }

        /// <summary>
        /// Colors the cells that were filled by the solver (i.e., not part of the original grid).
        /// </summary>
        public void ColorSolution()
        {

            for (int row = 0; row < 9; row++) {
                for (int col = 0; col < 9; col++) {
                    // Color cells that were filled by the solver (i.e., not part of original grid)
                    if (originalGrid[row, col] == 0 && grid[row, col] != 0) {
                        cells[row,col].ForeColor = Color.Blue;
                    }
                }
            }
        }

        /// <summary>
        /// Stores the current grid state as the original puzzle for future comparison.
        /// </summary>
        public void StoreOriginalGrid()
        {
            for (int row = 0; row < 9; row++) {
                for (int col = 0; col < 9; col++) {
                    originalGrid[row, col] = grid[row, col];
                }
            }
        }

        /// <summary>
        /// Checks if the cell at the specified row and column has any conflicts with other cells in the same row, column, or 3x3 box.
        /// </summary>
        /// <param name="row">Row index of the cell to check (0-8).</param>
        /// <param name="col">Col index of the cell to check (0-8)</param>
        /// <returns>True if there is a conflict, false otherwise.</returns>
        private bool HasConflict(int row, int col)
        {
            int value = grid[row, col];
            if (value == 0) return false;

            // Check row
            for (int c = 0; c < 9; c++) {
                if (c != col && grid[row, c] == value)
                    return true;
            }

            // Check column
            for (int r = 0; r < 9; r++) {
                if (r != row && grid[r, col] == value)
                    return true;
            }

            // Check 3x3 box
            int boxRow = (row / 3) * 3;
            int boxCol = (col / 3) * 3;
            for (int r = boxRow; r < boxRow + 3; r++) {
                for (int c = boxCol; c < boxCol + 3; c++) {
                    if ((r != row || c != col) && grid[r, c] == value)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Sets the Sudoku grid to the specified values and updates the UI.
        /// </summary>
        /// <param name="newGrid">
        /// A 9x9 integer array representing the new state of the Sudoku grid. 
        /// Cells with value 0 are considered empty.
        /// </param>
        public void SetGrid(int[,] newGrid)
        {
            for (int row = 0; row < 9; row++) {
                for (int col = 0; col < 9; col++) {
                    grid[row, col] = newGrid[row, col];

                    if (newGrid[row, col] == 0)
                        cells[row, col].Text = "";
                    else
                        cells[row, col].Text = newGrid[row, col].ToString();
                }
            }
            UpdateCellColors();
        }

        /// <summary>
        /// Returns a copy of the current Sudoku grid as a 2D integer array.
        /// </summary>
        /// <returns>
        /// A 9x9 integer array representing the current state of the Sudoku grid.
        /// </returns>
        public int[,] GetGrid()
        {
            int[,] result = new int[9, 9];
            Array.Copy(grid, result, grid.Length);
            return result;
        }

        /// <summary>
        /// Clears the entire grid and resets all cell values.
        /// </summary>
        public void ClearGrid()
        {
            for (int row = 0; row < 9; row++) {
                for (int col = 0; col < 9; col++) {
                    grid[row, col] = 0;
                    cells[row, col].Text = "";
                }
            }
            UpdateCellColors();
        }

        /// <summary>
        /// Checks if grid does not have any conflicts.
        /// </summary>
        /// <returns>
        /// True if the grid does not contain any conflicts, false otherwise.
        /// </returns>
        public bool IsValid()
        {
            for (int row = 0; row < 9; row++) {
                for (int col = 0; col < 9; col++) {
                    if (HasConflict(row, col))
                        return false;
                }
            }
            return true;
        }
    }
}
