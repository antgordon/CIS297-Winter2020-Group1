using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseAntony
{

    public enum EditMode
    {
        Add, Update, Delete
    }

    /**
     * Lists components that are integral for any general form
     * 
     * **/
    public interface GenericFormCore
    {

        /**
         * Reads entries in the data table and displays them
         * 
         * **/
       ListBox ListBoxView { get; }

        /**
         * A multi purpose button used to create, update, and delete entries
         * 
         * **/
        Button SubmitButton { get; }

        /**
        * A radio button to switch to add mode 
        */
       RadioButton AddRadio { get; }

        /**
        * A radio button to switch to update mode 
        */
        RadioButton UpdateRadio { get; }

        /**
     * A radio button to switch to delete mode 
     */
        RadioButton DeleteRadio { get; }



    }


    /**
   * Used to denote any addition forms needed to manipulate entries
   * 
   * Form component accessors should be listed in subtypes
   */
    public interface GenericFormOptions { 
    
    }


    /**
    * A helper type can be used with  Listbox to assign custom names to database entiries
    */
    public interface ListboxEntry<T> {
    
        /**
         * Get the name of the entry to display on the list box
         * **/
        String Name { get; }


        /**
         * The actual entry
         * **/
        T Entry { get; }

       
    }
}
