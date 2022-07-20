using System.Collections.Generic;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class CheckTests
    {
        [Test]
        public void enPassantMovePossibility()
        {
            var board = new Board(Player.White);
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(4, 4), pawn);
            pawn.MoveTo(board, Square.At(3, 4));
            var pawn1 = new Pawn(Player.Black);
            board.AddPiece(Square.At(3, 5), pawn1);
            var pawn2 = new Pawn(Player.Black);
            board.AddPiece(Square.At(1, 3), pawn2);

            pawn2.MoveTo(board, Square.At(3, 3));

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(2, 3));
            moves.Should().Contain(Square.At(2, 4));
            moves.Should().NotContain(Square.At(2, 5));
        }
    }
}