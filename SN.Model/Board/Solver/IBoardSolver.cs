namespace SN.Model.Solver
{
    public interface IBoardSolver
    {
        BoardModel Answer { get; set; }
        BoardModel Board { get; set; }
        public void DetectErrors();
        bool IsComplete();
    }
}