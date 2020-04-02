using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database.CrudTests
{
    public class GradeCrud : GenericDatabaseCrud<Grade>
    {



        public GradeComponent Options { get; protected set; }

        public GradeCrud(CollegeEntities1 database, GenericFormCore core, GradeComponent options) : base(database, database.Grades, core)
        {
         
            Options = (GradeComponent)options;
        }

        protected override ListboxEntry<Grade> NameEntry(Grade grade)
        {
            return new StandardListboxEntry<Grade>(grade, grade.Letter);
        }

        public override void BindOptionComponent()
        {
            Options.GradeLabel.Click += gradeLabel_Click;
            Options.NameText.Text = "";
            Options.NameText.Enabled = true;
            Options.NameText.Visible = true;
            Options.GradeLabel.Enabled = true;
            Options.GradeLabel.Visible = true;
            Options.GradeLabel.Text = "Letter";
        }

        public override void UnbindOptionComponent()
        {
            Options.GradeLabel.Click -= gradeLabel_Click;
            Options.NameText.Text = "";
            Options.NameText.Enabled = false;
            Options.NameText.Visible = false;
            Options.GradeLabel.Enabled = false;
            Options.GradeLabel.Visible = false;
        }

        public override void SelectItem(ListboxEntry<Grade> item)
        {
            Grade grade = item.Entry;
            TextBox txt = Options.NameText;
            txt.Text = grade.Letter == null ? "" : grade.Letter;
        }

        public override void SubmitAdd()
        {
            String name = Options.NameText.Text;
            Options.NameText.Text = "";
            Grade grade = new Grade() { Letter = name };
            DataSet.Add(grade);
            SaveChanges();
        }

        public override void SubmitDelete()
        {

            Grade grade = (Grade)SelectedEntry.Entry;
            Options.NameText.Text = "";
            DataSet.Remove(grade);
            SaveChanges();
        }

        public override void SubmitUpdate()
        {
            Grade grade = (Grade)SelectedEntry.Entry;
            String name = Options.NameText.Text;

            if (grade == null)
                return;
            grade.Letter= name;
            SaveChanges();
        }


        public interface GradeComponent : GenericFormOptions
        {
            TextBox NameText { get; }
            Label GradeLabel { get; }
        }

        private void gradeLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Editing Seasons Boi!!");
        }
    }

}
