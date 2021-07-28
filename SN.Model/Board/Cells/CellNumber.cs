using SN.Model.Board.Listener;

namespace SN.Model.Board.Cells
{
    public class CellNumber : CellStateBase
    {
        protected override string Style => "number";
        public override void Register(IBoardListener listener)
        {
            LeftMouseClick += listener.NumberLeftMouseClick;
            RightMouseClick += listener.NumberRightMouseClick;
        }

        public override char ToChar()
        {
            return 'e';
        }
    }
}