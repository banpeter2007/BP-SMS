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
        public string[] szavak;

        public void Beolvasas(string fajlnev)
        {
            szavak = File.ReadAllLines(fajlnev);
        }

        public string leghosszabb_szo()
        {
            string leghosszabb = "";
            foreach (string szo in szavak)
            {
                if (szo.Length > leghosszabb.Length)
                    leghosszabb = szo;
            }
            return leghosszabb;
        }

        public string[] rovid_szavak;

        public void rovidek_mentese()
        {
            var rovidek = new List<string>();
            foreach (string szo in szavak)
            {
                if (szo.Length <= 5)
                    rovidek.Add(szo);
            }
            rovid_szavak = rovidek.ToArray();
        }
    }
    #endregion

    #region Szam-betu szotar
    // Szám-betű szótár
    public class Szam_Betu
    {
        private Dictionary<char, int> szam_betu;

        public Szam_Betu()
        {
            szam_betu = new Dictionary<char, int>()
            {
                { 'A', 2 }, { 'B', 2 }, { 'C', 2 },
                { 'D', 3 }, { 'E', 3 }, { 'F', 3 },
                { 'G', 4 }, { 'H', 4 }, { 'I', 4 },
                { 'J', 5 }, { 'K', 5 }, { 'L', 5 },
                { 'M', 6 }, { 'N', 6 }, { 'O', 6 },
                { 'P', 7 }, { 'Q', 7 }, { 'R', 7 }, { 'S', 7 },
                { 'T', 8 }, { 'U', 8 }, { 'V', 8 },
                { 'W', 9 }, { 'X', 9 }, { 'Y', 9 }, { 'Z', 9 }
            };
        }

        public string szamma_alakit(string szoveg)
        {
            string eredmeny = "";

            foreach (char c in szoveg.ToUpper())
            {
                if (szam_betu.ContainsKey(c))
                    eredmeny += szam_betu[c];  
                else
                    eredmeny += c;                   
            }

            return eredmeny;
        }

        public List<char> szovegge_alakit(int szam)
        {
            List<char> eredmeny = new List<char>();

            foreach (var b in szam_betu)
            {
                if (b.Value == szam)
                    eredmeny.Add(b.Key);
            }

            return eredmeny;
        }
    }
    #endregion

    #region Kódok kiíratása fájlba
    // Kódok kiíratása fájlba
    public class Kodok_Kiirasa
    {
        public void kodok_kiirasa(string fajlnev, string[] szavak, Szam_Betu szam_betu)
        {
            using (StreamWriter sw = new StreamWriter(fajlnev))
            {
                foreach (string szo in szavak)
                {
                    string kod = szam_betu.szamma_alakit(szo);
                    sw.WriteLine($"{kod}");
                }
            }
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
            var szam_betu = new Szam_Betu();

            // 1. feladat
            Console.WriteLine("1. feladat:");
            Console.Write("Adjon meg egy betűt: ");
            string betu = Console.ReadLine();
            Console.WriteLine($"A betű kódja (száma): {szam_betu.szamma_alakit(betu)}");

            Console.WriteLine();

            // 2. feladat
            Console.WriteLine("2. feladat:");
            Console.Write("Adjon meg egy szót: ");
            string szo = Console.ReadLine();
            Console.WriteLine($"A szó számsorrá alakítva: {szam_betu.szamma_alakit(szo)}");

            Console.WriteLine();

            // 3. feladat
            Console.WriteLine("3. feladat:");
            Filebeolvasas filebeolvasas = new Filebeolvasas();
            filebeolvasas.Beolvasas("szavak.txt");
            Console.WriteLine("A szavak beolvasása megtörtént!");

            Console.WriteLine();

            // 4. feladat
            Console.WriteLine("4. feladat:");
            string leghosszabb = filebeolvasas.leghosszabb_szo();
            Console.WriteLine($"A leghosszabb szó a fájlban: {leghosszabb} ({leghosszabb.Length} betű hosszú)");

            Console.WriteLine();

            // 5. feladat
            Console.WriteLine("5. feladat:");
            filebeolvasas.rovidek_mentese();
            int rovid_szavak_szama = filebeolvasas.rovid_szavak.Length;
            Console.WriteLine($"Rövid szavak darab száma: {rovid_szavak_szama}");

            Console.WriteLine();

            // 6. feladat
            Console.WriteLine("6. feladat:");
            var kodok_kiirasa = new Kodok_Kiirasa();
            kodok_kiirasa.kodok_kiirasa("kodok.txt", filebeolvasas.szavak, szam_betu);
            Console.WriteLine("A kódok fájlba írása megtörtént!");

            Console.WriteLine();

            // 7. feladat
            Console.WriteLine("7. feladat:");
            Console.Write("Adjon meg egy számsort: ");
            string keresett_kod = Console.ReadLine();

            List<string> talalatok = new List<string>();

            foreach (string szo2 in filebeolvasas.szavak)
            {
                string kod = szam_betu.szamma_alakit(szo2);

                if (kod == keresett_kod)
                {
                    talalatok.Add(szo2);
                }
            }

            if (talalatok.Count > 0)
            {
                Console.WriteLine("A következő szavak tartoznak ehhez a számsorhoz:");
                foreach (string szo3 in talalatok)
                {
                    Console.WriteLine(szo3);
                }
            }
            else
            {
                Console.WriteLine("Nincs ilyen számsorhoz tartozó szó a gyűjteményben.");
            }

            Console.WriteLine();

            // 8. feladat
            Console.WriteLine("8. feladat:");
            Console.WriteLine("Kódok, amelyekhez több szó is tartozik:");

            var kod_csoportok = filebeolvasas.szavak
                .GroupBy(s => szam_betu.szamma_alakit(s))
                .Where(g => g.Count() > 1)
                .ToList();  // Csak azok a csoportok, ahol több szó van

            foreach (var csoport in kod_csoportok)
            {
                foreach (string szo4 in csoport)
                {
                    Console.Write($"{szo4} : {csoport.Key}; ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            // 9. feladat
            Console.WriteLine("9. feladat:");
            if (kod_csoportok.Any())
            {
                // Kiválasztjuk azt a csoportot, amelyben a legtöbb szó van
                var legtobbszo_csoport = kod_csoportok
                    .OrderByDescending(g => g.Count())
                    .First(); // Ha több csoport azonos, elegendő az első

                Console.WriteLine($"Kódnak megfelelő szó, amiből a legtöbb van: {legtobbszo_csoport.Key}");

                Console.WriteLine("Szavak:");
                foreach (string szo5 in legtobbszo_csoport)
                {
                    Console.WriteLine(szo5);
                }
            }
            else
            {
                Console.WriteLine("Nincs olyan kód, amihez több szó tartozik.");
            }

            Console.WriteLine();
            Console.WriteLine("Kilépéshez nyomja meg az ENTER billentyűt.");
            Console.ReadLine();
        }
    }
}
