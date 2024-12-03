using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    // inputs --- movements- up, down,right, left
    // Layout -- chessboard-- 64 squares -- 8x8 ---> array[][]>> <char><int>
    // like chess board --> so each square is denoted as A1,A2 where A is row and 1 & 2 is column
    // decide on number of lives.
    //assuming starting point is A1
    //assuming no of mines toplaced randomly to be 10
    // after one move - update position
    // two entities position -->1 : mine and 2:Player
    public class BoardLayout
    {
        public readonly HashSet<(char col, int row)> minePosition;
        public readonly Random randomPosition;
        public (char col, int row) PlayerPosition { get; private set; }
        public int Lives { get; private set; }
        public int Moves { get; private set; }
        public const int boardSize = 8;

        public BoardLayout(int lives = 3)
        {
            minePosition= new HashSet<(char col, int row)>();
            randomPosition = new Random();
            Lives = lives;
            Moves = 0;
            PlayerPosition = ('A', 1);
            SetUpRandomMines();
        }

        // When game starts set up mines
        private void SetUpRandomMines()
        {
            while(minePosition.Count < 10)
            {
                char column = (char)randomPosition.Next('A','A'+boardSize); 
                int row = randomPosition.Next(1,boardSize+1);
                minePosition.Add((column,row));
            }
        }

        public bool isGameOver()
        {
            if(Lives.Equals(0)) return true;
            else return false;
        }

        public string Movement(string direction)
        {
            (char column, int row) newPosition = PlayerPosition;
            switch (direction.ToLower())
            {
                case "up": newPosition = (newPosition.column,newPosition.row-1); break;
                case "down": newPosition = (newPosition.column,newPosition.row+1); break;
                case "left": newPosition = ((char)(newPosition.column - 1), newPosition.row);break;
                case "right": newPosition = ((char)(newPosition.column + 1), newPosition.row); break;
                default: return "Invalid direction. Move up, down, right, or left.";
            }

            if(newPosition.column >='A' && newPosition.column<'A'+boardSize 
                && newPosition.row >= 1 && newPosition.row <=boardSize)
            {
                PlayerPosition = newPosition;
                Moves++;

                if (minePosition.Contains(newPosition))
                {
                    Lives--;
                    return $"Mine exploded! You have {Lives} left";
                }
                else
                {
                    return $"Moved to safe position!{newPosition.column}{newPosition.row}";
                }
            }
            else
            {
                return $"Invalid move. Stay in the board.";
            }
        }
    }
}
