using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInLibrary.Models
{
    [Table (Name = "Faculties")]
    internal class Faculty
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        private EntitySet<Faculty> faculties;

        [Association(Storage = "faculties", OtherKey = "IdFaculty")]
        public EntitySet<Faculty> Faculties
        {
            get { return faculties; }
            set { faculties.Assign(value); }
        }
    }
}
