using System;
using System.Collections.Generic;

namespace SN.Model
{
    public class BoardModel : Abstract.Model
    {
        public ICellState[,] DrawingCells { get; }
        public ICellState[,] ColumnNumberCells { get;  set; }
        public ICellState[,] RowNumberCells { get;  set; }
        public ICellState[,] FullBoard { get; set; }
        public BoardModel(int rows, int columns)
        {
            DrawingCells = new ICellState[rows,columns];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    DrawingCells[row, col] = new CellEmpty();
                }
            }
        }

        public void SetFullBoard(ICellState[,] rowCells, ICellState[,] colCells)
        {
            ColumnNumberCells = colCells;
            RowNumberCells = rowCells;

            int crossY = ColumnNumberCells.GetLength(0);
            int crossX = RowNumberCells.GetLength(1);
            
            Console.WriteLine($"crossX:{crossX}, crossY:{crossY}, " +
                              $"boardRow:{DrawingCells.GetLength(0)}, " +
                              $"boardCol:{DrawingCells.GetLength(1)}");

            int rows = crossY + DrawingCells.GetLength(0);
            int columns = crossX + DrawingCells.GetLength(1);

            var fullBoard = new ICellState[rows, columns];

            for (int i = 0; i < crossY; i++)
            {
                for (int j = 0; j < crossX; j++)
                {
                    fullBoard[i, j] = new CellCorner();
                }
            }
                
            for (int i = 0; i < ColumnNumberCells.GetLength(0); i++)
            {
                for (int j = crossX; j < crossX + ColumnNumberCells.GetLength(1); j++)
                {
                    fullBoard[i, j] = ColumnNumberCells[i, j - crossX];
                }
            }
                
            for (int i = crossY; i < crossY + RowNumberCells.GetLength(0); i++)
            {
                for (int j = 0; j < RowNumberCells.GetLength(1); j++)
                {
                    fullBoard[i, j] = RowNumberCells[i-crossY, j];
                }
            }
                
            for (int i = crossY; i < crossY + DrawingCells.GetLength(0); i++)
            {
                for (int j = crossX; j < crossX + DrawingCells.GetLength(1); j++)
                {
                    fullBoard[i, j] = DrawingCells[i-crossY, j-crossX];
                }
            }

            FullBoard = fullBoard;
        }
    }
    
    
}