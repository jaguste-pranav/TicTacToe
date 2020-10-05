﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TicTacToeGame
    {
        private char[] board = new char[10];
        char userSelection = ' ', compSelection = ' ';

        public void CreateGame()
        {
            Console.WriteLine("UC1");

            for (int position = 1; position<board.Length; position++)
            {
                board[position] = ' ';
            }
        }

        public void selectCharacter()
        {
            while (true)
            {
                Console.WriteLine("Select X or 0");
                userSelection = Convert.ToChar(Console.ReadLine());

                if (userSelection == 'X')
                {
                    compSelection = '0';
                    break;
                }
                else if (userSelection == '0')
                {
                    compSelection = 'X';
                    break;
                }
                else
                {
                    Console.WriteLine("Please select correctly");
                    userSelection = '-';
                    compSelection = '-';
                }
            }
        }

        public void showBoard()
        {
            Console.WriteLine("The Board looks like ");
            for (int position = 1; position<board.Length; position++)
            {
                if(position == 1 || position == 4 || position == 7)
                {
                    Console.WriteLine("\n");
                }
                Console.Write(board[position]+ "|");
            }
        }

        public void markCharacter()
        {
            Console.WriteLine("\n\nEnter the position to mark " + userSelection + ": ");
            int markTo = Convert.ToInt32(Console.ReadLine());

            if(0>markTo || markTo>10)
            {
                Console.WriteLine("Please select correctly");
            }
            else
            {
                if(!board[markTo].Equals(' '))
                {
                    Console.WriteLine("Position is already marked");
                }
                else
                {
                    board[markTo] = userSelection;
                }
            }

            showBoard();
        }
    }
}