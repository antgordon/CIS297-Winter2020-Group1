using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class DepartmentClass
    {
        CollegeEntities2 database;
        public DepartmentClass()
        {
            database = new CollegeEntities2();
        }

        public void AddNewDepartment(string departmentName)
        {
            Department newDepartment = new Department()
            {
                Name = departmentName
            };

            database.Departments.Add(newDepartment);
            database.SaveChanges();
        }

        public void UpdateDepartmentDetails(int id, string departmentName)
        {
            //Took from https://stackoverflow.com/questions/25894587/how-to-update-record-using-entity-framework-6
            using (database)
            {
                var result = database.Departments.SingleOrDefault(c => c.Id == id);
                if (result != null)
                {
                    result.Name = departmentName;

                    database.SaveChanges();
                }

            }

        }

        public void DeleteDepartment(int id)
        {
            var result = database.Departments.SingleOrDefault(c => c.Id == id);

            database.Departments.Remove(result);
            database.SaveChanges();

        }
    }
}
