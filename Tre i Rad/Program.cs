using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tre_i_Rad
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());





            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();

            // skapa en ny modell med rätt antal rader och kolumner
            Model model = new Model();

            // skapa en ny view, i winforms är detta ett Form
            Form1 view = new Form1();

            // skapa en controller som styr både model och view
            Controller controller = new Controller(model, view);

            Application.Run(view);
        }
    }
}
