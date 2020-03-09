using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Card_Game
{
    public static class FileHandler
    {
        public static List<string> GetFileContentAsList(string filePath)
        {
            StreamReader reader = new StreamReader(File.OpenRead(filePath));
            List<string> data = new List<string>();
            string line;

            while (reader.EndOfStream)
            {
                line = reader.ReadLine();
                data.Add(line);
            }

            return data;
        }
    }
}
