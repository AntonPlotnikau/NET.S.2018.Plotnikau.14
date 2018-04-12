using System;
using System.Diagnostics;
using System.Threading;
using Timer;

namespace TimerConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            var manager = new TimerManager();
            var firstListener = new Listeners.FirstListener();
            var secondListener = new Listeners.SecondListener();
            var thirdListener = new Listeners.ThirdListener();
            firstListener.Register(manager);
            secondListener.Register(manager);
            thirdListener.Register(manager);
            manager.Notify("Ура!!!", 5000);
            secondListener.Unregister(manager);
            manager.Notify("Свообода!!!", 2000);
            Console.ReadLine();
        }
    }
}
