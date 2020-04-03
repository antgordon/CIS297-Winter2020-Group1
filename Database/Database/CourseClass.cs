using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public partial class CourseClass
    {
        CollegeEntities1 database;
        public CourseClass()
        {
            database = new CollegeEntities1();
        }

        public void AddNewCourse(int department, int major, int number, string name)
        {
            Course newCourse = new Course()
            {
                Department = department,
                Major = major,
                Number = number,
                Name = name
            };

            database.Courses.Add(newCourse);
            database.SaveChanges();
        }

        public void UpdateCourseDetails(int id, int department, int major, int number, string name)
        {
            //Took from https://stackoverflow.com/questions/25894587/how-to-update-record-using-entity-framework-6
            using (database)
            {
                var result = database.Courses.SingleOrDefault(c => c.Id == id);
                if (result != null)
                {
                    result.Department = department;
                    result.Major = major;
                    result.Number = number;
                    result.Name = name;

                    database.SaveChanges();
                }

            }

        }

        public void DeleteCourse(int id)
        {
            var result = database.Courses.SingleOrDefault(c => c.Id == id);

            database.Courses.Remove(result);
            database.SaveChanges();

        }


    }


}
