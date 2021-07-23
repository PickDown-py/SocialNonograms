using SN.Model.Board.Cells;

namespace SN.Model.Board.Listener
{
    public interface IBoardListener
    {
        public BoardModel Board { get; set; }
        public void NumberLeftMouseClick(object sender, BoardEventArgs args);
        public void EmptyLeftMouseClick(object sender, BoardEventArgs args);
        public void EmptyRightMouseClick(object sender, BoardEventArgs args);
        public void CrossedLeftMouseClick(object sender, BoardEventArgs args);
        public void FilledLeftMouseClick(object sender, BoardEventArgs args);
    }
}