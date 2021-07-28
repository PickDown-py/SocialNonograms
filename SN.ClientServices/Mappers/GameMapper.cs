using System.Linq;
using SN.Entity;
using SN.Model;
using SN.Model.Board.Cells;

namespace SN.ClientServices.Mappers
{
    public static class GameMapper 
    {
        public static GameModel ToModel(this GameEntity entity)
        {
            var game =  new GameModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Rows = entity.Rows,
                Columns = entity.Columns,
                RatingScore = entity.RatingScore,
                Author = entity.Author.ToModel(),
                BoardModel = new BoardModel(entity.Rows, entity.Columns),
            };

            int[][] rowNumbers;
            int[][] colNumbers;
            game.Answer = entity.Answer.ToModel(out rowNumbers, out colNumbers);

            var maxCol = colNumbers.Max(c => c.Length);
            var maxRow = rowNumbers.Select(c => c.Length).Max();

            var colCells = new ICellState[maxCol, colNumbers.GetLength(0)];
            var rowCells = new ICellState[rowNumbers.GetLength(0), maxRow];

            for (int i = 0; i  < colNumbers.GetLength(0); i++)
            {
                for (int j = 0; j < maxCol; j++)
                {
                    colCells[maxCol-1-j, i] = new CellNumber()
                    {
                        Content = colNumbers[i].Length > j ? colNumbers[i][j].ToString() : " "
                    };
                }
            }
            
            for (int i = 0; i < rowNumbers.GetLength(0); i++)
            {
                for (int j = 0; j < maxRow; j++)
                {
                    rowCells[i, maxRow-1-j] = new CellNumber()
                    {
                        Content = rowNumbers[i].Length > j ? rowNumbers[i][j].ToString() : " "
                    };
                }
            }
            
            //TODO Don't set FullBoard for Answer
            game.Answer.SetFullBoard(rowCells, colCells);
            game.BoardModel.SetFullBoard(rowCells, colCells);

            return game;
        }

        public static GameEntity ToEntity(this GameModel model)
        {
            return new()
            {
                Id = model.Id,
                Name = model.Name,
                Rows = model.Rows,
                Columns = model.Columns,
                AuthorId = model.Author.Id,
                Answer = model.Answer.ToEntity()
            };
        }
    }
}