using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    //Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 
    //Implement an indexer this[row, col] to access the inner matrix cells.

    public class Matrix<T>
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private T[,] matrix;
        private int rows;
        private int cols;
        private int Rows
        {
            get { return this.rows; }
        }
        public int Cols
        {
            get { return this.cols; }
        }

        public T this[int row, int col]
        {
            get { return matrix[row, col]; }
            set { matrix[row, col] = value; }
        }

        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            matrix = new T[rows, cols];
        }
        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.rows == m2.rows && m1.cols == m2.cols)
            {
                Matrix<T> result = new Matrix<T>(m1.rows, m1.cols);
                for (int i = 0; i < m1.Rows; i++)
                {
                    for (int j = 0; j < m1.Cols; j++)
                    {
                        result[i, j] = (dynamic)m1[i, j] + m2[i, j];
                    }
                }
                return result;
            }
            else
            {
                throw new Exception("Can't sum different matrices.");
            }
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.rows == m2.rows && m1.cols == m2.cols)
            {
                Matrix<T> result = new Matrix<T>(m1.rows, m1.cols);
                for (int i = 0; i < m1.Rows; i++)
                {
                    for (int j = 0; j < m1.Cols; j++)
                    {
                        result[i, j] = (dynamic)m1[i, j] - m2[i, j];
                    }
                }
                return result;
            }
            else
            {
                throw new Exception("Can't substract different matrices.");
            }
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.rows == m2.rows && m1.cols == m2.cols)
            {
                Matrix<T> result = new Matrix<T>(m1.rows, m1.cols);
                for (int i = 0; i < m1.Rows; i++)
                {
                    for (int j = 0; j < m1.Cols; j++)
                    {
                        result[i, j] = (dynamic)m1[i, j] * m2[i, j];
                    }
                }
                return result;
            }
            else
            {
                throw new Exception("Can't multiple different matrices.");
            }
        }

        public static bool operator true(Matrix<T> m)
        {
            for (int row = 0; row < m.Rows; row++)
            {
                for (int col = 0; col < m.Cols; col++)
                {
                    if ((dynamic)m[row, col] != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool operator false(Matrix<T> m)
        {
            for (int row = 0; row < m.Rows; row++)
            {
                for (int col = 0; col < m.Cols; col++)
                {
                    if ((dynamic)m[row, col] != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.rows; i++)
            {
                result.Append("{ ");
                for (int j = 0; j < this.cols; j++)
                {
                    result.Append(this.matrix[i, j] + ", ");
                }
                result.Append("}\n");
            }
            return result.ToString();
        }
    }
}
