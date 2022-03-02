# Técnicas de Depuración

En esta sesión se describe cómo utilizar las clases de seguimiento y depuración. Estas clases están disponibles en Microsoft .NET Framework. Puede utilizar estas clases para proporcionar información sobre el rendimiento de una aplicación durante el desarrollo de aplicación o después de la implementación en producción. Estas clases son sólo una parte de las características de instrumentación que están disponibles en .NET Framework.

## Ejemplo usando la clase DEBUG

1. Inicie Visual Studio o Visual C# Express.
2. Cree un nuevo proyecto de aplicación de consola denominado **Debugging**.
3. Agregue el siguiente espacio de nombres en parte superior en **Program.cs**.

``` csharp
using System.Diagnostics;
```

1. Para inicializar variables que contienen información acerca de un producto, agregue las siguientes instrucciones de declaración de método **Main** :

string sProdName = &quot;Widget&quot;;

int iUnitQty = 100;

double dUnitCost = 1.03;

1. Especifique el mensaje que genera la clase como primer parámetro de entrada del método **WriteLine**. Presione la combinación de teclas CTRL + ALT + A para asegurarse de que está visible la ventana Resultados.

Debug.WriteLine(&quot;Debug: Iniciando depuracion de producto&quot;);

1. Para mejorar la legibilidad, utilice el método sangría para aplicar sangría mensajes posteriores en la ventana resultados:

Debug.Indent();

1. Para mostrar el contenido de variables seleccionadas, utilice el método WriteLine como sigue:

Debug.WriteLine(&quot;El Nombre del producto es: &quot; + sProdName);

Debug.WriteLine(&quot;El numero de unidades es: &quot; + iUnitQty.ToString());

Debug.WriteLine(&quot;El valor por unidad es: &quot; + dUnitCost.ToString());

1. También puede utilizar el método **WriteLine** para mostrar el espacio de nombres y el nombre de clase para un objeto existente. Por ejemplo, el código siguiente muestra el espacio de nombres de System.Xml.XmlDocument en la ventana resultados:

System.Xml.XmlDocument oxml = new System.Xml.XmlDocument();

Debug.WriteLine(oxml);

1. Para organizar el resultado, puede incluir un parámetro de categoría como opcional, segunda entrada del método **WriteLine**. Si especifica una categoría, el formato de la información del mensaje de ventana es &quot;categoría: mensaje.&quot; Por ejemplo, la primera línea del código siguiente se muestra &quot;campo: el nombre del producto será Widget&quot; en la salida de ventana:

Debug.WriteLine(&quot;El Nombre del producto es: &quot; + sProdName,&quot;Categoria:&quot;);

Debug.WriteLine(&quot;El numero de unidades es: &quot; + iUnitQty.ToString(),&quot;Categoria:&quot;);

Debug.WriteLine(&quot;El valor por unidad es: &quot; + dUnitCost.ToString(), &quot;Categoria:&quot;);

Debug.WriteLine (&quot;El Costo total es:&quot; + (iUnitQty \* dUnitCost),&quot;Calculo&quot;);

1. La ventana Resultados puede mostrar mensajes sólo si una condición designada se evalúa como true mediante el método WriteLineIf de la clase Debug . La condición que se va a evaluar es el primer parámetro del método WriteLineIf de entrada. El segundo parámetro de WriteLineIf es el mensaje que sólo aparece si la condición en el primer parámetro se evalúa como true.

Debug.WriteLineIf(iUnitQty \&gt; 50, &quot;Este mensaje si aparecera&quot;);

Debug.WriteLineIf(iUnitQty \&lt; 50, &quot;Este mensaje NO aparecera&quot;);

1. Utilizar el método Assert de la clase Debug para que la ventana Resultados muestra el mensaje sólo si una condición especificada se evalúa como false:

Debug.Assert(dUnitCost \&gt; 1, &quot;Este mensaje no aparecera&quot;);

Debug.Assert(dUnitCost\&lt; 1, &quot;Este mensaje aparece si dUnitcost \&lt; 1 es falso&quot;);

1. Crear los objetos TextWriterTraceListener para la ventana de consola (tr1) y un archivo de texto denominado output.txt (tr2) y, a continuación, agregue cada objeto a la colección Listeners depurar :

TextWriterTraceListener tr1 = newTextWriterTraceListener(System.Console.Out);

Debug.Listeners.Add(tr1);

TextWriterTraceListener tr2 = new

TextWriterTraceListener(System.IO.File.CreateText(&quot;Output.txt&quot;))

Debug.Listeners.Add(tr2);

1. Para mejorar la legibilidad, utilice el método Quitar sangría para quitar la sangría para los mensajes posteriores que genera la clase Debug . Cuando se utiliza la sangría y los métodos de Quitar sangría juntos, el lector puede distinguir los resultados como grupo.

Debug.Unindent();

Debug.WriteLine(&quot;Debug: Finaliza la informacion de producto&quot;);

1. Para asegurarse de que cada objeto de escucha recibe todo su salida, llamar al método Flush para los búferes de clase Debug :

Debug.Flush();

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
- Un archivo de texto (.txt) mediante la instrucción System.IO.File.CreateText(&quot;FileName.txt&quot;) .

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

Trace.WriteLine(&quot;Trace: Iniciando Informacion de Producto&quot;);

Trace.Indent();

Trace.WriteLine(&quot;El nombre del producto es:&quot;+sProdName);

Trace.WriteLine(&quot;El nombre del producto es:&quot;+sProdName,&quot;Categoria:&quot; );

Trace.WriteLineIf(iUnitQty \&gt; 50, &quot;Este mensaje si aparecera&quot;);

Trace.Assert(dUnitCost \&gt; 1, &quot;Este mensaje no aparecera&quot;);

Trace.Unindent();

Trace.WriteLine(&quot;Trace: Finaliza la informacion de producto&quot;);

Trace.Flush();

Console.ReadLine();

## Comprobar que funciona

1. Asegúrese de que Debug es la configuración de la solución actual.
2. Si la ventana Explorador de soluciones no está visible, presione la combinación de teclas CTRL + ALT + L para mostrar esta ventana.
3. Haga clic con el botón secundario del mouse en **conInfo** y, a continuación, haga clic en Propiedades.
4. En el panel izquierdo de la página de propiedad **conInfo** , en la carpeta de configuración, asegúrese de que la flecha apunta a la depuración.

**Nota:** En Visual C# Express Edition, haga clic en Depurar en la página **conInfo**.

1. Encima de la carpeta de configuración, en la configuración del cuadro de lista desplegable haga clic en Active (Debug) o depuración y, a continuación, haga clic en Aceptar . En Visual C# professional, haga clic en activo (Depurar) o la depuración en el cuadro de lista desplegable lista de configuración en la página depuración y, a continuación, haga clic en Guardar en el menú archivo.
2. Presione CTRL+ALT+O para mostrar la ventana de resultados.
3. Presione la tecla F5 para ejecutar el código. Cuando aparece el cuadro de diálogo Error de aserción, haga clic en Omitir.
4. En la ventana de consola, presione ENTRAR. Debe finalizar el programa y la ventana de resultados debe muestra el resultado similar al siguiente.

Debug: Iniciando depuracion de producto

El Nombre del producto es: Widget

El numero de unidades es: 100

El valor por unidad es: 1.03

System.Xml.XmlDocument

Categoria:El Nombre del producto es: Widget

Categoria:El numero de unidades es: 100

Categoria:El valor por unidad es: 1.03

Calculo: El Costo total es: 103

Este mensaje si aparecera

---- DEBUG ASSERTION FAILED ----

---- Assert Short Message ----

Este mensaje aparece si dUnitcost \&lt; 1 es falso

---- Assert Long Message ----

at Class1.Main(String[] args) \&lt;%Path%\&gt;\class1.cs(34)

El Nombre del producto es: Widget

El numero de unidades es: 100

El valor por unidad es: 1.03

Debug: Finaliza la informacion de producto

Trace: Iniciando Informacion de Producto

El nombre del producto es: Widget

Categoria:El nombre del producto es: Widget

Este mensaje si aparecerá

Trace: Finaliza la informacion de producto

1. La ventana de consola y el archivo Output.txt deben mostrar el siguiente resultado:

El Nombre del producto es: Widget

El numero de unidades es: 100

El valor por unidad es: 1.03

Debug: Finaliza la informacion de producto

Trace: Iniciando Informacion de Producto

El nombre del producto es: Widget

Categoria:El nombre del producto es: Widget

Este mensaje si aparecerá

Trace: Finaliza la informacion de producto

Nota El archivo Output.txt se encuentra en el mismo directorio que el ejecutable conInfo (conInfo.exe). Normalmente, es la carpeta \bin donde se almacena el origen del proyecto

### Codigo Completo

using System;

using System.Diagnostics;

classClass1

{

[STAThread]

static void Main(string[] args)

{

string sProdName = &quot;Widget&quot;;

int iUnitQty = 100;

double dUnitCost = 1.03;

Debug.WriteLine(&quot;Debug: Iniciando depuracion de producto&quot;);

Debug.Indent();

Debug.WriteLine(&quot;El Nombre del producto es: &quot; + sProdName);

Debug.WriteLine(&quot;El numero de unidades es: &quot; + iUnitQty.ToString());

Debug.WriteLine(&quot;El valor por unidad es: &quot; + dUnitCost.ToString());

System.Xml.XmlDocument oxml = new System.Xml.XmlDocument();

Debug.WriteLine(oxml);

Debug.WriteLine(&quot;El Nombre del producto es: &quot; + sProdName,&quot;Categoria:&quot;);

Debug.WriteLine(&quot;El numero de unidades es: &quot; + iUnitQty.ToString(),&quot;Categoria:&quot;);

Debug.WriteLine(&quot;El valor por unidad es: &quot; + dUnitCost.ToString(), &quot;Categoria:&quot;);

Debug.WriteLine (&quot;El Costo total es:&quot; + (iUnitQty \* dUnitCost),&quot;Calculo&quot;);

Debug.WriteLineIf(iUnitQty \&gt; 50, &quot;Este mensaje si aparecera&quot;);

Debug.WriteLineIf(iUnitQty \&lt; 50, &quot;Este mensaje NO aparecera&quot;);

Debug.Assert(dUnitCost \&gt; 1, &quot;Este mensaje no aparecera&quot;);

Debug.Assert(dUnitCost\&lt; 1, &quot;Este mensaje aparece si dUnitcost \&lt; 1 es falso&quot;);

TextWriterTraceListener tr1 = newTextWriterTraceListener(System.Console.Out);

Debug.Listeners.Add(tr1);

TextWriterTraceListener tr2 = newTextWriterTraceListener(System.IO.File.CreateText(&quot;Output.txt&quot;))

Debug.Listeners.Add(tr2);

Debug.WriteLine(&quot;El Nombre del producto es: &quot; + sProdName);

Debug.WriteLine(&quot;El numero de unidades es: &quot; + iUnitQty.ToString());

Debug.WriteLine(&quot;El valor por unidad es: &quot; + dUnitCost.ToString());

Debug.Unindent();

Debug.WriteLine(&quot;Debug: Finaliza la informacion de producto&quot;);

Debug.Flush();

Trace.WriteLine(&quot;Trace: Iniciando Informacion de Producto&quot;);

Trace.Indent();

Trace.WriteLine(&quot;El nombre del producto es:&quot;+sProdName);

Trace.WriteLine(&quot;El nombre del producto es:&quot;+sProdName,&quot;Categoria:&quot; );

Trace.WriteLineIf(iUnitQty \&gt; 50, &quot;Este mensaje si aparecera&quot;);

Trace.Assert(dUnitCost \&gt; 1, &quot;Este mensaje no aparecera&quot;);

Trace.Unindent();

Trace.WriteLine(&quot;Trace: Finaliza la informacion de producto&quot;);

Trace.Flush();

Console.ReadLine();

}

}

## Solucionar Problemas

- Si el tipo de configuración de solución es la versión , se omite el resultado de clase Debug.
- Después de crear una clase TextWriterTraceListener para un destino concreto, TextWriterTraceListener recibe resultados de la traza y las clases de depuración . Esto ocurre independientemente de si utiliza el método Add de la traza o la clase Debug para agregar TextWriterTraceListener a la clase de escuchas .
- Si agrega un objeto de escuchas para el mismo destino en el seguimiento y las clases Debug , se duplica cada línea de salida, independientemente de si Debug o seguimiento genera el resultado.

TextWriterTraceListener myWriter = new TextWriterTraceListener(System.Console.Out);

Debug.Listeners.Add(myWriter);

TextWriterTraceListener myCreator = new TextWriterTraceListener(System.Console.Out);

Trace.Listeners.Add(myCreator);

**Referencias**

[http://support.microsoft.com/kb/815788](http://support.microsoft.com/kb/815788)

16