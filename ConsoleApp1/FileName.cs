using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            GrupoEstudiantes<Estudiante> Grupo1 = new GrupoEstudiantes<Estudiante>();
            Grupo1.EventoAgregarEstudiantes += MetodoAgEstudiante;



        }




    }
}
