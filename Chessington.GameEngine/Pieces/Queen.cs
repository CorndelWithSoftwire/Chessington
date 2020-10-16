﻿using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            for (int i = 1; i < GameSettings.BoardSize; i++)
            {
                AddIfOnBoard(new Square(currentSquare.Row + i, currentSquare.Col + i), moves);
                AddIfOnBoard(new Square(currentSquare.Row - i, currentSquare.Col + i), moves);
                AddIfOnBoard(new Square(currentSquare.Row + i, currentSquare.Col - i), moves);
                AddIfOnBoard(new Square(currentSquare.Row - i, currentSquare.Col - i), moves);
                AddIfOnBoard(new Square(currentSquare.Row + i, currentSquare.Col), moves);
                AddIfOnBoard(new Square(currentSquare.Row - i, currentSquare.Col), moves);
                AddIfOnBoard(new Square(currentSquare.Row, currentSquare.Col + i), moves);
                AddIfOnBoard(new Square(currentSquare.Row, currentSquare.Col - i), moves);
            }

            return moves;
        }
    }
}