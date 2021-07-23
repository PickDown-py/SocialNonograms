using System;
using SN.Model;
using SN.Model.Board.Cells;

namespace SN.ClientServices.Mappers
{
    public static class CellMapper
    {
        public static ICellState ToCell(this string c)
        {
            return c switch
            {
                " "  => new CellEmpty(),
                "x" => new CellCrossed(),
                "o" => new CellFilled(),
                _ => throw new ArgumentException("Invalid char." + "{"+c+"}")
            };
        }
    }
}