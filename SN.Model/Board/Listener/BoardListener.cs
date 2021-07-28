using SN.Model.Board.CellDecoration;
using SN.Model.Board.Cells;

namespace SN.Model.Board.Listener
{
    public class BoardListener : BaseStyler<SelectedMainStyle, SelectedSecondaryRowStyle, SelectedSecondaryColStyle>, 
        IBoardListener
    {
        private RowColPair _selected = new RowColPair(0,0);
        public void NumberLeftMouseClick(object sender, RowColPair args)
        {
            if (args.Column >= Board.CrossX)
                _selected.Column = args.Column == _selected.Column ? 0 : args.Column;
            else
                _selected.Row = args.Row == _selected.Row ? 0 : args.Row;
            RemoveStyles();
            SelectColumn();
            SelectRow();
        }

        public void NumberRightMouseClick(object sender, RowColPair args)
        {
            var cell = Board.FullBoard[args.Row, args.Column];
            if (cell.CellStyles.Exists(s => s is CrossedNumberStyle))
                cell.CellStyles.RemoveAll(s => s is CrossedNumberStyle);
            else
                cell.CellStyles.Add(new CrossedNumberStyle());
        }

        private void SelectColumn()
        {
            if (_selected.Column < 1)
                return;
            StyleColumn(_selected.Column);
        }
        
        private void SelectRow()
        {
            if (_selected.Row < 1)
                return;
            StyleRow(_selected.Row);
        }

        public void EmptyLeftMouseClick(object sender, RowColPair args)
        {
            var previousCell = Board.FullBoard[args.Row, args.Column];
            var newCell = new CellFilled()
            {
                CellStyles = previousCell.CellStyles
            };
            newCell.Register(this);
            
            Board.FullBoard[args.Row, args.Column] = newCell;
        }

        public void EmptyRightMouseClick(object sender, RowColPair args)
        {
            var previousCell = Board.FullBoard[args.Row, args.Column];
            var newCell = new CellCrossed()
            {
                CellStyles = previousCell.CellStyles
            };
            newCell.Register(this);
            
            Board.FullBoard[args.Row, args.Column] = newCell;
        }

        public void CrossedLeftMouseClick(object sender, RowColPair args)
        {
            var previousCell = Board.FullBoard[args.Row, args.Column];
            var newCell = new CellEmpty
            {
                CellStyles = previousCell.CellStyles
            };
            newCell.Register(this);
            
            Board.FullBoard[args.Row, args.Column] = newCell;
        }

        public void FilledLeftMouseClick(object sender, RowColPair args)
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