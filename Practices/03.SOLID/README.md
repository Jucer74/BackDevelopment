# Principios S.O.L.I.D.
En este espacio realizaremos un ejercicio de Inicio a fin en donde aplicaremos todos los principios SOLID a un proyecto de consola desarrollado en .Net Core e implementado en lenguaje C#.

# Qué es S.O.L.I.D.?
Los principios SOLID son una serie de recomendaciones para escribir un mejor código que ayuda a implementar una **alta cohesión** y **bajo acoplamiento**.

Implementar SOLID puede ser una tarea simple o compleja, todo esto dependerá de la práctica pero tenerlos en cuenta desde un comienzo será más fácil de trabajar. La idea es buscar un punto de equilibrio ya que tal vez no todo nuestro proyecto necesite de dichos principios.

Estos principios se llamaron S.O.L.I.D. por sus siglas en inglés:

* **S**: Single responsibility principle o Principio de responsabilidad única (**SRP**).
* **O**: Open/closed principle o Principio de abierto/cerrado (**OCP**).
* **L**: Liskov substitution principle o Principio de sustitución de Liskov (**LSP**).
* **I**: Interface segregation principle o Principio de segregación de la interfaz (**ISP**).
* **D**: Dependency inversion principle o Principio de inversión de dependencia (**DIP**).


## El Proyecto
El proyecto es una sencilla aplicación de consola, con las siguientes opciones:

     S.O.L.I.D. Principles
    ------------------------------
    1. Insert new Employee
    2. Get Employee List
    3. Generate Employees Report
    4. Show Projects
    0. Exit
    Select Option:


Cada una de la opciones realiza acciones sobre una pequeña base de datos SQLite con la siguiente estructura:

![Modelo De Datos](https://github.com/Jucer74/SOLID/blob/develop/Images/SOLIDDB-MER.png)

El proyecto tiene la siguiente estructura:

![Modelo De Datos](https://github.com/Jucer74/SOLID/blob/develop/Images/Project-Structure.png)

Cada folder tiene la versión inicial del proyecto antes de aplicar cada principio (ejemplo: #.1 Principio sin aplicar) la idea es que se tome este proyecto y copie en la cartepa #.2 y se aplique cada principio en esa versión.

Puede crear una rama nueva a partir de la version de **develop** y nombrela segun el siguiente formato:

**Curso-##/1erNombre-1erApellido**

ej: Curso-01/Julio-Robles

Dentro de cada folder se encuentra la explicación de cada principio y la forma de aplicarlo al proyecto.

### Carpetas
- **Common/SqlDatabase**: Librería para realizar las operaciones sobre la base de datos.
- **Images**: Imagenes relacionadas con la explicacion de estos principios.
- **Reports**: Carpeta en donde se generan los reportes de la apliación.
- **SOLIDDatabase**: Carpeta donde se encuentra la base de datos necesaria para ejecutar las opciones de este proyecto.