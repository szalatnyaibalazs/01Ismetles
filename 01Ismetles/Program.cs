using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Ismetles
{
    class Program
    {
        static string[] lehetoseg = new string[] { "Kő", "Papír", "Olló" };

        static int gepNyer = 0;
        static int jatekosNyer = 0;
        static int Menet = 0;

        
        static int jatekoValasztas()
        {
            Console.WriteLine("Kő (0), Papír (1), Olló (2)");
            Console.Write("Válassz: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        static int gepValasztas()
        {
            Random vel = new Random();
            return vel.Next(0, 3);
        }
        static int EmberNyer(int gep, int ember)
        {
            if (ember == gep) // Döntetlen
            {
                return 0;
            }
            else if (
                        (ember == 0 && gep == 1)
                        ||
                        (ember == 1 && gep == 2)
                        ||
                        (ember == 2 && gep == 0)
                    ) // Gép nyer
            {
                gepNyer++;
                return 1;
            }
            else // Játékos nyer
            {
                jatekosNyer++;
                return 2;
            }
        }
        static void eredmenykiiras(int gep ,int ember)
        {
            Console.WriteLine("Gép: {0} --- Játékos: {1}",
                    lehetoseg[gep], lehetoseg[ember]
        );
            switch (EmberNyer(gep,ember))
            {
                case 0:
                    Console.WriteLine("Döntetlen!");
                    break;
                case 1:
                    Console.WriteLine("Skynet nyert!");
                    break;
                case 2:
                    Console.WriteLine("Játékos nyert!");
                    break;
            }
        }
        private static bool akarJatszani()
        {
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.Write("Tovább [i/n]?");
            string valasz = Console.ReadLine().ToLower();
            Console.WriteLine("\n-------------------------------------------------------------------------------");
            if (valasz == "i")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main()
        {


            bool tovabb = true;

            while (tovabb)
            {
                Menet++;

                int gepValasz = gepValasztas();

                int jatekosValasz = jatekoValasztas();

                eredmenykiiras(gepValasz, jatekosValasz);

                tovabb = akarJatszani();
            }

            StatisztikaKiiras();

            Console.ReadKey();
        }

        private static void StatisztikaKiiras()
        {
            Console.WriteLine("Menetek száma:{0} " +
                "\nJátékos nyert:{1} " +
                "\nGép nyert:{2}",Menet,jatekosNyer,gepNyer);
        }
    }
}
