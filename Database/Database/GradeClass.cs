using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class GradeClass
    {
        CollegeEntities2 database;
        public GradeClass()
        {
            database = new CollegeEntities2();
        }

        public void AddNewGrade(string letterGrade)
        {
            Grade newGrade = new Grade()
            {
                Letter = letterGrade
            };

            database.Grades.Add(newGrade);
            database.SaveChanges();
        }

        public void UpdateGradeDetails(int id, string letterGrade)
        {
            //Took from https://stackoverflow.com/questions/25894587/how-to-update-record-using-entity-framework-6
            using (database)
            {
                var result = database.Grades.SingleOrDefault(c => c.Id == id);
                if (result != null)
                {
                    result.Letter = letterGrade;

                    database.SaveChanges();
                }

            }

        }

        public void DeleteGrade(int id)
        {
            var result = database.Grades.SingleOrDefault(c => c.Id == id);

            database.Grades.Remove(result);
            database.SaveChanges();

        }
    }
}
