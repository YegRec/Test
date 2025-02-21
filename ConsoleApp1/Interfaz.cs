using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json.Serialization;

//Clase interfaz maneja todo lo relacionado con interfaz de usuario
//Y requerimientos o muestra de datos
namespace ConsoleApp1
{

    internal static class Interfaz
    {
        public static void MainMenu()
        {
            Console.WriteLine("Bienvenido, por favor selecciona una opcion\n" +
                "1.Agregar estudiante.\n" +
                "2.Buscar estudiante.\n" +
                "3.Eliminar estudiante.\n" +
                "4.Mostrar todos los estudiantes\n" +
                "5.Guardar lista de estudiantes.\n" +
                "6.Cargar lista de estudiantes.\n" +
                "7.[Salir]");
        }

        public static void MenuAgregarEstudiante(GrupoEstudiantes<Estudiante> grupo)
        {
            Console.Clear();
            Console.WriteLine("Ingresa el nombre del estudiante");
            string nombre = Validaciones.ValidarString(Console.ReadLine(), 25).Trim();

            Console.Clear();
            Console.WriteLine("Ingresa el apellido del estudiante");
            string apellido = Validaciones.ValidarString(Console.ReadLine(), 25).Trim();

            Console.Clear();
            Console.WriteLine("Ingresa la edad del estudiante");
            int edad = Validaciones.ValidarInt(Console.ReadLine(), 100);

            Console.Clear();
            Console.WriteLine("Ingresa el promedio del estudiante");
            double promedio = Validaciones.ValidarDouble(Console.ReadLine(), 100);

            Estudiante NuevoEstudiante = new Estudiante(nombre, apellido, edad, promedio);

            if (!grupo.ListaEstudiantes.Exists(x => x.Matricula == NuevoEstudiante.Matricula))
            {
                grupo.AgregarEstudiante(NuevoEstudiante);
            }
            else
            {
                Console.WriteLine("El estudiante ya esta registrado");
            }
            Validaciones.Esperar();
        }

        public static void MenuBuscarEstudiante(GrupoEstudiantes<Estudiante> grupo)
        {
            Console.Clear();
            Console.WriteLine("Ingresa la matricula del estudiante");
            string matricula = Validaciones.ValidarString(Console.ReadLine(), 14);

            Estudiante Resultado = grupo.ListaEstudiantes.Find(x => x.Matricula.ToLower() == matricula.ToLower());

            if (Resultado != null)
            {
                Console.WriteLine($"Estudiante encontrado: ({matricula})");
                Resultado.MostrarInformacion();
            }
            else
            {
                Console.WriteLine($"El estudiante con la matricula {matricula} no existe");
            }
        }

        public static void MenuEliminarEstudiante(GrupoEstudiantes<Estudiante> grupo)
        {
            Console.Clear();
            Console.WriteLine("Ingresa la matricula del estudiante");
            string matricula = Validaciones.ValidarString(Console.ReadLine(), 14);

            Estudiante Resultado = grupo.ListaEstudiantes.Find(x => x.Matricula.ToLower() == matricula.ToLower());

            if (Resultado != null)
            {
                Console.WriteLine($"Estudiante encontrado: ({matricula})");
                Resultado.MostrarInformacion();

                Console.WriteLine("Seguro deceas eliminar el estudiante?\n" +
                    "1. Si\n" +
                    "2. No\n");
                switch (Validaciones.ValidarInt(Console.ReadLine(), 2))
                {
                    case 1:
                        grupo.EliminarEstudiante(Resultado);
                        Console.WriteLine("Estudiante eliminado.");
                        break;
                    case 2:
                        Console.WriteLine("Cancelando operacion...");
                        break;
                    default:
                        Console.WriteLine("Seleccion incorrecta");
                        break;
                }
            }
        }

        public static void MostrarEstudiantes(GrupoEstudiantes<Estudiante> grupo)
        {
            Console.Clear();
            if (grupo.ListaEstudiantes.Any())
            {
                grupo.ListaEstudiantes.ForEach(x => x.MostrarInformacion());
            }
            else
            {
                Console.WriteLine("No existen estudiantes registrados");
            }
        }

        public static void Cargar(GrupoEstudiantes<Estudiante> grupo)
        {
            grupo.CargarArchivoJson();
        }

        public static void Guardar(GrupoEstudiantes<Estudiante> grupo)
        {
            grupo.GuardarArchivoJson();
        }

       //fin 
    }


}