using SN.Model.Board.CellDecoration;
using SN.Model.Board.Cells;

namespace SN.Model.Board.Listener
{
    public class BoardListener : BaseStyler<SelectedMainStyle, SelectedSecondaryRowStyle, SelectedSecondaryColStyle>, 
        IBoardListener
    {
        private int _selectedColumn; 
        private int _selectedRow; 
        public void NumberLeftMouseClick(object sender, BoardEventArgs args)
        {
            if (args.Column >= Board.CrossX)
                _selectedColumn = args.Column == _selectedColumn ? 0 : args.Column;
            else
                _selectedRow = args.Row == _selectedRow ? 0 : args.Row;
            RemoveStyles();
            SelectColumn();
            SelectRow();
        }

        private void SelectColumn()
        {
            if (_selectedColumn < 1)
                return;
            StyleColumn(_selectedColumn);
        }
        
        private void SelectRow()
        {
            if (_selectedRow < 1)
                return;
            StyleRow(_selectedRow);
        }

        public void EmptyLeftMouseClick(object sender, BoardEventArgs args)
        {
            var previousCell = Board.FullBoard[args.Row, args.Column];
            var newCell = new CellFilled()
            {
                CellStyles = previousCell.CellStyles
            };
            newCell.Register(this);
            
            Board.FullBoard[args.Row, args.Column] = newCell;
        }

        public void EmptyRightMouseClick(object sender, BoardEventArgs args)
        {
            var previousCell = Board.FullBoard[args.Row, args.Column];
            var newCell = new CellCrossed()
            {
                CellStyles = previousCell.CellStyles
            };
            newCell.Register(this);
            
            Board.FullBoard[args.Row, args.Column] = newCell;
        }

        public void CrossedLeftMouseClick(object sender, BoardEventArgs args)
        {
            var previousCell = Board.FullBoard[args.Row, args.Column];
            var newCell = new CellEmpty
            {
                CellStyles = previousCell.CellStyles
            };
            newCell.Register(this);
            
            Board.FullBoard[args.Row, args.Column] = newCell;
        }

        public void FilledLeftMouseClick(object sender, BoardEventArgs args)
        {
            var previousCell = Board.FullBoard[args.Row, args.Column];
            var newCell = new CellEmpty
            {
                CellStyles = previousCell.CellStyles
            };
            newCell.Register(this);
            
            Board.FullBoard[args.Row, args.Column] = newCell;
        }
    }
}