using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseAntony.CrudTests
{
    public class PersonCrud : GenericDatabaseCrud<Person>
    {



        public PersonComponent Options { get; protected set; }

        public PersonCrud(dboEntities1 database, GenericFormCore core, PersonComponent options) : base(database, database.People, core)
        {

            Options = (PersonComponent)options;
        }

        protected override ListboxEntry<Person> NameEntry(Person person)
        {
            return new PersonListboxEntry(person);
        }

        public override void BindOptionComponent()
        {
            Options.PersonLabel.Click += personLabel_Click;
            Options.NameText.Text = "";
            Options.NameText.Enabled = true;
            Options.NameText.Visible = true;
            Options.PersonLabel.Enabled = true;
            Options.PersonLabel.Visible = true;
            Options.EmailText.Enabled = true;
            Options.EmailText.Visible = true;

            Options.NumberText.Enabled = true;
            Options.NumberText.Visible = true;

            Options.StudentCheck.Enabled = true;
            Options.StudentCheck.Visible = true;
            Options.StudentCheck.Text = "Student";

            Options.FacultyCheck.Enabled = true;
            Options.FacultyCheck.Visible = true;
            Options.FacultyCheck.Text = " Faculty";

            Options.FacultyListbox.Enabled = true;
            Options.FacultyListbox.Visible = true;
            Options.FacultyListbox.Text = " Faculty List";
            Options.FacultyListbox.DisplayMember = "Name";

            Options.StudentListbox.Enabled = true;
            Options.StudentListbox.Visible = true;
            Options.StudentListbox.Text = "Student List";
            Options.StudentListbox.DisplayMember = "Name";
        }

        public override void UnbindOptionComponent()
        {
            Options.PersonLabel.Click -= personLabel_Click;
            Options.NameText.Text = "";
            Options.NameText.Enabled = false;
            Options.NameText.Visible = false;
            Options.PersonLabel.Enabled = false;
            Options.PersonLabel.Visible = false;
            Options.EmailText.Enabled = false;
            Options.EmailText.Visible = false;

            Options.NumberText.Enabled = false;
            Options.NumberText.Visible = false;

            Options.StudentCheck.Enabled = false;
            Options.StudentCheck.Visible = false;

            Options.FacultyCheck.Enabled = false;
            Options.FacultyCheck.Visible = false;

            Options.FacultyListbox.Enabled = false;
            Options.FacultyListbox.Visible = false;

            Options.StudentListbox.Enabled = false;
            Options.StudentListbox.Visible = false;

        }


        public override void SelectItem(ListboxEntry<Person> item)
        {
            PersonListboxEntry pEntry = item as PersonListboxEntry;
            Person person = item.Entry;

            Options.NameText.Text = person.Name == null ? "" : person.Name;
            Options.EmailText.Text = person.Email == null ? "" : person.Email;
            Options.NumberText.Text = person.Number == null ? "" : person.Number;
            Options.StudentCheck.Checked = pEntry.isStudent;
            Options.FacultyCheck.Checked = pEntry.isFaculty;
        }

        public override void SubmitAdd()
        {
            String name = Options.NameText.Text;
            Options.NameText.Text = "";

            String email = Options.EmailText.Text;
            Options.EmailText.Text = "";

            String number = Options.NumberText.Text;
            Options.NumberText.Text = "";

            Person person = new Person() { Name = name, Email = email, Number = number };
            DataSet.Add(person);
            SaveChanges();

            if (Options.FacultyCheck.Checked) {
                Faculty faculty = new Faculty() { Person_Id = person.Id };
                Database.Faculties.Add(faculty);
            }

            if (Options.StudentCheck.Checked)
            {
                Student student = new Student() { Person_Id = person.Id };
                Database.Students.Add(student);
            }

            SaveChanges();
        }

        public override void SubmitDelete()
        {

            Person person = (Person)SelectedEntry.Entry;
            Options.NameText.Text = "";
            Options.EmailText.Text = "";
            Options.NumberText.Text = "";
            Database.Faculties.RemoveRange(person.Faculties.AsEnumerable());
            Database.Students.RemoveRange(person.Students.AsEnumerable());
            DataSet.Remove(person);
            SaveChanges();
        }

        public override void SubmitUpdate()
        {
            PersonListboxEntry pEntry = SelectedEntry as PersonListboxEntry;

            Person person = pEntry.Entry;
            person.Name = Options.NameText.Text;
            person.Email = Options.EmailText.Text;
            person.Number = Options.NumberText.Text;
            SaveChanges();

            if (Options.FacultyCheck.Checked)
            {
                if (!pEntry.isFaculty) {
                    Faculty faculty = new Faculty() { Person_Id = person.Id };
                    Database.Faculties.Add(faculty);
                }
            }
            else {
                if (pEntry.isFaculty)
                {
                    Database.Faculties.RemoveRange(person.Faculties.AsEnumerable());
                }
            }

            if (Options.StudentCheck.Checked)
            {
                if (!pEntry.isStudent)
                {
                    Student student = new Student() { Person_Id = person.Id };
                    Database.Students.Add(student);
                }
            }
            else
            {
                if (pEntry.isStudent)
                {
                    Database.Students.RemoveRange(person.Students.AsEnumerable());
                }
            }




            SaveChanges();
        }


        public interface PersonComponent : GenericFormOptions
        {
            TextBox NameText { get; }

            TextBox EmailText { get; }

            TextBox NumberText { get; }

            CheckBox StudentCheck { get; }

            CheckBox FacultyCheck { get; }

            ListBox StudentListbox { get; }

            ListBox FacultyListbox { get; }

            Label PersonLabel { get; }


        }

        private void personLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Editing People Yay!!");
        }

        private class PersonListboxEntry : StandardListboxEntry<Person>
        {

            public Faculty FacultyStatus { get; }
            public Student StudentStatus { get; }

            public bool isFaculty { get;}
            public bool isStudent { get;}

            public PersonListboxEntry(Person entry) : base(entry, entry.Name)
            {

                isFaculty = entry.Faculties.Count > 0;
                if (isFaculty) {
                    FacultyStatus = entry.Faculties.Where(fac => fac.Person_Id == entry.Id).First();

                }

                isStudent = entry.Students.Count > 0;
                if (isStudent)
                {
                    StudentStatus = entry.Students.Where(stud => stud.Person_Id == entry.Id).First();

                }

            }
        }

        public override void SaveChanges()
        {
            base.SaveChanges();
            Database.SaveChanges();
      
            Options.FacultyListbox.DataSource = ConvertToEntry<Faculty>(Database.Faculties,
                entry => new StandardListboxEntry<Faculty>(entry, entry.Person.Name));

            Options.StudentListbox.DataSource = ConvertToEntry<Student>(Database.Students,
                      entry => new StandardListboxEntry<Student>(entry, entry.Person.Name));
        }

       
    }

}
