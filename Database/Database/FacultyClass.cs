using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class FacultyClass
    {
        CollegeEntities2 database;
        public FacultyClass()
        {
            database = new CollegeEntities2();
        }

        public void AddNewFaculty(int personID)
        {
            Faculty newFaculty = new Faculty()
            {
                Person_Id = personID
            };

            database.Faculties.Add(newFaculty);
            database.SaveChanges();
        }

        public void UpdateFacultyDetails(int id, int personID)
        {
            //Took from https://stackoverflow.com/questions/25894587/how-to-update-record-using-entity-framework-6
            using (database)
            {
                var result = database.Faculties.SingleOrDefault(c => c.Id == id);
                if (result != null)
                {
                    result.Person_Id = personID;

                    database.SaveChanges();
                }

            }

        }

        public void DeleteFaculty(int id)
        {
            var result = database.Faculties.SingleOrDefault(c => c.Id == id);

            database.Faculties.Remove(result);
            database.SaveChanges();

        }
    }
}
