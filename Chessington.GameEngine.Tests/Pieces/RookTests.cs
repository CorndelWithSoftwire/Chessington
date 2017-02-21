using System.Collections.Generic;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class RookTests
    {
        [Test]
        public void Rook_CanMove_Laterally()
        {
            var board = new Board();
            var rook = new Rook(Player.White);
            board.AddPiece(Square.At(4, 4), rook);

            var moves = rook.GetAvailableMoves(board);
            var expectedMoves = new List<Square>();

            for (var i = 0; i < 8; i++)
                expectedMoves.Add(Square.At(4, i));

            for (var i = 0; i < 8; i++)
                expectedMoves.Add(Square.At(i, 4));

            //Get rid of our starting location.
            expectedMoves.RemoveAll(s => s == Square.At(4, 4));

            moves.Should().Contain(expectedMoves);
        }
    }
}