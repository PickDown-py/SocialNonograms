using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SN.Entity;
using SN.Model;

namespace SN.ClientServices.Mappers
{
    public static class BoardMapper
    {
        public static BoardModel ToModel(this GridStateEntity entity)
        {
            var rows = entity.State.Split(";");
            var colsAmount = rows.First().Split(",").Length;

            var board = new BoardModel(rows.Length, colsAmount) {Id = entity.Id};

            for (var i = 0; i < rows.Length; i++)
            {
                var cols = rows[i].Split(",");

                for (var j = 0; j < cols.Length; j++)
                {
                    board.DrawingCells[i, j] = cols[j].ToCell();
                }
            }

            return board;
        }

        public static BoardModel ToModel(this GridStateEntity entity, out int[][] rowNumbers, out int[][] colNumbers)
        {
            var rows = entity.State.Split(";");
            var colsAmount = rows.First().Split(",").Length;

            var board = new BoardModel(rows.Length, colsAmount) {Id = entity.Id};
            rowNumbers = new int [rows.Length][];
            colNumbers = new int[colsAmount][];

            for (var i = 0; i < rows.Length; i++)
            {
                var cols = rows[i].Split(",");
                var colNums = new List<int>();
                bool counting = false;
                int ind = -1;

                for (var j = 0; j < cols.Length; j++)
                {
                    board.DrawingCells[i, j] = cols[j].ToCell();

                    if (board.DrawingCells[i, j].GetState() == CellStateEnum.Filled)
                    {
                        if (counting)
                        {
                            colNums[ind] += 1;
                        }
                        else
                        {
                            colNums.Add(1);
                            counting = true;
                            ind++;
                        }
                    }
                    else
                    {
                        counting = false;
                    }
                }
                colNums.Reverse();
                rowNumbers[i] = colNums.ToArray();
            }

            for (var i = 0; i < colsAmount; i++)
            {
                var rowNums = new List<int>();
                bool counting = false;
                int ind = -1;

                for (var j = 0; j < rows.Length; j++)
                {
                    if (board.DrawingCells[j, i].GetState() == CellStateEnum.Filled)
                    {
                        if (counting)
                            rowNums[ind] += 1;
                        else
                        {
                            rowNums.Add(1);
                            counting = true;
                            ind++;
                        }
                    }
                    else
                    {
                        counting = false;
                    }
                }
                rowNums.Reverse();
                colNumbers[i] = rowNums.ToArray();
            }

            return board;
        }

        public static GridStateEntity ToEntity(this BoardModel model)
        {
            var strBuilder = new StringBuilder();
            foreach (var cell in model.DrawingCells)
            {
                strBuilder.Append(cell.ToChar());
            }

            return new()
            {
                Id = model.Id,
                State = strBuilder.ToString()
            };
        }
    }
}