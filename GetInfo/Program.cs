using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Для работы c MainSMS необходимо подключить библиотеку mainsms
using System.Net;
using System.IO;

namespace SmsApp
{
    namespace getinfo
    {
        class Program
        {
            static void Main(string[] args)
            {

                string Host = Dns.GetHostName();
                string IP = Dns.GetHostEntry(Host).AddressList[0].ToString();

                int targetDirs;

                string[] getFiles = Directory.GetDirectories(@"c:\");

                string GetDirs(int howmanny)
                {
                    Array.Resize(ref getFiles, howmanny);
                    return string.Join(", ", getFiles);
                }

                if (args.Length == 0)
                {
                    System.Console.WriteLine("Вы не ввели аргументы");
                    Console.WriteLine("Cколько отправить директорий");
                    targetDirs = Int32.Parse(Console.ReadLine());
                }
                else
                {
                    targetDirs = Int32.Parse(args[0]);
                }

                Console.WriteLine(GetDirs(targetDirs) + " IP:" + IP);
            }
        }
    }
}