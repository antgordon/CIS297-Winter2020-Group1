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
                Id = database.Seasons.Count(),
                Name = "Never Winter"

            };

            database.Seasons.Add(season1);

            Season season2 = new Season()
            {
                Id = database.Seasons.Count(),
                Name = "Never Winter2"

            };

            database.Seasons.Add(season2);




        }


       /* private void updateText() {

            TextBox textBox = null; // put txt box here

            textBox.Text = "";
            Season season = database.Season;

            foreach (var sea in season) {
                textBox.Text += sea.name + "\n";
            }

        }
        */

    }
}
