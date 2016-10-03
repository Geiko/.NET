using LPipe.Domain.MaterialsAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LPipe.UI.Areas.Mvc.ViewModels.Materials
{
    public class MaterialViewModel
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 1)]
        private string name;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Material Name is not valid.");
                }

                name = value;
            }
        }



        public static MaterialViewModel Map(Material material)
        {
            var materialViewModel = new MaterialViewModel
            {
                Id = material.Id,
                Name = material.Name
            };

            return materialViewModel;
        }



        public Material ToDomain()
        {
            Material domainMaterial = new Material
            {
                Id = this.Id,
                Name = this.Name
            };
            return domainMaterial;
        }  
    }
}