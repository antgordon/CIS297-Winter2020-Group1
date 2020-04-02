using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database.CrudTests
{
    public class PersonCrud : GenericDatabaseCrud<Person>
    {



        public PersonComponent Options { get; protected set; }

        public PersonCrud(CollegeEntities database, GenericFormCore core, PersonComponent options) : base(database, database.People, core)
        {

            Options = (PersonComponent)options;
        }

        protected override ListboxEntry<Person> NameEntry(Person person)
        {
            return new StandardListboxEntry<Person>(person, person.Name);
        }

        public override void BindOptionComponent()
        {
        
            Options.NameText.Text = "";
            Options.NameText.Enabled = true;
            Options.NameText.Visible = true;

            Options.EmailText.Text = "";
            Options.EmailText.Enabled = true;
            Options.EmailText.Visible = true;

            Options.NumberText.Text = "";
            Options.NumberText.Enabled = true;
            Options.NumberText.Visible = true;

            Options.NameLabel.Text = "Name";
            Options.NameLabel.Enabled = true;
            Options.NameLabel.Visible = true;

            Options.EmailLabel.Text = "Email";
            Options.EmailLabel.Enabled = true;
            Options.EmailLabel.Visible = true;

            Options.NumberLabel.Text = "Number";
            Options.NumberLabel.Enabled = true;
            Options.NumberLabel.Visible = true;

          

        }

        public override void UnbindOptionComponent()
        {
     
            Options.NameText.Text = "";
            Options.NameText.Enabled = false;
            Options.NameText.Visible = false;
            Options.NameLabel.Enabled = false;
            Options.NameLabel.Visible = false;
            Options.EmailLabel.Enabled = false;
            Options.EmailLabel.Visible = false;
            Options.NumberLabel.Enabled = false;
            Options.NumberLabel.Visible = false;

            Options.EmailText.Enabled = false;
            Options.EmailText.Visible = false;

            Options.NumberText.Enabled = false;
            Options.NumberText.Visible = false;


        }


        public override void SelectItem(ListboxEntry<Person> item)
        {
         
            Person person = item.Entry;

            Options.NameText.Text = person.Name == null ? "" : person.Name;
            Options.EmailText.Text = person.Email == null ? "" : person.Email;
            Options.NumberText.Text = person.Number == null ? "" : person.Number;
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

        }

        public override void SubmitDelete()
        {

            Person person = (Person)SelectedEntry.Entry;
            Options.NameText.Text = "";
            Options.EmailText.Text = "";
            Options.NumberText.Text = "";
            DataSet.Remove(person);
            SaveChanges();
        }

        public override void SubmitUpdate()
        {
            ListboxEntry<Person> pEntry = SelectedEntry;

            Person person = pEntry.Entry;
            person.Name = Options.NameText.Text;
            person.Email = Options.EmailText.Text;
            person.Number = Options.NumberText.Text;
            SaveChanges();
        }

      


        public interface PersonComponent : GenericFormOptions
        {
            TextBox NameText { get; }

            TextBox EmailText { get; }

            TextBox NumberText { get; }

    

            Label NameLabel { get; }

            Label EmailLabel { get; }

            Label NumberLabel { get; }


        }

        private void personLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Editing People Yay!!");
        }

   
      

       
    }

}
