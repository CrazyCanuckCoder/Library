using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library;

namespace Library.Tests
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //var mainForm = CreateVerifierTestForm();
            var mainForm = CreateVerifierDelegateTestForm();

            Application.Run(mainForm);
        }

        private static Form CreateVerifierTestForm()
        {
            return new TestInputVerifierForm();
        }

        private static Form CreateVerifierDelegateTestForm()
        {
            return new TestInputVerifierDelegateForm();
        }
    }
}
