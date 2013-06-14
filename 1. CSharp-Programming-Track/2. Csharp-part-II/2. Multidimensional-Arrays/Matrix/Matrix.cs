//* Write a class Matrix, to holds a matrix of integers. 
//Overload the operators for adding, subtracting and multiplying of matrices,
//indexer for accessing the matrix content and ToString().

using System;
using System.Text;

namespace Matrix
{
    class Matrix
    {
        private int rows;
        public int Rows
        {
            get { return this.rows; }
        }
        private int cols;
        public int Cols
        {
            get { return this.cols; }
        }
        private int[,] matrix;

        public int this[int row, int col]
        {
            get { return matrix[row, col]; }
            set { matrix[row, col] = value; }
        }

        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            matrix = new int[rows, cols];
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.rows == matrix2.rows && matrix1.cols == matrix2.cols)
            {
                Matrix result = new Matrix(matrix1.rows, matrix1.cols);
                for (int i = 0; i < matrix1.rows; i++)
                {
                    for (int j = 0; j < matrix1.cols; j++)
                    {
                        result[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }
                return result;
            }
            else
            {
                throw new Exception("Can't sum different matrices.");
            }
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.rows == matrix2.rows && matrix1.cols == matrix2.cols)
            {
                Matrix result = new Matrix(matrix1.rows, matrix1.cols);
                for (int i = 0; i < matrix1.rows; i++)
                {
                    for (int j = 0; j < matrix1.cols; j++)
                    {
                        result[i, j] = matrix1[i, j] - matrix2[i, j];
                    }
                }
                return result;
            }
            else
            {
                throw new Exception("Can't substract different matrices.");
            }
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.rows == matrix2.rows && matrix1.cols == matrix2.cols)
            {
                Matrix result = new Matrix(matrix1.rows, matrix1.cols);
                for (int i = 0; i < matrix1.rows; i++)
                {
                    for (int j = 0; j < matrix1.cols; j++)
                    {
                        result[i, j] = matrix1[i, j] * matrix2[i, j];
                    }
                }
                return result;
            }
            else
            {
                throw new Exception("Can't multiple different matrices.");
            }
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.rows; i++)
            {
                result.Append("{ ");
                for (int j = 0; j < this.cols; j++)
                {
                    result.Append(this.matrix[i, j]+", ");
                }
                result.Append("}\n");
            }
            return result.ToString();
        }
    }
}
