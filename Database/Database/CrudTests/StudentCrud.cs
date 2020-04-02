using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database.CrudTests
{
    public class StudentCrud : GenericDatabaseCrud<Student>
    {



        public StudentCompoenent Options { get; protected set; }
        private int defaultIndex = 0;
        private IList<ListboxEntry<Person>> source;

        public StudentCrud(CollegeEntities database, GenericFormCore core, StudentCompoenent options) : base(database, database.Students, core)
        {

            Options = (StudentCompoenent)options;
        }

        protected override ListboxEntry<Student> NameEntry(Student student)
        {
            return new StandardListboxEntry<Student>(student, student.Person.Name);
        }

        public override void BindOptionComponent()
        {
            FormCore.SubmitButton.Enabled = true;
           

       
            Options.SemesterLabel.Enabled = true;
            Options.SemesterLabel.Visible = true;
            Options.SemesterLabel.Text = "Person";
            Options.PersonComboBox.Enabled = true;
            Options.PersonComboBox.Visible = true;
            Options.PersonComboBox.Text = "People";

            populateSeasons();
            //Default
            Options.PersonComboBox.DataSource = source;
            Options.PersonComboBox.SelectedIndex = defaultIndex;
        }


        public override void UnbindOptionComponent()
        {
            FormCore.SubmitButton.Enabled = true;

            Options.SemesterLabel.Enabled = false;
            Options.SemesterLabel.Visible = false;
            Options.PersonComboBox.Enabled = false;
            Options.PersonComboBox.Visible = false;
            Options.PersonComboBox.DataSource = null;
        }

        public override void SelectItem(ListboxEntry<Student> item)
        {
            Student student = item.Entry;

            ListboxEntry<Person> selected = findPerson(student.Person_Id);
            Options.PersonComboBox.SelectedItem = selected;
        }

        public override void SubmitAdd()
        {
      

            ListboxEntry<Person> selected = Options.PersonComboBox.SelectedItem as ListboxEntry<Person>;
            int key = selected.Entry.Id;

            Student semester = new Student() { Person_Id = key};


  
            Options.PersonComboBox.SelectedIndex = defaultIndex;
            DataSet.Add(semester);
            SaveChanges();
        }

        public override void SubmitDelete()
        {

            Student student = (Student)SelectedEntry.Entry;
      
            Options.PersonComboBox.SelectedIndex = defaultIndex;
            DataSet.Remove(student);
            SaveChanges();
        }

        public override void SubmitUpdate()
        {
            Student student = (Student)SelectedEntry.Entry;



            ListboxEntry<Person> selected = findPerson(student.Person_Id) ;
            student.Person_Id = selected.Entry.Id;
            SaveChanges();
        }


        public interface StudentCompoenent : GenericFormOptions
        {
        
            Label SemesterLabel { get; }
            ComboBox PersonComboBox { get; }
        }

        private void semesterLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Editing Seasons Boi!!");
        }

        private void populateSeasons() {

            ListboxEntry<Person> convert(Person person) {
                return new StandardListboxEntry<Person>(person, person.Name);

            }

           IList<ListboxEntry<Person>> list = ConvertToEntry(Database.People, convert);
            source = list;
            Options.PersonComboBox.DataSource = list;
            Options.PersonComboBox.DisplayMember = "Name";
        }


        private ListboxEntry<Person> findPerson(int key) {

    

        foreach (ListboxEntry<Person> entry in source)
        {
            if (entry.Entry != null)
            {

                if (entry.Entry.Id == key) {
                    return entry;
                }
            }
        }

        return source[defaultIndex];
     


        }


      
    }


}
