using System.Collections.Generic;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class KnightTests
    {
        [Test]
        public void Knights_CanPerformKnightsMoves()
        {
            var board = new Board();
            var knight = new Knight(Player.White);
            board.AddPiece(Square.At(4, 4), knight);

            var moves = knight.GetAvailableMoves(board);

            var expectedMoves = new List<Square>
            {
                Square.At(2, 5),
                Square.At(2, 3),
                Square.At(3, 6),
                Square.At(3, 2),
                Square.At(5, 6),
                Square.At(5, 2),
                Square.At(6, 5),
                Square.At(6, 3)
            };

            moves.ShouldAllBeEquivalentTo(expectedMoves);
        }

        [Test]
        public void Knights_CanJumpOverPieces()
        {
            var board = new Board();
            var knight = new Knight(Player.White);
            board.AddPiece(Square.At(4, 4), knight);

            var firstPawn = new Pawn(Player.White);
            var secondPawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(3, 4), firstPawn);
            board.AddPiece(Square.At(3, 5), secondPawn);

            var moves = knight.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(2, 5));
        }

        [Test]
        public void Knights_CannotLeaveTheBoard()
        {
            var board = new Board();
            var knight = new Knight(Player.White);
            board.AddPiece(Square.At(0, 0), knight);

            var moves = knight.GetAvailableMoves(board);

            var expectedMoves = new List<Square> {Square.At(1, 2), Square.At(2, 1)};
            moves.ShouldAllBeEquivalentTo(expectedMoves);
        }

        [Test]
        public void Knights_CanTakeOpposingPieces()
        {
            var board = new Board();
            var knight = new Knight(Player.White);
            board.AddPiece(Square.At(4, 4), knight);

            var pawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(2, 5), pawn);

            var moves = knight.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(2, 5));
        }

        [Test]
        public void Knights_CannotTakeFriendlyPieces()
        {
            var board = new Board();
            var knight = new Knight(Player.White);
            board.AddPiece(Square.At(4, 4), knight);
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(2, 5), pawn);

            var moves = knight.GetAvailableMoves(board);

            moves.Should().NotContain(Square.At(2, 5));
        }
    }
}