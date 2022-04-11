using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Models
{
    public class MyPhone
    {
        public MyPhone() { }
        public MyPhone(string number)
        {
            Number = number;
        }

        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Number { get; set; }
    }
}
