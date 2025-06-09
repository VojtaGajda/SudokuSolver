# Sudoku Solver – Windows Forms Application

## 🌐 Language / Jazyk
- [🇬🇧 English](#english-version)
- [🇨🇿 Česky](#ceska-verze)

---

## 🇬🇧 English Version

# Sudoku Solver – Windows Forms Application

## 👨‍💻 Author
Vojtěch Gajdušek  
Date: June 9, 2025

---

## 🧩 Project Overview
This application solves classic 9x9 Sudoku puzzles.  
The user can input the puzzle manually or load it from a saved file.  
It features a custom solving algorithm and supports saving/loading the puzzle state.

Sudoku is solved using a **backtracking** algorithm that employs **recursion** to explore all valid values for empty cells.

---

## ⚙️ Features
- Manual input using keyboard or mouse
- Automatically advances to the next cell after entering a number
- Arrow key navigation (↑ ↓ ← →)
- Automatic solving using a custom algorithm
- Save the current puzzle to a file
- Load a puzzle from a file
- Input validation (only digits 1–9 or empty cells)

---

## 💻 Technologies Used
- .NET Framework 4.7.2
- Windows Forms (WinForms)

---

## 💾 Saved Game Format

The application supports saving and loading the puzzle state from `.sud` or `.txt` files.

### 📄 File structure:
- The file may contain **comment lines** starting with `#`.
- The file must contain exactly **9 rows**, each with **9 comma-separated integers** representing Sudoku cells:
  - Values `1–9` represent filled cells,
  - Value `0` represents an **empty cell**.
- Comment lines are ignored during loading.

### 🧪 Example:
```text
# Sudoku Game – Created: 2025-06-09 10:00:00
# Format: 9 rows, 9 columns, 0 for empty cells
5,3,0,0,7,0,0,0,0
6,0,0,1,9,5,0,0,0
0,9,8,0,0,0,0,6,0
8,0,0,0,6,0,0,0,3
4,0,0,8,0,3,0,0,1
7,0,0,0,2,0,0,0,6
0,6,0,0,0,0,2,8,0
0,0,0,4,1,9,0,0,5
0,0,0,0,8,0,0,7,9
```

---

## 🇨🇿 Česká verze

# Sudoku Solver – Windows Forms aplikace

## 👨‍💻 Autor
Vojtěch Gajdušek  
Datum: 9.6.2025 

---

## 🧩 Popis projektu
Tato aplikace slouží k řešení klasické Sudoku hádanky velikosti 9x9. 
Uživatel může zadat vstupní hodnoty ručně nebo načíst uloženou hru. 
Aplikace obsahuje vlastní řešicí algoritmus a umožňuje uložení/načtení stavu hry.
Sudoku je řešeno pomocí **backtrackingu** a algoritmus využívá **rekurzi** k procházení všech možných hodnot v prázdných polích.

---

## ⚙️ Funkce
- Zadávání Sudoku ručně pomocí klávesnice/myši
- Automatické posouvání na další pole po zadání čísla
- Pohyb v poli pomocí šipek (↑ ↓ ← →)
- Automatické řešení Sudoku pomocí vlastního algoritmu
- Uložení aktuální hry do souboru
- Načtení uložené hry ze souboru
- Validace vstupu (pouze čísla 1–9 nebo prázdné)

---

## 💻 Použité technologie
- .NET Framework 4.7.2
- Windows Forms (WinForms)

---

## 💾 Formát uložené hry

Aplikace umožňuje ukládat a načítat stav hry ze souborů s příponou `.sud` nebo `.txt`.

### 📄 Struktura souboru:
- Soubor může obsahovat komentáře - řádky začínájící znakem `#`
- Soubor musí obsahovat **9 řádků**, kde každý řádek obsahuje **9 čísel** oddělených čárkami reprezentující jednotlivé pole:
  - Hodnoty `1–9` značí vyplněná pole,
  - Hodnota `0` značí **prázdné pole**.
- Komentářové řádky jsou při načítání ignorovány.

### 🧪 Příklad:
```text
# Sudoku Game – Created: 2025-06-09 10:00:00
# Format: 9 rows, 9 columns, 0 for empty cells
5,3,0,0,7,0,0,0,0
6,0,0,1,9,5,0,0,0
0,9,8,0,0,0,0,6,0
8,0,0,0,6,0,0,0,3
4,0,0,8,0,3,0,0,1
7,0,0,0,2,0,0,0,6
0,6,0,0,0,0,2,8,0
0,0,0,4,1,9,0,0,5
0,0,0,0,8,0,0,7,9
