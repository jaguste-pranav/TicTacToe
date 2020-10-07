﻿using System;
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

            while (!game.checkDraw() && !game.winner())
            {
                game.MakeMove(game.playerToPlay());
                game.changePlayer();
            }

            game.showBoard();
        }
    }
}