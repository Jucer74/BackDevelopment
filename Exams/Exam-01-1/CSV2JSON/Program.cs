using System.IO;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;

Console.WriteLine("CSV2JSON - Convert CSV file to JSON");
Console.WriteLine("-----------------------------------");

Main();

void Main()
{
    // Ruta del archivo CSV
    string inputFileCsv = "./Data/DATA.csv";
    string outputFileJson = "./Data/DATA.json";

    // Leer el archivo CSV
    using (TextFieldParser parser = new TextFieldParser(inputFileCsv))
    {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        
        // Leer los datos del archivo CSV
        string[] headers = parser.ReadFields();
        string[][] rows = new string[0][];
        while (!parser.EndOfData)
        {
            string[] row = parser.ReadFields();
            Array.Resize(ref rows, rows.Length + 1);
            rows[rows.Length - 1] = row;
        }

        // Convertir los datos a JSON
        var jsonObject = new { data = rows };
        string json = JsonConvert.SerializeObject(jsonObject);
        
        // Imprimir el resultado
        Console.WriteLine(json);

        using (TextWriter writer = new StreamWriter(outputFileJson))
        {
            writer.WriteLine(json);
        }
    }
}
