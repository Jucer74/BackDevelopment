# Técnicas de Depuración

En esta sesión se describe cómo utilizar las clases de seguimiento y depuración. Estas clases están disponibles en Microsoft .NET Framework. Puede utilizar estas clases para proporcionar información sobre el rendimiento de una aplicación durante el desarrollo de aplicación o después de la implementación en producción. Estas clases son sólo una parte de las características de instrumentación que están disponibles en .NET Framework.

## Ejemplo usando la clase DEBUG

- Inicie Visual Studio y en la terminal cree una nueva aplicacion de consola llamada **Debugging**.
- Agregue el siguiente espacio de nombres en parte superior en **Program.cs**.

``` csharp
using System.Diagnostics;
```

- Para inicializar variables que contienen información acerca de un producto, agregue las siguientes instrucciones de declaración de método **Main** :

``` csharp
string sProdName = "Widget";
int iUnitQty = 100;
double dUnitCost = 1.03;
```

- Especifique el mensaje que genera la clase como primer parámetro de entrada del método **WriteLine**. Presione la combinación de teclas CTRL + ALT + A para asegurarse de que está visible la ventana Resultados.

``` csharp
Debug.WriteLine("Debug: Iniciando depuracion de producto");
```

- Para mejorar la legibilidad, utilice el método sangría para aplicar sangría mensajes posteriores en la ventana resultados:

``` csharp
Debug.Indent();
```

- Para mostrar el contenido de variables seleccionadas, utilice el método WriteLine como sigue:

``` csharp
Debug.WriteLine("El Nombre del producto es: " + sProdName);
Debug.WriteLine("El numero de unidades es: " + iUnitQty.ToString());
Debug.WriteLine("El valor por unidad es: " + dUnitCost.ToString());
``` 
- También puede utilizar el método **WriteLine** para mostrar el espacio de nombres y el nombre de clase para un objeto existente. Por ejemplo, el código siguiente muestra el espacio de nombres de System.Xml.XmlDocument en la ventana resultados:

``` csharp
System.Xml.XmlDocument oxml = new System.Xml.XmlDocument();
Debug.WriteLine(oxml);
```

- Para organizar el resultado, puede incluir un parámetro de categoría como opcional, segunda entrada del método **WriteLine**. Si especifica una categoría, el formato de la información del mensaje de ventana es "categoría: mensaje." Por ejemplo, la primera línea del código siguiente se muestra "campo: el nombre del producto será Widget" en la salida de ventana:

``` csharp
Debug.WriteLine("El Nombre del producto es: " + sProdName,"Categoria:");
Debug.WriteLine("El numero de unidades es: " + iUnitQty.ToString(),"Categoria:");
Debug.WriteLine("El valor por unidad es: " + dUnitCost.ToString(), "Categoria:");
Debug.WriteLine ("El Costo total es:" + (iUnitQty \* dUnitCost),"Calculo");
``` 

- La ventana Resultados puede mostrar mensajes sólo si una condición designada se evalúa como true mediante el método WriteLineIf de la clase Debug . La condición que se va a evaluar es el primer parámetro del método WriteLineIf de entrada. El segundo parámetro de WriteLineIf es el mensaje que sólo aparece si la condición en el primer parámetro se evalúa como true.

``` csharp
Debug.WriteLineIf(iUnitQty >; 50, "Este mensaje si aparecera");
Debug.WriteLineIf(iUnitQty < 50, "Este mensaje NO aparecera");
```

- Utilizar el método Assert de la clase Debug para que la ventana Resultados muestra el mensaje sólo si una condición especificada se evalúa como false:

``` csharp
Debug.Assert(dUnitCost >; 1, "Este mensaje no aparecera");
Debug.Assert(dUnitCost< 1, "Este mensaje aparece si dUnitcost < 1 es falso");

```
- Crear los objetos TextWriterTraceListener para la ventana de consola (tr1) y un archivo de texto denominado output.txt (tr2) y, a continuación, agregue cada objeto a la colección Listeners depurar :

``` csharp
TextWriterTraceListener tr1 = newTextWriterTraceListener(System.Console.Out);
Debug.Listeners.Add(tr1);
TextWriterTraceListener tr2 = new
TextWriterTraceListener(System.IO.File.CreateText("Output.txt"))
Debug.Listeners.Add(tr2);
``` 

- Para mejorar la legibilidad, utilice el método Quitar sangría para quitar la sangría para los mensajes posteriores que genera la clase Debug . Cuando se utiliza la sangría y los métodos de Quitar sangría juntos, el lector puede distinguir los resultados como grupo.

``` csharp
Debug.Unindent();
Debug.WriteLine("Debug: Finaliza la informacion de producto");
``` 

-Para asegurarse de que cada objeto de escucha recibe todo su salida, llamar al método Flush para los búferes de clase Debug :

``` csharp
Debug.Flush();
``` 

## Descripción de la Técnica

Cuando ejecute un programa, puede utilizar métodos de la clase **Debug** para generar los mensajes que le ayudarán a supervisar la secuencia de ejecución de programa, para detectar errores de funcionamiento o para proporcionar información de la medida de rendimiento. De forma predeterminada, los mensajes que genera la clase **Debug** aparecen en la ventana de resultados de Visual Studio entorno de desarrollo integrado (IDE).

El código de ejemplo utiliza el método **WriteLine** para producir un mensaje seguido de un terminador de línea. Cuando utiliza este método para generar un mensaje, cada mensaje aparece en una línea independiente en la ventana Resultados.

Cuando se utiliza el método **Assert** de la clase **Debug** , la ventana Resultados muestra un mensaje sólo si una condición especificada se evalúa como false. El mensaje también aparece en un cuadro de diálogo modal al usuario. El cuadro de diálogo incluye el mensaje, el nombre del proyecto y el número de instrucción Debug.Assert . El cuadro de diálogo también incluye los botones de tres comandos siguientes:

- **Anular** : La aplicación deja de ejecutarse.
- **Reintentar** : La aplicación entra en modo de depuración.
- **Omitir** : La aplicación continúa.

El usuario debe hacer clic en uno de estos botones antes la aplicación puede continuar.

También puede dirigir resultados de la clase Debug a destinos distinto de la ventana Resultados. La clase Debug tiene una colección denominada Listeners incluye objetos de escucha.

Cada objeto de escucha supervisa la salida de depuración y dirige el resultado a un destino especificado.

Cada escucha en la colección de escucha recibe ningún resultado que genera la clase Debug . Utilice la clase TextWriterTraceListener para definir objetos de escucha . Puede especificar el destino de una clase TextWriterTraceListener a través de su constructor.

Algunos destinos de salida posibles incluyen:

- La ventana de consola mediante la propiedad System.Console.Out .
- Un archivo de texto (.txt) mediante la instrucción System.IO.File.CreateText("FileName.txt") .

Después de crear un objeto TextWriterTraceListener , debe agregar el objeto a la colección Debug.Listeners para recibir resultados.

## Mediante la Clase de Seguimiento

También puede utilizar la clase Trace para generar mensajes de ese monitor la ejecución de una aplicación. Las clases Trace y Debug comparten la mayoría de los mismos métodos para generar, incluidos los siguientes:

- WriteLine
- WriteLineIf
- Aplicar sangría
- Quitar sangría
- Assert
- Vaciar

Puede utilizar el seguimiento y las clases **Debug** por separado o conjuntamente en la misma aplicación. En un proyecto de configuración de soluciones de **Debug** y **Trace** y Debug salida están activas. El proyecto genera resultados de ambas de estas clases a todos los objetos de escucha. Sin embargo, un proyecto de configuración de soluciones de versión sólo genera resultados de una clase de seguimiento. El proyecto de configuración de soluciones de versión omite cualquier invocación de método de clase Debug.


``` csharp
Trace.WriteLine("Trace: Iniciando Informacion de Producto");
Trace.Indent();
Trace.WriteLine("El nombre del producto es:"+sProdName);
Trace.WriteLine("El nombre del producto es:"+sProdName,"Categoria:" );
Trace.WriteLineIf(iUnitQty >; 50, "Este mensaje si aparecera");
Trace.Assert(dUnitCost >; 1, "Este mensaje no aparecera");
Trace.Unindent();
Trace.WriteLine("Trace: Finaliza la informacion de producto");
Trace.Flush();
Console.ReadLine();
``` 

## Comprobar que funciona

- Asegúrese de que Debug es la configuración de la solución actual.
- Si la ventana Explorador de soluciones no está visible, presione la combinación de teclas CTRL + ALT + L para mostrar esta ventana.
- Haga clic con el botón secundario del mouse en **Debugging** y, a continuación, haga clic en Propiedades.
- En el panel izquierdo de la página de propiedad **Debugging** , en la carpeta de configuración, asegúrese de que la flecha apunta a la depuración.

**Nota:** En Visual C# Express Edition, haga clic en Depurar en la página **Debugging**.

- Encima de la carpeta de configuración, en la configuración del cuadro de lista desplegable haga clic en Active (Debug) o depuración y, a continuación, haga clic en Aceptar . En Visual C# professional, haga clic en activo (Depurar) o la depuración en el cuadro de lista desplegable lista de configuración en la página depuración y, a continuación, haga clic en Guardar en el menú archivo.
- Presione CTRL+ALT+O para mostrar la ventana de resultados.
- Presione la tecla F5 para ejecutar el código. Cuando aparece el cuadro de diálogo Error de aserción, haga clic en Omitir.
- En la ventana de consola, presione ENTRAR. Debe finalizar el programa y la ventana de resultados debe muestra el resultado similar al siguiente.

```
Debug: Iniciando depuracion de producto
      El Nombre del producto es: Widget
      El numero de unidades es: 100
      El valor por unidad es: 1.03
      System.Xml.XmlDocument
      Categoria: El Nombre del producto es: Widget
      Categoria: El numero de unidades es: 100
      Categoria: El valor por unidad es: 1.03
      Calculo: El Costo total es: 103
    Este mensaje si aparecera
          ---- DEBUG ASSERTION FAILED ----
  ---- Assert Short Message ----
            Este mensaje aparece si dUnitcost < 1 es falso
            ---- Assert Long Message ----
            at Class1.Main(String[] args)  <%Path%>\class1.cs(34)

    El Nombre del producto es: Widget
      El numero de unidades es: 100
      El valor por unidad es: 1.03
Debug: Finaliza la informacion de producto
Trace: Iniciando Informacion de Producto
    El nombre del producto es: Widget
    Categoria: El nombre del producto es: Widget
           Este mensaje si aparecerá
           Trace: Finaliza la informacion de producto

```
- La ventana de consola y el archivo Output.txt deben mostrar el siguiente resultado:

```
El Nombre del producto es: Widget
El numero de unidades es: 100
El valor por unidad es: 1.03
Debug: Finaliza la informacion de producto
Trace: Iniciando Informacion de Producto
El nombre del producto es: Widget
Categoria: El nombre del producto es: Widget
Este mensaje si aparecerá
Trace: Finaliza la informacion de producto

```

**Nota:** El archivo Output.txt se encuentra en el mismo directorio que el ejecutable Debugging (Debugging.exe). Normalmente, es la carpeta \bin donde se almacena el origen del proyecto

### Codigo Completo

``` csharp
using System;
using System.Diagnostics;
namespace Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            string sProdName = "Widget";
            int iUnitQty = 100;
            double  dUnitCost = 1.03;

            Debug.WriteLine("Debug: Iniciando depuracion de producto");
            Debug.Indent();
            Debug.WriteLine("El Nombre del producto es: " + sProdName);
            Debug.WriteLine("El numero de unidades es: " + iUnitQty.ToString());
            Debug.WriteLine("El valor por unidad es: " + dUnitCost.ToString());

            System.Xml.XmlDocument oxml = new System.Xml.XmlDocument();
            Debug.WriteLine(oxml);

            Debug.WriteLine("El Nombre del producto es: " + sProdName,"Categoria:");
            Debug.WriteLine("El numero de unidades es: " + iUnitQty.ToString(),"Categoria:");
            Debug.WriteLine("El valor por unidad es: " + dUnitCost.ToString(), ”Categoria:");
            Debug.WriteLine ("El Costo total es:" + (iUnitQty * dUnitCost),"Calculo");

            Debug.WriteLineIf(iUnitQty > 50, "Este mensaje si aparecera");
            Debug.WriteLineIf(iUnitQty < 50, "Este mensaje NO aparecera");

            Debug.Assert(dUnitCost > 1, "Este mensaje no aparecera");
            Debug.Assert(dUnitCost< 1, "Este mensaje aparece si dUnitcost < 1 es falso");

            TextWriterTraceListener tr1 = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(tr1);
            TextWriterTraceListener tr2 = new TextWriterTraceListener(System.IO.File.CreateText("Output.txt"))
            Debug.Listeners.Add(tr2);

            Debug.WriteLine("El Nombre del producto es: " + sProdName);
            Debug.WriteLine("El numero de unidades es: " + iUnitQty.ToString());
            Debug.WriteLine("El valor por unidad es: " + dUnitCost.ToString());
            Debug.Unindent();
            Debug.WriteLine("Debug: Finaliza la informacion de producto");
            Debug.Flush();

            Trace.WriteLine("Trace: Iniciando Informacion de Producto");
            Trace.Indent();

            Trace.WriteLine("El nombre del producto es:”+sProdName);
            Trace.WriteLine("El nombre del producto es:"+sProdName,"Categoria:" );
            Trace.WriteLineIf(iUnitQty > 50, "Este mensaje si aparecera");
            Trace.Assert(dUnitCost > 1, "Este mensaje no aparecera");

            Trace.Unindent();
            Trace.WriteLine("Trace: Finaliza la informacion de producto");

            Trace.Flush();

            Console.ReadLine();
        }
    }
}
``` 
## Solucionar Problemas

- Si el tipo de configuración de solución es la versión , se omite el resultado de clase Debug.
- Después de crear una clase TextWriterTraceListener para un destino concreto, TextWriterTraceListener recibe resultados de la traza y las clases de depuración . Esto ocurre independientemente de si utiliza el método Add de la traza o la clase Debug para agregar TextWriterTraceListener a la clase de escuchas .
- Si agrega un objeto de escuchas para el mismo destino en el seguimiento y las clases Debug , se duplica cada línea de salida, independientemente de si Debug o seguimiento genera el resultado.

``` csharp
TextWriterTraceListener myWriter = new TextWriterTraceListener(System.Console.Out);
Debug.Listeners.Add(myWriter);
TextWriterTraceListener myCreator = new TextWriterTraceListener(System.Console.Out);
Trace.Listeners.Add(myCreator);
``` 

### Referencias

[http://support.microsoft.com/kb/815788](http://support.microsoft.com/kb/815788)
