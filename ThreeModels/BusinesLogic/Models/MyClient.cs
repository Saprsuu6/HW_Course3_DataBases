using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Models
{
    public class MyClient
    {
        public MyClient() { }
        public MyClient(string name, string surename, string password)
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
