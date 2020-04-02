﻿using System;
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
        private SemesterCrud semesterCrud;
        private PersonCrud personCrud;
        private StudentCrud studentCrud;

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
            semesterCrud = new SemesterCrud(database, this, new SemesterOptions(this));
            personCrud = new PersonCrud(database, this, new PersonOptions(this));
            studentCrud = new StudentCrud(database, this, new StudentOptions(this));

    
            updateListBoxes();

            DisableallCruds();
            deptCrud.EnableCrud();
        }

        private void updateListBoxes()
        {
            options = new List<CrudOption>();
            options.Add(new CrudOption("Department", () => deptCrud.EnableCrud(), () => deptCrud.DisableCrud()));
            options.Add(new CrudOption("Season", () => seaCrud.EnableCrud(), () => seaCrud.DisableCrud()));
            options.Add(new CrudOption("Grade", () => gradeCrud.EnableCrud(), () => gradeCrud.DisableCrud()));
            options.Add(new CrudOption("Major", () => majorCrud.EnableCrud(), () => majorCrud.DisableCrud()));
            options.Add(new CrudOption("Semester", () => semesterCrud.EnableCrud(), () => semesterCrud.DisableCrud()));
            options.Add(new CrudOption("Person", () => personCrud.EnableCrud(), () => personCrud.DisableCrud()));
            options.Add(new CrudOption("Student", () => studentCrud.EnableCrud(), () => studentCrud.DisableCrud()));

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

     
        private void tabl_select(object sender, EventArgs e)
        {
            CrudOption option = table_ListBox.SelectedItem as CrudOption;
            DisableallCruds();

            if (option != null) {
                option.EnableTask();
            }
        


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

        private class SemesterOptions : SemesterCrud.SemesterCompoenent
        {

            private EditForm2 form;
            public SemesterOptions(EditForm2 form)
            {

                this.form = form;
            }

            public TextBox YearText => form.option1_TextBox;

            public Label SemesterLabel => form.option1_Label;

            public ComboBox SeasonComboBox => form.comboBox1;
        }

        private class PersonOptions : PersonCrud.PersonComponent
        {

            private EditForm2 form;
            public PersonOptions(EditForm2 form)
            {

                this.form = form;
            }

            public TextBox NameText => form.option1_TextBox;

            public TextBox EmailText => form.option2_TextBox;

            public TextBox NumberText => form.option3_TextBox;

            public Label NameLabel => form.option1_Label;

            public Label EmailLabel => form.option2_Label;

            public Label NumberLabel =>  form.option3_Label;
        }

        private class StudentOptions : StudentCrud.StudentCompoenent
        {

            private EditForm2 form;
            public StudentOptions(EditForm2 form)
            {

                this.form = form;
            }

            public Label SemesterLabel => form.option1_Label;

            public ComboBox PersonComboBox => form.comboBox1;
        }

        private void DisableallCruds()
        {
            foreach(CrudOption option in options){
                option.DisableTask();
            }
         
          
        }
    }


}
