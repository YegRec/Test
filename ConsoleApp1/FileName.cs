using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class program
    {

        public delegate void EstudianteEventHandler<T>(T estudiante);

        public static void MetodoAgEstudiante(Estudiante estudiante)
        {
            Console.WriteLine($"\nSe ha agregado un nuevo estudiante:\n" +
                $"Nombre: {estudiante.Nombre} {estudiante.Apellido}\n" +
                $"Edad: {estudiante.Edad}\n" +
                $"Promedio: {estudiante.Promedio}\n" +
                $"Matricula: {estudiante.Matricula}");
        }
        static void Main(string[] args)
        {
            GrupoEstudiantes<Estudiante> grupo1 = new GrupoEstudiantes<Estudiante>();
            grupo1.EventoAgregarEstudiantes += MetodoAgEstudiante;


            while (true)
            {
                Console.Clear();
                Interfaz.MainMenu();

                try
                {
                    int seleccion = Validaciones.ValidarInt(Console.ReadLine(), 7);
                    switch(seleccion)
                    {
                        case 1:
                            Interfaz.MenuAgregarEstudiante(grupo1);
                            break;
                        case 2:
                            Interfaz.MenuBuscarEstudiante(grupo1);
                            break;
                        case 3:
                            Interfaz.MenuEliminarEstudiante(grupo1);
                            break;
                        case 4:
                            Interfaz.MostrarEstudiantes(grupo1);
                            break;
                        case 5:
                            Interfaz.Guardar(grupo1);
                            break;
                        case 6:
                            Interfaz.Cargar(grupo1);
                            break;
                        case 7:
                            break;
                    }

                    Validaciones.Esperar();
                    if (seleccion == 7)
                    {
                        break;
                    }

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                catch (InvalidOperationException ez)
                {
                    Console.WriteLine($"{ez.Message}");
                }
                catch (Exception z)
                {
                    Console.WriteLine($"Algo salio mal: {z.Message}");
                }

            }

        }




    }
}
