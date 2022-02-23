using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicZ.Models
{
    class Albom
    {

        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string BandName { get; set; }

        [Required, MaxLength(50)]
        public string Publisher { get; set; }

        [Required]
        public int AmountTracks { get; set; }

        [Required, MaxLength(50)]
        public string Genre { get; set; }

        [Required]
        public int YearOfPublish { get; set; }

        [Required]
        public int YearOfAdding { get; set; }

        [Required]
        public int CostPrice { get; set; }

        [Required]
        public int PriceForSale { get; set; }

        [Required]
        public float Discount { get; set; }

        public virtual Client ReservedByClient { get; set; }
    }
}
