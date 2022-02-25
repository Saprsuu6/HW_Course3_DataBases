using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicZ.Models
{
    class Check
    {
        public int Id { get; set; }

        [Required]
        public virtual Albom Id_Albom { get; set; }

        [Required]
        public virtual Client Id_Client { get; set; }

        public virtual Stuff Id_Stuff { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public virtual int AmountAlboms { get; set; }
    }
}
