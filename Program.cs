using Appccelerate.EventBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SquawkBank.Core;
using Ninject;

namespace SquawkBank
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IKernel kernel = new StandardKernel(new InjectionModules());
            IEventBroker broker = kernel.Get<IEventBroker>();
            PtmManager ptmManager = new PtmManager(broker);

            Application.Run(new Form1());
        }
    }
}
