using System.Collections.Generic;
using System.Diagnostics.Contracts;
using SN.Model.Board.CellDecoration;
using SN.Model.Board.Listener;

namespace SN.Model.Board.Cells
{
    public  interface ICellState
    {
        public List<ICellStyle> CellStyles { get; set; }
        public event BoardEvent LeftMouseClick;
        public void OnLeftMouseClick(int row, int col); 
        public event BoardEvent RightMouseClick;
        public void OnRightMouseClick(int row, int col);
        public string Content { get; set;}
        public string GetCellStyles();
        public void Register(IBoardListener listener);
        public char ToChar();
    }

    public delegate void BoardEvent(object sender, BoardEventArgs args);

    public class BoardEventArgs
    {
        public BoardEventArgs(int row, int col)
        {
            Row = row;
            Column = col;
        }
        public int Row { get; }
        public int Column { get; }
    }
}