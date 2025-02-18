Primer ejercicio de este repositorio: (Conceptos avanzados de OOP y Introduccion a GIT)

1. Gestión de Estudiantes con Git
Objetivo: Refuerza OOP, genéricos y LINQ creando un sistema de gestión de estudiantes con control de versiones en Git.

Tareas de programación
Crea una clase Estudiante con propiedades como Nombre, Edad y Promedio.
Implementa una clase Grupo<T> con una lista de estudiantes y métodos:
AgregarEstudiante(T estudiante)
EliminarEstudiante(string nombre)
ObtenerPromedioGeneral()
FiltrarEstudiantes(Func<T, bool> criterio)
Tareas de Git
Inicializa un repositorio (git init).
Crea una rama feature/gestionar-estudiantes y trabaja ahí.
Realiza commits después de cada funcionalidad importante (git commit -m "Agrega método para agregar estudiantes").
Cuando termines, fusiona la rama con main (git merge).
Usa git log para revisar tu historial de cambios.
2. Registro de Eventos con Delegados
Objetivo: Implementa eventos y delegados para notificar cuando se agregan nuevos estudiantes.

Tareas de programación
Agrega un delegate y un event en Grupo<T> llamado OnNuevoEstudianteAgregado.
Dispara el evento cuando se agregue un nuevo estudiante.
Suscribe un método que imprima un mensaje en consola cuando se dispare el evento.
Tareas de Git
Crea una rama feature/eventos-delegados.
Realiza commits después de cada paso importante.
Usa git diff antes de hacer commits para ver qué cambió.
Fusiona la rama con main cuando termines.
3. Serialización y Deserialización de Datos (JSON)
Objetivo: Practica la persistencia de datos usando JSON.

Tareas de programación
Agrega la capacidad de guardar la lista de estudiantes en un archivo estudiantes.json.
Implementa un método CargarDesdeJSON() para leer los datos cuando el programa se inicia.
Usa System.Text.Json para la serialización.
Tareas de Git
Crea una nueva rama feature/guardar-datos-json.
Usa git status para verificar archivos modificados antes de hacer un commit.
Ignora archivos innecesarios con .gitignore (por ejemplo, bin/, obj/).
Usa git reset --soft si necesitas deshacer un commit reciente sin perder cambios.
4. Implementación de un Repositorio Remoto
Objetivo: Aprender a trabajar con GitHub o GitLab.

Tareas de Git
Crea un repositorio en GitHub o GitLab.
Agrega el repositorio remoto con git remote add origin <URL>.
Sube tu código (git push origin main).
Crea una rama feature/nueva-mejora en GitHub y clónala localmente (git checkout).
Agrega una nueva función, haz commit y sube los cambios.
Abre un Pull Request en GitHub/GitLab y fusiona la rama.
5. Resolución de Conflictos
Objetivo: Aprender a resolver conflictos en Git.

Tareas de Git
Modifica el mismo archivo en dos ramas diferentes (feature/a y feature/b).
Intenta fusionarlas con git merge feature/b en feature/a.
Git generará un conflicto, resuélvelo editando el archivo manualmente.
Usa git add y git commit después de resolver el conflicto.
