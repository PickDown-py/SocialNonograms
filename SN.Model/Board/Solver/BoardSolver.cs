using System;
using System.Collections.Generic;
using System.Linq;
using SN.Model.Board.CellDecoration;
using SN.Model.Board.Cells;
using SN.Model.Solver;

namespace SN.Model.Board.Solver
{
    public class BoardSolver : BaseStyler<ErrorMainStyle, ErrorSecondaryRowStyle, ErrorSecondaryColStyle>,IBoardSolver
    {
        public BoardModel Answer { get; set; }

        public void DetectErrors()
        {
            RemoveStyles();
            
            var colHeight = Board.ColumnNumberCells.GetLength(0);
            var colWidth = Board.ColumnNumberCells.GetLength(1);

            var answerColNums = new List<int>[colWidth];

            for (int col = 0; col < colWidth; col++)
            {
                for (int row = 0; row < colHeight; row++)
                {
                    if (!string.IsNullOrEmpty(Board.ColumnNumberCells[row, col].Content))
                    {
                        answerColNums[col] ??= new List<int>();
                        if (int.TryParse(Board.ColumnNumberCells[row, col].Content, out var parsed))
                            answerColNums[col].Add(parsed);
                    }
                }
            }
            
            for (int col = 0; col < Board.DrawingCells.GetLength(1); col++)
            {
                var boardColNums = new List<int>();
                bool counting = false;
                int ind = -1;

                for (int row = 0; row < Board.DrawingCells.GetLength(0); row++)
                {
                    if (Board.FullBoard[row+Board.CrossY, col+Board.CrossX] is CellFilled)
                    {
                        if (counting)
                        {
                            boardColNums[ind] += 1;
                        }
                        else
                        {
                            boardColNums.Add(1);
                            counting = true;
                            ind++;
                        }
                    }
                    else
                    {
                        counting = false;
                    }
                }

                if (boardColNums.Count > answerColNums[col].Count)
                {
                    StyleColumn(col + Board.CrossX);
                    continue;
                }

                bool error = false;
                for (int i = 0; i < Math.Min(boardColNums.Count, answerColNums[col].Count); i++)
                {
                    if (boardColNums[i] > answerColNums[col][i])
                    {
                        error = true;
                        break;
                    }
                }
                
                if (error)
                    StyleColumn(col + Board.CrossX);
            }
            
            var rowHeight = Board.RowNumberCells.GetLength(0);
            var rowWidth = Board.RowNumberCells.GetLength(1);

            var answerRowNums = new List<int>[colWidth];

            for (int row = 0; row < rowHeight; row++)
            {
                for (int col = 0; col < rowWidth; col++)
                {
                    if (!string.IsNullOrEmpty(Board.RowNumberCells[row, col].Content))
                    {
                        answerRowNums[row] ??= new List<int>();
                        if (int.TryParse(Board.RowNumberCells[row, col].Content, out var parsed))
                            answerRowNums[row].Add(parsed);
                    }
                }
            }
            
            for (int row = 0; row < Board.DrawingCells.GetLength(0); row++)
            {
                var boardRowNums = new List<int>();
                bool counting = false;
                int ind = -1;

                for (int col = 0; col < Board.DrawingCells.GetLength(1); col++)
                {
                    if (Board.FullBoard[row+Board.CrossY, col+Board.CrossX] is CellFilled)
                    {
                        if (counting)
                        {
                            boardRowNums[ind] += 1;
                        }
                        else
                        {
                            boardRowNums.Add(1);
                            counting = true;
                            ind++;
                        }
                    }
                    else
                    {
                        counting = false;
                    }
                }

                if (boardRowNums.Count > answerRowNums[row].Count)
                {
                    StyleRow(row + Board.CrossY);
                    continue;
                }

                bool error = false;
                for (int i = 0; i < Math.Min(boardRowNums.Count, answerRowNums[row].Count); i++)
                {
                    if (boardRowNums[i] > answerRowNums[row][i])
                    {
                        error = true;
                        break;
                    }
                }
                
                if (error)
                    StyleRow(row + Board.CrossY);
            }
            
        }
        
        public bool IsComplete()
        {
            var crossX = Board.CrossX;
            var crossY = Board.CrossY;
            for (int row = 0; row < Answer.DrawingCells.GetLength(0); row++)
            {
                for (int col = 0; col < Answer.DrawingCells.GetLength(1); col++)
                {
                    var answerCell = Answer.DrawingCells[row, col] is CellFilled;
                    var boardCell = Board.FullBoard[row + crossY, col + crossX] is CellFilled;
                    if (answerCell ^ boardCell)
                        return false;
                }
            }

            return true;
        }
    }
}