//-----------------------------------------------------------------------
// <copyright file="ChessBoard.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _1.Chess.Entities
{
    using System;
    using System.IO;
    using Properties;
    using View;

    /// <summary>
    /// This is class for main entity.
    /// </summary>
    public class ChessBoard
    {
        /// <summary>
        /// Path to the file with specification.
        /// </summary>
        private const string SPECIFICATION =
                @"..\..\TextFiles\Specification.txt";

        /// <summary>
        /// Minimal value of board side.
        /// </summary>
        private const int MinValue = 2;

        /// <summary>
        /// Maximal value of board side.
        /// </summary>
        private const int MaxValue = 80;


        /// <summary>
        /// Interface reference for displaying result.
        /// </summary>
        private IView view;

        /// <summary>
        /// Height of the chess board.
        /// </summary>
        private int height;

        /// <summary>
        /// Width of the chess board.
        /// </summary>
        private int width;

        /// <summary>
        /// Scheme of the board.
        /// </summary>
        private bool[,] cells;

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="ChessBoard" /> class.
        /// </summary>
        public ChessBoard()
        {
            this.view = new ConsoleView();
            this.view.Display(File.ReadAllText(SPECIFICATION));
        }

        /// <summary>
        ///  Initializes a new instance of the 
        ///  <see cref="ChessBoard" /> class.
        /// </summary>
        /// <param name="width">Width of the chess board.</param>
        /// <param name="height">Height of the chess board.</param>
        public ChessBoard(string width, string height)
        {
            this.Width = int.Parse(width);
            this.Height = int.Parse(height);
            this.InitializeCells();
        }

        /// <summary>
        /// Gets scheme of the chess board.
        /// </summary>
        public bool[,] Cells
        {
            get
            {
                return this.cells;
            }
        }

        /// <summary>
        /// Gets or sets height of the chess board.
        /// </summary>
        public int Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format(Resources.NoHeight, value));
                }

                this.height = value;
            }
        }

        /// <summary>
        /// Gets or sets width of the chess board.
        /// </summary>
        public int Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new ArgumentOutOfRangeException(string.Format(Resources.NoWidth, value));
                }

                this.width = value;
            }
        }

        /// <summary>
        /// Reset ToString() for this class.
        /// </summary>
        private void InitializeCells()
        {
            this.cells = new bool[this.Height, this.Width];
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        this.cells[i, j] = true;
                    }
                    else
                    {
                        this.cells[i, j] = false;
                    }
                }
            }
        }       
    }
}