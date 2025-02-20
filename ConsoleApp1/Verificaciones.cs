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
        
        public static int ValidarInt(string numero, int largo)
        {
            //En este metodo verificaremos que el usuario ingrese un numero entero correctamente
            //Ademas de una verificacion adicional para que el numero que el usuario ingrese no sea
            //mayor al valor de largo.
            //EJ: numero = 10, largo = 12. = true.. ya que 10 es menor a 12.
            if (string.IsNullOrEmpty(numero) || int.Parse(numero) > largo || (!int.TryParse(numero, out int c)))
            {
                throw new ArgumentException("El numero ingresado es invalido o nulo");
            }
            return int.Parse(numero);
        }

        public static int ValidarInt(string numero)
        {
            //Este metodo solo verificaremos que el usuario ingrese un numero entero correctamente.
            if (string.IsNullOrEmpty(numero) || !int.TryParse(numero, out int c))
            {
                throw new ArgumentException("El numero ingresado es invalido o nulo");
            }
            return int.Parse(numero);
        }

        public static double ValidarDouble(string numero, double largo)
        {
            //Este metodo funciona igual que ValidarInt solo que con un double en vez de un int.
            if (string.IsNullOrEmpty(numero) || double.Parse(numero) > largo || double.TryParse(numero, out double c))
            {
                throw new ArgumentException("El numero ingresado es invalido o nulo");
            }
            return double.Parse(numero);
        }

    }


}