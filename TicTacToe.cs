using System;

namespace Sharp{
    class TicTacToe{
        private char[] board;
        private char currentPlayer;
        public TicTacToe(){
            board = new char[9];
            currentPlayer = 'X'; // The first player will always be X; 
        }
        static void Main(string[] args){
           TicTacToe game = new TicTacToe();
           game.play();
        }

        public void play(){
            Console.WriteLine(this);
            bool ongoing = true;
            while(ongoing){
                Console.WriteLine("Player: " + this.currentPlayer + ", it is your turn." + "\n" + 
                "Choose an index to place an [" + this.currentPlayer + "]. (0 - 8)");
                int chosenSpot = Convert.ToInt32(Console.ReadLine());
                while(chosenSpot > 8 || chosenSpot < 0 || this.isTaken(chosenSpot)){
                    Console.WriteLine("Try again.");
                    chosenSpot = Convert.ToInt32(Console.ReadLine());
                }
                placePiece(chosenSpot);
                Console.WriteLine(this);
                if(xWins() || oWins()){
                    Console.WriteLine(this.currentPlayer + " Wins!");
                    break;
                }
                ongoing = false;
                for(int i = 0; i < this.board.Length; i++){
                    if(!this.isTaken(i))
                      ongoing = true;
                }
                if(!ongoing){
                  Console.WriteLine("The game has ended in a tie!");
                  break;
                }
                switchPlayer();
            }
        }

        public void placePiece(int index){
            if(this.isTaken(index))
                Console.WriteLine("Err. Spot already taken.");
            else
                this.board[index] = this.currentPlayer;
        }

        public void switchPlayer(){
            if(this.currentPlayer == 'X')
                this.currentPlayer = 'O';
            else if(this.currentPlayer == 'O')
                this.currentPlayer = 'X';
        }

        public bool isTaken(int index){
            if(this.board[index] != 0) // Wack but works
                return true;
            return false;
        }

        public bool xWins(){
        bool xWins = false;
        if(board[0] == 'X' && board[1] == 'X' && board[2] == 'X')//- top
          xWins = true;
        if(board[3] == 'X' && board[4] == 'X' && board[5] == 'X')// - mid
          xWins = true;
        if(board[6] == 'X' && board[7] == 'X' && board[8] == 'X')// - bot
          xWins = true;
        if(board[0] == 'X' && board[3] == 'X' && board[6] == 'X')// | left
          xWins = true;
        if(board[1] == 'X' && board[4] == 'X' && board[7] == 'X')// | mid
          xWins = true;
        if(board[2] == 'X' && board[5] == 'X' && board[8] == 'X')// | right
          xWins = true;
        if(board[0] == 'X' && board[4] == 'X' && board[8] == 'X')// \ diag
          xWins = true;
        if(board[2] == 'X' && board[4] == 'X' && board[6] == 'X')// / diag
          xWins = true;
        return xWins;
    }
    public bool oWins(){
      bool oWins = false;
        if(board[0] == 'O' && board[1] == 'O' && board[2] == 'O')//- top
          oWins = true;
        if(board[3] == 'O' && board[4] == 'O' && board[5] == 'O')// - mid
          oWins = true;
        if(board[6] == 'O' && board[7] == 'O' && board[8] == 'O')// - bot
          oWins = true;
        if(board[0] == 'O' && board[3] == 'O' && board[6] == 'O')// | left
          oWins = true;
        if(board[1] == 'O' && board[4] == 'O' && board[7] == 'O')// | mid
          oWins = true;
        if(board[2] == 'O' && board[5] == 'O' && board[8] == 'O')// | right
          oWins = true;
        if(board[0] == 'O' && board[4] == 'O' && board[8] == 'O')// \ diag
          oWins = true;
        if(board[2] == 'O' && board[4] == 'O' && board[6] == 'O')// / diag
          oWins = true;
        return oWins;
    }

        
        public override string ToString (){
            string output = "";
            output += this.board[0] + " | " + this.board[1] + " | " + this.board[2] + "\n"
                    + "--+---+--\n"
                    + this.board[3] + " | " + this.board[4] + " | " + this.board[5] + "\n"
                    + "--+---+--\n"
                    + this.board[6] + " | " + this.board[7] + " | " + this.board[8];
            return output;
        }
    }
}
