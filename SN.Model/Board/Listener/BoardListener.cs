using System;
using System.Collections.Generic;
using SN.Model.Board.CellDecoration;
using SN.Model.Board.Cells;

namespace SN.Model.Board.Listener
{
    public class BoardListener : BaseStyler<SelectedMainStyle, SelectedSecondaryRowStyle, SelectedSecondaryColStyle>, 
        IBoardListener
    {
        private RowColPair _selected = new RowColPair(-1,-1);

        private RowColPair _down = new RowColPair(0, 0);
        private bool _isFilled;
        private List<Tuple<RowColPair, ICellState>> _ephemeralCells = new List<Tuple<RowColPair, ICellState>>();

        private event BoardEvent MouseMoveEvent;

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

        public void EmptyLeftMouseDown(object sender, RowColPair args)
        {
            var previousCell = Board.FullBoard[args.Row, args.Column];
            var newCell = new CellFilled()
            {
                CellStyles = previousCell.CellStyles
            };
            newCell.Register(this);
            
            Board.FullBoard[args.Row, args.Column] = newCell;
            
            _down.Column = args.Column;
            _down.Row = args.Row;
            _isFilled = true;

            MouseMoveEvent += MouseMove;
        }

        public void OnMouseMove(RowColPair args)
        {
            MouseMoveEvent?.Invoke(null, args);
        }

        private void MouseMove(object sender, RowColPair args)
        {
            if (Board.FullBoard[args.Row, args.Column] is CellCorner or CellNumber)
                return;
            RemoveEphemeralCells();
            if (args.Column == _down.Column && args.Row == _down.Row)
                return;
            bool isCol;
            RowColPair lineEnd = GetLine(args, out isCol);
            ICellState cell;
            if (_isFilled)
                cell = new CellFilled();
            else
                cell = new CellEmpty();
            if (isCol)
            {
                for (int i = Math.Min(_down.Row, lineEnd.Row); i <= Math.Max(_down.Row, lineEnd.Row); i++)
                {
                    _ephemeralCells.Add(
                        new Tuple<RowColPair, ICellState>(
                            new RowColPair(i, _down.Column), Board.FullBoard[i, _down.Column]));
                    Board.FullBoard[i, _down.Column] = cell;
                }
            }
            else
            {
                for (int i = Math.Min(_down.Column, lineEnd.Column); i <= Math.Max(_down.Column, lineEnd.Column); i++)
                {
                    _ephemeralCells.Add(
                        new Tuple<RowColPair, ICellState>(
                            new RowColPair(_down.Row, i), Board.FullBoard[_down.Column, i]));
                    Board.FullBoard[_down.Row, i] = cell;
                }
            }
            
        }
        
        public void OnMouseUp(RowColPair args)
        {
            RemoveEphemeralCells();
            if ((args.Column == _down.Column && args.Row == _down.Row) || (Board.FullBoard[args.Row, args.Column] is CellCorner or CellNumber))
            {
                MouseMoveEvent -= MouseMove;
                _selected = new RowColPair(-1, -1);
                return;
            }

            bool isCol;
            RowColPair lineEnd = GetLine(args, out isCol);
            ICellState cell;
           
            if (isCol)
            {
                for (int i = Math.Min(_down.Row, lineEnd.Row); i <= Math.Max(_down.Row, lineEnd.Row); i++)
                {
                    var previousCell = Board.FullBoard[i, _down.Column];
                    ICellState newCell;
                    if (_isFilled)
                    {
                        newCell = new CellFilled()
                        {
                            CellStyles = previousCell.CellStyles
                        };
                    }
                    else
                    {
                        newCell = new CellEmpty()
                        {
                            CellStyles = previousCell.CellStyles
                        };
                    }

                    newCell.Register(this);
            
                    Board.FullBoard[i, _down.Column] = newCell;
                }
            }
            else
            {
                for (int i = Math.Min(_down.Column, lineEnd.Column); i <= Math.Max(_down.Column, lineEnd.Column); i++)
                {
                    var previousCell = Board.FullBoard[_down.Row, i];
                    ICellState newCell;
                    if (_isFilled)
                    {
                        newCell = new CellFilled()
                        {
                            CellStyles = previousCell.CellStyles
                        };
                    }
                    else
                    {
                        newCell = new CellEmpty()
                        {
                            CellStyles = previousCell.CellStyles
                        };
                    }

                    newCell.Register(this);
            
                    Board.FullBoard[_down.Row, i] = newCell;
                }
            }

            MouseMoveEvent -= MouseMove;
            _selected = new RowColPair(-1,-1);
        }

        private void RemoveEphemeralCells()
        {
            foreach (var pair in _ephemeralCells)
            {
                Board.FullBoard[pair.Item1.Row, pair.Item1.Column] = pair.Item2;
            }

            _ephemeralCells.Clear();
        }

        private RowColPair GetLine(RowColPair args, out bool isCol)
        {
            int row, col;
            if (Math.Abs(_down.Column - args.Column) < Math.Abs(_down.Row - args.Row))
            {
                row = args.Row;
                col = _down.Column;
                isCol = true;
            }
            else
            {
                row = _down.Row;
                col = args.Column;
                isCol = false;
            }

            return new(row, col);
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

        public void FilledLeftMouseDown(object sender, RowColPair args)
        {
            var previousCell = Board.FullBoard[args.Row, args.Column];
            var newCell = new CellEmpty
            {
                CellStyles = previousCell.CellStyles
            };
            newCell.Register(this);
            
            Board.FullBoard[args.Row, args.Column] = newCell;
            
            _down.Column = args.Column;
            _down.Row = args.Row;
            _isFilled = false;

            MouseMoveEvent += MouseMove;
        }
    }
}