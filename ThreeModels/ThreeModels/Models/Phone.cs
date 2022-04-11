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
        [Required, MaxLength(20)]
        public string Number { get; set; }
    }
}
