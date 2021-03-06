﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB338Core
{
    class DB338TransactionMgr
    {
        //the List of Internal Schema Tables holds the actual data for DB338
        //it is implemented using Lists, which could be replaced.
        List<IntSchTable> tables;

        public DB338TransactionMgr()
        {
            tables = new List<IntSchTable>();
        }

        public string[,] Process(List<string> tokens, string type)
        {
            string[,] results = new string[1,1];
            bool success;

            if (type == "create")
            {
                success = ProcessCreateTableStatement(tokens);
            }
            else if (type == "insert")
            {
                success = ProcessInsertStatement(tokens);
            }
            else if (type == "select")
            {
                results = ProcessSelectStatement(tokens);
            }
            else if (type == "alter")
            {
                results = ProcessAlterStatement(tokens);
            }
            else if (type == "delete")
            {
                results = ProcessDeleteStatement(tokens);
            }
            else if (type == "drop")
            {
                ProcessDropStatement(tokens);
            }
            else if (type == "update")
            {
                results = ProcessUpdateStatement(tokens);
            }
            else
            {
                results = null;
            }
            //other parts of SQL to do...

            return results;
        }

        private string[,] ProcessSelectStatement(List<string> tokens)
        {
            // <Select Stm> ::= SELECT <Columns> <From Clause> <Where Clause> <Group Clause> <Having Clause> <Order Clause>
            tokens = tokens.Select(x => x.ToLower()).ToList();
            List<string> colsToSelect = new List<string>();
            int tableOffset = 0;
            int selectAll = 0;
            int whereIndex = tokens.IndexOf("where");
            int endIndex = tokens.Count();
            var conditions = new List<Tuple<string, string, string>>();
            string logic = null;

            if (whereIndex != -1)
            {
                for(int i = whereIndex + 1; i < tokens.Count; i += 4)
                {
                    conditions.Add(new Tuple<string, string, string>(tokens[i], tokens[i + 1], tokens[i + 2]));
                    if (i + 4 < tokens.Count)
                    {
                        logic = tokens[i + 3];
                    }
                }
            }

           
            for (int i = 1; i < tokens.Count; ++i)
            {
                if (tokens[i] == "*" & i == 1)
                {
                    selectAll = 1;
                    tableOffset = i + 2;
                    break;
                }
                else if (tokens[i] == "from")
                {
                    tableOffset = i + 1;
                    break;
                }
                else if (tokens[i] == ",")
                {
                    continue;
                }
                else
                {
                    colsToSelect.Add(tokens[i]);
                }
            }

            string tableToSelectFrom = tokens[tableOffset];

            for (int i = 0; i < tables.Count; ++i)
            {
                if (tables[i].Name == tableToSelectFrom)
                {
                    if (selectAll == 0)
                    {
                        return tables[i].SelectResult(colsToSelect, conditions, logic);
                    }
                    else {
                        colsToSelect = new List<string>(new string[] {"*"});
                        return tables[i].SelectResult(colsToSelect, conditions, logic);

                    }
                }
            }

            return null;
        }

        private bool ProcessInsertStatement(List<string> tokens)
        {
            // <Insert Stm> ::= INSERT INTO Id '(' <ID List> ')' VALUES '(' <Expr List> ')'
            tokens = tokens.Select(x => x.ToLower()).ToList();
            string insertTableName = tokens[2];

            foreach (IntSchTable tbl in tables)
            {
                if (tbl.Name == insertTableName)
                {
                    List<string> columnNames = new List<string>();
                    List<string> columnValues = new List<string>();

                    int offset = 0;

                    for (int i = 4; i < tokens.Count; ++i)
                    {
                        if (tokens[i] == ")")
                        {
                            offset = i + 3;
                            break;
                        }
                        else if (tokens[i] == ",")
                        {
                            continue;
                        }
                        else
                        {
                            columnNames.Add(tokens[i]);
                        }
                    }

                    for (int i = offset; i < tokens.Count; ++i)
                    {
                        if (tokens[i] == ")")
                        {
                            break;
                        }
                        else if (tokens[i] == ",")
                        {
                            continue;
                        }
                        else
                        {
                            columnValues.Add(tokens[i]);
                        }
                    }

                    if (columnNames.Count != columnValues.Count)
                    {
                        return false;
                    }
                    else
                    {
                        tbl.Insert(columnNames, columnValues);
                        return true;
                    }
                }
            }

            return false;
        }

        private bool ProcessCreateTableStatement(List<string> tokens)
        {
            // assuming only the following rule is accepted
            // <Create Stm> ::= CREATE TABLE Id '(' <ID List> ')'  ------ NO SUPPORT for <Constraint Opt>
            tokens = tokens.Select(x => x.ToLower()).ToList();
            string newTableName = tokens[2];

            foreach (IntSchTable tbl in tables)
            {
                if (tbl.Name == newTableName)
                {
                    //cannot create a new table with the same name
                    MessageBox.Show("the table " + newTableName + " already existed");
                    return false;
                }
            }

            List<string> columnNames = new List<string>();
            List<string> columnTypes = new List<string>();

            int idCount = 2;
            for (int i = 4; i < tokens.Count; ++i)
            {
                if (tokens[i] == ")")
                {
                    break;
                }
                else if (tokens[i] == ",")
                {
                    continue;
                }
                else
                {
                    if (idCount == 2)
                    {
                        columnNames.Add(tokens[i]);
                        --idCount;
                    }
                    else if (idCount == 1)
                    {
                        columnTypes.Add(tokens[i]);
                        idCount = 2;
                    }
                }
            }

            IntSchTable newTable = new IntSchTable(newTableName);

            for (int i = 0; i < columnNames.Count; ++i)
            {
                newTable.AddColumn(columnNames[i], columnTypes[i]);
            }

            tables.Add(newTable);

            return true;
        }

        private string[,] ProcessUpdateStatement(List<string> tokens)
        {
            tokens = tokens.Select(x => x.ToLower()).ToList();
            string updateTableName = tokens[2];
            IntSchTable table = getTable(updateTableName);
            int setIndex = tokens.IndexOf("set");
            int whereIndex = tokens.IndexOf("where");
            List<string> cols = new List <string>();
            List<string> vals = new List<string>();
            int endIndex = tokens.Count() + 1;

            if (setIndex == -1)
            {
                MessageBox.Show("no set in the update statement");
            }

            if (whereIndex != -1)
            {
                endIndex = whereIndex;
                
            }

            for (int i = setIndex + 1; i < endIndex; i += 4)
            {
                cols.Add(tokens[i]);
                vals.Add(tokens[i + 2]);
            }




            return table.Update(cols, vals);
        }

        private void ProcessDropStatement(List<string> tokens)
        {
            tokens = tokens.Select(x => x.ToLower()).ToList();
            string dropTableName = tokens[2];
            if (getTable(dropTableName) != null) {
                tables.Remove(getTable(dropTableName));
                MessageBox.Show("Table " + dropTableName + " is successfully dropped");
            }
        }


        private string[,] ProcessDeleteStatement(List<string> tokens)
        {
            throw new NotImplementedException();
        }

        private string[,] ProcessAlterStatement(List<string> tokens)
        {
            throw new NotImplementedException();
        }

        private IntSchTable getTable(string name)
        {
            if (tables.Find(x => x.Name == name) == null)
            {
                MessageBox.Show("Table " + name + " not found");
            }
            return tables.Find(x => x.Name == name);
        }
    }
}
