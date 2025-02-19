using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.program;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json.Serialization;

namespace ConsoleApp1
{
    internal class Estudiante
    {
        [JsonInclude]
        public string Nombre { get; private set; }
        [JsonInclude]
        public string Apellido { get; private set; }
        [JsonInclude]
        public int Edad {  get; private set; }
        [JsonInclude]
        public double Promedio { get; private set; }
        [JsonInclude]
        public string Matricula { get; private set; }
        

        public Estudiante(string nombre, string apellido, int edad, double promedio)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Promedio = promedio;
            Matricula = GenerarMatricula(nombre, edad, apellido);
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"\nNombre: {Nombre}\n" +
                $"Apellido: {Apellido}\n" +
                $"Edad: {Edad}\n" +
                $"Promedio: {Promedio}\n" +
                $"Matricula: {Matricula}\n");
        }

        public void ActualizarPromedio(double promedio)
        {
            Promedio = promedio;
        }

        //Generaremos una matricula usando el nombre, edad, apellido y el dia en que
        //el estudiante es registrado.
        private string GenerarMatricula(string nombre, int edad, string apellido)
        {
            return "EST-" + nombre.Substring(0,1) + edad.ToString().Substring(1) + DateTime.Now.Day + DateTime.Now.Year.ToString().Substring(0,2) + apellido.Substring(0,1);
        }

    }

    internal class GrupoEstudiantes<T> where T : Estudiante
    {
        public List<T> ListaEstudiantes { get; private set; } = new List<T>();

        public event AgregarEstudianteEventHandler<T> EventoAgregarEstudiantes;

        public void AgregarEstudiante(T estudiante)
        {
            EventoAgregarEstudiantes?.Invoke(estudiante);
            ListaEstudiantes.Add(estudiante);
        }

        public void EliminarEstudiante(string matricula)
        {
            T estudiante = ListaEstudiantes.FirstOrDefault(x => x.Matricula == matricula);

            if (estudiante != null)
            {
                ListaEstudiantes.Remove(estudiante);
            }
            else
            {
                throw new InvalidOperationException($"El estudiante {matricula} no existe");
            }
        }

        public double ObtenerPromedioGeneral()
        {
            if (ListaEstudiantes.Count == 0)
            {
                throw new InvalidOperationException($"No existen estudiantes");
            }

            return ListaEstudiantes.Sum(x => x.Promedio);
        }

        public void FiltrarEstudiantes(Func<T, bool> Criterio)
        {
            if (!ListaEstudiantes.Any())
            {
                throw new InvalidOperationException("No existen estudiantes");
            }
            else
            {
                ListaEstudiantes.ForEach(x => { if (Criterio(x)) x.MostrarInformacion(); });
            }
        }

        public void CargarArchivoJson()
        {
            string rutaArchivo = Path.Combine(Path.GetTempPath(), "GestionEstudiantes.json");

            if (File.Exists(rutaArchivo))
            {
                var opciones = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    TypeInfoResolver = new DefaultJsonTypeInfoResolver()
                };
                string json = File.ReadAllText(rutaArchivo);
                ListaEstudiantes = JsonSerializer.Deserialize<List<T>>(json, opciones);
                Console.WriteLine("Archivo cargado con exito...");
            }
            else
            {
                Console.WriteLine("Error: no se encontro ningun archivo");
            }
        }

        public void GuardarArchivoJson()
        {
            string rutaArchivo = Path.Combine(Path.GetTempPath(), "GestionEstudiantes.json");

            var opciones = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                IncludeFields = true,
                PropertyNameCaseInsensitive = true,
                TypeInfoResolver = new DefaultJsonTypeInfoResolver()
            };
            string json = JsonSerializer.Serialize(ListaEstudiantes, opciones);
            File.WriteAllText(rutaArchivo, json);
            Console.WriteLine("Archivo guardado con exito...");
        }


    }

}
