using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInLibrary.Models
{
    [Table(Name = "Students")]
    internal class Student
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "FirstName")]
        public string Name { get; set; }

        [Column(Name = "LastName")]
        public string Surename { get; set; }

        [Column(Name = "Id_Group")]
        public string IdGroup { get; set; }

        private EntityRef<Group> group;

        [Association(Storage = "group", ThisKey = "IdGroup")]
        public Group Group
        {
            get { return group.Entity; }
            set { group.Entity = value; }
        }
    }
}
