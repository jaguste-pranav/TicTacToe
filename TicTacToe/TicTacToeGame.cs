using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace TicTacToe
{
    class TicTacToeGame
    {
        private char[] board = new char[10];
        char userSelection = ' ', compSelection = ' ';
        int HEADS = 1;
        int TAILS = 2;

        public void CreateGame()
        {
            Console.WriteLine("UC1");

            for (int position = 1; position < board.Length; position++)
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
                    Console.WriteLine("\nYou are " + userSelection + "\nComputer is " + compSelection);
                    break;
                }
                else if (userSelection == '0')
                {
                    compSelection = 'X';
                    Console.WriteLine("\nYou are " + userSelection + "\nComputer is " + compSelection);
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
            for (int position = 1; position < board.Length; position++)
            {
                if (position == 1 || position == 4 || position == 7)
                {
                    Console.WriteLine("\n");
                }
                Console.Write(board[position] + "|");
            }
        }

        public bool checkPositionAval(int position)
        {
            if (board[position].Equals("X") || board[position].Equals("0"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void markCharacter()
        {
            Console.WriteLine("\n\nEnter the position to mark " + userSelection + ": ");
            int markTo = Convert.ToInt32(Console.ReadLine());

            if (0 > markTo || markTo > 10)
            {
                Console.WriteLine("Please select correctly");
            }
            else
            {
                if (!board[markTo].Equals(' '))
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

        public void Toss()
        {
            Random rand = new Random();
            int outcome = rand.Next(0, 2);

            if (outcome == HEADS)
            {
                Console.WriteLine("Computer Plays First");
            }
            else
            {
                Console.WriteLine("User Plays First");
            }
        }

        public bool winner()
        {
            char syb;
            bool winnerDecided = false;
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    syb = 'X';
                }
                else
                {
                    syb = '0';
                }

                if ((board[1] == syb && board[2] == syb && board[3] == syb) ||
                    (board[4] == syb && board[5] == syb && board[6] == syb) ||
                    (board[7] == syb && board[8] == syb && board[9] == syb) ||
                    (board[1] == syb && board[4] == syb && board[7] == syb) ||
                    (board[2] == syb && board[5] == syb && board[7] == syb) ||
                    (board[3] == syb && board[6] == syb && board[9] == syb) ||
                    (board[1] == syb && board[5] == syb && board[9] == syb) ||
                    (board[3] == syb && board[5] == syb && board[7] == syb))
                {
                    winnerDecided = true;
                    break;
                }
                
            }
            
            return winnerDecided;
        }

        public bool checkDraw()
        {
            bool isDraw = false;
            if (winner())
            {
                return false;
            }
            else
            {
                for (int position = 1; position < board.Length; position++)
                {
                    if (checkPositionAval(position))
                    {
                        isDraw = false;
                        break;
                    }
                    else
                    {
                        isDraw = true;
                    }
                }

                //Console.WriteLine("Result: " + isDraw);
                return isDraw;
            }
        }
    }
}