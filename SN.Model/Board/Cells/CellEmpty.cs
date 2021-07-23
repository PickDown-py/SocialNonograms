using SN.Model.Board.Listener;

namespace SN.Model.Board.Cells
{
    public class CellEmpty : CellStateBase
    {
        protected override string Style => "empty";
        public override void Register(IBoardListener listener)
        {
            LeftMouseClick += listener.EmptyLeftMouseClick;
            RightMouseClick += listener.EmptyRightMouseClick;
        }
        public override char ToChar()
        {
            return ' ';
        }
    }
}