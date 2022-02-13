using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInLibrary.Models
{
    [Table(Name = "Groups")]
    internal class Group
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "Id_Faculty")]
        public string IdFaculty { get; set; }

        private EntityRef<Faculty> faculty;

        [Association(Storage = "faculty", ThisKey = "IdFaculty")]
        public Faculty Faculty
        {
            get { return faculty.Entity; }
            set { faculty.Entity = value; }
        }

        private EntitySet<Student> students;

        [Association(Storage = "students", OtherKey = "IdGroup")]
        public EntitySet<Student> Students
        {
            get { return students; }
            set { students.Assign(value); }
        }
    }
}
