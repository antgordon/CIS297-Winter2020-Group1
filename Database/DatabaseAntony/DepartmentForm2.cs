using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseAntony
{
    public partial class DepartmentForm2 : Form
    {

        dboEntities1 database;
        Mode editMode;
        private bool initDone = false;

        public DepartmentForm2()
        {
            InitializeComponent();
            initDone = true;
            database = new dboEntities1();
            editMode = Mode.Add;
            Department d;
            generalListBox.DataSource = database.Departments.ToList();
            generalListBox.DisplayMember = "Name";
            updateButton();
           // generalListBox.ValueMember = "Id";
        }


        private void updateButton() {
            switch (editMode) {
                case Mode.Add: { 
                    submitButton.Text = "Add";
                }break;


                case Mode.Delete: {
                 submitButton.Text = "Delete";
                }break;

                 case Mode.Update: {
                 submitButton.Text = "Update";
                }
            break;
           
         }
        }

        private void DepartmentForm2_Load(object sender, EventArgs e)
        {

        }

        enum Mode { 
            Add, Update, Delete
        }

        private void addRadio_CheckedChanged(object sender, EventArgs e)
        {
            editMode = Mode.Add;
            updateButton();
        }

        private void updateRadioBut_CheckedChanged(object sender, EventArgs e)
        {
            editMode = Mode.Update;
            updateButton();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void deleteRadioBut_CheckedChanged(object sender, EventArgs e)
        {
            editMode = Mode.Delete;
            updateButton();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            if (!initDone)
                return;

            if (editMode == Mode.Add) {
                String name = nameTextBox.Text;
                nameTextBox.Text = "";
                Department dept = new Department() { Name = name };
                database.Departments.Add(dept);
                database.SaveChanges();
                generalListBox.DataSource = database.Departments.ToList();
            }
            else if (editMode == Mode.Delete)
            {

                Department dept = (Department)generalListBox.SelectedItem;
                String name = nameTextBox.Text;
                nameTextBox.Text = "";
                database.Departments.Remove(dept);
                database.SaveChanges();
                generalListBox.DataSource = database.Departments.ToList();
            }
            else if (editMode == Mode.Update)
            {

                Department dept = (Department)generalListBox.SelectedItem;
                String name = nameTextBox.Text;
                dept.Name = name;
                database.Departments.Remove(dept);
                database.SaveChanges();
                generalListBox.DataSource = database.Departments.ToList();
            }
        }

        private void generalListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Department dept = (Department)generalListBox.SelectedItem;
            nameTextBox.Text = dept.Name;
        }
    }
}
