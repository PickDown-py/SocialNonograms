using System.Collections.Generic;
using System.Linq;
using SN.Model.Board.CellDecoration;
using SN.Model.Board.Listener;

namespace SN.Model.Board.Cells
{
    public class CellStateBase : ICellState
    {
        public List<ICellStyle> CellStyles { get; set; } = new List<ICellStyle>();

        protected virtual string Style { get; }
        
        public event BoardEvent LeftMouseClick;
        
        public void OnLeftMouseClick(int row, int col)
        {
            LeftMouseClick?.Invoke(this, new BoardEventArgs(row, col));
        }
        
        public event BoardEvent RightMouseClick;
        
        public void OnRightMouseClick(int row, int col)
        {
            RightMouseClick?.Invoke(this, new BoardEventArgs(row, col));
        }
        public virtual string Content { get; set; }

        public void AttachStyle(ICellStyle style)
        {
            CellStyles ??= new List<ICellStyle>();
            CellStyles.Add(style);
        }

        public void DetachStyle(ICellStyle style)
        {
            if (CellStyles is null)
                return;
            CellStyles.Remove(style);
        }

        public void DetachAllStyles()
        {
            if (CellStyles is null)
                return;
            CellStyles.Clear();
        }

        public string GetCellStyles()
        {
            if (CellStyles is null)
                return Style;
            return CellStyles.Aggregate(Style, (str, style) => $"{str} {style.Style}");
        }

        public virtual void Register(IBoardListener listener)
        {
            
        }

        public virtual char ToChar()
        {
            return ' ';
        }
    }
}