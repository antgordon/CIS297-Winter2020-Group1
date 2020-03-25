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
    public partial class Form1 : Form
    {

        private CollegeEntities1 database;
        public Form1()
        {
            InitializeComponent();
            database = new CollegeEntities1();


        }


        private void AddSeasonTest()
        {
            Season season1 = new Season()
            {
                id = database.Seasons.Count(),
                name = "Never Winter"

            };

            database.Seasons.Add(season1);
            database.Seasons.Append(season1);
            Season season2 = new Season()
            {
                id = database.Seasons.Count(),
                name = "Never Winter2"

            };

            database.Seasons.Add(season2);




        }


        private void updateText() {
            
            //TextBox textBox; // put txt box here

            textBox1.Text = "";
            //Database.Season seasonA = Database.Season;

            foreach (var sea in database.Seasons) {
                textBox1.Text += sea.name + '\n';
            }

        }

        private void button1ClickTest(object sender, EventArgs e)
        {
            AddSeasonTest();
            updateText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PeopleForm peopleForm = new PeopleForm();
            peopleForm.Show();
        }
    }
}
