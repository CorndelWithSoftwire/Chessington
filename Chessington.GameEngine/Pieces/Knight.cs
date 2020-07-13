using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> availableMoves = new List<Square>();
            var here = board.FindPiece(this);
            var dir = new int[] {-1, 1};
            foreach (var twoStep in dir)
            {
                foreach (var oneStep in dir) {
                    var target = new Square(here.Row + 2*twoStep, here.Col + oneStep);
                    if (target.isValid()) {
                        availableMoves.Add(target);
                    }
                    target = new Square(here.Row + oneStep, here.Col + 2*twoStep);
                    if (target.isValid()) {
                        availableMoves.Add(target);
                    }
                }
            }
            return availableMoves;
        }
    }
}