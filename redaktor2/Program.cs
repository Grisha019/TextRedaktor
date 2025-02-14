using redaktor2.Controller;
using redaktor2.Model;
using redaktor2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace redaktor2
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var model = new TextModel();
            var view = new TextView();
            var controller = new TextController(model, view);

            Application.Run(view);
        }
    }
}
