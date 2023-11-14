using System;
using System.Collections.Generic;
using System.IO;

namespace Taller_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numCaracteres;
            string palabrasInput;
            numCaracteres = ValidadorPalabras.NumeroCaracteres();
            Console.Write($"Ingrese los caracteres que aparecen en la pantalla: ");
            palabrasInput = Console.ReadLine();

            string rutaArchivo = "0_palabras_todas.txt";
            PosiblesPalabras genPalabras = new PosiblesPalabras(rutaArchivo);
            List<string> genPalabras1 = genPalabras.Palabras(numCaracteres, palabrasInput);

            Console.WriteLine("Palabras posibles: ");
            foreach (string palabra in genPalabras1)
            {
                if (palabra.Length == numCaracteres)
                {
                    Console.WriteLine(palabra);
                }
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
            private List<string> palabras;
            private string archivoPalabras;

            public PosiblesPalabras(string archivoPalabras)
            {
                this.archivoPalabras = archivoPalabras;
                palabras = CargarPalabras();
            }

            public List<string> Palabras(int longitud, string letras)
            {
                List<string> palabrasGen = new List<string>();
                GenerarPalabras(longitud, letras, palabrasGen);
                return palabrasGen;
            }

            private void GenerarPalabras(int longitud, string letras, List<string> palabrasGen)
            {
                foreach (string palabraTxt in palabras)
                {
                    if (ContieneLetras(longitud, palabraTxt, letras))
                    {
                        palabrasGen.Add(palabraTxt);
                    }
                }
            }

            private bool ContieneLetras(int longitud, string palabraEnTxt, string letras)
            {
                int letrasEncontradas = 0;

                foreach (char letra in letras)
                {
                    if (palabraEnTxt.Contains(letra.ToString()))
                    {
                        palabraEnTxt = palabraEnTxt.Remove(palabraEnTxt.IndexOf(letra), 1);
                        letrasEncontradas++;

                        if (letrasEncontradas == longitud)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            private List<string> CargarPalabras()
            {
                List<string> archivoTxt = new List<string>();
                archivoTxt.AddRange(File.ReadAllLines(archivoPalabras));
                return archivoTxt;
            }
        }
    }
}

