using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    internal class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Pages { get; set; }

        [Required]
        public int YearPress { get; set; }

        [StringLength(50)]
        public string Comment { get; set; }

        [Required]
        public int Quantity { get; set; }

        public virtual Author Author { get; set; }
        public virtual Press Press { get; set; }
        public virtual Category Category { get; set; }
        public virtual Theme Theme { get; set; }
    }
}
