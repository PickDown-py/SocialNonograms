using System;
using System.Collections.Generic;
using SN.Model.Board.CellDecoration;
using SN.Model.Board.Cells;
using SN.Model.Board.Listener;

namespace SN.Model
{
    public class BoardModel : Abstract.Model
    {
        public ICellState[,] DrawingCells { get; private set; }
        public ICellState[,] ColumnNumberCells { get;  private set; }
        public ICellState[,] RowNumberCells { get;  private set; }
        public ICellState[,] FullBoard { get; private set; }
        public int CrossX { get; private set; }
        public int CrossY { get; private set; }
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

            CrossY = crossY;
            CrossX = crossX;
            
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
                    
                    if ((i+1-crossY)%5 == 0 && i + 1 - crossY <  DrawingCells.GetLength(0))
                        fullBoard[i, j].CellStyles.Add(new ThickRowStyle());
                    if ((j+1-crossX)%5 == 0 && j + 1 - crossX <  DrawingCells.GetLength(1))
                        fullBoard[i, j].CellStyles.Add(new ThickColumnStyle());
                }
            }

            FullBoard = fullBoard;
        }
        
        public void Register(IBoardListener listener)
        {
            listener.Board = this;
            foreach (var cell in FullBoard)
            {
                cell.Register(listener);
            }
        }
    }
    
   
    
    
}