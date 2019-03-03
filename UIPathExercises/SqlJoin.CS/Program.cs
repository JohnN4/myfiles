using System;
using System.Data;
using System.IO;
using System.Linq;

namespace SqlJoin
{
	class Program
	{
		static void Main(string[] args)
		{
			DataTable orders = LoadDataTableFromFile("orders.txt"),
				customers = LoadDataTableFromFile("customers.txt"),
				orderDetails = LoadDataTableFromFile("orderDetails.txt"),
				results = BuildResultsTable();
			foreach(DataRow orderRow in orders.Rows)
			{
				int orderId = int.Parse(orderRow["OrderID"].ToString());
				string customerId = orderRow["CustomerID"].ToString();
				DataRow customerRow = customers.Select($"CustomerID = '{customerId}'").First();
				string companyName = customerRow["CompanyName"].ToString();
				DateTime orderDate = DateTime.Parse(orderRow["OrderDate"] as string);
				decimal orderTotal = 0;
				foreach(DataRow detailRow in orderDetails.Select($"OrderID = '{orderId}'"))
				{
					int quantity = int.Parse(detailRow[3].ToString());
					decimal price = decimal.Parse(detailRow[2].ToString());
					double discount = double.Parse(detailRow[4].ToString());
					orderTotal += price * quantity * (1 - (decimal)discount);
				}
				DataRow newRow = results.NewRow();
				newRow[0] = companyName;
				newRow[1] = orderDate;
				newRow[2] = orderTotal;
				results.Rows.Add(newRow);
			}
			DataView view = results.DefaultView;
			view.Sort = "TotalAmount DESC";
			results = view.ToTable();
			ExportDelimited(results, "results.txt", '\t');
		}

		private static DataTable LoadDataTableFromFile(string fileName)
		{
			DataTable table = new DataTable(Path.GetFileNameWithoutExtension(fileName));
			foreach(string line in File.ReadLines(fileName))
			{
				if (table.Columns.Count == 0)	// Header row
				{
					table.BeginInit();
					// Parse column names.  Assume all data types are string:
					foreach(string colName in line.Split('\t'))
					{
						DataColumn dc = new DataColumn(colName, typeof(string));
						table.Columns.Add(dc);
					}
					table.EndInit();
					table.BeginLoadData();
				} else  // data
				{
					DataRow row = table.NewRow();
					int nCol = 0;
					foreach(string value in line.Split('\t')) row[nCol++] = value;
					table.Rows.Add(row);
				}
			}
			table.EndLoadData();
			return table;
		}

		private static DataTable BuildResultsTable()
		{
			DataTable results = new DataTable("Results");
			results.Columns.Add(new DataColumn("CompanyName", typeof(string)));
			results.Columns.Add(new DataColumn("OrderDate", typeof(DateTime)));
			results.Columns.Add(new DataColumn("TotalAmount", typeof(decimal)));
			return results;
		}

		private static void ExportDelimited(DataTable table, string fileName, char delimiter)
		{
			using (var file = File.OpenWrite(fileName))
			{
				using (var writer = new StreamWriter(file))
				{
					int nCol = 0;
					foreach(DataColumn dc in table.Columns)
					{
						if (0 < nCol++) writer.Write(delimiter);
						writer.Write(dc.ColumnName);
					}
					writer.WriteLine();
					foreach(DataRow row in table.Rows)
					{
						writer.WriteLine(String.Join(delimiter, row.ItemArray));
					}
				}
			}
		}
	}
}
