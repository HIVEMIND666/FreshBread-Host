using FreshBreadHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreshBread_Host
{
    class Program
    {
        //TODO: FIX CMD CMD.CS
        //TODO: FIX STRING SENT TO STUB DURING BUILDING BUILDER.CS
        static void Main(string[] args)
        {
            //start up form

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Main main = new Main();
            Application.Run(main);
        }

    }
}
