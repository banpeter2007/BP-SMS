using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BP_SMS
{
    #region Fájlbeolvasás
    // Fájlbeolvasás
    class Filebeolvasas
    {
        public void Beolvasas(string fajlnev)
        {
            string[] sorok = File.ReadAllLines(fajlnev);
        }
    }
    #endregion
    internal class Program
    {
        #region fejlec
        static void fejlec()
        {
            /*
             BP - SMS
             BP - 10.15.-10.17.
            */

            Type type = typeof(Program);
            string namespaceName = type.Namespace;
            Console.WriteLine(namespaceName);
            for (int i = 0; i < namespaceName.Length; i++) Console.Write('-');
            Console.WriteLine();
        }
        #endregion
        static void Main(string[] args)
        {
            fejlec();

            Filebeolvasas filebeolvasas = new Filebeolvasas();
            filebeolvasas.Beolvasas("szavak.txt");
            Console.WriteLine("A szavak beolvasása megtörtént!");

            Console.WriteLine();
            Console.WriteLine("Kilépéshez nyomja meg az ENTER billentyűt.");
            Console.ReadLine();
        }
    }
}
