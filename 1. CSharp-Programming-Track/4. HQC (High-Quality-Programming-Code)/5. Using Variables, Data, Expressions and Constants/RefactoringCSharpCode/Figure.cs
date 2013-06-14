// ##########################################################
// # <copyright file="Figure.cs" company="Telerik Academy">
// # Copyright (c) 2013 Telerik Academy. All rights reserved.
// # </copyright>
// ##########################################################
namespace RefactoringCSharpCode
{
    using System;

    /// <summary>
    /// Represents Figure with width and height.
    /// </summary>
    internal class Figure
    {
        private double width;
        private double height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Figure"/> class.
        /// with specified <paramref name="width"/> and <paramref name="height"/>.
        /// </summary>
        /// <param name="width">Width of the figure</param>
        /// <param name="height">Height of the figure</param>
        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Gets or sets the width of figure.
        /// </summary>
        /// <exception cref="System.ArgumentException">
        /// Throws when negative value is set.
        /// </exception>
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Figure width can't be negative number.");
                }

                this.width = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of figure.
        /// </summary>
        /// <exception cref="System.ArgumentException">
        /// Throws when negative value is set.
        /// </exception>
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Figre height can't be negative number.");
                }

                this.height = value;
            }
        }

        /// <summary>
        /// Return new <see cref="Figure"/> rotated by <paramref name="angle"/>
        /// </summary>
        /// <param name="figure">Figure to rotate.</param>
        /// <param name="angle">Angle to rotate.</param>
        /// <returns>new <see cref="Figure"/> rotated by <paramref name="angle"/></returns>
        public static Figure GetRotatedFigure(Figure figure, double angle)
        {
            double sinOfAngle = Math.Sin(angle);
            double cosOfAngle = Math.Cos(angle);

            double rotatedFigureWidth = (Math.Abs(cosOfAngle) * figure.Width) + (Math.Abs(sinOfAngle) * figure.Height);
            double rotatedFigureHeight = (Math.Abs(sinOfAngle) * figure.Width) + (Math.Abs(cosOfAngle) * figure.Height);

            Figure rotatedFigure = new Figure(rotatedFigureWidth, rotatedFigureHeight);
            return rotatedFigure;
        }
    }
}
