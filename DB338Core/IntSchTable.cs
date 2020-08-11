using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB338Core
{
    class IntSchTable
    {

        private string name;

        private List<IntSchColumn> columns;

        private List<Dictionary<string, object>> rows;


        public IntSchTable(string initname)
        {
            name = initname;
            columns = new List<IntSchColumn>();
        }

        public string Name { get => name; set => name = value; }
        public List<IntSchColumn> Columns { get => columns; set => columns = value; }


        public string[,] Select(List<string> cols)
        {
            string[,] results = new string[columns[0].items.Count, cols.Count];

            if (cols[0] == "*")
            {
                results = new string[columns[0].items.Count, columns.Count];
                for (int j = 0; j < columns.Count; ++j)
                {
                    for (int z = 0; z < columns[0].items.Count; ++z)
                    {
                        results[z, j] = columns[j].items[z];

                    }
                }
                return results;
            }


            for (int i = 0; i < cols.Count; ++i)
            {
                for (int j = 0; j < columns.Count; ++j)
                {
                    if (cols[i] == columns[j].Name)
                    {
                        for (int z = 0; z < columns[0].items.Count; ++z)
                        {
                            results[z, i] = columns[j].items[z];
                        }
                    }
                }
            }

            return results;
        }

        public bool Project()
        {
            throw new NotImplementedException();
        }

        public void Insert(List<string> cols, List<string> vals)
        {
            for (int i = 0; i < cols.Count; ++i)
            {
                for (int j = 0; j < columns.Count; ++j)
                {
                    if (columns[j].Name == cols[i])
                    {
                        columns[j].items.Add(vals[i]);
                    }
                }
            }
        }

        public bool AddColumn(string name, string type)
        {
            foreach (IntSchColumn col in columns)
            {
                if (col.Name == name)
                {
                    return false;
                }
            }

            columns.Add(new IntSchColumn(name, type));
            return true;
        }

        public string[,] Update(List<string> cols, List<string> updatedValues)
        {
            string[,] results = new string[columns[0].items.Count, columns.Count];
            for (int i = 0; i < cols.Count; ++i)
            {
                for (int j = 0; j < columns.Count; ++j)
                {
                    if (cols[i] == columns[j].Name)
                    {
                        for (int z = 0; z < columns[0].items.Count; ++z)
                        {
                            results[z, i] = columns[j].items[z];
                        }
                    }
                }
            }

            return results;
        }
    }


}
