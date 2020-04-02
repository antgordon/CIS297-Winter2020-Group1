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
        private CollegeEntities database;
        public EditForm()
        {
            database = new CollegeEntities();
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

        private void courseTable_Selected(object sender, EventArgs e)
        {
            if (table_ListBox.SelectedIndex == 0)
            {
                foreach (var entry in database.Courses)
                    tableContent_ListBox.Items.Add(entry.Name);
            }
        }
    }
}
