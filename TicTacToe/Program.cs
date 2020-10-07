using System;
using System.Security.Cryptography.X509Certificates;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Welcome to TiTacToe Game!");
            TicTacToeGame game = new TicTacToeGame();
            game.CreateGame();
            game.selectCharacter();

            if(!game.checkDraw() && !game.winner())
            {
                Console.WriteLine("Change Turn");
            }
            else
            {
                Console.WriteLine("Game is decided");
            }

            game.showBoard();
            //game.markCharacter();
        }
    }
}