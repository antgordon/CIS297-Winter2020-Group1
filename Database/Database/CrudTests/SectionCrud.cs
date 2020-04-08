using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Database.CrudTests
{
    public class SectionCrud : GenericDatabaseCrud<Section>
    {
        public SectionComponent Options { get; protected set; }
        private IList<ListboxEntry<Faculty>> falcultySource;
        private IList<ListboxEntry<Semester>> semesterSource;
        private IList<ListboxEntry<Course>> courseSource;
        private IList<ListboxEntry<Semester>> filterSource;

        private int defaultIndex = 0;


        public SectionCrud(CollegeEntities1 database, GenericFormCore core, SectionComponent options) : base(database, database.Sections,core)
        {
            Options = options;
        }

        public override void BindOptionComponent()
        {
            Options.FilterCheckBox.CheckedChanged += filterCheckChange;

            FormCore.SubmitButton.Enabled = true;

            Options.FacultyLabel.Text = "Section";
            Options.FacultyLabel.Enabled = true;
            Options.FacultyLabel.Visible = true;

            Options.SectionNameText.Text = "Section";
            Options.SectionNameText.Enabled = true;
            Options.SectionNameText.Visible = true;

            Options.FacultyComboBox.Enabled = true;
            Options.FacultyComboBox.Visible = true;
            //Options.PersonComboBox.Text = "Person";

            Options.SemesterLabel.Text = "Semester";
            Options.SemesterLabel.Enabled = true;
            Options.SemesterLabel.Visible = true;

            Options.SemesterComboBox.Enabled = true;
            Options.SemesterComboBox.Visible = true;
            //Options.SemesterComboBox.Text = "Semester";

            Options.CourseLabel.Text = "Course";
            Options.CourseLabel.Enabled = true;
            Options.CourseLabel.Visible = true;

            Options.CourseComboBox.Enabled = true;
            Options.CourseComboBox.Visible = true;

            Options.FilterComboBox.Enabled = false;
            Options.FilterComboBox.Visible = true;
            Options.FilterComboBox.SelectedIndexChanged += filterbox_SelectedIndexChanged;

            Options.FilterCheckBox.Enabled = true;
            Options.FilterCheckBox.Visible = true;

            populateComboBoxes();

            Options.FacultyComboBox.SelectedItem = defaultIndex;
            Options.CourseComboBox.SelectedItem = defaultIndex;
            Options.SemesterComboBox.SelectedItem = defaultIndex;
            Options.FilterComboBox.SelectedItem = defaultIndex;
        }

        public override void UnbindOptionComponent()
        {
            Options.FilterCheckBox.CheckedChanged -= filterCheckChange;

            Options.FacultyLabel.Text = "";
            Options.FacultyLabel.Enabled = false;
            Options.FacultyLabel.Visible = false;

            Options.FacultyComboBox.Enabled = false;
            Options.FacultyComboBox.Visible = false;
            Options.FacultyComboBox.Text = "";

            Options.SemesterLabel.Text = "";
            Options.SemesterLabel.Enabled = false;
            Options.SemesterLabel.Visible = false;

            Options.SemesterComboBox.Enabled = false;
            Options.SemesterComboBox.Visible = false;
            Options.SemesterComboBox.Text = "";

            Options.CourseLabel.Text = "";
            Options.CourseLabel.Enabled = false;
            Options.CourseLabel.Visible = false;

            Options.CourseComboBox.Enabled = false;
            Options.CourseComboBox.Visible = false;
            Options.CourseComboBox.Text = "";

            Options.SectionNameText.Text = "";
            Options.SectionNameText.Enabled = false;
            Options.SectionNameText.Visible = false;

            Options.FilterComboBox.Enabled = false;
            Options.FilterComboBox.Visible = false;
            Options.FilterComboBox.DataSource = null;
            Options.FilterComboBox.SelectedIndexChanged -= filterbox_SelectedIndexChanged;

            Options.FilterCheckBox.Enabled = false;
            Options.FilterCheckBox.Visible = false;
            Options.FilterCheckBox.Checked = false;

        }

        public override void SelectItem(ListboxEntry<Section> item)
        {
            Section section = item.Entry;

            Options.SectionNameText.Text = section.Name;

            ListboxEntry<Faculty> selectedSection = findFaculty(section.Faculty_ID);
            Options.FacultyComboBox.SelectedItem = selectedSection;

            ListboxEntry<Semester> selectedSemester = findSemesters(section.Semester_ID);
            Options.SemesterComboBox.SelectedItem = selectedSemester;

            ListboxEntry<Course> selectedCourse = findCourses(section.Course_ID);
            Options.CourseComboBox.SelectedItem = selectedCourse;
        }

        public override void SubmitAdd()
        {
            ListboxEntry<Faculty> selectedFaculty = Options.FacultyComboBox.SelectedItem as ListboxEntry<Faculty>;
            int personKey = selectedFaculty.Entry.Id;

            ListboxEntry<Course> selectedCourse = Options.CourseComboBox.SelectedItem as ListboxEntry<Course>;
            int courseKey = selectedCourse.Entry.Id;

            ListboxEntry<Semester> selectedSemester = Options.SemesterComboBox.SelectedItem as ListboxEntry<Semester>;
            int semesterKey = selectedSemester.Entry.Id;

            string name = Options.SectionNameText.Text;


            Section section = new Section()
            {
                Name = name,
                Faculty_ID = personKey,
                Semester_ID = semesterKey,
                Course_ID = courseKey
            };

            Options.FacultyComboBox.SelectedItem = defaultIndex;
            Options.CourseComboBox.SelectedItem = defaultIndex;
            Options.SemesterComboBox.SelectedItem = defaultIndex;
    
            DataSet.Add(section);
            SaveChanges();

        }

        public override void SubmitDelete()
        {
            Section section = (Section)SelectedEntry.Entry;
            Options.FacultyComboBox.SelectedItem = defaultIndex;
            Options.CourseComboBox.SelectedItem = defaultIndex;
            Options.SemesterComboBox.SelectedItem = defaultIndex;
            Options.SectionNameText.Text = "";
            DataSet.Remove(section);
            SaveChanges();
        }

        public override void SubmitUpdate()
        {
            Section section = (Section)SelectedEntry.Entry;

            ListboxEntry<Faculty> selectedFaculty = findFaculty(section.Faculty_ID);
            ListboxEntry<Semester> selectedSemester = findSemesters(section.Semester_ID);
            ListboxEntry<Course> selectedCourse = findCourses(section.Course_ID);

            section.Name = Options.SectionNameText.Text;
            section.Faculty_ID = selectedFaculty.Entry.Id;
            section.Semester_ID = selectedSemester.Entry.Id;
            section.Course_ID = selectedCourse.Entry.Id;
         

            SaveChanges();
        }



        protected override ListboxEntry<Section> NameEntry(Section section)
        {
            return new StandardListboxEntry<Section>(section,
                $"{section.Course.Name} {section.Course.Number} {section.Name} {section.Semester.Season1.Name} {section.Semester.Year}");
        }

        public interface SectionComponent : GenericFormOptions
        {
            ComboBox FacultyComboBox { get; }
            ComboBox SemesterComboBox { get; }
            ComboBox CourseComboBox { get; }
            ComboBox FilterComboBox { get; }
            TextBox SectionNameText { get; }

            Label FacultyLabel { get; }
            Label SemesterLabel { get; }
            Label CourseLabel { get; }
            CheckBox FilterCheckBox { get; }
        }

        private void populateComboBoxes()
        {
            ListboxEntry<Faculty> convertFaculty(Faculty faculty)
            {
                return new StandardListboxEntry<Faculty>(faculty, faculty.Person.Name);
            }

            ListboxEntry<Semester> convertSemester(Semester semester)
            {
                return new StandardListboxEntry<Semester>(semester, $"{semester.Season1.Name} {semester.Year}");
            }

            ListboxEntry<Course> convertCourse(Course course)
            {
                return new StandardListboxEntry<Course>(course, $"{course.Name} {course.Number}");
            }

        

            IList<ListboxEntry<Faculty>> facultyList = ConvertToEntry(Database.Faculties, convertFaculty);
            falcultySource = facultyList;
            Options.FacultyComboBox.DataSource = facultyList;
            Options.FacultyComboBox.DisplayMember = "Name";

            IList<ListboxEntry<Semester>> semesterList = ConvertToEntry(Database.Semesters, convertSemester);
            semesterSource = semesterList;
            Options.SemesterComboBox.DataSource = semesterList;
            Options.SemesterComboBox.DisplayMember = "Name";

            IList<ListboxEntry<Course>> courseList = ConvertToEntry(Database.Courses, convertCourse);
            courseSource = courseList;
            Options.CourseComboBox.DataSource = courseList;
            Options.CourseComboBox.DisplayMember = "Name";

            IList<ListboxEntry<Semester>> filterList = ConvertToEntry(Database.Semesters, convertSemester);
            filterSource = filterList;
            Options.FilterComboBox.DataSource = filterList;
            Options.FilterComboBox.DisplayMember = "Name";
        }

        private ListboxEntry<Faculty> findFaculty(int key)
        {
            foreach (ListboxEntry<Faculty> entry in falcultySource)
            {
                if (entry.Entry != null)
                {
                    if (entry.Entry.Id == key)
                    {
                        return entry;
                    }
                }
            }

            return falcultySource[defaultIndex];
        }

        private ListboxEntry<Semester> findSemesters(int key)
        {
            foreach (ListboxEntry<Semester> entry in semesterSource)
            {
                if (entry.Entry != null)
                {
                    if (entry.Entry.Id == key)
                    {
                        return entry;
                    }
                }
            }

            return semesterSource[defaultIndex];
        }

        private ListboxEntry<Course> findCourses(int key)
        {
            foreach (ListboxEntry<Course> entry in courseSource)
            {
                if (entry.Entry != null)
                {
                    if (entry.Entry.Id == key)
                    {
                        return entry;
                    }
                }
            }

            return courseSource[defaultIndex];
        }

        private void filterCheckChange(object sender, EventArgs e)
        {
            if (Options.FilterCheckBox.Checked)
            {
                Options.FilterComboBox.Enabled = true;
                Filter = generateFilter();
                SaveChanges();
            }
            else
            {
                Options.FilterComboBox.Enabled = false;
                Filter = null;
                SaveChanges();
            }
        }


    


        private Func<ListboxEntry<Section>, bool> generateFilter()
        {

            ListboxEntry<Semester> box = Options.FilterComboBox.SelectedItem as ListboxEntry<Semester>;

            if (box == null)
            {
               return null;
            }
            else
            {

                return (section) => {

                    int semr = box.Entry.Id;
                    return section.Entry.Semester_ID == semr;
                };

            }
        }

       

        private void filterbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter = generateFilter();

            SaveChanges();
        }
    }
}
