using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithDB.Models
{
    public class Phone
    {
        public Phone() { }
        public Phone(string number, Contact contact)
        {
            Number = number;
            Contact = contact;
        }

        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Number { get; set; }
        [Required]
        public virtual Contact Contact { get; set; }
    }
}
