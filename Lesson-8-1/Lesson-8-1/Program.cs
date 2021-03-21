using System;
using System.Diagnostics;

namespace Lesson_8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string processNameorId;

            Process[] sysprocess = Process.GetProcesses();

            do
            {
                ListProcess(sysprocess);
                Console.WriteLine("Введите имя процесса или его ID");
                processNameorId = Console.ReadLine();
                Console.Clear();

            } while (SearchProcess(sysprocess, processNameorId).Item1 == false);

            int index = SearchProcess(sysprocess, processNameorId).Item2;
            Console.WriteLine(sysprocess[index]);
            Console.WriteLine("Отменить процесс? Введите Y(Да)/N(Нет)");

            if (Console.ReadLine() == "Y")
            {
                sysprocess[index].Kill();
                ListProcess(sysprocess);
            }
            else
            {
                Console.Clear();
                ListProcess(sysprocess);
            }


        }
        public static void ListProcess(Process[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine($"ID: {a[i].Id} Процесс имя: {a[i].ProcessName}");
            }
        }
        public static Tuple<bool, int> SearchProcess(Process[] a, string name_process)
        {

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].ProcessName == name_process || Convert.ToString(a[i].Id) == name_process)
                {

                    return new Tuple<bool, int>(true, i);

                }
            }
            return new Tuple<bool, int>(true, 0);
        }
    }
}
