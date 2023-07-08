using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace run
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\inject.exe");
            }
            catch { }
            {
                Console.WriteLine("Oops the file inject SPRX was not found\nPress any enter to continue.");
                Console.ReadLine();
            }

            Environment.Exit(0);
        }
    }
}
