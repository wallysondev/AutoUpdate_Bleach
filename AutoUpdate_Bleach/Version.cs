using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdate_Bleach
{
    public class FileVersion
    {
        public string filename;
        public string filepath;
        public short version;

        public FileVersion() 
        {
            this.filename = string.Empty;
            this.filepath = string.Empty;
            this.version = 0;
        }
    }

    public class Version
    {
        public int MaxFiles;
        public FileVersion[] Files;

        public Version()
        {
            // diz o total de arquivos
            MaxFiles = 0;

            // Diz o total de arquivos
            Files = new FileVersion[MaxFiles];

            // Faz a instancia de cada arquivo de download
            for(int i=0; i < MaxFiles; i++)
            {
                Files[i] = new FileVersion();
            }
        }
    }
}

