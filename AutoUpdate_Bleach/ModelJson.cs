using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AutoUpdate_Bleach
{
    public static class ModelJson
    {
        public static void SaveJSON(string filename, string jsondata)
        {
            // Diz qual diretorio será salvo o arquivo gerado!
            string docPath = Environment.CurrentDirectory.ToString();

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, filename + ".json")))
            {
                outputFile.WriteLine(jsondata);
            }
        }

        public static void SaveJSON(string path, string filename, string jsondata)
        {
            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, filename + ".json")))
            {
                outputFile.WriteLine(jsondata);
            }
        }

        public static string ReadJSON(string filename)
        {
            // Diz qual diretorio será salvo o arquivo gerado!
            string docPath = Environment.CurrentDirectory;

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamReader outputFile = new StreamReader(Path.Combine(docPath, filename + ".json")))
            {
                return outputFile.ReadLine();
            }
        }

        public static string ReadJSON(string path, string filename)
        {
            // Write the string array to a new file named "WriteLines.txt".
            using (StreamReader outputFile = new StreamReader(Path.Combine(path, filename + ".json")))
            {
                return outputFile.ReadLine();
            }
        }
    }
}
