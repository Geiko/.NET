//-----------------------------------------------------------------------
// <copyright file="PipeListViewModel.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace PipeStore.ViewModels
{
    using PipeStore.Models;
    using System.Collections.Generic;
    using System.Web.Mvc;

    /// <summary>
    /// This field represents a typed model to convey 
    /// data from a controller to a view.
    /// </summary>
    public class PipeListViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Pipe Pipe { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Pipe> Pipes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SelectList Standards { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SelectList Materials { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SelectList Manufacturers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SortInfo { get; set; }
    }
}