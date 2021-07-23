using SN.Model.Board.Cells;

namespace SN.Model.Board.Listener
{
    public interface IBoardListener
    {
        public BoardModel Board { get; set; }
        public void OnMouseMove(RowColPair args);
        public  void OnMouseUp(RowColPair args);
        public void NumberLeftMouseClick(object sender, RowColPair args);
        public void EmptyLeftMouseDown(object sender, RowColPair args);
        public void EmptyRightMouseClick(object sender, RowColPair args);
        public void CrossedLeftMouseClick(object sender, RowColPair args);
        public void FilledLeftMouseDown(object sender, RowColPair args);
    }
}