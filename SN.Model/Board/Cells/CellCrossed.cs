using System;
using System.Text;
using SN.Model.Board.Listener;

namespace SN.Model.Board.Cells
{
    public class CellCrossed : CellStateBase
    {
        public override string Content { get; set; } = "✕";
        protected override string Style => "crossed";
        public override void Register(IBoardListener listener)
        {
            LeftMouseClick += listener.CrossedLeftMouseClick;
        }
        public override char ToChar()
        {
            return 'x';
        }
    }
}