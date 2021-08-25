using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algoritmos
{
    class Program
    {
        static void Main(string[] args)
        {
            
            void Fibonacci()
            {
                Console.Clear();
                int a, b, i, temp, opcion;

                int cinco = 5;

                Console.WriteLine("Ingrese el número al que someter al algoritmo de Fibonacci");

                try 
                {
                    b = int.Parse(Console.ReadLine());

                    a = b - 1;

                    for (i = 0; i < cinco; i++)
                    {
                        temp = a;
                        a = b;
                        b = temp + a;
                        Console.WriteLine(a);
                    }

                    Console.WriteLine("\n¿Quiere volver al menú anterior?");
                    Console.WriteLine("\nPulse 1 en caso de ser así, sino pulse cualquier otra tecla para cerrar la aplicación.");

                    try
                    {
                        opcion = int.Parse(Console.ReadLine());

                        if (opcion == 1)
                        {
                            Console.Clear();
                            menu();
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                    catch
                    {
                        Environment.Exit(0);
                    }

                }
                catch 
                {
                    Console.WriteLine("Pulse cualquier tecla para volver al menú anterior y esta vez Ingrese un número por favor");
                    fix();
                    Fibonacci();
                }
                
            }

            void Listas()
            {
                Console.Clear();
                int opcion;

                Console.WriteLine("Este es el algoritmo que recibirá un arreglo de listas y posteriormente le mostrará tanto el número más alto dentro de ellas, como la lista con más números de contenido.");
                var ok = Algoritmo1(predeterminadaListas());
                Console.WriteLine("\nLa lista con mayor cantidad de números es: " + String.Join("; ", ok.Item1));
                Console.WriteLine($"\nEl número más alto de las listas es {ok.Item2}");
                Console.WriteLine("\n¿Quiere volver al menú anterior?");
                Console.WriteLine("\nPulse 1 en caso de ser así, sino pulse cualquier otra tecla para cerrar la aplicación.");

                try 
                {
                    opcion = int.Parse(Console.ReadLine());

                    if (opcion == 1)
                    {
                        Console.Clear();
                        menu();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                } 
                catch
                {
                    Environment.Exit(0);
                }
                    
            }

            List<int>[] predeterminadaListas() 
            {
                List<int>[] a = new List<int>[3];
                a[0] = new List<int>(){ 2, 3, 4, 7, 12 };
                a[1] = new List<int>() { 21, 12, 31, 34, 33, 4 };
                a[2] = new List<int>() { 22, 44, 55, 66, 77 };
                return a;
            };
            
             Tuple<List<int>, int> Algoritmo1( List<int>[] a) 
            {
                int aux = 0;
                int validacion = 0;
                int countL = a[0].Count;
                List<int> c = new List<int>();
                foreach (List<int> i in a)
                {
                    if (aux == 0)
                    {
                        aux = i.Max();
                        validacion = aux;
                    }
                    else 
                    {
                        aux = i.Max();
                        if (aux>validacion) 
                        {
                            validacion = aux;
                        };
                    };
                    if (countL < i.Count())
                    {
                        countL = i.Count();
                        c = i;
                    }
                    
                };

                

                return new Tuple<List<int>, int>(c, validacion);
            };


            void fix() 
            {
                Console.ReadLine();
                Console.Clear();
                
            };

            void menu()
            {
                
                Console.WriteLine("¿Qué algoritmo quiere ver?\n1. Algoritmo 1\n2. Algoritmo 2");
                try 
                {
                    int opcion = int.Parse(Console.ReadLine());
                    if (opcion == 1 || opcion == 2)
                    {
                        switch (opcion)
                        {
                            case 1:
                                Listas();
                                break;

                            case 2:
                                Fibonacci();
                                break;
                            default:
                                break;
                        };
                    }
                    else
                    {
                        Console.WriteLine("Pulse cualquier tecla para volver al menú anterior y esta vez  elija una de las dos opciones por favor");
                        fix();
                        menu();
                    }

                }
                catch
                {
                    Console.WriteLine("Pulse cualquier tecla para volver al menú anterior y esta vez Ingrese un número por favor");
                    fix();
                    menu();
                };
                
            }
            menu();
        }
    }
}
