using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database.CrudTests
{
    public class CourseCrud : GenericDatabaseCrud<Course>
    {

        public CourseCompoenent Options { get; protected set; }
        private int defaultIndexMajor = 0;
        private int defaultIndexDept = 0;

        private IList<ListboxEntry<Major>> majorSource;
        private IList<ListboxEntry<Department>> departSource;
        private IList<ListboxEntry<Department>> filterSource;

        public CourseCrud(CollegeEntities1 database, GenericFormCore core, CourseCompoenent options) : base(database, database.Courses, core)
        {

            Options = (CourseCompoenent)options;
        }

        protected override ListboxEntry<Course> NameEntry(Course course)
        {
            return new StandardListboxEntry<Course>(course, $"{course.Name}{course.Number}");
        }

        public override void BindOptionComponent()
        {
            FormCore.SubmitButton.Enabled = true;

            Options.FilterCheckBox.CheckedChanged += filterCheckChange;

            Options.NameText.Text = "";
            Options.NameText.Enabled = true;
            Options.NameText.Visible = true;

            Options.NumberText.Text = "";
            Options.NumberText.TextChanged += NumberextChanged;
            Options.NumberText.Enabled = true;
            Options.NumberText.Visible = true;

            Options.NameLabel.Enabled = true;
            Options.NameLabel.Visible = true;
            Options.NameLabel.Text = "Name";

            Options.NumberLabel.Enabled = true;
            Options.NumberLabel.Visible = true;
            Options.NumberLabel.Text = "Number";

            Options.DeparmentComboBox.Enabled = true;
            Options.DeparmentComboBox.Visible = true;
            Options.DeparmentComboBox.Text = "Deparment";

            Options.MajorComboBox.Enabled = true;
            Options.MajorComboBox.Visible = true;
            Options.MajorComboBox.Text = "Major";

            Options.FilterComboBox.Enabled = false;
            Options.FilterComboBox.Visible = true;
            Options.FilterComboBox.SelectedIndexChanged += filterbox_SelectedIndexChanged;

            Options.FilterCheckBox.Enabled = true;
            Options.FilterCheckBox.Visible = true;

            populateDepartment();
            populateMajor();
            populateFilters();
            //Default
    
            Options.MajorComboBox.SelectedIndex = defaultIndexMajor;
            Options.DeparmentComboBox.SelectedIndex = defaultIndexDept;
        }


        public override void UnbindOptionComponent()
        {

            Options.FilterCheckBox.CheckedChanged -= filterCheckChange;

            FormCore.SubmitButton.Enabled = true;
            Options.NumberText.TextChanged -= NumberextChanged;
            Options.NumberText.Text = "";
            Options.NumberText.Enabled = false;
            Options.NumberText.Visible = false;

            Options.NameText.Text = "";
            Options.NameText.Enabled = false;
            Options.NameText.Visible = false;


            Options.NameLabel.Enabled = false;
            Options.NameLabel.Visible = false;

            Options.NumberLabel.Enabled = false;
            Options.NumberLabel.Visible = false;

            Options.DeparmentComboBox.Enabled = false;
            Options.DeparmentComboBox.Visible = false;
            Options.DeparmentComboBox.DataSource = null;

            Options.MajorComboBox.Enabled = false;
            Options.MajorComboBox.Visible = false;
            Options.MajorComboBox.DataSource = null;

            Options.FilterComboBox.Enabled = false;
            Options.FilterComboBox.Visible = false;
            Options.FilterComboBox.SelectedIndexChanged -= filterbox_SelectedIndexChanged;

            Options.FilterCheckBox.Enabled = false;
            Options.FilterCheckBox.Visible = false;

        }

        public override void SelectItem(ListboxEntry<Course> item)
        {
            Course course = item.Entry;
            Options.NumberText.Text = Convert.ToString(course.Number);
            Options.NameText.Text = course.Name;

            ListboxEntry<Department> selectedDept = findDepartment(course.Department);
            ListboxEntry<Major> selectedMajor = findMajor(course.Major);
            Options.DeparmentComboBox.SelectedItem = selectedDept;
            Options.MajorComboBox.SelectedItem = selectedMajor;

        }

        public override void SubmitAdd()
        {
            int number = Convert.ToInt32(Options.NumberText.Text);
            string name = Options.NameText.Text;


            ListboxEntry<Department> selectedDept = Options.DeparmentComboBox.SelectedItem as ListboxEntry<Department>;
            int keyDept = selectedDept.Entry.Id;

            ListboxEntry<Major> selectedMajor = Options.MajorComboBox.SelectedItem as ListboxEntry<Major>;
            int keyMajor = selectedMajor.Entry.Id;


            Course course = new Course() { Name = name, Number = number, Department = keyDept, Major = keyMajor};

            Options.DeparmentComboBox.SelectedIndex = defaultIndexDept;
            Options.MajorComboBox.SelectedIndex = defaultIndexMajor;
            DataSet.Add(course);
            SaveChanges();
        }

        public override void SubmitDelete()
        {

            Course course = (Course)SelectedEntry.Entry;
            Options.NameText.Text = "";
            Options.NumberText.Text = "";

            Options.DeparmentComboBox.SelectedIndex = defaultIndexDept;
            Options.MajorComboBox.SelectedIndex = defaultIndexMajor;
            DataSet.Remove(course);
            SaveChanges();
        }

        public override void SubmitUpdate()
        {
            Course course = (Course)SelectedEntry.Entry;
            int number = Convert.ToInt32(Options.NumberText.Text);
            string name = Options.NameText.Text;


            ListboxEntry<Department> selectedDept = Options.DeparmentComboBox.SelectedItem as ListboxEntry<Department>;
            int keyDept = selectedDept.Entry.Id;

            ListboxEntry<Major> selectedMajor = Options.MajorComboBox.SelectedItem as ListboxEntry<Major>;
            int keyMajor = selectedMajor.Entry.Id;

            course.Number = number;
            course.Name = name;
            course.Department = keyDept;
            course.Major = keyMajor;
            SaveChanges();
        }


        public interface CourseCompoenent : GenericFormOptions
        {
            TextBox NameText { get; }
            TextBox NumberText { get; }


            Label NameLabel { get; }
            Label NumberLabel { get; }

            ComboBox DeparmentComboBox { get; }
            ComboBox MajorComboBox { get; }
            ComboBox FilterComboBox { get; }

            CheckBox FilterCheckBox { get; }
        }

   

        private void populateDepartment() {

            ListboxEntry<Department> convert(Department department) {
                return new StandardListboxEntry<Department>(department, department.Name);

            }



           IList<ListboxEntry<Department>> list = ConvertToEntry(Database.Departments, convert);
            departSource = list;
            Options.DeparmentComboBox.DataSource = list;
            Options.DeparmentComboBox.DisplayMember = "Name";
        }


        private void populateMajor()
        {

            ListboxEntry<Major> convert(Major major)
            {
                return new StandardListboxEntry<Major>(major, major.Name);
            }

            IList<ListboxEntry<Major>> list = ConvertToEntry(Database.Majors, convert);
            majorSource = list;
            Options.MajorComboBox.DataSource = list;
            Options.MajorComboBox.DisplayMember = "Name";
        }

        private void populateFilters()
        {
            ListboxEntry<Department> convert(Department department)
            {
                return new StandardListboxEntry<Department>(department, department.Name);
            }
            
            IList<ListboxEntry<Department>> list = ConvertToEntry(Database.Departments, convert);
            filterSource = list;
            Options.FilterComboBox.DataSource = list;
            Options.FilterComboBox.DisplayMember = "Name";
        }


        private ListboxEntry<Department> findDepartment(int key) {

    

            foreach (ListboxEntry<Department> entry in departSource)
            {
                if (entry.Entry != null)
                {

                    if (entry.Entry.Id == key) {
                        return entry;
                    }
                }
            }

            return departSource[defaultIndexMajor];
    


        }

        private ListboxEntry<Major> findMajor(int key)
        {



            foreach (ListboxEntry<Major> entry in majorSource)
            {
                if (entry.Entry != null)
                {

                    if (entry.Entry.Id == key)
                    {
                        return entry;
                    }
                }
            }

            return majorSource[defaultIndexMajor];



        }

        private void NumberextChanged(object sender, EventArgs e)
        {
            int val = 0;
            if (int.TryParse(Options.NumberText.Text, out val))
            {
                FormCore.SubmitButton.Enabled = true;
            }
            else {
                FormCore.SubmitButton.Enabled = false;
            }
        }

        private void filterCheckChange(object sender, EventArgs e)
        {
            if (Options.FilterCheckBox.Checked)
            {
                Options.FilterComboBox.Enabled = true;
                Filter = null;
                SaveChanges();
            }
            else
            {
                Options.FilterComboBox.Enabled = false;
                Filter = null;
                SaveChanges();
            }
        }


        private void filterbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListboxEntry<Department> box = Options.FilterComboBox.SelectedItem as ListboxEntry<Department>;

            if (box == null)
            {
                Filter = null;
            }
            else
            {

                Filter = (course) => {
                    int semr = box.Entry.Id;
                    return course.Entry.Department == semr;

                };

            }

            SaveChanges();
        }
    }


}
