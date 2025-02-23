Primer ejercicio de este repositorio: (Conceptos avanzados de OOP y Introduccion a GIT)

1. Gestión de Estudiantes con Git
Objetivo: Refuerza OOP, genéricos y LINQ creando un sistema de gestión de estudiantes con control de versiones en Git.

Tareas de programación"
Crea una clase Estudiante con propiedades como Nombre, Edad y Promedio.
Implementa una clase Grupo<T> con una lista de estudiantes y métodos:
AgregarEstudiante(T estudiante)
EliminarEstudiante(string nombre)
ObtenerPromedioGeneral()
FiltrarEstudiantes(Func<T, bool> criterio)

2. Registro de Eventos con Delegados
Objetivo: Implementa eventos y delegados para notificar cuando se agregan nuevos estudiantes.
Tareas de programación:
Agrega un delegate y un event en Grupo<T> llamado OnNuevoEstudianteAgregado.
Dispara el evento cuando se agregue un nuevo estudiante.
Suscribe un método que imprima un mensaje en consola cuando se dispare el evento.

3. Serialización y Deserialización de Datos (JSON)
Objetivo: Practica la persistencia de datos usando JSON.
Tareas de programación:
Agrega la capacidad de guardar la lista de estudiantes en un archivo estudiantes.json.
Implementa un método CargarDesdeJSON() para leer los datos cuando el programa se inicia.
Usa System.Text.Json para la serialización.

4. Implementación de un Repositorio Remoto
Objetivo: Aprender a trabajar con GitHub o GitLab.

5. Resolución de Conflictos
Objetivo: Aprender a resolver conflictos en Git.


Explicado el ejercicio, hay varias características y métodos que quise agregar por mi cuenta, tales como la interfaz y la validación de inputs del usuario. Aquí explicare cada clase y sus métodos:

CLASE ESTUDIANTE:
-	Contiene un constructor “Estudiante()” que acepta los parámetros que necesita un estudiante (nombre, apellido, edad y promedio).
-	MostrarInformacion(): Muestra la información del objeto.
-	GenerarMatricula(): Este metodo se encarga de construir un ID para cada objeto creado, se utiliza el nombre, edad, y apellido. Para su creación el código toma en cuenta si el usuario tiene 1 o mas nombre y 1 o mas apellidos y toma las iniciales de cada uno mas la edad y como agregado el dia en que fue registrado o creado el estudiante.
-	ActualizarPromedio(): Como no es posible actualizar el promedio del estudiante directamente ya que el parámetro es privado, se usa este método si se desea actualizar el promedio de un estudiante. El método recibe un double y lo asigna al valor de Promedio correspondiente al estudiante.

CLASE GRUPO ESTUDIANTE:
-	ListaEstudiantes: Es la lista principal de estudiantes o objetos.
-	AgregarEstudiante(): recibe un estudiante (T) y lo agrega a la lista “ListaEstudiantes”, además invoca el evento que informa cuando se agrega un estudiante.
-	EliminarEstudiante(): Recibe un estudiante (T) y lo elimina de la lista “ListaEstudiantes”.
-	FiltrarEstudiantes(): Este método recibe un Fun<> y devuelve una lista de los estudiantes que cumpla dicha función y muestra su informacion.
-	CargarArchivoJson(): Carga una lista de estudiantes previamente creada en un archivo Json. Luego define la lista de estudiantes “ListaEstudiantes” con el contenido del archivo Json.
-	GuardarArchivoJson(); Guarda la lista de estudiantes “ListaEstudiantes” en un archivo Json.
CLASE VALIDACIONES:
-	ValidarString(): Este método se encarga de validar el input del usuario y verifica que sea correcto. En su overload recibe un numero int para limitar el tama;o del texto o palabra que se desea por parte del usuario.
-	ValidarInt(); Valida que el usuario ingrese un numero entero valido. En su overload recibe otro numero entero que se encarga de verificar que el numero que el usuario haya ingresado no sea mayor a ese numero.

CLASE INTERFAZ:
-	MainMenu(): Es el menú principal donde se muestran las opciones del programa.
-	MenuAgregarEstudiante(): Se encarga de la construcción del objeto estudiante. Pide al usuario la información al mismo tiempo que usa los métodos de la Clase ”Validaciones” para asegurar que los datos ingresados sean correctos.
-	MenuBuscarEstudiante(): Se encarga de buscar un estudiante en especifico usando el ID.
-	MostrarEstudiantes(); Muestra todos los estudiantes de la lista principal de estudiantes. 






