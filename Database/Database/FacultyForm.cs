﻿using System;
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
    public partial class FacultyForm : Form
    {
        private CollegeEntities1 database;
        public FacultyForm()
        {
            InitializeComponent();
            database = new CollegeEntities1();

        }

        public void AddNewFaculty()
        { 
            
        }


    }
}