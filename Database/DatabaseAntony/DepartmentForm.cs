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

namespace DatabaseAntony
{
    public partial class DepartmentForm : Form
    {

        dboEntities1 database;
        DataTable table;

        public DepartmentForm()
        {
            InitializeComponent();
            database = new dboEntities1();
            table = MakeParentTable();
            departmentGrid.DataSource = table;
            updateTable(table, database.Departments);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = DepNameTextbox.Text;

            if (name.Length != 0) {

                DepNameTextbox.Text = "";
                Department department = new Department()
                {
                    Name = name
                };

                database.Departments.Add(department);
                database.SaveChanges();
                updateTable(table, database.Departments);
            }
           
         

        }

        private void updateTable(DataTable table, DbSet<Department> dbset) {
            table.Rows.Clear();

            foreach (Department dep in dbset)
            {
                DataRow row = table.NewRow();
                row["Id"] = Convert.ToString(dep.Id);
                row["Department"] = Convert.ToString(dep.Name);
                table.Rows.Add(row);


            }
        }

        private System.Data.DataTable MakeParentTable()
        {
            // Create a new DataTable.
            System.Data.DataTable table = new DataTable("ParentTable");
          
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;

            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Id";
            column.ReadOnly = true;
            column.Unique = true;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Department";
            column.AutoIncrement = false;
            column.Caption = "ParentItem";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the column to the table.
            table.Columns.Add(column);

            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;

            return table;
        }

        private void departmentGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void departmentGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = departmentGrid.CurrentRow;
            int id = Convert.ToInt32(row.Cells["Id"].Value);
            string value = (string)row.Cells["Department"].Value;

            Department dept = database.Departments.Find(id);
            dept.Name = value;
            database.SaveChanges();
            updateTable(table, database.Departments);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selected = departmentGrid.SelectedRows;

            List<int> ids = new List<int>();

            foreach (DataGridViewRow row in selected) {
                int pKey = Convert.ToInt32(row.Cells["Id"].Value);
                ids.Add(pKey);
            
            }

            foreach (int pKey in ids) {
                Department dept =    database.Departments.Find(pKey);
                database.Departments.Remove(dept);
            }

            database.SaveChanges();
            updateTable(table, database.Departments);
        }
    }
}
