namespace SudokuSolver
{
    public class Solver
    {
        private int[,] grid;

        public Solver()
        {
            grid = new int[9, 9];
        }

        /// <summary>
        /// Recursively solves the Sudoku puzzle using backtracking.
        /// </summary>
        /// <param name="grid">The Sudoku grid.</param>
        /// <param name="r">The row index of the cell.</param>
        /// <param name="c">The column index of the cell.</param>
        /// <returns>True if the puzzle was solved, otherwise false.</returns>
        public bool Solve(int[,] grid, int r = 0, int c = 0)
        {
            // Solved whole grid, return True
            if (r == 9) {
                return true;

            }
            // If column is 9, move to next row and reset column
            if (c == 9) {
                return Solve(grid, r + 1, 0);
            }
            // If cell is not empty, move to next column
            if (grid[r, c] != 0) {
                return Solve(grid, r, c + 1);
            }
            // If cell is empty, try numbers 1-9
            for (int k = 1; k <= 9; k++) {
                // Check if placing number k is valid in the current cell
                if (IsValid(grid, r, c, k)) {
                    grid[r, c] = k;
                    // Recursively try to solve the rest of the grid by moving to the next cell
                    if (Solve(grid, r, c + 1)) {
                        return true;
                    }
                    grid[r, c] = 0;
                }
            }
            // If no number can be placed, return false
            return false;

        }

        /// <summary>
        /// Checks if placing a given number in a specific cell is valid according to Sudoku rules.
        /// </summary>
        /// <param name="grid">The Sudoku grid.</param>
        /// <param name="r">The row index of the cell.</param>
        /// <param name="c">The column index of the cell.</param>
        /// <param name="k">The number to check for validity.</param>
        /// <returns>True if the number can be placed in the cell, otherwise false.</returns>
        private bool IsValid(int[,] grid, int r, int c, int k)
        {
            bool notInRow = true;
            for (int i = 0; i < 9; i++) {
                if (grid[r, i] == k) {
                    notInRow = false; // k is already in the row
                }
            }

            bool notInCol = true;
            for (int i = 0; i < 9; i++) {
                if (grid[i, c] == k) {
                    notInCol = false; // k is already in the column
                }
            }

            // Check if k is not present in the 3x3 box
            bool notInBox = true;
            int boxStartRow = (r / 3) * 3;
            int boxStartCol = (c / 3) * 3;

            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (grid[boxStartRow + i, boxStartCol + j] == k) {
                        notInBox = false; // k is already in the 3x3 box
                    }
                }
            }

            return notInRow && notInCol && notInBox;
        }
    }
}
