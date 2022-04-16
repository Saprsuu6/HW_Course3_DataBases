using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThreeModels.Models
{
    public class Contacts
    {
        public Contacts() { }
        public Contacts(string email, string countryTownStreet)
        {
            Email = email;
            CountryTownStreet = countryTownStreet;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "EmailRequired"),
            RegularExpression(@"^((([0-9A-Za-z]{1}[-0-9A-z\.]{1,}[0-9A-Za-z]{1})|([0-9А-Яа-я]{1}[-0-9А-я\.]{1,}[0-9А-Яа-я]{1}))@([-A-Za-z]{1,}\.){1,2}[-A-Za-z]{2,})$", ErrorMessage = "RegexEmail"),
            MaxLength(50, ErrorMessage = "MaxLengthEmail"),
            Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "CTSRequired"),
            Display(Name = "CountryTownStreet")]
        public string CountryTownStreet { get; set; }
        [Required(ErrorMessage = "PhonesRequired"),
            Display(Name = "Phones")]
        public virtual List<Phone> Phones { get; set; }
    }
}
