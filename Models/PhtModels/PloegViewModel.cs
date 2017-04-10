using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PHT.Models.PhtModels
{
    public class PloegViewModel
    {
        [Required]
        [Display(Name = "Ploeg naam")]
        [DataType(DataType.Text)]
        public string Naam { get; set; }

        [Required]
        [DataType(DataType.Custom)]
        [Display(Name = "Aantal pinten")]
        public int PintenAantal { get; set; }
    }
}