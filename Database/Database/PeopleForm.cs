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
    public partial class PeopleForm : Form
    {
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TypeGroupBox = new System.Windows.Forms.GroupBox();
            this.StudentRadioButton = new System.Windows.Forms.RadioButton();
            this.FacultyRadioButton = new System.Windows.Forms.RadioButton();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CurrentPeopleListBox = new System.Windows.Forms.ListBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.TypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Person:";
            // 
            // TypeGroupBox
            // 
            this.TypeGroupBox.Controls.Add(this.StudentRadioButton);
            this.TypeGroupBox.Controls.Add(this.FacultyRadioButton);
            this.TypeGroupBox.Location = new System.Drawing.Point(72, 61);
            this.TypeGroupBox.Name = "TypeGroupBox";
            this.TypeGroupBox.Size = new System.Drawing.Size(129, 82);
            this.TypeGroupBox.TabIndex = 1;
            this.TypeGroupBox.TabStop = false;
            this.TypeGroupBox.Text = "Type:";
            // 
            // StudentRadioButton
            // 
            this.StudentRadioButton.AutoSize = true;
            this.StudentRadioButton.Location = new System.Drawing.Point(21, 42);
            this.StudentRadioButton.Name = "StudentRadioButton";
            this.StudentRadioButton.Size = new System.Drawing.Size(62, 17);
            this.StudentRadioButton.TabIndex = 1;
            this.StudentRadioButton.TabStop = true;
            this.StudentRadioButton.Text = "Student";
            this.StudentRadioButton.UseVisualStyleBackColor = true;
            // 
            // FacultyRadioButton
            // 
            this.FacultyRadioButton.AutoSize = true;
            this.FacultyRadioButton.Location = new System.Drawing.Point(21, 19);
            this.FacultyRadioButton.Name = "FacultyRadioButton";
            this.FacultyRadioButton.Size = new System.Drawing.Size(59, 17);
            this.FacultyRadioButton.TabIndex = 0;
            this.FacultyRadioButton.TabStop = true;
            this.FacultyRadioButton.Text = "Faculty";
            this.FacultyRadioButton.UseVisualStyleBackColor = true;
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(69, 162);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(60, 13);
            this.FirstNameLabel.TabIndex = 2;
            this.FirstNameLabel.Text = "First Name:";
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(69, 188);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(61, 13);
            this.LastNameLabel.TabIndex = 3;
            this.LastNameLabel.Text = "Last Name:";
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(135, 159);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(148, 20);
            this.FirstNameTextBox.TabIndex = 4;
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(135, 185);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(148, 20);
            this.LastNameTextBox.TabIndex = 5;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(135, 237);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(148, 20);
            this.EmailTextBox.TabIndex = 9;
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.Location = new System.Drawing.Point(135, 211);
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.Size = new System.Drawing.Size(148, 20);
            this.PhoneTextBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Phone:";
            // 
            // CurrentPeopleListBox
            // 
            this.CurrentPeopleListBox.FormattingEnabled = true;
            this.CurrentPeopleListBox.Location = new System.Drawing.Point(421, 103);
            this.CurrentPeopleListBox.Name = "CurrentPeopleListBox";
            this.CurrentPeopleListBox.Size = new System.Drawing.Size(241, 160);
            this.CurrentPeopleListBox.TabIndex = 10;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(250, 283);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(108, 36);
            this.AddButton.TabIndex = 11;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // PeopleForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.CurrentPeopleListBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.PhoneTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LastNameTextBox);
            this.Controls.Add(this.FirstNameTextBox);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.TypeGroupBox);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "PeopleForm";
            this.TypeGroupBox.ResumeLayout(false);
            this.TypeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private CollegeEntities1 database;
        public PeopleForm()
        {
            InitializeComponent();
            database = new CollegeEntities1();

            /*rrentPeopleListBox.DataSource = database.People.ToList();
            CurrentPeopleListBox.DisplayMember = "Name";
            CurrentPeopleListBox.ValueMember = "Id";
            */

        }

        public void AddNewFaculty()
        {
            string name = $"{FirstNameTextBox} {LastNameTextBox}";
            Person newPerson = new Person() {
                Name = name, 
                Number =  PhoneTextBox.Text,
                Email = EmailTextBox.Text
            };
            Faculty faculty = new Faculty(); 
            faculty.Person_Id = newPerson.Id;

        }

        public void AddNewStudent()
        {
            string name = $"{FirstNameTextBox} {LastNameTextBox}";
            Person newPerson = new Person()
            {
                Name = name,
                Email = EmailTextBox.Text,
                Number = PhoneTextBox.Text
            };
           Student student = new Student();
            student.Person_Id = newPerson.Id;

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (FacultyRadioButton.Checked)
                AddNewFaculty();
            else if (StudentRadioButton.Checked)
                AddNewStudent();
        }
    }
}
