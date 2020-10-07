using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;

namespace TicTacToe
{
    class TicTacToeGame
    {
        private char[] board = new char[10];
        char userSelection = ' ', compSelection = ' ';
        int HEADS = 1;
        int TAILS = 2;

        int USER = 1;
        int COMPUTER = 2;

        int whoPlays;
        string winningPlayer = "";

        public void CreateGame()
        {
            for (int position = 1; position < board.Length; position++)
            {
                board[position] = ' ';
            }
        }

        public int playerToPlay()
        {
            return whoPlays;
        }

        public void MakeMove(int player)
        {
            if(player == USER)
            {
                markCharacter(userSelection, getUserMove());
            }
            else
            {
                getBestMove();
            }    
           
        }

        public void changePlayer()
        {
            if(whoPlays == USER)
            {
                Console.WriteLine("Computer to Play");
                whoPlays = COMPUTER;
            }
            else
            {
                whoPlays = USER;
            }
        }
        public int getBestMove()
        {
            int bestposition = 100;
            for(int position = 1; position<board.Length; position++)
            {
                Console.WriteLine("Loop " + position+ " free: "+ checkPositionAval(position));
                if(checkPositionAval(position))
                {
                    markCharacter(compSelection, position);
                    
                    if(winner())
                    {
                        markCharacter(' ', position);
                    }
                    else
                    {
                        bestposition = position;
                        break;
                    }
                }
            }

            return bestposition;
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
            if (board[position].Equals(userSelection) || board[position].Equals(compSelection))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int getUserMove()
        {
            Console.WriteLine("\n\nEnter the position to mark " + userSelection + ": ");
            int position = Convert.ToInt32(Console.ReadLine());

            while (0 > position || position > 10)
            {
                Console.WriteLine("Please select correctly");
                position = Convert.ToInt32(Console.ReadLine());
            }
            return position;
        }

        public void markCharacter(char symbol, int position)
        {
            if (0 > position || position > 10)
            {
                Console.WriteLine("Please select correctly");
            }
            else
            {
                if (!board[position].Equals(' '))
                {
                    Console.WriteLine("Position is already marked");
                }
                else
                {
                    board[position] = symbol;
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
                whoPlays = COMPUTER;
                Console.WriteLine("Computer Plays First");
            }
            else
            {
                whoPlays = USER;
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
                    if(syb == userSelection)
                    {
                        winningPlayer = "User";
                    }
                    else
                    {
                        winningPlayer = "Computer";
                    }
                    Console.WriteLine("The winner is " + winningPlayer);
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

                if(isDraw)
                {
                    Console.WriteLine("Match Drawn");
                }
                return isDraw;
            }
        }
    }
}