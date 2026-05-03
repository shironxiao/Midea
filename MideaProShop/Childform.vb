Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Printing
Imports System.ComponentModel

Public Class Childform

    ' Uses global conn and OpenConnection from MideaProShopModule
    Private _isLoadingSrCustomers As Boolean = False
    Private dashInsightsPanel As Panel
    Private dashRecentGrid As DataGridView
    Private dashInsightLabels As New Dictionary(Of String, Label)
    Private dashActivityTypeFilter As ComboBox
    Private dashActivityDateFilter As ComboBox
    Private v_cmbQuickFilter As ComboBox
    Private v_btnRefresh As Button
    Private l_btnRefresh As Button
    Private _orderAddressColumn As String = ""

    ' ==============================
    ' CHILDFORM CORE
    ' ==============================
    Public Sub New()
        InitializeComponent()

        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then
            InitializeDesignTimeTabPreview()
        End If
    End Sub

    Private Sub InitializeDesignTimeTabPreview()
        Try
            ST_EnsureTabs()
            SUP_InitializeTabIfNeeded()
            RPT_EnsureSalesReportTab()
        Catch
            ' Keep the WinForms designer usable even if a preview tab fails to build.
        End Try
    End Sub

    Private Sub Childform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Hide TabControl headers at runtime
        tcMain.Appearance = TabAppearance.FlatButtons
        tcMain.ItemSize = New Size(0, 1)
        tcMain.SizeMode = TabSizeMode.Fixed

        o_colActionAdd.DefaultCellStyle.BackColor = Color.White
        o_colActionAdd.DefaultCellStyle.ForeColor = Color.Black
        o_colActionRemove.DefaultCellStyle.BackColor = Color.White
        o_colActionRemove.DefaultCellStyle.ForeColor = Color.Black
        
        HideAllPanels()
        V_InitializeHeaderControls()
        WireDashboardCardClicks()
        BuildDashboardExtraContent()
        ' Initialize logic for all modules
        O_LoadCategories()
        O_LoadProducts("")
        V_LoadOrders()
        A_LoadSuppliers()
        M_LoadCategories()
        L_LoadCategories()
        S_InitializeTable()
        SR_InitializeTables()
        ST_InitializeTables()
        S_LoadProducts()
        S_LoadHistory()
        L_LoadAlerts("")
        SR_LoadServices()
        SR_LoadRequests()
        SR_PopulateDropdowns()

        ConfigureDashboardStyle()
        LoadDashboardStats()
        AddHandler tcMain.SelectedIndexChanged, AddressOf tcMain_SelectedIndexChanged

    End Sub

    Private Sub tcMain_SelectedIndexChanged(sender As Object, e As EventArgs)
        If tcMain.SelectedTab Is pnlDashboardMain Then
            LoadDashboardStats()
        End If
    End Sub

    Public Sub HideAllPanels()
        ' Deprecated: TabControl now handles visibility automatically.
    End Sub

    Private Sub WireDashboardCardClicks()
        AttachCardNavigation(pnlCard1, Sub()
                                           ' Navigate to Sales Report when clicking "Total Sales"
                                           RPT_ShowSalesReport()
                                       End Sub)
        AttachCardNavigation(pnlCard2, Sub()
                                           tcMain.SelectedTab = pnlViewOrdersMain
                                           V_LoadOrders()
                                       End Sub)
        AttachCardNavigation(pnlCard3, Sub()
                                           tcMain.SelectedTab = pnlViewServiceRequestsMain
                                           SR_LoadRequests()
                                       End Sub)
        AttachCardNavigation(pnlCard4, Sub()
                                           VC_ShowWarrantyClaims()
                                       End Sub)
    End Sub

    Private Sub AttachCardNavigation(card As Control, action As Action)
        card.Cursor = Cursors.Hand
        AddHandler card.Click, Sub() action()
        For Each child As Control In card.Controls
            child.Cursor = Cursors.Hand
            AddHandler child.Click, Sub() action()
        Next
    End Sub

    Private Sub BuildDashboardExtraContent()
        If dashInsightsPanel IsNot Nothing Then Return

        dashInsightsPanel = New Panel() With {
            .Dock = DockStyle.Top,
            .Height = 90,
            .BackColor = Color.White,
            .Padding = New Padding(20, 10, 20, 10)
        }
        pnlDashboardMain.Controls.Add(dashInsightsPanel)
        dashInsightsPanel.BringToFront()

        Dim keys As String() = {"Active Warranties", "Low Stock Items", "Active Technicians", "Suppliers"}
        For i As Integer = 0 To keys.Length - 1
            Dim x = 10 + (i * 200)
            Dim cardKey = keys(i) ' prevent closure issues in click handlers
            Dim card As New Panel() With {.Location = New Point(x, 8), .Size = New Size(185, 68), .BackColor = Color.FromArgb(245, 245, 248), .BorderStyle = BorderStyle.FixedSingle}
            Dim lblTitle As New Label() With {
                .Text = cardKey,
                .Location = New Point(10, 8),
                .Size = New Size(165, 18),
                .AutoSize = False,
                .TextAlign = ContentAlignment.MiddleCenter,
                .ForeColor = Color.FromArgb(70, 70, 70)
            }
            ' Alignment fix: center the numeric value inside the card.
            Dim lblValue As New Label() With {
                .Text = "0",
                .Location = New Point(10, 30),
                .Size = New Size(165, 28),
                .AutoSize = False,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Font = New Font("Segoe UI", 12, FontStyle.Bold),
                .ForeColor = Color.FromArgb(30, 30, 30)
            }
            card.Controls.Add(lblTitle)
            card.Controls.Add(lblValue)
            dashInsightsPanel.Controls.Add(card)
            dashInsightLabels(keys(i)) = lblValue

            ' Make the 2nd-row dashboard cards clickable.
            card.Cursor = Cursors.Hand
            lblTitle.Cursor = Cursors.Hand
            lblValue.Cursor = Cursors.Hand

            Dim dashAction As Action = Sub()
                                           ' default no-op (keeps handler safe if key mapping changes)
                                       End Sub
            Select Case cardKey
                Case "Active Warranties"
                    dashAction = Sub()
                                      tcMain.SelectedTab = pnlViewWarrantyMain
                                      If wr_cmbFilterStatus IsNot Nothing Then wr_cmbFilterStatus.SelectedIndex = 1 ' Active
                                      WR_LoadWarranties()
                                  End Sub
                Case "Low Stock Items"
                    dashAction = Sub()
                                      tcMain.SelectedTab = pnlLowStockMain
                                      L_LoadAlerts("")
                                  End Sub
                Case "Active Technicians"
                    dashAction = Sub()
                                      ST_ShowManageStaff()
                                      If st_cmbFilter IsNot Nothing Then
                                          st_cmbFilter.SelectedItem = "Technicians Only"
                                          ST_LoadStaffGrid()
                                      End If
                                  End Sub
                Case "Suppliers"
                    dashAction = Sub()
                                      SUP_ShowManageSupplier()
                                  End Sub
            End Select

            AddHandler card.Click, Sub() dashAction()
            AddHandler lblTitle.Click, Sub() dashAction()
            AddHandler lblValue.Click, Sub() dashAction()
        Next

        Dim pnlRecentWrap As New Panel() With {.Dock = DockStyle.Fill, .BackColor = Color.White, .Padding = New Padding(20, 10, 20, 20)}
        Dim lblRecent As New Label() With {.Text = "Recent Activity", .Dock = DockStyle.Top, .Height = 28, .Font = New Font("Segoe UI", 12, FontStyle.Bold), .ForeColor = Color.FromArgb(40, 40, 40)}
        Dim pnlRecentFilters As New Panel() With {.Dock = DockStyle.Top, .Height = 34}
        dashActivityTypeFilter = New ComboBox() With {.Location = New Point(0, 4), .Size = New Size(170, 24), .DropDownStyle = ComboBoxStyle.DropDownList}
        dashActivityTypeFilter.Items.AddRange(New String() {"All Activities", "Order", "Service Request", "Warranty Claim"})
        dashActivityTypeFilter.SelectedIndex = 0
        AddHandler dashActivityTypeFilter.SelectedIndexChanged, Sub() LoadDashboardRecentActivity()
        pnlRecentFilters.Controls.Add(dashActivityTypeFilter)

        dashActivityDateFilter = New ComboBox() With {.Location = New Point(180, 4), .Size = New Size(150, 24), .DropDownStyle = ComboBoxStyle.DropDownList}
        dashActivityDateFilter.Items.AddRange(New String() {"Last 7 Days", "This Month", "This Year", "All"})
        dashActivityDateFilter.SelectedIndex = 0
        AddHandler dashActivityDateFilter.SelectedIndexChanged, Sub() LoadDashboardRecentActivity()
        pnlRecentFilters.Controls.Add(dashActivityDateFilter)

        dashRecentGrid = New DataGridView() With {
            .Dock = DockStyle.Fill,
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .ReadOnly = True,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            .RowHeadersVisible = False,
            .BackgroundColor = Color.White
        }
        dashRecentGrid.Columns.Add("dash_colType", "Type")
        dashRecentGrid.Columns.Add("dash_colInfo", "Details")
        dashRecentGrid.Columns.Add("dash_colDate", "Date")
        pnlRecentWrap.Controls.Add(dashRecentGrid)
        pnlRecentWrap.Controls.Add(pnlRecentFilters)
        pnlRecentWrap.Controls.Add(lblRecent)
        pnlDashboardMain.Controls.Add(pnlRecentWrap)
        pnlRecentWrap.BringToFront()
    End Sub

    Private Sub ConfigureDashboardStyle()
        Dim cards = New Panel() {pnlCard1, pnlCard2, pnlCard3, pnlCard4}
        Dim titles = New Label() {lblCard1Title, lblCard2Title, lblCard3Title, lblCard4Title}
        Dim values = New Label() {lblCard1Value, lblCard2Value, lblCard3Value, lblCard4Value}

        For Each card In cards
            card.BackColor = Color.White
            card.BorderStyle = BorderStyle.FixedSingle
        Next
        For Each lbl In titles
            lbl.ForeColor = Color.FromArgb(70, 70, 70)
        Next
        For Each lbl In values
            lbl.ForeColor = Color.FromArgb(30, 30, 30)
        Next
    End Sub

    Private Sub LoadDashboardStats()
        Try
            OpenConnection()
            Using cmdSales As New MySqlCommand("SELECT IFNULL(SUM(Quantity * Item_Price), 0) FROM PURCHASE_ITEMS", conn)
                lblCard1Value.Text = "₱" & Convert.ToDecimal(cmdSales.ExecuteScalar()).ToString("N2")
            End Using
            Using cmdTrans As New MySqlCommand("SELECT COUNT(*) FROM PURCHASE", conn)
                lblCard2Value.Text = Convert.ToInt32(cmdTrans.ExecuteScalar()).ToString("N0")
            End Using
            Using cmdSvc As New MySqlCommand("SELECT COUNT(*) FROM SERVICE_REQUEST", conn)
                lblCard3Value.Text = Convert.ToInt32(cmdSvc.ExecuteScalar()).ToString("N0")
            End Using
            Using cmdWar As New MySqlCommand("SELECT COUNT(*) FROM WARRANTY_CLAIM", conn)
                lblCard4Value.Text = Convert.ToInt32(cmdWar.ExecuteScalar()).ToString("N0")
            End Using

            If dashInsightLabels.Count > 0 Then
                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM WARRANTY WHERE Warranty_End_Date >= CURDATE()", conn)
                    dashInsightLabels("Active Warranties").Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0")
                End Using
                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM PRODUCT WHERE Stock_Quantity <= Reorder_Level", conn)
                    dashInsightLabels("Low Stock Items").Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0")
                End Using
                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM TECHNICIAN WHERE Technician_Status = 'Active'", conn)
                    dashInsightLabels("Active Technicians").Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0")
                End Using
                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM SUPPLIER", conn)
                    dashInsightLabels("Suppliers").Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0")
                End Using
            End If

            LoadDashboardRecentActivity()
        Catch ex As Exception
            lblCard1Value.Text = "₱0.00"
            lblCard2Value.Text = "0"
            lblCard3Value.Text = "0"
            lblCard4Value.Text = "0"
            If dashInsightLabels.Count > 0 Then
                For Each key In dashInsightLabels.Keys.ToList()
                    dashInsightLabels(key).Text = "0"
                Next
            End If
            If dashRecentGrid IsNot Nothing Then dashRecentGrid.Rows.Clear()
        End Try
    End Sub

    Private Sub LoadDashboardRecentActivity()
        If dashRecentGrid Is Nothing Then Return
        dashRecentGrid.Rows.Clear()
        Try
            Dim typeFilter As String = If(dashActivityTypeFilter Is Nothing OrElse dashActivityTypeFilter.SelectedItem Is Nothing, "All Activities", dashActivityTypeFilter.SelectedItem.ToString())
            Dim dateFilter As String = If(dashActivityDateFilter Is Nothing OrElse dashActivityDateFilter.SelectedItem Is Nothing, "Last 7 Days", dashActivityDateFilter.SelectedItem.ToString())

            Dim q As String = "SELECT ActivityType, Details, ActDate FROM (" &
                              "SELECT 'Order' AS ActivityType, CONCAT('Receipt ', P.Receipt_Number, ' - ', C.Full_Name) AS Details, P.Purchase_Date AS ActDate " &
                              "FROM PURCHASE P JOIN CUSTOMER C ON P.Customer_ID = C.Customer_ID " &
                              "UNION ALL " &
                              "SELECT 'Service Request', CONCAT('Request #', SR.Request_ID, ' - ', C.Full_Name) AS Details, SR.Request_Date AS ActDate " &
                              "FROM SERVICE_REQUEST SR JOIN CUSTOMER C ON SR.Customer_ID = C.Customer_ID " &
                              "UNION ALL " &
                              "SELECT 'Warranty Claim', CONCAT('Claim #', WC.Claim_ID, ' - ', IFNULL(WC.Claim_Status, 'Pending')) AS Details, WC.Claim_Date AS ActDate " &
                              "FROM WARRANTY_CLAIM WC" &
                              ") AS A WHERE 1=1 "

            If typeFilter <> "All Activities" Then
                q &= "AND ActivityType = @atype "
            End If

            Select Case dateFilter
                Case "Last 7 Days"
                    q &= "AND ActDate >= @startDate "
                Case "This Month"
                    q &= "AND ActDate >= @startDate "
                Case "This Year"
                    q &= "AND ActDate >= @startDate "
            End Select

            q &= "ORDER BY ActDate DESC LIMIT 10"

            Using cmd As New MySqlCommand(q, conn)
                If typeFilter <> "All Activities" Then
                    cmd.Parameters.AddWithValue("@atype", typeFilter)
                End If

                Select Case dateFilter
                    Case "Last 7 Days"
                        cmd.Parameters.AddWithValue("@startDate", DateTime.Now.Date.AddDays(-6))
                    Case "This Month"
                        cmd.Parameters.AddWithValue("@startDate", New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1))
                    Case "This Year"
                        cmd.Parameters.AddWithValue("@startDate", New DateTime(DateTime.Now.Year, 1, 1))
                End Select

                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        dashRecentGrid.Rows.Add(reader("ActivityType").ToString(), reader("Details").ToString(), Convert.ToDateTime(reader("ActDate")).ToString("yyyy-MM-dd"))
                    End While
                End Using
            End Using
        Catch ex As Exception
        End Try
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

    Private Class OrderEditLine
        Public Property ProductID As Integer
        Public Property ProductName As String
        Public Property Quantity As Integer
        Public Property UnitPrice As Decimal
    End Class

    Private Sub O_LoadCategories()
        o_pnlCategories.Controls.Clear()
        Dim btnAll As New Button()
        btnAll.Text = "All Categories"
        btnAll.Tag = ""
        btnAll.Size = New Size(150, 40)
        btnAll.FlatStyle = FlatStyle.Flat
        btnAll.BackColor = Color.FromArgb(0, 120, 215)
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
        btn.BackColor = Color.FromArgb(0, 120, 215)
        btn.ForeColor = Color.White
        O_LoadProducts(btn.Tag.ToString())
    End Sub

    Private Sub O_LoadProducts(category As String)
        o_dgvProducts.Rows.Clear()
        Try
            OpenConnection()
            Dim query As String = "SELECT Product_ID, Product_Name, Brand, Product_Description, Unit_Price, Stock_Quantity FROM PRODUCT WHERE Stock_Quantity > 0"
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
                        Dim brand = If(reader.IsDBNull(reader.GetOrdinal("Brand")), "", reader.GetString("Brand"))
                        Dim desc = If(reader.IsDBNull(reader.GetOrdinal("Product_Description")), "", reader.GetString("Product_Description"))
                        Dim price = reader.GetDecimal("Unit_Price")
                        Dim stock = reader.GetInt32("Stock_Quantity")

                        o_dgvProducts.Rows.Add(id, name, brand, desc, price, stock)
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub o_dgvProducts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles o_dgvProducts.CellContentClick
        If e.RowIndex < 0 Then Return

        Dim row = o_dgvProducts.Rows(e.RowIndex)
        Dim prodId = Convert.ToInt32(row.Cells("o_colProductID").Value)

        If e.ColumnIndex = o_dgvProducts.Columns("o_colActionAdd").Index Then
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
        ElseIf e.ColumnIndex = o_dgvProducts.Columns("o_colActionRemove").Index Then
            O_DecreaseCartItemByProductId(prodId)
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

            pnlItem.Controls.Add(lblName)
            pnlItem.Controls.Add(lblPrice)

            o_flpCartItems.Controls.Add(pnlItem)
        Next

        o_lblTotal.Text = "₱" & _totalAmount.ToString("N2")
        o_btnContinue.Enabled = _cart.Count > 0
    End Sub

    Private Sub O_DecreaseCartItemByProductId(productId As Integer)
        Dim item = _cart.FirstOrDefault(Function(c) c.ProductID = productId)
        If item Is Nothing Then Return
        item.Quantity -= 1
        If item.Quantity <= 0 Then
            _cart.Remove(item)
        End If
        O_RefreshCart()
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
        O_LoadStaff()
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

    Private Sub O_LoadStaff()
        o_cmbAssignStaff.Items.Clear()
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("SELECT Staff_ID, Full_Name FROM STAFF", conn)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        o_cmbAssignStaff.Items.Add(New With {.Text = reader("Full_Name").ToString(), .Value = reader("Staff_ID")})
                    End While
                End Using
            End Using
            o_cmbAssignStaff.DisplayMember = "Text"
            o_cmbAssignStaff.ValueMember = "Value"
            If o_cmbAssignStaff.Items.Count > 0 Then o_cmbAssignStaff.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Error loading staff: " & ex.Message)
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
                    Dim staffId As Integer = 0
                    If o_cmbAssignStaff.SelectedItem IsNot Nothing Then
                        staffId = Convert.ToInt32(DirectCast(o_cmbAssignStaff.SelectedItem, Object).Value)
                    End If
                    Using cmdPurch As New MySqlCommand("INSERT INTO PURCHASE (Customer_ID, Staff_ID, Purchase_Date, Receipt_Number) VALUES (@cid, @sid, @pdate, @receipt)", conn, transaction)
                        cmdPurch.Parameters.AddWithValue("@cid", customerId)
                        cmdPurch.Parameters.AddWithValue("@sid", staffId)
                        cmdPurch.Parameters.AddWithValue("@pdate", DateTime.Now)
                        cmdPurch.Parameters.AddWithValue("@receipt", receiptNo)
                        cmdPurch.ExecuteNonQuery()
                        purchaseId = Convert.ToInt32(cmdPurch.LastInsertedId)
                    End Using

                    ' 3. Create Purchase Items & Update Stock & Log Transaction
                    For Each item In _cart
                        Dim itemId As Integer = 0
                        Using cmdItem As New MySqlCommand("INSERT INTO PURCHASE_ITEMS (Purchase_ID, Product_ID, Quantity, Item_Price) VALUES (@pid, @prodid, @qty, @price)", conn, transaction)
                            cmdItem.Parameters.AddWithValue("@pid", purchaseId)
                            cmdItem.Parameters.AddWithValue("@prodid", item.ProductID)
                            cmdItem.Parameters.AddWithValue("@qty", item.Quantity)
                            cmdItem.Parameters.AddWithValue("@price", item.Price)
                            cmdItem.ExecuteNonQuery()
                            itemId = Convert.ToInt32(cmdItem.LastInsertedId)
                        End Using

                        ' Create a warranty row per purchased item row.
                        Using cmdWarranty As New MySqlCommand("INSERT INTO WARRANTY (Item_ID, Warranty_Start_Date, Warranty_End_Date, Warranty_Status) VALUES (@itemId, @wstart, @wend, 'Active')", conn, transaction)
                            cmdWarranty.Parameters.AddWithValue("@itemId", itemId)
                            cmdWarranty.Parameters.AddWithValue("@wstart", DateTime.Now.Date)
                            cmdWarranty.Parameters.AddWithValue("@wend", DateTime.Now.Date.AddYears(1))
                            cmdWarranty.ExecuteNonQuery()
                        End Using

                        Dim currentStock As Integer
                        Using cmdCheckStock As New MySqlCommand("SELECT Stock_Quantity FROM PRODUCT WHERE Product_ID = @prodid FOR UPDATE", conn, transaction)
                            cmdCheckStock.Parameters.AddWithValue("@prodid", item.ProductID)
                            Dim stockObj = cmdCheckStock.ExecuteScalar()
                            If stockObj Is Nothing OrElse stockObj Is DBNull.Value Then
                                Throw New Exception("Product not found while updating stock. Product ID: " & item.ProductID.ToString())
                            End If
                            currentStock = Convert.ToInt32(stockObj)
                        End Using

                        If currentStock < item.Quantity Then
                            Throw New Exception("Insufficient stock for product '" & item.ProductName & "'. Available: " & currentStock.ToString() & ", Requested: " & item.Quantity.ToString())
                        End If

                        Using cmdStock As New MySqlCommand("UPDATE PRODUCT SET Stock_Quantity = Stock_Quantity - @qty WHERE Product_ID = @prodid AND Stock_Quantity >= @qty", conn, transaction)
                            cmdStock.Parameters.AddWithValue("@qty", item.Quantity)
                            cmdStock.Parameters.AddWithValue("@prodid", item.ProductID)
                            Dim affected = cmdStock.ExecuteNonQuery()
                            If affected <> 1 Then
                                Throw New Exception("Stock update failed for product ID " & item.ProductID.ToString() & ".")
                            End If
                        End Using

                        Using cmdLog As New MySqlCommand("INSERT INTO STOCK_TRANSACTION (Product_ID, Transaction_Type, Quantity, Transaction_Date, Remarks) VALUES (@prodid, 'Sale', @qty, @tdate, @remarks)", conn, transaction)
                            cmdLog.Parameters.AddWithValue("@prodid", item.ProductID)
                            cmdLog.Parameters.AddWithValue("@qty", item.Quantity)
                            cmdLog.Parameters.AddWithValue("@tdate", DateTime.Now)
                            cmdLog.Parameters.AddWithValue("@remarks", "Order " & receiptNo & " | Customer: " & If(o_optNewCustomer.Checked, o_txtCustName.Text.Trim(), DirectCast(o_cmbExistingCustomer.SelectedItem, Object).Text.ToString()) & " | Product: " & item.ProductName)
                            cmdLog.ExecuteNonQuery()
                        End Using
                    Next

                    transaction.Commit()
                    If MessageBox.Show("Order successfully placed!" & vbCrLf & "Receipt: " & receiptNo & vbCrLf & vbCrLf & "Would you like to print the receipt now?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                        PrintReceipt(purchaseId)
                    End If

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
                    L_LoadAlerts("")
                    LoadDashboardStats()
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
    Private Sub V_InitializeHeaderControls()
        If v_cmbQuickFilter IsNot Nothing Then Return

        v_lblDateRange.Text = "Quick Filter:"
        v_dtpStart.Visible = False
        v_lblTo.Visible = False
        v_dtpEnd.Visible = False
        v_btnFilter.Visible = False

        v_cmbQuickFilter = New ComboBox() With {
            .DropDownStyle = ComboBoxStyle.DropDownList,
            .Location = New Point(380, 25),
            .Size = New Size(170, 24)
        }
        v_cmbQuickFilter.Items.AddRange(New String() {"Today", "This Week", "This Month", "Last 30 Days", "This Year", "All"})
        v_cmbQuickFilter.SelectedIndex = 0
        AddHandler v_cmbQuickFilter.SelectedIndexChanged, Sub() V_LoadOrders()
        v_pnlHeader.Controls.Add(v_cmbQuickFilter)

        v_btnRefresh = New Button() With {
            .Text = "Refresh",
            .BackColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .ForeColor = Color.Black,
            .Location = New Point(570, 20),
            .Size = New Size(75, 35)
        }
        AddHandler v_btnRefresh.Click, Sub() V_LoadOrders()
        v_pnlHeader.Controls.Add(v_btnRefresh)
    End Sub

    Private Sub V_LoadOrders()
        v_dgvOrders.Rows.Clear()
        Try
            OpenConnection()
            Dim query As String = "SELECT p.Purchase_ID, p.Receipt_Number, p.Purchase_Date, c.Full_Name, " &
                                  "IFNULL(s.Full_Name, 'None') AS Staff_Name, " &
                                  "IFNULL((SELECT GROUP_CONCAT(CONCAT(pr.Product_Name, ' x', pi2.Quantity) ORDER BY pr.Product_Name SEPARATOR ', ') " &
                                  "FROM PURCHASE_ITEMS pi2 " &
                                  "JOIN PRODUCT pr ON pr.Product_ID = pi2.Product_ID " &
                                  "WHERE pi2.Purchase_ID = p.Purchase_ID), '') AS Products, " &
                                  "IFNULL((SELECT SUM(Quantity * Item_Price) FROM PURCHASE_ITEMS WHERE Purchase_ID = p.Purchase_ID), 0) AS Total_Amount " &
                                  "FROM PURCHASE p JOIN CUSTOMER c ON p.Customer_ID = c.Customer_ID " &
                                  "LEFT JOIN STAFF s ON p.Staff_ID = s.Staff_ID WHERE 1=1 "

            Dim startDate As DateTime = DateTime.MinValue
            Dim endDate As DateTime = DateTime.MaxValue
            V_GetOrderDateRange(startDate, endDate)

            If startDate <> DateTime.MinValue AndAlso endDate <> DateTime.MaxValue Then
                query &= "AND p.Purchase_Date >= @start AND p.Purchase_Date <= @end "
            End If

            If v_txtSearch IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(v_txtSearch.Text) Then
                query &= "AND (c.Full_Name LIKE @search " &
                         "OR p.Receipt_Number LIKE @search " &
                         "OR IFNULL(s.Full_Name, '') LIKE @search " &
                         "OR EXISTS (SELECT 1 FROM PURCHASE_ITEMS pi3 JOIN PRODUCT pr3 ON pi3.Product_ID = pr3.Product_ID WHERE pi3.Purchase_ID = p.Purchase_ID AND pr3.Product_Name LIKE @search)) "
            End If

            query &= "ORDER BY p.Purchase_Date DESC"

            Using cmd As New MySqlCommand(query, conn)
                If startDate <> DateTime.MinValue AndAlso endDate <> DateTime.MaxValue Then
                    cmd.Parameters.AddWithValue("@start", startDate.Date)
                    cmd.Parameters.AddWithValue("@end", endDate.Date.AddDays(1).AddTicks(-1))
                End If
                If v_txtSearch IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(v_txtSearch.Text) Then
                    cmd.Parameters.AddWithValue("@search", "%" & v_txtSearch.Text.Trim() & "%")
                End If
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim id = reader.GetInt32(0)
                        Dim receipt = reader.GetString(1)
                        Dim dt = reader.GetDateTime(2)
                        Dim customer = reader.GetString(3)
                        Dim staff = reader.GetString(4)
                        Dim products = reader.GetString(5)
                        Dim total = reader.GetDecimal(6)
                        v_dgvOrders.Rows.Add(id, receipt, dt.ToString("g"), customer, staff, products, total)
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub v_txtSearch_TextChanged(sender As Object, e As EventArgs) Handles v_txtSearch.TextChanged
        V_LoadOrders()
        If v_txtSearch.Text.Trim() <> "" AndAlso v_dgvOrders.Rows.Count > 0 Then
            V_PopulateDetailPanel(0)
        Else
            v_pnlDetailForm.Visible = False
        End If
    End Sub

    Private _detailOrderPurchaseId As Integer = 0
    Private _detailOrderRowIndex As Integer = -1

    Private Sub V_PopulateDetailPanel(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= v_dgvOrders.Rows.Count Then
            v_pnlDetailForm.Visible = False
            Return
        End If
        _detailOrderRowIndex = rowIndex
        _detailOrderPurchaseId = Convert.ToInt32(v_dgvOrders.Rows(rowIndex).Cells("v_colPurchaseID").Value)

        v_lblDetailReceipt.Text = "Receipt: " & v_dgvOrders.Rows(rowIndex).Cells("v_colReceipt").Value.ToString()
        v_lblDetailCustomer.Text = "Customer: " & v_dgvOrders.Rows(rowIndex).Cells("v_colCustomer").Value.ToString()
        v_lblDetailStaff.Text = "Staff: " & v_dgvOrders.Rows(rowIndex).Cells("v_colStaff").Value.ToString()
        v_lblDetailDate.Text = "Date: " & v_dgvOrders.Rows(rowIndex).Cells("v_colDate").Value.ToString()
        v_lblDetailProducts.Text = "Items: " & v_dgvOrders.Rows(rowIndex).Cells("v_colProducts").Value.ToString()
        v_lblDetailTotal.Text = "Total: " & Convert.ToDecimal(v_dgvOrders.Rows(rowIndex).Cells("v_colTotalAmount").Value).ToString("C2")
        v_pnlDetailForm.Visible = True
    End Sub

    Private Sub v_btnDetailEdit_Click(sender As Object, e As EventArgs) Handles v_btnDetailEdit.Click
        If _detailOrderPurchaseId = 0 Then Return
        V_EditOrder(_detailOrderPurchaseId, _detailOrderRowIndex)
        v_pnlDetailForm.Visible = False
    End Sub

    Private Sub v_btnDetailClose_Click(sender As Object, e As EventArgs) Handles v_btnDetailClose.Click
        v_pnlDetailForm.Visible = False
    End Sub

    Private Sub v_btnFilter_Click(sender As Object, e As EventArgs) Handles v_btnFilter.Click
        V_LoadOrders()
    End Sub

    Private Sub V_GetOrderDateRange(ByRef startDate As DateTime, ByRef endDate As DateTime)
        startDate = DateTime.MinValue
        endDate = DateTime.MaxValue
        If v_cmbQuickFilter Is Nothing OrElse v_cmbQuickFilter.SelectedItem Is Nothing Then Return

        Dim nowDate = DateTime.Now.Date
        Select Case v_cmbQuickFilter.SelectedItem.ToString()
            Case "Today"
                startDate = nowDate
                endDate = nowDate
            Case "This Week"
                Dim mondayOffset As Integer = (CInt(nowDate.DayOfWeek) + 6) Mod 7
                Dim weekStart = nowDate.AddDays(-mondayOffset)
                startDate = weekStart
                endDate = weekStart.AddDays(6)
            Case "This Month"
                startDate = New DateTime(nowDate.Year, nowDate.Month, 1)
                endDate = startDate.AddMonths(1).AddDays(-1)
            Case "Last 30 Days"
                startDate = nowDate.AddDays(-29)
                endDate = nowDate
            Case "This Year"
                startDate = New DateTime(nowDate.Year, 1, 1)
                endDate = New DateTime(nowDate.Year, 12, 31)
            Case Else ' All
        End Select
    End Sub

    Private Sub v_dgvOrders_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles v_dgvOrders.CellContentClick
        If e.RowIndex < 0 Then Return
        Dim purchaseId As Integer = Convert.ToInt32(v_dgvOrders.Rows(e.RowIndex).Cells("v_colPurchaseID").Value)

        If e.ColumnIndex = v_dgvOrders.Columns("v_colActionEdit").Index Then
            V_EditOrder(purchaseId, e.RowIndex)
        ElseIf e.ColumnIndex = v_dgvOrders.Columns("v_colActionDelete").Index Then
            V_DeleteOrder(purchaseId)
        ElseIf e.ColumnIndex = v_dgvOrders.Columns("v_colActionPrint").Index Then
            PrintReceipt(purchaseId)
        End If
    End Sub

    Private Sub v_dgvOrders_SelectionChanged(sender As Object, e As EventArgs) Handles v_dgvOrders.SelectionChanged
        If v_pnlDetailForm.Visible AndAlso v_dgvOrders.SelectedRows.Count > 0 Then
            V_PopulateDetailPanel(v_dgvOrders.SelectedRows(0).Index)
        End If
    End Sub

    Private Sub V_EditOrder(purchaseId As Integer, rowIndex As Integer)
        Dim currentReceipt As String = v_dgvOrders.Rows(rowIndex).Cells("v_colReceipt").Value.ToString()
        Dim currentCustomer As String = v_dgvOrders.Rows(rowIndex).Cells("v_colCustomer").Value.ToString()
        Dim editedLines As List(Of OrderEditLine) = Nothing

        If Not V_ShowOrderEditForm(purchaseId, currentReceipt, currentCustomer, editedLines) Then Return

        Try
            OpenConnection()
            Using tx = conn.BeginTransaction()
                Try
                    V_SaveEditedOrderItems(purchaseId, editedLines, tx)
                    tx.Commit()
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
            MessageBox.Show("Order updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            V_LoadOrders()
            L_LoadAlerts("")
            LoadDashboardStats()
        Catch ex As Exception
            MessageBox.Show("Failed to update order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function V_ShowOrderEditForm(purchaseId As Integer, currentReceipt As String, currentCustomer As String, ByRef editedLines As List(Of OrderEditLine)) As Boolean
        Dim sourceProducts As DataTable = V_GetEditableProducts()
        Dim currentLines As List(Of OrderEditLine) = V_GetOrderItemsForEdit(purchaseId)
        Dim originalTotal As Decimal = currentLines.Sum(Function(x) x.UnitPrice * x.Quantity)

        Using frm As New Form()
            frm.Text = "Edit Order"
            frm.StartPosition = FormStartPosition.CenterParent
            frm.FormBorderStyle = FormBorderStyle.FixedDialog
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ClientSize = New Size(860, 560)

            Dim lblReceipt As New Label() With {.Text = "Receipt Number", .Location = New Point(20, 15), .AutoSize = True}
            Dim txtReceipt As New TextBox() With {.Location = New Point(20, 36), .Size = New Size(180, 24), .Text = currentReceipt, .ReadOnly = True}
            Dim lblCustomer As New Label() With {.Text = "Customer", .Location = New Point(220, 15), .AutoSize = True}
            Dim txtCustomer As New TextBox() With {.Location = New Point(220, 36), .Size = New Size(300, 24), .Text = currentCustomer, .ReadOnly = True}

            Dim dgvItems As New DataGridView() With {
                .Location = New Point(20, 75),
                .Size = New Size(820, 320),
                .AllowUserToAddRows = False,
                .AllowUserToDeleteRows = False,
                .ReadOnly = False,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            }
            dgvItems.Columns.Add("colProductID", "Product ID")
            dgvItems.Columns("colProductID").Visible = False
            dgvItems.Columns.Add("colProductName", "Product")
            dgvItems.Columns("colProductName").ReadOnly = True
            dgvItems.Columns.Add("colUnitPrice", "Unit Price")
            dgvItems.Columns("colUnitPrice").ReadOnly = True
            dgvItems.Columns.Add("colQty", "Quantity")
            dgvItems.Columns.Add(New DataGridViewButtonColumn() With {.Name = "colRemove", .HeaderText = "Action", .Text = "Remove", .UseColumnTextForButtonValue = True})

            For Each line In currentLines
                dgvItems.Rows.Add(line.ProductID, line.ProductName, line.UnitPrice.ToString("N2"), line.Quantity)
            Next

            Dim lblAddProduct As New Label() With {.Text = "Add Product", .Location = New Point(20, 415), .AutoSize = True}
            Dim cmbProduct As New ComboBox() With {.Location = New Point(20, 438), .Size = New Size(360, 24), .DropDownStyle = ComboBoxStyle.DropDownList}
            cmbProduct.DataSource = sourceProducts
            cmbProduct.DisplayMember = "Product_Name"
            cmbProduct.ValueMember = "Product_ID"

            Dim lblQty As New Label() With {.Text = "Qty", .Location = New Point(395, 415), .AutoSize = True}
            Dim numQty As New NumericUpDown() With {.Location = New Point(395, 438), .Size = New Size(80, 24), .Minimum = 1, .Maximum = 9999, .Value = 1}
            Dim btnAddProduct As New Button() With {.Text = "Add", .Location = New Point(490, 434), .Size = New Size(90, 32)}
            Dim lblTotal As New Label() With {.Text = "Total: 0.00", .Location = New Point(20, 480), .AutoSize = True, .Font = New Font("Segoe UI", 11, FontStyle.Bold)}

            Dim refreshTotal As Action = Sub()
                                             Dim total As Decimal = 0D
                                             For Each r As DataGridViewRow In dgvItems.Rows
                                                 If r.IsNewRow Then Continue For
                                                 Dim price As Decimal = Convert.ToDecimal(r.Cells("colUnitPrice").Value)
                                                 Dim qty As Integer = Convert.ToInt32(r.Cells("colQty").Value)
                                                 total += price * qty
                                             Next
                                             lblTotal.Text = "Total: " & total.ToString("N2")
                                         End Sub
            refreshTotal()

            AddHandler btnAddProduct.Click, Sub()
                                                If cmbProduct.SelectedValue Is Nothing Then Return
                                                Dim prodId As Integer = Convert.ToInt32(cmbProduct.SelectedValue)
                                                Dim prodName As String = cmbProduct.Text
                                                Dim unitPrice As Decimal = 0D
                                                For Each dr As DataRow In sourceProducts.Rows
                                                    If Convert.ToInt32(dr("Product_ID")) = prodId Then
                                                        unitPrice = Convert.ToDecimal(dr("Unit_Price"))
                                                        Exit For
                                                    End If
                                                Next

                                                Dim existingRow As DataGridViewRow = Nothing
                                                For Each r As DataGridViewRow In dgvItems.Rows
                                                    If r.IsNewRow Then Continue For
                                                    If Convert.ToInt32(r.Cells("colProductID").Value) = prodId Then
                                                        existingRow = r
                                                        Exit For
                                                    End If
                                                Next

                                                If existingRow Is Nothing Then
                                                    dgvItems.Rows.Add(prodId, prodName, unitPrice.ToString("N2"), Convert.ToInt32(numQty.Value))
                                                Else
                                                    existingRow.Cells("colQty").Value = Convert.ToInt32(existingRow.Cells("colQty").Value) + Convert.ToInt32(numQty.Value)
                                                End If
                                                refreshTotal()
                                            End Sub

            AddHandler dgvItems.CellContentClick, Sub(sender, e)
                                                      If e.RowIndex < 0 Then Return
                                                      If dgvItems.Columns(e.ColumnIndex).Name = "colRemove" Then
                                                          dgvItems.Rows.RemoveAt(e.RowIndex)
                                                          refreshTotal()
                                                      End If
                                                  End Sub

            AddHandler dgvItems.CellEndEdit, Sub(sender, e)
                                                 If e.RowIndex < 0 Then Return
                                                 If dgvItems.Columns(e.ColumnIndex).Name = "colQty" Then
                                                     Dim cellValue = dgvItems.Rows(e.RowIndex).Cells("colQty").Value
                                                     Dim parsed As Integer
                                                     If cellValue Is Nothing OrElse Not Integer.TryParse(cellValue.ToString(), parsed) OrElse parsed <= 0 Then
                                                         dgvItems.Rows(e.RowIndex).Cells("colQty").Value = 1
                                                     End If
                                                     refreshTotal()
                                                 End If
                                             End Sub

            Dim btnSave As New Button() With {.Text = "Save", .Location = New Point(680, 515), .Size = New Size(75, 30)}
            Dim btnCancel As New Button() With {.Text = "Cancel", .Location = New Point(765, 515), .Size = New Size(75, 30), .DialogResult = DialogResult.Cancel}

            AddHandler btnSave.Click, Sub()
                                          If dgvItems.Rows.Count = 0 Then
                                              MessageBox.Show("Order must have at least one product.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                              Return
                                          End If

                                          Dim newTotalAmount As Decimal = 0D
                                          Dim editedMap As New Dictionary(Of Integer, Integer)
                                          For Each r As DataGridViewRow In dgvItems.Rows
                                              If r.IsNewRow Then Continue For
                                              Dim pid = Convert.ToInt32(r.Cells("colProductID").Value)
                                              Dim qty = Convert.ToInt32(r.Cells("colQty").Value)
                                              Dim unitPrice = Convert.ToDecimal(r.Cells("colUnitPrice").Value)
                                              newTotalAmount += (unitPrice * qty)
                                              editedMap(pid) = qty
                                          Next

                                          Dim originalMap As New Dictionary(Of Integer, Integer)
                                          For Each line In currentLines
                                              originalMap(line.ProductID) = line.Quantity
                                          Next

                                          Dim changedCount As Integer = 0
                                          Dim allIds = originalMap.Keys.Union(editedMap.Keys)
                                          For Each pid In allIds
                                              Dim oldQty As Integer = If(originalMap.ContainsKey(pid), originalMap(pid), 0)
                                              Dim newQty As Integer = If(editedMap.ContainsKey(pid), editedMap(pid), 0)
                                              If oldQty <> newQty Then changedCount += 1
                                          Next

                                          Dim summary As String =
                                              "Please confirm order update:" & Environment.NewLine & Environment.NewLine &
                                              "Original Total: " & originalTotal.ToString("N2") & Environment.NewLine &
                                              "New Total: " & newTotalAmount.ToString("N2") & Environment.NewLine &
                                              "Products Changed: " & changedCount.ToString()

                                          If MessageBox.Show(summary, "Confirm Order Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                                              Return
                                          End If

                                          frm.DialogResult = DialogResult.OK
                                          frm.Close()
                                      End Sub
            frm.Controls.AddRange(New Control() {lblReceipt, txtReceipt, lblCustomer, txtCustomer, dgvItems, lblAddProduct, cmbProduct, lblQty, numQty, btnAddProduct, lblTotal, btnSave, btnCancel})
            frm.AcceptButton = btnSave
            frm.CancelButton = btnCancel

            If frm.ShowDialog(Me) <> DialogResult.OK Then Return False
            If dgvItems.Rows.Count = 0 Then
                MessageBox.Show("Order must have at least one product.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            editedLines = New List(Of OrderEditLine)
            For Each r As DataGridViewRow In dgvItems.Rows
                If r.IsNewRow Then Continue For
                editedLines.Add(New OrderEditLine With {
                    .ProductID = Convert.ToInt32(r.Cells("colProductID").Value),
                    .ProductName = r.Cells("colProductName").Value.ToString(),
                    .UnitPrice = Convert.ToDecimal(r.Cells("colUnitPrice").Value),
                    .Quantity = Convert.ToInt32(r.Cells("colQty").Value)
                })
            Next
            Return True
        End Using
    End Function

    Private Function V_GetEditableProducts() As DataTable
        Dim dt As New DataTable()
        OpenConnection()
        Using da As New MySqlDataAdapter("SELECT Product_ID, Product_Name, Unit_Price FROM PRODUCT ORDER BY Product_Name", conn)
            da.Fill(dt)
        End Using
        Return dt
    End Function

    Private Function V_GetOrderItemsForEdit(purchaseId As Integer) As List(Of OrderEditLine)
        Dim items As New List(Of OrderEditLine)
        OpenConnection()
        Dim q As String = "SELECT PI.Product_ID, P.Product_Name, PI.Item_Price, PI.Quantity " &
                          "FROM PURCHASE_ITEMS PI " &
                          "JOIN PRODUCT P ON PI.Product_ID = P.Product_ID " &
                          "WHERE PI.Purchase_ID = @id ORDER BY PI.Item_ID"
        Using cmd As New MySqlCommand(q, conn)
            cmd.Parameters.AddWithValue("@id", purchaseId)
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    items.Add(New OrderEditLine With {
                        .ProductID = Convert.ToInt32(reader("Product_ID")),
                        .ProductName = reader("Product_Name").ToString(),
                        .UnitPrice = Convert.ToDecimal(reader("Item_Price")),
                        .Quantity = Convert.ToInt32(reader("Quantity"))
                    })
                End While
            End Using
        End Using
        Return items
    End Function

    Private Sub V_SaveEditedOrderItems(purchaseId As Integer, editedLines As List(Of OrderEditLine), tx As MySqlTransaction)
        Dim oldLines As New List(Of OrderEditLine)
        Using cmdOld As New MySqlCommand("SELECT PI.Product_ID, P.Product_Name, PI.Item_Price, PI.Quantity FROM PURCHASE_ITEMS PI JOIN PRODUCT P ON PI.Product_ID = P.Product_ID WHERE PI.Purchase_ID = @id", conn, tx)
            cmdOld.Parameters.AddWithValue("@id", purchaseId)
            Using reader = cmdOld.ExecuteReader()
                While reader.Read()
                    oldLines.Add(New OrderEditLine With {
                        .ProductID = Convert.ToInt32(reader("Product_ID")),
                        .ProductName = reader("Product_Name").ToString(),
                        .UnitPrice = Convert.ToDecimal(reader("Item_Price")),
                        .Quantity = Convert.ToInt32(reader("Quantity"))
                    })
                End While
            End Using
        End Using

        For Each oldLine In oldLines
            Using cmdRestore As New MySqlCommand("UPDATE PRODUCT SET Stock_Quantity = Stock_Quantity + @qty WHERE Product_ID = @pid", conn, tx)
                cmdRestore.Parameters.AddWithValue("@qty", oldLine.Quantity)
                cmdRestore.Parameters.AddWithValue("@pid", oldLine.ProductID)
                cmdRestore.ExecuteNonQuery()
            End Using
        Next

        Using cmdDelClaim As New MySqlCommand("DELETE WC FROM WARRANTY_CLAIM WC JOIN WARRANTY W ON WC.Warranty_ID = W.Warranty_ID JOIN PURCHASE_ITEMS PI ON W.Item_ID = PI.Item_ID WHERE PI.Purchase_ID = @pid", conn, tx)
            cmdDelClaim.Parameters.AddWithValue("@pid", purchaseId)
            cmdDelClaim.ExecuteNonQuery()
        End Using
        Using cmdDelWarranty As New MySqlCommand("DELETE W FROM WARRANTY W JOIN PURCHASE_ITEMS PI ON W.Item_ID = PI.Item_ID WHERE PI.Purchase_ID = @pid", conn, tx)
            cmdDelWarranty.Parameters.AddWithValue("@pid", purchaseId)
            cmdDelWarranty.ExecuteNonQuery()
        End Using
        Using cmdDelItems As New MySqlCommand("DELETE FROM PURCHASE_ITEMS WHERE Purchase_ID = @pid", conn, tx)
            cmdDelItems.Parameters.AddWithValue("@pid", purchaseId)
            cmdDelItems.ExecuteNonQuery()
        End Using

        For Each line In editedLines
            Using cmdCheck As New MySqlCommand("SELECT Stock_Quantity FROM PRODUCT WHERE Product_ID = @pid FOR UPDATE", conn, tx)
                cmdCheck.Parameters.AddWithValue("@pid", line.ProductID)
                Dim stockObj = cmdCheck.ExecuteScalar()
                If stockObj Is Nothing OrElse stockObj Is DBNull.Value Then Throw New Exception("Product not found during order edit.")
                Dim stock = Convert.ToInt32(stockObj)
                If stock < line.Quantity Then
                    Throw New Exception("Insufficient stock for '" & line.ProductName & "'. Available: " & stock.ToString() & ", Required: " & line.Quantity.ToString())
                End If
            End Using

            Dim itemId As Integer
            Using cmdIns As New MySqlCommand("INSERT INTO PURCHASE_ITEMS (Purchase_ID, Product_ID, Quantity, Item_Price) VALUES (@pid, @prod, @qty, @price)", conn, tx)
                cmdIns.Parameters.AddWithValue("@pid", purchaseId)
                cmdIns.Parameters.AddWithValue("@prod", line.ProductID)
                cmdIns.Parameters.AddWithValue("@qty", line.Quantity)
                cmdIns.Parameters.AddWithValue("@price", line.UnitPrice)
                cmdIns.ExecuteNonQuery()
                itemId = Convert.ToInt32(cmdIns.LastInsertedId)
            End Using

            Using cmdStock As New MySqlCommand("UPDATE PRODUCT SET Stock_Quantity = Stock_Quantity - @qty WHERE Product_ID = @pid", conn, tx)
                cmdStock.Parameters.AddWithValue("@qty", line.Quantity)
                cmdStock.Parameters.AddWithValue("@pid", line.ProductID)
                cmdStock.ExecuteNonQuery()
            End Using

            Using cmdWarranty As New MySqlCommand("INSERT INTO WARRANTY (Item_ID, Warranty_Start_Date, Warranty_End_Date, Warranty_Status) VALUES (@itemId, CURDATE(), DATE_ADD(CURDATE(), INTERVAL 1 YEAR), 'Active')", conn, tx)
                cmdWarranty.Parameters.AddWithValue("@itemId", itemId)
                cmdWarranty.ExecuteNonQuery()
            End Using
        Next
    End Sub

    Private Sub V_DeleteOrder(purchaseId As Integer)
        If MessageBox.Show("Delete this order? This removes related purchase items.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return
        Try
            OpenConnection()
            Using tx = conn.BeginTransaction()
                Try
                    Using cmdItems As New MySqlCommand("DELETE FROM PURCHASE_ITEMS WHERE Purchase_ID = @id", conn, tx)
                        cmdItems.Parameters.AddWithValue("@id", purchaseId)
                        cmdItems.ExecuteNonQuery()
                    End Using
                    Using cmdPurch As New MySqlCommand("DELETE FROM PURCHASE WHERE Purchase_ID = @id", conn, tx)
                        cmdPurch.Parameters.AddWithValue("@id", purchaseId)
                        cmdPurch.ExecuteNonQuery()
                    End Using
                    tx.Commit()
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
            MessageBox.Show("Order deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            V_LoadOrders()
            L_LoadAlerts("")
            LoadDashboardStats()
        Catch ex As Exception
            MessageBox.Show("Unable to delete order. It may be tied to warranty records." & Environment.NewLine & ex.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private _currentPrintPurchaseId As Integer = 0

    Private Sub PrintReceipt(purchaseId As Integer)
        _currentPrintPurchaseId = purchaseId
        Dim pd As New System.Drawing.Printing.PrintDocument()
        AddHandler pd.PrintPage, AddressOf pd_PrintPage
        
        Dim ppd As New PrintPreviewDialog()
        ppd.Document = pd
        ppd.Width = 400
        ppd.Height = 600
        ppd.ShowDialog()
    End Sub

    Private Sub pd_PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs)
        Try
            OpenConnection()
            Dim receiptNo As String = ""
            Dim pDate As DateTime = DateTime.Now
            Dim custName As String = ""
            Dim staffName As String = ""
            
            Using cmdPurch As New MySqlCommand("SELECT p.Receipt_Number, p.Purchase_Date, c.Full_Name, IFNULL(s.Full_Name, 'None') FROM PURCHASE p JOIN CUSTOMER c ON p.Customer_ID = c.Customer_ID LEFT JOIN STAFF s ON p.Staff_ID = s.Staff_ID WHERE p.Purchase_ID = @pid", conn)
                cmdPurch.Parameters.AddWithValue("@pid", _currentPrintPurchaseId)
                Using reader = cmdPurch.ExecuteReader()
                    If reader.Read() Then
                        receiptNo = reader.GetString(0)
                        pDate = reader.GetDateTime(1)
                        custName = reader.GetString(2)
                        staffName = reader.GetString(3)
                    End If
                End Using
            End Using

            Dim items As New List(Of String)
            Dim totalAmount As Decimal = 0
            Using cmdItems As New MySqlCommand("SELECT pr.Product_Name, pi.Quantity, pi.Item_Price FROM PURCHASE_ITEMS pi JOIN PRODUCT pr ON pi.Product_ID = pr.Product_ID WHERE pi.Purchase_ID = @pid", conn)
                cmdItems.Parameters.AddWithValue("@pid", _currentPrintPurchaseId)
                Using reader = cmdItems.ExecuteReader()
                    While reader.Read()
                        Dim name = reader.GetString(0)
                        Dim qty = reader.GetInt32(1)
                        Dim price = reader.GetDecimal(2)
                        items.Add(qty.ToString() & "x " & name & " - ₱" & (qty * price).ToString("N2"))
                        totalAmount += (qty * price)
                    End While
                End Using
            End Using

            Dim g As Graphics = e.Graphics
            Dim fBold As New Font("Courier New", 12, FontStyle.Bold)
            Dim fRegular As New Font("Courier New", 10, FontStyle.Regular)
            Dim brush As New SolidBrush(Color.Black)
            Dim startX As Integer = 10
            Dim startY As Integer = 10
            Dim offset As Integer = 0

            g.DrawString("MIDEA PRO SHOP", fBold, brush, startX + 50, startY + offset)
            offset += 30
            g.DrawString("Official Receipt", fRegular, brush, startX + 50, startY + offset)
            offset += 30
            g.DrawString("--------------------------------", fRegular, brush, startX, startY + offset)
            offset += 20
            g.DrawString("Receipt No: " & receiptNo, fRegular, brush, startX, startY + offset)
            offset += 20
            g.DrawString("Date: " & pDate.ToString("yyyy-MM-dd HH:mm"), fRegular, brush, startX, startY + offset)
            offset += 20
            g.DrawString("Customer: " & custName, fRegular, brush, startX, startY + offset)
            offset += 20
            g.DrawString("Staff: " & staffName, fRegular, brush, startX, startY + offset)
            offset += 20
            g.DrawString("--------------------------------", fRegular, brush, startX, startY + offset)
            offset += 20
            
            For Each itm In items
                g.DrawString(itm, fRegular, brush, startX, startY + offset)
                offset += 20
            Next
            
            g.DrawString("--------------------------------", fRegular, brush, startX, startY + offset)
            offset += 20
            g.DrawString("TOTAL: ₱" & totalAmount.ToString("N2"), fBold, brush, startX, startY + offset)
            offset += 40
            g.DrawString("Thank you for your purchase!", fRegular, brush, startX + 20, startY + offset)

        Catch ex As Exception
            e.Graphics.DrawString("Error loading receipt details.", New Font("Arial", 12), Brushes.Red, 10, 10)
        End Try
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

        Dim brandValue As String = ""
        If a_chkNewBrand.Checked Then
            If String.IsNullOrWhiteSpace(a_txtNewBrand.Text) Then
                MessageBox.Show("Please enter the new brand name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            brandValue = a_txtNewBrand.Text.Trim()
            If Not a_cmbBrand.Items.Contains(brandValue) Then
                a_cmbBrand.Items.Add(brandValue)
            End If
        Else
            brandValue = If(a_cmbBrand.SelectedItem IsNot Nothing, a_cmbBrand.SelectedItem.ToString(), "")
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
                        cmdProd.Parameters.AddWithValue("@brand", brandValue)
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
                    a_cmbBrand.SelectedIndex = -1
                    a_chkNewBrand.Checked = False
                    a_txtNewBrand.Clear()
                    a_txtNewBrand.Visible = False
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
        a_cmbBrand.SelectedIndex = -1
        a_chkNewBrand.Checked = False
        a_txtNewBrand.Clear()
        a_txtNewBrand.Visible = False
        a_txtProdDesc.Clear()
        a_numPrice.Value = 0
        a_numStock.Value = 0
        a_numReorder.Value = 0
    End Sub

    Private Sub a_chkNewBrand_CheckedChanged(sender As Object, e As EventArgs) Handles a_chkNewBrand.CheckedChanged
        a_cmbBrand.Visible = Not a_chkNewBrand.Checked
        a_txtNewBrand.Visible = a_chkNewBrand.Checked
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
        btnAll.BackColor = Color.FromArgb(0, 120, 215)
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

        M_LoadProducts("")
    End Sub

    Private Sub M_CategoryFilter_Click(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        For Each ctrl As Control In m_pnlCategories.Controls
            If TypeOf ctrl Is Button Then
                ctrl.BackColor = Color.White
                ctrl.ForeColor = Color.Black
            End If
        Next
        btn.BackColor = Color.FromArgb(0, 120, 215)
        btn.ForeColor = Color.White
        M_LoadProducts(btn.Tag.ToString())
    End Sub

    Private Sub M_LoadProducts(category As String)
        m_dgvProducts.Rows.Clear()
        Try
            OpenConnection()
            Dim query As String = "SELECT Product_ID, Product_Name, Brand, Product_Description, Unit_Price, Stock_Quantity, Reorder_Level FROM PRODUCT"
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
                        Dim pdesc = If(reader.IsDBNull(reader.GetOrdinal("Product_Description")), "", reader("Product_Description").ToString())
                        Dim price = reader.GetDecimal("Unit_Price")
                        Dim stock = reader.GetInt32("Stock_Quantity")
                        Dim reorder = reader.GetInt32("Reorder_Level")

                        m_dgvProducts.Rows.Add(id, name, brand, pdesc, price, stock, reorder)
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
            M_EditProductWithSupplier(prodId)
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

    Private Sub M_EditProductWithSupplier(prodId As Integer)
        Dim pName As String = ""
        Dim pBrand As String = ""
        Dim pDesc As String = ""
        Dim pCategory As String = ""
        Dim pPrice As Decimal = 0D
        Dim pStock As Integer = 0
        Dim pReorder As Integer = 0
        Dim supplierId As Integer = 0

        Try
            OpenConnection()
            Using cmd As New MySqlCommand("SELECT Product_Name, Brand, Product_Description, Product_Category, Unit_Price, Stock_Quantity, Reorder_Level, Supplier_ID FROM PRODUCT WHERE Product_ID = @id", conn)
                cmd.Parameters.AddWithValue("@id", prodId)
                Using reader = cmd.ExecuteReader()
                    If Not reader.Read() Then Return
                    pName = reader("Product_Name").ToString()
                    pBrand = If(reader("Brand") Is DBNull.Value, "", reader("Brand").ToString())
                    pDesc = If(reader("Product_Description") Is DBNull.Value, "", reader("Product_Description").ToString())
                    pCategory = reader("Product_Category").ToString()
                    pPrice = Convert.ToDecimal(reader("Unit_Price"))
                    pStock = Convert.ToInt32(reader("Stock_Quantity"))
                    pReorder = Convert.ToInt32(reader("Reorder_Level"))
                    supplierId = Convert.ToInt32(reader("Supplier_ID"))
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load product details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        If Not M_ShowProductEditForm(pName, pBrand, pDesc, pCategory, pPrice, pStock, pReorder, supplierId) Then Return

        Try
            OpenConnection()
            Dim q As String = "UPDATE PRODUCT SET Product_Name = @name, Brand = @brand, Product_Description = @desc, Product_Category = @cat, Unit_Price = @price, Stock_Quantity = @stock, Reorder_Level = @reorder, Supplier_ID = @supid WHERE Product_ID = @id"
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@name", pName)
                cmd.Parameters.AddWithValue("@brand", pBrand)
                cmd.Parameters.AddWithValue("@desc", pDesc)
                cmd.Parameters.AddWithValue("@cat", pCategory)
                cmd.Parameters.AddWithValue("@price", pPrice)
                cmd.Parameters.AddWithValue("@stock", pStock)
                cmd.Parameters.AddWithValue("@reorder", pReorder)
                cmd.Parameters.AddWithValue("@supid", supplierId)
                cmd.Parameters.AddWithValue("@id", prodId)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            M_RefreshCurrentCategory()
            O_CategoryFilter_Click(o_pnlCategories.Controls(0), EventArgs.Empty)
            L_LoadAlerts("")
        Catch ex As Exception
            MessageBox.Show("Update failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function M_ShowProductEditForm(ByRef pName As String,
                                           ByRef pBrand As String,
                                           ByRef pDesc As String,
                                           ByRef pCategory As String,
                                           ByRef pPrice As Decimal,
                                           ByRef pStock As Integer,
                                           ByRef pReorder As Integer,
                                           ByRef supplierId As Integer) As Boolean
        Dim categories() As String = {"Air Conditioners", "Washing Machines", "Televisions", "Refrigerators"}
        Dim dtSup As New DataTable()

        Try
            OpenConnection()
            Using da As New MySqlDataAdapter("SELECT Supplier_ID, Supplier_Name FROM SUPPLIER ORDER BY Supplier_Name", conn)
                da.Fill(dtSup)
            End Using
        Catch ex As Exception
            MessageBox.Show("Unable to load suppliers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

        Using frm As New Form()
            frm.Text = "Update Product"
            frm.StartPosition = FormStartPosition.CenterParent
            frm.FormBorderStyle = FormBorderStyle.FixedDialog
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ClientSize = New Size(560, 520)

            Dim y = 18
            Dim lblName As New Label() With {.Text = "Product Name", .Location = New Point(20, y), .AutoSize = True}
            Dim txtName As New TextBox() With {.Location = New Point(20, y + 20), .Size = New Size(240, 24), .Text = pName}
            Dim lblBrand As New Label() With {.Text = "Brand", .Location = New Point(280, y), .AutoSize = True}
            Dim txtBrand As New TextBox() With {.Location = New Point(280, y + 20), .Size = New Size(240, 24), .Text = pBrand}

            y += 58
            Dim lblCat As New Label() With {.Text = "Category", .Location = New Point(20, y), .AutoSize = True}
            Dim cmbCat As New ComboBox() With {.Location = New Point(20, y + 20), .Size = New Size(240, 24), .DropDownStyle = ComboBoxStyle.DropDownList}
            cmbCat.Items.AddRange(categories)
            cmbCat.SelectedItem = pCategory
            Dim lblPrice As New Label() With {.Text = "Unit Price", .Location = New Point(280, y), .AutoSize = True}
            Dim numPrice As New NumericUpDown() With {.Location = New Point(280, y + 20), .Size = New Size(120, 24), .DecimalPlaces = 2, .Maximum = 1000000D, .Value = Math.Max(0D, pPrice)}

            y += 58
            Dim lblStock As New Label() With {.Text = "Stock Quantity", .Location = New Point(20, y), .AutoSize = True}
            Dim numStock As New NumericUpDown() With {.Location = New Point(20, y + 20), .Size = New Size(120, 24), .Maximum = 1000000D, .Value = Math.Max(0, pStock)}
            Dim lblReorder As New Label() With {.Text = "Reorder Level", .Location = New Point(160, y), .AutoSize = True}
            Dim numReorder As New NumericUpDown() With {.Location = New Point(160, y + 20), .Size = New Size(120, 24), .Maximum = 1000000D, .Value = Math.Max(0, pReorder)}

            y += 58
            Dim lblDesc As New Label() With {.Text = "Description", .Location = New Point(20, y), .AutoSize = True}
            Dim txtDesc As New TextBox() With {.Location = New Point(20, y + 20), .Size = New Size(500, 80), .Multiline = True, .ScrollBars = ScrollBars.Vertical, .Text = pDesc}

            y += 114
            Dim lblSupplierMode As New Label() With {.Text = "Supplier", .Location = New Point(20, y), .AutoSize = True}
            Dim optExisting As New RadioButton() With {.Text = "Existing Supplier", .Location = New Point(20, y + 22), .AutoSize = True, .Checked = True}
            Dim cmbSup As New ComboBox() With {.Location = New Point(20, y + 44), .Size = New Size(240, 24), .DropDownStyle = ComboBoxStyle.DropDownList}
            cmbSup.DataSource = dtSup
            cmbSup.DisplayMember = "Supplier_Name"
            cmbSup.ValueMember = "Supplier_ID"
            cmbSup.SelectedValue = supplierId

            Dim optNew As New RadioButton() With {.Text = "New Supplier", .Location = New Point(280, y + 22), .AutoSize = True}
            Dim newSupBaseY As Integer = y + 22

            ' Place the whole New Supplier block below the radio button so labels are not overlapped.
            Dim lblSupName As New Label() With {.Text = "Supplier Name", .Location = New Point(280, newSupBaseY + 24), .AutoSize = True}
            Dim txtSupName As New TextBox() With {.Location = New Point(280, newSupBaseY + 40), .Size = New Size(240, 24)}
            ' Spacing fix: make sure labels do not overlap the previous textboxes.
            ' (The form uses fixed pixel offsets, so small misalignment becomes visible at runtime.)
            Dim lblSupContact As New Label() With {.Text = "Contact Number", .Location = New Point(280, newSupBaseY + 64), .AutoSize = True}
            Dim txtSupContact As New TextBox() With {.Location = New Point(280, newSupBaseY + 80), .Size = New Size(240, 24)}
            Dim lblSupAddress As New Label() With {.Text = "Warehouse Address", .Location = New Point(280, newSupBaseY + 104), .AutoSize = True}
            Dim txtSupAddress As New TextBox() With {.Location = New Point(280, newSupBaseY + 120), .Size = New Size(240, 24)}

            Dim toggleSupplierMode = Sub()
                                         cmbSup.Enabled = optExisting.Checked
                                         ' Use Visible instead of only Enabled so labels render clearly.
                                         lblSupName.Visible = optNew.Checked
                                         txtSupName.Visible = optNew.Checked
                                         lblSupContact.Visible = optNew.Checked
                                         txtSupContact.Visible = optNew.Checked
                                         lblSupAddress.Visible = optNew.Checked
                                         txtSupAddress.Visible = optNew.Checked
                                     End Sub
            AddHandler optExisting.CheckedChanged, Sub() toggleSupplierMode()
            AddHandler optNew.CheckedChanged, Sub() toggleSupplierMode()
            toggleSupplierMode()

            Dim btnSave As New Button() With {.Text = "Save", .Location = New Point(345, 476), .Size = New Size(80, 30), .DialogResult = DialogResult.OK}
            Dim btnCancel As New Button() With {.Text = "Cancel", .Location = New Point(435, 476), .Size = New Size(80, 30), .DialogResult = DialogResult.Cancel}

            frm.Controls.AddRange(New Control() {lblName, txtName, lblBrand, txtBrand, lblCat, cmbCat, lblPrice, numPrice, lblStock, numStock, lblReorder, numReorder, lblDesc, txtDesc, lblSupplierMode, optExisting, cmbSup, optNew, lblSupName, txtSupName, lblSupContact, txtSupContact, lblSupAddress, txtSupAddress, btnSave, btnCancel})
            frm.AcceptButton = btnSave
            frm.CancelButton = btnCancel

            If frm.ShowDialog(Me) <> DialogResult.OK Then Return False

            If String.IsNullOrWhiteSpace(txtName.Text) OrElse cmbCat.SelectedItem Is Nothing Then
                MessageBox.Show("Product name and category are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            Dim finalSupplierId As Integer
            If optNew.Checked Then
                If String.IsNullOrWhiteSpace(txtSupName.Text) Then
                    MessageBox.Show("Supplier name is required for a new supplier.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
                Try
                    OpenConnection()
                    Dim addrCol = SUP_GetAddressColumnName()
                    Using cmd As New MySqlCommand($"INSERT INTO SUPPLIER (Supplier_Name, Contact_Number, {addrCol}) VALUES (@n, @c, @a)", conn)
                        cmd.Parameters.AddWithValue("@n", txtSupName.Text.Trim())
                        cmd.Parameters.AddWithValue("@c", txtSupContact.Text.Trim())
                        cmd.Parameters.AddWithValue("@a", txtSupAddress.Text.Trim())
                        cmd.ExecuteNonQuery()
                        finalSupplierId = Convert.ToInt32(cmd.LastInsertedId)
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Failed to create supplier: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            Else
                If cmbSup.SelectedValue Is Nothing Then
                    MessageBox.Show("Please select an existing supplier.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
                finalSupplierId = Convert.ToInt32(cmbSup.SelectedValue)
            End If

            pName = txtName.Text.Trim()
            pBrand = txtBrand.Text.Trim()
            pDesc = txtDesc.Text.Trim()
            pCategory = cmbCat.SelectedItem.ToString()
            pPrice = numPrice.Value
            pStock = Convert.ToInt32(numStock.Value)
            pReorder = Convert.ToInt32(numReorder.Value)
            supplierId = finalSupplierId
            Return True
        End Using
    End Function

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
        L_EnsureRefreshButton()
        l_pnlCategories.Controls.Clear()
        Dim btnAll As New Button()
        btnAll.Text = "All Categories"
        btnAll.Tag = ""
        btnAll.Size = New Size(150, 40)
        btnAll.FlatStyle = FlatStyle.Flat
        btnAll.BackColor = Color.FromArgb(0, 120, 215)
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

    Private Sub L_EnsureRefreshButton()
        If l_btnRefresh IsNot Nothing Then Return

        l_btnRefresh = New Button() With {
            .Text = "Refresh",
            .BackColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .ForeColor = Color.Black,
            .Location = New Point(1248, 14),
            .Size = New Size(90, 32)
        }
        AddHandler l_btnRefresh.Click, AddressOf L_btnRefresh_Click
        l_pnlHeader.Controls.Add(l_btnRefresh)
        l_btnRefresh.BringToFront()
    End Sub

    Private Sub L_btnRefresh_Click(sender As Object, e As EventArgs)
        L_LoadAlerts(L_GetActiveLowStockCategory())
    End Sub

    Private Sub L_CategoryFilter_Click(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        For Each ctrl As Control In l_pnlCategories.Controls
            If TypeOf ctrl Is Button Then
                ctrl.BackColor = Color.White
                ctrl.ForeColor = Color.Black
            End If
        Next
        btn.BackColor = Color.FromArgb(0, 120, 215)
        btn.ForeColor = Color.White
        L_LoadAlerts(btn.Tag.ToString())
    End Sub

    Private Sub L_LoadAlerts(category As String)
        l_dgvAlerts.Rows.Clear()
        Try
            OpenConnection()
            Dim query As String = "SELECT p.Product_ID, p.Product_Name, p.Brand, p.Stock_Quantity, IFNULL(p.Reorder_Level, 0) AS Reorder_Level, s.Supplier_Name " &
                                  "FROM PRODUCT p " &
                                  "LEFT JOIN SUPPLIER s ON p.Supplier_ID = s.Supplier_ID " &
                                  "WHERE IFNULL(p.Stock_Quantity, 0) <= IFNULL(p.Reorder_Level, 0)"
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
            Dim prodName = row.Cells("l_colProductName").Value.ToString()
            Dim currentStock = Convert.ToInt32(row.Cells("l_colStock").Value)
            Dim reorderLevel = Convert.ToInt32(row.Cells("l_colReorder").Value)
            L_ShowAddStockDialog(prodId, prodName, currentStock, reorderLevel)
        End If
    End Sub

    Private Sub L_ShowAddStockDialog(prodId As Integer, prodName As String, currentStock As Integer, reorderLevel As Integer)
        Using frm As New Form()
            frm.Text = "Add Stock"
            frm.StartPosition = FormStartPosition.CenterParent
            frm.FormBorderStyle = FormBorderStyle.FixedDialog
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ClientSize = New Size(420, 230)

            Dim lblProduct As New Label() With {.Text = "Product", .Location = New Point(20, 20), .AutoSize = True}
            Dim txtProduct As New TextBox() With {.Location = New Point(20, 42), .Size = New Size(380, 24), .ReadOnly = True, .Text = prodName}
            Dim lblStockInfo As New Label() With {.Text = "Current Stock: " & currentStock.ToString() & "   Reorder Level: " & reorderLevel.ToString(), .Location = New Point(20, 75), .AutoSize = True}
            Dim lblQty As New Label() With {.Text = "Add Quantity", .Location = New Point(20, 105), .AutoSize = True}
            Dim numQty As New NumericUpDown() With {.Location = New Point(20, 128), .Size = New Size(150, 24), .Minimum = 1, .Maximum = 999999, .Value = 1}
            Dim txtRemarks As New TextBox() With {.Location = New Point(20, 162), .Size = New Size(380, 24), .Text = "Low stock replenishment"}
            Dim btnSave As New Button() With {.Text = "Save", .Location = New Point(244, 192), .Size = New Size(75, 28), .DialogResult = DialogResult.OK}
            Dim btnCancel As New Button() With {.Text = "Cancel", .Location = New Point(325, 192), .Size = New Size(75, 28), .DialogResult = DialogResult.Cancel}

            frm.Controls.AddRange(New Control() {lblProduct, txtProduct, lblStockInfo, lblQty, numQty, txtRemarks, btnSave, btnCancel})
            frm.AcceptButton = btnSave
            frm.CancelButton = btnCancel

            If frm.ShowDialog(Me) <> DialogResult.OK Then Return

            Dim qty As Integer = Convert.ToInt32(numQty.Value)
            If qty <= 0 Then Return

            Try
                OpenConnection()
                Using tx = conn.BeginTransaction()
                    Try
                        Using cmdStock As New MySqlCommand("UPDATE PRODUCT SET Stock_Quantity = Stock_Quantity + @qty WHERE Product_ID = @id", conn, tx)
                            cmdStock.Parameters.AddWithValue("@qty", qty)
                            cmdStock.Parameters.AddWithValue("@id", prodId)
                            If cmdStock.ExecuteNonQuery() <> 1 Then
                                Throw New Exception("Failed to update product stock.")
                            End If
                        End Using

                        Using cmdLog As New MySqlCommand("INSERT INTO STOCK_TRANSACTION (Product_ID, Transaction_Type, Quantity, Transaction_Date, Remarks) VALUES (@prodid, 'Restock', @qty, @tdate, @remarks)", conn, tx)
                            cmdLog.Parameters.AddWithValue("@prodid", prodId)
                            cmdLog.Parameters.AddWithValue("@qty", qty)
                            cmdLog.Parameters.AddWithValue("@tdate", DateTime.Now)
                            cmdLog.Parameters.AddWithValue("@remarks", If(String.IsNullOrWhiteSpace(txtRemarks.Text), "Low stock replenishment", txtRemarks.Text.Trim()))
                            cmdLog.ExecuteNonQuery()
                        End Using

                        tx.Commit()
                    Catch
                        tx.Rollback()
                        Throw
                    End Try
                End Using

                MessageBox.Show("Stock updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                S_LoadHistory()
                M_LoadProducts("")
                O_CategoryFilter_Click(o_pnlCategories.Controls(0), EventArgs.Empty)
                L_LoadAlerts(L_GetActiveLowStockCategory())
                LoadDashboardStats()
            Catch ex As Exception
                MessageBox.Show("Failed to add stock: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Function L_GetActiveLowStockCategory() As String
        For Each ctrl As Control In l_pnlCategories.Controls
            If TypeOf ctrl Is Button Then
                Dim btn = DirectCast(ctrl, Button)
                If btn.BackColor = Color.FromArgb(0, 120, 215) Then
                    Return btn.Tag.ToString()
                End If
            End If
        Next
        Return ""
    End Function

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
            Dim q As String = "SELECT st.Transaction_ID, p.Product_Name, st.Transaction_Type, st.Quantity, st.Transaction_Date, st.Remarks FROM STOCK_TRANSACTION st JOIN PRODUCT p ON st.Product_ID = p.Product_ID WHERE 1=1 "

            Dim startDate As DateTime = DateTime.MinValue
            Dim endDate As DateTime = DateTime.MaxValue
            S_GetTransactionDateRange(startDate, endDate)

            If startDate <> DateTime.MinValue AndAlso endDate <> DateTime.MaxValue Then
                q &= "AND st.Transaction_Date >= @start AND st.Transaction_Date <= @end "
            End If

            If s_txtSearch IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(s_txtSearch.Text) Then
                q &= "AND (p.Product_Name LIKE @search OR st.Remarks LIKE @search) "
            End If

            q &= "ORDER BY st.Transaction_Date DESC"

            Using cmd As New MySqlCommand(q, conn)
                If startDate <> DateTime.MinValue AndAlso endDate <> DateTime.MaxValue Then
                    cmd.Parameters.AddWithValue("@start", startDate.Date)
                    cmd.Parameters.AddWithValue("@end", endDate.Date.AddDays(1).AddTicks(-1))
                End If
                If s_txtSearch IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(s_txtSearch.Text) Then
                    cmd.Parameters.AddWithValue("@search", "%" & s_txtSearch.Text.Trim() & "%")
                End If
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        s_dgvHistory.Rows.Add(reader("Transaction_ID"), reader("Product_Name"), reader("Transaction_Type"), reader("Quantity"), Convert.ToDateTime(reader("Transaction_Date")).ToString("g"), reader("Remarks").ToString())
                    End While
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub s_txtSearch_TextChanged(sender As Object, e As EventArgs) Handles s_txtSearch.TextChanged
        S_LoadHistory()
        If s_txtSearch.Text.Trim() <> "" AndAlso s_dgvHistory.Rows.Count > 0 Then
            S_PopulateEditPanel(0)
        Else
            s_pnlEditForm.Visible = False
        End If
    End Sub

    Private Sub s_cmbQuickFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles s_cmbQuickFilter.SelectedIndexChanged
        S_LoadHistory()
    End Sub

    Private Sub S_GetTransactionDateRange(ByRef startDate As DateTime, ByRef endDate As DateTime)
        startDate = DateTime.MinValue
        endDate = DateTime.MaxValue
        If s_cmbQuickFilter Is Nothing OrElse s_cmbQuickFilter.SelectedItem Is Nothing Then Return

        Dim nowDate = DateTime.Now.Date
        Select Case s_cmbQuickFilter.SelectedItem.ToString()
            Case "Today"
                startDate = nowDate
                endDate = nowDate
            Case "This Week"
                Dim mondayOffset As Integer = (CInt(nowDate.DayOfWeek) + 6) Mod 7
                Dim weekStart = nowDate.AddDays(-mondayOffset)
                startDate = weekStart
                endDate = weekStart.AddDays(6)
            Case "This Month"
                startDate = New DateTime(nowDate.Year, nowDate.Month, 1)
                endDate = startDate.AddMonths(1).AddDays(-1)
            Case "Last 30 Days"
                startDate = nowDate.AddDays(-29)
                endDate = nowDate
            Case "This Year"
                startDate = New DateTime(nowDate.Year, 1, 1)
                endDate = New DateTime(nowDate.Year, 12, 31)
            Case Else ' All
        End Select
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
                    LoadDashboardStats()
                Catch ex As Exception
                    transaction.Rollback()
                    Throw ex
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Transaction failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub s_dgvHistory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles s_dgvHistory.CellContentClick
        If e.RowIndex < 0 Then Return

        Dim colName As String = s_dgvHistory.Columns(e.ColumnIndex).Name
        Dim transId As Integer = Convert.ToInt32(s_dgvHistory.Rows(e.RowIndex).Cells("s_colTransID").Value)

        If colName = "s_colActionDelete" Then
            If MessageBox.Show("Are you sure you want to delete this transaction? This will automatically reverse the stock change for the product.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Try
                    OpenConnection()
                    Dim prodId As Integer = 0
                    Dim qty As Integer = 0
                    Using cmdGet As New MySqlCommand("SELECT Product_ID, Quantity FROM STOCK_TRANSACTION WHERE Transaction_ID = @id", conn)
                        cmdGet.Parameters.AddWithValue("@id", transId)
                        Using reader = cmdGet.ExecuteReader()
                            If reader.Read() Then
                                prodId = Convert.ToInt32(reader("Product_ID"))
                                qty = Convert.ToInt32(reader("Quantity"))
                            End If
                        End Using
                    End Using

                    If prodId > 0 Then
                        Using transaction = conn.BeginTransaction()
                            Try
                                ' Reverse stock change. Quantity in STOCK_TRANSACTION stores signed value (+/-)
                                Dim qUpdate As String = "UPDATE PRODUCT SET Stock_Quantity = Stock_Quantity - @qty WHERE Product_ID = @id"
                                Using cmdStock As New MySqlCommand(qUpdate, conn, transaction)
                                    cmdStock.Parameters.AddWithValue("@qty", qty)
                                    cmdStock.Parameters.AddWithValue("@id", prodId)
                                    cmdStock.ExecuteNonQuery()
                                End Using

                                Using cmdDel As New MySqlCommand("DELETE FROM STOCK_TRANSACTION WHERE Transaction_ID = @id", conn, transaction)
                                    cmdDel.Parameters.AddWithValue("@id", transId)
                                    cmdDel.ExecuteNonQuery()
                                End Using

                                transaction.Commit()
                                MessageBox.Show("Transaction deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                S_LoadHistory()
                                M_LoadProducts("")
                                L_LoadAlerts("")
                            Catch ex As Exception
                                transaction.Rollback()
                                Throw ex
                            End Try
                        End Using
                    End If
                Catch ex As Exception
                    MessageBox.Show("Delete failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

        ElseIf colName = "s_colActionEdit" Then
            S_PopulateEditPanel(e.RowIndex)
        End If
    End Sub

    Private _editStockTransId As Integer = 0
    Private _editStockProdId As Integer = 0
    Private _editOriginalSignedQty As Integer = 0
    Private _editOriginalType As String = ""

    Private Sub S_PopulateEditPanel(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= s_dgvHistory.Rows.Count Then
            s_pnlEditForm.Visible = False
            Return
        End If

        Dim transId As Integer = Convert.ToInt32(s_dgvHistory.Rows(rowIndex).Cells("s_colTransID").Value)
        _editStockTransId = transId

        Dim tDate As String = s_dgvHistory.Rows(rowIndex).Cells("s_colDate").Value.ToString()
        s_lblEditDate.Text = $"Date: {tDate}"

        Try
            OpenConnection()
            
            s_cmbEditProduct.Items.Clear()
            Using cmdProd As New MySqlCommand("SELECT Product_ID, Product_Name FROM PRODUCT ORDER BY Product_Name", conn)
                Using reader = cmdProd.ExecuteReader()
                    While reader.Read()
                        s_cmbEditProduct.Items.Add(New With {.Text = reader("Product_Name").ToString(), .Value = reader("Product_ID")})
                    End While
                End Using
            End Using
            s_cmbEditProduct.DisplayMember = "Text"
            s_cmbEditProduct.ValueMember = "Value"
            Using cmdGet As New MySqlCommand("SELECT Product_ID, Transaction_Type, Quantity, Remarks FROM STOCK_TRANSACTION WHERE Transaction_ID = @id", conn)
                cmdGet.Parameters.AddWithValue("@id", transId)
                Using reader = cmdGet.ExecuteReader()
                    If reader.Read() Then
                        _editStockProdId = Convert.ToInt32(reader("Product_ID"))
                        _editOriginalType = reader("Transaction_Type").ToString()
                        _editOriginalSignedQty = Convert.ToInt32(reader("Quantity"))

                        For i As Integer = 0 To s_cmbEditProduct.Items.Count - 1
                            If DirectCast(s_cmbEditProduct.Items(i), Object).Value.ToString() = _editStockProdId.ToString() Then
                                s_cmbEditProduct.SelectedIndex = i
                                Exit For
                            End If
                        Next

                        If s_cmbEditType.Items.Contains(_editOriginalType) Then
                            s_cmbEditType.SelectedItem = _editOriginalType
                        End If
                        s_numEditQuantity.Value = Math.Abs(_editOriginalSignedQty)
                        s_txtEditRemarks.Text = reader("Remarks").ToString()
                    End If
                End Using
            End Using
            s_pnlEditForm.Visible = True
        Catch ex As Exception
            MessageBox.Show("Error loading transaction details: " & ex.Message)
        End Try
    End Sub

    Private Sub s_btnEditClose_Click(sender As Object, e As EventArgs) Handles s_btnEditClose.Click
        s_pnlEditForm.Visible = False
    End Sub

    Private Sub s_btnEditSave_Click(sender As Object, e As EventArgs) Handles s_btnEditSave.Click
        If _editStockTransId = 0 OrElse _editStockProdId = 0 Then Return

        Dim newQty As Integer = Convert.ToInt32(s_numEditQuantity.Value)
        If newQty <= 0 Then
            MessageBox.Show("Quantity must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim newProdId As Integer = Convert.ToInt32(DirectCast(s_cmbEditProduct.SelectedItem, Object).Value)
        Dim newType As String = If(s_cmbEditType.SelectedItem IsNot Nothing, s_cmbEditType.SelectedItem.ToString(), _editOriginalType)
        Dim isNewAddition As Boolean = (newType = "Restock" Or newType = "Correction")
        
        If newType = "Correction" AndAlso _editOriginalType <> "Correction" Then
            Dim res = MessageBox.Show("Is this correction adding stock? (Click Yes to Add, No to Deduct)", "Correction Direction", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If res = DialogResult.Cancel Then Return
            isNewAddition = (res = DialogResult.Yes)
        ElseIf newType = "Correction" AndAlso _editOriginalType = "Correction" Then
            isNewAddition = (_editOriginalSignedQty > 0)
        End If

        Dim newSignedQty As Integer = If(isNewAddition, newQty, -newQty)

        Try
            OpenConnection()
            Using transaction = conn.BeginTransaction()
                Try
                    If newProdId = _editStockProdId Then
                        Dim qUpdateStock As String = "UPDATE PRODUCT SET Stock_Quantity = Stock_Quantity - @origQty + @newQty WHERE Product_ID = @id"
                        Using cmdStock As New MySqlCommand(qUpdateStock, conn, transaction)
                            cmdStock.Parameters.AddWithValue("@origQty", _editOriginalSignedQty)
                            cmdStock.Parameters.AddWithValue("@newQty", newSignedQty)
                            cmdStock.Parameters.AddWithValue("@id", _editStockProdId)
                            cmdStock.ExecuteNonQuery()
                        End Using
                    Else
                        Dim qRevert As String = "UPDATE PRODUCT SET Stock_Quantity = Stock_Quantity - @origQty WHERE Product_ID = @oldId"
                        Using cmdRevert As New MySqlCommand(qRevert, conn, transaction)
                            cmdRevert.Parameters.AddWithValue("@origQty", _editOriginalSignedQty)
                            cmdRevert.Parameters.AddWithValue("@oldId", _editStockProdId)
                            cmdRevert.ExecuteNonQuery()
                        End Using

                        Dim qApply As String = "UPDATE PRODUCT SET Stock_Quantity = Stock_Quantity + @newQty WHERE Product_ID = @newId"
                        Using cmdApply As New MySqlCommand(qApply, conn, transaction)
                            cmdApply.Parameters.AddWithValue("@newQty", newSignedQty)
                            cmdApply.Parameters.AddWithValue("@newId", newProdId)
                            cmdApply.ExecuteNonQuery()
                        End Using
                    End If

                    Using cmdUpdate As New MySqlCommand("UPDATE STOCK_TRANSACTION SET Product_ID = @prodId, Transaction_Type = @type, Quantity = @qty, Remarks = @remarks WHERE Transaction_ID = @id", conn, transaction)
                        cmdUpdate.Parameters.AddWithValue("@prodId", newProdId)
                        cmdUpdate.Parameters.AddWithValue("@type", newType)
                        cmdUpdate.Parameters.AddWithValue("@qty", newSignedQty)
                        cmdUpdate.Parameters.AddWithValue("@remarks", s_txtEditRemarks.Text.Trim())
                        cmdUpdate.Parameters.AddWithValue("@id", _editStockTransId)
                        cmdUpdate.ExecuteNonQuery()
                    End Using

                    transaction.Commit()
                    MessageBox.Show("Transaction updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    s_pnlEditForm.Visible = False
                    S_LoadHistory()
                    M_LoadProducts("")
                    L_LoadAlerts("")
                Catch ex As Exception
                    transaction.Rollback()
                    Throw ex
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Update failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            Dim qWarranty As String = "CREATE TABLE IF NOT EXISTS WARRANTY (Warranty_ID INT PRIMARY KEY AUTO_INCREMENT, Item_ID INT, Warranty_Start_Date DATETIME, Warranty_End_Date DATETIME, Warranty_Status VARCHAR(20));"
            Using cmd As New MySqlCommand(qWarranty, conn)
                cmd.ExecuteNonQuery()
            End Using

            Dim qClaim As String = "CREATE TABLE IF NOT EXISTS WARRANTY_CLAIM (Claim_ID INT PRIMARY KEY AUTO_INCREMENT, Warranty_ID INT NOT NULL, Claim_Date DATE NOT NULL, Claim_Description TEXT NOT NULL, Claim_Resolution TEXT);"
            Using cmd As New MySqlCommand(qClaim, conn)
                cmd.ExecuteNonQuery()
            End Using

            Try
                Dim qAlterClaimStatus As String = "ALTER TABLE WARRANTY_CLAIM ADD COLUMN Claim_Status VARCHAR(20) NOT NULL DEFAULT 'Pending';"
                Using cmdAlterClaim As New MySqlCommand(qAlterClaimStatus, conn)
                    cmdAlterClaim.ExecuteNonQuery()
                End Using
            Catch exAlter As Exception
            End Try

            Try
                Dim qPopulate As String = "INSERT INTO WARRANTY (Item_ID, Warranty_Start_Date, Warranty_End_Date, Warranty_Status) " &
                                          "SELECT PI.Item_ID, PU.Purchase_Date, DATE_ADD(PU.Purchase_Date, INTERVAL 1 YEAR), 'Active' " &
                                          "FROM PURCHASE_ITEMS PI JOIN PURCHASE PU ON PI.Purchase_ID = PU.Purchase_ID " &
                                          "WHERE PI.Item_ID NOT IN (SELECT Item_ID FROM WARRANTY)"
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
                q &= " AND (c.Full_Name LIKE @search" &
                     " OR s.Service_Type LIKE @search" &
                     " OR st.Full_Name LIKE @search" &
                     " OR IFNULL(tc.Full_Name, '') LIKE @search)"
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
        Dim txt = vr_txtSearch.Text.Trim()
        If txt <> "" AndAlso txt <> "Search by Customer Name..." AndAlso vr_dgvRequests.Rows.Count > 0 Then
            VR_PopulateDetailPanel(0)
        Else
            vr_pnlDetail.Visible = False
        End If
    End Sub

    Private _vrDetailReqId As Integer = 0
    Private _vrDetailRowIndex As Integer = -1

    Private Sub VR_LoadEditCombos()
        Try
            OpenConnection()
            vr_cmbDetailService.Items.Clear()
            Using cmd As New MySqlCommand("SELECT Service_ID, Service_Type FROM SERVICE", conn)
                Using r = cmd.ExecuteReader()
                    While r.Read()
                        vr_cmbDetailService.Items.Add(New With {.Text = r("Service_Type").ToString(), .Value = r("Service_ID")})
                    End While
                End Using
            End Using
            vr_cmbDetailService.DisplayMember = "Text"
            vr_cmbDetailService.ValueMember = "Value"

            vr_cmbDetailStaff.Items.Clear()
            Using cmd As New MySqlCommand("SELECT Staff_ID, Full_Name FROM STAFF", conn)
                Using r = cmd.ExecuteReader()
                    While r.Read()
                        vr_cmbDetailStaff.Items.Add(New With {.Text = r("Full_Name").ToString(), .Value = r("Staff_ID")})
                    End While
                End Using
            End Using
            vr_cmbDetailStaff.DisplayMember = "Text"
            vr_cmbDetailStaff.ValueMember = "Value"

            vr_cmbDetailTech.Items.Clear()
            vr_cmbDetailTech.Items.Add(New With {.Text = "Unassigned", .Value = 0})
            Using cmd As New MySqlCommand("SELECT T.Technician_ID, S.Full_Name FROM TECHNICIAN T JOIN STAFF S ON T.Staff_ID = S.Staff_ID", conn)
                Using r = cmd.ExecuteReader()
                    While r.Read()
                        vr_cmbDetailTech.Items.Add(New With {.Text = r("Full_Name").ToString(), .Value = r("Technician_ID")})
                    End While
                End Using
            End Using
            vr_cmbDetailTech.DisplayMember = "Text"
            vr_cmbDetailTech.ValueMember = "Value"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub VR_PopulateDetailPanel(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= vr_dgvRequests.Rows.Count Then
            vr_pnlDetail.Visible = False
            Return
        End If
        _vrDetailRowIndex = rowIndex
        _vrDetailReqId = Convert.ToInt32(vr_dgvRequests.Rows(rowIndex).Cells("vr_colReqID").Value)

        ' Display-only info
        vr_txtDetailCust.Text = vr_dgvRequests.Rows(rowIndex).Cells("vr_colCust").Value.ToString()
        vr_lblDetailDate.Text = "Filed: " & vr_dgvRequests.Rows(rowIndex).Cells("vr_colDate").Value.ToString()

        ' Load combos if not yet loaded
        If vr_cmbDetailService.Items.Count = 0 Then VR_LoadEditCombos()

        ' Select correct Service
        Dim svcText = vr_dgvRequests.Rows(rowIndex).Cells("vr_colService").Value.ToString()
        For i As Integer = 0 To vr_cmbDetailService.Items.Count - 1
            If DirectCast(vr_cmbDetailService.Items(i), Object).Text = svcText Then
                vr_cmbDetailService.SelectedIndex = i : Exit For
            End If
        Next

        ' Select correct Staff
        Dim staffText = vr_dgvRequests.Rows(rowIndex).Cells("vr_colStaff").Value.ToString()
        For i As Integer = 0 To vr_cmbDetailStaff.Items.Count - 1
            If DirectCast(vr_cmbDetailStaff.Items(i), Object).Text = staffText Then
                vr_cmbDetailStaff.SelectedIndex = i : Exit For
            End If
        Next

        ' Select correct Tech (0 = Unassigned)
        Dim techText = vr_dgvRequests.Rows(rowIndex).Cells("vr_colTech").Value.ToString()
        vr_cmbDetailTech.SelectedIndex = 0
        For i As Integer = 1 To vr_cmbDetailTech.Items.Count - 1
            If DirectCast(vr_cmbDetailTech.Items(i), Object).Text = techText Then
                vr_cmbDetailTech.SelectedIndex = i : Exit For
            End If
        Next

        ' Load address and schedule from DB
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("SELECT Service_Address, Scheduled_Date FROM SERVICE_REQUEST WHERE Request_ID = @id", conn)
                cmd.Parameters.AddWithValue("@id", _vrDetailReqId)
                Using r = cmd.ExecuteReader()
                    If r.Read() Then
                        vr_txtDetailAddress.Text = If(r.IsDBNull(0), "", r.GetString(0))
                        If r.IsDBNull(1) Then
                            vr_dtpDetailSched.Checked = False
                        Else
                            vr_dtpDetailSched.Checked = True
                            vr_dtpDetailSched.Value = r.GetDateTime(1)
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
        End Try

        ' Status
        Dim statusText = vr_dgvRequests.Rows(rowIndex).Cells("vr_colStatus").Value.ToString()
        Dim statusIdx = vr_cmbDetailStatus.Items.IndexOf(statusText)
        vr_cmbDetailStatus.SelectedIndex = If(statusIdx >= 0, statusIdx, 0)

        vr_pnlDetail.Visible = True
    End Sub

    Private Sub vr_btnDetailUpdate_Click(sender As Object, e As EventArgs) Handles vr_btnDetailUpdate.Click
        If _vrDetailReqId = 0 Then Return
        If vr_cmbDetailService.SelectedIndex = -1 OrElse vr_cmbDetailStaff.SelectedIndex = -1 Then
            MessageBox.Show("Please select a service and staff coordinator.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            OpenConnection()
            Dim serviceId = Convert.ToInt32(DirectCast(vr_cmbDetailService.SelectedItem, Object).Value)
            Dim staffId = Convert.ToInt32(DirectCast(vr_cmbDetailStaff.SelectedItem, Object).Value)
            Dim techId As Object = DBNull.Value
            If vr_cmbDetailTech.SelectedIndex > 0 Then
                techId = Convert.ToInt32(DirectCast(vr_cmbDetailTech.SelectedItem, Object).Value)
            End If
            Dim schedDate As Object = DBNull.Value
            If vr_dtpDetailSched.Checked Then schedDate = vr_dtpDetailSched.Value
            Dim newStatus = vr_cmbDetailStatus.SelectedItem.ToString()
            Dim completedDate As Object = DBNull.Value
            If newStatus = "Completed" Then completedDate = DateTime.Now

            Using cmd As New MySqlCommand(
                "UPDATE SERVICE_REQUEST sr " &
                "JOIN CUSTOMER c ON sr.Customer_ID = c.Customer_ID " &
                "SET sr.Service_ID=@sid, sr.Staff_ID=@stid, sr.Technician_ID=@tid, " &
                "sr.Service_Address=@addr, sr.Scheduled_Date=@sdate, sr.Request_Status=@stat, sr.Completed_Date=@cdate, " &
                "c.Full_Name=@cname " &
                "WHERE sr.Request_ID=@id", conn)
                cmd.Parameters.AddWithValue("@sid", serviceId)
                cmd.Parameters.AddWithValue("@stid", staffId)
                cmd.Parameters.AddWithValue("@tid", techId)
                cmd.Parameters.AddWithValue("@addr", vr_txtDetailAddress.Text)
                cmd.Parameters.AddWithValue("@sdate", schedDate)
                cmd.Parameters.AddWithValue("@stat", newStatus)
                cmd.Parameters.AddWithValue("@cdate", completedDate)
                cmd.Parameters.AddWithValue("@cname", vr_txtDetailCust.Text.Trim())
                cmd.Parameters.AddWithValue("@id", _vrDetailReqId)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Service request updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SR_LoadRequests()
            vr_pnlDetail.Visible = False
        Catch ex As Exception
            MessageBox.Show("Failed to update: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub vr_btnDetailClose_Click(sender As Object, e As EventArgs) Handles vr_btnDetailClose.Click
        vr_pnlDetail.Visible = False
    End Sub

    Private Sub vr_dgvRequests_SelectionChanged(sender As Object, e As EventArgs) Handles vr_dgvRequests.SelectionChanged
        If vr_pnlDetail.Visible AndAlso vr_dgvRequests.SelectedRows.Count > 0 Then
            VR_PopulateDetailPanel(vr_dgvRequests.SelectedRows(0).Index)
        End If
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
        If e.RowIndex < 0 Then Return

        Dim reqId = Convert.ToInt32(vr_dgvRequests.Rows(e.RowIndex).Cells("vr_colReqID").Value)

        If e.ColumnIndex = vr_dgvRequests.Columns("vr_colActionUpdate").Index Then
            VR_PopulateDetailPanel(e.RowIndex)
        ElseIf e.ColumnIndex = vr_dgvRequests.Columns("vr_colActionDelete").Index Then
            SR_DeleteRequest(reqId)
        End If
    End Sub

    Private Sub SR_DeleteRequest(reqId As Integer)
        If MessageBox.Show("Delete this service request?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("DELETE FROM SERVICE_REQUEST WHERE Request_ID = @id", conn)
                cmd.Parameters.AddWithValue("@id", reqId)
                cmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("Service request deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SR_LoadRequests()
        Catch ex As Exception
            MessageBox.Show("Failed to delete service request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ==============================
    ' ADD SERVICE REQUEST LOGIC (SR_)
    ' ==============================
    Private Sub SR_PopulateDropdowns()
        Try
            OpenConnection()
            ' Customers
            SR_LoadCustomersForServiceRequest("")

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

    Private Sub SR_LoadCustomersForServiceRequest(searchText As String)
        Try
            OpenConnection()
            _isLoadingSrCustomers = True
            Dim dt As New DataTable()
            Dim q As String = "SELECT Customer_ID, Full_Name FROM CUSTOMER WHERE 1=1 "
            If Not String.IsNullOrWhiteSpace(searchText) Then
                q &= "AND Full_Name LIKE @search "
            End If
            q &= "ORDER BY Full_Name"

            Using cmd As New MySqlCommand(q, conn)
                If Not String.IsNullOrWhiteSpace(searchText) Then
                    cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")
                End If
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using

            sr_cmbExistingCust.DataSource = dt
            sr_cmbExistingCust.DisplayMember = "Full_Name"
            sr_cmbExistingCust.ValueMember = "Customer_ID"
            sr_cmbExistingCust.SelectedIndex = -1
        Catch ex As Exception
        Finally
            _isLoadingSrCustomers = False
        End Try
    End Sub

    Private Sub sr_cmbExistingCust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sr_cmbExistingCust.SelectedIndexChanged
        If sr_cmbExistingCust.SelectedIndex = -1 Then Return
        If sr_cmbExistingCust.SelectedValue Is Nothing OrElse TypeOf sr_cmbExistingCust.SelectedValue Is DataRowView Then Return
        Dim cid = Convert.ToInt32(sr_cmbExistingCust.SelectedValue)

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

    Private Sub sr_cmbExistingCust_TextUpdate(sender As Object, e As EventArgs) Handles sr_cmbExistingCust.TextUpdate
        If _isLoadingSrCustomers Then Return
        Dim typedText As String = sr_cmbExistingCust.Text.Trim()
        SR_LoadCustomersForServiceRequest(typedText)
        sr_cmbExistingCust.DroppedDown = True
        sr_cmbExistingCust.Text = typedText
        sr_cmbExistingCust.SelectionStart = typedText.Length
        sr_cmbExistingCust.SelectionLength = 0
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
                        If sr_cmbExistingCust.SelectedValue Is Nothing OrElse TypeOf sr_cmbExistingCust.SelectedValue Is DataRowView Then
                            MessageBox.Show("Please select a valid customer from the dropdown list.")
                            transaction.Rollback()
                            Return
                        End If
                        customerId = Convert.ToInt32(sr_cmbExistingCust.SelectedValue)
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
            Dim q As String = "SELECT W.Warranty_ID, C.Full_Name, P.Product_Name, W.Warranty_Start_Date, W.Warranty_End_Date, W.Warranty_Status " &
                              "FROM WARRANTY W " &
                              "JOIN PURCHASE_ITEMS PI ON W.Item_ID = PI.Item_ID " &
                              "JOIN PURCHASE PU ON PI.Purchase_ID = PU.Purchase_ID " &
                              "JOIN CUSTOMER C ON PU.Customer_ID = C.Customer_ID " &
                              "JOIN PRODUCT P ON PI.Product_ID = P.Product_ID " &
                              "WHERE (@search = '' OR C.Full_Name LIKE @search OR P.Product_Name LIKE @search) "

            If wr_cmbFilterStatus.SelectedIndex = 1 Then
                q &= "AND W.Warranty_End_Date >= NOW() "
            ElseIf wr_cmbFilterStatus.SelectedIndex = 2 Then
                q &= "AND W.Warranty_End_Date < NOW() "
            End If

            q &= "GROUP BY W.Warranty_ID, C.Full_Name, P.Product_Name, W.Warranty_Start_Date, W.Warranty_End_Date, W.Warranty_Status"
            
            Using cmd As New MySqlCommand(q, conn)
                Dim searchParam As String = If(wr_txtSearch.Text = "Search by Customer or Product...", "", "%" & wr_txtSearch.Text & "%")
                cmd.Parameters.AddWithValue("@search", searchParam)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim endDate As DateTime = Convert.ToDateTime(reader("Warranty_End_Date"))
                        Dim status As String = If(endDate >= DateTime.Now, "Active", "Expired")
                        Dim wid As Integer = Convert.ToInt32(reader("Warranty_ID"))
                        wr_dgvWarranties.Rows.Add(wid, reader("Full_Name"), reader("Product_Name"), Convert.ToDateTime(reader("Warranty_Start_Date")).ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"), status)
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
            Dim currentStatus As String = wr_dgvWarranties.Rows(e.RowIndex).Cells("wr_colStatus").Value.ToString()
            Dim newStatus As String = currentStatus
            If Not WR_ShowWarrantyStatusForm(newStatus) Then Return

            Try
                OpenConnection()
                Using cmd As New MySqlCommand("UPDATE WARRANTY SET Warranty_Status = @stat WHERE Warranty_ID = @id", conn)
                    cmd.Parameters.AddWithValue("@stat", newStatus)
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

    Private Function WR_ShowWarrantyStatusForm(ByRef warrantyStatus As String) As Boolean
        Dim statusOptions = New String() {"Active", "Expired"}
        Dim incomingStatus As String = warrantyStatus

        Using frm As New Form()
            frm.Text = "Update Warranty Status"
            frm.StartPosition = FormStartPosition.CenterParent
            frm.FormBorderStyle = FormBorderStyle.FixedDialog
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ClientSize = New Size(330, 150)

            Dim lblStatus As New Label() With {.Text = "Warranty Status", .Location = New Point(20, 20), .AutoSize = True}
            Dim cmbStatus As New ComboBox() With {.Location = New Point(20, 44), .Size = New Size(200, 24), .DropDownStyle = ComboBoxStyle.DropDownList}
            cmbStatus.Items.AddRange(statusOptions)
            Dim selectedStatus = statusOptions.FirstOrDefault(Function(s) s.Equals(incomingStatus, StringComparison.OrdinalIgnoreCase))
            cmbStatus.SelectedItem = If(selectedStatus Is Nothing, "Active", selectedStatus)

            Dim btnSave As New Button() With {.Text = "Save", .Size = New Size(85, 30), .Location = New Point(145, 95), .DialogResult = DialogResult.OK}
            Dim btnCancel As New Button() With {.Text = "Cancel", .Size = New Size(85, 30), .Location = New Point(235, 95), .DialogResult = DialogResult.Cancel}

            frm.Controls.Add(lblStatus)
            frm.Controls.Add(cmbStatus)
            frm.Controls.Add(btnSave)
            frm.Controls.Add(btnCancel)
            frm.AcceptButton = btnSave
            frm.CancelButton = btnCancel

            If frm.ShowDialog(Me) <> DialogResult.OK Then Return False
            If cmbStatus.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a valid warranty status.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            warrantyStatus = cmbStatus.SelectedItem.ToString()
            Return True
        End Using
    End Function

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
            Dim q As String = "SELECT DISTINCT C.Customer_ID, C.Full_Name FROM CUSTOMER C JOIN PURCHASE PU ON C.Customer_ID = PU.Customer_ID JOIN PURCHASE_ITEMS PI ON PU.Purchase_ID = PI.Purchase_ID JOIN WARRANTY W ON PI.Item_ID = W.Item_ID"
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
            Dim q As String = "SELECT W.Warranty_ID, P.Product_Name, PI.Quantity " &
                              "FROM WARRANTY W " &
                              "JOIN PURCHASE_ITEMS PI ON W.Item_ID = PI.Item_ID " &
                              "JOIN PURCHASE PU ON PI.Purchase_ID = PU.Purchase_ID " &
                              "JOIN PRODUCT P ON PI.Product_ID = P.Product_ID " &
                              "WHERE PU.Customer_ID = @cid"
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@cid", custId)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim txt As String = reader("Product_Name").ToString()
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
            Dim q As String = "SELECT W.Warranty_Start_Date, W.Warranty_End_Date FROM WARRANTY W JOIN PURCHASE_ITEMS PI ON W.Item_ID = PI.Item_ID JOIN PURCHASE PU ON PI.Purchase_ID = PU.Purchase_ID WHERE W.Warranty_ID = @wid"
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@wid", wid)
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
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

            Dim qReq As String = "INSERT INTO WARRANTY_CLAIM (Warranty_ID, Claim_Date, Claim_Description, Claim_Resolution, Claim_Status) VALUES (@wid, @cdate, @cdesc, @cres, @cstat)"
            Using cmd As New MySqlCommand(qReq, conn)
                cmd.Parameters.AddWithValue("@wid", wid)
                cmd.Parameters.AddWithValue("@cdate", DateTime.Now.Date)
                cmd.Parameters.AddWithValue("@cdesc", fc_txtIssue.Text)
                cmd.Parameters.AddWithValue("@cres", "Pending review")
                cmd.Parameters.AddWithValue("@cstat", "Pending")
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Warranty claim filed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            fc_cmbCustomer.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error filing claim: " & ex.Message)
        End Try
    End Sub

    ' ==============================
    ' VIEW WARRANTY CLAIM LOGIC (VC_)
    ' ==============================
    Private vc_tabPage As TabPage
    Private vc_txtSearch As TextBox
    Private vc_cmbStatus As ComboBox
    Private vc_dgvClaims As DataGridView
    Private vc_btnRefresh As Button

    Public Sub VC_ShowWarrantyClaims()
        VC_InitializeTabIfNeeded()
        tcMain.SelectedTab = vc_tabPage
        VC_LoadClaims()
    End Sub

    Private Sub VC_InitializeTabIfNeeded()
        If vc_tabPage IsNot Nothing Then Return

        vc_tabPage = New TabPage("ViewClaim") With {
            .BackColor = Color.White
        }
        tcMain.TabPages.Add(vc_tabPage)

        Dim lblTitle As New Label() With {
            .Text = "View Warranty Claim",
            .Font = New Font("Segoe UI", 16.0!, FontStyle.Bold),
            .Location = New Point(20, 15),
            .AutoSize = True
        }
        vc_tabPage.Controls.Add(lblTitle)

        Dim pnlFilter As New Panel() With {
            .Location = New Point(20, 55),
            .Size = New Size(820, 55),
            .BackColor = Color.White
        }
        vc_tabPage.Controls.Add(pnlFilter)

        vc_txtSearch = New TextBox() With {
            .Location = New Point(12, 16),
            .Size = New Size(290, 24),
            .Text = "Search by customer, product, or issue..."
        }
        AddHandler vc_txtSearch.Enter, AddressOf vc_txtSearch_Enter
        AddHandler vc_txtSearch.Leave, AddressOf vc_txtSearch_Leave
        AddHandler vc_txtSearch.TextChanged, AddressOf vc_txtSearch_TextChanged
        pnlFilter.Controls.Add(vc_txtSearch)

        vc_cmbStatus = New ComboBox() With {
            .Location = New Point(315, 16),
            .Size = New Size(140, 24),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        vc_cmbStatus.Items.AddRange(New String() {"All", "Pending", "In Progress", "Resolved", "Rejected"})
        vc_cmbStatus.SelectedIndex = 0
        AddHandler vc_cmbStatus.SelectedIndexChanged, AddressOf vc_cmbStatus_SelectedIndexChanged
        pnlFilter.Controls.Add(vc_cmbStatus)

        vc_btnRefresh = New Button() With {
            .Text = "Refresh",
            .Location = New Point(470, 14),
            .Size = New Size(90, 28)
        }
        AddHandler vc_btnRefresh.Click, Sub() VC_LoadClaims()
        pnlFilter.Controls.Add(vc_btnRefresh)

        vc_dgvClaims = New DataGridView() With {
            .Location = New Point(20, 120),
            .Size = New Size(820, 420),
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .ReadOnly = True,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            .MultiSelect = False
        }
        vc_dgvClaims.Columns.Add("vc_colClaimID", "Claim ID")
        vc_dgvClaims.Columns.Add("vc_colCustomer", "Customer")
        vc_dgvClaims.Columns.Add("vc_colProduct", "Product")
        vc_dgvClaims.Columns.Add("vc_colDate", "Claim Date")
        vc_dgvClaims.Columns.Add("vc_colIssue", "Description")
        vc_dgvClaims.Columns.Add("vc_colStatus", "Status")
        vc_dgvClaims.Columns.Add("vc_colResolution", "Resolution")

        Dim colEdit As New DataGridViewButtonColumn() With {.Name = "vc_colEdit", .HeaderText = "Update", .Text = "Update", .UseColumnTextForButtonValue = True}
        Dim colDelete As New DataGridViewButtonColumn() With {.Name = "vc_colDelete", .HeaderText = "Delete", .Text = "Delete", .UseColumnTextForButtonValue = True}
        vc_dgvClaims.Columns.Add(colEdit)
        vc_dgvClaims.Columns.Add(colDelete)

        AddHandler vc_dgvClaims.CellContentClick, AddressOf vc_dgvClaims_CellContentClick
        vc_tabPage.Controls.Add(vc_dgvClaims)
    End Sub

    Private Sub VC_EnsureClaimStatusColumn()
        Try
            OpenConnection()
            Dim q As String = "ALTER TABLE WARRANTY_CLAIM ADD COLUMN Claim_Status VARCHAR(20) NOT NULL DEFAULT 'Pending';"
            Using cmd As New MySqlCommand(q, conn)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub VC_LoadClaims()
        If vc_dgvClaims Is Nothing Then Return
        vc_dgvClaims.Rows.Clear()
        Try
            OpenConnection()
            VC_EnsureClaimStatusColumn()

            Dim searchText As String = vc_txtSearch.Text.Trim()
            If searchText = "Search by customer, product, or issue..." Then searchText = ""

            Dim q As String = "SELECT WC.Claim_ID, WC.Warranty_ID, C.Full_Name, P.Product_Name, WC.Claim_Date, " &
                              "WC.Claim_Description, IFNULL(WC.Claim_Status, 'Pending') AS Claim_Status, IFNULL(WC.Claim_Resolution, '') AS Claim_Resolution " &
                              "FROM WARRANTY_CLAIM WC " &
                              "JOIN WARRANTY W ON WC.Warranty_ID = W.Warranty_ID " &
                              "JOIN PURCHASE_ITEMS PI ON W.Item_ID = PI.Item_ID " &
                              "JOIN PURCHASE PU ON PI.Purchase_ID = PU.Purchase_ID " &
                              "JOIN CUSTOMER C ON PU.Customer_ID = C.Customer_ID " &
                              "JOIN PRODUCT P ON PI.Product_ID = P.Product_ID " &
                              "WHERE 1=1 "

            If vc_cmbStatus.SelectedIndex > 0 Then
                q &= "AND IFNULL(WC.Claim_Status, 'Pending') = @status "
            End If
            If Not String.IsNullOrWhiteSpace(searchText) Then
                q &= "AND (C.Full_Name LIKE @search OR P.Product_Name LIKE @search OR WC.Claim_Description LIKE @search) "
            End If

            q &= "ORDER BY WC.Claim_Date DESC, WC.Claim_ID DESC"

            Using cmd As New MySqlCommand(q, conn)
                If vc_cmbStatus.SelectedIndex > 0 Then
                    cmd.Parameters.AddWithValue("@status", vc_cmbStatus.SelectedItem.ToString())
                End If
                If Not String.IsNullOrWhiteSpace(searchText) Then
                    cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")
                End If

                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        vc_dgvClaims.Rows.Add(
                            Convert.ToInt32(reader("Claim_ID")),
                            reader("Full_Name").ToString(),
                            reader("Product_Name").ToString(),
                            Convert.ToDateTime(reader("Claim_Date")).ToString("yyyy-MM-dd"),
                            reader("Claim_Description").ToString(),
                            reader("Claim_Status").ToString(),
                            reader("Claim_Resolution").ToString()
                        )
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading warranty claims: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub vc_txtSearch_Enter(sender As Object, e As EventArgs)
        If vc_txtSearch.Text = "Search by customer, product, or issue..." Then vc_txtSearch.Text = ""
    End Sub

    Private Sub vc_txtSearch_Leave(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(vc_txtSearch.Text) Then vc_txtSearch.Text = "Search by customer, product, or issue..."
    End Sub

    Private Sub vc_txtSearch_TextChanged(sender As Object, e As EventArgs)
        VC_LoadClaims()
    End Sub

    Private Sub vc_cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs)
        VC_LoadClaims()
    End Sub

    Private Sub vc_dgvClaims_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return

        Dim claimId As Integer = Convert.ToInt32(vc_dgvClaims.Rows(e.RowIndex).Cells("vc_colClaimID").Value)
        Dim colName As String = vc_dgvClaims.Columns(e.ColumnIndex).Name

        If colName = "vc_colEdit" Then
            VC_EditClaim(claimId, e.RowIndex)
        ElseIf colName = "vc_colDelete" Then
            VC_DeleteClaim(claimId)
        End If
    End Sub

    Private Sub VC_EditClaim(claimId As Integer, rowIndex As Integer)
        Dim currentDesc As String = vc_dgvClaims.Rows(rowIndex).Cells("vc_colIssue").Value.ToString()
        Dim currentRes As String = vc_dgvClaims.Rows(rowIndex).Cells("vc_colResolution").Value.ToString()
        Dim currentStatus As String = vc_dgvClaims.Rows(rowIndex).Cells("vc_colStatus").Value.ToString()

        Dim newDesc As String = currentDesc
        Dim newRes As String = currentRes
        Dim newStatus As String = currentStatus

        If Not VC_ShowClaimEditForm(newDesc, newRes, newStatus, False) Then Return

        Try
            OpenConnection()
            VC_EnsureClaimStatusColumn()
            Dim q As String = "UPDATE WARRANTY_CLAIM SET Claim_Description = @d, Claim_Resolution = @r, Claim_Status = @s WHERE Claim_ID = @id"
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@d", newDesc)
                cmd.Parameters.AddWithValue("@r", newRes)
                cmd.Parameters.AddWithValue("@s", newStatus)
                cmd.Parameters.AddWithValue("@id", claimId)
                cmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("Claim updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            VC_LoadClaims()
        Catch ex As Exception
            MessageBox.Show("Error updating claim: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub VC_DeleteClaim(claimId As Integer)
        If MessageBox.Show("Delete this warranty claim?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
            Return
        End If

        Try
            OpenConnection()
            Dim q As String = "DELETE FROM WARRANTY_CLAIM WHERE Claim_ID = @id"
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@id", claimId)
                cmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("Claim deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            VC_LoadClaims()
        Catch ex As Exception
            MessageBox.Show("Error deleting claim: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function VC_ShowClaimEditForm(ByRef claimDesc As String, ByRef claimResolution As String, ByRef claimStatus As String, statusOnly As Boolean) As Boolean
        Dim validStatuses = New String() {"Pending", "In Progress", "Resolved", "Rejected"}
        Dim incomingStatus As String = claimStatus

        Using frm As New Form()
            frm.Text = If(statusOnly, "Update Claim Status", "Edit Warranty Claim")
            frm.StartPosition = FormStartPosition.CenterParent
            frm.FormBorderStyle = FormBorderStyle.FixedDialog
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.ClientSize = If(statusOnly, New Size(360, 150), New Size(480, 330))

            Dim y As Integer = 15
            Dim lblStatus As New Label() With {.Text = "Claim Status", .Location = New Point(20, y), .AutoSize = True}
            Dim cmbStatus As New ComboBox() With {.Location = New Point(20, y + 20), .Size = New Size(200, 24), .DropDownStyle = ComboBoxStyle.DropDownList}
            cmbStatus.Items.AddRange(validStatuses)
            Dim selectedStatus = validStatuses.FirstOrDefault(Function(s) s.Equals(incomingStatus, StringComparison.OrdinalIgnoreCase))
            cmbStatus.SelectedItem = If(selectedStatus Is Nothing, "Pending", selectedStatus)
            frm.Controls.Add(lblStatus)
            frm.Controls.Add(cmbStatus)

            Dim txtDesc As TextBox = Nothing
            Dim txtRes As TextBox = Nothing

            If Not statusOnly Then
                y += 55
                Dim lblDesc As New Label() With {.Text = "Claim Description", .Location = New Point(20, y), .AutoSize = True}
                txtDesc = New TextBox() With {.Location = New Point(20, y + 20), .Size = New Size(440, 90), .Multiline = True, .ScrollBars = ScrollBars.Vertical, .Text = claimDesc}
                frm.Controls.Add(lblDesc)
                frm.Controls.Add(txtDesc)

                y += 120
                Dim lblRes As New Label() With {.Text = "Claim Resolution", .Location = New Point(20, y), .AutoSize = True}
                txtRes = New TextBox() With {.Location = New Point(20, y + 20), .Size = New Size(440, 80), .Multiline = True, .ScrollBars = ScrollBars.Vertical, .Text = claimResolution}
                frm.Controls.Add(lblRes)
                frm.Controls.Add(txtRes)
            End If

            Dim btnSave As New Button() With {.Text = "Save", .Size = New Size(90, 30), .Location = If(statusOnly, New Point(170, 100), New Point(270, 285))}
            Dim btnCancel As New Button() With {.Text = "Cancel", .Size = New Size(90, 30), .Location = If(statusOnly, New Point(270, 100), New Point(370, 285))}
            btnSave.DialogResult = DialogResult.OK
            btnCancel.DialogResult = DialogResult.Cancel
            frm.Controls.Add(btnSave)
            frm.Controls.Add(btnCancel)
            frm.AcceptButton = btnSave
            frm.CancelButton = btnCancel

            If frm.ShowDialog(Me) <> DialogResult.OK Then Return False

            If cmbStatus.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a valid claim status.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            If Not statusOnly Then
                If txtDesc Is Nothing OrElse String.IsNullOrWhiteSpace(txtDesc.Text) Then
                    MessageBox.Show("Claim description is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
                claimDesc = txtDesc.Text.Trim()
                claimResolution = If(txtRes Is Nothing, "", txtRes.Text.Trim())
            End If

            claimStatus = cmbStatus.SelectedItem.ToString()
            Return True
        End Using
    End Function

    ' ==============================
    ' STAFF & TECHNICIAN (ST_)
    ' ==============================
    Private stAdd_tabPage As TabPage
    Private stManage_tabPage As TabPage
    Private st_txtFullName As TextBox
    Private st_txtContact As TextBox
    Private st_cmbStaffStatus As ComboBox
    Private st_dtpDateHired As DateTimePicker
    Private st_chkIsTechnician As CheckBox
    Private st_txtSpecialization As TextBox
    Private st_cmbTechStatus As ComboBox
    Private st_txtCertification As TextBox
    Private st_dgv As DataGridView
    Private st_txtSearch As TextBox
    Private st_cmbFilter As ComboBox
    Private st_pnlDetail As Panel
    Private st_detFullName As TextBox
    Private st_detContact As TextBox
    Private st_detStaffStatus As ComboBox
    Private st_detDateHired As DateTimePicker
    Private st_detIsTech As CheckBox
    Private st_detSpec As TextBox
    Private st_detTechStatus As ComboBox
    Private st_detCert As TextBox
    Private _stDetailId As Integer = 0

    Private sup_tabPage As TabPage
    Private sup_txtName As TextBox
    Private sup_txtContact As TextBox
    Private sup_txtAddress As TextBox
    Private sup_txtSearch As TextBox
    Private sup_dgv As DataGridView
    Private sup_editSupplierId As Integer = 0
    Private sup_addressColumnName As String = ""
    Private rptSales_tabPage As TabPage
    Private rptSales_dgv As DataGridView
    Private rptSales_cmbFilter As ComboBox
    Private rptSales_lblTotalAmount As Label
    Private rptSales_lblTotalItems As Label

    Private Sub ST_InitializeTables()
        Try
            OpenConnection()

            Dim qStaff As String = "CREATE TABLE IF NOT EXISTS STAFF (" &
                                   "Staff_ID INT PRIMARY KEY AUTO_INCREMENT, " &
                                   "Full_Name VARCHAR(100) NOT NULL, " &
                                   "Contact_Number VARCHAR(20) NOT NULL, " &
                                   "Staff_Status VARCHAR(20) NOT NULL DEFAULT 'Active', " &
                                   "Date_Hired DATE NOT NULL)"
            Using cmd As New MySqlCommand(qStaff, conn)
                cmd.ExecuteNonQuery()
            End Using

            Dim qTech As String = "CREATE TABLE IF NOT EXISTS TECHNICIAN (" &
                                  "Technician_ID INT PRIMARY KEY AUTO_INCREMENT, " &
                                  "Staff_ID INT NOT NULL UNIQUE, " &
                                  "Specialization VARCHAR(100) NOT NULL, " &
                                  "Technician_Status VARCHAR(20) NOT NULL DEFAULT 'Active', " &
                                  "Certification VARCHAR(100), " &
                                  "CONSTRAINT fk_technician_staff FOREIGN KEY (Staff_ID) REFERENCES STAFF(Staff_ID) ON UPDATE CASCADE ON DELETE RESTRICT)"
            Using cmd As New MySqlCommand(qTech, conn)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Public Sub RPT_ShowSalesReport()
        RPT_EnsureSalesReportTab()
        tcMain.SelectedTab = rptSales_tabPage
        RPT_LoadSalesReport()
    End Sub

    Private Sub RPT_EnsureSalesReportTab()
        If rptSales_tabPage IsNot Nothing Then Return

        rptSales_tabPage = tpReportMain
        rptSales_tabPage.Text = "Sales Report"
        rptSales_tabPage.BackColor = Color.White
        rptSales_tabPage.Controls.Clear()

        Dim lblTitle As New Label() With {.Text = "Sales Report", .Font = New Font("Segoe UI", 16, FontStyle.Bold), .Location = New Point(20, 15), .AutoSize = True}
        rptSales_tabPage.Controls.Add(lblTitle)

        Dim btnRefresh As New Button() With {.Text = "Refresh", .Location = New Point(20, 55), .Size = New Size(80, 30)}
        AddHandler btnRefresh.Click, Sub() RPT_LoadSalesReport()
        rptSales_tabPage.Controls.Add(btnRefresh)

        Dim btnExport As New Button() With {.Text = "Preview & Export to Excel", .Location = New Point(110, 55), .Size = New Size(180, 30)}
        AddHandler btnExport.Click, AddressOf RPT_ExportSalesReport_Click
        rptSales_tabPage.Controls.Add(btnExport)

        rptSales_cmbFilter = New ComboBox() With {.Location = New Point(300, 58), .Size = New Size(130, 24), .DropDownStyle = ComboBoxStyle.DropDownList}
        rptSales_cmbFilter.Items.AddRange(New String() {"Today", "This Week", "This Month", "Last 30 Days", "This Year", "All"})
        rptSales_cmbFilter.SelectedIndex = 5
        AddHandler rptSales_cmbFilter.SelectedIndexChanged, Sub() RPT_LoadSalesReport()
        rptSales_tabPage.Controls.Add(rptSales_cmbFilter)

        Dim pnlCardAmount As New Panel() With {.Location = New Point(490, 50), .Size = New Size(170, 60), .BackColor = Color.FromArgb(245, 245, 248), .BorderStyle = BorderStyle.FixedSingle}
        pnlCardAmount.Controls.Add(New Label() With {.Text = "Total Amount", .Location = New Point(10, 8), .AutoSize = True, .ForeColor = Color.FromArgb(70, 70, 70)})
        rptSales_lblTotalAmount = New Label() With {.Text = "0.00", .Location = New Point(10, 30), .AutoSize = True, .Font = New Font("Segoe UI", 11, FontStyle.Bold), .ForeColor = Color.FromArgb(0, 120, 215)}
        pnlCardAmount.Controls.Add(rptSales_lblTotalAmount)
        rptSales_tabPage.Controls.Add(pnlCardAmount)

        Dim pnlCardItems As New Panel() With {.Location = New Point(670, 50), .Size = New Size(170, 60), .BackColor = Color.FromArgb(245, 245, 248), .BorderStyle = BorderStyle.FixedSingle}
        pnlCardItems.Controls.Add(New Label() With {.Text = "Total Items", .Location = New Point(10, 8), .AutoSize = True, .ForeColor = Color.FromArgb(70, 70, 70)})
        rptSales_lblTotalItems = New Label() With {.Text = "0", .Location = New Point(10, 30), .AutoSize = True, .Font = New Font("Segoe UI", 11, FontStyle.Bold), .ForeColor = Color.FromArgb(0, 120, 215)}
        pnlCardItems.Controls.Add(rptSales_lblTotalItems)
        rptSales_tabPage.Controls.Add(pnlCardItems)

        rptSales_dgv = New DataGridView() With {
            .Location = New Point(20, 125),
            .Size = New Size(820, 410),
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .ReadOnly = True,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        }
        rptSales_dgv.Columns.Add("rptSale_colPurchaseId", "Purchase ID")
        rptSales_dgv.Columns.Add("rptSale_colReceipt", "Receipt Number")
        rptSales_dgv.Columns.Add("rptSale_colDate", "Purchase Date")
        rptSales_dgv.Columns.Add("rptSale_colCustomer", "Customer")
        rptSales_dgv.Columns.Add("rptSale_colItemCount", "Total Items")
        rptSales_dgv.Columns.Add("rptSale_colAmount", "Total Amount")
        rptSales_tabPage.Controls.Add(rptSales_dgv)
    End Sub

    Private Sub RPT_LoadSalesReport()
        If rptSales_dgv Is Nothing Then Return
        rptSales_dgv.Rows.Clear()
        Try
            OpenConnection()
            Dim startDate As DateTime = DateTime.MinValue
            Dim endDate As DateTime = DateTime.MaxValue
            RPT_GetDateRange(startDate, endDate)
            Dim q As String = "SELECT P.Purchase_ID, P.Receipt_Number, P.Purchase_Date, C.Full_Name, " &
                              "IFNULL(SUM(PI.Quantity), 0) AS Total_Items, IFNULL(SUM(PI.Quantity * PI.Item_Price), 0) AS Total_Amount " &
                              "FROM PURCHASE P " &
                              "JOIN CUSTOMER C ON P.Customer_ID = C.Customer_ID " &
                              "LEFT JOIN PURCHASE_ITEMS PI ON P.Purchase_ID = PI.Purchase_ID WHERE 1=1 "
            If startDate <> DateTime.MinValue AndAlso endDate <> DateTime.MaxValue Then
                q &= "AND P.Purchase_Date >= @start AND P.Purchase_Date <= @end "
            End If
            q &= "GROUP BY P.Purchase_ID, P.Receipt_Number, P.Purchase_Date, C.Full_Name " &
                              "ORDER BY P.Purchase_Date DESC, P.Purchase_ID DESC"

            Dim totalItems As Integer = 0
            Dim totalAmount As Decimal = 0D
            Using cmd As New MySqlCommand(q, conn)
                If startDate <> DateTime.MinValue AndAlso endDate <> DateTime.MaxValue Then
                    cmd.Parameters.AddWithValue("@start", startDate.Date)
                    cmd.Parameters.AddWithValue("@end", endDate.Date.AddDays(1).AddTicks(-1))
                End If
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim items = Convert.ToInt32(reader("Total_Items"))
                        Dim amount = Convert.ToDecimal(reader("Total_Amount"))
                        totalItems += items
                        totalAmount += amount
                        rptSales_dgv.Rows.Add(
                            Convert.ToInt32(reader("Purchase_ID")),
                            reader("Receipt_Number").ToString(),
                            Convert.ToDateTime(reader("Purchase_Date")).ToString("yyyy-MM-dd"),
                            reader("Full_Name").ToString(),
                            items,
                            amount.ToString("N2")
                        )
                    End While
                End Using
            End Using

            If rptSales_lblTotalItems IsNot Nothing Then rptSales_lblTotalItems.Text = totalItems.ToString("N0")
            If rptSales_lblTotalAmount IsNot Nothing Then rptSales_lblTotalAmount.Text = totalAmount.ToString("N2")
        Catch ex As Exception
            MessageBox.Show("Failed to load sales report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RPT_GetDateRange(ByRef startDate As DateTime, ByRef endDate As DateTime)
        startDate = DateTime.MinValue
        endDate = DateTime.MaxValue
        If rptSales_cmbFilter Is Nothing OrElse rptSales_cmbFilter.SelectedItem Is Nothing Then Return

        Dim nowDate = DateTime.Now.Date
        Select Case rptSales_cmbFilter.SelectedItem.ToString()
            Case "Today"
                startDate = nowDate
                endDate = nowDate
            Case "This Week"
                Dim mondayOffset As Integer = (CInt(nowDate.DayOfWeek) + 6) Mod 7
                Dim weekStart = nowDate.AddDays(-mondayOffset)
                startDate = weekStart
                endDate = weekStart.AddDays(6)
            Case "This Month"
                startDate = New DateTime(nowDate.Year, nowDate.Month, 1)
                endDate = startDate.AddMonths(1).AddDays(-1)
            Case "Last 30 Days"
                startDate = nowDate.AddDays(-29)
                endDate = nowDate
            Case "This Year"
                startDate = New DateTime(nowDate.Year, 1, 1)
                endDate = New DateTime(nowDate.Year, 12, 31)
            Case Else ' All
        End Select
    End Sub

    Private Sub RPT_ExportSalesReport_Click(sender As Object, e As EventArgs)
        If rptSales_dgv Is Nothing OrElse rptSales_dgv.Rows.Count = 0 Then
            MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Show Preview First
        _rptPrintRowIndex = 0
        Dim pd As New System.Drawing.Printing.PrintDocument()
        pd.DefaultPageSettings.Landscape = True ' Better for tables
        AddHandler pd.PrintPage, AddressOf rpt_pd_PrintPage

        Using ppd As New PrintPreviewDialog()
            ppd.Document = pd
            ppd.Width = 800
            ppd.Height = 600
            ppd.Text = "Preview before Exporting to Excel"
            ppd.ShowDialog()
        End Using

        ' Prompt for export
        Dim result = MessageBox.Show("Do you want to proceed with exporting this report to Excel?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result <> DialogResult.Yes Then Return

        Using sfd As New SaveFileDialog()
            sfd.Filter = "Excel Compatible CSV (*.csv)|*.csv"
            sfd.FileName = "sales_report_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"
            If sfd.ShowDialog() <> DialogResult.OK Then Return

            Try
                Using sw As New StreamWriter(sfd.FileName, False, System.Text.Encoding.UTF8)
                    ' Write layout/header
                    sw.WriteLine("Sales Report")
                    sw.WriteLine("Total Items:," & rptSales_lblTotalItems.Text)
                    sw.WriteLine("Total Amount:," & rptSales_lblTotalAmount.Text)
                    sw.WriteLine()

                    Dim headers As New List(Of String)
                    For Each col As DataGridViewColumn In rptSales_dgv.Columns
                        headers.Add("""" & col.HeaderText.Replace("""", """""") & """")
                    Next
                    sw.WriteLine(String.Join(",", headers))

                    For Each row As DataGridViewRow In rptSales_dgv.Rows
                        If row.IsNewRow Then Continue For
                        Dim values As New List(Of String)
                        For i As Integer = 0 To rptSales_dgv.Columns.Count - 1
                            Dim cellValue = If(row.Cells(i).Value, "").ToString()
                            values.Add("""" & cellValue.Replace("""", """""") & """")
                        Next
                        sw.WriteLine(String.Join(",", values))
                    Next
                End Using
                MessageBox.Show("Sales report exported successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Failed to export file: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private _rptPrintRowIndex As Integer = 0

    Private Sub rpt_pd_PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs)
        Dim g As Graphics = e.Graphics
        Dim fTitle As New Font("Segoe UI", 16, FontStyle.Bold)
        Dim fHeader As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fRegular As New Font("Segoe UI", 10, FontStyle.Regular)
        Dim brush As New SolidBrush(Color.Black)

        Dim startX As Integer = 50
        Dim startY As Integer = 50
        Dim offset As Integer = 0

        ' Only print header on first page
        If _rptPrintRowIndex = 0 Then
            g.DrawString("MIDEA PRO SHOP - SALES REPORT", fTitle, brush, startX, startY + offset)
            offset += 40

            g.DrawString("Total Items: " & rptSales_lblTotalItems.Text, fRegular, brush, startX, startY + offset)
            offset += 25
            g.DrawString("Total Amount: ₱" & rptSales_lblTotalAmount.Text, fRegular, brush, startX, startY + offset)
            offset += 40
        End If

        ' Draw Headers
        Dim colWidths() As Integer = {100, 150, 120, 220, 100, 150}
        Dim headers() As String = {"Purchase ID", "Receipt No", "Date", "Customer", "Items", "Amount"}
        
        Dim curX As Integer = startX
        For i As Integer = 0 To headers.Length - 1
            g.DrawString(headers(i), fHeader, brush, curX, startY + offset)
            curX += colWidths(i)
        Next
        offset += 25
        g.DrawLine(Pens.Black, startX, startY + offset, startX + colWidths.Sum(), startY + offset)
        offset += 10

        ' Draw Rows
        While _rptPrintRowIndex < rptSales_dgv.Rows.Count
            Dim row = rptSales_dgv.Rows(_rptPrintRowIndex)
            If Not row.IsNewRow Then
                curX = startX
                For i As Integer = 0 To rptSales_dgv.Columns.Count - 1
                    Dim val = If(row.Cells(i).Value, "").ToString()
                    ' Truncate long strings (e.g. Customer Name)
                    If g.MeasureString(val, fRegular).Width > colWidths(i) Then
                        While g.MeasureString(val & "...", fRegular).Width > colWidths(i) AndAlso val.Length > 0
                            val = val.Substring(0, val.Length - 1)
                        End While
                        val &= "..."
                    End If
                    g.DrawString(val, fRegular, brush, curX, startY + offset)
                    curX += colWidths(i)
                Next
                offset += 25
            End If
            
            _rptPrintRowIndex += 1
            
            ' Pagination check
            If startY + offset > e.MarginBounds.Bottom - 50 AndAlso _rptPrintRowIndex < rptSales_dgv.Rows.Count Then
                e.HasMorePages = True
                Return
            End If
        End While

        e.HasMorePages = False
        _rptPrintRowIndex = 0 ' Reset for next print
    End Sub

    Public Sub SUP_ShowManageSupplier()
        SUP_InitializeTabIfNeeded()
        tcMain.SelectedTab = sup_tabPage
        SUP_LoadGrid()
    End Sub

    Private Sub SUP_InitializeTabIfNeeded()
        If sup_tabPage IsNot Nothing Then Return

        sup_tabPage = tpSupplierMain
        sup_tabPage.Text = "Manage Supplier"
        sup_tabPage.BackColor = Color.White
        sup_tabPage.Controls.Clear()

        Dim lblTitle As New Label() With {.Text = "Manage Supplier", .Font = New Font("Segoe UI", 16, FontStyle.Bold), .Location = New Point(20, 15), .AutoSize = True}
        sup_tabPage.Controls.Add(lblTitle)

        Dim pnlForm As New Panel() With {.Location = New Point(20, 55), .Size = New Size(820, 140), .BackColor = Color.FromArgb(245, 245, 248)}
        sup_tabPage.Controls.Add(pnlForm)

        pnlForm.Controls.Add(New Label() With {.Text = "Supplier Name", .Location = New Point(20, 18), .AutoSize = True})
        sup_txtName = New TextBox() With {.Location = New Point(20, 38), .Size = New Size(250, 24)}
        pnlForm.Controls.Add(sup_txtName)

        pnlForm.Controls.Add(New Label() With {.Text = "Contact Number", .Location = New Point(285, 18), .AutoSize = True})
        sup_txtContact = New TextBox() With {.Location = New Point(285, 38), .Size = New Size(170, 24)}
        pnlForm.Controls.Add(sup_txtContact)

        pnlForm.Controls.Add(New Label() With {.Text = "Warehouse Address", .Location = New Point(470, 18), .AutoSize = True})
        sup_txtAddress = New TextBox() With {.Location = New Point(470, 38), .Size = New Size(330, 24)}
        pnlForm.Controls.Add(sup_txtAddress)

        Dim btnSave As New Button() With {.Text = "Save", .Location = New Point(20, 84), .Size = New Size(95, 34), .BackColor = Color.FromArgb(40, 167, 69), .ForeColor = Color.White}
        AddHandler btnSave.Click, AddressOf SUP_Save_Click
        pnlForm.Controls.Add(btnSave)

        Dim btnClear As New Button() With {.Text = "Clear", .Location = New Point(125, 84), .Size = New Size(90, 34)}
        AddHandler btnClear.Click, Sub() SUP_ClearForm()
        pnlForm.Controls.Add(btnClear)

        sup_txtSearch = New TextBox() With {.Location = New Point(20, 210), .Size = New Size(280, 24), .Text = "Search supplier..."}
        AddHandler sup_txtSearch.Enter, Sub()
                                            If sup_txtSearch.Text = "Search supplier..." Then sup_txtSearch.Text = ""
                                        End Sub
        AddHandler sup_txtSearch.Leave, Sub()
                                            If String.IsNullOrWhiteSpace(sup_txtSearch.Text) Then sup_txtSearch.Text = "Search supplier..."
                                        End Sub
        AddHandler sup_txtSearch.TextChanged, Sub() SUP_LoadGrid()
        sup_tabPage.Controls.Add(sup_txtSearch)

        Dim btnRefresh As New Button() With {.Text = "Refresh", .Location = New Point(315, 208), .Size = New Size(90, 28)}
        AddHandler btnRefresh.Click, Sub() SUP_LoadGrid()
        sup_tabPage.Controls.Add(btnRefresh)

        sup_dgv = New DataGridView() With {
            .Location = New Point(20, 245),
            .Size = New Size(820, 290),
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .ReadOnly = True,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        }
        sup_dgv.Columns.Add("sup_colId", "Supplier ID")
        sup_dgv.Columns.Add("sup_colName", "Supplier Name")
        sup_dgv.Columns.Add("sup_colContact", "Contact Number")
        sup_dgv.Columns.Add("sup_colAddress", "Warehouse Address")
        sup_dgv.Columns.Add(New DataGridViewButtonColumn() With {.Name = "sup_colUpdate", .HeaderText = "Update", .Text = "Update", .UseColumnTextForButtonValue = True})
        sup_dgv.Columns.Add(New DataGridViewButtonColumn() With {.Name = "sup_colDelete", .HeaderText = "Delete", .Text = "Delete", .UseColumnTextForButtonValue = True})
        AddHandler sup_dgv.CellContentClick, AddressOf SUP_dgv_CellContentClick
        sup_tabPage.Controls.Add(sup_dgv)
    End Sub

    Private Function SUP_GetAddressColumnName() As String
        If Not String.IsNullOrWhiteSpace(sup_addressColumnName) Then Return sup_addressColumnName
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("SELECT Warehouse_Address FROM SUPPLIER LIMIT 1", conn)
                cmd.ExecuteScalar()
                sup_addressColumnName = "Warehouse_Address"
                Return sup_addressColumnName
            End Using
        Catch
            sup_addressColumnName = "Address"
            Return sup_addressColumnName
        End Try
    End Function

    Private Sub SUP_Save_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(sup_txtName.Text) Then
            MessageBox.Show("Supplier name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If String.IsNullOrWhiteSpace(sup_txtContact.Text) Then
            MessageBox.Show("Contact number is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If String.IsNullOrWhiteSpace(sup_txtAddress.Text) Then
            MessageBox.Show("Warehouse address is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            OpenConnection()
            Dim addrCol = SUP_GetAddressColumnName()
            Dim q As String
            If sup_editSupplierId > 0 Then
                q = $"UPDATE SUPPLIER SET Supplier_Name=@n, Contact_Number=@c, {addrCol}=@a WHERE Supplier_ID=@id"
            Else
                q = $"INSERT INTO SUPPLIER (Supplier_Name, Contact_Number, {addrCol}) VALUES (@n, @c, @a)"
            End If

            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@n", sup_txtName.Text.Trim())
                cmd.Parameters.AddWithValue("@c", sup_txtContact.Text.Trim())
                cmd.Parameters.AddWithValue("@a", sup_txtAddress.Text.Trim())
                If sup_editSupplierId > 0 Then cmd.Parameters.AddWithValue("@id", sup_editSupplierId)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show(If(sup_editSupplierId > 0, "Supplier updated successfully.", "Supplier added successfully."), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SUP_ClearForm()
            SUP_LoadGrid()
            A_LoadSuppliers()
        Catch ex As Exception
            MessageBox.Show("Error saving supplier: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SUP_LoadGrid()
        If sup_dgv Is Nothing Then Return
        sup_dgv.Rows.Clear()
        Try
            OpenConnection()
            Dim addrCol = SUP_GetAddressColumnName()
            Dim q As String = $"SELECT Supplier_ID, Supplier_Name, Contact_Number, IFNULL({addrCol}, '') AS Warehouse_Address FROM SUPPLIER WHERE 1=1 "

            Dim search As String = sup_txtSearch.Text.Trim()
            If search = "Search supplier..." Then search = ""
            If Not String.IsNullOrWhiteSpace(search) Then
                q &= $"AND (Supplier_Name LIKE @s OR Contact_Number LIKE @s OR {addrCol} LIKE @s) "
            End If
            q &= "ORDER BY Supplier_ID DESC"

            Using cmd As New MySqlCommand(q, conn)
                If Not String.IsNullOrWhiteSpace(search) Then cmd.Parameters.AddWithValue("@s", "%" & search & "%")
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        sup_dgv.Rows.Add(
                            Convert.ToInt32(reader("Supplier_ID")),
                            reader("Supplier_Name").ToString(),
                            reader("Contact_Number").ToString(),
                            reader("Warehouse_Address").ToString()
                        )
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading suppliers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SUP_dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        Dim supplierId As Integer = Convert.ToInt32(sup_dgv.Rows(e.RowIndex).Cells("sup_colId").Value)
        Dim colName As String = sup_dgv.Columns(e.ColumnIndex).Name

        If colName = "sup_colUpdate" Then
            sup_editSupplierId = supplierId
            sup_txtName.Text = sup_dgv.Rows(e.RowIndex).Cells("sup_colName").Value.ToString()
            sup_txtContact.Text = sup_dgv.Rows(e.RowIndex).Cells("sup_colContact").Value.ToString()
            sup_txtAddress.Text = sup_dgv.Rows(e.RowIndex).Cells("sup_colAddress").Value.ToString()
        ElseIf colName = "sup_colDelete" Then
            SUP_DeleteSupplier(supplierId)
        End If
    End Sub

    Private Sub SUP_DeleteSupplier(supplierId As Integer)
        If MessageBox.Show("Delete this supplier?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("DELETE FROM SUPPLIER WHERE Supplier_ID=@id", conn)
                cmd.Parameters.AddWithValue("@id", supplierId)
                cmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("Supplier deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SUP_ClearForm()
            SUP_LoadGrid()
            A_LoadSuppliers()
        Catch ex As Exception
            MessageBox.Show("Unable to delete supplier. It may be used by products." & Environment.NewLine & ex.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub SUP_ClearForm()
        sup_editSupplierId = 0
        If sup_txtName IsNot Nothing Then sup_txtName.Clear()
        If sup_txtContact IsNot Nothing Then sup_txtContact.Clear()
        If sup_txtAddress IsNot Nothing Then sup_txtAddress.Clear()
    End Sub

    Public Sub ST_ShowAddStaff()
        ST_EnsureTabs()
        tcMain.SelectedTab = stAdd_tabPage
    End Sub

    Public Sub ST_ShowManageStaff()
        ST_EnsureTabs()
        tcMain.SelectedTab = stManage_tabPage
        ST_LoadStaffGrid()
    End Sub

    Private Sub ST_EnsureTabs()
        If stAdd_tabPage IsNot Nothing AndAlso stManage_tabPage IsNot Nothing Then Return

        stAdd_tabPage = tpStaffMain
        stManage_tabPage = tpViewWarrantyClaimMain

        stAdd_tabPage.Text = "Add Staff"
        stManage_tabPage.Text = "Manage Staff"

        stAdd_tabPage.BackColor = Color.White
        stManage_tabPage.BackColor = Color.White

        stAdd_tabPage.Controls.Clear()
        stManage_tabPage.Controls.Clear()

        ST_BuildAddTab()
        ST_BuildManageTab()
    End Sub

    Private Sub ST_BuildAddTab()
        Dim lblTitle As New Label() With {.Text = "Add New Staff / Technician", .Font = New Font("Segoe UI", 16, FontStyle.Bold), .Location = New Point(20, 15), .AutoSize = True}
        stAdd_tabPage.Controls.Add(lblTitle)

        Dim pnl As New Panel() With {.Location = New Point(20, 55), .Size = New Size(780, 470), .BackColor = Color.FromArgb(245, 245, 248)}
        stAdd_tabPage.Controls.Add(pnl)

        Dim y As Integer = 20
        pnl.Controls.Add(New Label() With {.Text = "Full Name", .Location = New Point(20, y), .AutoSize = True})
        st_txtFullName = New TextBox() With {.Location = New Point(20, y + 20), .Size = New Size(320, 24)}
        pnl.Controls.Add(st_txtFullName)

        pnl.Controls.Add(New Label() With {.Text = "Contact Number", .Location = New Point(360, y), .AutoSize = True})
        st_txtContact = New TextBox() With {.Location = New Point(360, y + 20), .Size = New Size(220, 24)}
        pnl.Controls.Add(st_txtContact)

        y += 70
        pnl.Controls.Add(New Label() With {.Text = "Staff Status", .Location = New Point(20, y), .AutoSize = True})
        st_cmbStaffStatus = New ComboBox() With {.Location = New Point(20, y + 20), .Size = New Size(170, 24), .DropDownStyle = ComboBoxStyle.DropDownList}
        st_cmbStaffStatus.Items.AddRange(New String() {"Active", "Inactive"})
        st_cmbStaffStatus.SelectedIndex = 0
        pnl.Controls.Add(st_cmbStaffStatus)

        pnl.Controls.Add(New Label() With {.Text = "Date Hired", .Location = New Point(210, y), .AutoSize = True})
        st_dtpDateHired = New DateTimePicker() With {.Location = New Point(210, y + 20), .Size = New Size(170, 24), .Format = DateTimePickerFormat.Custom, .CustomFormat = "yyyy-MM-dd"}
        pnl.Controls.Add(st_dtpDateHired)

        st_chkIsTechnician = New CheckBox() With {.Text = "Also assign as Technician", .Location = New Point(410, y + 22), .AutoSize = True}
        AddHandler st_chkIsTechnician.CheckedChanged, Sub() ST_ToggleTechFields()
        pnl.Controls.Add(st_chkIsTechnician)

        y += 80
        pnl.Controls.Add(New Label() With {.Text = "Specialization", .Location = New Point(20, y), .AutoSize = True})
        st_txtSpecialization = New TextBox() With {.Location = New Point(20, y + 20), .Size = New Size(320, 24)}
        pnl.Controls.Add(st_txtSpecialization)

        pnl.Controls.Add(New Label() With {.Text = "Technician Status", .Location = New Point(360, y), .AutoSize = True})
        st_cmbTechStatus = New ComboBox() With {.Location = New Point(360, y + 20), .Size = New Size(170, 24), .DropDownStyle = ComboBoxStyle.DropDownList}
        st_cmbTechStatus.Items.AddRange(New String() {"Active", "Inactive"})
        st_cmbTechStatus.SelectedIndex = 0
        pnl.Controls.Add(st_cmbTechStatus)

        y += 70
        pnl.Controls.Add(New Label() With {.Text = "Certification", .Location = New Point(20, y), .AutoSize = True})
        st_txtCertification = New TextBox() With {.Location = New Point(20, y + 20), .Size = New Size(510, 24)}
        pnl.Controls.Add(st_txtCertification)

        Dim btnSave As New Button() With {.Text = "Save Staff", .Location = New Point(20, 390), .Size = New Size(140, 36), .BackColor = Color.FromArgb(40, 167, 69), .ForeColor = Color.White}
        AddHandler btnSave.Click, AddressOf ST_SaveStaff_Click
        pnl.Controls.Add(btnSave)

        Dim btnClear As New Button() With {.Text = "Clear", .Location = New Point(170, 390), .Size = New Size(100, 36)}
        AddHandler btnClear.Click, Sub() ST_ClearAddForm()
        pnl.Controls.Add(btnClear)

        ST_ToggleTechFields()
    End Sub

    Private Sub ST_BuildManageTab()
        Dim lblTitle As New Label() With {.Text = "Manage Staff & Technician", .Font = New Font("Segoe UI", 16, FontStyle.Bold), .Location = New Point(20, 15), .AutoSize = True}
        stManage_tabPage.Controls.Add(lblTitle)

        st_txtSearch = New TextBox() With {.Location = New Point(20, 55), .Size = New Size(320, 24), .Text = "Search by name or contact..."}
        AddHandler st_txtSearch.Enter, Sub()
                                           If st_txtSearch.Text = "Search by name or contact..." Then st_txtSearch.Text = ""
                                       End Sub
        AddHandler st_txtSearch.Leave, Sub()
                                           If String.IsNullOrWhiteSpace(st_txtSearch.Text) Then st_txtSearch.Text = "Search by name or contact..."
                                       End Sub
        AddHandler st_txtSearch.TextChanged, Sub() ST_LoadStaffGrid()
        stManage_tabPage.Controls.Add(st_txtSearch)

        st_cmbFilter = New ComboBox() With {.Location = New Point(355, 55), .Size = New Size(170, 24), .DropDownStyle = ComboBoxStyle.DropDownList}
        st_cmbFilter.Items.AddRange(New String() {"All Staff", "Active Staff", "Inactive Staff", "Technicians Only"})
        st_cmbFilter.SelectedIndex = 0
        AddHandler st_cmbFilter.SelectedIndexChanged, Sub() ST_LoadStaffGrid()
        stManage_tabPage.Controls.Add(st_cmbFilter)

        Dim st_btnRefresh As New Button() With {.Text = "Refresh", .Location = New Point(540, 53), .Size = New Size(90, 28)}
        AddHandler st_btnRefresh.Click, Sub() ST_LoadStaffGrid()
        stManage_tabPage.Controls.Add(st_btnRefresh)

        st_dgv = New DataGridView() With {
            .Location = New Point(20, 90),
            .Size = New Size(500, 440),
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .ReadOnly = True,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        }
        st_dgv.Columns.Add("st_colId", "Staff ID")
        st_dgv.Columns.Add("st_colName", "Full Name")
        st_dgv.Columns.Add("st_colContact", "Contact")
        st_dgv.Columns.Add("st_colStatus", "Status")
        st_dgv.Columns.Add("st_colDate", "Date Hired")
        st_dgv.Columns.Add("st_colIsTech", "Is Tech")
        st_dgv.Columns.Add("st_colSpec", "Spec")
        st_dgv.Columns.Add("st_colTechStatus", "T. Status")
        st_dgv.Columns.Add("st_colCert", "Cert")
        st_dgv.Columns.Add(New DataGridViewButtonColumn() With {.Name = "st_colDelete", .HeaderText = "Delete", .Text = "Delete", .UseColumnTextForButtonValue = True})
        AddHandler st_dgv.CellContentClick, AddressOf ST_dgv_CellContentClick
        AddHandler st_dgv.SelectionChanged, Sub() ST_PopulateDetailPanel()
        stManage_tabPage.Controls.Add(st_dgv)

        ' Detail Panel
        st_pnlDetail = New Panel() With {.Location = New Point(530, 90), .Size = New Size(310, 440), .BackColor = Color.FromArgb(245, 245, 248), .BorderStyle = BorderStyle.FixedSingle, .Visible = False}
        stManage_tabPage.Controls.Add(st_pnlDetail)

        Dim y As Integer = 10
        st_pnlDetail.Controls.Add(New Label() With {.Text = "Full Name", .Location = New Point(10, y), .AutoSize = True})
        st_detFullName = New TextBox() With {.Location = New Point(10, y + 20), .Size = New Size(280, 24)}
        st_pnlDetail.Controls.Add(st_detFullName)

        y += 50
        st_pnlDetail.Controls.Add(New Label() With {.Text = "Contact Number", .Location = New Point(10, y), .AutoSize = True})
        st_detContact = New TextBox() With {.Location = New Point(10, y + 20), .Size = New Size(130, 24)}
        st_pnlDetail.Controls.Add(st_detContact)

        st_pnlDetail.Controls.Add(New Label() With {.Text = "Staff Status", .Location = New Point(160, y), .AutoSize = True})
        st_detStaffStatus = New ComboBox() With {.Location = New Point(160, y + 20), .Size = New Size(130, 24), .DropDownStyle = ComboBoxStyle.DropDownList}
        st_detStaffStatus.Items.AddRange(New String() {"Active", "Inactive"})
        st_pnlDetail.Controls.Add(st_detStaffStatus)

        y += 50
        st_pnlDetail.Controls.Add(New Label() With {.Text = "Date Hired", .Location = New Point(10, y), .AutoSize = True})
        st_detDateHired = New DateTimePicker() With {.Location = New Point(10, y + 20), .Size = New Size(130, 24), .Format = DateTimePickerFormat.Short}
        st_pnlDetail.Controls.Add(st_detDateHired)

        st_detIsTech = New CheckBox() With {.Text = "Is Technician", .Location = New Point(160, y + 22), .AutoSize = True}
        AddHandler st_detIsTech.CheckedChanged, Sub()
            Dim isTech = st_detIsTech.Checked
            st_detSpec.Enabled = isTech
            st_detTechStatus.Enabled = isTech
            st_detCert.Enabled = isTech
        End Sub
        st_pnlDetail.Controls.Add(st_detIsTech)

        y += 50
        st_pnlDetail.Controls.Add(New Label() With {.Text = "Specialization", .Location = New Point(10, y), .AutoSize = True})
        st_detSpec = New TextBox() With {.Location = New Point(10, y + 20), .Size = New Size(130, 24)}
        st_pnlDetail.Controls.Add(st_detSpec)

        st_pnlDetail.Controls.Add(New Label() With {.Text = "Tech Status", .Location = New Point(160, y), .AutoSize = True})
        st_detTechStatus = New ComboBox() With {.Location = New Point(160, y + 20), .Size = New Size(130, 24), .DropDownStyle = ComboBoxStyle.DropDownList}
        st_detTechStatus.Items.AddRange(New String() {"Active", "Inactive"})
        st_pnlDetail.Controls.Add(st_detTechStatus)

        y += 50
        st_pnlDetail.Controls.Add(New Label() With {.Text = "Certification", .Location = New Point(10, y), .AutoSize = True})
        st_detCert = New TextBox() With {.Location = New Point(10, y + 20), .Size = New Size(280, 24)}
        st_pnlDetail.Controls.Add(st_detCert)

        y += 60
        Dim btnUpdate As New Button() With {.Text = "Save Changes", .Location = New Point(10, y), .Size = New Size(280, 36), .BackColor = Color.FromArgb(0, 120, 215), .ForeColor = Color.White}
        AddHandler btnUpdate.Click, AddressOf ST_UpdateStaff_Click
        st_pnlDetail.Controls.Add(btnUpdate)
    End Sub

    Private Sub ST_ToggleTechFields()
        Dim isTech = st_chkIsTechnician IsNot Nothing AndAlso st_chkIsTechnician.Checked
        If st_txtSpecialization IsNot Nothing Then st_txtSpecialization.Enabled = isTech
        If st_cmbTechStatus IsNot Nothing Then st_cmbTechStatus.Enabled = isTech
        If st_txtCertification IsNot Nothing Then st_txtCertification.Enabled = isTech
    End Sub

    Private Sub ST_ClearAddForm()
        st_txtFullName.Clear()
        st_txtContact.Clear()
        st_cmbStaffStatus.SelectedIndex = 0
        st_dtpDateHired.Value = DateTime.Now.Date
        st_chkIsTechnician.Checked = False
        st_txtSpecialization.Clear()
        st_cmbTechStatus.SelectedIndex = 0
        st_txtCertification.Clear()
        ST_ToggleTechFields()
    End Sub

    Private Sub ST_SaveStaff_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(st_txtFullName.Text) Then
            MessageBox.Show("Full name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If String.IsNullOrWhiteSpace(st_txtContact.Text) Then
            MessageBox.Show("Contact number is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If st_chkIsTechnician.Checked AndAlso String.IsNullOrWhiteSpace(st_txtSpecialization.Text) Then
            MessageBox.Show("Specialization is required for technician.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            OpenConnection()
            Using tx = conn.BeginTransaction()
                Try
                    Dim staffId As Integer
                    Dim qStaff = "INSERT INTO STAFF (Full_Name, Contact_Number, Staff_Status, Date_Hired) VALUES (@n, @c, @s, @d)"
                    Using cmd As New MySqlCommand(qStaff, conn, tx)
                        cmd.Parameters.AddWithValue("@n", st_txtFullName.Text.Trim())
                        cmd.Parameters.AddWithValue("@c", st_txtContact.Text.Trim())
                        cmd.Parameters.AddWithValue("@s", st_cmbStaffStatus.SelectedItem.ToString())
                        cmd.Parameters.AddWithValue("@d", st_dtpDateHired.Value.Date)
                        cmd.ExecuteNonQuery()
                        staffId = Convert.ToInt32(cmd.LastInsertedId)
                    End Using

                    If st_chkIsTechnician.Checked Then
                        Dim qTech = "INSERT INTO TECHNICIAN (Staff_ID, Specialization, Technician_Status, Certification) VALUES (@sid, @sp, @ts, @cf)"
                        Using cmd As New MySqlCommand(qTech, conn, tx)
                            cmd.Parameters.AddWithValue("@sid", staffId)
                            cmd.Parameters.AddWithValue("@sp", st_txtSpecialization.Text.Trim())
                            cmd.Parameters.AddWithValue("@ts", st_cmbTechStatus.SelectedItem.ToString())
                            cmd.Parameters.AddWithValue("@cf", st_txtCertification.Text.Trim())
                            cmd.ExecuteNonQuery()
                        End Using
                    End If

                    tx.Commit()
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using

            MessageBox.Show("Staff saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ST_ClearAddForm()
            If st_dgv IsNot Nothing Then ST_LoadStaffGrid()
        Catch ex As Exception
            MessageBox.Show("Error saving staff: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ST_LoadStaffGrid()
        If st_dgv Is Nothing Then Return
        st_dgv.Rows.Clear()

        Try
            OpenConnection()
            Dim q As String = "SELECT S.Staff_ID, S.Full_Name, S.Contact_Number, S.Staff_Status, S.Date_Hired, " &
                              "T.Technician_ID, IFNULL(T.Specialization, '') AS Specialization, IFNULL(T.Technician_Status, '') AS Technician_Status, IFNULL(T.Certification, '') AS Certification " &
                              "FROM STAFF S LEFT JOIN TECHNICIAN T ON S.Staff_ID = T.Staff_ID WHERE 1=1 "

            Dim search As String = st_txtSearch.Text.Trim()
            If search = "Search by name or contact..." Then search = ""
            If Not String.IsNullOrWhiteSpace(search) Then
                q &= "AND (S.Full_Name LIKE @search OR S.Contact_Number LIKE @search) "
            End If

            If st_cmbFilter IsNot Nothing AndAlso st_cmbFilter.SelectedItem IsNot Nothing Then
                Select Case st_cmbFilter.SelectedItem.ToString()
                    Case "Active Staff"
                        q &= "AND S.Staff_Status = 'Active' "
                    Case "Inactive Staff"
                        q &= "AND S.Staff_Status = 'Inactive' "
                    Case "Technicians Only"
                        q &= "AND T.Technician_ID IS NOT NULL "
                End Select
            End If

            q &= "ORDER BY S.Staff_ID DESC"
            Using cmd As New MySqlCommand(q, conn)
                If Not String.IsNullOrWhiteSpace(search) Then cmd.Parameters.AddWithValue("@search", "%" & search & "%")
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        st_dgv.Rows.Add(
                            Convert.ToInt32(reader("Staff_ID")),
                            reader("Full_Name").ToString(),
                            reader("Contact_Number").ToString(),
                            reader("Staff_Status").ToString(),
                            Convert.ToDateTime(reader("Date_Hired")).ToString("yyyy-MM-dd"),
                            If(reader("Technician_ID") Is DBNull.Value, "No", "Yes"),
                            reader("Specialization").ToString(),
                            reader("Technician_Status").ToString(),
                            reader("Certification").ToString()
                        )
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading staff list: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ST_dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return

        Dim staffId As Integer = Convert.ToInt32(st_dgv.Rows(e.RowIndex).Cells("st_colId").Value)
        Dim colName As String = st_dgv.Columns(e.ColumnIndex).Name

        If colName = "st_colDelete" Then
            ST_DeleteStaff(staffId)
        End If
    End Sub

    Private Sub ST_PopulateDetailPanel()
        If st_dgv.SelectedRows.Count = 0 Then
            st_pnlDetail.Visible = False
            Return
        End If

        Dim row = st_dgv.SelectedRows(0)
        _stDetailId = Convert.ToInt32(row.Cells("st_colId").Value)
        st_detFullName.Text = row.Cells("st_colName").Value.ToString()
        st_detContact.Text = row.Cells("st_colContact").Value.ToString()
        
        Dim sStat = row.Cells("st_colStatus").Value.ToString()
        st_detStaffStatus.SelectedItem = If(st_detStaffStatus.Items.Contains(sStat), sStat, "Active")
        
        Dim dHired As DateTime
        If DateTime.TryParse(row.Cells("st_colDate").Value.ToString(), dHired) Then
            st_detDateHired.Value = dHired
        End If

        Dim isTech = (row.Cells("st_colIsTech").Value.ToString() = "Yes")
        st_detIsTech.Checked = isTech
        
        st_detSpec.Text = row.Cells("st_colSpec").Value.ToString()
        
        Dim tStat = row.Cells("st_colTechStatus").Value.ToString()
        st_detTechStatus.SelectedItem = If(st_detTechStatus.Items.Contains(tStat), tStat, "Active")
        
        st_detCert.Text = row.Cells("st_colCert").Value.ToString()
        
        st_pnlDetail.Visible = True
    End Sub

    Private Sub ST_UpdateStaff_Click(sender As Object, e As EventArgs)
        If _stDetailId <= 0 Then Return
        If String.IsNullOrWhiteSpace(st_detFullName.Text) Then
            MessageBox.Show("Full name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            OpenConnection()
            Using tx = conn.BeginTransaction()
                Try
                    Dim qStaff As String = "UPDATE STAFF SET Full_Name=@n, Contact_Number=@c, Staff_Status=@s, Date_Hired=@d WHERE Staff_ID=@id"
                    Using cmd As New MySqlCommand(qStaff, conn, tx)
                        cmd.Parameters.AddWithValue("@n", st_detFullName.Text.Trim())
                        cmd.Parameters.AddWithValue("@c", st_detContact.Text.Trim())
                        cmd.Parameters.AddWithValue("@s", st_detStaffStatus.SelectedItem.ToString())
                        cmd.Parameters.AddWithValue("@d", st_detDateHired.Value.Date)
                        cmd.Parameters.AddWithValue("@id", _stDetailId)
                        cmd.ExecuteNonQuery()
                    End Using

                    If st_detIsTech.Checked Then
                        Dim qExists = "SELECT COUNT(*) FROM TECHNICIAN WHERE Staff_ID=@id"
                        Dim exists As Integer
                        Using cmd As New MySqlCommand(qExists, conn, tx)
                            cmd.Parameters.AddWithValue("@id", _stDetailId)
                            exists = Convert.ToInt32(cmd.ExecuteScalar())
                        End Using

                        If exists > 0 Then
                            Dim qUp = "UPDATE TECHNICIAN SET Specialization=@sp, Technician_Status=@ts, Certification=@cf WHERE Staff_ID=@id"
                            Using cmd As New MySqlCommand(qUp, conn, tx)
                                cmd.Parameters.AddWithValue("@sp", st_detSpec.Text.Trim())
                                cmd.Parameters.AddWithValue("@ts", st_detTechStatus.SelectedItem.ToString())
                                cmd.Parameters.AddWithValue("@cf", st_detCert.Text.Trim())
                                cmd.Parameters.AddWithValue("@id", _stDetailId)
                                cmd.ExecuteNonQuery()
                            End Using
                        Else
                            Dim qIn = "INSERT INTO TECHNICIAN (Staff_ID, Specialization, Technician_Status, Certification) VALUES (@id, @sp, @ts, @cf)"
                            Using cmd As New MySqlCommand(qIn, conn, tx)
                                cmd.Parameters.AddWithValue("@id", _stDetailId)
                                cmd.Parameters.AddWithValue("@sp", st_detSpec.Text.Trim())
                                cmd.Parameters.AddWithValue("@ts", st_detTechStatus.SelectedItem.ToString())
                                cmd.Parameters.AddWithValue("@cf", st_detCert.Text.Trim())
                                cmd.ExecuteNonQuery()
                            End Using
                        End If
                    Else
                        Using cmd As New MySqlCommand("DELETE FROM TECHNICIAN WHERE Staff_ID=@id", conn, tx)
                            cmd.Parameters.AddWithValue("@id", _stDetailId)
                            cmd.ExecuteNonQuery()
                        End Using
                    End If

                    tx.Commit()
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using

            MessageBox.Show("Staff updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ST_LoadStaffGrid()
        Catch ex As Exception
            MessageBox.Show("Error updating staff: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ST_DeleteStaff(staffId As Integer)
        If MessageBox.Show("Delete this staff record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return
        Try
            OpenConnection()
            Using tx = conn.BeginTransaction()
                Try
                    Using cmd As New MySqlCommand("DELETE FROM TECHNICIAN WHERE Staff_ID=@id", conn, tx)
                        cmd.Parameters.AddWithValue("@id", staffId)
                        cmd.ExecuteNonQuery()
                    End Using
                    Using cmd As New MySqlCommand("DELETE FROM STAFF WHERE Staff_ID=@id", conn, tx)
                        cmd.Parameters.AddWithValue("@id", staffId)
                        cmd.ExecuteNonQuery()
                    End Using
                    tx.Commit()
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
            ST_LoadStaffGrid()
        Catch ex As Exception
            MessageBox.Show("Unable to delete staff. It may be used in service requests." & Environment.NewLine & ex.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

End Class

