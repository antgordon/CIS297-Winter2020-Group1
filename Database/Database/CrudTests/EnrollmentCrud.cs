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
        private IList<ListboxEntry<Grade>> gradeSource;
        private IList<ListboxEntry<Student>> filterSource;

        private int defaultIndex = 0;


        public EnrollmentCrud(CollegeEntities1 database, GenericFormCore core, EnrollmentComponent options) : base(database, database.Enrollments, core)
        {
            Options = options;
        }

        public override void BindOptionComponent()
        {
            FormCore.SubmitButton.Enabled = true;

            Options.FilterCheckBox.CheckedChanged += filterCheckChange;

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

            Options.GradeLabel.Text = "Grade";
            Options.GradeLabel.Enabled = true;
            Options.GradeLabel.Visible = true;

            Options.GradeComboBox.Enabled = true;
            Options.GradeComboBox.Visible = true;
            //Options.SectionComboBox.Text = "Grade";

            Options.FilterComboBox.Enabled = false;
            Options.FilterComboBox.Visible = true;

            Options.FilterCheckBox.Enabled = true;
            Options.FilterCheckBox.Visible = true;

            populateComboBoxes();

            Options.PersonComboBox.SelectedItem = defaultIndex;
            Options.CourseComboBox.SelectedItem = defaultIndex;
            Options.SemesterComboBox.SelectedItem = defaultIndex;
            Options.SectionComboBox.SelectedItem = defaultIndex;
            Options.GradeComboBox.SelectedItem = defaultIndex;
        }

        public override void UnbindOptionComponent()
        {

            Options.FilterCheckBox.CheckedChanged -= filterCheckChange;

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

            Options.GradeLabel.Text = "";
            Options.GradeLabel.Enabled = false;
            Options.GradeLabel.Visible = false;

            Options.GradeComboBox.Enabled = false;
            Options.GradeComboBox.Visible = false;

            Options.FilterComboBox.Enabled = false;
            Options.FilterComboBox.Visible = false;

            Options.FilterCheckBox.Enabled = false;
            Options.FilterCheckBox.Visible = false;
            Options.FilterCheckBox.Checked = false;
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

            ListboxEntry<Grade> selectedGrade = findGrades(enrollment.FinalGrade_ID);
            Options.GradeComboBox.SelectedItem = selectedGrade;
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

            ListboxEntry<Grade> selectedGrade = Options.GradeComboBox.SelectedItem as ListboxEntry<Grade>;
            int gradeKey = selectedGrade.Entry.Id;

            Enrollment enrollment = new Enrollment()
            {
                Person_ID = personKey,
                Semester = semesterKey,
                Course_ID = courseKey,
                Section_ID = sectionKey,
                FinalGrade_ID = gradeKey
            };

            Options.PersonComboBox.SelectedItem = defaultIndex;
            Options.CourseComboBox.SelectedItem = defaultIndex;
            Options.SemesterComboBox.SelectedItem = defaultIndex;
            Options.SectionComboBox.SelectedItem = defaultIndex;
            Options.GradeComboBox.SelectedItem = defaultIndex;
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
            Options.GradeComboBox.SelectedItem = defaultIndex;
            DataSet.Remove(enrollment);
            SaveChanges();
        }

        public override void SubmitUpdate()
        {
            Enrollment enrollment = (Enrollment)SelectedEntry.Entry;



            ListboxEntry<Person> selectedPerson = Options.PersonComboBox.SelectedItem as ListboxEntry<Person>;
            ListboxEntry<Semester> selectedSemester = Options.SemesterComboBox.SelectedItem as ListboxEntry<Semester>;
            ListboxEntry<Course> selectedCourse = Options.CourseComboBox.SelectedItem as ListboxEntry<Course>;
            ListboxEntry<Section> selectedSection = Options.SectionComboBox.SelectedItem as ListboxEntry<Section>;
            ListboxEntry<Grade> selectedGrade = Options.GradeComboBox.SelectedItem as ListboxEntry<Grade>;

            enrollment.Person_ID = selectedPerson.Entry.Id;
            enrollment.Semester = selectedSemester.Entry.Id;
            enrollment.Course_ID = selectedCourse.Entry.Id;
            enrollment.Section_ID = selectedSection.Entry.Id;
            enrollment.FinalGrade_ID = selectedGrade.Entry.Id;

            SaveChanges();
        }



        protected override ListboxEntry<Enrollment> NameEntry(Enrollment enrollment)
        {
            if (enrollment.Grade != null)
            {
                return new StandardListboxEntry<Enrollment>(enrollment,
                    $"{enrollment.Person.Name} {enrollment.Semester1.Season1.Name} {enrollment.Semester1.Year} {enrollment.Course.Name} {enrollment.Section.Name} {enrollment.Grade.Letter}");
            }
            else
            {
                return new StandardListboxEntry<Enrollment>(enrollment,
                  $"{enrollment.Person.Name} {enrollment.Semester1.Season1.Name} {enrollment.Semester1.Year} {enrollment.Course.Name} {enrollment.Section.Name}");
            }

        }

        public interface EnrollmentComponent : GenericFormOptions
        {
            ComboBox PersonComboBox { get; }
            ComboBox SemesterComboBox { get; }
            ComboBox CourseComboBox { get; }
            ComboBox SectionComboBox { get; }
            ComboBox GradeComboBox { get; }
            ComboBox FilterComboBox { get; }

            Label PersonLabel { get; }
            Label SemesterLabel { get; }
            Label CourseLabel { get; }
            Label SectionLabel { get; }
            Label GradeLabel { get; }

            CheckBox FilterCheckBox { get; }
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
                return new StandardListboxEntry<Course>(course, $"{course.Name} {course.Number}");
            }

            ListboxEntry<Section> convertSection(Section section)
            {
                return new StandardListboxEntry<Section>(section, $"{section.Name}");
            }

            ListboxEntry<Grade> convertGrade(Grade grade)
            {
                return new StandardListboxEntry<Grade>(grade, $"{grade.Letter}");
            }

            ListboxEntry<Student> convertStudent(Student student)
            {
                return new StandardListboxEntry<Student>(student, $"{ student.Person.Name}");
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
            Options.SectionComboBox.DataSource = sectionSource;
            Options.SectionComboBox.DisplayMember = "Name";

            IList<ListboxEntry<Grade>> gradeList = ConvertToEntry(Database.Grades, convertGrade);
            gradeSource = gradeList;
            Options.GradeComboBox.DataSource = gradeList;
            Options.GradeComboBox.DisplayMember = "Name";

            IList<ListboxEntry<Student>> filterList = ConvertToEntry(Database.Students, convertStudent);
            filterSource = filterList;
            Options.FilterComboBox.DataSource = filterList;
            Options.FilterComboBox.DisplayMember = "Name";
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

        private ListboxEntry<Grade> findGrades(Nullable<int> key)
        {
            if (key.HasValue)
            {
                foreach (ListboxEntry<Grade> entry in gradeSource)
                {
                    if (entry.Entry != null)
                    {
                        if (entry.Entry.Id == key)
                        {
                            return entry;
                        }
                    }
                }

                return gradeSource[defaultIndex];
            }
            else
            {
                return gradeSource[defaultIndex];
            }
        }

        private void filterCheckChange(object sender, EventArgs e)
        {
            if (Options.FilterCheckBox.Checked)
            {
                Options.FilterComboBox.Enabled = true;
            }
            else
            {
                Options.FilterComboBox.Enabled = false;
            }
        }
    }
}
