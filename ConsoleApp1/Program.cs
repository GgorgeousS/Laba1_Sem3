using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using System.Drawing;
using Ninject;
using ConsoleApp1;


namespace Laba1_Sem3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IKernel ninject = new StandardKernel(new SimpleConfigModule());
            var logic = ninject.Get<ILogic>();
            IConsoleView consoleView = new ConsoleView(logic);
            consoleView.Start();

        }
    }
}
