using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lasso.CollectionGrid
{
    public class CollectionGrid<T>
    {
        #region MemberVars

        private readonly Dictionary<(int row, int column), T> _data = new();

        #endregion

        #region Properties

        /// <summary>
        /// Returns all columns in the grid.
        /// </summary>
        public IEnumerable<IGrouping<int, T>> Columns =>
            _data.GroupBy(pair => pair.Key.column, element => element.Value);

        /// <summary>
        /// Returns the direction of the grid.
        /// </summary>
        public GridDirection Direction { get; }

        /// <summary>
        /// Returns the number of columns in the grid.
        /// </summary>
        public int NumColumns { get; }

        /// <summary>
        /// Returns the number of rows in the grid.
        /// </summary>
        public int NumRows { get; private set; }

        /// <summary>
        /// Returns all rows in the grid.
        /// </summary>
        public IEnumerable<IGrouping<int, T>> Rows =>
            _data.GroupBy(pair => pair.Key.row, element => element.Value);

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new CollectionGrid object.
        /// </summary>
        /// <param name="source">The elements that should be placed in the grid</param>
        /// <param name="numColumns">
        /// The number of columns the grid should have.
        /// The number of rows will be automatically calculated by dividing the number elements
        /// with the number of columns. 
        /// </param>
        /// <param name="direction">The direction of the grid</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public CollectionGrid(
            IEnumerable<T> source,
            int numColumns,
            GridDirection direction = GridDirection.Vertical
        )
        {
            var src = source.ToArray();

            if (src.Length < 1)
                throw new ArgumentOutOfRangeException(
                    nameof(source),
                    src.Length,
                    "Source.Count must be > 0."
                );

            if (numColumns < 2)
                throw new ArgumentOutOfRangeException(
                    nameof(numColumns),
                    numColumns,
                    "numColumns must be > 1."
                );

            Direction = direction;

            NumColumns = numColumns;

            switch (direction)
            {
                case GridDirection.Horizontal:
                    BuildHorizontalGrid(src);
                    break;
                case GridDirection.Vertical:
                    BuildVerticalGrid(src);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(direction),
                        direction,
                        "Invalid direction"
                    );
            }
        }

        #endregion

        #region PublicMethods

        /// <summary>
        /// Returns the value positioned at (row, column) in the grid.
        /// </summary>
        /// <param name="row">A positive integer between 1 and NumRows</param>
        /// <param name="column">A positive integer between 1 and NumColumns</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// If the cell does not contain a value.
        /// This can only occur when the number of elements in the grid differs
        /// from NumRows * NumColumns (on the "last" row/column)
        /// </exception>
        public T Cell(int row, int column)
        {
            CheckValidity(row, column);

            if (!_data.ContainsKey((row, column)))
                throw new ArgumentException($"Cell ({row}, {column}) contains no value.");

            return _data[(row, column)];
        }

        /// <summary>
        /// Returns all values from the specified column.
        /// </summary>
        /// <param name="column">A positive integer between 1 and NumColumns</param>
        /// <returns></returns>
        public IEnumerable<T> Column(int column)
        {
            CheckValidity(null, column);
            return _data.Where(pair => pair.Key.column == column).Select(pair => pair.Value);
        }

        /// <summary>
        /// Returns all values from the specified row.
        /// </summary>
        /// <param name="row">A positive integer between 1 and NumRows</param>
        /// <returns></returns>
        public IEnumerable<T> Row(int row)
        {
            CheckValidity(row, null);
            return _data.Where(pair => pair.Key.row == row).Select(pair => pair.Value);
        }

        /// <summary>
        /// Returns the grid as a string.
        /// This method will use T.ToString() to display the values.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"Direction: {Direction}");
            builder.AppendLine($"Number of columns: {NumColumns}");
            builder.AppendLine($"Number of rows: {NumRows}");

            foreach (var currentRow in Rows)
            {
                var column = 1;

                foreach (var current in currentRow)
                {
                    builder.Append($"({currentRow.Key}, {column}) {current}");
                    if (column < NumColumns)
                        builder.Append('\t');
                    column++;
                }

                builder.AppendLine();
            }

            return builder.ToString().TrimEnd();
        }

        #endregion

        #region PrivateMethods

        private void BuildHorizontalGrid(IReadOnlyCollection<T> source)
        {
            var column = 1;
            var row = 1;

            foreach (var current in source)
            {
                if (column == NumColumns + 1)
                {
                    column = 1;
                    row++;
                }

                _data[(row, column)] = current;

                column++;
            }

            NumRows = row;
        }

        private void BuildVerticalGrid(IReadOnlyCollection<T> source)
        {
            NumRows = (int)Math.Ceiling((decimal)source.Count / NumColumns);

            var column = 1;
            var row = 1;

            foreach (var current in source)
            {
                if (row > NumRows)
                {
                    column++;
                    row = 1;
                }

                _data[(row, column)] = current;

                row++;
            }
        }

        private void CheckValidity(int? row, int? column)
        {
            if (row.HasValue && !RowIsValid(row.Value))
                throw new ArgumentOutOfRangeException(
                    nameof(row),
                    row,
                    "Invalid row"
                );

            if (column.HasValue && !ColumnIsValid(column.Value))
                throw new ArgumentOutOfRangeException(
                    nameof(column),
                    column,
                    "Invalid column"
                );
        }

        private bool ColumnIsValid(int column) => column > 0 && column <= NumColumns;

        private bool RowIsValid(int row) => row > 0 && row <= NumRows;

        #endregion
    }
}