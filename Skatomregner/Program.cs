using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skatomregner
{
    class Program
    {
        static void Main(string[] args)
        {   Console.Title = "Skatte beregning";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            double indtjent = 0;
            double skat = 0;
            double udbetalt = 0;
            double fradag = 0;
            double topskat = 0;
            double topskat_ubetalt = 0; 
            string upper = "╔════════════════════════════════════════════════════════════════════════════════════════╗";
            string lower = "╚════════════════════════════════════════════════════════════════════════════════════════╝";
           
            while (true)            
            {
            Console.Clear();
            Console.WriteLine(upper);
            Console.SetCursorPosition(33, 2);

            Console.WriteLine("Indtast månedlig indkomst\n");
            Console.WriteLine(lower);
                while (true)
                {
                    try
                    {
                    indtjent = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        break;
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine(upper);
                        Console.SetCursorPosition(33, 2);
                        Console.WriteLine("Indtast gyldig indkomst\n");
                        Console.WriteLine(lower);
                    }
                } // Slutning af try catch loop

            Console.WriteLine(upper);
            Console.SetCursorPosition(33, 2);

            Console.WriteLine("Indtast skatte procent\n");
            Console.WriteLine(lower);
                while (true)
                {
                    try
                    {
                        skat = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        break;
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine(upper);
                        Console.SetCursorPosition(33, 2);
                        Console.WriteLine("Indtast gyldig skatte procent\n");
                        Console.WriteLine(lower);
                    }
                } // Slutning af try catch loop
                Console.WriteLine(upper);
            Console.SetCursorPosition(28, 2);

            Console.WriteLine("Indtast fradag. (0 hvis ukendt fradag)\n");
            Console.WriteLine(lower);
                while (true)
                {
                    try
                    {
                        fradag = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        break;
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine(upper);
                        Console.SetCursorPosition(33, 2);
                        Console.WriteLine("Indtast gyldig fradag\n");
                        Console.WriteLine(lower);
                    }
                } // Slutning af try catch loop
                Console.WriteLine(upper);
                if (indtjent >= 49348) // Topskat efter første 49348 kr
                {
                    indtjent = (indtjent - fradag) * 0.92; // Indtjent minus AM bidrag
                    udbetalt = indtjent * ((100 - skat) / 100);
                    topskat = (indtjent - 49348) * 0.85; // Udregner skat for topskat mængden
                    topskat_ubetalt = udbetalt + topskat + fradag; // Total ubetaling med topskat

                    Console.SetCursorPosition(15, 2);
                    Console.WriteLine($"Med et AM-bidrag på 8% af kr. for du udbetalt ----- {topskat_ubetalt}kr.\n");
                }
                else //  indkomst er under topskat
                {
                    indtjent = (indtjent - fradag) * 0.92; // indtjent minus AM bidrag
                    udbetalt = indtjent * ((100 - skat) / 100 ) + fradag;

                    Console.SetCursorPosition(15, 2);
                    Console.WriteLine($"Med et AM-bidrag på 8% af kr. for du udbetalt ----- {udbetalt}kr.\n"); // AM-bidrag: 8% af løn efter fradag
                }
            Console.WriteLine(lower);
            Console.WriteLine("Tryk TAB for at afslutte.\nTryk ENTER for ny beregning\n");
                if (Console.ReadKey(true).Key == ConsoleKey.Tab) // ReadKey for TAB
                {
                    Environment.Exit(0); // Lukker programmet
                }                
            }



                                    
        }
    }
}
