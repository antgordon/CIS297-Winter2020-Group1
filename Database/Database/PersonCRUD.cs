using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    partial class PersonCRUD
    {
        CollegeEntities1 database = new CollegeEntities1();
               
        /*Written so
         * Name_TextBox = Option1
         * Phone_TextBox = Option2
         * Email_TextBox = Option3
         */
        //for easy renaming uncomment the lines below
        //string Option1_TextBox, Option2_TextBox, Option3_TextBox;
        //bool FacultySelected, StudentSelected;
        
        //Create Faculty Person
        public void AddNewFaculty()
        {
            //string name = $"{FirstName_TextBox} {LastName_TextBox}";
            Person newPerson = new Person()
            {
                Name = Option1_TextBox.Text,
                Phone = Option2_TextBox.Text,
                Email = Option3_TextBox.Text
            };
            Faculty faculty = new Faculty();
            faculty.Person_Id = newPerson.Id;

        }

        //Create Student Person
        public void AddNewStudent()
        {
            //string name = $"{FirstNameTextBox} {LastNameTextBox}";
            Person newPerson = new Person()
            {
                Name = Option1_TextBox.Text,
                Email = Option3_TextBox.Text,
                Phone = Option2_TextBox.Text
            };
            Student student = new Student();
            student.Person_Id = newPerson.Id;

        }

        private void AddButton_Click(object sender, EventArgs e)
        {/*
            if (FacultySelected.Checked)
            {
                AddNewFaculty();
            }
            else if (StudentSelected.Checked)
            {
                AddNewStudent();
            }
            database.SaveChanges();*/
        }

        //Update Faculty Person
        public void UpdateFaculty(int personId)
        {
            Person person = database.People.Find(personId);
            //uncomment below after textboxes are named
            /*
            person.Name = Option1_TextBox.Text;
            person.Phone = Option2_TextBox.Text;
            person.Email = Option3_TextBox.Text;
            */
        }

        //Update Student Person
        public void UpdateStudent(int personId)
        {
            /*
            Person person = database.People.Find(personId);
            person.Name = Option1_TextBox.Text;
            person.Phone = Option2_TextBox.Text;
            person.Email = Option3_TextBox.Text;
            */
            database.SaveChanges();
        }

        //Delete Faculty Person
        public void DeleteFaculty(int personId) 
        {
            /*
            Person person = database.People.Find(personId);
            int facultyID = database.Faculties.Find(personId).Id;
            database.People.Remove(person);
            Faculty faculty = database.Faculties.Find(facultyID);
            database.Faculties.Remove(faculty);
            */
            database.SaveChanges();
        }

        //Delete Student Person
        public void DeleteStudent(int personId)
        {
            Person person = database.People.Find(personId);
            int studentID = database.Students.Find(personId).Id;
            database.People.Remove(person);
            Student student = database.Students.Find(studentID);
            database.Students.Remove(student);
            database.SaveChanges();
        }
    }
}
