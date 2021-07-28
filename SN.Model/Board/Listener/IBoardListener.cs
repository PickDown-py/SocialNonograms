using SN.Model.Board.Cells;

namespace SN.Model.Board.Listener
{
    public interface IBoardListener
    {
        public BoardModel Board { get; set; }
        public void NumberLeftMouseClick(object sender, RowColPair args);
        public void NumberRightMouseClick(object sender, RowColPair args);
        public void EmptyLeftMouseClick(object sender, RowColPair args);
        public void EmptyRightMouseClick(object sender, RowColPair args);
        public void CrossedLeftMouseClick(object sender, RowColPair args);
        public void FilledLeftMouseClick(object sender, RowColPair args);
    }
}