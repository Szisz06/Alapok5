using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alapok5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kiir();

            Console.WriteLine("Nagyobb : " + Nagyobb(2, 5));

            int[] tomb = Feltolt(10);
            Console.WriteLine();
            ArrayWrite(tomb);

            BubleSort(ref tomb);
            Console.WriteLine($"A rendezett tömb :");
            ArrayWrite(tomb);

            Console.WriteLine("\n Ird be a max elemet");
            int max = int.Parse(Console.ReadLine());
            int[] kisElemek = Collect(tomb, max);
            Console.WriteLine($"A {max} érték alatti számok: ");
            //for (int i = 0; i < kisElemek.Length;  i++)
            //{
            //    Console.WriteLine(kisElemek[i]+"   ");
            //}
            ArrayWrite(kisElemek);

            Console.WriteLine("Palindrom szöveg tesztelő:");
            string text = Console.ReadLine();
            if (Palindrom(text))
            { Console.WriteLine("ez palindrom"); }
            else { Console.WriteLine("ez nem palindrom"); }

            Console.WriteLine("Kérek egy rendszámot XXXX123 formátumban");
            string rendszam = Console.ReadLine();
            Console.WriteLine("Formázott rendszám: ");
            Console.WriteLine(Rendszam(rendszam));



        }
        static void Kiir() { Console.WriteLine("KIÍRÓ"); }
        static int Nagyobb(int x, int y)
        {
            //if (x > y) { return x; } else { return y; } 
            return x < y ? x : y;
        }
        static int[] Feltolt(int n)
        {
            Random rnd = new Random();
            int[] tomb = new int[n];
            for (int i = 0; i < n; i++)
            {
                tomb[i] = rnd.Next(10, 51);
            }
            return tomb;
        }
        static void ArrayWrite(int[] tomb)
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                Console.Write(tomb[i] + "   ");
            }
            Console.WriteLine();

        }
        static int[] Collect(int[] tomb, int max)
        {
            int count = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] < max) { count++; }
            }
            int[] minElements = new int[count];
            int j = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] < max)
                {
                    minElements[j] = tomb[i];
                    j++;
                }
            }
            return minElements;
        }
        static void BubleSort(ref int[] tomb)
        {

            for (int i = tomb.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (tomb[j] > tomb[j + 1])
                    {
                        int puffer = tomb[j];
                        tomb[j] = tomb[j + 1];
                        tomb[j + 1] = puffer;
                    }
                }
            }
        }
        static bool Palindrom(string text)
        {
            string cleanText = "";
            foreach (char c in text.ToLower())
            { if (char.IsLetterOrDigit(c)) { cleanText += c; } }
            bool isPalindrom = true;
            int left = 0;
            int right = cleanText.Length - 1;
            while (left < right)
            {
                if (cleanText[left] != cleanText[right]) { isPalindrom = false; break; }
                left++; right--;
            }
            return isPalindrom;
        }
        static string Rendszam(string lpn)
        {
            //tisztitas
            string cleanedLpn = "";
            int lpnLetterCount = 0;
            int lpnDigitCount = 0;
            foreach (char c in lpn.ToUpper()) {
                if (char.IsLetterOrDigit(c) && lpnLetterCount < 4)
                {
                    cleanedLpn += c;
                    lpnLetterCount++;
                }
                else if (char.IsDigit(c) && lpnDigitCount < 3) {
                    cleanedLpn += c;
                    lpnDigitCount++;
                }
            } if (cleanedLpn.Length < 7)
            {
                return "A megadott rendzsám nem elég hosszú";
            }
            else {
                //XX XX-123
                string formattedPlate = cleanedLpn.Substring(0, 2) + " " + cleanedLpn.Substring(2, 2) + "-" + cleanedLpn.Substring(4, 3);
                return formattedPlate;
                                       
            }

        }

    }
}
// kód rendezése : Ctrl + K, majd Ctrl + D