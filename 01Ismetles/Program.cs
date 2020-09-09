using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Ismetles
{
    class Program
    {

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
                return 1;
            }
            else // Játékos nyer
            {
                return 2;
            }
        }
        static void eredmenykiiras(int gep ,int ember)
        {
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
        static void Main()
        {
            Random vel = new Random();
            string[] lehetoseg = new string[] { "Kő", "Papír", "Olló" };

            int gepValasz = vel.Next(0, 3 );

            int jatekosValasz;

            Console.WriteLine("Kő (0), Papír (1), Olló (2)");
            Console.Write("Válassz: ");
            jatekosValasz = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Gép: {0} --- Játékos: {1}",
                                lehetoseg[gepValasz], lehetoseg[jatekosValasz]
                    );

            eredmenykiiras(gepValasz,jatekosValasz);

            Console.ReadKey();
        }
    }
}
