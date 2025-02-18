using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.program;

namespace ConsoleApp1
{
    internal class Estudiante
    {
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public int Edad {  get; private set; }
        public double Promedio { get; private set; }
        public string Matricula { get; private set; }


        public Estudiante(string nombre, string apellido, int edad, double promedio)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Promedio = promedio;
            Matricula = GenerarMatricula(nombre, edad, apellido);
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


    }

}
