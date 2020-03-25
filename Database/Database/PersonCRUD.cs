using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    partial class PersonCRUD
    {
        /*CurrentPeopleListBox.DataSource = database.People.ToList();
            CurrentPeopleListBox.DisplayMember = "Name";
            CurrentPeopleListBox.ValueMember = "Id";
            */
        public void AddNewFaculty()
        {
            //string name = $"{FirstName_TextBox} {LastName_TextBox}";
            Person newPerson = new Person()
            {
              /*  Name = Name_TextBox.Text,
                Number = Phone_TextBox.Text,
                Email = Email_TextBox.Text*/
            };
            Faculty faculty = new Faculty();
            faculty.Person_Id = newPerson.Id;

        }

        public void AddNewStudent()
        {
            //string name = $"{FirstNameTextBox} {LastNameTextBox}";
            Person newPerson = new Person()
            {
              /*  Name = Name_TextBox.Text,
                Email = EmailTextBox.Text,
                Number = PhoneTextBox.Text */
            };
            Student student = new Student();
            student.Person_Id = newPerson.Id;

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            /*if (FacultyRadioButton.Checked)
            {
                AddNewFaculty();
            }
            else if (StudentRadioButton.Checked)
            {
                AddNewStudent();
            }*/
        }
    }
}
