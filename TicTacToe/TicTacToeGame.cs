using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TicTacToeGame
    {
        private char[] board = new char[10];

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
            Console.WriteLine("Select X or 0");
            char userSelection = Convert.ToChar(Console.ReadLine());
            char compSelection = ' ';

            if (userSelection == 'X')
            {
                compSelection = '0';
            }
            else if (userSelection == '0')
            {
                compSelection = 'X';
            }
            else
            {
                Console.WriteLine("Please select correctly");
                userSelection = '-';
                compSelection = '-';
            }
        }
    }
}
