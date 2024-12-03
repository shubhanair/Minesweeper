using Xunit;
using Minesweeper;

namespace MinesweeperTests
{
    public class BoardLayoutTests
    {
        [Fact]
        public void BoardLayout_InitialState_PlayerStartsAtA1()
        {
            var boardLayout = new BoardLayout();

            var initialPosition = boardLayout.PlayerPosition;

            Assert.Equal(('A', 1), initialPosition);
        }

        [Fact]
        public void Movement_ValidMove_PlayerMovesCorrectly()
        {
            var board = new BoardLayout();

            var result = board.Movement("down");

            Assert.Equal(('A', 2), board.PlayerPosition);
            Assert.Contains("Moved to safe position", result);
        }

        [Fact]
        public void Movement_InvalidDirection_ReturnsErrorMessage()
        {
            var board = new BoardLayout();

            var result = board.Movement("diagonal");

            Assert.Contains("Invalid direction. Move up, down, right, or left.", result);
        }

        [Fact]
        public void Movement_OutOfBounds_ReturnsErrorMessage()
        {
            // Arrange
            var board = new BoardLayout();
            board.Movement("up"); // Try to move out of bounds

            // Act
            var result = board.Movement("up");

            // Assert
            Assert.Equal("Invalid move. Stay in the board.", result);
        }

        [Fact]
        public void IsGameOver_TrueWhenNoLivesLeft()
        {
            var board = new BoardLayout(0); 
            
            Assert.True(board.isGameOver());
        }

    }
}
