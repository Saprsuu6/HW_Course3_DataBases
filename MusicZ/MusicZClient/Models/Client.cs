using System;
using System.ComponentModel.DataAnnotations;

namespace MusicZClient.Models
{
    class Client
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Surename { get; set; }

        [Required, MaxLength(50)]
        public string Phone { get; set; }

        [Required, MaxLength(50)]
        public string Password { get; set; }

        [Required]
        public string Birthday { get; set; }

        [Required]
        public bool IsRegularClient { get; set; }
    }
}
