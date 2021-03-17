using System;
using System.Diagnostics;

namespace Lesson_8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string processNameorId;
            //string processKill;
            // bool YeNo=f;
            Process[] sysprocess = Process.GetProcesses();
            //Console.WriteLine("Вывод списка процессов");
            //ListProcess(sysprocess);

            do
            {
                ListProcess(sysprocess);
                Console.WriteLine("Введите имя процесса или его ID");
                processNameorId = Console.ReadLine();
                Console.Clear();
                //Console.WriteLine("Процесс не найден");
                //ListProcess(sysprocess);
            } while (SearchProcess(sysprocess, processNameorId) == false);


            Console.WriteLine("Отменить процесс? Введите Y(Да)/N(Нет)");
            //
        }
        public static void ListProcess(Process[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine($"ID: {a[i].Id} Процесс имя: {a[i].ProcessName}");
            }
        }
        public static bool SearchProcess(Process[] a, string name_process)
        {

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].ProcessName == name_process || Convert.ToString(a[i].Id) == name_process)
                {
                    Console.WriteLine(a[i].ProcessName);

                    return true;

                }

            }
            return false;
        }
    }
}
