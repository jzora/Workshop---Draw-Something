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
            Console.Write($"Ingrese los caracteres que aparecen en la pantalla: ");
            palabrasInput = Console.ReadLine();

            string rutaArchivo = "palabras.txt";
            PosiblesPalabras genPalabras = new PosiblesPalabras(rutaArchivo);
            List<string> genPalabras1 = genPalabras.Palabras(numCaracteres, palabrasInput);

            Console.WriteLine("Palabras posibles: ");
            foreach (string palabra in genPalabras1)
            {
                Console.WriteLine(palabra);
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

            private bool ContieneLetras(int longitud, string palabraEnArchivo, string letras)
            {
                int letrasEncontradas = 0;

                foreach (char letra in letras)
                {
                    if (palabraEnArchivo.Contains(letra.ToString()))
                    {
                        palabraEnArchivo = palabraEnArchivo.Remove(palabraEnArchivo.IndexOf(letra), 1);
                        letrasEncontradas++;

                        if (letrasEncontradas == longitud)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            //private void GenerarPalabras(string palabra1, string palabra2, List<string> palabrasGen)
            //{
            //    if (string.IsNullOrEmpty(palabra2))
            //    {
            //        palabrasGen.Add(palabra1);
            //        return;
            //    }

            //    foreach (string palabraTxt in palabras)
            //    {
            //        if(palabraTxt.Length == palabra2.Length)
            //        {
            //            string nuevaPalabra = palabraTxt;
            //            for(int i = 0; i  < nuevaPalabra.Length; i++) 
            //            {
            //                if (palabra2[i] != '*')
            //                {
            //                    nuevaPalabra = nuevaPalabra.Substring(0, i) + palabra2[i] + nuevaPalabra.Substring(i + 1);
            //                }
            //            }
            //            palabrasGen.Add(nuevaPalabra);
            //            //string newString = palabra1 + palabraTxt;
            //            //string newString2 = palabra2.Substring(0, 1) + palabra2.Substring(1);
            //            //GenerarPalabras(newString, newString2, palabrasGen);
            //        }
            //    }
            //    //for (int i = 0; i < longPalabra; i++)
            //    //{
            //    //    string newString = palabra1 + palabra2[i];
            //    //    string newString2 = palabra2.Substring(0, i) + palabra2.Substring(i + 1);
            //    //    GenerarPalabras(newString, newString2, palabrasGen);
            //    //}
            //}

            private List<string> CargarPalabras()
            {
                List<string> archivoTxt = new List<string>();
                archivoTxt.AddRange(File.ReadAllLines(archivoPalabras));

                return archivoTxt;
            }

            public void MostrarPalabras(int longitud)
            {
                Console.WriteLine($"Palabras parecidas con longitud {longitud}");

                foreach (string palabra in palabras)
                {
                    if (palabra.Length == longitud)
                    {
                        Console.WriteLine(palabra);
                    }
                }
            }


        }
    }
}

