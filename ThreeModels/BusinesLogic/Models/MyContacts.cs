using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Models
{
    public class MyContacts
    {
        public MyContacts() { }
        public MyContacts(string email, string countryTownStreet)
        {
            Email = email;
            CountryTownStreet = countryTownStreet;
        }

        public int Id { get; set; }
        [Required, RegularExpression(@"^((([0-9A-Za-z]{1}[-0-9A-z\.]{1,}[0-9A-Za-z]{1})|([0-9А-Яа-я]{1}[-0-9А-я\.]{1,}[0-9А-Яа-я]{1}))@([-A-Za-z]{1,}\.){1,2}[-A-Za-z]{2,})$",
            ErrorMessage = @"Not corrent format.")]
        public string Email { get; set; }
        [Required(ErrorMessage = @"Not corrent format. Example: (Ukraina\Kiev\Mira-24)")]
        public string CountryTownStreet { get; set; }
        [Required]
        public virtual List<MyPhone> Phones { get; set; }
    }
}
