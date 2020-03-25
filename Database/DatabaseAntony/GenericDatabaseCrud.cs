using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace DatabaseAntony
{
    public abstract class GenericDatabaseCrud<T> where T : class
    {
        private dboEntities1 databse;
        private GenericFormApi api;
        private EditMode editMode;

        public EditMode Mode => editMode;

        public virtual GenericFormApi Form => api;

        public virtual GenericFormOptions Options { get; }


        public DbSet<T> DataSet { get; }

        public bool Enabled { get; private set; }



        public GenericDatabaseCrud(dboEntities1 database, DbSet<T> set)
        {
            this.databse = database;
            this.DataSet = set;
    
        }


        public void SupplyForm(GenericFormApi form, GenericFormOptions formOptions)
        {
            editMode = EditMode.Add;
            this.api = form;
            BindOptionComponent(formOptions);
            BindStandardComponent(form);
            
           



        }


        public void BindStandardComponent(GenericFormApi form) {
            form.SubmitButton.Click += submitButton_Click;
            form.ListBoxView.SelectedIndexChanged += generalListBox_SelectedIndexChanged;
            form.AddRadio.Click += addRadio_CheckedChanged;
            form.UpdateRadio.Click += updateRadioBut_CheckedChanged;
            form.DeleteRadio.Click += deleteRadioBut_CheckedChanged;
            form.ListBoxView.DataSource = DataSet.ToList();
        }

        public abstract void BindOptionComponent(GenericFormOptions form);



     
        public void EnableCrud() {
            Enabled = true;
            EnableComponents();
        }

        public void DisableCrud()
        {
            Enabled = false;
            DisableComponents();
           
        }

    


        public abstract void EnableComponents();

        public abstract void DisableComponents();

        public abstract void SubmitAdd();

        public abstract void SubmitUpdate();

        public abstract void SubmitDelete();

        public abstract void SelectItem(object item);

        public virtual void SaveChanges() {
            databse.SaveChanges();
            api.ListBoxView.DataSource = DataSet.ToList();
        }

        public void updateButton()
        {
            switch (editMode)
            {
                case EditMode.Add:
                    {
                        api.SubmitButton.Text = "Add";
                    }
                    break;


                case EditMode.Delete:
                    {
                        api.SubmitButton.Text = "Delete";
                    }
                    break;

                case EditMode.Update:
                    {
                        api.SubmitButton.Text = "Update";
                    }
                    break;

            }
        }

        public void addRadio_CheckedChanged(object sender, EventArgs e)
        {
            editMode = EditMode.Add;
            updateButton();
        }

        public void updateRadioBut_CheckedChanged(object sender, EventArgs e)
        {
            editMode = EditMode.Update;
            updateButton();
        }

 
        public void deleteRadioBut_CheckedChanged(object sender, EventArgs e)
        {
            editMode = EditMode.Delete;
            updateButton();
        }

        public void submitButton_Click(object sender, EventArgs e)
        {

         

            if (editMode == EditMode.Add)
            {

                SubmitAdd();

                /* String name = nameTextBox.Text;
                 nameTextBox.Text = "";
                 Department dept = new Department() { Name = name };
                 database.Departments.Add(dept);
                 database.SaveChanges();
                 generalListBox.DataSource = database.Departments.ToList();*/
            }
            else if (editMode == EditMode.Delete)
            {

                SubmitDelete();

                /*Department dept = (Department)generalListBox.SelectedItem;
                String name = nameTextBox.Text;
                nameTextBox.Text = "";
                database.Departments.Remove(dept);
                database.SaveChanges();
                generalListBox.DataSource = database.Departments.ToList();*/
            }
            else if (editMode == EditMode.Update)
            {

                SubmitUpdate();

                /* Department dept = (Department)generalListBox.SelectedItem;
                 String name = nameTextBox.Text;
                 dept.Name = name;
                 database.Departments.Remove(dept);
                 database.SaveChanges();
                 generalListBox.DataSource = database.Departments.ToList();*/
            }
        }

        public void generalListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
             SelectItem(api.ListBoxView.SelectedItem);
            // Department dept = (Department)generalListBox.SelectedItem;
            // nameTextBox.Text = dept.Name;
        }


    }
}
