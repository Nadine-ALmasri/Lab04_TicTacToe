using System;
using System.Numerics;
using Lab04_TicTacToe;
using Lab04_TicTacToe.Classes;

namespace TesttTicTacToe
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
            [Fact]
      
        public void CheckForWinner()
        {
            // Arrange
            Game game = new Game();
            game.board = new Board();

            // Set up the game board with a winning condition
            game.board.GameBoard = new string[,]
            {
        { "X", "X", "X" },
        { "O", "O", "" },
        { "", "", "" }
            };

            // Act
            bool hasWinner = game.CheckForWinner();

            // Assert
            Assert.True(hasWinner);
        }


        [Fact]
            public void SwitchPlayers_BetweenTurns()
            {
                // Arrange
                Game game = new Game();
                Player[] players = new Player[2];
                players[0] = new Player { Name = "Player 1", Marker = "X" };
                players[1] = new Player { Name = "Player 2", Marker = "O" };
                game.players = players;
                game.currentPlayer = players[0];

                // Act
                game.SwitchPlayers();

                // Assert
                Assert.Equal(players[1], game.currentPlayer);
            }
        [Theory]
        [InlineData(2, 0, 1)]
        [InlineData(1, 0, 0)]
        public void PositionToIndex(int position, int expectedRow, int expectedColumn)
        {
            // Act
            Position actualPosition = Player.PositionForNumber(position);

            // Assert
            Assert.Equal(expectedRow, actualPosition.Row);
            Assert.Equal(expectedColumn, actualPosition.Column);
        }


        [Fact]
            public void YourOwnUniqueTest()
            {
                // Add your own unique test here to test a specific functionality or scenario of your game.
                // For example, you could test the game's behavior when a draw condition is reached.
            }
        }

    }

