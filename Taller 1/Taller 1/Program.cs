using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using NHunspell;

namespace Taller_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numCaracteres;
            string palabrasInput;
            numCaracteres = ValidadorPalabras.NumeroCaracteres();
            Console.Write($"Ingrese los {numCaracteres} caracteres que aparecen en la pantalla: ");
            palabrasInput = Console.ReadLine();



            if (palabrasInput.Length != numCaracteres)
            {
                Console.WriteLine("La longitud de la cadena no coincide con el número de caracteres digitados.");
            }

            PosiblesPalabras genPalabras = new PosiblesPalabras();
            List<string> genPalabras1 = genPalabras.Palabras(palabrasInput);

            Console.WriteLine("Palabras posibles: ");
            foreach (string palabras in genPalabras1)
            {
                Console.WriteLine(palabras);
            }
        }

        public static class ValidadorPalabras
        {

            public static int NumeroCaracteres()
            {
                int numChar;

                do
                {
                    Console.Write("Ingrese el número de caracteres de la palabra a adivinar: ");
                } while (!int.TryParse(Console.ReadLine(), out numChar) || numChar <= 0);

                return numChar;
            }
        }

        public class PosiblesPalabras
        {
            public List<string> Palabras(string palabraInput)
            {
                List<string> palabrasGen = new List<string>();
                GenerarPalabras("", palabraInput, palabrasGen);
                return palabrasGen;
            }

            private void GenerarPalabras(string palabra1, string palabra2, List<string> palabrasGen)
            {
                int longPalabra = palabra2.Length;

                if (longPalabra == 0)
                {
                    palabrasGen.Add(palabra1);
                    return;
                }
                for (int i = 0; i < longPalabra; i++)
                {
                    string newString = palabra1 + palabra2[i];
                    string newString2 = palabra2.Substring(0, i) + palabra2.Substring(i + 1);
                    GenerarPalabras(newString, newString2, palabrasGen);
                }
            }
        }
    }
}