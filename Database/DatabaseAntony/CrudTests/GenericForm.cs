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

namespace DatabaseAntony.CrudTests
{
    public partial class GenericForm : Form, GenericFormCore {




        private DepartmentCrud deptCrud;
        private DepartmentOptions optionsDept;

        private SeasonCrud seaCrud;
        private SeasonOptions optionsSea;

        private PersonCrud personCrud;
        private PersonOptions optionsPerson;

        public GenericForm(dboEntities1 database)
        {
            InitializeComponent();
            optionsDept = new DepartmentOptions(this);
            optionsSea = new SeasonOptions(this);
            optionsPerson = new PersonOptions(this);

            deptCrud = new DepartmentCrud(database, this, optionsDept);
            seaCrud = new SeasonCrud(database, this, optionsSea);
            personCrud = new PersonCrud(database, this, optionsPerson);


            DisableallCruds();
            deptCrud.EnableCrud();

        }

        private void DisableallCruds() {

            deptCrud.DisableCrud();
            seaCrud.DisableCrud();
            personCrud.DisableCrud();
        }


        /**
       * 
       * Crud specific components
       * **/
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


        private class PersonOptions : PersonCrud.PersonComponent
        {

            private GenericForm form;
            public PersonOptions(GenericForm form)
            {

                this.form = form;
            }

            public TextBox NameText => form.nameTextBox;

            public TextBox EmailText => form.textBox1;

            public TextBox NumberText => form.textBox2;

            public CheckBox StudentCheck => form.checkBox1;

            public CheckBox FacultyCheck => form.checkBox2;

            public Label PersonLabel => form.personLabel;

            public ListBox StudentListbox => form.listBox1;

            public ListBox FacultyListbox => form.listBox2;
        }


        /**
       * 
       * Global components
       * **/

        public ListBox ListBoxView => generalListBox;

        public Button SubmitButton => submitButton;

        public RadioButton AddRadio => addRadioBut;

        public RadioButton UpdateRadio => updateRadioBut;

        public RadioButton DeleteRadio => deleteRadioBut;


        /**
         * 
         * Switching between cruds
         * **/
     

        private void deptRadio_CheckedChanged(object sender, EventArgs e)
        {
            DisableallCruds();
            deptCrud.EnableCrud();
           

        }

        private void seasonRadio_CheckedChanged(object sender, EventArgs e)
        {
            DisableallCruds();
            seaCrud.EnableCrud();

        }

        private void personRadio_CheckedChanged(object sender, EventArgs e)
        {
            DisableallCruds();
            personCrud.EnableCrud();
        }
    }



    
  

}
