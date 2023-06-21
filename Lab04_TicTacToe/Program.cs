using Lab04_TicTacToe.Classes;
using System;

namespace Lab04_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {//make an object of the class game to start the game 
            Game game = new Game();
            game.StartGame();

            Console.WriteLine("Thanks for playing Tic-Tac-Toe! Press any key to exit.");
            Console.ReadKey();
        }
    }
}
