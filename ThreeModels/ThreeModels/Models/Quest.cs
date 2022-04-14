using System.ComponentModel.DataAnnotations;

namespace ThreeModels.Models
{
    public class Quest
    {
        public Quest() { }

        public Quest(string name, string photo, uint minPalyers,
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
            ErrorMessage = @"Forbidden symbols"), MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Photo { get; set; }
        [Range(1, 2, ErrorMessage = "Minimum players")]
        public uint MinPalyers { get; set; }
        [Range(50, 100, ErrorMessage = "Maximum players")]
        public uint MaxPalyers { get; set; }
        [Required, RegularExpression(@"^(?:0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$",
            ErrorMessage = @"Time format"), MaxLength(5)]
        public string Time { get; set; }
        [Range(1, 5, ErrorMessage = "Rating")]
        public uint Rating { get; set; }
    }
}
