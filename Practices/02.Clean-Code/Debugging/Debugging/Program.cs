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
            Debug.WriteLine("El valor por unidad es: " + dUnitCost.ToString(), "Categoria:");
            Debug.WriteLine ("El Costo total es:" + (iUnitQty * dUnitCost),"Calculo");

            Debug.WriteLineIf(iUnitQty > 50, "Este mensaje si aparecera");
            Debug.WriteLineIf(iUnitQty < 50, "Este mensaje NO aparecera");

            Debug.Assert(dUnitCost > 1, "Este mensaje no aparecera");
            Debug.Assert(dUnitCost< 1, "Este mensaje aparece si dUnitcost < 1 es falso");
            TextWriterTraceListener myWriter = new TextWriterTraceListener(System.Console.Out);

            //solucion de problemas
            Debug.Listeners.Add(myWriter);
            TextWriterTraceListener myCreator = new TextWriterTraceListener(System.Console.Out);
            Trace.Listeners.Add(myCreator);

            // TextWriterTraceListener tr1 = new TextWriterTraceListener(System.Console.Out);
            // Debug.Listeners.Add(tr1);
            // TextWriterTraceListener tr2 = new TextWriterTraceListener(System.IO.File.CreateText("Output.txt"));
            // Debug.Listeners.Add(tr2);

            Debug.WriteLine("El Nombre del producto es: " + sProdName);
            Debug.WriteLine("El numero de unidades es: " + iUnitQty.ToString());
            Debug.WriteLine("El valor por unidad es: " + dUnitCost.ToString());
            Debug.Unindent();
            Debug.WriteLine("Debug: Finaliza la informacion de producto");
            Debug.Flush();

            Trace.WriteLine("Trace: Iniciando Informacion de Producto");
            Trace.Indent();

            Trace.WriteLine("El nombre del producto es:"+sProdName);
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