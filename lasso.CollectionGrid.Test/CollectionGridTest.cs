using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace lasso.CollectionGrid.Test
{
    public class CollectionGridTest
    {
        private readonly char[] _chars =
        {
            'A', 'B', 'C', 'D', 'E', 'F',
            'G', 'H', 'I', 'J', 'K', 'L',
            'M', 'N', 'O', 'P', 'Q','R',
            'S', 'T', 'U', 'V', 'W','X',
            'Y', 'Z'
        };

        [Fact]
        public void TestHorizontal3Columns()
        {
            var collectionGrid = new CollectionGrid<char>(_chars, 3, GridDirection.Horizontal);

            collectionGrid.NumColumns.Should().Be(3);
            collectionGrid.NumRows.Should().Be(9);

            var firstRow = collectionGrid.Row(1).ToArray();
            firstRow.Length.Should().Be(3);
            firstRow[0].Should().Be('A');
            firstRow[1].Should().Be('B');
            firstRow[2].Should().Be('C');

            var lastRow = collectionGrid.Row(collectionGrid.NumRows).ToArray();
            lastRow.Length.Should().Be(2);
            lastRow[0].Should().Be('Y');
            lastRow[1].Should().Be(('Z'));

            var firstColumn = collectionGrid.Column(1).ToArray();
            firstColumn.Length.Should().Be(9);
            firstColumn[0].Should().Be('A');
            firstColumn[1].Should().Be('D');
            firstColumn[2].Should().Be('G');
            firstColumn[3].Should().Be('J');
            firstColumn[4].Should().Be('M');
            firstColumn[5].Should().Be('P');
            firstColumn[6].Should().Be('S');
            firstColumn[7].Should().Be('V');
            firstColumn[8].Should().Be('Y');

            var lastColumn = collectionGrid.Column(collectionGrid.NumColumns).ToArray();
            lastColumn.Length.Should().Be(8);
            lastColumn[0].Should().Be('C');
            lastColumn[1].Should().Be('F');
            lastColumn[2].Should().Be('I');
            lastColumn[3].Should().Be('L');
            lastColumn[4].Should().Be('O');
            lastColumn[5].Should().Be('R');
            lastColumn[6].Should().Be('U');
            lastColumn[7].Should().Be('X');
        }

        [Fact]
        public void TestHorizontal7Columns()
        {
            var collectionGrid = new CollectionGrid<char>(_chars, 7, GridDirection.Horizontal);

            collectionGrid.NumColumns.Should().Be(7);
            collectionGrid.NumRows.Should().Be(4);

            var firstRow = collectionGrid.Row(1).ToArray();
            firstRow.Length.Should().Be(7);
            firstRow[0].Should().Be('A');
            firstRow[1].Should().Be('B');
            firstRow[2].Should().Be('C');
            firstRow[3].Should().Be('D');
            firstRow[4].Should().Be('E');
            firstRow[5].Should().Be('F');
            firstRow[6].Should().Be('G');

            var lastRow = collectionGrid.Row(collectionGrid.NumRows).ToArray();
            lastRow.Length.Should().Be((5));
            lastRow[0].Should().Be('V');
            lastRow[1].Should().Be(('W'));
            lastRow[2].Should().Be(('X'));
            lastRow[3].Should().Be(('Y'));
            lastRow[4].Should().Be(('Z'));

            var firstColumn = collectionGrid.Column(1).ToArray();
            firstColumn.Length.Should().Be(4);
            firstColumn[0].Should().Be('A');
            firstColumn[1].Should().Be('H');
            firstColumn[2].Should().Be('O');
            firstColumn[3].Should().Be('V');

            var lastColumn = collectionGrid.Column(collectionGrid.NumColumns).ToArray();
            lastColumn.Length.Should().Be(3);
            lastColumn[0].Should().Be('G');
            lastColumn[1].Should().Be('N');
            lastColumn[2].Should().Be('U');
        }

        [Fact]
        public void TestVertical3Columns()
        {
            var collectionGrid = new CollectionGrid<char>(_chars, 3);

            collectionGrid.NumColumns.Should().Be(3);
            collectionGrid.NumRows.Should().Be(9);

            var firstRow = collectionGrid.Row(1).ToArray();
            firstRow.Length.Should().Be(3);
            firstRow[0].Should().Be('A');
            firstRow[1].Should().Be('J');
            firstRow[2].Should().Be('S');

            var lastRow = collectionGrid.Row(collectionGrid.NumRows).ToArray();
            lastRow.Length.Should().Be((2));
            lastRow[0].Should().Be('I');
            lastRow[1].Should().Be(('R'));

            var firstColumn = collectionGrid.Column(1).ToArray();
            firstColumn.Length.Should().Be(9);
            firstColumn[0].Should().Be('A');
            firstColumn[1].Should().Be('B');
            firstColumn[2].Should().Be('C');
            firstColumn[3].Should().Be('D');
            firstColumn[4].Should().Be('E');
            firstColumn[5].Should().Be('F');
            firstColumn[6].Should().Be('G');
            firstColumn[7].Should().Be('H');
            firstColumn[8].Should().Be('I');

            var lastColumn = collectionGrid.Column(collectionGrid.NumColumns).ToArray();
            lastColumn.Length.Should().Be(8);
            lastColumn[0].Should().Be('S');
            lastColumn[1].Should().Be('T');
            lastColumn[2].Should().Be('U');
            lastColumn[3].Should().Be('V');
            lastColumn[4].Should().Be('W');
            lastColumn[5].Should().Be('X');
            lastColumn[6].Should().Be('Y');
            lastColumn[7].Should().Be('Z');
        }

        [Fact]
        public void TestVertical7Columns()
        {
            var collectionGrid = new CollectionGrid<char>(_chars, 7);

            collectionGrid.NumColumns.Should().Be(7);
            collectionGrid.NumRows.Should().Be(4);

            var firstRow = collectionGrid.Row(1).ToArray();
            firstRow.Length.Should().Be(7);
            firstRow[0].Should().Be('A');
            firstRow[1].Should().Be('E');
            firstRow[2].Should().Be('I');
            firstRow[3].Should().Be('M');
            firstRow[4].Should().Be('Q');
            firstRow[5].Should().Be('U');
            firstRow[6].Should().Be('Y');

            var lastRow = collectionGrid.Row(collectionGrid.NumRows).ToArray();
            lastRow.Length.Should().Be((6));
            lastRow[0].Should().Be('D');
            lastRow[1].Should().Be(('H'));
            lastRow[2].Should().Be(('L'));
            lastRow[3].Should().Be(('P'));
            lastRow[4].Should().Be(('T'));
            lastRow[5].Should().Be(('X'));

            var firstColumn = collectionGrid.Column(1).ToArray();
            firstColumn.Length.Should().Be(4);
            firstColumn[0].Should().Be('A');
            firstColumn[1].Should().Be('B');
            firstColumn[2].Should().Be('C');
            firstColumn[3].Should().Be('D');

            var lastColumn = collectionGrid.Column(collectionGrid.NumColumns).ToArray();
            lastColumn.Length.Should().Be(2);
            lastColumn[0].Should().Be('Y');
            lastColumn[1].Should().Be('Z');
        }

        [Fact]
        public void TestBounds()
        {
            Action act1 = () => new CollectionGrid<char>(Enumerable.Empty<char>(), 3);
            act1.Should().ThrowExactly<ArgumentOutOfRangeException>()
                .WithMessage(
                    "Source.Count must be > 0. " +
                    "(Parameter 'source')" + Environment.NewLine +
                    "Actual value was 0."
                );

            Action act2 = () => new CollectionGrid<char>(_chars, 1);

            act2.Should().ThrowExactly<ArgumentOutOfRangeException>()
                .WithMessage(
                    "numColumns must be > 1. " +
                    "(Parameter 'numColumns')" + Environment.NewLine +
                    "Actual value was 1."
                );
        }

        [Fact]
        public void TestCells()
        {
            var horizontalCollectionGrid = new CollectionGrid<char>(_chars, 4, GridDirection.Horizontal);
            horizontalCollectionGrid.Cell(1, 1).Should().Be('A');
            horizontalCollectionGrid.Cell(2, 2).Should().Be('F');
            horizontalCollectionGrid.Cell(3, 3).Should().Be('K');
            horizontalCollectionGrid.Cell(4, 4).Should().Be('P');
            horizontalCollectionGrid.Cell(5, 1).Should().Be('Q');
            horizontalCollectionGrid.Cell(6, 2).Should().Be('V');

            // For cells that don't exist, we should throw an exceptions
            horizontalCollectionGrid
                .Invoking(hgc => hgc.Cell(7, 3))
                .Should().ThrowExactly<ArgumentException>()
                .WithMessage("Cell (7, 3) contains no value.");
        }

        [Fact]
        public void TestCollection()
        {
            var horizontalCollectionGrid = new CollectionGrid<char>(_chars, 8, GridDirection.Horizontal);
            horizontalCollectionGrid.NumColumns.Should().Be(8);
            horizontalCollectionGrid.NumRows.Should().Be(4);
            horizontalCollectionGrid.Columns.Count().Should().Be(horizontalCollectionGrid.NumColumns);
            horizontalCollectionGrid.Rows.Count().Should().Be(horizontalCollectionGrid.NumRows);

            var verticalCollectionGrid = new CollectionGrid<char>(_chars, 6);
            verticalCollectionGrid.NumColumns.Should().Be(6);
            verticalCollectionGrid.NumRows.Should().Be(5);
            verticalCollectionGrid.Columns.Count().Should().Be(verticalCollectionGrid.NumColumns);
            verticalCollectionGrid.Rows.Count().Should().Be(verticalCollectionGrid.NumRows);
        }

        [Fact]
        public void TestDirection()
        {
            var defaultCollectionGrid = new CollectionGrid<char>(_chars, 4);
            defaultCollectionGrid.Direction.Should().Be(GridDirection.Vertical);

            var horizontalCollectionGrid = new CollectionGrid<char>(_chars, 3, GridDirection.Horizontal);
            horizontalCollectionGrid.Direction.Should().Be(GridDirection.Horizontal);

            var verticalCollectionGrid = new CollectionGrid<char>(_chars, 5);
            verticalCollectionGrid.Direction.Should().Be(GridDirection.Vertical);
        }

        [Fact]
        public void TestToString()
        {
            var squareCollectionGrid = new CollectionGrid<char>(_chars.Take(4), 2);
            var collectionGridString = squareCollectionGrid.ToString();

            // Split lines and check each line for correct output.
            var lines = collectionGridString.Split(Environment.NewLine);

            lines.Length.Should().Be(5);
            lines[0].Should().Be("Direction: Vertical");
            lines[1].Should().Be("Number of columns: 2");
            lines[2].Should().Be("Number of rows: 2");
            lines[3].Should().Be("(1, 1) A\t(1, 2) C");
            lines[4].Should().Be("(2, 1) B\t(2, 2) D");
        }
    }
}