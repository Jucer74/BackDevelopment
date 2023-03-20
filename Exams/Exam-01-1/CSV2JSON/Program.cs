using System.IO;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
//-----------------------------------------------------------------------------------------------------------------
const string DEFAULT_DELIMITER = ",";

Console.WriteLine("CSV2JSON - Convert CSV file to JSON");
Console.WriteLine("-----------------------------------");
Main();

void Main()
{
    BuildJSON(  ConvertToJSON( ReadCSV( GetCSVRoute() ) ), SetJSONRoute()  );
}

string GetCSVRoute(){ // Ruta del archivo CSV
    string inputFileCsv = "./Data/DATA.csv";
    return inputFileCsv;
}

List<string[]?> ReadCSV(string inputFileCsv){ //Leer CSV
    try{
        using ( TextFieldParser CsvParser = new TextFieldParser(inputFileCsv) )
        {
            SetCSVDelimiter(CsvParser, DEFAULT_DELIMITER);
            // Leer los datos del archivo CSV
            string[]? headers = CsvParser.ReadFields();
            List<string[]?> rows = LoadCsvData(CsvParser);
            return rows;
        }
    }catch(System.IO.IOException nonFoundCsv){ //Exception thrown if file not found
        Console.WriteLine("Exception caught: {0}", nonFoundCsv);
    }
    return new List<string[]?>(); //return empty list if exception catch, it will create an empty JSON file so delete it
}

void SetCSVDelimiter(TextFieldParser CsvParser, string DEFAULT_DELIMITER) // No se usar Constante como Parametro
{
    CsvParser.TextFieldType = FieldType.Delimited;
    CsvParser.SetDelimiters(DEFAULT_DELIMITER);
}

List<string[]?> LoadCsvData(TextFieldParser CsvParser){
    List<string[]?> rows = new List<string[]?>();
    while (!CsvParser.EndOfData)
        {
            rows.Add( CsvParser.ReadFields() );
        }     
    return rows;
}

string ConvertToJSON(List<string[]?> rows){
    var jsonObject = new { data = rows };
    string json = JsonConvert.SerializeObject(jsonObject);
    return json;
}

string SetJSONRoute(){ // Ruta donde terminará archivo JSON
    string outputFileJson = "./Data/DATA.json";
    return outputFileJson;
}

void BuildJSON(string json, string outputFileJson){
    Console.WriteLine(json);
    using (TextWriter JsonWriter = new StreamWriter(outputFileJson))
    {
        JsonWriter.WriteLine(json);
    }
}