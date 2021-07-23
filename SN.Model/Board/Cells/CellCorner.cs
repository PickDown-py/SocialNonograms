namespace SN.Model.Board.Cells
{
    public class CellCorner : CellStateBase
    {
        protected override string Style => "corner";
        public override char ToChar()
        {
            return 'e';
        }
    }
}