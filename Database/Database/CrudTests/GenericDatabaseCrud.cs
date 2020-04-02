using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Database.CrudTests
{


    /**
     * A general crud handler for a database table.
     * 
     * Handles and connects form compoents to the apporiate behavior 
     * 
     * **/
    public abstract class GenericDatabaseCrud<T> where T : class
    {
        public CollegeEntities1 Database { get; }

        public GenericFormCore FormCore { get; protected set; }

        public EditMode Mode { get; private set; }

        public DbSet<T> DataSet { get; }

        public bool Enabled { get; private set; }

        public ListboxEntry<T> SelectedEntry => FormCore.ListBoxView.SelectedItem as ListboxEntry<T>;

        /**
         * Initializes the crud handler
         * 
         * The paramater form will contain accessors for the basic form layout
         * 
         * The parameter formOptions will contain access for adition form compoenents needed to modify entries
         * 
         * **/
        public GenericDatabaseCrud(CollegeEntities1 database, DbSet<T> set, GenericFormCore form)
        {
            this.Database = database;
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
            form.ListBoxView.DisplayMember = "Name";
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
        }

        /**
        * Disables the crud operations and unbinds all controls
           * **/
        public void DisableCrud()
        {
            Enabled = false;
            UnbindOptionComponent();
            UnbindStandardComponent();

        }

      
        /**
         * Ran when the user plans to submit an entry into the database with the information in the option components
         */
        public abstract void SubmitAdd();

        /**
       * Ran when the user plans to update an entry into the database with the information in the option components
       */
        public abstract void SubmitUpdate();

        /**
       * Ran when the user plans to delete selected entry
       */
        public abstract void SubmitDelete();

        /**
        * Ran when a entry is slected in the listbox
        */
        public abstract void SelectItem(ListboxEntry<T> item);



        /**
         * Formats the entry so it can display in the listbox
         * **/
        protected abstract ListboxEntry<T> NameEntry(T entry);


        /**
         * Saves all changes to the database and displays changes on the listbox
         * **/
        public virtual void SaveChanges() {
          
            Database.SaveChanges();
            FormCore.ListBoxView.DataSource = ConvertToEntry(DataSet, NameEntry);
         
        }

        public class StandardListboxEntry<A> : ListboxEntry<A> where A : class
        {


            public StandardListboxEntry(A entry, String name)
            {
                Name = name;
                Entry = entry;

            }

            public string Name { get; }

            public A Entry { get; }


        }

        public static IList<ListboxEntry<A>> ConvertToEntry<A>(DbSet<A> set, Func<A, ListboxEntry<A>> conversion) where A:class
        {
            IList<ListboxEntry<A>> lists = new List<ListboxEntry<A>>();
            set.ToList().ForEach(sel => lists.Add(conversion(sel)));

            return lists;

        }



        private void updateSubmitMode()
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
            updateSubmitMode();
        }

        public void updateRadioBut_CheckedChanged(object sender, EventArgs e)
        {
           Mode = EditMode.Update;
            updateSubmitMode();
        }


        public void deleteRadioBut_CheckedChanged(object sender, EventArgs e)
        {
            Mode = EditMode.Delete;
            updateSubmitMode();
        }

        public void submitButton_Click(object sender, EventArgs e)
        {

            if (Mode == EditMode.Add)
            {

                SubmitAdd();
            }
            else if (Mode == EditMode.Delete)
            {

                SubmitDelete();
            }
            else if (Mode == EditMode.Update)
            {

                SubmitUpdate();
            }
        }



        public void generalListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListboxEntry<T> entry = SelectedEntry;

            if (entry != null) {
                SelectItem(entry);
            }
     
 
        }

       

     

    }
}
