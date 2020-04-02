using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database.CrudTests
{
    public partial class EditForm2 : Form, GenericFormCore
    {
        private CollegeEntities database;

        private DepartmentCrud deptCrud;
        private SeasonCrud seaCrud;
        private GradeCrud gradeCrud;
        private MajorCrud majorCrud;

        private IList<CrudOption> options;


        public ListBox ListBoxView => this.tableContent_ListBox;

        public Button SubmitButton => this.submitButton;

        public RadioButton AddRadio => this.create_Button;

        public RadioButton UpdateRadio => this.update_Button;

        public RadioButton DeleteRadio => this.delete_Button;

        public EditForm2()
        {
            database = new CollegeEntities();
            InitializeComponent();
       

            deptCrud = new DepartmentCrud(database, this, new DepartmentOptions(this));
            seaCrud = new SeasonCrud(database, this, new SeasonOptions(this));
            gradeCrud = new GradeCrud(database, this, new GradeOptions(this));
            majorCrud = new MajorCrud(database, this, new MajorOptions(this));
            options = new List<CrudOption>();
            updateListBoxes(options);

            DisableallCruds();
            deptCrud.EnableCrud();
        }

        private void updateListBoxes(IList<CrudOption> options)
        {

            options.Add(new CrudOption("Department", () => deptCrud.EnableCrud(), () => deptCrud.DisableCrud()));
            options.Add(new CrudOption("Season", () => seaCrud.EnableCrud(), () => seaCrud.DisableCrud()));
            options.Add(new CrudOption("Grade", () => gradeCrud.EnableCrud(), () => gradeCrud.DisableCrud()));
            options.Add(new CrudOption("Major", () => majorCrud.EnableCrud(), () => majorCrud.DisableCrud()));

            table_ListBox.DisplayMember = "Name";

            foreach (CrudOption cudOption in options) {
                table_ListBox.Items.Add(cudOption);
            }
            //  table_ListBox.Items.Add("Course"); //0
            //  table_ListBox.Items.Add("Department"); //1 x
            //  table_ListBox.Items.Add("Enrollment"); //2
            // table_ListBox.Items.Add("Faculty"); //3
            // table_ListBox.Items.Add("Grade"); //4 x
            // table_ListBox.Items.Add("Major"); //5 x
            // table_ListBox.Items.Add("Person"); //6 
            // table_ListBox.Items.Add("Season"); //7 x
            // table_ListBox.Items.Add("Section"); //8 
            //table_ListBox.Items.Add("Semester"); //9 x
            //table_ListBox.Items.Add("Student"); //10

        }

        private void create_Button_Selected(object sender, EventArgs e)
        {
            option1_TextBox.Visible = true;
            option2_TextBox.Visible = true;
            option3_TextBox.Visible = true;
            option4_TextBox.Visible = true;

            option1_Label.Visible = true;
            option2_Label.Visible = true;
            option3_Label.Visible = true;
            option4_Label.Visible = true;

            option1_TextBox.Enabled = false;
            option2_TextBox.Enabled = false;
            option3_TextBox.Enabled = false;
            option4_TextBox.Enabled = false;
        }

        private void read_Button_Selected(object sender, EventArgs e)
        {
            option1_TextBox.Visible = false;
            option2_TextBox.Visible = false;
            option3_TextBox.Visible = false;
            option4_TextBox.Visible = false;

            option1_Label.Visible = false;
            option2_Label.Visible = false;
            option3_Label.Visible = false;
            option4_Label.Visible = false;

        }

        private void courseTable_Selected(object sender, EventArgs e)
        {
            CrudOption option = table_ListBox.SelectedItem as CrudOption;
            DisableallCruds();

            if (option != null) {
                option.EnableTask();
            }
        


   }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }

    

        private class CrudOption {
            public delegate void Task();

            public String Name { get; }
            public Task EnableTask { get; }
            public Task DisableTask { get; }

            public CrudOption(String name, Task enable, Task disable) {
                Name = name;
                EnableTask = enable;
                DisableTask = disable;
             }

        
        }



        /**
  * 
  * Crud specific components
  * **/
        private class DepartmentOptions : DepartmentCrud.DeparmentComponent
        {

            private EditForm2 form;
            public DepartmentOptions(EditForm2 form)
            {

                this.form = form;
            }

            public TextBox NameText => form.option1_TextBox;

            public Label DeptLabel => form.option1_Label;
        }

        private class SeasonOptions : SeasonCrud.SeasonComponent
        {

            private EditForm2 form;
            public SeasonOptions(EditForm2 form)
            {

                this.form = form;
            }

            public TextBox NameText => form.option1_TextBox;

            public Label SeasonLabel => form.option1_Label;
        }

        private class GradeOptions: GradeCrud.GradeComponent
        {

            private EditForm2 form;
            public GradeOptions(EditForm2 form)
            {

                this.form = form;
            }

            public TextBox NameText => form.option1_TextBox;

            public Label GradeLabel => form.option1_Label;
        }

        private class MajorOptions : MajorCrud.MajorCompoenent
        {

            private EditForm2 form;
            public MajorOptions(EditForm2 form)
            {

                this.form = form;
            }

            public TextBox NameText => form.option1_TextBox;

            public Label MajorLabel => form.option1_Label;

            public ComboBox DeparmentComboBox => form.comboBox1;
        }

        private void DisableallCruds()
        {
            foreach(CrudOption option in options){
                option.DisableTask();
            }
         
          
        }

    }


}
