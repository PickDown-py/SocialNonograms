using SN.Model.Board.Cells;
using SN.Model.Solver;

namespace SN.Model.Board.Solver
{
    public class BoardSolver : IBoardSolver
    {
        public BoardModel Answer { get; set; }
        public BoardModel Board { get; set; }

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