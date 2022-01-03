using System;
using System.Threading;

namespace CV19Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main theread";

            var thread = new Thread(ThreadMetod);
            thread.Name = "other thread";
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.AboveNormal;

            thread.Start(42);

            CheckThread();

            for (var i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }

        private static void ThreadMetod(object parameter)
        {
            var value = (int)parameter;
            Console.WriteLine(value);

            CheckThread();

            while (true)
            {
                Thread.Sleep(100);
                Console.Title = DateTime.Now.ToString();
            }
        }

        private static void CheckThread()
        {
            var thread = Thread.CurrentThread;
            Console.WriteLine("id:{0} - {1}", thread.ManagedThreadId, thread.Name);
        }
    }
}
