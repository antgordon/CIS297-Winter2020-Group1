using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class EnrollmentClass
    {
        CollegeEntities2 database;
        public EnrollmentClass()
        {
            database = new CollegeEntities2();
        }

        public void AddNewEnrollment(int personID, int semesterID, int courseID, int sectionID)
        {
            Enrollment newEnrollment = new Enrollment()
            {
                Person_ID = personID,
                Semester = semesterID,
                Course_ID = courseID,
                Section_ID = sectionID

            };

            database.Enrollments.Add(newEnrollment);
            database.SaveChanges();
        }

        public void UpdateEnrollmentDetails(int id, int personID, int semesterID, int courseID, int sectionID)
        {
            //Took from https://stackoverflow.com/questions/25894587/how-to-update-record-using-entity-framework-6
            using (database)
            {
                var result = database.Enrollments.SingleOrDefault(c => c.Id == id);
                if (result != null)
                {
                    result.Person_ID = personID;
                    result.Semester = semesterID;
                    result.Course_ID = courseID;
                    result.Section_ID = sectionID;

                    database.SaveChanges();
                }

            }

        }

        public void DeleteEnrollment(int id)
        {
            var result = database.Enrollments.SingleOrDefault(c => c.Id == id);

            database.Enrollments.Remove(result);
            database.SaveChanges();

        }
    }
}
