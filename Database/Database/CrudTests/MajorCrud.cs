using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database.CrudTests
{
    public class MajorCrud : GenericDatabaseCrud<Major>
    {



        public MajorCompoenent Options { get; protected set; }
        private int defaultIndex = 0;
        private IList<ListboxEntry<Department>> source;

        public MajorCrud(CollegeEntities1 database, GenericFormCore core, MajorCompoenent options) : base(database, database.Majors, core)
        {

            Options = (MajorCompoenent)options;
        }

        protected override ListboxEntry<Major> NameEntry(Major major)
        {
            return new StandardListboxEntry<Major>(major, major.Name);
        }

        public override void BindOptionComponent()
        {
            Options.MajorLabel.Click += majorLabel_Click;
            Options.NameText.Text = "";
            Options.NameText.Enabled = true;
            Options.NameText.Visible = true;
            Options.MajorLabel.Enabled = true;
            Options.MajorLabel.Visible = true;
            Options.MajorLabel.Text = "Major";
            Options.DeparmentComboBox.Enabled = true;
            Options.DeparmentComboBox.Visible = true;
            Options.DeparmentComboBox.Text = "Department";
            populateDepartments();
            //Default
            source = (IList<ListboxEntry<Department>>)Options.DeparmentComboBox.DataSource;
            defaultIndex = source.Count - 1;
            Options.DeparmentComboBox.SelectedIndex = defaultIndex;
        }


        public override void UnbindOptionComponent()
        {
            Options.MajorLabel.Click -= majorLabel_Click;
            Options.NameText.Text = "";
            Options.NameText.Enabled = false;
            Options.NameText.Visible = false;
            Options.MajorLabel.Enabled = false;
            Options.MajorLabel.Visible = false;
            Options.DeparmentComboBox.Enabled = false;
            Options.DeparmentComboBox.Visible = false;
            Options.DeparmentComboBox.DataSource = null;
        }

        public override void SelectItem(ListboxEntry<Major> item)
        {
            Major majorm = item.Entry;
            Options.NameText.Text = majorm.Name == null ? "" : majorm.Name;
            Nullable<int> key = majorm.Department_Id;


            ListboxEntry<Department> selected = findDepartment(key);
            Options.DeparmentComboBox.SelectedItem = selected;
        }

        public override void SubmitAdd()
        {
            String name = Options.NameText.Text;

            Nullable<int> key = null;
            ListboxEntry<Department> selected = Options.DeparmentComboBox.SelectedItem as ListboxEntry<Department>;
            if (selected.Entry == null) {
                key = null;
            } else {
                key = selected.Entry.Id;
            }
            Major grade = new Major() { Name = name , Department_Id = key};


            Options.NameText.Text = "";
            Options.DeparmentComboBox.SelectedIndex = defaultIndex;
            DataSet.Add(grade);
            SaveChanges();
        }

        public override void SubmitDelete()
        {

            Major major = (Major)SelectedEntry.Entry;
            Options.NameText.Text = "";
            Options.DeparmentComboBox.SelectedIndex = defaultIndex;
            DataSet.Remove(major);
            SaveChanges();
        }

        public override void SubmitUpdate()
        {
            Major major = (Major)SelectedEntry.Entry;
            String name = Options.NameText.Text;
            Nullable<int> key = null;

            ListboxEntry<Department> selected = Options.DeparmentComboBox.SelectedItem as ListboxEntry<Department>;
            if (selected.Entry == null)
            {
                key = null;
            }
            else
            {
                key = selected.Entry.Id;
            }


            if (major == null)
                return;

            major.Name = name;
            major.Department_Id = key;
            SaveChanges();
        }


        public interface MajorCompoenent : GenericFormOptions
        {
            TextBox NameText { get; }
            Label MajorLabel { get; }
            ComboBox DeparmentComboBox { get; }
        }

        private void majorLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Editing Majors Boi!!");
        }

        private void populateDepartments() {

            ListboxEntry<Department> convert(Department dept) {
                return new StandardListboxEntry<Department>(dept, dept.Name);

            }

           IList<ListboxEntry<Department>> list = ConvertToEntry(Database.Departments, convert);
            list.Add(new StandardListboxEntry<Department>(null, "None"));

            Options.DeparmentComboBox.DataSource = list;
            Options.DeparmentComboBox.DisplayMember = "Name";
        }


        private ListboxEntry<Department> findDepartment(Nullable<int> key) {

            if (key.HasValue)
            {

                foreach (ListboxEntry<Department> entry in source)
                {
                    if (entry.Entry != null)
                    {

                        if (entry.Entry.Id == key.Value) {
                            return entry;
                        }
                    }
                }

                return source[defaultIndex];
     


            }
            else {

                return source[defaultIndex];

            }
        }
    }

}
