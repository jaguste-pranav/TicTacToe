using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TicTacToeGame
    {
        private char[] board = new char[] { 'i', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v', 'v'};

        public void UC1()
        {
            Console.WriteLine("UC1");

            for (int position = 0; position<board.Length; position++)
            {
                Console.WriteLine(position + " position is " + board[position]);
            }
        }
    }
}
