using SN.Model.Board.Listener;

namespace SN.Model.Board.Cells
{
    public class CellFilled : CellStateBase
    {
        protected override string Style => "filled";
        public override void Register(IBoardListener listener)
        {
            LeftMouseClick += listener.FilledLeftMouseDown;
        }
        public override char ToChar()
        {
            return 'o';
        }
    }
}