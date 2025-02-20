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
        public delegate void AgregarEstudianteEventHandler<T>(T estudiante);

        public static void MetodoAgregar(Estudiante estudiante)
        {
            Console.WriteLine($"Nuevo estudiante agregado: {estudiante.Matricula}");
        }
        static void Main(string[] args)
        {
            GrupoEstudiantes<Estudiante> grupo1 = new GrupoEstudiantes<Estudiante>();
            grupo1.EventoAgregarEstudiantes += MetodoAgregar;

            grupo1.CargarArchivoJson();

            grupo1.FiltrarEstudiantes(x => x.Promedio > 1);

            Console.ReadKey();
        }




    }
}
