using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Board
    {
        private char _player1Token;
        private char _player2Token;
        private char _currentToken;
        private char[,] _board;
        
        /// <summary>
        /// Initializes player tokens and the game board
        /// </summary>
        public void Start()
        {
            _player1Token = 'x';
            _player2Token = 'o';
            _currentToken = _player1Token;
            _board = new char[3, 3]{ { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
            
        }

        /// <summary>
        /// Gets the input from the player.
        /// Sets the player token at the desired spot in the 2D array.
        /// Checks if there is a winner.
        /// Changes the current token in play.
        /// </summary>
        public void Update()
        {
            //Check both tokens/ players to see if they reached win condition
            CheckWinner(_player1Token);
            CheckWinner(_player2Token);

            Console.WriteLine("Current Token turn: " + _currentToken);
            
            if (SetToken(_currentToken, 1, 1))
            {

                if (_currentToken == _player1Token)
                    _currentToken = _player2Token;
                else
                    _currentToken = _player1Token;
            }                       
        }

        /// <summary>
        /// Draws the board and lets the players know whose turn it is.
        /// </summary>
        public void Draw()
        {
            Console.WriteLine(_board[0, 0] + " | " + _board[0, 1] + " | " + _board[0, 2] + "\n" +
                                                  "___________\n" +
                              _board[1, 0] + " | " + _board[1, 1] + " | " + _board[1, 2] + "\n" +
                                                  "___________\n" +
                              _board[2, 0] + " | " + _board[2, 1] + " | " + _board[2, 2] + "\n");
        }

        public void End()
        {
            Console.WriteLine("Thanks for Playing");
            
        }

        /// <summary>
        /// Assigns the spot at the given indices in the board array to be the given token.
        /// </summary>
        /// <param name="token">The token to set the array index to.</param>
        /// <param name="posX">The x position of the token.</param>
        /// <param name="posY">The y position of the token.</param>
        /// <returns>Return false if the indices are out of range.</returns>
        public bool SetToken(char token, int posX, int posY)
        {            
            int place = (Game.GetInput());
            //Places the token as long as its destination is between 0 or 8
            if (place >= 0 && place <= 8)
            {
                //Sets the position of the token.
                posX = place / 3;
                posY = place % 3;
                if (_board[posX,posY] != 'x' && _board[posX,posY] != 'o')
                {
                    //Places it on the board based on that place
                    _board[posX, posY] = token;
                    return true;
                }
                return false;                 
            }            
            //If the move is invalit
            else
            {
                Console.WriteLine("Invalid Response");
                Console.WriteLine("Current Token turn: " + _currentToken);
                SetToken(_currentToken, 1, 1);                
            }
           
            return true;
        }
        
        /// <summary>
        /// Checks to see if the token appears three times consecutively vertically, horizontally , or diagonally.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool CheckWinner(char token)
        {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                //IF you win condition is met horizontal
                if (_board[i,0] == token && _board[i,1] == token && _board[i,2] == token)
                {
                    Console.WriteLine("You Win-" + token);
                    ClearBoard();
                    return true;
                }
                //Checks if win condition is met vertically
                else if (_board[0,i] == token && _board[1,i] == token && _board[2,i] == token)
                {
                    Console.WriteLine("You Win-" + token);
                    ClearBoard();
                    return true;
                }
            }
            //Checks if win condition is met Diagnal
            if (_board[0,0] == token && _board[1,1] == token && _board[2,2] == token)
            {
                Console.WriteLine("You Win-" + token);
                ClearBoard();
                return true;
            }
            else if(_board[0,2] == token && _board[1,1] == token && _board[2,0] == token)
            {
                Console.WriteLine("You Win-" + token);
                ClearBoard();
                return true;                
            }
                           
            return false;
        }

        /// <summary>
        /// Resets the board to it's default state.
        /// </summary>
        public void ClearBoard()
        {
            Console.WriteLine("Would You like to play Again?" + "\n1.Yes" + "\n2.No");
            int input = (Game.GetInput());
            if (input == 0)
            {
                Console.Clear();
                _player1Token = 'x';
                _player2Token = 'o';
                _currentToken = _player1Token;
                _board = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
            }
            else if (input == 1)
            {
                End();
            }
            
        }
    }
}
