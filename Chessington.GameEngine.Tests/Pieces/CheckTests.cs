using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class CheckTests
    {
        [Test]
        public void Kings_CannotMove_IntoCheck()
        {
            var board = new Board();
            var king = new King(Player.White);
            board.AddPiece(Square.At(4, 4), king);
            var rook = new Rook(Player.Black);
            board.AddPiece(Square.At(3, 3), rook);

            var moves = king.GetNonCheckMoves(board);
            moves.Should().NotContain(Square.At(4, 3));
        }

        [Test]
        public void OtherPieces_CannotLeaveKing_InCheck()
        {
            var board = new Board();
            var king = new King(Player.White);
            board.AddPiece(Square.At(4, 4), king);
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(1, 6), pawn);
            var rook = new Rook(Player.Black);
            board.AddPiece(Square.At(4, 7), rook);

            var moves = pawn.GetNonCheckMoves(board);
            moves.Should().BeEmpty();
        }

        [Test]
        public void OtherPieces_CannotPutKing_InCheck()
        {
            var board = new Board();
            var king = new King(Player.White);
            board.AddPiece(Square.At(4, 4), king);
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(4, 6), pawn);
            var rook = new Rook(Player.Black);
            board.AddPiece(Square.At(4, 7), rook);

            var moves = pawn.GetNonCheckMoves(board);
            moves.Should().BeEmpty();
        }
    }
}