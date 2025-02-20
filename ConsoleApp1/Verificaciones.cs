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

//Esta clase se encarga de validar todos los datos
//solicitados al usuario y verificar que sean correctos
namespace ConsoleApp1
{

    public static class Validaciones
    {
        //Validar que un string sea correcto y no sobrepase el numero de letras deceado.
        public static string ValidarString(string text, int largo)
        {
            //En este metodo verificaremos si un string es valido y ademas verificaremos o agregaremos
            //otro requisito que sera un numero para asegurarnos que el texto requerido no sobrepase
            //el largo del numero que asignamos.
            // EJ: text = Juguete, largo = 7. = true
            //El texto "Juguete" no tiene mas de 7 letras por lo tanto el metodo retorna true.
            if (string.IsNullOrEmpty(text) || text.Length > largo)
            {
                throw new ArgumentException("El texto ingresado es invalido");
            }
            return text;
        }

        public static string VaidarString(string text)
        {
            //En este metodo overload validaremos solo si el string es valido o no esta vacio
            //no nos importara el tamano del texto o palabra.
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("El texto ingresado es invalido");
            }
            return text;
        }
        

    }


}