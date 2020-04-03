using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database.CrudTests;

namespace Database
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //Shhhhhhhhh did u know that triple slashes have a different color than double slashes
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EditForm2());
        }

    }

}
