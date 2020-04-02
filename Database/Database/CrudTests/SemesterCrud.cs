using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database.CrudTests
{
    public class SemesterCrud : GenericDatabaseCrud<Semester>
    {



        public SemesterCompoenent Options { get; protected set; }
        private int defaultIndex = 0;
        private IList<ListboxEntry<Season>> source;

        public SemesterCrud(CollegeEntities1 database, GenericFormCore core, SemesterCompoenent options) : base(database, database.Semesters, core)
        {

            Options = (SemesterCompoenent)options;
        }

        protected override ListboxEntry<Semester> NameEntry(Semester semester)
        {
            return new StandardListboxEntry<Semester>(semester, $"{semester.Season1.name} {semester.Year}");
        }

        public override void BindOptionComponent()
        {
            FormCore.SubmitButton.Enabled = true;
           

            Options.SemesterLabel.Click += semesterLabel_Click;
            Options.YearText.Text = "";
            Options.YearText.TextChanged += YearTextChanged;
            Options.YearText.Enabled = true;
            Options.YearText.Visible = true;
            Options.SemesterLabel.Enabled = true;
            Options.SemesterLabel.Visible = true;
            Options.SemesterLabel.Text = "Year";
            Options.SeasonComboBox.Enabled = true;
            Options.SeasonComboBox.Visible = true;
            Options.SeasonComboBox.Text = "Season";

            populateSeasons();
            //Default
    
            Options.SeasonComboBox.SelectedIndex = defaultIndex;
        }


        public override void UnbindOptionComponent()
        {
            FormCore.SubmitButton.Enabled = true;
            Options.SemesterLabel.Click -= semesterLabel_Click;
            Options.YearText.TextChanged -= YearTextChanged;
            Options.YearText.Text = "";
            Options.YearText.Enabled = false;
            Options.YearText.Visible = false;
            Options.SemesterLabel.Enabled = false;
            Options.SemesterLabel.Visible = false;
            Options.SeasonComboBox.Enabled = false;
            Options.SeasonComboBox.Visible = false;
            Options.SeasonComboBox.DataSource = null;
        }

        public override void SelectItem(ListboxEntry<Semester> item)
        {
            Semester semester = item.Entry;
            Options.YearText.Text = Convert.ToString(semester.Year);
            ListboxEntry<Season> selected = findSeasons(semester.Season);
            Options.SeasonComboBox.SelectedItem = selected;
        }

        public override void SubmitAdd()
        {
            int year = Convert.ToInt32(Options.YearText.Text);

            ListboxEntry<Season> selected = Options.SeasonComboBox.SelectedItem as ListboxEntry<Season>;
            int key = selected.Entry.id;
         
           Semester semester = new Semester() { Year = year , Season = key};


            Options.YearText.Text = "";
            Options.SeasonComboBox.SelectedIndex = defaultIndex;
            DataSet.Add(semester);
            SaveChanges();
        }

        public override void SubmitDelete()
        {

            Semester semester = (Semester)SelectedEntry.Entry;
            Options.YearText.Text = "";
            Options.SeasonComboBox.SelectedIndex = defaultIndex;
            DataSet.Remove(semester);
            SaveChanges();
        }

        public override void SubmitUpdate()
        {
            Semester semester = (Semester)SelectedEntry.Entry;
            int year = Convert.ToInt32(Options.YearText.Text);
         

            ListboxEntry<Season> selected = findSeasons(semester.Season);



            semester.Year = year;
            semester.Season = selected.Entry.id;
            SaveChanges();
        }


        public interface SemesterCompoenent : GenericFormOptions
        {
            TextBox YearText { get; }
            Label SemesterLabel { get; }
            ComboBox SeasonComboBox { get; }
        }

        private void semesterLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Editing Seasons Boi!!");
        }

        private void populateSeasons() {

            ListboxEntry<Season> convert(Season season) {
                return new StandardListboxEntry<Season>(season, season.name);

            }

           IList<ListboxEntry<Season>> list = ConvertToEntry(Database.Seasons, convert);
            source = list;
            Options.SeasonComboBox.DataSource = list;
            Options.SeasonComboBox.DisplayMember = "Name";
        }


        private ListboxEntry<Season> findSeasons(int key) {

    

        foreach (ListboxEntry<Season> entry in source)
        {
            if (entry.Entry != null)
            {

                if (entry.Entry.id == key) {
                    return entry;
                }
            }
        }

        return source[defaultIndex];
     


        }


        private void YearTextChanged(object sender, EventArgs e)
        {
            int val = 0;
            if (int.TryParse(Options.YearText.Text, out val))
            {
                FormCore.SubmitButton.Enabled = true;
            }
            else {
                FormCore.SubmitButton.Enabled = false;
            }
        }
    }


}
