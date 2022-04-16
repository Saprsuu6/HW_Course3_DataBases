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
        [Required(ErrorMessage = "NameRequired"),
            RegularExpression(@"^[^\/:*?<>|+ ]+$", ErrorMessage = "RegexName"),
            MaxLength(50, ErrorMessage = "MaxLengthName"),
            Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "PhotoRequired")]
        public string Photo { get; set; }
        [Required(ErrorMessage = "RangeMinRequired"), 
            Range(1, 2, ErrorMessage = "RangeMin"),
            Display(Name = "MinPalyers")]
        public uint MinPalyers { get; set; }
        [Required(ErrorMessage = "RangeMaxRequired"), 
            Range(50, 100, ErrorMessage = "RangeMax"),
            Display(Name = "MaxPalyers")]
        public uint MaxPalyers { get; set; }
        [Required(ErrorMessage = "TimeRequited"),
            RegularExpression(@"^(?:0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "RegexTime"),
            MaxLength(4, ErrorMessage = "MaxLengthTime"),
            Display(Name = "Time")]
        public string Time { get; set; }
        [Required(ErrorMessage = "RatingRequired"), 
            Range(1, 5, ErrorMessage = "RangeRating"),
            Display(Name = "Rating")]
        public uint Rating { get; set; }
    }
}
