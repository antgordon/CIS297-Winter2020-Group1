using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace DatabaseAntony
{


    /**
     * A general crud handler for a database table.
     * 
     * Handles and connects form compoents to the apporiate behavior 
     * 
     * **/
    public abstract class GenericDatabaseCrud<T> where T : class
    {
        private dboEntities1 databse;
        public GenericFormCore FormCore { get; protected set; }
    


        public EditMode Mode { get; private set; }

        public virtual GenericFormCore Form => FormCore;



        public DbSet<T> DataSet { get; }

        public bool Enabled { get; private set; }


        /**
         * Initializes the crud handler
         * 
         * The paramater form will contain accessors for the basic form layout
         * 
         * The parameter formOptions will contain access for adition form compoenents needed to modify entries
         * 
         * **/
        public GenericDatabaseCrud(dboEntities1 database, DbSet<T> set, GenericFormCore form, GenericFormOptions formOptions)
        {
            this.databse = database;
            this.DataSet = set;
            Mode = EditMode.Add;
            this.FormCore = form;
      

        }


        /**
         * Binds this crud behavior to the form
         * **/
        public void BindStandardComponent() {

            GenericFormCore form = FormCore;
            form.SubmitButton.Click += submitButton_Click;
            form.ListBoxView.SelectedIndexChanged += generalListBox_SelectedIndexChanged;
            form.AddRadio.Click += addRadio_CheckedChanged;
            form.UpdateRadio.Click += updateRadioBut_CheckedChanged;
            form.DeleteRadio.Click += deleteRadioBut_CheckedChanged;
            Form.ListBoxView.DisplayMember = "Name";
            form.ListBoxView.DataSource = ConvertToEntry(DataSet, NameEntry);
        }

        /**
         * Binds this crud behavior to the options forms
         * **/
        public abstract void BindOptionComponent();

        /**
         * unbinds this crud behavior to the form
         * **/
        public void UnbindStandardComponent()
        {
            GenericFormCore form = FormCore;
            form.SubmitButton.Click -= submitButton_Click;
            form.ListBoxView.SelectedIndexChanged -= generalListBox_SelectedIndexChanged;
            form.AddRadio.Click -= addRadio_CheckedChanged;
            form.UpdateRadio.Click -= updateRadioBut_CheckedChanged;
            form.DeleteRadio.Click -= deleteRadioBut_CheckedChanged;
            form.ListBoxView.DataSource = null;
        }


        /**
         * unbinds this crud behavior to the options forms
         * **/
        public abstract void UnbindOptionComponent();

        /**
         * Enables the crud operations and binds all controls
         * **/
        public void EnableCrud() {
            Enabled = true;
            BindOptionComponent();
            BindStandardComponent();
            EnableComponents();
        }

        /**
        * Disables the crud operations and unbinds all controls
           * **/
        public void DisableCrud()
        {
            Enabled = false;
            DisableComponents();
            UnbindOptionComponent();
            UnbindStandardComponent();

        }




        public abstract void EnableComponents();

        public abstract void DisableComponents();

        /**
         * 
         * **/
        public abstract void SubmitAdd();

        public abstract void SubmitUpdate();

        public abstract void SubmitDelete();

        public abstract void SelectItem(ListboxEntry<T> item);

        public ListboxEntry<T> SelectedEntry => FormCore.ListBoxView.SelectedItem as ListboxEntry<T>;

        protected abstract String NameEntry(T entry);

        public virtual void SaveChanges() {
            databse.SaveChanges();
            FormCore.ListBoxView.DataSource = ConvertToEntry(DataSet, NameEntry);
        }

        public void updateButton()
        {
            switch (Mode)
            {
                case EditMode.Add:
                    {
                        FormCore.SubmitButton.Text = "Add";
                    }
                    break;


                case EditMode.Delete:
                    {
                        FormCore.SubmitButton.Text = "Delete";
                    }
                    break;

                case EditMode.Update:
                    {
                        FormCore.SubmitButton.Text = "Update";
                    }
                    break;

            }
        }

        public void addRadio_CheckedChanged(object sender, EventArgs e)
        {
            Mode = EditMode.Add;
            updateButton();
        }

        public void updateRadioBut_CheckedChanged(object sender, EventArgs e)
        {
           Mode = EditMode.Update;
            updateButton();
        }


        public void deleteRadioBut_CheckedChanged(object sender, EventArgs e)
        {
            Mode = EditMode.Delete;
            updateButton();
        }

        public void submitButton_Click(object sender, EventArgs e)
        {



            if (Mode == EditMode.Add)
            {

                SubmitAdd();

                /* String name = nameTextBox.Text;
                 nameTextBox.Text = "";
                 Department dept = new Department() { Name = name };
                 database.Departments.Add(dept);
                 database.SaveChanges();
                 generalListBox.DataSource = database.Departments.ToList();*/
            }
            else if (Mode == EditMode.Delete)
            {

                SubmitDelete();

                /*Department dept = (Department)generalListBox.SelectedItem;
                String name = nameTextBox.Text;
                nameTextBox.Text = "";
                database.Departments.Remove(dept);
                database.SaveChanges();
                generalListBox.DataSource = database.Departments.ToList();*/
            }
            else if (Mode == EditMode.Update)
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
            ListboxEntry<T> entry = SelectedEntry;

            if (entry != null) {
                SelectItem(entry);
            }
     
 
        }

        private class StandardListboxEntry : ListboxEntry<T>
        {


            public StandardListboxEntry(T entry, Func<T, String> conversion) {
                Name = conversion(entry);
                Entry = entry;

            }

            public string Name{get;}

            public T Entry {get;}


        }

        public static IList<ListboxEntry<T>> ConvertToEntry(DbSet<T> set, Func<T, String> conversion)
        {
            Func<T, ListboxEntry<T>> func = (T ent) =>  new StandardListboxEntry(ent, conversion);


            IList<ListboxEntry<T>> lists = new List<ListboxEntry<T>>();
            set.ToList().ForEach(sel=>lists.Add(func(sel)));

            return lists;

        }

     

    }
}
