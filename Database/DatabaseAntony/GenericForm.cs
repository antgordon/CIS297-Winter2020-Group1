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
    public partial class GenericForm : Form, GenericFormApi, DeparmentComponent
    {




        DepartmentCrud crud; 
        public GenericForm(dboEntities1 database)
        {
            InitializeComponent();
            crud = new DepartmentCrud(database);
            crud.SupplyForm(this, this);
            crud.EnableCrud();
  
        }


        public TextBox NameText => nameTextBox;

        public ListBox ListBoxView => generalListBox;

        public Button SubmitButton => submitButton;

        public RadioButton AddRadio => addRadioBut;

        public RadioButton UpdateRadio => updateRadioBut;

        public RadioButton DeleteRadio => deleteRadioBut;


        class DepartmentCrud : GenericDatabaseCrud<Department>
        {

            private DeparmentComponent option;

            public virtual DeparmentComponent Options => option;

            public DepartmentCrud(dboEntities1 database) : base(database, database.Departments)
            {

            }

            public override void BindOptionComponent(GenericFormOptions form)
            {
                if (form == null) throw new Exception("Wtf");
                option = (DeparmentComponent)form;
            }

            public override void DisableComponents()
            {
                throw new NotImplementedException();
            }

            public override void EnableComponents()
            {
                Form.ListBoxView.DisplayMember = "Name";
                Options.NameText.Text = "";

            }

            public override void SelectItem(object item)
            {
                Department dept = (Department)item;

                if (dept != null)
                {
                    TextBox txt = Options.NameText;

                        txt.Text = dept.Name == null ? "" : dept.Name;
                }
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
                
                Department dept = (Department)Form.ListBoxView.SelectedItem;
                String name = Options.NameText.Text;
                Options.NameText.Text = "";
                DataSet.Remove(dept);
                SaveChanges();
            }

            public override void SubmitUpdate()
            {
                Department dept = (Department)Form.ListBoxView.SelectedItem;
                String name = Options.NameText.Text;

                if (dept == null)
                    return;
                dept.Name = name;
                SaveChanges();
            }
        }


    }


 


    public interface DeparmentComponent : GenericFormOptions
    {
        TextBox NameText { get; }
    }

}
