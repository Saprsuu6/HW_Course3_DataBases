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
        [Required(ErrorMessage = "NameRequired"),
            RegularExpression(@"^[^\/:*?<>|+]+$", ErrorMessage = "RegexNameSurename"),
            MaxLength(50, ErrorMessage = "NameSurenameMaxLength"),
            Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "SurenameRequired"),
            RegularExpression(@"^[^\/:*?<>|+]+$", ErrorMessage = "RegexNameSurename"),
            MaxLength(50, ErrorMessage = "NameSurenameMaxLength"),
            Display(Name = "Surename")]
        public string Surename { get; set; }
        [Required(ErrorMessage = "PasswordRequired"),
            RegularExpression(@"^([a-z]+[A-Z]+[0-9]+|[a-z]+[0-9]+[A-Z]+|[A-Z]+[a-z]+[0-9]+|[A-Z]+[0-9]+[a-z]+|[0-9]+[a-z]+[A-Z]+|[0-9]+[A-Z]+[a-z]+)$", ErrorMessage = "RegexPassword"),
            MaxLength(50, ErrorMessage = "MaxLength"),
            Display(Name = "Password")]
        public string Password { get; set; }
    }
}
