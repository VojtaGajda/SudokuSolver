using System;
using System.IO;
using System.Text;

namespace SudokuSolver
{
    /// <summary>
    /// Represents the game data for a Sudoku puzzle, including the grid and creation timestamp.
    /// </summary>
    public class GameData
    {
        /// <summary> The 9x9 Sudoku grid. Values range from 0 (empty) to 9.</summary>
        public int[,] Grid { get; set; }
        public DateTime CreatedDate { get; set; }
        public GameData()
        {
            Grid = new int[9, 9];
            CreatedDate = DateTime.Now;
        }

        /// <summary>
        /// Saves the current game data to a file in a custom plain-text format.
        /// </summary>
        /// <param name="filePath">The file path where the data should be saved.</param>
        /// <remarks>
        /// The file format is as follows:
        /// - The first two lines are comments (starting with '#') containing metadata and format information.
        /// - Each subsequent line represents one row of the Sudoku grid.
        /// - Each row contains 9 comma-separated integers (0–9), where 0 denotes an empty cell.
        /// - There are exactly 9 such rows in the file.
        /// 
        /// Example:
        /// <code>
        /// # Sudoku Game - Created: 2025-06-09 10:00:00
        /// # Format: 9 rows, 9 columns, 0 for empty cells
        /// 5,3,0,0,7,0,0,0,0
        /// 6,0,0,1,9,5,0,0,0
        /// ...
        /// </code>
        /// </remarks>
        public void SaveToFile(string filePath)
        {
            try {
                using (StreamWriter writer = new StreamWriter(filePath)) {
                    writer.WriteLine($"# Sudoku Game - Created: {CreatedDate}");
                    writer.WriteLine("# Format: 9 rows, 9 columns, 0 for empty cells");

                    for (int row = 0; row < 9; row++) {
                        StringBuilder sb = new StringBuilder();
                        for (int col = 0; col < 9; col++) {
                            sb.Append(Grid[row, col]);
                            if (col < 8) sb.Append(",");
                        }
                        writer.WriteLine(sb.ToString());
                    }
                }
            }
            catch (Exception ex) {
                throw new Exception($"{ex.Message}");
            }
        }

        /// <summary>
        /// Loads game data from a file in the expected Sudoku format.
        /// </summary>
        /// <param name="filePath">The path to the file containing the game data.</param>
        /// <returns>A <see cref="GameData"/> instance populated with the loaded grid.</returns>
        /// <remarks>
        /// The file format is as follows:
        /// - The first two lines are comments (starting with '#') containing metadata and format information.
        /// - Each subsequent line represents one row of the Sudoku grid.
        /// - Each row contains 9 comma-separated integers (0–9), where 0 denotes an empty cell.
        /// - There are exactly 9 such rows in the file.
        /// 
        /// Example:
        /// <code>
        /// # Sudoku Game - Created: 2025-06-09 10:00:00
        /// # Format: 9 rows, 9 columns, 0 for empty cells
        /// 5,3,0,0,7,0,0,0,0
        /// 6,0,0,1,9,5,0,0,0
        /// ...
        /// </code>
        /// </remarks>
        public static GameData LoadFromFile(string filePath)
        {
            try {
                GameData gameData = new GameData();
                using (StreamReader reader = new StreamReader(filePath)) {
                    string line;
                    int row = 0;

                    while ((line = reader.ReadLine()) != null) {
                        if (line.StartsWith("#") || string.IsNullOrWhiteSpace(line))
                            continue;

                        if (row >= 9) break;

                        string[] values = line.Split(',');
                        if (values.Length != 9)
                            throw new Exception("Invalid file format - each row must have 9 values");

                        for (int col = 0; col < 9; col++) {
                            if (int.TryParse(values[col].Trim(), out int value)) {
                                if (value >= 0 && value <= 9)
                                    gameData.Grid[row, col] = value;
                                else
                                    throw new Exception($"Invalid value {value} at position ({row + 1}, {col + 1})");
                            }
                            else {
                                throw new Exception($"Invalid number format at position ({row + 1}, {col + 1})");
                            }
                        }
                        row++;
                    }

                    if (row != 9)
                        throw new Exception("Invalid file format - must contain exactly 9 rows");
                }

                return gameData;
            }
            catch (Exception ex) {
                throw new Exception($"{ex.Message}");
            }
        }

    }
}