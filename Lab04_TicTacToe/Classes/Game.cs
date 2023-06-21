using System;

namespace Lab04_TicTacToe.Classes
{
    class Game
    {
        //declares a private instance variable players of type Player[], which will store the two players of the game.
        private Player[] players;
        //: This line declares a private instance variable currentPlayer of type Player, which represents the player who is currently taking their turn.
        private Player currentPlayer;
        //This line declares a private instance variable board of type Board, which represents the game board.
        private Board board;

        //This line defines a constructor for the Game class.  
        public Game()
        {// initializes the players array with a length of 2 and creates a new instance of the Board class
            players = new Player[2];
            board = new Board();
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome To The Game!");
            for (int i = 0; i < players.Length; i++)
            {
                players[i] = CreatePlayer(i + 1);
            }

            Console.Write($" Players are {players[0].Name}  plays with  {players[0].Marker} and {players[1].Name}  plays with  {players[1].Marker}\n\n");
            currentPlayer = players[0];
            Console.WriteLine("The Game Started!");
            bool gameIsOver = false;
            int turnCount = 0;

            while (!gameIsOver && turnCount < 9)
            {
                board.DisplayBoard();
                currentPlayer.TakeTurn(board);

                if (CheckForWinner())
                {
                    gameIsOver = true;
                    board.DisplayBoard();
                    Console.WriteLine($"{currentPlayer.Name} wins! Congratulations!");
                }
                else if (turnCount == 8)
                {
                    gameIsOver = true;
                    board.DisplayBoard();
                    Console.WriteLine("It's a draw!");
                }
                else
                {//This line is responsible for switching the current player's turn between the two players
                    currentPlayer = currentPlayer == players[0] ? players[1] : players[0];
                    turnCount++;
                }
            }
        }

        private Player CreatePlayer(int playerNumber)
        {
            Console.Write($"Enter Player {playerNumber} name: ");
            string name = Console.ReadLine();

            string marker;
            if (playerNumber == 1)
            {
                Console.Write($"Enter Player {playerNumber} symbol (X or O): ");
                marker = Console.ReadLine().ToUpper();

                while (marker != "X" && marker != "O")
                {
                    Console.Write($"Invalid symbol. Please enter either 'X' or 'O': ");
                    marker = Console.ReadLine().ToUpper();
                }
            }
            else
            {
                marker = players[0].Marker == "X" ? "O" : "X";
                Console.WriteLine($"Player {playerNumber} symbol is automatically set to '{marker}'.");
            }

            return new Player { Name = name, Marker = marker };
        }


        private bool CheckForWinner()
        {
            string[,] gb = board.GameBoard;
            for (int i = 0; i < 3; i++)
            {
                // Check rows
                if (gb[i, 0] == gb[i, 1] && gb[i, 0] == gb[i, 2])
                    return true;
                // Check columns
                if (gb[0, i] == gb[1, i] && gb[0, i] == gb[2, i])
                    return true;
            }
            // Check diagonals
            if ((gb[0, 0] == gb[1, 1] && gb[0, 0] == gb[2, 2]) || (gb[0, 2] == gb[1, 1] && gb[0, 2] == gb[2, 0]))
                return true;

            return false;
        }
    }
}
