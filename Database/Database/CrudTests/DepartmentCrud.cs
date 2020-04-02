using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database.CrudTests
{
    public class DepartmentCrud : GenericDatabaseCrud<Department>
    {



        public DeparmentComponent Options { get; protected set; }

        public DepartmentCrud(CollegeEntities database, GenericFormCore core, DeparmentComponent options) : base(database, database.Departments, core)
        {

            Options = options;
        }



        public override void BindOptionComponent()
        {
            Options.DeptLabel.Click += deptLabel_Click;
            Options.NameText.Text = "";
            Options.NameText.Enabled = true;
            Options.NameText.Visible = true;
            Options.DeptLabel.Enabled = true;
            Options.DeptLabel.Visible = true;
            Options.DeptLabel.Text = "Department";

        }

        public override void UnbindOptionComponent()
        {
            Options.DeptLabel.Click -= deptLabel_Click;
            Options.NameText.Text = "";
            Options.NameText.Enabled = false;
            Options.NameText.Visible = false;
            Options.DeptLabel.Enabled = false;
            Options.DeptLabel.Visible = false;
        }


     

        public override void SelectItem(ListboxEntry<Department> item)
        {
            Department dept = item.Entry;
            TextBox txt = Options.NameText;
            txt.Text = dept.Name == null ? "" : dept.Name;

        }

        public override void SubmitAdd()
        {
            String name = Options.NameText.Text;
            Options.NameText.Text = "";
            Department dept = new Department() { Name = name };
            DataSet.Add(dept);
            SaveChanges();
        }

        public override void SubmitDelete()
        {

            Department dept = (Department)SelectedEntry.Entry;
            Options.NameText.Text = "";
            DataSet.Remove(dept);
            SaveChanges();
        }

        public override void SubmitUpdate()
        {
            Department dept = (Department)SelectedEntry.Entry;
            String name = Options.NameText.Text;

            if (dept == null)
                return;
            dept.Name = name;
            SaveChanges();
        }

        public interface DeparmentComponent : GenericFormOptions
        {
            TextBox NameText { get; }
            Label DeptLabel { get; }
        }

        private void deptLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Editing Departments Son!!");
        }

        protected override ListboxEntry<Department> NameEntry(Department dept)
        {
            return new StandardListboxEntry<Department>(dept, dept.Name);
        }
    }

}
