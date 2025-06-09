using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SudokuSolver
{
    public partial class MainForm : Form
    {
        private Solver solver = new Solver();

        public MainForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SavePuzzle();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadPuzzle();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearPuzzle();
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            SolvePuzzle();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            ShowInstructions();
        }

        /// <summary>
        /// Attempts to solve the current puzzle and update the UI with the solution.
        /// </summary>
        private void SolvePuzzle()
        {
            try {
                if (!sudokuGrid.IsValid()) {
                    MessageBox.Show("Invalid Sudoku puzzle. Please check your input for conflicts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int[,] puzzle = sudokuGrid.GetGrid();
                sudokuGrid.StoreOriginalGrid();
                if (solver.Solve(puzzle)) {
                    sudokuGrid.SetGrid(puzzle);
                    sudokuGrid.ColorSolution();
                    MessageBox.Show("Sudoku puzzle solved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("No solution exists for the given Sudoku puzzle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"An error occurred while solving the puzzle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Clears the grid after confirming with the user.
        /// </summary>
        private void ClearPuzzle()
        {
            var result = MessageBox.Show(
                "Are you sure you want to clear the puzzle?",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (result == DialogResult.Yes) {
                sudokuGrid.ClearGrid();
            }
        }

        /// <summary>
        /// Saves the current puzzle to a file using SaveFileDialog.
        /// </summary>
        private void SavePuzzle()
        {
            string saveDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "saves");
            Directory.CreateDirectory(saveDir);  // Creates the folder if it doesn't exist

            try {
                using (SaveFileDialog dialog = new SaveFileDialog()) {
                    dialog.Filter = "Sudoku files (*.sud)|*.sud|Text files (*.txt)|*.txt";
                    dialog.Title = "Save Sudoku Puzzle";
                    dialog.DefaultExt = "sud";
                    dialog.InitialDirectory = saveDir;
                    dialog.FileName = "puzzle_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                    if (dialog.ShowDialog() == DialogResult.OK) {
                        GameData gameData = new GameData();
                        gameData.Grid = sudokuGrid.GetGrid();
                        gameData.SaveToFile(dialog.FileName);

                        MessageBox.Show($"Puzzle saved to: {Path.GetFullPath(dialog.FileName)}",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Error saving puzzle: {ex.Message}", "Save Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads a saved puzzle from a file using OpenFileDialog.
        /// </summary>
        private void LoadPuzzle()
        {

            string saveDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "saves");
            Directory.CreateDirectory(saveDir);  // Creates the folder if it doesn't exist

            try {
                using (OpenFileDialog dialog = new OpenFileDialog()) {
                    dialog.Filter = "Sudoku files (*.sud)|*.sud|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    dialog.Title = "Load Sudoku Puzzle";
                    dialog.InitialDirectory = saveDir;

                    if (dialog.ShowDialog() == DialogResult.OK) {
                        GameData gameData = GameData.LoadFromFile(dialog.FileName);
                        sudokuGrid.SetGrid(gameData.Grid);
                        MessageBox.Show($"Puzzle loaded from: {Path.GetFileName(dialog.FileName)}",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Error loading puzzle: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Displays a message box with usage instructions for the application.
        /// </summary>
        private void ShowInstructions()
        {
            string instructions = @"SUDOKU SOLVER INSTRUCTIONS

HOW TO USE:
• Enter numbers 1-9 in empty cells
• Use 'Solve' to automatically solve the puzzle
• Use 'Clear' to start over
• Use 'Save' to save your puzzle
• Use 'Load' to load a saved puzzle

FEATURES:
• Simple sudoku solver using backtracking
• Conflict highlighting (red cells)
• 3x3 block visual grouping
• Save/Load functionality
• Arrow key navigation between cells
• Automatically moves to the next cell after entry

FILE FORMAT:
• Saves as .sud or .txt files
• 9 rows, 9 columns, comma-separated
• Use 0 for empty cells
• Comments start with #
• Top left cell is indexed as 1,1

CONTROLS:
• Click any cell to edit
• Only numbers 1-9 are allowed";

            MessageBox.Show(instructions, "Instructions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}