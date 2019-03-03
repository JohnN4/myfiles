using System;
using System.Data;
using System.IO;
using System.Linq;

namespace CSV2DataTable
{
    // Exercise:	read the tab-delimited file "customers.txt" and package it into a DataTable
    //						Use DataTable.Select find just those customers from Germany.
    //						Print their names to the console.


    //						Assume:
    //							The table columns at indexes 0 and 11 are integers
    //							The table column at index 12 is of type Decimal
    //							All other columns are String
    //							Any value of "NULL" means it is missing and should not be added to the table

    class Program
    {
        static void Main(string[] args)
        {


            DataTable customers = LoadDataTableFromFile("Customers.txt");

            DataRow[] conbin = customers.Select("country='Germany'");

           foreach(DataRow row in conbin)
            {

                Console.WriteLine(string.Join("= ", row[1],row[10])); 
            }


            
        }

        private static DataTable LoadDataTableFromFile(string fileName)

        {

            DataTable table = new DataTable(Path.GetFileNameWithoutExtension(fileName));

            foreach (string line in File.ReadLines(fileName))

            {

                if (table.Columns.Count == 0)   // Header row

                {

                    table.BeginInit();

                    // Parse column names.  Assume all data types are string:

                    int nCol = 0;

                    foreach (string colName in line.Split('\t'))

                    {

                        Type type = null;

                        switch (nCol++)

                        {

                            case 0:

                            case 11: type = typeof(int); break;

                            case 12: type = typeof(decimal); break;

                            default: type = typeof(string); break;

                        }

                        DataColumn dc = new DataColumn(colName, type);

                        table.Columns.Add(dc);

                    }

                    table.EndInit();

                    table.BeginLoadData();

                }

                else  // data

                {

                    DataRow row = table.NewRow();

                    int nCol = 0;

                    foreach (string value in line.Split('\t'))

                    {

                        if (value == "NULL")

                        {

                            nCol++;

                            continue;

                        }

                        switch (nCol)

                        {

                            case 0:

                            case 11: if (int.TryParse(value, out int v)) row[nCol] = v; break;

                            case 12: if (decimal.TryParse(value, out decimal d)) row[nCol] = d; break;

                            default: row[nCol] = value; break;

                        }

                        nCol++;

                    }



                    table.Rows.Add(row);

                }

            }

            table.EndLoadData();

            return table;

        }

    }

}
















//        private static DataTable LoadDataTableFromFile(string fileName)
//        {
//            DataTable table = new DataTable(Path.GetFileNameWithoutExtension(fileName));
//            foreach (string line in File.ReadLines(fileName))
//            {
//                if (table.Columns.Count == 0)   // Header row
//                {
//                    table.BeginInit();
//                    // Parse column names.  Assume all data types are string:
//                    foreach (string colName in line.Split('\t'))
//                    {
//                        DataColumn dc = new DataColumn(colName, typeof(string));
//                        table.Columns.Add(dc);
//                    }
//                    table.EndInit();
//                    table.BeginLoadData();
//                }
//                else  // data
//                {
//                    DataRow row = table.NewRow();
//                    int nCol = 0;
//                    foreach (string value in line.Split('\t')) row[nCol++] = value;
//                    table.Rows.Add(row);
//                }
//            }
//            table.EndLoadData();
//            return table;
//        }


//    }
//}
