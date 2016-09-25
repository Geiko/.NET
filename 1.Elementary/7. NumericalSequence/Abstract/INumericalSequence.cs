//-----------------------------------------------------------------------
// <copyright file="INumericalSequence.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace _7.NumericalSequence.Abstract
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for getting needed sequence.
    /// </summary>
    public interface INumericalSequence
    {
        /// <summary>
        /// Method for getting needed sequence.
        /// </summary>
        /// <returns>Needed sequence.</returns>
        ICollection<int> GetSequence();
    }
}
