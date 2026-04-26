Imports MySql.Data.MySqlClient

Public Class Childform

    ' Uses global conn and OpenConnection from MideaProShopModule

    ' ==============================
    ' CHILDFORM CORE
    ' ==============================
    Private Sub Childform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HideAllPanels()
        pnlDashboardMain.Visible = True

        ' Initialize logic for all modules
        O_LoadCategories()
        O_LoadProducts("")
        V_LoadOrders()
        A_LoadSuppliers()
        M_LoadCategories()
        S_InitializeTable()
        SR_InitializeTables()
        S_LoadProducts()
        S_LoadHistory()
        SR_LoadServices()
        SR_LoadRequests()
        SR_PopulateDropdowns()

        LoadDashboardStats()
    End Sub

    Public Sub HideAllPanels()
        pnlDashboardMain.Visible = False
        pnlOrderMain.Visible = False
        pnlViewOrdersMain.Visible = False
        pnlAddProductMain.Visible = False
        pnlManageProductsMain.Visible = False
        pnlLowStockMain.Visible = False
        pnlStockTransactionMain.Visible = False
        pnlManageServiceMain.Visible = False
        pnlAddServiceRequestMain.Visible = False
        pnlViewServiceRequestsMain.Visible = False
        pnlViewWarrantyMain.Visible = False
        pnlFileClaimMain.Visible = False
    End Sub

    Private Sub LoadDashboardStats()
        ' Dummy implementation for dashboard
        lblCard1Value.Text = "₱0.00"
        lblCard2Value.Text = "0"
        lblCard3Value.Text = "0"
        lblCard4Value.Text = "0"
    End Sub

    ' ==============================
    ' ORDER LOGIC (O_)
    ' ==============================
    Private _cart As New List(Of CartItem)
    Private _totalAmount As Decimal = 0

    Private Class CartItem
        Public Property ProductID As Integer
        Public Property ProductName As String
        Public Property Price As Decimal
        Public Property Quantity As Integer
    End Class

    Private Sub O_LoadCategories()
        o_pnlCategories.Controls.Clear()
        Dim btnAll As New Button()
        btnAll.Text = "All Categories"
        btnAll.Tag = ""
        btnAll.Size = New Size(150, 40)
        btnAll.FlatStyle = FlatStyle.Flat
        btnAll.BackColor = Color.FromArgb(30, 30, 30)
        btnAll.ForeColor = Color.White
        AddHandler btnAll.Click, AddressOf O_CategoryFilter_Click
        o_pnlCategories.Controls.Add(btnAll)

        Dim categories() As String = {"Air Conditioners", "Washing Machines", "Televisions", "Refrigerators"}
        For Each cat As String In categories
            Dim btn As New Button()
            btn.Text = cat
            btn.Tag = cat
            btn.Size = New Size(150, 40)
            btn.FlatStyle = FlatStyle.Flat
            btn.BackColor = Color.White
            btn.ForeColor = Color.Black
            AddHandler btn.Click, AddressOf O_CategoryFilter_Click
            o_pnlCategories.Controls.Add(btn)
        Next
    End Sub

    Private Sub O_CategoryFilter_Click(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        For Each ctrl As Control In o_pnlCategories.Controls
            If TypeOf ctrl Is Button Then
                ctrl.BackColor = Color.White
                ctrl.ForeColor = Color.Black
            End If
        Next
        btn.BackColor = Color.FromArgb(30, 30, 30)
        btn.ForeColor = Color.White
        O_LoadProducts(btn.Tag.ToString())
    End Sub

    Private Sub O_LoadProducts(category As String)
        o_dgvProducts.Rows.Clear()
        Try
            OpenConnection()
            Dim query As String = "SELECT Product_ID, Product_Name, Brand, Unit_Price, Stock_Quantity FROM PRODUCT WHERE Stock_Quantity > 0"
            If Not String.IsNullOrEmpty(category) Then
                query &= " AND Product_Category = @cat"
            End If

            Using sqlCmd As New MySqlCommand(query, conn)
                If Not String.IsNullOrEmpty(category) Then
                    sqlCmd.Parameters.AddWithValue("@cat", category)
                End If
                Using reader As MySqlDataReader = sqlCmd.ExecuteReader()
                    While reader.Read()
                        Dim id = reader.GetInt32("Product_ID")
                        Dim name = reader.GetString("Product_Name")
                        Dim desc = If(reader.IsDBNull(reader.GetOrdinal("Brand")), "", reader.GetString("Brand"))
                        Dim price = reader.GetDecimal("Unit_Price")
                        Dim stock = reader.GetInt32("Stock_Quantity")

                        o_dgvProducts.Rows.Add(id, name, desc, price, stock)
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub o_dgvProducts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles o_dgvProducts.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = o_dgvProducts.Columns("o_colActionAdd").Index Then
            Dim row = o_dgvProducts.Rows(e.RowIndex)
            Dim prodId = Convert.ToInt32(row.Cells("o_colProductID").Value)
            Dim prodName = row.Cells("o_colProductName").Value.ToString()
            Dim price = Convert.ToDecimal(row.Cells("o_colPrice").Value)
            Dim stock = Convert.ToInt32(row.Cells("o_colStock").Value)

            Dim existingItem = _cart.FirstOrDefault(Function(c) c.ProductID = prodId)
            If existingItem IsNot Nothing Then
                If existingItem.Quantity < stock Then
                    existingItem.Quantity += 1
                Else
                    MessageBox.Show("Cannot add more than available stock.", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            Else
                _cart.Add(New CartItem With {.ProductID = prodId, .ProductName = prodName, .Price = price, .Quantity = 1})
            End If

            O_RefreshCart()
        End If
    End Sub

    Private Sub O_RefreshCart()
        o_flpCartItems.Controls.Clear()
        _totalAmount = 0

        For Each item In _cart
            _totalAmount += (item.Price * item.Quantity)
            Dim pnlItem As New Panel With {.Width = 330, .Height = 60, .BackColor = Color.FromArgb(245, 245, 248), .Margin = New Padding(5)}

            Dim lblName As New Label With {.Text = item.ProductName, .Font = New Font("Segoe UI", 10, FontStyle.Bold), .Location = New Point(10, 10), .AutoSize = True}
            Dim lblPrice As New Label With {.Text = item.Quantity.ToString() & " x ₱" & item.Price.ToString("N2"), .Location = New Point(10, 35), .AutoSize = True}

            Dim btnMinus As New Button With {.Text = "-", .Size = New Size(30, 30), .Location = New Point(220, 15), .Tag = item.ProductID, .BackColor = Color.LightCoral, .FlatStyle = FlatStyle.Flat}
            Dim btnPlus As New Button With {.Text = "+", .Size = New Size(30, 30), .Location = New Point(260, 15), .Tag = item.ProductID, .BackColor = Color.LightGreen, .FlatStyle = FlatStyle.Flat}

            AddHandler btnMinus.Click, AddressOf O_CartMinus_Click
            AddHandler btnPlus.Click, AddressOf O_CartPlus_Click

            pnlItem.Controls.Add(lblName)
            pnlItem.Controls.Add(lblPrice)
            pnlItem.Controls.Add(btnMinus)
            pnlItem.Controls.Add(btnPlus)

            o_flpCartItems.Controls.Add(pnlItem)
        Next

        o_lblTotal.Text = "₱" & _totalAmount.ToString("N2")
        o_btnContinue.Enabled = _cart.Count > 0
    End Sub

    Private Sub O_CartMinus_Click(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        Dim id = Convert.ToInt32(btn.Tag)
        Dim item = _cart.First(Function(c) c.ProductID = id)
        item.Quantity -= 1
        If item.Quantity <= 0 Then _cart.Remove(item)
        O_RefreshCart()
    End Sub

    Private Sub O_CartPlus_Click(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        Dim id = Convert.ToInt32(btn.Tag)
        Dim item = _cart.First(Function(c) c.ProductID = id)

        Dim stock As Integer = 0
        For Each row As DataGridViewRow In o_dgvProducts.Rows
            If Convert.ToInt32(row.Cells("o_colProductID").Value) = id Then
                stock = Convert.ToInt32(row.Cells("o_colStock").Value)
                Exit For
            End If
        Next

        If item.Quantity < stock Then
            item.Quantity += 1
        Else
            MessageBox.Show("Maximum stock reached.", "Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        O_RefreshCart()
    End Sub

    Private Sub o_btnContinue_Click(sender As Object, e As EventArgs) Handles o_btnContinue.Click
        o_lblFinalTotal.Text = "₱" & _totalAmount.ToString("N2")
        o_flpCheckoutSummary.Controls.Clear()
        For Each item In _cart
            Dim lbl As New Label With {.Text = $"{item.Quantity}x {item.ProductName} - ₱{(item.Price * item.Quantity):N2}", .AutoSize = True, .Margin = New Padding(5)}
            o_flpCheckoutSummary.Controls.Add(lbl)
        Next
        O_LoadCustomers()
        o_pnlCheckoutForm.Visible = True
        o_pnlCheckoutForm.BringToFront()
    End Sub

    Private Sub O_LoadCustomers()
        o_cmbExistingCustomer.Items.Clear()
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("SELECT Customer_ID, Full_Name FROM CUSTOMER", conn)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        o_cmbExistingCustomer.Items.Add(New With {.Text = reader("Full_Name").ToString(), .Value = reader("Customer_ID")})
                    End While
                End Using
            End Using
            o_cmbExistingCustomer.DisplayMember = "Text"
            o_cmbExistingCustomer.ValueMember = "Value"
            If o_cmbExistingCustomer.Items.Count > 0 Then o_cmbExistingCustomer.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub o_optCustomer_CheckedChanged(sender As Object, e As EventArgs) Handles o_optExistingCustomer.CheckedChanged, o_optNewCustomer.CheckedChanged
        o_cmbExistingCustomer.Enabled = o_optExistingCustomer.Checked
        o_pnlNewCustomer.Enabled = o_optNewCustomer.Checked
    End Sub

    Private Sub o_btnBackToSales_Click(sender As Object, e As EventArgs) Handles o_btnBackToSales.Click
        o_pnlCheckoutForm.Visible = False
    End Sub

    Private Sub o_btnConfirmOrder_Click(sender As Object, e As EventArgs) Handles o_btnConfirmOrder.Click
        If _cart.Count = 0 Then Return
        Dim customerId As Integer = 0

        If o_optNewCustomer.Checked Then
            If String.IsNullOrWhiteSpace(o_txtCustName.Text) OrElse String.IsNullOrWhiteSpace(o_txtCustContact.Text) Then
                MessageBox.Show("Please fill out Name and Contact for the new customer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        Try
            OpenConnection()
            Using transaction = conn.BeginTransaction()
                Try
                    ' 1. Handle Customer
                    If o_optNewCustomer.Checked Then
                        Using cmdCust As New MySqlCommand("INSERT INTO CUSTOMER (Full_Name, Contact_Number, Home_Address) VALUES (@name, @contact, @address)", conn, transaction)
                            cmdCust.Parameters.AddWithValue("@name", o_txtCustName.Text)
                            cmdCust.Parameters.AddWithValue("@contact", o_txtCustContact.Text)
                            cmdCust.Parameters.AddWithValue("@address", o_txtCustAddress.Text)
                            cmdCust.ExecuteNonQuery()
                            customerId = Convert.ToInt32(cmdCust.LastInsertedId)
                        End Using
                    Else
                        customerId = Convert.ToInt32(DirectCast(o_cmbExistingCustomer.SelectedItem, Object).Value)
                    End If

                    ' 2. Create Purchase Record
                    Dim receiptNo As String = "RCPT" & DateTime.Now.ToString("yyyyMMddHHmmss")
                    Dim purchaseId As Integer = 0
                    Using cmdPurch As New MySqlCommand("INSERT INTO PURCHASE (Customer_ID, Purchase_Date, Receipt_Number) VALUES (@cid, @pdate, @receipt)", conn, transaction)
                        cmdPurch.Parameters.AddWithValue("@cid", customerId)
                        cmdPurch.Parameters.AddWithValue("@pdate", DateTime.Now)
                        cmdPurch.Parameters.AddWithValue("@receipt", receiptNo)
                        cmdPurch.ExecuteNonQuery()
                        purchaseId = Convert.ToInt32(cmdPurch.LastInsertedId)
                    End Using

                    ' 3. Create Purchase Items & Update Stock & Log Transaction
                    For Each item In _cart
                        Using cmdItem As New MySqlCommand("INSERT INTO PURCHASE_ITEMS (Purchase_ID, Product_ID, Quantity, Item_Price) VALUES (@pid, @prodid, @qty, @price)", conn, transaction)
                            cmdItem.Parameters.AddWithValue("@pid", purchaseId)
                            cmdItem.Parameters.AddWithValue("@prodid", item.ProductID)
                            cmdItem.Parameters.AddWithValue("@qty", item.Quantity)
                            cmdItem.Parameters.AddWithValue("@price", item.Price)
                            cmdItem.ExecuteNonQuery()
                        End Using

                        Using cmdStock As New MySqlCommand("UPDATE PRODUCT SET Stock_Quantity = Stock_Quantity - @qty WHERE Product_ID = @prodid", conn, transaction)
                            cmdStock.Parameters.AddWithValue("@qty", item.Quantity)
                            cmdStock.Parameters.AddWithValue("@prodid", item.ProductID)
                            cmdStock.ExecuteNonQuery()
                        End Using

                        Using cmdLog As New MySqlCommand("INSERT INTO STOCK_TRANSACTION (Product_ID, Transaction_Type, Quantity, Transaction_Date, Remarks) VALUES (@prodid, 'Sale', @qty, @tdate, @remarks)", conn, transaction)
                            cmdLog.Parameters.AddWithValue("@prodid", item.ProductID)
                            cmdLog.Parameters.AddWithValue("@qty", item.Quantity)
                            cmdLog.Parameters.AddWithValue("@tdate", DateTime.Now)
                            cmdLog.Parameters.AddWithValue("@remarks", "Order " & receiptNo)
                            cmdLog.ExecuteNonQuery()
                        End Using
                    Next

                    ' 4. Generate 1-Year Warranty
                    Using cmdWarranty As New MySqlCommand("INSERT INTO WARRANTY (Purchase_ID, Warranty_Start_Date, Warranty_End_Date, Warranty_Status) VALUES (@pid, @wstart, @wend, 'Active')", conn, transaction)
                        cmdWarranty.Parameters.AddWithValue("@pid", purchaseId)
                        cmdWarranty.Parameters.AddWithValue("@wstart", DateTime.Now)
                        cmdWarranty.Parameters.AddWithValue("@wend", DateTime.Now.AddYears(1))
                        cmdWarranty.ExecuteNonQuery()
                    End Using

                    transaction.Commit()
                    MessageBox.Show("Order successfully placed!" & vbCrLf & "Receipt: " & receiptNo, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    _cart.Clear()
                    o_txtCustName.Clear()
                    o_txtCustContact.Clear()
                    o_txtCustAddress.Clear()
                    o_optExistingCustomer.Checked = True
                    o_pnlCheckoutForm.Visible = False

                    O_RefreshCart()
                    O_CategoryFilter_Click(o_pnlCategories.Controls(0), EventArgs.Empty)
                    V_LoadOrders()
                    S_LoadHistory()
                Catch ex As Exception
                    transaction.Rollback()
                    Throw ex
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Transaction failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ==============================
    ' VIEW ORDERS LOGIC (V_)
    ' ==============================
    Private Sub V_LoadOrders()
        v_dgvOrders.Rows.Clear()
        Try
            OpenConnection()
            Dim query As String = "SELECT p.Purchase_ID, p.Receipt_Number, p.Purchase_Date, c.Full_Name, IFNULL((SELECT SUM(Quantity * Item_Price) FROM PURCHASE_ITEMS WHERE Purchase_ID = p.Purchase_ID), 0) AS Total_Amount FROM PURCHASE p JOIN CUSTOMER c ON p.Customer_ID = c.Customer_ID WHERE p.Purchase_Date >= @start AND p.Purchase_Date <= @end ORDER BY p.Purchase_Date DESC"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@start", v_dtpStart.Value.Date)
                cmd.Parameters.AddWithValue("@end", v_dtpEnd.Value.Date.AddDays(1).AddTicks(-1))
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim id = reader.GetInt32(0)
                        Dim receipt = reader.GetString(1)
                        Dim dt = reader.GetDateTime(2)
                        Dim customer = reader.GetString(3)
                        Dim total = reader.GetDecimal(4)
                        v_dgvOrders.Rows.Add(id, receipt, dt.ToString("g"), customer, total)
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub v_btnFilter_Click(sender As Object, e As EventArgs) Handles v_btnFilter.Click
        V_LoadOrders()
    End Sub

    ' ==============================
    ' ADD PRODUCT LOGIC (A_)
    ' ==============================
    Private Sub A_LoadSuppliers()
        a_cmbExistingSupplier.Items.Clear()
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("SELECT Supplier_ID, Supplier_Name FROM SUPPLIER", conn)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        a_cmbExistingSupplier.Items.Add(New With {.Text = reader("Supplier_Name").ToString(), .Value = reader("Supplier_ID")})
                    End While
                End Using
            End Using
            a_cmbExistingSupplier.DisplayMember = "Text"
            a_cmbExistingSupplier.ValueMember = "Value"
            If a_cmbExistingSupplier.Items.Count > 0 Then a_cmbExistingSupplier.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub a_optSupplier_CheckedChanged(sender As Object, e As EventArgs) Handles a_optExistingSupplier.CheckedChanged, a_optNewSupplier.CheckedChanged
        a_cmbExistingSupplier.Enabled = a_optExistingSupplier.Checked
        a_pnlNewSupplier.Enabled = a_optNewSupplier.Checked
    End Sub

    Private Sub a_btnSave_Click(sender As Object, e As EventArgs) Handles a_btnSave.Click
        If String.IsNullOrWhiteSpace(a_txtProdName.Text) OrElse a_cmbCategory.SelectedIndex = -1 Then
            MessageBox.Show("Product Name and Category are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If a_optNewSupplier.Checked AndAlso String.IsNullOrWhiteSpace(a_txtSupName.Text) Then
            MessageBox.Show("Supplier Name is required for a new supplier.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            OpenConnection()
            Using transaction = conn.BeginTransaction()
                Try
                    Dim supplierId As Integer = 0

                    If a_optNewSupplier.Checked Then
                        Using cmdSup As New MySqlCommand("INSERT INTO SUPPLIER (Supplier_Name, Contact_Number, Address) VALUES (@name, @contact, @address)", conn, transaction)
                            cmdSup.Parameters.AddWithValue("@name", a_txtSupName.Text)
                            cmdSup.Parameters.AddWithValue("@contact", a_txtSupContact.Text)
                            cmdSup.Parameters.AddWithValue("@address", a_txtSupAddress.Text)
                            cmdSup.ExecuteNonQuery()
                            supplierId = Convert.ToInt32(cmdSup.LastInsertedId)
                        End Using
                    Else
                        supplierId = Convert.ToInt32(DirectCast(a_cmbExistingSupplier.SelectedItem, Object).Value)
                    End If

                    Using cmdProd As New MySqlCommand("INSERT INTO PRODUCT (Product_Name, Brand, Product_Category, Unit_Price, Stock_Quantity, Reorder_Level, Supplier_ID) VALUES (@name, @brand, @cat, @price, @stock, @reorder, @supid)", conn, transaction)
                        cmdProd.Parameters.AddWithValue("@name", a_txtProdName.Text)
                        cmdProd.Parameters.AddWithValue("@brand", a_txtProdBrand.Text)
                        cmdProd.Parameters.AddWithValue("@cat", a_cmbCategory.SelectedItem.ToString())
                        cmdProd.Parameters.AddWithValue("@price", a_numPrice.Value)
                        cmdProd.Parameters.AddWithValue("@stock", a_numStock.Value)
                        cmdProd.Parameters.AddWithValue("@reorder", a_numReorder.Value)
                        cmdProd.Parameters.AddWithValue("@supid", supplierId)
                        cmdProd.ExecuteNonQuery()
                    End Using

                    transaction.Commit()
                    MessageBox.Show("Product successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    a_txtProdName.Clear()
                    a_txtProdBrand.Clear()
                    a_txtProdDesc.Clear()
                    a_numPrice.Value = 0
                    a_numStock.Value = 0
                    a_numReorder.Value = 0
                    a_txtSupName.Clear()
                    a_txtSupContact.Clear()
                    a_txtSupAddress.Clear()
                    a_cmbCategory.SelectedIndex = -1
                    a_optExistingSupplier.Checked = True
                    A_LoadSuppliers()

                    ' Refresh other modules
                    M_LoadProducts("")
                    L_LoadAlerts("")
                    S_LoadProducts()
                    O_CategoryFilter_Click(o_pnlCategories.Controls(0), EventArgs.Empty)
                Catch ex As Exception
                    transaction.Rollback()
                    Throw ex
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to save product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub a_btnCancel_Click(sender As Object, e As EventArgs) Handles a_btnCancel.Click
        a_txtProdName.Clear()
        a_txtProdBrand.Clear()
        a_txtProdDesc.Clear()
        a_numPrice.Value = 0
        a_numStock.Value = 0
        a_numReorder.Value = 0
    End Sub

    ' ==============================
    ' MANAGE PRODUCTS LOGIC (M_)
    ' ==============================
    Private _editProductId As Integer = 0

    Private Sub M_LoadCategories()
        m_pnlCategories.Controls.Clear()
        Dim btnAll As New Button()
        btnAll.Text = "All Categories"
        btnAll.Tag = ""
        btnAll.Size = New Size(150, 40)
        btnAll.FlatStyle = FlatStyle.Flat
        btnAll.BackColor = Color.FromArgb(30, 30, 30)
        btnAll.ForeColor = Color.White
        AddHandler btnAll.Click, AddressOf M_CategoryFilter_Click
        m_pnlCategories.Controls.Add(btnAll)

        Dim categories() As String = {"Air Conditioners", "Washing Machines", "Televisions", "Refrigerators"}
        For Each cat As String In categories
            Dim btn As New Button()
            btn.Text = cat
            btn.Tag = cat
            btn.Size = New Size(150, 40)
            btn.FlatStyle = FlatStyle.Flat
            btn.BackColor = Color.White
            btn.ForeColor = Color.Black
            AddHandler btn.Click, AddressOf M_CategoryFilter_Click
            m_pnlCategories.Controls.Add(btn)
        Next
    End Sub

    Private Sub M_CategoryFilter_Click(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        For Each ctrl As Control In m_pnlCategories.Controls
            If TypeOf ctrl Is Button Then
                ctrl.BackColor = Color.White
                ctrl.ForeColor = Color.Black
            End If
        Next
        btn.BackColor = Color.FromArgb(30, 30, 30)
        btn.ForeColor = Color.White
        M_LoadProducts(btn.Tag.ToString())
    End Sub

    Private Sub M_LoadProducts(category As String)
        m_dgvProducts.Rows.Clear()
        Try
            OpenConnection()
            Dim query As String = "SELECT Product_ID, Product_Name, Brand, Unit_Price, Stock_Quantity FROM PRODUCT"
            If Not String.IsNullOrEmpty(category) Then
                query &= " WHERE Product_Category = @cat"
            End If

            Using sqlCmd As New MySqlCommand(query, conn)
                If Not String.IsNullOrEmpty(category) Then
                    sqlCmd.Parameters.AddWithValue("@cat", category)
                End If
                Using reader As MySqlDataReader = sqlCmd.ExecuteReader()
                    While reader.Read()
                        Dim id = reader.GetInt32("Product_ID")
                        Dim name = reader.GetString("Product_Name")
                        Dim brand = If(reader.IsDBNull(reader.GetOrdinal("Brand")), "", reader.GetString("Brand"))
                        Dim price = reader.GetDecimal("Unit_Price")
                        Dim stock = reader.GetInt32("Stock_Quantity")

                        m_dgvProducts.Rows.Add(id, name, brand, price, stock)
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub m_dgvProducts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles m_dgvProducts.CellContentClick
        If e.RowIndex < 0 Then Return

        Dim row = m_dgvProducts.Rows(e.RowIndex)
        Dim prodId = Convert.ToInt32(row.Cells("m_colProductID").Value)

        ' Edit Button
        If e.ColumnIndex = m_dgvProducts.Columns("m_colActionEdit").Index Then
            M_LoadProductForEdit(prodId)
        End If

        ' Delete Button
        If e.ColumnIndex = m_dgvProducts.Columns("m_colActionDelete").Index Then
            If MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Try
                    OpenConnection()
                    Using cmd As New MySqlCommand("DELETE FROM PRODUCT WHERE Product_ID = @id", conn)
                        cmd.Parameters.AddWithValue("@id", prodId)
                        cmd.ExecuteNonQuery()
                    End Using
                    MessageBox.Show("Product deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    M_RefreshCurrentCategory()
                    O_CategoryFilter_Click(o_pnlCategories.Controls(0), EventArgs.Empty)
                Catch ex As MySqlException
                    If ex.Number = 1451 Then
                        MessageBox.Show("Cannot delete this product because it is tied to past transactions.", "Constraint Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Private Sub M_LoadProductForEdit(prodId As Integer)
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("SELECT * FROM PRODUCT WHERE Product_ID = @id", conn)
                cmd.Parameters.AddWithValue("@id", prodId)
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        _editProductId = prodId
                        m_txtEditName.Text = reader("Product_Name").ToString()
                        m_txtEditBrand.Text = If(reader.IsDBNull(reader.GetOrdinal("Brand")), "", reader("Brand").ToString())
                        m_cmbEditCategory.SelectedItem = reader("Product_Category").ToString()
                        m_numEditPrice.Value = Convert.ToDecimal(reader("Unit_Price"))
                        m_numEditStock.Value = Convert.ToInt32(reader("Stock_Quantity"))
                        m_numEditReorder.Value = Convert.ToInt32(reader("Reorder_Level"))

                        m_pnlEditProduct.Visible = True
                        m_pnlEditProduct.BringToFront()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load product details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub m_btnUpdate_Click(sender As Object, e As EventArgs) Handles m_btnUpdate.Click
        If String.IsNullOrWhiteSpace(m_txtEditName.Text) Then
            MessageBox.Show("Product Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            OpenConnection()
            Dim q As String = "UPDATE PRODUCT SET Product_Name = @name, Brand = @brand, Product_Category = @cat, Unit_Price = @price, Stock_Quantity = @stock, Reorder_Level = @reorder WHERE Product_ID = @id"
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@name", m_txtEditName.Text)
                cmd.Parameters.AddWithValue("@brand", m_txtEditBrand.Text)
                cmd.Parameters.AddWithValue("@cat", m_cmbEditCategory.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@price", m_numEditPrice.Value)
                cmd.Parameters.AddWithValue("@stock", m_numEditStock.Value)
                cmd.Parameters.AddWithValue("@reorder", m_numEditReorder.Value)
                cmd.Parameters.AddWithValue("@id", _editProductId)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            m_pnlEditProduct.Visible = False
            M_RefreshCurrentCategory()

            ' Refresh others
            O_CategoryFilter_Click(o_pnlCategories.Controls(0), EventArgs.Empty)
            L_LoadAlerts("")
        Catch ex As Exception
            MessageBox.Show("Update failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub m_btnCancel_Click(sender As Object, e As EventArgs) Handles m_btnCancel.Click
        m_pnlEditProduct.Visible = False
    End Sub

    Private Sub M_RefreshCurrentCategory()
        Dim activeBtn As Button = Nothing
        For Each ctrl As Control In m_pnlCategories.Controls
            If TypeOf ctrl Is Button AndAlso ctrl.BackColor = Color.FromArgb(30, 30, 30) Then
                activeBtn = ctrl
                Exit For
            End If
        Next
        M_LoadProducts(If(activeBtn IsNot Nothing, activeBtn.Tag.ToString(), ""))
    End Sub

    ' ==============================
    ' LOW STOCK ALERTS LOGIC (L_)
    ' ==============================
    Private Sub L_LoadCategories()
        l_pnlCategories.Controls.Clear()
        Dim btnAll As New Button()
        btnAll.Text = "All Categories"
        btnAll.Tag = ""
        btnAll.Size = New Size(150, 40)
        btnAll.FlatStyle = FlatStyle.Flat
        btnAll.BackColor = Color.FromArgb(30, 30, 30)
        btnAll.ForeColor = Color.White
        AddHandler btnAll.Click, AddressOf L_CategoryFilter_Click
        l_pnlCategories.Controls.Add(btnAll)

        Dim categories() As String = {"Air Conditioners", "Washing Machines", "Televisions", "Refrigerators"}
        For Each cat As String In categories
            Dim btn As New Button()
            btn.Text = cat
            btn.Tag = cat
            btn.Size = New Size(150, 40)
            btn.FlatStyle = FlatStyle.Flat
            btn.BackColor = Color.White
            btn.ForeColor = Color.Black
            AddHandler btn.Click, AddressOf L_CategoryFilter_Click
            l_pnlCategories.Controls.Add(btn)
        Next
    End Sub

    Private Sub L_CategoryFilter_Click(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        For Each ctrl As Control In l_pnlCategories.Controls
            If TypeOf ctrl Is Button Then
                ctrl.BackColor = Color.White
                ctrl.ForeColor = Color.Black
            End If
        Next
        btn.BackColor = Color.FromArgb(30, 30, 30)
        btn.ForeColor = Color.White
        L_LoadAlerts(btn.Tag.ToString())
    End Sub

    Private Sub L_LoadAlerts(category As String)
        l_dgvAlerts.Rows.Clear()
        Try
            OpenConnection()
            Dim query As String = "SELECT p.Product_ID, p.Product_Name, p.Brand, p.Stock_Quantity, p.Reorder_Level, s.Supplier_Name FROM PRODUCT p LEFT JOIN SUPPLIER s ON p.Supplier_ID = s.Supplier_ID WHERE p.Stock_Quantity <= p.Reorder_Level"
            If Not String.IsNullOrEmpty(category) Then
                query &= " AND p.Product_Category = @cat"
            End If
            query &= " ORDER BY p.Stock_Quantity ASC"

            Using cmd As New MySqlCommand(query, conn)
                If Not String.IsNullOrEmpty(category) Then
                    cmd.Parameters.AddWithValue("@cat", category)
                End If
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim id = reader.GetInt32(0)
                        Dim name = reader.GetString(1)
                        Dim brand = If(reader.IsDBNull(2), "", reader.GetString(2))
                        Dim stock = reader.GetInt32(3)
                        Dim reorder = reader.GetInt32(4)
                        Dim supplier = If(reader.IsDBNull(5), "Unknown", reader.GetString(5))
                        l_dgvAlerts.Rows.Add(id, name, brand, stock, reorder, supplier)
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub l_dgvAlerts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles l_dgvAlerts.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = l_dgvAlerts.Columns("l_colActionAddStock").Index Then
            Dim row = l_dgvAlerts.Rows(e.RowIndex)
            Dim prodId = Convert.ToInt32(row.Cells("l_colProductID").Value)

            ' Redirect to Stock Transactions
            HideAllPanels()
            pnlStockTransactionMain.Visible = True

            ' Pre-select product and action
            If s_cmbProduct.Items.Count > 0 Then
                For i As Integer = 0 To s_cmbProduct.Items.Count - 1
                    If DirectCast(s_cmbProduct.Items(i), Object).Value = prodId Then
                        s_cmbProduct.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If

            s_cmbType.SelectedItem = "Restock"
            s_numQuantity.Value = 10
            s_txtRemarks.Text = "Low stock replenishment"
            s_numQuantity.Focus()
        End If
    End Sub

    ' ==============================
    ' STOCK TRANSACTIONS LOGIC (S_)
    ' ==============================
    Private Sub S_InitializeTable()
        Try
            OpenConnection()
            Dim q As String = "CREATE TABLE IF NOT EXISTS STOCK_TRANSACTION (" &
                              "Transaction_ID INT AUTO_INCREMENT PRIMARY KEY, " &
                              "Product_ID INT, " &
                              "Transaction_Type VARCHAR(50), " &
                              "Quantity INT, " &
                              "Transaction_Date DATETIME, " &
                              "Remarks VARCHAR(255))"
            Using cmd As New MySqlCommand(q, conn)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to initialize Stock Transactions table: " & ex.Message)
        End Try
    End Sub

    Private Sub S_LoadProducts()
        s_cmbProduct.Items.Clear()
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("SELECT Product_ID, Product_Name FROM PRODUCT ORDER BY Product_Name ASC", conn)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        s_cmbProduct.Items.Add(New With {.Text = reader("Product_Name").ToString(), .Value = reader("Product_ID")})
                    End While
                End Using
            End Using
            s_cmbProduct.DisplayMember = "Text"
            s_cmbProduct.ValueMember = "Value"
            If s_cmbProduct.Items.Count > 0 Then s_cmbProduct.SelectedIndex = 0
            If s_cmbType.Items.Count > 0 Then s_cmbType.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub

    Private Sub S_LoadHistory()
        s_dgvHistory.Rows.Clear()
        Try
            OpenConnection()
            Dim q As String = "SELECT st.Transaction_ID, p.Product_Name, st.Transaction_Type, st.Quantity, st.Transaction_Date, st.Remarks FROM STOCK_TRANSACTION st JOIN PRODUCT p ON st.Product_ID = p.Product_ID ORDER BY st.Transaction_Date DESC"
            Using cmd As New MySqlCommand(q, conn)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        s_dgvHistory.Rows.Add(reader("Transaction_ID"), reader("Product_Name"), reader("Transaction_Type"), reader("Quantity"), Convert.ToDateTime(reader("Transaction_Date")).ToString("g"), reader("Remarks").ToString())
                    End While
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub s_btnSave_Click(sender As Object, e As EventArgs) Handles s_btnSave.Click
        If s_cmbProduct.SelectedIndex = -1 OrElse s_cmbType.SelectedIndex = -1 Then
            MessageBox.Show("Please select a product and transaction type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim qty As Integer = Convert.ToInt32(s_numQuantity.Value)
        If qty <= 0 Then
            MessageBox.Show("Quantity must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim prodId As Integer = Convert.ToInt32(DirectCast(s_cmbProduct.SelectedItem, Object).Value)
        Dim tType As String = s_cmbType.SelectedItem.ToString()
        Dim isAddition As Boolean = (tType = "Restock" Or tType = "Correction")

        If tType = "Correction" Then
            Dim res = MessageBox.Show("Is this correction adding stock? (Click Yes to Add, No to Deduct)", "Correction Direction", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If res = DialogResult.Cancel Then Return
            isAddition = (res = DialogResult.Yes)
        End If

        Try
            OpenConnection()
            Using transaction = conn.BeginTransaction()
                Try
                    ' 1. Check stock if deducting
                    If Not isAddition Then
                        Dim currentStock As Integer = 0
                        Using cmdCheck As New MySqlCommand("SELECT Stock_Quantity FROM PRODUCT WHERE Product_ID = @id", conn, transaction)
                            cmdCheck.Parameters.AddWithValue("@id", prodId)
                            currentStock = Convert.ToInt32(cmdCheck.ExecuteScalar())
                        End Using

                        If currentStock < qty Then
                            MessageBox.Show($"Cannot deduct {qty} stock. Only {currentStock} available.", "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            transaction.Rollback()
                            Return
                        End If
                    End If

                    ' 2. Log Transaction
                    Using cmdLog As New MySqlCommand("INSERT INTO STOCK_TRANSACTION (Product_ID, Transaction_Type, Quantity, Transaction_Date, Remarks) VALUES (@prodid, @type, @qty, @tdate, @remarks)", conn, transaction)
                        cmdLog.Parameters.AddWithValue("@prodid", prodId)
                        cmdLog.Parameters.AddWithValue("@type", tType)
                        cmdLog.Parameters.AddWithValue("@qty", If(isAddition, qty, -qty))
                        cmdLog.Parameters.AddWithValue("@tdate", DateTime.Now)
                        cmdLog.Parameters.AddWithValue("@remarks", s_txtRemarks.Text)
                        cmdLog.ExecuteNonQuery()
                    End Using

                    ' 3. Update Product Stock
                    Dim qUpdate As String = If(isAddition, "UPDATE PRODUCT SET Stock_Quantity = Stock_Quantity + @qty WHERE Product_ID = @id", "UPDATE PRODUCT SET Stock_Quantity = Stock_Quantity - @qty WHERE Product_ID = @id")
                    Using cmdStock As New MySqlCommand(qUpdate, conn, transaction)
                        cmdStock.Parameters.AddWithValue("@qty", qty)
                        cmdStock.Parameters.AddWithValue("@id", prodId)
                        cmdStock.ExecuteNonQuery()
                    End Using

                    transaction.Commit()
                    MessageBox.Show("Stock transaction completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    s_numQuantity.Value = 0
                    s_txtRemarks.Clear()

                    ' Refresh all necessary grids
                    S_LoadHistory()
                    M_LoadProducts("")
                    L_LoadAlerts("")
                    O_CategoryFilter_Click(o_pnlCategories.Controls(0), EventArgs.Empty)
                Catch ex As Exception
                    transaction.Rollback()
                    Throw ex
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Transaction failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ==============================
    ' MANAGE SERVICES LOGIC (SV_)
    ' ==============================
    Private _editServiceId As Integer = 0

    Private Sub SR_InitializeTables()
        Try
            OpenConnection()
            Dim qSvc As String = "CREATE TABLE IF NOT EXISTS SERVICE (Service_ID INT PRIMARY KEY AUTO_INCREMENT, Service_Type VARCHAR(50) NOT NULL, Service_Description TEXT, Service_Fee DECIMAL(10,2) NOT NULL CHECK (Service_Fee >= 0));"
            Using cmd As New MySqlCommand(qSvc, conn)
                cmd.ExecuteNonQuery()
            End Using

            Dim qReq As String = "CREATE TABLE IF NOT EXISTS SERVICE_REQUEST (Request_ID INT PRIMARY KEY AUTO_INCREMENT, Customer_ID INT, Service_ID INT, Staff_ID INT, Technician_ID INT, Warranty_ID INT, Request_Date DATETIME, Scheduled_Date DATETIME, Completed_Date DATETIME, Service_Address TEXT, Request_Status VARCHAR(20), Request_Type VARCHAR(50) DEFAULT 'Standard');"
            Using cmd As New MySqlCommand(qReq, conn)
                cmd.ExecuteNonQuery()
            End Using

            Try
                Dim qAlter As String = "ALTER TABLE SERVICE_REQUEST ADD COLUMN Request_Type VARCHAR(50) DEFAULT 'Standard';"
                Using cmdAlter As New MySqlCommand(qAlter, conn)
                    cmdAlter.ExecuteNonQuery()
                End Using
            Catch exAlter As Exception
            End Try

            Dim qWarranty As String = "CREATE TABLE IF NOT EXISTS WARRANTY (Warranty_ID INT PRIMARY KEY AUTO_INCREMENT, Purchase_ID INT, Warranty_Start_Date DATETIME, Warranty_End_Date DATETIME, Warranty_Status VARCHAR(20));"
            Using cmd As New MySqlCommand(qWarranty, conn)
                cmd.ExecuteNonQuery()
            End Using

            Dim qClaim As String = "CREATE TABLE IF NOT EXISTS WARRANTY_CLAIM (Claim_ID INT PRIMARY KEY AUTO_INCREMENT, Warranty_ID INT NOT NULL, Claim_Date DATE NOT NULL, Claim_Description TEXT NOT NULL, Claim_Resolution TEXT);"
            Using cmd As New MySqlCommand(qClaim, conn)
                cmd.ExecuteNonQuery()
            End Using

            Try
                Dim qPopulate As String = "INSERT INTO WARRANTY (Purchase_ID, Warranty_Start_Date, Warranty_End_Date, Warranty_Status) " &
                                          "SELECT Purchase_ID, Purchase_Date, DATE_ADD(Purchase_Date, INTERVAL 1 YEAR), 'Active' " &
                                          "FROM PURCHASE " &
                                          "WHERE Purchase_ID NOT IN (SELECT Purchase_ID FROM WARRANTY)"
                Using cmdPopulate As New MySqlCommand(qPopulate, conn)
                    cmdPopulate.ExecuteNonQuery()
                End Using
            Catch exPop As Exception
            End Try

        Catch ex As Exception
        End Try
    End Sub

    Private Sub SR_LoadServices()
        sv_dgvServices.Rows.Clear()
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("SELECT Service_ID, Service_Type, Service_Description, Service_Fee FROM SERVICE", conn)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        sv_dgvServices.Rows.Add(reader(0), reader(1), reader(2), reader(3))
                    End While
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub sv_btnSave_Click(sender As Object, e As EventArgs) Handles sv_btnSave.Click
        If String.IsNullOrWhiteSpace(sv_txtType.Text) Then
            MessageBox.Show("Please enter a service type.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            OpenConnection()
            If _editServiceId > 0 Then
                Using cmd As New MySqlCommand("UPDATE SERVICE SET Service_Type = @t, Service_Description = @d, Service_Fee = @f WHERE Service_ID = @id", conn)
                    cmd.Parameters.AddWithValue("@t", sv_txtType.Text)
                    cmd.Parameters.AddWithValue("@d", sv_txtDesc.Text)
                    cmd.Parameters.AddWithValue("@f", sv_numFee.Value)
                    cmd.Parameters.AddWithValue("@id", _editServiceId)
                    cmd.ExecuteNonQuery()
                End Using
                MessageBox.Show("Service updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Using cmd As New MySqlCommand("INSERT INTO SERVICE (Service_Type, Service_Description, Service_Fee) VALUES (@t, @d, @f)", conn)
                    cmd.Parameters.AddWithValue("@t", sv_txtType.Text)
                    cmd.Parameters.AddWithValue("@d", sv_txtDesc.Text)
                    cmd.Parameters.AddWithValue("@f", sv_numFee.Value)
                    cmd.ExecuteNonQuery()
                End Using
                MessageBox.Show("Service added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            
            sv_btnCancel_Click(Nothing, Nothing)
            SR_LoadServices()
            SR_PopulateDropdowns()
        Catch ex As Exception
            MessageBox.Show("Error saving service: " & ex.Message)
        End Try
    End Sub

    Private Sub sv_btnCancel_Click(sender As Object, e As EventArgs) Handles sv_btnCancel.Click
        _editServiceId = 0
        sv_txtType.Clear()
        sv_txtDesc.Clear()
        sv_numFee.Value = 0
        sv_btnSave.Text = "Save Service"
        sv_btnCancel.Visible = False
    End Sub

    Private Sub sv_dgvServices_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles sv_dgvServices.CellContentClick
        If e.RowIndex < 0 Then Return

        Dim row = sv_dgvServices.Rows(e.RowIndex)
        Dim srvId = Convert.ToInt32(row.Cells("sv_colID").Value)

        ' Edit Button
        If e.ColumnIndex = sv_dgvServices.Columns("sv_colActionEdit").Index Then
            _editServiceId = srvId
            sv_txtType.Text = row.Cells("sv_colType").Value.ToString()
            sv_txtDesc.Text = If(row.Cells("sv_colDesc").Value IsNot Nothing, row.Cells("sv_colDesc").Value.ToString(), "")
            sv_numFee.Value = Convert.ToDecimal(row.Cells("sv_colFee").Value)
            
            sv_btnSave.Text = "Update Service"
            sv_btnCancel.Visible = True
        End If

        ' Delete Button
        If e.ColumnIndex = sv_dgvServices.Columns("sv_colActionDelete").Index Then
            If MessageBox.Show("Are you sure you want to delete this service?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Try
                    OpenConnection()
                    ' Validation check
                    Dim count As Integer = 0
                    Using checkCmd As New MySqlCommand("SELECT COUNT(*) FROM SERVICE_REQUEST WHERE Service_ID = @id", conn)
                        checkCmd.Parameters.AddWithValue("@id", srvId)
                        count = Convert.ToInt32(checkCmd.ExecuteScalar())
                    End Using

                    If count > 0 Then
                        MessageBox.Show("Cannot delete this service because it is actively used in past or pending Service Requests.", "Constraint Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    Using cmd As New MySqlCommand("DELETE FROM SERVICE WHERE Service_ID = @id", conn)
                        cmd.Parameters.AddWithValue("@id", srvId)
                        cmd.ExecuteNonQuery()
                    End Using
                    MessageBox.Show("Service deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SR_LoadServices()
                    SR_PopulateDropdowns()
                Catch ex As Exception
                    MessageBox.Show("Error deleting service: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    ' ==============================
    ' VIEW SERVICE REQUESTS LOGIC (VR_)
    ' ==============================
    Private Sub SR_LoadRequests()
        vr_dgvRequests.Rows.Clear()
        Try
            OpenConnection()
            Dim q As String = "SELECT sr.Request_ID, c.Full_Name, s.Service_Type, st.Full_Name, IFNULL(tc.Full_Name, 'Unassigned'), sr.Request_Date, sr.Scheduled_Date, sr.Request_Status " &
                              "FROM SERVICE_REQUEST sr " &
                              "JOIN CUSTOMER c ON sr.Customer_ID = c.Customer_ID " &
                              "JOIN SERVICE s ON sr.Service_ID = s.Service_ID " &
                              "JOIN STAFF st ON sr.Staff_ID = st.Staff_ID " &
                              "LEFT JOIN TECHNICIAN t ON sr.Technician_ID = t.Technician_ID " &
                              "LEFT JOIN STAFF tc ON t.Staff_ID = tc.Staff_ID WHERE 1=1"

            If vr_cmbFilterStatus.SelectedIndex > 0 Then
                q &= " AND sr.Request_Status = @stat"
            End If

            Dim searchTxt = vr_txtSearch.Text.Trim()
            If Not String.IsNullOrWhiteSpace(searchTxt) AndAlso searchTxt <> "Search by Customer Name..." Then
                q &= " AND c.Full_Name LIKE @search"
            End If

            q &= " ORDER BY sr.Request_Date DESC"

            Using cmd As New MySqlCommand(q, conn)
                If vr_cmbFilterStatus.SelectedIndex > 0 Then
                    cmd.Parameters.AddWithValue("@stat", vr_cmbFilterStatus.SelectedItem.ToString())
                End If
                If Not String.IsNullOrWhiteSpace(searchTxt) AndAlso searchTxt <> "Search by Customer Name..." Then
                    cmd.Parameters.AddWithValue("@search", "%" & searchTxt & "%")
                End If

                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim sched = If(reader.IsDBNull(6), "Not Scheduled", Convert.ToDateTime(reader(6)).ToString("d"))
                        vr_dgvRequests.Rows.Add(reader(0), reader(1), reader(2), reader(3), reader(4), Convert.ToDateTime(reader(5)).ToString("d"), sched, reader(7))
                    End While
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub vr_cmbFilterStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles vr_cmbFilterStatus.SelectedIndexChanged
        SR_LoadRequests()
    End Sub

    Private Sub vr_txtSearch_TextChanged(sender As Object, e As EventArgs) Handles vr_txtSearch.TextChanged
        SR_LoadRequests()
    End Sub

    Private Sub vr_txtSearch_Enter(sender As Object, e As EventArgs) Handles vr_txtSearch.Enter
        If vr_txtSearch.Text = "Search by Customer Name..." Then
            vr_txtSearch.Text = ""
        End If
    End Sub

    Private Sub vr_txtSearch_Leave(sender As Object, e As EventArgs) Handles vr_txtSearch.Leave
        If String.IsNullOrWhiteSpace(vr_txtSearch.Text) Then
            vr_txtSearch.Text = "Search by Customer Name..."
        End If
    End Sub

    Private Sub vr_dgvRequests_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles vr_dgvRequests.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = vr_dgvRequests.Columns("vr_colActionUpdate").Index Then
            Dim reqId = Convert.ToInt32(vr_dgvRequests.Rows(e.RowIndex).Cells("vr_colReqID").Value)
            Dim currentStatus = vr_dgvRequests.Rows(e.RowIndex).Cells("vr_colStatus").Value.ToString()

            Dim newStatus As String = InputBox("Enter new status (Pending, Scheduled, In Progress, Completed, Cancelled):", "Update Status", currentStatus)
            If String.IsNullOrWhiteSpace(newStatus) Then Return

            Dim validStatuses = {"Pending", "Scheduled", "In Progress", "Completed", "Cancelled"}
            If Not validStatuses.Contains(newStatus, StringComparer.OrdinalIgnoreCase) Then
                MessageBox.Show("Invalid status. Please enter one of the predefined statuses.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Format correctly
            Dim formattedStatus As String = validStatuses.First(Function(s) s.Equals(newStatus, StringComparison.OrdinalIgnoreCase))

            Try
                OpenConnection()
                Dim updateQ As String = "UPDATE SERVICE_REQUEST SET Request_Status = @stat WHERE Request_ID = @id"
                If formattedStatus = "Completed" Then
                    updateQ = "UPDATE SERVICE_REQUEST SET Request_Status = @stat, Completed_Date = @cdate WHERE Request_ID = @id"
                End If

                Using cmd As New MySqlCommand(updateQ, conn)
                    cmd.Parameters.AddWithValue("@stat", formattedStatus)
                    cmd.Parameters.AddWithValue("@id", reqId)
                    If formattedStatus = "Completed" Then
                        cmd.Parameters.AddWithValue("@cdate", DateTime.Now)
                    End If
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                SR_LoadRequests()
            Catch ex As Exception
                MessageBox.Show("Failed to update status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' ==============================
    ' ADD SERVICE REQUEST LOGIC (SR_)
    ' ==============================
    Private Sub SR_PopulateDropdowns()
        Try
            OpenConnection()
            ' Customers
            sr_cmbExistingCust.Items.Clear()
            Using cmd As New MySqlCommand("SELECT Customer_ID, Full_Name FROM CUSTOMER", conn)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        sr_cmbExistingCust.Items.Add(New With {.Text = reader("Full_Name").ToString(), .Value = reader("Customer_ID")})
                    End While
                End Using
            End Using
            sr_cmbExistingCust.DisplayMember = "Text"
            sr_cmbExistingCust.ValueMember = "Value"

            ' Services
            sr_cmbService.Items.Clear()
            Using cmd As New MySqlCommand("SELECT Service_ID, Service_Type FROM SERVICE", conn)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        sr_cmbService.Items.Add(New With {.Text = reader("Service_Type").ToString(), .Value = reader("Service_ID")})
                    End While
                End Using
            End Using
            sr_cmbService.DisplayMember = "Text"
            sr_cmbService.ValueMember = "Value"

            ' Staff
            sr_cmbStaff.Items.Clear()
            Using cmd As New MySqlCommand("SELECT Staff_ID, Full_Name FROM STAFF", conn)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        sr_cmbStaff.Items.Add(New With {.Text = reader("Full_Name").ToString(), .Value = reader("Staff_ID")})
                    End While
                End Using
            End Using
            sr_cmbStaff.DisplayMember = "Text"
            sr_cmbStaff.ValueMember = "Value"

            ' Techs
            sr_cmbTech.Items.Clear()
            Using cmd As New MySqlCommand("SELECT T.Technician_ID, S.Full_Name FROM TECHNICIAN T JOIN STAFF S ON T.Staff_ID = S.Staff_ID", conn)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        sr_cmbTech.Items.Add(New With {.Text = reader("Full_Name").ToString(), .Value = reader("Technician_ID")})
                    End While
                End Using
            End Using
            sr_cmbTech.DisplayMember = "Text"
            sr_cmbTech.ValueMember = "Value"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub sr_cmbExistingCust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sr_cmbExistingCust.SelectedIndexChanged
        If sr_cmbExistingCust.SelectedIndex = -1 Then Return
        Dim cid = Convert.ToInt32(DirectCast(sr_cmbExistingCust.SelectedItem, Object).Value)

        Try
            OpenConnection()
            ' Auto-fill address
            Using cmdAddr As New MySqlCommand("SELECT Home_Address FROM CUSTOMER WHERE Customer_ID = @id", conn)
                cmdAddr.Parameters.AddWithValue("@id", cid)
                Dim addr = cmdAddr.ExecuteScalar()
                If addr IsNot Nothing AndAlso Not DBNull.Value.Equals(addr) Then
                    sr_txtAddress.Text = addr.ToString()
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub sr_optCust_CheckedChanged(sender As Object, e As EventArgs) Handles sr_optExistingCust.CheckedChanged, sr_optNewCust.CheckedChanged
        If sr_optExistingCust.Checked Then
            sr_cmbExistingCust.Visible = True
            sr_txtCustName.Visible = False
            sr_txtCustContact.Visible = False
            sr_txtCustAddress.Visible = False
            sr_lblCust.Text = "Search Existing Customer:"
        Else
            sr_cmbExistingCust.Visible = False
            sr_txtCustName.Visible = True
            sr_txtCustContact.Visible = True
            sr_txtCustAddress.Visible = True
            sr_lblCust.Text = "New Customer Details:"
        End If
    End Sub

    Private Sub sr_txtCustName_Enter(sender As Object, e As EventArgs) Handles sr_txtCustName.Enter
        If sr_txtCustName.Text = "Name..." Then sr_txtCustName.Text = ""
    End Sub
    Private Sub sr_txtCustName_Leave(sender As Object, e As EventArgs) Handles sr_txtCustName.Leave
        If String.IsNullOrWhiteSpace(sr_txtCustName.Text) Then sr_txtCustName.Text = "Name..."
    End Sub
    Private Sub sr_txtCustContact_Enter(sender As Object, e As EventArgs) Handles sr_txtCustContact.Enter
        If sr_txtCustContact.Text = "Contact..." Then sr_txtCustContact.Text = ""
    End Sub
    Private Sub sr_txtCustContact_Leave(sender As Object, e As EventArgs) Handles sr_txtCustContact.Leave
        If String.IsNullOrWhiteSpace(sr_txtCustContact.Text) Then sr_txtCustContact.Text = "Contact..."
    End Sub
    Private Sub sr_txtCustAddress_Enter(sender As Object, e As EventArgs) Handles sr_txtCustAddress.Enter
        If sr_txtCustAddress.Text = "Customer Home Address..." Then sr_txtCustAddress.Text = ""
    End Sub
    Private Sub sr_txtCustAddress_Leave(sender As Object, e As EventArgs) Handles sr_txtCustAddress.Leave
        If String.IsNullOrWhiteSpace(sr_txtCustAddress.Text) Then sr_txtCustAddress.Text = "Customer Home Address..."
    End Sub
    Private Sub sr_txtAddress_Enter(sender As Object, e As EventArgs) Handles sr_txtAddress.Enter
        If sr_txtAddress.Text = "Service Address..." Then sr_txtAddress.Text = ""
    End Sub
    Private Sub sr_txtAddress_Leave(sender As Object, e As EventArgs) Handles sr_txtAddress.Leave
        If String.IsNullOrWhiteSpace(sr_txtAddress.Text) Then sr_txtAddress.Text = "Service Address..."
    End Sub

    Private Sub sr_btnCancel_Click(sender As Object, e As EventArgs) Handles sr_btnCancel.Click
        sr_optExistingCust.Checked = True
        sr_cmbService.SelectedIndex = -1
        sr_cmbStaff.SelectedIndex = -1
        sr_cmbTech.SelectedIndex = -1
        sr_txtAddress.Text = ""
        sr_dtpRequest.Value = DateTime.Now
        sr_dtpScheduled.Checked = False
        sr_cmbStatus.SelectedIndex = 0
    End Sub

    Private Sub sr_btnSave_Click(sender As Object, e As EventArgs) Handles sr_btnSave.Click
        Try
            OpenConnection()
            Using transaction = conn.BeginTransaction()
                Try
                    Dim customerId As Integer = 0
                    If sr_optNewCust.Checked Then
                        Using cmdCust As New MySqlCommand("INSERT INTO CUSTOMER (Full_Name, Contact_Number, Home_Address) VALUES (@name, @contact, @address)", conn, transaction)
                            cmdCust.Parameters.AddWithValue("@name", sr_txtCustName.Text)
                            cmdCust.Parameters.AddWithValue("@contact", sr_txtCustContact.Text)
                            cmdCust.Parameters.AddWithValue("@address", sr_txtCustAddress.Text)
                            cmdCust.ExecuteNonQuery()
                            customerId = Convert.ToInt32(cmdCust.LastInsertedId)
                        End Using
                    Else
                        If sr_cmbExistingCust.SelectedIndex = -1 Then
                            MessageBox.Show("Please select a customer.")
                            transaction.Rollback()
                            Return
                        End If
                        customerId = Convert.ToInt32(DirectCast(sr_cmbExistingCust.SelectedItem, Object).Value)
                    End If

                    If sr_cmbService.SelectedIndex = -1 OrElse sr_cmbStaff.SelectedIndex = -1 Then
                        MessageBox.Show("Please select a service and staff.")
                        transaction.Rollback()
                        Return
                    End If

                    Dim qSave As String = "INSERT INTO SERVICE_REQUEST (Customer_ID, Service_ID, Staff_ID, Technician_ID, Warranty_ID, Request_Date, Scheduled_Date, Service_Address, Request_Status) VALUES (@cid, @sid, @stid, @tid, @wid, @rdate, @sdate, @addr, @status)"
                    Using sqlCmd As New MySqlCommand(qSave, conn, transaction)
                        sqlCmd.Parameters.AddWithValue("@cid", customerId)
                        sqlCmd.Parameters.AddWithValue("@sid", Convert.ToInt32(DirectCast(sr_cmbService.SelectedItem, Object).Value))
                        sqlCmd.Parameters.AddWithValue("@stid", Convert.ToInt32(DirectCast(sr_cmbStaff.SelectedItem, Object).Value))

                        If sr_cmbTech.SelectedIndex = -1 Then
                            sqlCmd.Parameters.AddWithValue("@tid", DBNull.Value)
                        Else
                            sqlCmd.Parameters.AddWithValue("@tid", Convert.ToInt32(DirectCast(sr_cmbTech.SelectedItem, Object).Value))
                        End If

                        sqlCmd.Parameters.AddWithValue("@wid", DBNull.Value)

                        sqlCmd.Parameters.AddWithValue("@rdate", sr_dtpRequest.Value.Date)

                        If sr_dtpScheduled.Checked Then
                            sqlCmd.Parameters.AddWithValue("@sdate", sr_dtpScheduled.Value.Date)
                        Else
                            sqlCmd.Parameters.AddWithValue("@sdate", DBNull.Value)
                        End If

                        sqlCmd.Parameters.AddWithValue("@addr", sr_txtAddress.Text)
                        sqlCmd.Parameters.AddWithValue("@status", sr_cmbStatus.SelectedItem.ToString())
                        sqlCmd.ExecuteNonQuery()
                    End Using

                    transaction.Commit()
                    MessageBox.Show("Service request submitted successfully!")

                    ' Clear
                    sr_btnCancel_Click(Nothing, Nothing)

                    SR_LoadRequests()
                    O_RefreshCart() ' Just in case to reset customer dropdowns
                Catch ex As Exception
                    transaction.Rollback()
                    Throw ex
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Error submitting request: " & ex.Message)
        End Try
    End Sub

    ' ==============================
    ' VIEW WARRANTY LOGIC (WR_)
    ' ==============================
    Public Sub WR_LoadWarranties()
        If wr_dgvWarranties.Columns.Count = 0 Then Return
        wr_dgvWarranties.Rows.Clear()
        Try
            OpenConnection()
            Dim q As String = "SELECT W.Warranty_ID, C.Full_Name, P.Product_Name, PU.Purchase_Date, W.Warranty_Start_Date, W.Warranty_End_Date, W.Warranty_Status " &
                              "FROM WARRANTY W " &
                              "JOIN PURCHASE PU ON W.Purchase_ID = PU.Purchase_ID " &
                              "JOIN CUSTOMER C ON PU.Customer_ID = C.Customer_ID " &
                              "JOIN PURCHASE_ITEMS PI ON PU.Purchase_ID = PI.Purchase_ID " &
                              "JOIN PRODUCT P ON PI.Product_ID = P.Product_ID " &
                              "WHERE (@search = '' OR C.Full_Name LIKE @search OR P.Product_Name LIKE @search) "

            If wr_cmbFilterStatus.SelectedIndex = 1 Then
                q &= "AND W.Warranty_End_Date >= NOW() "
            ElseIf wr_cmbFilterStatus.SelectedIndex = 2 Then
                q &= "AND W.Warranty_End_Date < NOW() "
            End If

            q &= "GROUP BY W.Warranty_ID, C.Full_Name, P.Product_Name, PU.Purchase_Date, W.Warranty_Start_Date, W.Warranty_End_Date, W.Warranty_Status"
            
            Using cmd As New MySqlCommand(q, conn)
                Dim searchParam As String = If(wr_txtSearch.Text = "Search by Customer or Product...", "", "%" & wr_txtSearch.Text & "%")
                cmd.Parameters.AddWithValue("@search", searchParam)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim endDate As DateTime = Convert.ToDateTime(reader("Warranty_End_Date"))
                        Dim status As String = If(endDate >= DateTime.Now, "Active", "Expired")
                        Dim wid As Integer = Convert.ToInt32(reader("Warranty_ID"))
                        wr_dgvWarranties.Rows.Add(wid, reader("Full_Name"), reader("Product_Name"), Convert.ToDateTime(reader("Purchase_Date")).ToString("yyyy-MM-dd"), Convert.ToDateTime(reader("Warranty_Start_Date")).ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"), status)
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading warranties: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub wr_txtSearch_TextChanged(sender As Object, e As EventArgs) Handles wr_txtSearch.TextChanged
        If wr_txtSearch.Text <> "Search by Customer or Product..." Then WR_LoadWarranties()
    End Sub

    Private Sub wr_txtSearch_Enter(sender As Object, e As EventArgs) Handles wr_txtSearch.Enter
        If wr_txtSearch.Text = "Search by Customer or Product..." Then wr_txtSearch.Text = ""
    End Sub

    Private Sub wr_txtSearch_Leave(sender As Object, e As EventArgs) Handles wr_txtSearch.Leave
        If String.IsNullOrWhiteSpace(wr_txtSearch.Text) Then wr_txtSearch.Text = "Search by Customer or Product..."
    End Sub

    Private Sub wr_cmbFilterStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles wr_cmbFilterStatus.SelectedIndexChanged
        WR_LoadWarranties()
    End Sub

    Private Sub wr_dgvWarranties_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles wr_dgvWarranties.CellContentClick
        If e.RowIndex < 0 Then Return
        
        Dim wid As Integer = Convert.ToInt32(wr_dgvWarranties.Rows(e.RowIndex).Cells("wr_colID").Value)
        
        If e.ColumnIndex = wr_dgvWarranties.Columns("wr_colActionEdit").Index Then
            Dim currentEnd As String = wr_dgvWarranties.Rows(e.RowIndex).Cells("wr_colEnd").Value.ToString()
            Dim newDateStr As String = InputBox("Enter new Warranty End Date (yyyy-MM-dd):", "Edit Warranty", currentEnd)
            If String.IsNullOrWhiteSpace(newDateStr) Then Return
            
            Dim newDate As DateTime
            If Not DateTime.TryParse(newDateStr, newDate) Then
                MessageBox.Show("Invalid date format. Please use yyyy-MM-dd.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                OpenConnection()
                Using cmd As New MySqlCommand("UPDATE WARRANTY SET Warranty_End_Date = @wend, Warranty_Status = @stat WHERE Warranty_ID = @id", conn)
                    cmd.Parameters.AddWithValue("@wend", newDate)
                    cmd.Parameters.AddWithValue("@stat", If(newDate >= DateTime.Now, "Active", "Expired"))
                    cmd.Parameters.AddWithValue("@id", wid)
                    cmd.ExecuteNonQuery()
                End Using
                MessageBox.Show("Warranty updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                WR_LoadWarranties()
            Catch ex As Exception
                MessageBox.Show("Error updating warranty: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            
        ElseIf e.ColumnIndex = wr_dgvWarranties.Columns("wr_colActionDelete").Index Then
            If MessageBox.Show("Are you sure you want to delete this warranty? This cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Try
                    OpenConnection()
                    Using cmd As New MySqlCommand("DELETE FROM WARRANTY WHERE Warranty_ID = @id", conn)
                        cmd.Parameters.AddWithValue("@id", wid)
                        cmd.ExecuteNonQuery()
                    End Using
                    MessageBox.Show("Warranty deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    WR_LoadWarranties()
                Catch ex As Exception
                    MessageBox.Show("Error deleting warranty: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    ' ==============================
    ' FILE WARRANTY CLAIM LOGIC (FC_)
    ' ==============================
    Public Sub FC_LoadCustomers()
        fc_cmbCustomer.Items.Clear()
        fc_cmbCustomer.DropDownStyle = ComboBoxStyle.DropDown
        fc_cmbCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        fc_cmbCustomer.AutoCompleteSource = AutoCompleteSource.ListItems
        Try
            OpenConnection()
            ' Only load customers that have warranties
            Dim q As String = "SELECT DISTINCT C.Customer_ID, C.Full_Name FROM CUSTOMER C JOIN PURCHASE PU ON C.Customer_ID = PU.Customer_ID JOIN WARRANTY W ON PU.Purchase_ID = W.Purchase_ID"
            Using cmd As New MySqlCommand(q, conn)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        fc_cmbCustomer.Items.Add(New With {.Text = reader("Full_Name").ToString(), .Value = Convert.ToInt32(reader("Customer_ID"))})
                    End While
                End Using
            End Using
            fc_cmbCustomer.DisplayMember = "Text"
            fc_cmbCustomer.ValueMember = "Value"
            fc_cmbCustomer.SelectedIndex = -1
            fc_cmbProduct.Items.Clear()
            FC_ClearFields()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FC_ClearFields()
        fc_txtPurchDate.Clear()
        fc_txtStart.Clear()
        fc_txtEnd.Clear()
        fc_txtStatus.Clear()
        fc_txtIssue.Clear()
    End Sub

    Private Sub fc_cmbCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles fc_cmbCustomer.SelectedIndexChanged
        fc_cmbProduct.Items.Clear()
        FC_ClearFields()
        If fc_cmbCustomer.SelectedIndex = -1 Then Return

        Dim custId As Integer
        Try
            custId = Convert.ToInt32(DirectCast(fc_cmbCustomer.SelectedItem, Object).Value)
        Catch
            Return
        End Try

        Try
            OpenConnection()
            Dim q As String = "SELECT W.Warranty_ID, P.Product_Name, PI.Quantity, PU.Purchase_Date " &
                              "FROM WARRANTY W JOIN PURCHASE PU ON W.Purchase_ID = PU.Purchase_ID " &
                              "JOIN PURCHASE_ITEMS PI ON PU.Purchase_ID = PI.Purchase_ID " &
                              "JOIN PRODUCT P ON PI.Product_ID = P.Product_ID " &
                              "WHERE PU.Customer_ID = @cid"
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@cid", custId)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim pdate As String = Convert.ToDateTime(reader("Purchase_Date")).ToString("yyyy-MM-dd")
                        Dim txt As String = reader("Product_Name").ToString() & " - " & pdate
                        Dim wid As Integer = Convert.ToInt32(reader("Warranty_ID"))
                        fc_cmbProduct.Items.Add(New With {.Text = txt, .Value = wid})
                    End While
                End Using
            End Using
            fc_cmbProduct.DisplayMember = "Text"
            fc_cmbProduct.ValueMember = "Value"
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub fc_cmbProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles fc_cmbProduct.SelectedIndexChanged
        FC_ClearFields()
        If fc_cmbProduct.SelectedIndex = -1 Then Return
        
        Dim wid As Integer
        Try
            wid = Convert.ToInt32(DirectCast(fc_cmbProduct.SelectedItem, Object).Value)
        Catch
            Return
        End Try

        Try
            OpenConnection()
            Dim q As String = "SELECT PU.Purchase_Date, W.Warranty_Start_Date, W.Warranty_End_Date FROM WARRANTY W JOIN PURCHASE PU ON W.Purchase_ID = PU.Purchase_ID WHERE W.Warranty_ID = @wid"
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@wid", wid)
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        fc_txtPurchDate.Text = Convert.ToDateTime(reader("Purchase_Date")).ToString("yyyy-MM-dd")
                        fc_txtStart.Text = Convert.ToDateTime(reader("Warranty_Start_Date")).ToString("yyyy-MM-dd")
                        Dim dtEnd As DateTime = Convert.ToDateTime(reader("Warranty_End_Date"))
                        fc_txtEnd.Text = dtEnd.ToString("yyyy-MM-dd")
                        fc_txtStatus.Text = If(dtEnd >= DateTime.Now, "Active", "Expired")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading warranty details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub fc_btnSubmit_Click(sender As Object, e As EventArgs) Handles fc_btnSubmit.Click
        If fc_cmbCustomer.SelectedIndex = -1 OrElse fc_cmbProduct.SelectedIndex = -1 Then
            MessageBox.Show("Please select a customer and product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If fc_txtStatus.Text = "Expired" Then
            MessageBox.Show("Warranty has expired. Cannot file claim.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If String.IsNullOrWhiteSpace(fc_txtIssue.Text) Then
            MessageBox.Show("Please describe the issue.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim custId As Integer = Convert.ToInt32(DirectCast(fc_cmbCustomer.SelectedItem, Object).Value)
            Dim wid As Integer = Convert.ToInt32(DirectCast(fc_cmbProduct.SelectedItem, Object).Value)
            OpenConnection()

            Dim qReq As String = "INSERT INTO WARRANTY_CLAIM (Warranty_ID, Claim_Date, Claim_Description) VALUES (@wid, @cdate, @cdesc)"
            Using cmd As New MySqlCommand(qReq, conn)
                cmd.Parameters.AddWithValue("@wid", wid)
                cmd.Parameters.AddWithValue("@cdate", DateTime.Now.Date)
                cmd.Parameters.AddWithValue("@cdesc", fc_txtIssue.Text)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Warranty claim filed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            fc_cmbCustomer.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error filing claim: " & ex.Message)
        End Try
    End Sub

End Class
