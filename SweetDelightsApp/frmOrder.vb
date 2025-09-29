Imports System.Data.SqlClient

Public Class frmOrder

    Private Sub frmOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCustomers()
        LoadCakes()

        ' Set up event handler AFTER cakes are loaded
        AddHandler cmbCake.SelectedIndexChanged, AddressOf cmbCake_SelectedIndexChanged

        ' Set up DataGridView columns
        dgvOrderDetails.Columns.Clear()
        dgvOrderDetails.Columns.Add("CakeID", "CakeID")
        dgvOrderDetails.Columns("CakeID").Visible = False
        dgvOrderDetails.Columns.Add("Cake", "Cake")
        dgvOrderDetails.Columns.Add("IcingID", "IcingID")
        dgvOrderDetails.Columns("IcingID").Visible = False
        dgvOrderDetails.Columns.Add("Icing", "Icing")
        dgvOrderDetails.Columns.Add("ToppingID", "ToppingID")
        dgvOrderDetails.Columns("ToppingID").Visible = False
        dgvOrderDetails.Columns.Add("Topping", "Topping")
        dgvOrderDetails.Columns.Add("Quantity", "Quantity")
        dgvOrderDetails.Columns.Add("PriceEach", "Price Each")
        dgvOrderDetails.Columns.Add("Subtotal", "Subtotal")
    End Sub

    Private Sub LoadCustomers()
        Using con As SqlConnection = GetConnection()
            Dim da As New SqlDataAdapter("SELECT CustomerID, FirstName + ' ' + LastName AS FullName FROM Customer", con)
            Dim dt As New DataTable()
            da.Fill(dt)
            cmbCustomer.DataSource = dt
            cmbCustomer.DisplayMember = "FullName"
            cmbCustomer.ValueMember = "CustomerID"
        End Using
    End Sub

    Private Sub LoadCakes()
        Using con As SqlConnection = GetConnection()
            Dim da As New SqlDataAdapter("SELECT CakeID, CakeType, Price FROM Cake", con)
            Dim dt As New DataTable()
            da.Fill(dt)
            cmbCake.DataSource = dt
            cmbCake.DisplayMember = "CakeType"
            cmbCake.ValueMember = "CakeID"
        End Using
    End Sub

    ' Load Icings related to selected Cake
    Private Sub LoadIcings(cakeID As Integer)
        Using con As SqlConnection = GetConnection()
            Dim query As String = "SELECT i.IcingID, i.IcingType, i.Price " &
                                  "FROM Icing i " &
                                  "INNER JOIN CakeIcing ci ON i.IcingID = ci.IcingID " &
                                  "WHERE ci.CakeID = @CakeID"
            Dim da As New SqlDataAdapter(query, con)
            da.SelectCommand.Parameters.AddWithValue("@CakeID", cakeID)
            Dim dt As New DataTable()
            da.Fill(dt)

            cmbIcing.DataSource = Nothing
            cmbIcing.Items.Clear()

            cmbIcing.DataSource = dt
            cmbIcing.DisplayMember = "IcingType"
            cmbIcing.ValueMember = "IcingID"
        End Using
    End Sub

    ' Load Toppings related to selected Cake
    Private Sub LoadToppings(cakeID As Integer)
        Using con As SqlConnection = GetConnection()
            Dim query As String = "SELECT t.ToppingID, t.ToppingType, t.Price " &
                                  "FROM Topping t " &
                                  "INNER JOIN CakeTopping ct ON t.ToppingID = ct.ToppingID " &
                                  "WHERE ct.CakeID = @CakeID"
            Dim da As New SqlDataAdapter(query, con)
            da.SelectCommand.Parameters.AddWithValue("@CakeID", cakeID)
            Dim dt As New DataTable()
            da.Fill(dt)

            cmbTopping.DataSource = Nothing
            cmbTopping.Items.Clear()

            cmbTopping.DataSource = dt
            cmbTopping.DisplayMember = "ToppingType"
            cmbTopping.ValueMember = "ToppingID"
        End Using
    End Sub

    ' Update icings and toppings when cake changes
    Private Sub cmbCake_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cmbCake.SelectedValue Is Nothing Then Exit Sub
        Dim selectedCakeID As Integer
        If Integer.TryParse(cmbCake.SelectedValue.ToString(), selectedCakeID) Then
            LoadIcings(selectedCakeID)
            LoadToppings(selectedCakeID)
        End If
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        If cmbIcing.SelectedItem Is Nothing OrElse cmbTopping.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a valid icing and topping.")
            Return
        End If

        Dim cakeID As Integer = CInt(cmbCake.SelectedValue)
        Dim cakeName As String = cmbCake.Text
        Dim cakePrice As Decimal = Convert.ToDecimal(DirectCast(cmbCake.SelectedItem, DataRowView)("Price"))

        Dim icingID As Integer = CInt(cmbIcing.SelectedValue)
        Dim icingName As String = cmbIcing.Text
        Dim icingPrice As Decimal = Convert.ToDecimal(DirectCast(cmbIcing.SelectedItem, DataRowView)("Price"))

        Dim toppingID As Integer = CInt(cmbTopping.SelectedValue)
        Dim toppingName As String = cmbTopping.Text
        Dim toppingPrice As Decimal = Convert.ToDecimal(DirectCast(cmbTopping.SelectedItem, DataRowView)("Price"))

        Dim quantity As Integer = CInt(numQuantity.Value)
        Dim priceEach As Decimal = cakePrice + icingPrice + toppingPrice
        Dim subtotal As Decimal = priceEach * quantity

        dgvOrderDetails.Rows.Add(cakeID, cakeName, icingID, icingName, toppingID, toppingName, quantity, priceEach, subtotal)

        UpdateTotal()
    End Sub

    Private Sub UpdateTotal()
        Dim total As Decimal = 0
        For Each row As DataGridViewRow In dgvOrderDetails.Rows
            If Not row.IsNewRow Then
                total += Convert.ToDecimal(row.Cells("Subtotal").Value)
            End If
        Next
        lblTotal.Text = total.ToString("N2")
    End Sub

    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        If dgvOrderDetails.SelectedRows.Count > 0 Then
            dgvOrderDetails.Rows.RemoveAt(dgvOrderDetails.SelectedRows(0).Index)
            UpdateTotal()
        End If
    End Sub

    Private Sub btnPlaceOrder_Click(sender As Object, e As EventArgs) Handles btnPlaceOrder.Click
        If dgvOrderDetails.Rows.Count = 0 OrElse (dgvOrderDetails.Rows.Count = 1 AndAlso dgvOrderDetails.Rows(0).IsNewRow) Then
            MessageBox.Show("No items to place.")
            Return
        End If

        Using con As SqlConnection = GetConnection()
            con.Open()
            Dim trans As SqlTransaction = con.BeginTransaction()

            Try
                ' Insert order
                Dim insertOrderSql As String = "INSERT INTO Orders (CustomerID, OrderDate, TotalAmount) OUTPUT INSERTED.OrderID VALUES (@CustomerID, @OrderDate, @TotalAmount)"
                Dim orderId As Integer
                Using cmd As New SqlCommand(insertOrderSql, con, trans)
                    cmd.Parameters.AddWithValue("@CustomerID", cmbCustomer.SelectedValue)
                    cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now)
                    cmd.Parameters.AddWithValue("@TotalAmount", Decimal.Parse(lblTotal.Text))
                    orderId = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                ' Insert order details
                Dim insertDetailsSql As String = "INSERT INTO OrderDetails (OrderID, CakeID, Quantity, Subtotal) VALUES (@OrderID, @CakeID, @Quantity, @Subtotal)"
                For Each row As DataGridViewRow In dgvOrderDetails.Rows
                    If Not row.IsNewRow Then
                        Dim cakeID As Integer = CInt(row.Cells("CakeID").Value)
                        Dim icingID As Integer = CInt(row.Cells("IcingID").Value)
                        Dim toppingID As Integer = CInt(row.Cells("ToppingID").Value)

                        Using cmdDet As New SqlCommand(insertDetailsSql, con, trans)
                            cmdDet.Parameters.AddWithValue("@OrderID", orderId)
                            cmdDet.Parameters.AddWithValue("@CakeID", cakeID)
                            cmdDet.Parameters.AddWithValue("@Quantity", CInt(row.Cells("Quantity").Value))
                            cmdDet.Parameters.AddWithValue("@Subtotal", Convert.ToDecimal(row.Cells("Subtotal").Value))
                            cmdDet.ExecuteNonQuery()
                        End Using

                        ' Link cake and icing
                        Dim sqlCheckIcing As String = "IF NOT EXISTS (SELECT 1 FROM CakeIcing WHERE CakeID=@CakeID AND IcingID=@IcingID) INSERT INTO CakeIcing (CakeID, IcingID) VALUES (@CakeID, @IcingID)"
                        Using cmdCheckIcing As New SqlCommand(sqlCheckIcing, con, trans)
                            cmdCheckIcing.Parameters.AddWithValue("@CakeID", cakeID)
                            cmdCheckIcing.Parameters.AddWithValue("@IcingID", icingID)
                            cmdCheckIcing.ExecuteNonQuery()
                        End Using

                        ' Link cake and topping
                        Dim sqlCheckTopping As String = "IF NOT EXISTS (SELECT 1 FROM CakeTopping WHERE CakeID=@CakeID AND ToppingID=@ToppingID) INSERT INTO CakeTopping (CakeID, ToppingID) VALUES (@CakeID, @ToppingID)"
                        Using cmdCheckTopping As New SqlCommand(sqlCheckTopping, con, trans)
                            cmdCheckTopping.Parameters.AddWithValue("@CakeID", cakeID)
                            cmdCheckTopping.Parameters.AddWithValue("@ToppingID", toppingID)
                            cmdCheckTopping.ExecuteNonQuery()
                        End Using
                    End If
                Next

                trans.Commit()
                MessageBox.Show("Order placed successfully!")

                ' Show receipt
                Dim receiptBuilder As New Text.StringBuilder()
                receiptBuilder.AppendLine("======= Sweet Delights =======")
                receiptBuilder.AppendLine("Date: " & DateTime.Now.ToString("yyyy-MM-dd HH:mm"))
                receiptBuilder.AppendLine("Customer: " & cmbCustomer.Text)
                receiptBuilder.AppendLine("-------------------------------")

                For Each row As DataGridViewRow In dgvOrderDetails.Rows
                    If Not row.IsNewRow Then
                        receiptBuilder.AppendLine($"{row.Cells("Cake").Value} + {row.Cells("Icing").Value} + {row.Cells("Topping").Value}")
                        receiptBuilder.AppendLine($"Qty: {row.Cells("Quantity").Value} x {Convert.ToDecimal(row.Cells("PriceEach").Value):C2} = {Convert.ToDecimal(row.Cells("Subtotal").Value):C2}")
                        receiptBuilder.AppendLine()
                    End If
                Next

                receiptBuilder.AppendLine("-------------------------------")
                receiptBuilder.AppendLine("Total: " & lblTotal.Text)
                receiptBuilder.AppendLine("Thank you for your order!")
                receiptBuilder.AppendLine("===============================")

                ' Show receipt form
                Dim receiptForm As New frmReceipt()
                receiptForm.LoadReceipt(receiptBuilder.ToString())
                receiptForm.ShowDialog()

                ' Reset form
                dgvOrderDetails.Rows.Clear()
                lblTotal.Text = "0.00"

            Catch ex As Exception
                trans.Rollback()
                MessageBox.Show("Error placing order: " & ex.Message)
            End Try
        End Using
    End Sub

    ' DB connection
    Private Function GetConnection() As SqlConnection
        Dim connString As String = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SweetDelight;Integrated Security=True"
        Return New SqlConnection(connString)
    End Function
End Class
