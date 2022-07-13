using System;
using System.Collections.Generic;
using System.IO;

namespace csvCuter
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "/data.csv";
            var data = new Program();
            List<string> Fields = new List<string>
                { "2", "5"};
            data.RemoveColumnByFieldsNames(path, Fields);
        }

        public void RemoveColumnByFieldsNames(string path, List<string> Fields)
        {
            List<string> lines = new List<string>();
            List<int> Index = new List<int>();
            using (StreamReader reader = new StreamReader(path))
            {
                var line = reader.ReadLine();
                List<string> values = new List<string>();
                
                var cols = line.Split(',');
                for (int i = 0; i < cols.Length; i++)
                {
                    for (int w = 0; w < Fields.Count; w++)
                    {
                        if (cols[i] == Fields[w])
                            Index.Add(i);
                    }
                }

                while (line != null)
                {
                    cols = line.Split(',');
                    values.Clear();
                    for (int i = 0; i < cols.Length; i++)
                    {
                        for (int w = 0; w < Fields.Count; w++)
                        {
                            if (i == Index[w])
                                values.Add(cols[i]);
                        }
                    }
                    var newLine = string.Join(",", values);
                    lines.Add(newLine);
                    line = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var line in lines)
                {
                    writer.WriteLine(line);
                }
            }

        }
    }
}
