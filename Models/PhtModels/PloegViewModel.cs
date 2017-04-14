using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PHT.Models.PhtModels
{
    public class PloegViewModel
    {
        [Key]
        [Display(Name = "Ploeg identifier")]
        public Guid Ploeg_ID { get; set; }

        [Required]
        [Display(Name = "Ploeg naam")]
        public string Naam { get; set; }

        [Required]
        [Display(Name = "Aantal pinten")]
        public int PintenAantal { get; set; }

        public string PintenPercentage {
            get
            {
                var percent = (int)Math.Round((double)(100 * PintenAantal) / 2000);
                return percent.ToString() + "%";
            }
        }

        public int PlusPinten { get; set; }

    }
}