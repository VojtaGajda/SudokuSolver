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
