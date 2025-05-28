using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle015ThrereIsNoSpoon1
{
    public class MatrixIterator<T> : IEnumerable<T>
    {
        private readonly T[,] _array;
        private readonly ScanMode _mode;
        private readonly int _x, _y;
        private int _currentX, _currentY;

        public enum ScanMode
        {
            Horizontal, // Iterates row-wise starting from position (x, y)
            Vertical,   // Iterates column-wise starting from position (x, y)
            Full        // Iterates row-wise and column-wise starting from position (x, y)
        }

        public MatrixIterator(T[,] array, ScanMode mode, int x, int y)
        {
            _array = array;
            _mode = mode;
            _x = x;
            _y = y;
        }

        public MatrixIterator(T[] array, ScanMode mode, int x, int y)
        {
            _array = Create2DArrayFrom1D(array, array.Length, 1);
            _mode = mode;
            _x = x;
            _y = y;
        }

        private T[,] Create2DArrayFrom1D(T[] array, int rows, int cols)
        {
            if (array.Length != rows * cols)
            {
                throw new ArgumentException("The length of the 1D array does not match the specified dimensions of the 2D array.");
            }

            T[,] result = new T[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = array[i * cols + j];
                }
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int rows = _array.GetLength(0);
            int cols = _array.GetLength(1);

            // Ensure the starting point is within bounds
            if (_x < 0 || _x >= rows || _y < 0 || _y >= cols)
            {
                //throw new ArgumentOutOfRangeException("Starting position is out of bounds.");
                yield break;
            }

            if (_mode == ScanMode.Horizontal)
            {
                // Iterate over the specified row starting at position (x, y)
                for (int col = _y; col < cols; col++)
                {
                    _currentX = col;
                    _currentY = _x;
                    yield return _array[_x, col];
                }
            }
            else if (_mode == ScanMode.Vertical)
            {
                // Iterate over the specified column starting at position (x, y)
                for (int row = _x; row < rows; row++)
                {
                    _currentX = _y;
                    _currentY = row;
                    yield return _array[row, _y];
                }
            }
            else if (_mode == ScanMode.Full)
            {
                // Iterate over the whole matrix starting at position (x, y)
                for (int col = _y; col < cols; col++)
                {
                    for (int row = _x; row < rows; row++)
                    {
                        _currentX = col;
                        _currentY = row;
                        yield return _array[col, row];
                    }
                }
            }
        }

        public int GetRow()
        {
            return _currentY;
        }

        public int GetColumn()
        {
            return _currentX;
        }

        // Required for non-generic IEnumerator interface
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
