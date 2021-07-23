using System.Collections.Generic;
using SN.Model.Board.CellDecoration;

namespace SN.Model
{
    public class BaseStyler<TMain, TRow, TCol> 
        where TMain : ICellStyle, new()
        where TRow : ICellStyle, new()
        where TCol : ICellStyle, new()
    {
        public BoardModel Board { get; set; }

        private TMain _main = new TMain();
        private TRow _row = new TRow();
        private TCol _col = new TCol();
        
        protected void RemoveStyles()
        {
            foreach (var cell in Board.FullBoard)
            {
                cell.CellStyles.RemoveAll(s => s is TMain or TRow or TCol);
            }
        }

        protected void StyleColumn(int column)
        {
            for (int row = 0; row < Board.FullBoard.GetLength(0); row++)
            {
                Board.FullBoard[row, column].CellStyles.Add(_main);
                Board.FullBoard[row, column-1].CellStyles.Add(_col);
            }
        }

        protected void StyleRow(int row)
        {
            for (int col = 0; col < Board.FullBoard.GetLength(1); col++)
            {
                Board.FullBoard[row, col].CellStyles.Add(_main);
                Board.FullBoard[row-1, col].CellStyles.Add(_row);
            }
        }
    }
}