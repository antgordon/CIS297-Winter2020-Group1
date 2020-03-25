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

    public interface GenericFormApi
    {

       ListBox ListBoxView { get; }

       Button SubmitButton { get; }

       RadioButton AddRadio { get; }

       RadioButton UpdateRadio { get; }

       RadioButton DeleteRadio { get; }



    }

    public interface GenericFormOptions { 
    
    }
}
