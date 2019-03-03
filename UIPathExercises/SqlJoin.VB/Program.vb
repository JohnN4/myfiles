Imports System
Imports System.Data
Imports System.IO

Module Program
	Sub Main(args As String())
		Dim orders = LoadDataTableFromFile("orders.txt"),
			customers = LoadDataTableFromFile("customers.txt"),
			orderDetails = LoadDataTableFromFile("orderDetails.txt"),
			results = BuildResultsTable()
		For Each orderRow As DataRow In orders.Rows
			Dim orderId = Int32.Parse(orderRow("OrderID").ToString)
			Dim customerId = orderRow("CustomerID").ToString
			Dim customerRow = customers.Select($"CustomerID = '{customerId}'").First()
			Dim companyName = customerRow("CompanyName").ToString
			Dim orderDate = DateTime.Parse(orderRow("OrderDate").ToString)
			Dim orderTotal As Decimal = 0
			For Each detailRow As DataRow In orderDetails.Select($"OrderID = '{orderId}'")
				Dim quantity = Integer.Parse(detailRow(3).ToString)
				Dim price = Decimal.Parse(detailRow(2).ToString)
				Dim discount = Double.Parse(detailRow(4).ToString)
				orderTotal = orderTotal + price * quantity * (1 - discount)
			Next
			Dim newRow = results.NewRow()
			newRow(0) = companyName
			newRow(1) = orderDate
			newRow(2) = orderTotal
			results.Rows.Add(newRow)
		Next
		Dim view = results.DefaultView
		view.Sort = "TotalAmount DESC"
		results = view.ToTable()
		ExportDelimited(results, "results.txt", vbTab(0))
	End Sub

	Function LoadDataTableFromFile(fileName As String) As DataTable
		Dim table As DataTable = New DataTable(Path.GetFileNameWithoutExtension(fileName))
		For Each line In File.ReadLines(fileName)
			If table.Columns.Count = 0 Then ' Header Row
				table.BeginInit()
				For Each colName In line.Split(vbTab(0))
					Dim dc = New DataColumn(colName, GetType(String))
					table.Columns.Add(dc)
				Next
				table.EndInit()
				table.BeginLoadData()
			Else  ' Data Row
				Dim row = table.NewRow()
				Dim nCol As Integer = 0
				For Each value In line.Split(vbTab)
					row(nCol) = value
					nCol = nCol + 1
				Next
				table.Rows.Add(row)
			End If
		Next
		table.EndLoadData()
		Return table
	End Function

	Function BuildResultsTable() As DataTable
		Dim results = New DataTable("Results")
		results.Columns.Add(New DataColumn("CompanyName", GetType(String)))
		results.Columns.Add(New DataColumn("OrderDate", GetType(DateTime)))
		results.Columns.Add(New DataColumn("TotalAmount", GetType(Decimal)))
		Return results
	End Function

	Sub ExportDelimited(table As DataTable, fileName As String, delimiter As Char)
		Using file = System.IO.File.OpenWrite(fileName)
			Using writer As New StreamWriter(file)
				Dim nCol As Integer = 0
				For Each dc As DataColumn In table.Columns
					If 0 < nCol Then writer.Write(delimiter)
					nCol += 1
					writer.Write(dc.ColumnName)
				Next
				writer.WriteLine()
				For Each row As DataRow In table.Rows
					writer.WriteLine(String.Join(delimiter, row.ItemArray))
				Next
			End Using
		End Using
	End Sub
End Module
