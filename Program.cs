// inputs --- movements- up, down,right, left
// Layout -- chessboard-- 64 squares -- 8x8 ---> array[][]>> <char><int>
// like chess board --> so each square is denoted as A1,A2 where A is row and 1 & 2 is column
// decide on number of lives.
//assuming starting point is A1
// after one move - update position

namespace Minesweeper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minesweeper console game!!");
            var boardLayout = new BoardLayout();
            while(!boardLayout.isGameOver())
            {
                Console.WriteLine($"Current position of the player is at {boardLayout.PlayerPosition}; You have {boardLayout.Lives} lives.");
                Console.WriteLine("Enter any one direction to move - up,down,left or right");
                string? input = Console.ReadLine();
                if (input is null)
                {
                    Console.WriteLine("Enter a direction from the above choice");
                }
                else
                {
                    string result = boardLayout.Movement(input);
                    Console.WriteLine(result);
                    if (boardLayout.isGameOver()) 
                    {
                        Console.WriteLine(boardLayout.Lives > 0 ? "You won!" : "Game over!");
                    }
                }
            }
        }
    }
}
