using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class MajorClass
    {
        CollegeEntities2 database;
        public MajorClass()
        {
            database = new CollegeEntities2();
        }

        public void AddNewMajor(string majorName, int departmentID)
        {
            Major newMajor = new Major()
            {
                Name = majorName,
                Department_Id = departmentID
            };

            database.Majors.Add(newMajor);
            database.SaveChanges();
        }

        public void UpdateMajorDetails(int id, string majorName, int departmentID)
        {
            //Took from https://stackoverflow.com/questions/25894587/how-to-update-record-using-entity-framework-6
            using (database)
            {
                var result = database.Majors.SingleOrDefault(c => c.Id == id);
                if (result != null)
                {
                    result.Name = majorName;
                    result.Department_Id = departmentID;

                    database.SaveChanges();
                }

            }

        }

        public void DeleteMajor(int id)
        {
            var result = database.Majors.SingleOrDefault(c => c.Id == id);

            database.Majors.Remove(result);
            database.SaveChanges();

        }

    }
}
