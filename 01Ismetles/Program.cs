﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        private static void StatisztikaKiiras()
        {
            Console.WriteLine("Menetek száma:{0} " +
                "\tJátékos nyert:{1} " +
                "\tGép nyert:{2}", Menet, jatekosNyer, gepNyer);
        }

        private static void StatisztikaFajlba()
        {
            string adat = Menet.ToString() + ";" +
                jatekosNyer.ToString() + ";" +
                gepNyer.ToString() + ";";
            /*FileStream ki = new FileStream("Statisztika.txt", FileMode.Append);
            StreamWriter sKi = new StreamWriter(ki);
            sKi.WriteLine(adat);*/
            StreamWriter sKi = new StreamWriter("Statisztika.txt", true);
            sKi.WriteLine(adat);
            sKi.Close();
        }
        static void Main()
        {

            statisztikaFajlbol();

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

            StatisztikaFajlba();

            Console.ReadKey();
        }



        private static void statisztikaFajlbol()
        {
            StreamReader stat = new StreamReader("Statisztika.txt");
            while (!stat.EndOfStream)
            {
                string[] sor = stat.ReadLine().Split(';');
                int[] adat = new int[3];
                for (int i = 0; i < adat.Length; i++)
                {
                    adat[i] = int.Parse(sor[i]);
                }
                Console.WriteLine("{0} {1} {2}",adat[0],adat[1],adat[2]);
            }
            stat.Close();
            Console.WriteLine("------------------>Statisztika vége<------------------");
        }
    }
}
