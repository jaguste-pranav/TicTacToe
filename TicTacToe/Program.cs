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
            game.Toss();

            while (true)
            {
                while (!game.checkDraw() && !game.winner())
                {
                    game.MakeMove(game.playerToPlay());
                    game.changePlayer();
                }

                game.showBoard();

                Console.WriteLine("\n\nGame Over.\nPress 1 to play another game or any other key to exit");
                int anotherGame = Convert.ToInt32(Console.ReadLine());

                if(anotherGame != 1)
                {
                    break;
                }
                game.CreateGame();
                game.selectCharacter();
                game.Toss();
            }
        }
    }
}