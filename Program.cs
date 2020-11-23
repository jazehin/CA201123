using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA201123
{
    class Program
    {
        struct Termek
        {
            public string Nev;
            public int Egysegar;
            public int Keszlet;
            public string Szallito;

            public Termek(string nev, int egysegar, int keszlet, string szallito)
            {
                Nev = nev;
                Egysegar = egysegar;
                Keszlet = keszlet;
                Szallito = szallito;
            }
        }

        static Random rnd = new Random();
        static void Main(string[] args)
        {
            //F01(Beker(1), Beker(2));
            F02();

            Console.ReadLine();
        }

        private static void F02()
        {
            Console.Write("Adja meg a tömb méretét: ");
            var l = int.Parse(Console.ReadLine());
            Termek[] termekek = new Termek[l];
            for (int i = 0; i < termekek.Length; i++)
            {
                Console.Write($"Adja meg a(z) {i+1}. termék nevét: ");
                termekek[i].Nev = Console.ReadLine();
                termekek[i].Egysegar = rnd.Next(200, 2001);
                termekek[i].Keszlet = rnd.Next(0, 51);
                switch (rnd.Next(1, 5))
                {
                    case 1:
                        termekek[i].Szallito = "Rothschild Rt";
                        break;
                    case 2:
                        termekek[i].Szallito = "Koma Kft";
                        break;
                    case 3:
                        termekek[i].Szallito = "Bendegúz Bt";
                        break;
                    case 4:
                        termekek[i].Szallito = "Papa&Mama Bt";
                        break;
                }
            }

            int mini = 0;
            for (int i = 1; i < termekek.Length; i++)
            {
                if (termekek[mini].Egysegar > termekek[i].Egysegar) mini = i;
            }
            Console.WriteLine($"A legolcsóbb termék a {termekek[mini].Nev}, egységára {termekek[mini].Egysegar} Ft.");

            int sum = 0;
            foreach (var t in termekek)
            {
                sum += t.Egysegar;
            }
            Console.WriteLine($"Az átlagos egységár {(double)sum/termekek.Length:0.00} Ft.");

            Console.Write("Adjon meg egy szállítót: ");
            var sz = Console.ReadLine();
            int c = 0;
            foreach (var t in termekek)
            {
                if (t.Szallito == sz) c++;
            }
            Console.WriteLine($"A {sz} szállítótól {c} db termékfajta érkezett.");

            foreach (var t in termekek)
            {
                if (t.Keszlet < 5) Console.WriteLine($"{t.Nev}-ból/ből kell rendelni {15-t.Keszlet} dbot a {t.Szallito}-tól/től.");
            }
        }

        private static void F01(Termek termek1, Termek termek2)
        {
            Console.WriteLine("a)");
            Console.WriteLine(termek1.Egysegar == termek2.Egysegar ? "A két termék ára azonos" : ($"{(termek1.Egysegar > termek2.Egysegar ? termek1.Nev : termek2.Nev)} a drágább {Math.Abs(termek1.Egysegar - termek2.Egysegar)} forinttal"));

            Console.WriteLine("\nb)");
            if (termek1.Keszlet < 5) Console.WriteLine($"{termek1.Nev}-ból/ből rendelni kell");
            if (termek2.Keszlet < 5) Console.WriteLine($"{termek2.Nev}-ból/ből rendelni kell");

            Console.WriteLine("\nc)");
            if (termek1.Szallito == termek2.Szallito) Console.WriteLine($"{termek1.Nev} és {termek2.Nev} beszállítója ugyanaz.");
            else Console.WriteLine($"{termek1.Nev} és {termek2.Nev} beszállítója nem ugyanaz.");
        }

        static Termek Beker(int num)
        {
            Console.WriteLine($"Adja meg a {num}. termék adatait: ");
            Console.Write("\tNév: ");
            var n = Console.ReadLine();
            Console.Write("\tEgységár: ");
            var e = int.Parse(Console.ReadLine());
            Console.Write("\tKészlet: ");
            var k = int.Parse(Console.ReadLine());
            Console.Write("\tSzállító: ");
            var sz = Console.ReadLine();

            return new Termek(n, e, k, sz);
        }
    }
}
