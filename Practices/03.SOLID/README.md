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

![Modelo De Datos](https://github.com/Jucer74/SOLID/blob/main/Images/SOLIDDB-MER.png)

El proyecto tiene la siguiente estructura:

![Directorios](https://github.com/Jucer74/SOLID/blob/main/Images/Project-Structure.png)

Cada folder tiene la descripcion de cada principios y la idea es aplicar los cambios necesarios en el proyecto mejorandolo con la aplicacion de cada principio.

Cree una rama nueva a partir de la version de **main** y nombrela segun el siguiente formato:

**Año-Periodo/Nickname**

- **Año**: Año actual , por ejemplo 2023
- **Periodo**: Se Refiere al semestre actual puede ser 01 o 02
- **Nickname**: Se construye utilizando las siguientes reglas
  - 3 primeras letras del primer Nombre
  - 3 primeras letras del primer apellido
  - 3 primeras letras del segundo apellido
Por ejemplo el nickname de Julio Cesar Robles Uribe, seria julroburi. por consiguiente el nombre de la rama seria:

Nueva Rama: **2023-03/julroburi**

Dentro de cada folder se encuentra la explicación de cada principio y la forma de aplicarlo al proyecto.

### Carpetas
- **Common/SqlDatabase**: Librería para realizar las operaciones sobre la base de datos.
- **Images**: Imagenes relacionadas con la explicacion de estos principios.
- **Reports**: Carpeta en donde se generan los reportes de la apliación.
- **Principles**: Folder que contiene uno a uno los principios que se deben aplicar
- **SOLID.Database**: Carpeta donde se encuentra la base de datos necesaria para ejecutar las opciones de este proyecto.
- **SOLID.Principles**: Proyecto donde se aplicaran los principios