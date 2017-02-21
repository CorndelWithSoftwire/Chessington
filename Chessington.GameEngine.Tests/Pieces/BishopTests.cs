using System.Collections.Generic;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class BishopTests
    {
        [Test]
        public void Bishop_CanMove_Diagonally()
        {
            var board = new Board();
            var bishop = new Bishop(Player.White);
            board.AddPiece(Square.At(4, 4), bishop);

            var moves = bishop.GetAvailableMoves(board);

            var expectedMoves = new List<Square>();

            //Checking the backwards diagonal, i.e. 0,0 1,1, 2,2
            for (var i = 0; i < 8; i++)
                expectedMoves.Add(Square.At(i, i));

            //Checking the forwards diagonal i.e. 5,3 6,2 7,1
            for (var i = 1; i < 8; i++)
                expectedMoves.Add(Square.At(i, 8 - i));

            //Get rid of our starting location.
            expectedMoves.RemoveAll(s => s == Square.At(4, 4));

            moves.ShouldAllBeEquivalentTo(expectedMoves);
        }

        [Test]
        public void Bishop_CannnotPassThrough_OpposingPieces()
        {
            var board = new Board();
            var bishop = new Bishop(Player.White);
            board.AddPiece(Square.At(4, 4), bishop);
            var pieceToTake = new Pawn(Player.Black);
            board.AddPiece(Square.At(6, 6), pieceToTake);

            var moves = bishop.GetAvailableMoves(board);
            moves.Should().NotContain(Square.At(7, 7));
        }

        [Test]
        public void Bishop_CannnotPassThrough_FriendlyPieces()
        {
            var board = new Board();
            var bishop = new Bishop(Player.White);
            board.AddPiece(Square.At(4, 4), bishop);
            var friendlyPiece = new Pawn(Player.White);
            board.AddPiece(Square.At(6, 6), friendlyPiece);

            var moves = bishop.GetAvailableMoves(board);
            moves.Should().NotContain(Square.At(7, 7));
        }

        [Test]
        public void Bishop_CanTake_OpposingPieces()
        {
            var board = new Board();
            var bishop = new Bishop(Player.White);
            board.AddPiece(Square.At(4, 4), bishop);
            var pieceToTake = new Pawn(Player.Black);
            board.AddPiece(Square.At(6, 6), pieceToTake);

            var moves = bishop.GetAvailableMoves(board);
            moves.Should().Contain(Square.At(6, 6));
        }

        [Test]
        public void Bishop_CannotTake_FriendlyPieces()
        {
            var board = new Board();
            var bishop = new Bishop(Player.White);
            board.AddPiece(Square.At(4, 4), bishop);
            var friendlyPiece = new Pawn(Player.White);
            board.AddPiece(Square.At(6, 6), friendlyPiece);

            var moves = bishop.GetAvailableMoves(board);
            moves.Should().NotContain(Square.At(6, 6));
        }
    }
}