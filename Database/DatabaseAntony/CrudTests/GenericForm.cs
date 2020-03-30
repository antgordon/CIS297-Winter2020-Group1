using DatabaseAntony;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseAntony
{
    public partial class GenericForm : Form, GenericFormCore   {




        private DepartmentCrud deptCrud;
        private DepartmentOptions optionsDept;

        private SeasonCrud seaCrud;
        private SeasonOptions optionsSea;

        public GenericForm(dboEntities1 database)
        {
            InitializeComponent();
            optionsDept = new DepartmentOptions(this);
            optionsSea = new SeasonOptions(this);

            deptCrud = new DepartmentCrud(database, this, optionsDept);
            seaCrud = new SeasonCrud(database, this, optionsSea);

            deptCrud.DisableCrud();
            seaCrud.DisableCrud();
            deptCrud.EnableCrud();

        }


        private class DepartmentOptions : DepartmentCrud.DeparmentComponent
        {

            private GenericForm form;
            public DepartmentOptions(GenericForm form) {

                this.form = form;
            }

            public TextBox NameText => form.nameTextBox;

            public Label DeptLabel => form.deptLabel;
        }

        private class SeasonOptions : SeasonCrud.SeasonComponent
        {

            private GenericForm form;
            public SeasonOptions(GenericForm form)
            {

                this.form = form;
            }

            public TextBox NameText => form.nameTextBox;

            public Label SeasonLabel => form.seasonLabel;
        }


        public ListBox ListBoxView => generalListBox;

        public Button SubmitButton => submitButton;

        public RadioButton AddRadio => addRadioBut;

        public RadioButton UpdateRadio => updateRadioBut;

        public RadioButton DeleteRadio => deleteRadioBut;


        class DepartmentCrud : GenericDatabaseCrud<Department>
        {



            public DeparmentComponent Options { get; protected set; }

            public DepartmentCrud(dboEntities1 database, GenericFormCore core, GenericFormOptions options) : base(database, database.Departments, core, options)
            {
                if (options == null)
                    throw new Exception("Wtf");
                Options = (DeparmentComponent)options;
            }

      

            public override void BindOptionComponent()
            {
                Options.DeptLabel.Click += deptLabel_Click;
            }

            public override void UnbindOptionComponent()
            {
                Options.DeptLabel.Click -= deptLabel_Click;
            }


            public override void DisableComponents()
            { 
                Options.NameText.Text = "";
                Options.NameText.Enabled = false;
                Options.NameText.Visible = false;
                Options.DeptLabel.Enabled = false;
                Options.DeptLabel.Visible = false;
            }

            public override void EnableComponents()
            {
                Options.NameText.Text = "";
                Options.NameText.Enabled = true;
                Options.NameText.Visible = true;
                Options.DeptLabel.Enabled = true;
                Options.DeptLabel.Visible = true;

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
                String name = Options.NameText.Text;
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

            protected override string NameEntry(Department dept)
            {
                return dept.Name;
            }
        }

        class SeasonCrud : GenericDatabaseCrud<Season>
        {



            public SeasonComponent Options { get; protected set; }

            public SeasonCrud(dboEntities1 database, GenericFormCore core, GenericFormOptions options) : base(database, database.Seasons, core, options)
            {
                if (options == null)
                    throw new Exception("Wtf");
                Options = (SeasonComponent)options;
            }

            protected override string NameEntry(Season season)
            {
                return season.name;
            }

            public override void BindOptionComponent()
            {
                Options.SeasonLabel.Click += seasonLabel_Click;
            }

            public override void UnbindOptionComponent()
            {
                Options.SeasonLabel.Click -= seasonLabel_Click;
            }


            public override void DisableComponents()
            {
                Options.NameText.Text = "";
                Options.NameText.Enabled = false;
                Options.NameText.Visible = false;
                Options.SeasonLabel.Enabled = false;
                Options.SeasonLabel.Visible = false;
            }

            public override void EnableComponents()
            {
         
                Options.NameText.Text = "";
                Options.NameText.Enabled = true;
                Options.NameText.Visible = true;
                Options.SeasonLabel.Enabled = true;
                Options.SeasonLabel.Visible = true;

            }

            public override void SelectItem(ListboxEntry<Season> item)
            {
                Season season = item.Entry;
                TextBox txt = Options.NameText;
                txt.Text = season.name == null ? "" : season.name;
                
            }

            public override void SubmitAdd()
            {
                String name = Options.NameText.Text;
                Options.NameText.Text = "";
                Season season = new Season() { name = name };
                DataSet.Add(season);
                SaveChanges();
            }

            public override void SubmitDelete()
            {

                Season season = (Season)SelectedEntry.Entry;
                String name = Options.NameText.Text;
                Options.NameText.Text = "";
                DataSet.Remove(season);
                SaveChanges();
            }

            public override void SubmitUpdate()
            {
                Season season = (Season)SelectedEntry.Entry;
                String name = Options.NameText.Text;

                if (season == null)
                    return;
                season.name = name;
                SaveChanges();
            }


            public interface SeasonComponent : GenericFormOptions
            {
                TextBox NameText { get; }
                Label SeasonLabel { get; }
            }

            private void seasonLabel_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Editing Seasons Boi!!");
            }
        }

        private void deptRadio_CheckedChanged(object sender, EventArgs e)
        {
            seaCrud.DisableCrud();
            deptCrud.DisableCrud();
            deptCrud.EnableCrud();
           

        }

        private void seasonRadio_CheckedChanged(object sender, EventArgs e)
        {
            deptCrud.DisableCrud();
            seaCrud.DisableCrud();
            seaCrud.EnableCrud();

        }
    }



    
  

}
