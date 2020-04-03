using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Database.CrudTests
{
    public class EnrollmentCrud : GenericDatabaseCrud<Enrollment>
    {
        public EnrollmentComponent Options { get; protected set; }
        private IList<ListboxEntry<Person>> personSource;
        private IList<ListboxEntry<Semester>> semesterSource;
        private IList<ListboxEntry<Course>> courseSource;
        private IList<ListboxEntry<Section>> sectionSource;

        private int defaultIndex = 0;


        public EnrollmentCrud(CollegeEntities1 database, GenericFormCore core, EnrollmentComponent options) : base(database, database.Enrollments, core)
        {
            Options = options;
        }

        public override void BindOptionComponent()
        {
            FormCore.SubmitButton.Enabled = true;

            Options.PersonLabel.Text = "Person";
            Options.PersonLabel.Enabled = true;
            Options.PersonLabel.Visible = true;

            Options.PersonComboBox.Enabled = true;
            Options.PersonComboBox.Visible = true;
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
            //Options.CourseComboBox.Text = "Course";

            Options.SectionLabel.Text = "Section";
            Options.SectionLabel.Enabled = true;
            Options.SectionLabel.Visible = true;

            Options.SectionComboBox.Enabled = true;
            Options.SectionComboBox.Visible = true;
            //Options.SectionComboBox.Text = "Section";

            populateComboBoxes();

            Options.PersonComboBox.SelectedItem = defaultIndex;
            Options.CourseComboBox.SelectedItem = defaultIndex;
            Options.SemesterComboBox.SelectedItem = defaultIndex;
            Options.SectionComboBox.SelectedItem = defaultIndex;
        }

        public override void UnbindOptionComponent()
        {
            Options.PersonLabel.Text = "";
            Options.PersonLabel.Enabled = false;
            Options.PersonLabel.Visible = false;

            Options.PersonComboBox.Enabled = false;
            Options.PersonComboBox.Visible = false;
            Options.PersonComboBox.Text = "";

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

            Options.SectionLabel.Text = "";
            Options.SectionLabel.Enabled = false;
            Options.SectionLabel.Visible = false;

            Options.SectionComboBox.Enabled = false;
            Options.SectionComboBox.Visible = false;
            Options.SectionComboBox.Text = "";
        }

        public override void SelectItem(ListboxEntry<Enrollment> item)
        {
            Enrollment enrollment = item.Entry;
            ListboxEntry<Person> selectedPerson = findPeople(enrollment.Person_ID);
            Options.PersonComboBox.SelectedItem = selectedPerson;

            ListboxEntry<Semester> selectedSemester = findSemesters(enrollment.Semester);
            Options.SemesterComboBox.SelectedItem = selectedSemester;

            ListboxEntry<Course> selectedCourse = findCourses(enrollment.Course_ID);
            Options.CourseComboBox.SelectedItem = selectedCourse;

            ListboxEntry<Section> selectedSection = findSections(enrollment.Section_ID);
            Options.SectionComboBox.SelectedItem = selectedSection;
        }

        public override void SubmitAdd()
        {
            ListboxEntry<Person> selectedPerson = Options.PersonComboBox.SelectedItem as ListboxEntry<Person>;
            int personKey = selectedPerson.Entry.Id;

            ListboxEntry<Course> selectedCourse = Options.CourseComboBox.SelectedItem as ListboxEntry<Course>;
            int courseKey = selectedCourse.Entry.Id;

            ListboxEntry<Semester> selectedSemester = Options.SemesterComboBox.SelectedItem as ListboxEntry<Semester>;
            int semesterKey = selectedSemester.Entry.Id;

            ListboxEntry<Section> selectedSection = Options.SectionComboBox.SelectedItem as ListboxEntry<Section>;
            int sectionKey = selectedSection.Entry.Id;

            Enrollment enrollment = new Enrollment()
            {
                Person_ID = personKey,
                Semester = semesterKey,
                Course_ID = courseKey,
                Section_ID = sectionKey
            };

            Options.PersonComboBox.SelectedItem = defaultIndex;
            Options.CourseComboBox.SelectedItem = defaultIndex;
            Options.SemesterComboBox.SelectedItem = defaultIndex;
            Options.SectionComboBox.SelectedItem = defaultIndex;
            DataSet.Add(enrollment);
            SaveChanges();

        }

        public override void SubmitDelete()
        {
            Enrollment enrollment = (Enrollment)SelectedEntry.Entry;
            Options.PersonComboBox.SelectedItem = defaultIndex;
            Options.CourseComboBox.SelectedItem = defaultIndex;
            Options.SemesterComboBox.SelectedItem = defaultIndex;
            Options.SectionComboBox.SelectedItem = defaultIndex;
            DataSet.Remove(enrollment);
            SaveChanges();
        }

        public override void SubmitUpdate()
        {
            Enrollment enrollment = (Enrollment)SelectedEntry.Entry;

            ListboxEntry<Person> selectedPerson = findPeople(enrollment.Person_ID);
            ListboxEntry<Semester> selectedSemester = findSemesters(enrollment.Semester);
            ListboxEntry<Course> selectedCourse = findCourses(enrollment.Course_ID);
            ListboxEntry<Section> selectedSection = findSections(enrollment.Section_ID);

            enrollment.Person_ID = selectedPerson.Entry.Id;
            enrollment.Semester = selectedSemester.Entry.Id;
            enrollment.Course_ID = selectedCourse.Entry.Id;
            enrollment.Section_ID = selectedSection.Entry.Id;

            SaveChanges();
        }



        protected override ListboxEntry<Enrollment> NameEntry(Enrollment enrollment)
        {
            return new StandardListboxEntry<Enrollment>(enrollment,
                $"{enrollment.Person.Name} {enrollment.Semester1.Season1.Name} {enrollment.Semester1.Year} {enrollment.Course.Name} {enrollment.Section.Id}");
        }

        public interface EnrollmentComponent : GenericFormOptions
        {
            ComboBox PersonComboBox { get; }
            ComboBox SemesterComboBox { get; }
            ComboBox CourseComboBox { get; }
            ComboBox SectionComboBox { get; }

            Label PersonLabel { get; }
            Label SemesterLabel { get; }
            Label CourseLabel { get; }
            Label SectionLabel { get; }

        }

        private void populateComboBoxes()
        {
            ListboxEntry<Person> convertPerson(Person person)
            {
                return new StandardListboxEntry<Person>(person, person.Name);
            }

            ListboxEntry<Semester> convertSemester(Semester semester)
            {
                return new StandardListboxEntry<Semester>(semester, $"{semester.Season1.Name} {semester.Year}");
            }

            ListboxEntry<Course> convertCourse(Course course)
            {
                return new StandardListboxEntry<Course>(course, course.Name);
            }

            ListboxEntry<Section> convertSection(Section section)
            {
                return new StandardListboxEntry<Section>(section, $"{section.Id}");
            }

            IList<ListboxEntry<Person>> personList = ConvertToEntry(Database.People, convertPerson);
            personSource = personList;
            Options.PersonComboBox.DataSource = personList;
            Options.PersonComboBox.DisplayMember = "Name";

            IList<ListboxEntry<Semester>> semesterList = ConvertToEntry(Database.Semesters, convertSemester);
            semesterSource = semesterList;
            Options.SemesterComboBox.DataSource = semesterList;
            Options.SemesterComboBox.DisplayMember = "Name";

            IList<ListboxEntry<Course>> courseList = ConvertToEntry(Database.Courses, convertCourse);
            courseSource = courseList;
            Options.CourseComboBox.DataSource = courseList;
            Options.CourseComboBox.DisplayMember = "Name";

            IList<ListboxEntry<Section>> sectionList = ConvertToEntry(Database.Sections, convertSection);
            sectionSource = sectionList;
            Options.SectionComboBox.DataSource = sectionList;
            Options.SectionComboBox.DisplayMember = "Name";

        }

        private ListboxEntry<Person> findPeople(int key)
        {
            foreach (ListboxEntry<Person> entry in personSource)
            {
                if (entry.Entry != null)
                {
                    if (entry.Entry.Id == key)
                    {
                        return entry;
                    }
                }
            }

            return personSource[defaultIndex];
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

        private ListboxEntry<Section> findSections(int key)
        {
            foreach (ListboxEntry<Section> entry in sectionSource)
            {
                if (entry.Entry != null)
                {
                    if (entry.Entry.Id == key)
                    {
                        return entry;
                    }
                }
            }

            return sectionSource[defaultIndex];
        }
    }
}
