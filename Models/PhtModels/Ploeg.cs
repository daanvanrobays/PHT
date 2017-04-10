using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PHT.Models.PhtModels
{
    public class Ploeg
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Ploeg_ID { get; set; }

        public string Naam { get; set; }

        public int PintenAantal { get; set; }
    }
}