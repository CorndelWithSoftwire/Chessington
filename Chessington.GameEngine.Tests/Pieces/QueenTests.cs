using System.Collections.Generic;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class QueenTests
    {
        [Test]
        public void Queen_CanMove_Laterally()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            board.AddPiece(Square.At(4, 4), queen);

            var moves = queen.GetAvailableMoves(board);
            var expectedMoves = new List<Square>();

            for (var i = 0; i < 8; i++)
                expectedMoves.Add(Square.At(4, i));

            for (var i = 0; i < 8; i++)
                expectedMoves.Add(Square.At(i, 4));

            //Get rid of our starting location.
            expectedMoves.RemoveAll(s => s == Square.At(4, 4));

            moves.Should().Contain(expectedMoves);
        }

        [Test]
        public void Queen_CanMove_Diagonally()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            board.AddPiece(Square.At(4, 4), queen);

            var moves = queen.GetAvailableMoves(board);
            var expectedMoves = new List<Square>();

            for (var i = 0; i < 8; i++)
                expectedMoves.Add(Square.At(i, i));

            for (var i = 1; i < 7; i++)
                expectedMoves.Add(Square.At(i, 8 - i));

            //Get rid of our starting location.
            expectedMoves.RemoveAll(s => s == Square.At(4, 4));

            moves.Should().Contain(expectedMoves);
        }

        [Test]
        public void Queen_CannotMakeAnyOtherMoves()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            board.AddPiece(Square.At(4, 4), queen);

            var moves = queen.GetAvailableMoves(board);

            //There are 27 valid lateral and diagonal moves. We need to make sure that no other moves are available.
            moves.Should().HaveCount(27);
        }
    }
}