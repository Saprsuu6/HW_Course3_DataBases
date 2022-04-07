using System.ComponentModel.DataAnnotations;

namespace ThreeModels.Models
{
    public class Client
    {
        public Client() { }
        public Client(string name, string surename, string password)
        {
            Name = name;
            Surename = surename;
            Password = password;
        }

        public int Id { get; set; }
        [Required, RegularExpression(@"^[^\/:*?<>|+]+$",
            ErrorMessage = @"Forbidden symbols (^\/:*?<>|+)"), MaxLength(50)]
        public string Name { get; set; }
        [Required, RegularExpression(@"^[^\/:*?<>|+]+$",
            ErrorMessage = @"Forbidden symbols (^\/:*?<>|+)"), MaxLength(50)]
        public string Surename { get; set; }
        [Required, RegularExpression(@"^([a-z]+[A-Z]+[0-9]+|[a-z]+[0-9]+[A-Z]+|[A-Z]+[a-z]+[0-9]+|[A-Z]+[0-9]+[a-z]+|[0-9]+[a-z]+[A-Z]+|[0-9]+[A-Z]+[a-z]+)$",
            ErrorMessage = @"Uncorrent password. Try again"), MaxLength(50)]
        public string Password { get; set; }
    }
}
