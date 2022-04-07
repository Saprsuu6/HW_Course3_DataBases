using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Models
{
    public class MyQuest
    {
        public MyQuest() { }

        public MyQuest(string name, string photo, uint minPalyers,
            uint maxPalyers, string time, uint rating)
        {
            Name = name;
            Photo = photo;
            MinPalyers = minPalyers;
            MaxPalyers = maxPalyers;
            Time = time;
            Rating = rating;
        }

        public int Id { get; set; }
        [Required, RegularExpression(@"^[^\/:*?<>|+ ]+$",
            ErrorMessage = @"Forbidden symbols (^\/:*?<>|+)"), MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Photo { get; set; }
        [Range(1, 2, ErrorMessage = "Minimum players 1-2")]
        public uint MinPalyers { get; set; }
        [Range(50, 100, ErrorMessage = "Maximum players 50-100")]
        public uint MaxPalyers { get; set; }
        [Required, RegularExpression(@"^(?:0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$",
            ErrorMessage = @"Time format should be from 00:00 to 23:59"), MaxLength(5)]
        public string Time { get; set; }
        [Range(1, 5, ErrorMessage = "Rating from 1 to 5")]
        public uint Rating { get; set; }
    }
}
