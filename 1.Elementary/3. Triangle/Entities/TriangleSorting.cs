//-----------------------------------------------------------------------
// <copyright file="TriangleSorting.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _3.Triangle.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text.RegularExpressions;
    using Properties;
    using View;

    /// <summary>
    /// It is a class to process actions with triangles.
    /// </summary>
    public class TriangleSorting
    {
        /// <summary>
        /// Field for path to the specification file;
        /// </summary>
        private const string SPECIFICATION =
                @"..\..\TextFiles\Specification.txt";

        /// <summary>
        /// It is an interface reference to collection of triangles.
        /// </summary>
        private ICollection<Triangle> triangles;

        /// <summary>
        /// It is an interface reference to show a result.
        /// </summary>
        private IView view;

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="TriangleSorting" /> class.
        /// It is a structure of processing with triangles.
        /// </summary>
        public TriangleSorting()
        {
            this.view = new ConsoleView();
            this.view.Dislay(File.ReadAllText(SPECIFICATION));
            this.triangles = new List<Triangle>();
        }

        /// <summary>
        /// Method to manage the program.
        /// </summary>
        public void Start()
        {
            while (true)
            {
                this.InputNewTriangle();
                if (this.IsContinue() == false)
                {
                    break;
                }
            }

            (this.triangles as List<Triangle>).Sort();
            this.view.DisplayData(this.triangles);
        }

        /// <summary>
        /// It is a method to put new triangle into a collection.
        /// </summary>
        private void InputNewTriangle()
        {
            Triangle? triangle = this.InputTriangleParams();
            if (triangle == null)
            {
                this.view.Dislay(string.Format(Resources.NoTriangleExists));
            }
            else
            {
                this.triangles.Add((Triangle)triangle);
            }
        }
    
        /// <summary>
        /// It is a method to get from user triangles parameters.
        /// </summary>
        /// <returns>Object of triangle</returns>
        private Triangle? InputTriangleParams()
        {
            while (true)
            {
                this.view.Dislay(Resources.Input);
                this.view.Dislay(Resources.TriangleFormat);
                this.view.Dislay(Resources.Divider);
                string input = this.view.ReadLine();
                if (input.Trim().ToLower() == "out")
                {
                    return null;
                }

                try
                {
                    Triangle? triangle = this.ParseInput(input);
                    if (triangle != null)
                    {
                        return triangle;
                    }
                }
                catch (ArgumentException)
                {
                    this.view.Dislay(Resources.InputNotValid);
                    continue;
                }
                catch (FormatException)
                {
                    this.view.Dislay(Resources.InputNotValid);
                    continue;
                }
                catch (OverflowException)
                {
                    this.view.Dislay(Resources.InputNotValid);
                    continue;
                }

                this.view.Dislay(Resources.InputNotValid);
            }
        }
        
        /// <summary>
        /// It is a method convert user string to object of triangle.
        /// </summary>
        /// <param name="input">User input string.</param>
        /// <returns>Object of triangle.</returns>
        private Triangle? ParseInput(string input)
        {
            string[] triangleParams = input.Split(',');
            int paramQuantity = triangleParams.Length;
            if (paramQuantity != 4)
            {
                this.view.Dislay(
                        string.Format(Resources.LessParam, paramQuantity));
                return null;
            }
            
            for (int i = 0; i < paramQuantity; i++)
            {
                triangleParams[i] = triangleParams[i].Trim().Trim('\t');
            }

            return new Triangle(
                triangleParams[0],
                double.Parse(triangleParams[1], CultureInfo.CurrentCulture),
                double.Parse(triangleParams[2], CultureInfo.CurrentCulture),
                double.Parse(triangleParams[3], CultureInfo.CurrentCulture));
        }

        /// <summary>
        /// It is a method to ask User does he like to continue.
        /// </summary>
        /// <returns>It is a User answer does he like to continue.</returns>
        private bool IsContinue()
        {
            this.view.Dislay(Resources.IsContinue);
            string userAnswer = this.view.ReadLine();
            if (userAnswer.Trim().ToLower() == "y" || 
                       userAnswer.ToLower() == "yes")
            {
                return true;
            }

            return false;
        }       
    }
}
