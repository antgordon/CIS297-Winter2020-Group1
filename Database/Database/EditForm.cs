using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database
{
    public partial class EditForm : Form
    {
        private CollegeEntities1 database;
        public EditForm()
        {
            database = new CollegeEntities1();
            InitializeComponent();
            updateListBoxes();
        }

        private void updateListBoxes()
        {
            table_ListBox.Items.Add("Course"); //0
            table_ListBox.Items.Add("Department"); //1
            table_ListBox.Items.Add("Enrollment"); //2
            table_ListBox.Items.Add("Faculty"); //3
            table_ListBox.Items.Add("Grade"); //4
            table_ListBox.Items.Add("Major"); //5 
            table_ListBox.Items.Add("Person"); //6 
            table_ListBox.Items.Add("Season"); //7
            table_ListBox.Items.Add("Section"); //8
            table_ListBox.Items.Add("Semester"); //9
            table_ListBox.Items.Add("Student"); //10
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

        private void update_Button_Selected(object sender, EventArgs e)
        {

        }

        private void delete_Button_Selected(object sender, EventArgs e)
        {

        }
        private void Table_Selected(object sender, EventArgs e)
        {
            tableContent_ListBox.Items.Clear();
            if (table_ListBox.SelectedIndex == 0)
            {
                foreach (var entry in database.Courses)
                    tableContent_ListBox.Items.Add(entry.Name);
            }
            if (table_ListBox.SelectedIndex == 1)
            {
                foreach (var entry in database.Departments)
                    tableContent_ListBox.Items.Add(entry.Name);
            }
            if (table_ListBox.SelectedIndex == 2)
            {
                foreach (var entry in database.Enrollments)
                    tableContent_ListBox.Items.Add($"ID: {entry.Id}");
            }
            if (table_ListBox.SelectedIndex == 3)
            {
                foreach (var entry in database.Faculties)
                    tableContent_ListBox.Items.Add(entry.Person.Name);
            }
            if (table_ListBox.SelectedIndex == 4)
            {
                foreach (var entry in database.Grades)
                    tableContent_ListBox.Items.Add(entry.Letter);
            }
            if (table_ListBox.SelectedIndex == 5)
            {
                foreach (var entry in database.Majors)
                    tableContent_ListBox.Items.Add(entry.Name);
            }
            if (table_ListBox.SelectedIndex == 6)
            {
                foreach (var entry in database.People)
                    tableContent_ListBox.Items.Add(entry.Name);
            }
            if (table_ListBox.SelectedIndex == 7)
            {
                foreach (var entry in database.Seasons)
                    tableContent_ListBox.Items.Add(entry.Name);
            }
            if (table_ListBox.SelectedIndex == 8)
            {
                foreach (var entry in database.Sections)
                    tableContent_ListBox.Items.Add(entry.Id);
            }
            if (table_ListBox.SelectedIndex == 9)
            {
                foreach (var entry in database.Semesters)
                {
                    string season = "";
                    if (entry.Season == 1)
                    {
                        season = "Fall";
                    }
                    if (entry.Season == 2)
                    {
                        season = "Winter";
                    }
                    if (entry.Season == 3)
                    {
                        season = "Summer";
                    }
                    tableContent_ListBox.Items.Add($"{season} {entry.Year}");
                }
            }
            if (table_ListBox.SelectedIndex == 10)
            {
                foreach (var entry in database.Students)
                    tableContent_ListBox.Items.Add(entry.Person.Name);
            }
        }
    }
}
