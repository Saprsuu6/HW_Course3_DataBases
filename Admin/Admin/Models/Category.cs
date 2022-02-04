using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Models
{
    internal class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Clone()
        {
            return new Category()
            {
                Id = Id,
                Name = Name,
            };
        }
    }
}
