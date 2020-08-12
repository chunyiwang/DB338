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


        public IntSchTable(string initname)
        {
            name = initname;
            columns = new List<IntSchColumn>();
        }

        public string Name { get => name; set => name = value; }
        public List<IntSchColumn> Columns { get => columns; set => columns = value; }


        public string[,] SelectResult(List<string> cols, List<Tuple<string, string, string>> conditions, string logic)
        {
            string[,] results = new string[1, 1];
            float n;
            int rowCount = columns[0].items.Count;
            HashSet<int> indexes = new HashSet<int>();
            var indexVal = Enumerable.Range(0, columns[0].items.Count).ToList();
            foreach(var indexer in indexVal)
            {
                indexes.Add(indexer);
            }


            if (conditions.Count != 0)
            {
                foreach (var condition in conditions)
                {
                    foreach(var col in columns)
                    {
                        if(col.Name == condition.Item1)
                        {
                            bool isNumeric = float.TryParse(col.items[0], out n);
                            if (isNumeric = true)
                            {
                                if (logic == "and")
                                {
                                    if (condition.Item2 == ">")
                                    {

                                        indexes.IntersectWith(col.items.Select((v, i) => new { v, i }).Where(x => float.Parse(x.v) > float.Parse(condition.Item3))
                                            .Select(x => x.i));
                                    }
                                    if (condition.Item2 == "=")
                                    {

                                        indexes.IntersectWith(col.items.Select((v, i) => new { v, i }).Where(x => float.Parse(x.v) == float.Parse(condition.Item3))
                                            .Select(x => x.i));
                                    }
                                    if (condition.Item2 == "<")
                                    {

                                        indexes.IntersectWith(col.items.Select((v, i) => new { v, i }).Where(x => float.Parse(x.v) < float.Parse(condition.Item3))
                                            .Select(x => x.i));
                                    }

                                }
                                if (logic == "or")
                                {
                                    indexes = new HashSet<int>();
                                    if (condition.Item2 == ">")
                                    {
                                        var test = col.items.Select((v, i) => new { v, i }).Where(x => float.Parse(x.v) > float.Parse(condition.Item3))
                                            .Select(x => x.i);
                                        indexes.Union(col.items.Select((v, i) => new { v, i }).Where(x => float.Parse(x.v) > float.Parse(condition.Item3))
                                            .Select(x => x.i));
                                    }
                                    if (condition.Item2 == "=")
                                    {
                                        var test = col.items.Select((v, i) => new { v, i }).Where(x => float.Parse(x.v) > float.Parse(condition.Item3))
    .Select(x => x.i);

                                        indexes.Union(col.items.Select((v, i) => new { v, i }).Where(x => float.Parse(x.v) == float.Parse(condition.Item3))
                                            .Select(x => x.i));
                                    }
                                    if (condition.Item2 == "<")
                                    {

                                        indexes.Union(col.items.Select((v, i) => new { v, i }).Where(x => float.Parse(x.v) < float.Parse(condition.Item3))
                                            .Select(x => x.i));
                                    }

                                }

                            }
                            else
                            {
                                indexes.IntersectWith(col.items.Select((v, i) => new { v, i }).Where(x => x.v ==  condition.Item3)
                                    .Select(x => x.i));
                            }
  

                        }
                    }
                }
                rowCount = indexes.Count;
                results = new string[rowCount, cols.Count];

            }
            else
            {
                results = new string[rowCount, cols.Count];
            }

            if (cols[0] == "*")
            {
                results = new string[rowCount, columns.Count];
                for (int j = 0; j < columns.Count; ++j)
                {
                    foreach(var idx in indexes)
                    {
                        results[idx, j] = columns[j].items[idx];

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
                        foreach (var idx in indexes)
                        {
                            results[idx, j] = columns[j].items[idx];

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
