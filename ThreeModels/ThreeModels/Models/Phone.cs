using System.ComponentModel.DataAnnotations;

namespace ThreeModels.Models
{
    public class Phone
    {
        public Phone() { }
        public Phone(string number)
        {
            Number = number;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "NumberRequired"),
            MaxLength(20, ErrorMessage = "MaxLengthNumber"),
            Display(Name = "Number")]
        public string Number { get; set; }
    }
}
