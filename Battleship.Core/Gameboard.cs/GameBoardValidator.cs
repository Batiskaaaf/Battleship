namespace Battleship.Core;

public class GameBoardValidator
{
  public static bool ValidateBattlefield(int[,] field)
  {
    var ships = new List<int>();    
    for (var x = 0; x < 10; x++)
      for (var y = 0; y < 10; y++)
        if (field[x, y] == 1)
        {
          var length = 1;
          while (x + length < 10 && field[x + length, y] == 1)
            field[x + length++, y] = 0;
          while (y + length < 10 && field[x, y + length] == 1)
            field[x, y + length++] = 0;          
          ships.Add(length);          
        }    
    ships.Sort();
    return string.Join("", ships) == "1111222334";
  }
}