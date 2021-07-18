namespace SN.Model
{
   public enum CellStateEnum
   {
      Empty,
      Filled,
      Crossed,
      Number,
      Corner
   }
   public  interface ICellState
   {
      public CellStateEnum GetState();
      public string Content { get; set;}
      public char ToChar();
   }

   public class CellEmpty : ICellState
   {
      public string Content { get; set; }

      public CellStateEnum GetState()
      {
         return CellStateEnum.Empty;
      }
      
      public char ToChar()
      {
         return ' ';
      }

      public override string ToString()
      {
         return "empty";
      }
   }
   
   public class CellFilled : ICellState
   {
      public string Content { get; set; }

      public CellStateEnum GetState()
      {
         return CellStateEnum.Filled;
      }

      public char ToChar()
      {
         return 'o';
      }
      
      public override string ToString()
      {
         return "filled";
      }
   }
   
   public class CellCrossed : ICellState
   {
      public string Content { get; set; }

      public CellStateEnum GetState()
      {
         return CellStateEnum.Crossed;
      }

      public char ToChar()
      {
         return 'x';
      }
      
      public override string ToString()
      {
         return "crossed";
      }
   }

   public class CellNumber : ICellState
   {
      public string Content { get; set; }

      public CellStateEnum GetState()
      {
         return CellStateEnum.Number;
      }

      public char ToChar()
      {
         return 'e';
      }
      
      public override string ToString()
      {
         return "number";
      }
   }
   
   public class CellCorner : ICellState
   {
      public string Content { get; set; }

      public CellStateEnum GetState()
      {
         return CellStateEnum.Corner;
      }

      public char ToChar()
      {
         return 'e';
      }
      
      public override string ToString()
      {
         return "corner";
      }
   }
}