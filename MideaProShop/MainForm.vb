Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient


Public Class MainForm

    Private _activeButton As Button = Nothing
    Private ReadOnly _activeColor As Color = Color.White
    Private ReadOnly _defaultColor As Color = Color.FromArgb(0, 120, 215)

    ' Content panels for each sidebar section
    Private pnlSales As Panel
    Private pnlServiceReq As Panel
    Private pnlWarranty As Panel
    Private pnlTransact As Panel
    Private pnlCheckout As Panel

    ' ── POS state ──
    Private _activeCategoryBtn As Button = Nothing
    Private _productGrid As FlowLayoutPanel
    Private _orderItemsPanel As FlowLayoutPanel
    Private _lblSubtotal As Label
    Private _lblTotal As Label

    ' Order items: key = Product_ID, value = (name, price, qty)
    Private _orderItems As New Dictionary(Of Integer, Tuple(Of String, Decimal, Integer))

    ' Products will be fetched from database
    
    Private flpRecentActivity As FlowLayoutPanel
    Private _cmbDashTimeFilter As ComboBox
    Private btnAdmin As Button
    Private pnlAdmin As Panel
    Private pnlAdminLogin As Panel
    Private pnlAdminInterface As Panel
    Private txtAdminUser As TextBox
    Private txtAdminPass As TextBox
    Private _activeAdminButton As Button = Nothing

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Open database connection
        OpenConnection()

        ' Seed dynamic Admin Credentials mechanism
        Try
            Dim createSql As String = "CREATE TABLE IF NOT EXISTS ADMIN_CREDENTIALS (id INT PRIMARY KEY, username VARCHAR(50), password VARCHAR(50)); " & 
                                      "INSERT IGNORE INTO ADMIN_CREDENTIALS (id, username, password) VALUES (1, 'admin', '123');"
            Dim cm = New MySqlCommand(createSql, conn)
            cm.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        ' Build content panels
        pnlSales = BuildSalesPOSPanel()
        pnlCheckout = BuildCheckoutPanel()
        pnlServiceReq = BuildServiceRequestDashboard()
        pnlWarranty = BuildWarrantyDashboard()
        pnlTransact = BuildTransactionsDashboard()

        ' Hide products sidebar button
        btnProducts.Visible = False

        ' Add all panels to main content area
        pnlMainContent.Controls.Add(pnlSales)
        pnlMainContent.Controls.Add(pnlCheckout)
        pnlMainContent.Controls.Add(pnlServiceReq)
        pnlMainContent.Controls.Add(pnlWarranty)
        pnlMainContent.Controls.Add(pnlTransact)

        ' Inject Recent Activity into Dashboard
        flpRecentActivity = New FlowLayoutPanel() With {
            .Dock = DockStyle.Fill,
            .AutoScroll = True,
            .Padding = New Padding(20),
            .BackColor = Color.FromArgb(245, 245, 248),
            .FlowDirection = FlowDirection.TopDown,
            .WrapContents = False
        }
        Dim pnlRecentActWrapper As New Panel() With {.Dock = DockStyle.Fill, .Padding = New Padding(10)}
        Dim lblActHdr As New Label() With {.Text = "Recent Activity", .Font = New Font("Segoe UI", 16, FontStyle.Bold), .ForeColor = Color.FromArgb(30, 30, 30), .Dock = DockStyle.Top, .Height = 40, .Padding = New Padding(10, 0, 0, 0)}
        pnlRecentActWrapper.Controls.Add(flpRecentActivity)
        flpRecentActivity.BringToFront()
        pnlRecentActWrapper.Controls.Add(lblActHdr)
        pnlDashboard.Controls.Add(pnlRecentActWrapper)
        pnlRecentActWrapper.BringToFront()

        ' Dashboard Time Filter
        _cmbDashTimeFilter = New ComboBox() With {
            .DropDownStyle = ComboBoxStyle.DropDownList,
            .Font = New Font("Segoe UI", 11),
            .Size = New Size(150, 30),
            .Location = New Point(pnlDashboard.Width - 180, 20),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
            .Cursor = Cursors.Hand
        }
        _cmbDashTimeFilter.Items.AddRange({"Today", "This Week", "This Month", "This Year", "All Time"})
        _cmbDashTimeFilter.SelectedIndex = 4 ' All Time
        AddHandler _cmbDashTimeFilter.SelectedIndexChanged, Sub() LoadDashboardData()
        pnlDashboard.Controls.Add(_cmbDashTimeFilter)
        _cmbDashTimeFilter.BringToFront()

        ' Make cards clickable
        Dim SetupCardClick = Sub(card As Panel, handler As EventHandler)
                                 card.Cursor = Cursors.Hand
                                 AddHandler card.Click, handler
                                 For Each child As Control In card.Controls
                                     child.Cursor = Cursors.Hand
                                     AddHandler child.Click, handler
                                 Next
                             End Sub
        SetupCardClick(pnlCard1, AddressOf btnTransactions_Click)
        ' SetupCardClick(pnlCard2, AddressOf btnProducts_Click) ' Retired
        SetupCardClick(pnlCard3, AddressOf btnServiceRequests_Click)
        SetupCardClick(pnlCard4, AddressOf btnWarrantyClaims_Click)

        AddHandler pnlDashboard.VisibleChanged, Sub(s, ev)
                                                    If pnlDashboard.Visible Then LoadDashboardData()
                                                End Sub

        ' Show Dashboard by default
        SetActiveButton(btnDashboard)
        ShowPanel(pnlDashboard)
        LoadDashboardData()

        ' Inject Admin Button natively
        btnAdmin = New Button() With {
            .Dock = DockStyle.Bottom,
            .Height = 50,
            .FlatStyle = FlatStyle.Flat,
            .Text = "   Admin",
            .TextAlign = ContentAlignment.MiddleLeft,
            .Font = btnDashboard.Font,
            .ForeColor = Color.White,
            .Cursor = Cursors.Hand,
            .Padding = New Padding(15, 0, 0, 0)
        }
        btnAdmin.FlatAppearance.BorderSize = 0
        btnAdmin.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 195)
        btnAdmin.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 90, 180)
        pnlSideBar.Controls.Add(btnAdmin)
        
        pnlAdmin = BuildAdminContainer()
        pnlMainContent.Controls.Add(pnlAdmin)
        
        AddHandler btnAdmin.Click, AddressOf btnAdmin_Click
    End Sub

    ' ═══════════════════════════════════════════════════
    '  POS-STYLE SALES PANEL
    ' ═══════════════════════════════════════════════════

    Private Function BuildSalesPOSPanel() As Panel
        Dim pnl As New Panel()
        pnl.Dock = DockStyle.Fill
        pnl.BackColor = Color.FromArgb(245, 245, 248)
        pnl.Visible = False

        ' ── RIGHT: Order Summary (add first so it docks right) ──
        Dim pnlOrder As New Panel()
        pnlOrder.Dock = DockStyle.Right
        pnlOrder.Width = 300
        pnlOrder.BackColor = Color.White
        pnlOrder.Padding = New Padding(0)

        ' Order header
        Dim pnlOrderHeader As New Panel()
        pnlOrderHeader.Dock = DockStyle.Top
        pnlOrderHeader.Height = 60
        pnlOrderHeader.BackColor = Color.White
        pnlOrderHeader.Padding = New Padding(20, 15, 20, 5)

        Dim lblOrderTitle As New Label()
        lblOrderTitle.Text = "Current Order"
        lblOrderTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblOrderTitle.ForeColor = Color.FromArgb(30, 30, 30)
        lblOrderTitle.Dock = DockStyle.Fill
        pnlOrderHeader.Controls.Add(lblOrderTitle)
        pnlOrder.Controls.Add(pnlOrderHeader)

        ' Separator line
        Dim sepTop As New Panel()
        sepTop.Dock = DockStyle.Top
        sepTop.Height = 1
        sepTop.BackColor = Color.FromArgb(230, 230, 230)
        pnlOrder.Controls.Add(sepTop)
        sepTop.BringToFront()

        ' Order items area (scrollable)
        _orderItemsPanel = New FlowLayoutPanel()
        _orderItemsPanel.Dock = DockStyle.Fill
        _orderItemsPanel.AutoScroll = True
        _orderItemsPanel.FlowDirection = FlowDirection.TopDown
        _orderItemsPanel.WrapContents = False
        _orderItemsPanel.BackColor = Color.White
        _orderItemsPanel.Padding = New Padding(15, 10, 15, 10)
        pnlOrder.Controls.Add(_orderItemsPanel)
        _orderItemsPanel.BringToFront()

        ' Bottom totals panel
        Dim pnlTotals As New Panel()
        pnlTotals.Dock = DockStyle.Bottom
        pnlTotals.Height = 160
        pnlTotals.BackColor = Color.White
        pnlTotals.Padding = New Padding(20, 10, 20, 15)

        ' Separator above totals
        Dim sepBottom As New Panel()
        sepBottom.Dock = DockStyle.Top
        sepBottom.Height = 1
        sepBottom.BackColor = Color.FromArgb(230, 230, 230)
        pnlTotals.Controls.Add(sepBottom)

        ' Totals labels
        Dim yTotals As Integer = 15
        _lblSubtotal = CreateTotalRow(pnlTotals, "Subtotal", "₱0.00", yTotals, False) : yTotals += 35

        ' Total line (bold, larger)
        Dim lblTotalLabel As New Label()
        lblTotalLabel.Text = "Total"
        lblTotalLabel.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTotalLabel.ForeColor = Color.FromArgb(30, 30, 30)
        lblTotalLabel.Location = New Point(10, yTotals)
        lblTotalLabel.AutoSize = True
        pnlTotals.Controls.Add(lblTotalLabel)

        _lblTotal = New Label()
        _lblTotal.Text = "₱0.00"
        _lblTotal.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        _lblTotal.ForeColor = Color.FromArgb(30, 30, 30)
        _lblTotal.TextAlign = ContentAlignment.MiddleRight
        _lblTotal.Size = New Size(120, 30)
        _lblTotal.Location = New Point(pnlTotals.Width - 150, yTotals)
        _lblTotal.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        pnlTotals.Controls.Add(_lblTotal)
        yTotals += 40

        ' Continue button
        Dim btnContinue As New Button()
        btnContinue.Text = "Continue"
        btnContinue.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        btnContinue.ForeColor = Color.White
        btnContinue.BackColor = Color.FromArgb(0, 120, 215)
        btnContinue.FlatStyle = FlatStyle.Flat
        btnContinue.FlatAppearance.BorderSize = 0
        btnContinue.Size = New Size(pnlTotals.Width - 40, 42)
        btnContinue.Location = New Point(10, yTotals)
        btnContinue.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
        btnContinue.Cursor = Cursors.Hand
        AddHandler btnContinue.Click, AddressOf CheckoutContinue_Click
        pnlTotals.Controls.Add(btnContinue)

        pnlOrder.Controls.Add(pnlTotals)

        pnl.Controls.Add(pnlOrder)

        ' ── Vertical separator ──
        Dim vSep As New Panel()
        vSep.Dock = DockStyle.Right
        vSep.Width = 1
        vSep.BackColor = Color.FromArgb(225, 225, 230)
        pnl.Controls.Add(vSep)

        ' ── LEFT: Title + Filters + Product Grid ──
        Dim pnlLeft As New Panel()
        pnlLeft.Dock = DockStyle.Fill
        pnlLeft.BackColor = Color.FromArgb(245, 245, 248)
        pnlLeft.Padding = New Padding(0)

        ' Title bar with search
        Dim pnlTitleBar As New Panel()
        pnlTitleBar.Dock = DockStyle.Top
        pnlTitleBar.Height = 60
        pnlTitleBar.BackColor = Color.FromArgb(245, 245, 248)
        pnlTitleBar.Padding = New Padding(25, 15, 25, 5)

        Dim lblSalesTitle As New Label()
        lblSalesTitle.Text = "Sales"
        lblSalesTitle.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        lblSalesTitle.ForeColor = Color.FromArgb(30, 30, 30)
        lblSalesTitle.AutoSize = True
        lblSalesTitle.Location = New Point(25, 15)
        pnlTitleBar.Controls.Add(lblSalesTitle)

        ' Search box
        Dim txtSearch As New TextBox()
        txtSearch.Font = New Font("Segoe UI", 11)
        txtSearch.Size = New Size(200, 30)
        txtSearch.Location = New Point(pnlTitleBar.Width - 240, 15)
        txtSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.Text = ""
        txtSearch.ForeColor = Color.Gray
        pnlTitleBar.Controls.Add(txtSearch)

        ' Search placeholder
        Dim searchPlaceholder As String = "🔍  Search products..."
        txtSearch.Text = searchPlaceholder
        AddHandler txtSearch.GotFocus, Sub(s, ev)
                                           If txtSearch.Text = searchPlaceholder Then
                                               txtSearch.Text = ""
                                               txtSearch.ForeColor = Color.Black
                                           End If
                                       End Sub
        AddHandler txtSearch.LostFocus, Sub(s, ev)
                                            If String.IsNullOrWhiteSpace(txtSearch.Text) Then
                                                txtSearch.Text = searchPlaceholder
                                                txtSearch.ForeColor = Color.Gray
                                            End If
                                        End Sub

        pnlLeft.Controls.Add(pnlTitleBar)

        ' ── Category filter buttons (scrollable horizontally) ──
        Dim pnlFilters As New FlowLayoutPanel()
        pnlFilters.Dock = DockStyle.Top
        pnlFilters.Height = 55
        pnlFilters.BackColor = Color.FromArgb(245, 245, 248)
        pnlFilters.Padding = New Padding(22, 5, 10, 5)
        pnlFilters.WrapContents = False
        pnlFilters.AutoScroll = True

        Dim categories() As String = {"Air Conditioners", "Washing Machines", "Televisions", "Refrigerators"}
        For Each cat As String In categories
            Dim btn As New Button()
            btn.Text = cat
            btn.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
            btn.FlatStyle = FlatStyle.Flat
            btn.Cursor = Cursors.Hand
            btn.AutoSize = True
            btn.Padding = New Padding(12, 2, 12, 2)
            btn.Margin = New Padding(3, 3, 6, 3)
            btn.Height = 34
            ' Default: outlined style
            btn.BackColor = Color.White
            btn.ForeColor = Color.FromArgb(60, 60, 60)
            btn.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200)
            btn.FlatAppearance.BorderSize = 1
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 240)
            btn.Tag = cat
            AddHandler btn.Click, AddressOf CategoryFilter_Click
            pnlFilters.Controls.Add(btn)
        Next

        pnlLeft.Controls.Add(pnlFilters)
        pnlFilters.BringToFront()

        ' ── Product card grid ──
        _productGrid = New FlowLayoutPanel()
        _productGrid.Dock = DockStyle.Fill
        _productGrid.AutoScroll = True
        _productGrid.BackColor = Color.FromArgb(245, 245, 248)
        _productGrid.Padding = New Padding(20, 10, 20, 10)
        _productGrid.WrapContents = True

        ' Resize handler: dynamically adjust card widths to fill grid evenly
        AddHandler _productGrid.Resize, Sub(s, ev)
                                            ResizeProductCards()
                                        End Sub

        pnlLeft.Controls.Add(_productGrid)
        _productGrid.BringToFront()

        ' Resize handler for order items panel: refresh row widths
        AddHandler _orderItemsPanel.Resize, Sub(s, ev)
                                                If _orderItems.Count > 0 Then
                                                    RefreshOrderPanel()
                                                End If
                                            End Sub

        pnl.Controls.Add(pnlLeft)
        pnlLeft.BringToFront() ' Ensure left panel isn't covered by right dock

        ' Select first category by default
        If pnlFilters.Controls.Count > 0 Then
            Dim firstBtn = DirectCast(pnlFilters.Controls(0), Button)
            SetActiveCategoryButton(firstBtn)
            LoadProducts(firstBtn.Tag.ToString())
        End If

        Return pnl
    End Function

    ' ── Category filter click handler ──
    Private Sub CategoryFilter_Click(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        SetActiveCategoryButton(btn)
        LoadProducts(btn.Tag.ToString())
    End Sub

    Private Sub SetActiveCategoryButton(btn As Button)
        ' Reset previous
        If _activeCategoryBtn IsNot Nothing Then
            _activeCategoryBtn.BackColor = Color.White
            _activeCategoryBtn.ForeColor = Color.FromArgb(60, 60, 60)
            _activeCategoryBtn.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200)
            _activeCategoryBtn.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
        End If
        ' Set active
        btn.BackColor = Color.FromArgb(30, 30, 30)
        btn.ForeColor = Color.White
        btn.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30)
        btn.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        _activeCategoryBtn = btn
    End Sub

    ' ── Load product cards into the grid ──
    Private Sub LoadProducts(category As String)
        _productGrid.SuspendLayout()
        _productGrid.Controls.Clear()

        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()
            Dim query As String = "SELECT Product_ID, Product_Name, Unit_Price, Stock_Quantity FROM PRODUCT WHERE Product_Category = @cat"
            Using sqlCmd As New MySqlCommand(query, conn)
                sqlCmd.Parameters.AddWithValue("@cat", category)
                Using reader As MySqlDataReader = sqlCmd.ExecuteReader()
                    While reader.Read()
                        Dim id = reader.GetInt32("Product_ID")
                        Dim name = reader.GetString("Product_Name")
                        Dim price = reader.GetDecimal("Unit_Price")
                        Dim stock = reader.GetInt32("Stock_Quantity")
                        Dim card = CreateProductCard(id, name, price, stock)
                        _productGrid.Controls.Add(card)
                    End While
                End Using
            End Using
        Catch ex As Exception
            ' Silently handle if table does not exist or DB error
        End Try

        _productGrid.ResumeLayout(True)
        ResizeProductCards()
    End Sub

    ''' <summary>
    ''' Recalculates product card widths to fill the grid evenly.
    ''' Determines how many columns fit and distributes remaining space.
    ''' </summary>
    Private Sub ResizeProductCards()
        If _productGrid Is Nothing OrElse _productGrid.Controls.Count = 0 Then Return

        Dim gridWidth As Integer = _productGrid.ClientSize.Width - _productGrid.Padding.Horizontal
        Dim cardMargin As Integer = 8 ' matches card.Margin
        Dim minCardWidth As Integer = 155
        Dim totalCardSlot As Integer = minCardWidth + (cardMargin * 2)

        ' How many columns fit?
        Dim cols As Integer = Math.Max(1, gridWidth \ totalCardSlot)
        Dim cardWidth As Integer = (gridWidth \ cols) - (cardMargin * 2)
        ' Clamp to a reasonable max
        If cardWidth > 280 Then cardWidth = 280

        _productGrid.SuspendLayout()
        For Each ctrl As Control In _productGrid.Controls
            If TypeOf ctrl Is Panel Then
                Dim card = DirectCast(ctrl, Panel)
                card.Width = cardWidth

                ' Reposition the + button to the new right edge
                For Each child As Control In card.Controls
                    If TypeOf child Is Button AndAlso DirectCast(child, Button).Text = "+" Then
                        child.Location = New Point(card.Width - 42, child.Location.Y)
                    End If
                    ' Adjust product name label width
                    If TypeOf child Is Label Then
                        Dim lbl = DirectCast(child, Label)
                        If lbl.MaximumSize.Width > 0 Then
                            Dim nameWidth = cardWidth - 24
                            lbl.Size = New Size(nameWidth, lbl.Size.Height)
                            lbl.MaximumSize = New Size(nameWidth, lbl.MaximumSize.Height)
                        End If
                    End If
                Next
            End If
        Next
        _productGrid.ResumeLayout(True)
    End Sub

    Private Function CreateProductCard(id As Integer, name As String, price As Decimal, stock As Integer) As Panel
        Dim card As New Panel()
        card.Size = New Size(168, 190)
        card.Margin = New Padding(8)
        card.BackColor = Color.White
        card.Cursor = Cursors.Hand
        card.Tag = name

        ' Subtle shadow effect via paint
        AddHandler card.Paint, Sub(s, ev)
                                   Dim g = ev.Graphics
                                   Using pen As New Pen(Color.FromArgb(30, 0, 0, 0), 1)
                                       g.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1)
                                   End Using
                               End Sub

        ' Product icon area (colored placeholder)
        Dim pnlIcon As New Panel()
        pnlIcon.Dock = DockStyle.Top
        pnlIcon.Height = 95
        pnlIcon.BackColor = Color.FromArgb(240, 245, 255)
        pnlIcon.Padding = New Padding(10)

        ' Icon label (emoji placeholder)
        Dim lblIcon As New Label()
        Dim iconText As String = "🏷️"
        If name.ToLower().Contains("cool") OrElse name.ToLower().Contains("inverter") OrElse name.ToLower().Contains("hp") Then
            iconText = "❄️"
            pnlIcon.BackColor = Color.FromArgb(230, 245, 255)
        ElseIf name.ToLower().Contains("load") OrElse name.ToLower().Contains("tub") Then
            iconText = "🌀"
            pnlIcon.BackColor = Color.FromArgb(235, 255, 240)
        ElseIf name.ToLower().Contains("tv") Then
            iconText = "📺"
            pnlIcon.BackColor = Color.FromArgb(255, 245, 230)
        ElseIf name.ToLower().Contains("door") OrElse name.ToLower().Contains("side") Then
            iconText = "🧊"
            pnlIcon.BackColor = Color.FromArgb(240, 240, 255)
        End If
        lblIcon.Text = iconText
        lblIcon.Font = New Font("Segoe UI Emoji", 28)
        lblIcon.Dock = DockStyle.Fill
        lblIcon.TextAlign = ContentAlignment.MiddleCenter
        pnlIcon.Controls.Add(lblIcon)
        card.Controls.Add(pnlIcon)

        ' Product name
        Dim lblName As New Label()
        lblName.Text = name
        lblName.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblName.ForeColor = Color.FromArgb(50, 50, 50)
        lblName.Location = New Point(12, 102)
        lblName.Size = New Size(145, 36)
        lblName.MaximumSize = New Size(145, 36)
        card.Controls.Add(lblName)

        ' Price row
        Dim lblPrice As New Label()
        lblPrice.Text = "₱" & price.ToString("N2")
        lblPrice.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblPrice.ForeColor = Color.FromArgb(0, 120, 215)
        lblPrice.Location = New Point(12, 145)
        lblPrice.AutoSize = True
        card.Controls.Add(lblPrice)

        ' Stock row
        Dim lblStock As New Label()
        lblStock.Text = "Stock: " & stock
        lblStock.Font = New Font("Segoe UI", 8, FontStyle.Regular)
        lblStock.ForeColor = If(stock <= 5, Color.Crimson, Color.FromArgb(100, 100, 100))
        lblStock.Location = New Point(12, 168)
        lblStock.AutoSize = True
        card.Controls.Add(lblStock)

        ' Add button
        Dim btnAdd As New Button()
        btnAdd.Text = "+"
        btnAdd.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        btnAdd.Size = New Size(32, 32)
        btnAdd.Location = New Point(card.Width - 42, 148)
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.BackColor = If(stock <= 0, Color.LightGray, Color.FromArgb(0, 120, 215))
        btnAdd.ForeColor = Color.White
        btnAdd.FlatAppearance.BorderSize = 0
        btnAdd.Cursor = If(stock <= 0, Cursors.Default, Cursors.Hand)
        btnAdd.Enabled = (stock > 0)
        btnAdd.Tag = New Tuple(Of Integer, String, Decimal, Integer)(id, name, price, stock)
        AddHandler btnAdd.Click, AddressOf AddToOrder_Click
        card.Controls.Add(btnAdd)

        Return card
    End Function

    ' ── Add-to-order handler ──
    Private Sub AddToOrder_Click(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        Dim info = DirectCast(btn.Tag, Tuple(Of Integer, String, Decimal, Integer))
        Dim prodId = info.Item1
        Dim prodName = info.Item2
        Dim prodPrice = info.Item3
        Dim prodStock = info.Item4

        If _orderItems.ContainsKey(prodId) Then
            Dim existing = _orderItems(prodId)
            If existing.Item3 >= prodStock Then
                MessageBox.Show("Cannot add more. Exceeds available stock of " & prodStock & ".", "Low Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            _orderItems(prodId) = Tuple.Create(existing.Item1, prodPrice, existing.Item3 + 1)
        Else
            If prodStock <= 0 Then
                MessageBox.Show("Product is out of stock.", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            _orderItems(prodId) = Tuple.Create(prodName, prodPrice, 1)
        End If

        RefreshOrderPanel()
    End Sub

    Private Sub RefreshOrderPanel()
        _orderItemsPanel.SuspendLayout()
        _orderItemsPanel.Controls.Clear()

        Dim subtotal As Decimal = 0

        For Each kvp In _orderItems
            Dim prodId = kvp.Key
            Dim prodName = kvp.Value.Item1
            Dim prodPrice = kvp.Value.Item2
            Dim qty = kvp.Value.Item3
            Dim lineTotal = prodPrice * qty
            subtotal += lineTotal

            ' Item row panel
            Dim rowWidth As Integer = Math.Max(100, _orderItemsPanel.ClientSize.Width - _orderItemsPanel.Padding.Horizontal - 2)
            Dim rowPanel As New Panel()
            rowPanel.Size = New Size(rowWidth, 55)
            rowPanel.Margin = New Padding(0, 2, 0, 2)
            rowPanel.BackColor = Color.White

            ' Product name (anchored left-right, leaves room for buttons)
            Dim lblItemName As New Label()
            lblItemName.Text = prodName
            lblItemName.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            lblItemName.ForeColor = Color.FromArgb(50, 50, 50)
            lblItemName.Location = New Point(0, 5)
            lblItemName.Size = New Size(rowWidth - 75, 20)
            lblItemName.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
            rowPanel.Controls.Add(lblItemName)

            ' Price
            Dim lblItemPrice As New Label()
            lblItemPrice.Text = "₱" & prodPrice.ToString("N2")
            lblItemPrice.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            lblItemPrice.ForeColor = Color.FromArgb(80, 80, 80)
            lblItemPrice.Location = New Point(0, 28)
            lblItemPrice.AutoSize = True
            rowPanel.Controls.Add(lblItemPrice)

            ' Quantity badge (anchored to right)
            Dim lblQty As New Label()
            lblQty.Text = qty.ToString()
            lblQty.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            lblQty.ForeColor = Color.White
            lblQty.BackColor = Color.FromArgb(0, 120, 215)
            lblQty.Size = New Size(26, 26)
            lblQty.TextAlign = ContentAlignment.MiddleCenter
            lblQty.Location = New Point(rowWidth - 36, 14)
            lblQty.Anchor = AnchorStyles.Top Or AnchorStyles.Right
            rowPanel.Controls.Add(lblQty)

            ' Remove button (anchored to right)
            Dim btnRemove As New Button()
            btnRemove.Text = "✕"
            btnRemove.Font = New Font("Segoe UI", 8)
            btnRemove.Size = New Size(22, 22)
            btnRemove.Location = New Point(rowWidth - 64, 16)
            btnRemove.Anchor = AnchorStyles.Top Or AnchorStyles.Right
            btnRemove.FlatStyle = FlatStyle.Flat
            btnRemove.BackColor = Color.FromArgb(255, 230, 230)
            btnRemove.ForeColor = Color.FromArgb(200, 50, 50)
            btnRemove.FlatAppearance.BorderSize = 0
            btnRemove.Cursor = Cursors.Hand
            btnRemove.Tag = prodId
            AddHandler btnRemove.Click, Sub(s, ev)
                                            Dim key = CInt(DirectCast(s, Button).Tag)
                                            If _orderItems.ContainsKey(key) Then
                                                Dim cur = _orderItems(key)
                                                If cur.Item3 > 1 Then
                                                    _orderItems(key) = Tuple.Create(cur.Item1, cur.Item2, cur.Item3 - 1)
                                                Else
                                                    _orderItems.Remove(key)
                                                End If
                                            End If
                                            RefreshOrderPanel()
                                        End Sub
            rowPanel.Controls.Add(btnRemove)

            ' Bottom separator (anchored to stretch)
            Dim rowSep As New Panel()
            rowSep.Size = New Size(rowWidth, 1)
            rowSep.Location = New Point(0, rowPanel.Height - 1)
            rowSep.BackColor = Color.FromArgb(240, 240, 240)
            rowSep.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
            rowPanel.Controls.Add(rowSep)

            _orderItemsPanel.Controls.Add(rowPanel)
        Next

        _orderItemsPanel.ResumeLayout(True)

        ' Update totals
        _lblSubtotal.Text = "₱" & subtotal.ToString("N2")
        _lblTotal.Text = "₱" & subtotal.ToString("N2")
    End Sub

    ''' <summary>
    ''' Helper: creates a label row in the totals area (e.g., "Subtotal    ₱0.00")
    ''' Returns the value label so we can update it later.
    ''' </summary>
    Private Function CreateTotalRow(parent As Panel, labelText As String, valueText As String, yPos As Integer, isBold As Boolean) As Label
        Dim lbl As New Label()
        lbl.Text = labelText
        lbl.Font = New Font("Segoe UI", 10, If(isBold, FontStyle.Bold, FontStyle.Regular))
        lbl.ForeColor = Color.FromArgb(100, 100, 100)
        lbl.Location = New Point(10, yPos)
        lbl.AutoSize = True
        parent.Controls.Add(lbl)

        Dim lblVal As New Label()
        lblVal.Text = valueText
        lblVal.Font = New Font("Segoe UI", 10, If(isBold, FontStyle.Bold, FontStyle.Regular))
        lblVal.ForeColor = Color.FromArgb(60, 60, 60)
        lblVal.TextAlign = ContentAlignment.MiddleRight
        lblVal.Size = New Size(120, 24)
        lblVal.Location = New Point(parent.Width - 150, yPos)
        lblVal.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        parent.Controls.Add(lblVal)

        Return lblVal
    End Function

    ' ═══════════════════════════════════════════════════
    '  GENERIC FORM PANEL (for other sections)
    ' ═══════════════════════════════════════════════════

    Private Function BuildFormPanel(title As String, fields() As String) As Panel
        Dim pnl As New Panel()
        pnl.Dock = DockStyle.Fill
        pnl.BackColor = Color.FromArgb(240, 240, 245)
        pnl.Visible = False
        pnl.Padding = New Padding(0)

        ' Title label
        Dim lblTitle As New Label()
        lblTitle.Text = title
        lblTitle.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(30, 30, 30)
        lblTitle.Dock = DockStyle.Top
        lblTitle.Padding = New Padding(30, 20, 0, 10)
        lblTitle.Height = 70
        pnl.Controls.Add(lblTitle)

        ' Form fields container
        Dim formContainer As New Panel()
        formContainer.Dock = DockStyle.Top
        formContainer.Padding = New Padding(30, 10, 30, 10)
        formContainer.AutoSize = True
        formContainer.BackColor = Color.White
        formContainer.Location = New Point(30, 80)

        Dim yPos As Integer = 15
        For Each fieldName As String In fields
            Dim lbl As New Label()
            lbl.Text = fieldName
            lbl.Font = New Font("Segoe UI", 10, FontStyle.Regular)
            lbl.ForeColor = Color.FromArgb(80, 80, 80)
            lbl.Location = New Point(15, yPos)
            lbl.AutoSize = True
            formContainer.Controls.Add(lbl)

            Dim txt As New TextBox()
            txt.Font = New Font("Segoe UI", 11, FontStyle.Regular)
            txt.Location = New Point(15, yPos + 25)
            txt.Size = New Size(350, 30)
            txt.BorderStyle = BorderStyle.FixedSingle
            formContainer.Controls.Add(txt)

            yPos += 65
        Next

        ' Save button
        Dim btnSave As New Button()
        btnSave.Text = "Save"
        btnSave.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        btnSave.ForeColor = Color.White
        btnSave.BackColor = Color.FromArgb(0, 120, 215)
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.Size = New Size(120, 40)
        btnSave.Location = New Point(15, yPos + 10)
        btnSave.Cursor = Cursors.Hand
        formContainer.Controls.Add(btnSave)

        ' Clear button
        Dim btnClear As New Button()
        btnClear.Text = "Clear"
        btnClear.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        btnClear.ForeColor = Color.FromArgb(80, 80, 80)
        btnClear.BackColor = Color.White
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200)
        btnClear.FlatAppearance.BorderSize = 1
        btnClear.Size = New Size(120, 40)
        btnClear.Location = New Point(145, yPos + 10)
        btnClear.Cursor = Cursors.Hand
        formContainer.Controls.Add(btnClear)

        pnl.Controls.Add(formContainer)
        formContainer.BringToFront()

        Return pnl
    End Function

    ' ═══════════════════════════════════════════════════
    '  SERVICE REQUEST PANEL (DASHBOARD & FORM)
    ' ═══════════════════════════════════════════════════
    Private flpServiceRequests As FlowLayoutPanel
    Private _cmbStatusFilter As ComboBox
    Private pnlSRDashboard As Panel
    Private pnlSRFormWrapper As Panel

    ' Form specific
    Private _optSRNewCust As RadioButton
    Private _optSRExistCust As RadioButton
    Private _pnlSRNewCust As Panel
    Private _pnlSRExistCust As Panel
    Private _txtSRNewCustName As TextBox
    Private _txtSRNewCustContact As TextBox
    Private _txtSRNewCustAddress As TextBox
    Private _cmbSRExistCust As ComboBox
    Private _cmbSRService As ComboBox
    Private _cmbSRStaff As ComboBox
    Private _cmbSRTechnician As ComboBox
    Private _cmbSRWarranty As ComboBox
    Private _dtpSRRequest As DateTimePicker
    Private _dtpSRScheduled As DateTimePicker
    Private _dtpSRCompleted As DateTimePicker
    Private _txtSRAddress As TextBox
    Private _cmbSRStatus As ComboBox

    Private Function BuildServiceRequestDashboard() As Panel
        Dim pnlMain As New Panel() With {.Dock = DockStyle.Fill, .BackColor = Color.FromArgb(245, 245, 248), .Visible = False}

        ' --- DASHBOARD ---
        pnlSRDashboard = New Panel() With {.Dock = DockStyle.Fill}
        Dim pnlTop As New Panel() With {.Dock = DockStyle.Top, .Height = 80, .Padding = New Padding(20)}
        Dim lblTitle As New Label() With {.Text = "Service Requests Dashboard", .Font = New Font("Segoe UI", 20, FontStyle.Bold), .ForeColor = Color.FromArgb(30,30,30), .AutoSize = True, .Location = New Point(20, 20)}
        pnlTop.Controls.Add(lblTitle)
        
        Dim btnNewReq As New Button() With {.Text = "+ New Request", .Font = New Font("Segoe UI", 11, FontStyle.Bold), .BackColor = Color.FromArgb(0, 120, 215), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Size = New Size(140, 40), .Location = New Point(pnlTop.Width - 180, 20), .Anchor = AnchorStyles.Top Or AnchorStyles.Right, .Cursor = Cursors.Hand}
        btnNewReq.FlatAppearance.BorderSize = 0
        AddHandler btnNewReq.Click, Sub() 
                                        ClearServiceRequestForm()
                                        LoadDataForSRForm()
                                        pnlSRDashboard.Visible = False
                                        pnlSRFormWrapper.Visible = True
                                    End Sub
        pnlTop.Controls.Add(btnNewReq)

        Dim lblFilter As New Label() With {.Text = "Filter Status:", .Font = New Font("Segoe UI", 10), .AutoSize = True, .Location = New Point(450, 30)}
        pnlTop.Controls.Add(lblFilter)
        _cmbStatusFilter = New ComboBox() With {.DropDownStyle = ComboBoxStyle.DropDownList, .Font = New Font("Segoe UI", 10), .Location = New Point(550, 28), .Size = New Size(150, 25)}
        _cmbStatusFilter.Items.AddRange(New String() {"All", "Pending", "Scheduled", "In Progress", "Completed", "Cancelled"})
        _cmbStatusFilter.SelectedIndex = 0
        AddHandler _cmbStatusFilter.SelectedIndexChanged, Sub() LoadServiceRequestsCards()
        pnlTop.Controls.Add(_cmbStatusFilter)

        pnlSRDashboard.Controls.Add(pnlTop)

        flpServiceRequests = New FlowLayoutPanel() With {
            .Dock = DockStyle.Fill, 
            .AutoScroll = True, 
            .Padding = New Padding(20),
            .BackColor = Color.FromArgb(245, 245, 248)
        }
        pnlSRDashboard.Controls.Add(flpServiceRequests)
        flpServiceRequests.BringToFront()

        pnlMain.Controls.Add(pnlSRDashboard)

        ' --- FORM ---
        pnlSRFormWrapper = New Panel() With {.Dock = DockStyle.Fill, .Visible = False, .AutoScroll = True, .Padding = New Padding(30)}
        
        Dim lblFormTitle As New Label() With {.Text = "Create New Service Request", .Font = New Font("Segoe UI", 20, FontStyle.Bold), .ForeColor = Color.FromArgb(30, 30, 30), .Dock = DockStyle.Top, .Height = 50}
        pnlSRFormWrapper.Controls.Add(lblFormTitle)

        Dim formContainer As New Panel() With {.Dock = DockStyle.Top, .AutoSize = True, .BackColor = Color.White, .Padding = New Padding(20)}
        Dim yPos As Integer = 15
        
        Dim BuildHeader = Sub(txt As String)
            Dim lblH As New Label() With {.Text = txt, .Font = New Font("Segoe UI", 12, FontStyle.Bold), .Location = New Point(15, yPos), .AutoSize = True}
            formContainer.Controls.Add(lblH)
            yPos += 30
        End Sub

        BuildHeader("Customer Selection")
        _optSRNewCust = New RadioButton() With {.Text = "New Customer", .Font = New Font("Segoe UI", 10, FontStyle.Bold), .Location = New Point(15, yPos), .AutoSize = True, .Checked = True}
        _optSRExistCust = New RadioButton() With {.Text = "Existing Customer", .Font = New Font("Segoe UI", 10, FontStyle.Bold), .Location = New Point(160, yPos), .AutoSize = True}
        formContainer.Controls.Add(_optSRNewCust)
        formContainer.Controls.Add(_optSRExistCust)
        yPos += 35

        _pnlSRNewCust = New Panel() With {.Location = New Point(0, yPos), .Size = New Size(600, 190), .BackColor = Color.White}
        Dim ny As Integer = 0
        Dim lblN1 As New Label() With {.Text = "Full Name", .Font = New Font("Segoe UI", 10), .Location = New Point(15, ny), .AutoSize = True}
        _pnlSRNewCust.Controls.Add(lblN1)
        _txtSRNewCustName = New TextBox() With {.Font = New Font("Segoe UI", 11), .Location = New Point(15, ny+25), .Size = New Size(350, 30)}
        _pnlSRNewCust.Controls.Add(_txtSRNewCustName)
        ny += 60
        Dim lblN2 As New Label() With {.Text = "Contact Number", .Font = New Font("Segoe UI", 10), .Location = New Point(15, ny), .AutoSize = True}
        _pnlSRNewCust.Controls.Add(lblN2)
        _txtSRNewCustContact = New TextBox() With {.Font = New Font("Segoe UI", 11), .Location = New Point(15, ny+25), .Size = New Size(350, 30)}
        _pnlSRNewCust.Controls.Add(_txtSRNewCustContact)
        ny += 60
        Dim lblN3 As New Label() With {.Text = "Home Address", .Font = New Font("Segoe UI", 10), .Location = New Point(15, ny), .AutoSize = True}
        _pnlSRNewCust.Controls.Add(lblN3)
        _txtSRNewCustAddress = New TextBox() With {.Font = New Font("Segoe UI", 11), .Location = New Point(15, ny+25), .Size = New Size(350, 30)}
        _pnlSRNewCust.Controls.Add(_txtSRNewCustAddress)
        formContainer.Controls.Add(_pnlSRNewCust)

        _pnlSRExistCust = New Panel() With {.Location = New Point(0, yPos), .Size = New Size(600, 190), .BackColor = Color.White, .Visible = False}
        Dim lblE1 As New Label() With {.Text = "Search Existing Customer:", .Font = New Font("Segoe UI", 10), .Location = New Point(15, 0), .AutoSize = True}
        _pnlSRExistCust.Controls.Add(lblE1)
        _cmbSRExistCust = New ComboBox() With {.Font = New Font("Segoe UI", 11), .Location = New Point(15, 25), .Size = New Size(350, 30), .DropDownStyle = ComboBoxStyle.DropDown, .AutoCompleteMode = AutoCompleteMode.SuggestAppend, .AutoCompleteSource = AutoCompleteSource.ListItems}
        AddHandler _cmbSRExistCust.SelectedIndexChanged, Sub() LoadWarrantiesForCustomer()
        _pnlSRExistCust.Controls.Add(_cmbSRExistCust)
        
        Dim lblE2 As New Label() With {.Text = "Select Associated Warranty (Optional):", .Font = New Font("Segoe UI", 10), .Location = New Point(15, 60), .AutoSize = True}
        _pnlSRExistCust.Controls.Add(lblE2)
        _cmbSRWarranty = New ComboBox() With {.Font = New Font("Segoe UI", 11), .Location = New Point(15, 85), .Size = New Size(350, 30), .DropDownStyle = ComboBoxStyle.DropDownList}
        _pnlSRExistCust.Controls.Add(_cmbSRWarranty)
        formContainer.Controls.Add(_pnlSRExistCust)

        AddHandler _optSRNewCust.CheckedChanged, Sub()
                                                     _pnlSRNewCust.Visible = _optSRNewCust.Checked
                                                     _pnlSRExistCust.Visible = _optSRExistCust.Checked
                                                 End Sub
        yPos += 190

        BuildHeader("Service Details")
        Dim lx As Integer = 15
        
        Dim lblService As New Label() With {.Text = "Service Target", .Font = New Font("Segoe UI", 10), .Location = New Point(lx, yPos), .AutoSize = True}
        formContainer.Controls.Add(lblService)
        _cmbSRService = New ComboBox() With {.Font = New Font("Segoe UI", 11), .Location = New Point(lx, yPos+25), .Size = New Size(350, 30), .DropDownStyle = ComboBoxStyle.DropDownList}
        formContainer.Controls.Add(_cmbSRService)
        yPos += 60

        Dim lblAddr As New Label() With {.Text = "Repair Address", .Font = New Font("Segoe UI", 10), .Location = New Point(lx, yPos), .AutoSize = True}
        formContainer.Controls.Add(lblAddr)
        _txtSRAddress = New TextBox() With {.Font = New Font("Segoe UI", 11), .Location = New Point(lx, yPos+25), .Size = New Size(350, 60), .Multiline = True}
        formContainer.Controls.Add(_txtSRAddress)
        yPos += 95
        
        BuildHeader("Scheduling & Staff")
        
        Dim lblStaff As New Label() With {.Text = "Assign Staff Coordinator", .Font = New Font("Segoe UI", 10), .Location = New Point(lx, yPos), .AutoSize = True}
        formContainer.Controls.Add(lblStaff)
        _cmbSRStaff = New ComboBox() With {.Font = New Font("Segoe UI", 11), .Location = New Point(lx, yPos+25), .Size = New Size(350, 30), .DropDownStyle = ComboBoxStyle.DropDownList}
        formContainer.Controls.Add(_cmbSRStaff)
        yPos += 60

        Dim lblTech As New Label() With {.Text = "Assign Technician (Optional)", .Font = New Font("Segoe UI", 10), .Location = New Point(lx, yPos), .AutoSize = True}
        formContainer.Controls.Add(lblTech)
        _cmbSRTechnician = New ComboBox() With {.Font = New Font("Segoe UI", 11), .Location = New Point(lx, yPos+25), .Size = New Size(350, 30), .DropDownStyle = ComboBoxStyle.DropDownList}
        formContainer.Controls.Add(_cmbSRTechnician)
        yPos += 60

        Dim lblReq As New Label() With {.Text = "Request Date", .Font = New Font("Segoe UI", 10), .Location = New Point(lx, yPos), .AutoSize = True}
        formContainer.Controls.Add(lblReq)
        _dtpSRRequest = New DateTimePicker() With {.Format=DateTimePickerFormat.Short, .Location = New Point(lx, yPos+25), .Size = New Size(160, 30), .Font = New Font("Segoe UI", 11)}
        formContainer.Controls.Add(_dtpSRRequest)
        
        Dim lblSch As New Label() With {.Text = "Scheduled Date", .Font = New Font("Segoe UI", 10), .Location = New Point(lx+200, yPos), .AutoSize = True}
        formContainer.Controls.Add(lblSch)
        _dtpSRScheduled = New DateTimePicker() With {.Format=DateTimePickerFormat.Short, .ShowCheckBox=True, .Checked=False, .Location = New Point(lx+200, yPos+25), .Size = New Size(160, 30), .Font = New Font("Segoe UI", 11)}
        formContainer.Controls.Add(_dtpSRScheduled)
        yPos += 60

        Dim lblStat As New Label() With {.Text = "Status", .Font = New Font("Segoe UI", 10), .Location = New Point(lx, yPos), .AutoSize = True}
        formContainer.Controls.Add(lblStat)
        _cmbSRStatus = New ComboBox() With {.DropDownStyle = ComboBoxStyle.DropDownList, .Font = New Font("Segoe UI", 11), .Location = New Point(lx, yPos+25), .Size=New Size(350, 30)}
        _cmbSRStatus.Items.AddRange(New String() {"Pending", "Scheduled", "In Progress", "Completed", "Cancelled"})
        _cmbSRStatus.SelectedIndex = 0
        formContainer.Controls.Add(_cmbSRStatus)
        yPos += 80

        Dim btnSaveReq As New Button() With {.Text = "Save Request", .Font = New Font("Segoe UI", 11, FontStyle.Bold), .ForeColor = Color.White, .BackColor = Color.FromArgb(0, 120, 215), .FlatStyle = FlatStyle.Flat, .Size = New Size(150, 40), .Location = New Point(15, yPos), .Cursor = Cursors.Hand}
        btnSaveReq.FlatAppearance.BorderSize = 0
        AddHandler btnSaveReq.Click, AddressOf SaveServiceRequestForm_Click
        formContainer.Controls.Add(btnSaveReq)

        Dim btnCancelReq As New Button() With {.Text = "Cancel", .Font = New Font("Segoe UI", 11), .ForeColor = Color.FromArgb(80, 80, 80), .BackColor = Color.White, .FlatStyle = FlatStyle.Flat, .Size = New Size(150, 40), .Location = New Point(180, yPos), .Cursor = Cursors.Hand}
        btnCancelReq.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200)
        AddHandler btnCancelReq.Click, Sub()
                                           pnlSRFormWrapper.Visible = False
                                           pnlSRDashboard.Visible = True
                                       End Sub
        formContainer.Controls.Add(btnCancelReq)

        pnlSRFormWrapper.Controls.Add(formContainer)
        pnlMain.Controls.Add(pnlSRFormWrapper)

        ' Make sure dashboard loads data when becoming visible
        AddHandler pnlMain.VisibleChanged, Sub(s, ev)
                                               If pnlMain.Visible Then
                                                   LoadServiceRequestsCards()
                                               End If
                                           End Sub

        Return pnlMain
    End Function

    Private Sub LoadDataForSRForm()
        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()

            ' Load Customers
            Dim dtCust As New DataTable()
            Using da As New MySqlDataAdapter("SELECT Customer_ID, Full_Name FROM CUSTOMER", conn)
                da.Fill(dtCust)
            End Using
            _cmbSRExistCust.DataSource = dtCust
            _cmbSRExistCust.DisplayMember = "Full_Name"
            _cmbSRExistCust.ValueMember = "Customer_ID"
            _cmbSRExistCust.SelectedIndex = -1

            ' Load Services
            Try
                Dim dtSvc As New DataTable()
                Using da As New MySqlDataAdapter("SELECT Service_ID, Service_Type FROM SERVICE", conn)
                    da.Fill(dtSvc)
                End Using
                _cmbSRService.DataSource = dtSvc
                _cmbSRService.DisplayMember = "Service_Type"
                _cmbSRService.ValueMember = "Service_ID"
            Catch
            End Try

            ' Load Staff
            Try
                Dim dtStaff As New DataTable()
                Using da As New MySqlDataAdapter("SELECT Staff_ID, Full_Name FROM STAFF", conn)
                    da.Fill(dtStaff)
                End Using
                _cmbSRStaff.DataSource = dtStaff
                _cmbSRStaff.DisplayMember = "Full_Name"
                _cmbSRStaff.ValueMember = "Staff_ID"
            Catch
            End Try

            ' Load Technician
            Try
                Dim dtTech As New DataTable()
                Dim q As String = "SELECT T.Technician_ID, S.Full_Name FROM TECHNICIAN T JOIN STAFF S ON T.Staff_ID = S.Staff_ID"
                Using da As New MySqlDataAdapter(q, conn)
                    da.Fill(dtTech)
                End Using
                _cmbSRTechnician.DataSource = dtTech
                _cmbSRTechnician.DisplayMember = "Full_Name"
                _cmbSRTechnician.ValueMember = "Technician_ID"
                _cmbSRTechnician.SelectedIndex = -1
            Catch
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadWarrantiesForCustomer()
        If _cmbSRWarranty Is Nothing Then Return
        If _cmbSRExistCust.SelectedValue Is Nothing Then 
            _cmbSRWarranty.DataSource = Nothing
            Return
        End If

        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()
            
            Dim custId As Object = _cmbSRExistCust.SelectedValue
            If TypeOf custId Is DataRowView Then Return
            
            Dim cid As Integer = Convert.ToInt32(custId)
            Dim dtW As New DataTable()
            Dim q As String = "SELECT W.Warranty_ID, CONCAT('Warranty ', W.Warranty_ID, ' (Expires: ', W.Warranty_End_Date, ')') as DescName " &
                              "FROM WARRANTY W JOIN PURCHASE P ON W.Purchase_ID = P.Purchase_ID " &
                              "WHERE P.Customer_ID = @cid AND W.Warranty_Status = 'Active'"
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@cid", cid)
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dtW)
                End Using
            End Using
            _cmbSRWarranty.DataSource = dtW
            _cmbSRWarranty.DisplayMember = "DescName"
            _cmbSRWarranty.ValueMember = "Warranty_ID"
            _cmbSRWarranty.SelectedIndex = -1
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadServiceRequestsCards()
        If flpServiceRequests Is Nothing Then Return
        flpServiceRequests.Controls.Clear()
        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()
            Dim statusFilter = If(_cmbStatusFilter IsNot Nothing AndAlso _cmbStatusFilter.SelectedItem IsNot Nothing, _cmbStatusFilter.SelectedItem.ToString(), "All")
            
            Dim q As String = "SELECT SR.Request_ID, C.Full_Name as Customer, SR.Request_Date, SR.Request_Status, S.Service_Type " &
                              "FROM SERVICE_REQUEST SR " &
                              "JOIN CUSTOMER C ON SR.Customer_ID = C.Customer_ID " &
                              "LEFT JOIN SERVICE S ON SR.Service_ID = S.Service_ID"
            
            If statusFilter <> "All" Then
                q &= " WHERE SR.Request_Status = @status"
            End If
            
            Using cmd As New MySqlCommand(q, conn)
                If statusFilter <> "All" Then cmd.Parameters.AddWithValue("@status", statusFilter)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim rId = Convert.ToInt32(reader("Request_ID"))
                        Dim cName = reader("Customer").ToString()
                        Dim rDate = Convert.ToDateTime(reader("Request_Date")).ToShortDateString()
                        Dim rStat = reader("Request_Status").ToString()
                        Dim sType = reader("Service_Type").ToString()

                        Dim card As New Panel() With {
                            .Size = New Size(280, 180),
                            .Margin = New Padding(10),
                            .BackColor = Color.White,
                            .BorderStyle = BorderStyle.FixedSingle
                        }
                        
                        Dim lblID As New Label() With {.Text = "Req ID: " & rId, .Font = New Font("Segoe UI", 10, FontStyle.Bold), .Location = New Point(10, 10), .AutoSize = True}
                        card.Controls.Add(lblID)

                        Dim lblCust As New Label() With {.Text = cName, .Font = New Font("Segoe UI", 12, FontStyle.Bold), .ForeColor = Color.FromArgb(0, 120, 215), .Location = New Point(10, 35), .AutoSize = True}
                        card.Controls.Add(lblCust)

                        Dim lblSvc As New Label() With {.Text = "Service: " & sType, .Font = New Font("Segoe UI", 10), .ForeColor = Color.FromArgb(80,80,80), .Location = New Point(10, 65), .AutoSize = True}
                        card.Controls.Add(lblSvc)

                        Dim lblDate As New Label() With {.Text = "Date: " & rDate, .Font = New Font("Segoe UI", 10), .ForeColor = Color.FromArgb(80,80,80), .Location = New Point(10, 90), .AutoSize = True}
                        card.Controls.Add(lblDate)

                        Dim btnStatus As New Button() With {
                            .Text = rStat,
                            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
                            .Size = New Size(260, 35),
                            .Location = New Point(10, 130),
                            .FlatStyle = FlatStyle.Flat,
                            .Cursor = Cursors.Hand,
                            .Tag = rId
                        }

                        Select Case rStat
                            Case "Pending" : btnStatus.BackColor = Color.Orange : btnStatus.ForeColor = Color.White
                            Case "Scheduled" : btnStatus.BackColor = Color.LightSkyBlue : btnStatus.ForeColor = Color.Black
                            Case "In Progress" : btnStatus.BackColor = Color.Gold : btnStatus.ForeColor = Color.Black
                            Case "Completed" : btnStatus.BackColor = Color.LimeGreen : btnStatus.ForeColor = Color.White
                            Case "Cancelled" : btnStatus.BackColor = Color.Crimson : btnStatus.ForeColor = Color.White
                            Case Else : btnStatus.BackColor = Color.Gray : btnStatus.ForeColor = Color.White
                        End Select
                        
                        btnStatus.FlatAppearance.BorderSize = 0
                        AddHandler btnStatus.Click, Sub(senderBtn, eBtn)
                                                        Dim cMenu As New ContextMenuStrip()
                                                        For Each st In {"Pending", "Scheduled", "In Progress", "Completed", "Cancelled"}
                                                            Dim itm = cMenu.Items.Add(st)
                                                            Dim sItemStr = st
                                                            AddHandler itm.Click, Sub(sItm, eItm) UpdateSRStatus(rId, sItemStr)
                                                        Next
                                                        cMenu.Show(btnStatus, New Point(0, btnStatus.Height))
                                                    End Sub
                        card.Controls.Add(btnStatus)

                        flpServiceRequests.Controls.Add(card)
                    End While
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub UpdateSRStatus(reqId As Integer, newStatus As String)
        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()
            Dim q As String = "UPDATE SERVICE_REQUEST SET Request_Status = @s WHERE Request_ID = @id"
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@s", newStatus)
                cmd.Parameters.AddWithValue("@id", reqId)
                cmd.ExecuteNonQuery()
            End Using
            LoadServiceRequestsCards()
        Catch ex As Exception
            MessageBox.Show("Error updating status: " & ex.Message)
        End Try
    End Sub

    Private Sub ClearServiceRequestForm()
        _optSRNewCust.Checked = True
        _txtSRNewCustName.Clear()
        _txtSRNewCustContact.Clear()
        _txtSRNewCustAddress.Clear()
        If _cmbSRExistCust IsNot Nothing Then _cmbSRExistCust.SelectedIndex = -1
        If _cmbSRWarranty IsNot Nothing Then _cmbSRWarranty.DataSource = Nothing
        If _cmbSRService IsNot Nothing Then _cmbSRService.SelectedIndex = -1
        If _cmbSRStaff IsNot Nothing Then _cmbSRStaff.SelectedIndex = -1
        If _cmbSRTechnician IsNot Nothing Then _cmbSRTechnician.SelectedIndex = -1
        _dtpSRRequest.Value = DateTime.Now
        _dtpSRScheduled.Checked = False
        If _dtpSRCompleted IsNot Nothing Then _dtpSRCompleted.Checked = False
        _txtSRAddress.Clear()
        If _cmbSRStatus IsNot Nothing Then _cmbSRStatus.SelectedIndex = 0
    End Sub

    Private Sub SaveServiceRequestForm_Click(sender As Object, e As EventArgs)
        Dim custId As Integer
        
        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()

            ' Handle Customer
            If _optSRNewCust.Checked Then
                If String.IsNullOrWhiteSpace(_txtSRNewCustName.Text) Then
                    MessageBox.Show("Please enter Customer Full Name.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                Dim qCustomer As String = "INSERT INTO CUSTOMER (Full_Name, Contact_Number, Home_Address) VALUES (@name, @contact, @address); SELECT LAST_INSERT_ID();"
                Using sqlCmd As New MySqlCommand(qCustomer, conn)
                    sqlCmd.Parameters.AddWithValue("@name", _txtSRNewCustName.Text)
                    sqlCmd.Parameters.AddWithValue("@contact", _txtSRNewCustContact.Text)
                    sqlCmd.Parameters.AddWithValue("@address", _txtSRNewCustAddress.Text)
                    custId = Convert.ToInt32(sqlCmd.ExecuteScalar())
                End Using
            Else
                If _cmbSRExistCust.SelectedValue Is Nothing Then
                    MessageBox.Show("Please select an existing customer.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                custId = Convert.ToInt32(_cmbSRExistCust.SelectedValue)
            End If

            ' Validate associations
            If _cmbSRService.SelectedValue Is Nothing Then
                MessageBox.Show("Please select a Service Target.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If _cmbSRStaff.SelectedValue Is Nothing Then
                MessageBox.Show("Please assign a Staff Coordinator.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If String.IsNullOrWhiteSpace(_txtSRAddress.Text) Then
                MessageBox.Show("Please explicitly enter a repair destination Service Address.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Execute Insertion
            Dim qInsert As String = "INSERT INTO SERVICE_REQUEST (Customer_ID, Service_ID, Staff_ID, Technician_ID, Warranty_ID, Request_Date, Scheduled_Date, Service_Address, Request_Status) " &
                                    "VALUES (@cid, @sid, @stid, @tid, @wid, @rdate, @sdate, @addr, @status)"
            Using sqlCmd As New MySqlCommand(qInsert, conn)
                sqlCmd.Parameters.AddWithValue("@cid", custId)
                sqlCmd.Parameters.AddWithValue("@sid", Convert.ToInt32(_cmbSRService.SelectedValue))
                sqlCmd.Parameters.AddWithValue("@stid", Convert.ToInt32(_cmbSRStaff.SelectedValue))
                
                If _cmbSRTechnician.SelectedValue Is Nothing Then
                    sqlCmd.Parameters.AddWithValue("@tid", DBNull.Value)
                Else
                    sqlCmd.Parameters.AddWithValue("@tid", Convert.ToInt32(_cmbSRTechnician.SelectedValue))
                End If

                If _cmbSRWarranty.SelectedValue Is Nothing Then
                    sqlCmd.Parameters.AddWithValue("@wid", DBNull.Value)
                Else
                    sqlCmd.Parameters.AddWithValue("@wid", Convert.ToInt32(_cmbSRWarranty.SelectedValue))
                End If

                sqlCmd.Parameters.AddWithValue("@rdate", _dtpSRRequest.Value.Date)

                If _dtpSRScheduled.Checked Then
                    sqlCmd.Parameters.AddWithValue("@sdate", _dtpSRScheduled.Value.Date)
                Else
                    sqlCmd.Parameters.AddWithValue("@sdate", DBNull.Value)
                End If

                ' Left out Completed_Date for initial creation
                sqlCmd.Parameters.AddWithValue("@addr", _txtSRAddress.Text)
                sqlCmd.Parameters.AddWithValue("@status", _cmbSRStatus.SelectedItem.ToString())

                sqlCmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Service Request generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearServiceRequestForm()
            pnlSRFormWrapper.Visible = False
            pnlSRDashboard.Visible = True
            LoadServiceRequestsCards()

        Catch ex As Exception
            MessageBox.Show("Error saving service request: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════
    '  WARRANTY CLAIMS PANEL
    ' ═══════════════════════════════════════════════════
    Private flpWarrantyClaims As FlowLayoutPanel
    Private _cmbWCStatusFilter As ComboBox
    Private pnlWCDashboard As Panel
    Private pnlWCFormWrapper As Panel

    Private _cmbWCCustomer As ComboBox
    Private _cmbWCWarranty As ComboBox
    Private _txtWCDesc As TextBox

    Private Function BuildWarrantyDashboard() As Panel
        Dim pnlMain As New Panel() With {.Dock = DockStyle.Fill, .BackColor = Color.FromArgb(245, 245, 248), .Visible = False}

        ' --- DASHBOARD ---
        pnlWCDashboard = New Panel() With {.Dock = DockStyle.Fill}
        Dim pnlTop As New Panel() With {.Dock = DockStyle.Top, .Height = 80, .Padding = New Padding(20)}
        Dim lblTitle As New Label() With {.Text = "Warranty Claims Dashboard", .Font = New Font("Segoe UI", 20, FontStyle.Bold), .ForeColor = Color.FromArgb(30, 30, 30), .AutoSize = True, .Location = New Point(20, 20)}
        pnlTop.Controls.Add(lblTitle)
        
        Dim btnNewClaim As New Button() With {.Text = "+ File New Claim", .Font = New Font("Segoe UI", 11, FontStyle.Bold), .BackColor = Color.FromArgb(0, 120, 215), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Size = New Size(160, 40), .Location = New Point(pnlTop.Width - 200, 20), .Anchor = AnchorStyles.Top Or AnchorStyles.Right, .Cursor = Cursors.Hand}
        btnNewClaim.FlatAppearance.BorderSize = 0
        AddHandler btnNewClaim.Click, Sub() 
                                          ClearWCForm()
                                          LoadDataForWCForm()
                                          pnlWCDashboard.Visible = False
                                          pnlWCFormWrapper.Visible = True
                                      End Sub
        pnlTop.Controls.Add(btnNewClaim)

        Dim lblFilter As New Label() With {.Text = "Filter Resolution:", .Font = New Font("Segoe UI", 10), .AutoSize = True, .Location = New Point(450, 30)}
        pnlTop.Controls.Add(lblFilter)
        _cmbWCStatusFilter = New ComboBox() With {.DropDownStyle = ComboBoxStyle.DropDownList, .Font = New Font("Segoe UI", 10), .Location = New Point(590, 28), .Size = New Size(150, 25)}
        _cmbWCStatusFilter.Items.AddRange(New String() {"All", "Pending Review", "Approved - Fixing", "Approved - Replaced", "Denied"})
        _cmbWCStatusFilter.SelectedIndex = 0
        AddHandler _cmbWCStatusFilter.SelectedIndexChanged, Sub() LoadWarrantyClaimsCards()
        pnlTop.Controls.Add(_cmbWCStatusFilter)
        pnlWCDashboard.Controls.Add(pnlTop)

        flpWarrantyClaims = New FlowLayoutPanel() With {
            .Dock = DockStyle.Fill, 
            .AutoScroll = True, 
            .Padding = New Padding(20),
            .BackColor = Color.FromArgb(245, 245, 248)
        }
        pnlWCDashboard.Controls.Add(flpWarrantyClaims)
        flpWarrantyClaims.BringToFront()
        pnlMain.Controls.Add(pnlWCDashboard)

        ' --- FORM ---
        pnlWCFormWrapper = New Panel() With {.Dock = DockStyle.Fill, .Visible = False, .AutoScroll = True, .Padding = New Padding(30)}
        Dim lblFormTitle As New Label() With {.Text = "File Warranty Claim", .Font = New Font("Segoe UI", 20, FontStyle.Bold), .ForeColor = Color.FromArgb(30, 30, 30), .Dock = DockStyle.Top, .Height = 50}
        pnlWCFormWrapper.Controls.Add(lblFormTitle)

        Dim formContainer As New Panel() With {.Dock = DockStyle.Top, .AutoSize = True, .BackColor = Color.White, .Padding = New Padding(20)}
        Dim yPos As Integer = 15
        
        Dim BuildH = Sub(txt As String)
            Dim lblH As New Label() With {.Text = txt, .Font = New Font("Segoe UI", 12, FontStyle.Bold), .Location = New Point(15, yPos), .AutoSize = True}
            formContainer.Controls.Add(lblH)
            yPos += 30
        End Sub

        BuildH("1. Select Customer")
        _cmbWCCustomer = New ComboBox() With {.Font = New Font("Segoe UI", 11), .Location = New Point(15, yPos), .Size = New Size(350, 30), .DropDownStyle = ComboBoxStyle.DropDown, .AutoCompleteMode = AutoCompleteMode.SuggestAppend, .AutoCompleteSource = AutoCompleteSource.ListItems}
        AddHandler _cmbWCCustomer.SelectedIndexChanged, Sub() LoadWarrantiesForWCCustomer()
        formContainer.Controls.Add(_cmbWCCustomer)
        yPos += 60

        BuildH("2. Select Eligible Warranty")
        _cmbWCWarranty = New ComboBox() With {.Font = New Font("Segoe UI", 11), .Location = New Point(15, yPos), .Size = New Size(450, 30), .DropDownStyle = ComboBoxStyle.DropDownList}
        formContainer.Controls.Add(_cmbWCWarranty)
        yPos += 60

        BuildH("3. Defect Description")
        _txtWCDesc = New TextBox() With {.Font = New Font("Segoe UI", 11), .Location = New Point(15, yPos), .Size = New Size(450, 80), .Multiline = True}
        formContainer.Controls.Add(_txtWCDesc)
        yPos += 110

        Dim btnSaveClaim As New Button() With {.Text = "Submit Claim", .Font = New Font("Segoe UI", 11, FontStyle.Bold), .ForeColor = Color.White, .BackColor = Color.FromArgb(0, 120, 215), .FlatStyle = FlatStyle.Flat, .Size = New Size(150, 40), .Location = New Point(15, yPos), .Cursor = Cursors.Hand}
        btnSaveClaim.FlatAppearance.BorderSize = 0
        AddHandler btnSaveClaim.Click, AddressOf SaveWarrantyClaim_Click
        formContainer.Controls.Add(btnSaveClaim)

        Dim btnCancelClaim As New Button() With {.Text = "Cancel", .Font = New Font("Segoe UI", 11), .ForeColor = Color.FromArgb(80, 80, 80), .BackColor = Color.White, .FlatStyle = FlatStyle.Flat, .Size = New Size(150, 40), .Location = New Point(180, yPos), .Cursor = Cursors.Hand}
        btnCancelClaim.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200)
        AddHandler btnCancelClaim.Click, Sub()
                                             pnlWCFormWrapper.Visible = False
                                             pnlWCDashboard.Visible = True
                                         End Sub
        formContainer.Controls.Add(btnCancelClaim)

        pnlWCFormWrapper.Controls.Add(formContainer)
        pnlMain.Controls.Add(pnlWCFormWrapper)

        AddHandler pnlMain.VisibleChanged, Sub(s, ev)
                                               If pnlMain.Visible Then LoadWarrantyClaimsCards()
                                           End Sub
        Return pnlMain
    End Function

    Private Sub LoadDataForWCForm()
        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()
            Dim dtCust As New DataTable()
            Using da As New MySqlDataAdapter("SELECT Customer_ID, Full_Name FROM CUSTOMER", conn)
                da.Fill(dtCust)
            End Using
            _cmbWCCustomer.DataSource = dtCust
            _cmbWCCustomer.DisplayMember = "Full_Name"
            _cmbWCCustomer.ValueMember = "Customer_ID"
            _cmbWCCustomer.SelectedIndex = -1
            _cmbWCWarranty.DataSource = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadWarrantiesForWCCustomer()
        If _cmbWCWarranty Is Nothing Then Return
        If _cmbWCCustomer.SelectedValue Is Nothing Then 
            _cmbWCWarranty.DataSource = Nothing
            Return
        End If
        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()
            Dim custIdObj As Object = _cmbWCCustomer.SelectedValue
            If TypeOf custIdObj Is DataRowView Then Return
            
            Dim cid As Integer = Convert.ToInt32(custIdObj)
            Dim dtW As New DataTable()
            Dim q As String = "SELECT W.Warranty_ID, CONCAT('WID: ', W.Warranty_ID, ' - Ends: ', W.Warranty_End_Date) as DescName " &
                              "FROM WARRANTY W JOIN PURCHASE P ON W.Purchase_ID = P.Purchase_ID " &
                              "WHERE P.Customer_ID = @cid"
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@cid", cid)
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dtW)
                End Using
            End Using
            _cmbWCWarranty.DataSource = dtW
            _cmbWCWarranty.DisplayMember = "DescName"
            _cmbWCWarranty.ValueMember = "Warranty_ID"
            _cmbWCWarranty.SelectedIndex = -1
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadWarrantyClaimsCards()
        If flpWarrantyClaims Is Nothing Then Return
        flpWarrantyClaims.Controls.Clear()
        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()
            Dim statusFilter = If(_cmbWCStatusFilter IsNot Nothing AndAlso _cmbWCStatusFilter.SelectedItem IsNot Nothing, _cmbWCStatusFilter.SelectedItem.ToString(), "All")
            
            Dim q As String = "SELECT WC.Claim_ID, C.Full_Name as Customer, WC.Claim_Date, WC.Claim_Description, WC.Claim_Resolution " &
                              "FROM WARRANTY_CLAIM WC " &
                              "JOIN WARRANTY W ON WC.Warranty_ID = W.Warranty_ID " &
                              "JOIN PURCHASE P ON W.Purchase_ID = P.Purchase_ID " &
                              "JOIN CUSTOMER C ON P.Customer_ID = C.Customer_ID"
            
            If statusFilter <> "All" Then q &= " WHERE WC.Claim_Resolution = @status"
            
            Using cmd As New MySqlCommand(q, conn)
                If statusFilter <> "All" Then cmd.Parameters.AddWithValue("@status", statusFilter)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim cId = Convert.ToInt32(reader("Claim_ID"))
                        Dim cName = reader("Customer").ToString()
                        Dim claimDateStr = Convert.ToDateTime(reader("Claim_Date")).ToShortDateString()
                        Dim cDesc = reader("Claim_Description").ToString()
                        Dim cRes = reader("Claim_Resolution").ToString()
                        If String.IsNullOrEmpty(cRes) Then cRes = "Pending Review"

                        Dim card As New Panel() With {.Size = New Size(280, 180), .Margin = New Padding(10), .BackColor = Color.White, .BorderStyle = BorderStyle.FixedSingle}
                        
                        Dim lblID As New Label() With {.Text = "Claim ID: " & cId, .Font = New Font("Segoe UI", 10, FontStyle.Bold), .Location = New Point(10, 10), .AutoSize = True}
                        card.Controls.Add(lblID)

                        Dim lblCust As New Label() With {.Text = cName, .Font = New Font("Segoe UI", 12, FontStyle.Bold), .ForeColor = Color.FromArgb(0, 120, 215), .Location = New Point(10, 35), .AutoSize = True}
                        card.Controls.Add(lblCust)

                        Dim lblD As New Label() With {.Text = "Desc: " & If(cDesc.Length > 20, cDesc.Substring(0, 20) & "...", cDesc), .Font = New Font("Segoe UI", 10), .ForeColor = Color.FromArgb(80,80,80), .Location = New Point(10, 65), .AutoSize = True}
                        card.Controls.Add(lblD)

                        Dim lblDate As New Label() With {.Text = "Date: " & claimDateStr, .Font = New Font("Segoe UI", 10), .ForeColor = Color.FromArgb(80,80,80), .Location = New Point(10, 90), .AutoSize = True}
                        card.Controls.Add(lblDate)

                        Dim btnRes As New Button() With {.Text = cRes, .Font = New Font("Segoe UI", 10, FontStyle.Bold), .Size = New Size(260, 35), .Location = New Point(10, 130), .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand, .Tag = cId}
                        Select Case cRes
                            Case "Pending Review" : btnRes.BackColor = Color.Orange : btnRes.ForeColor = Color.White
                            Case "Approved - Fixing" : btnRes.BackColor = Color.Gold : btnRes.ForeColor = Color.Black
                            Case "Approved - Replaced" : btnRes.BackColor = Color.LimeGreen : btnRes.ForeColor = Color.White
                            Case "Denied" : btnRes.BackColor = Color.Crimson : btnRes.ForeColor = Color.White
                            Case Else : btnRes.BackColor = Color.Gray : btnRes.ForeColor = Color.White
                        End Select
                        
                        btnRes.FlatAppearance.BorderSize = 0
                        AddHandler btnRes.Click, Sub(senderBtn, eBtn)
                                                     Dim cMenu As New ContextMenuStrip()
                                                     For Each st In {"Pending Review", "Approved - Fixing", "Approved - Replaced", "Denied"}
                                                         Dim itm = cMenu.Items.Add(st)
                                                         Dim sItemStr = st
                                                         AddHandler itm.Click, Sub(sItm, eItm) UpdateWCResolution(cId, sItemStr)
                                                     Next
                                                     cMenu.Show(btnRes, New Point(0, btnRes.Height))
                                                 End Sub
                        card.Controls.Add(btnRes)
                        flpWarrantyClaims.Controls.Add(card)
                    End While
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub UpdateWCResolution(claimId As Integer, resolution As String)
        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()
            Dim q As String = "UPDATE WARRANTY_CLAIM SET Claim_Resolution = @r WHERE Claim_ID = @id"
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@r", resolution)
                cmd.Parameters.AddWithValue("@id", claimId)
                cmd.ExecuteNonQuery()
            End Using
            LoadWarrantyClaimsCards()
        Catch ex As Exception
            MessageBox.Show("Error updating resolution: " & ex.Message)
        End Try
    End Sub

    Private Sub ClearWCForm()
        _cmbWCCustomer.SelectedIndex = -1
        _cmbWCWarranty.DataSource = Nothing
        _txtWCDesc.Clear()
    End Sub

    Private Sub SaveWarrantyClaim_Click(sender As Object, e As EventArgs)
        If _cmbWCWarranty.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a valid Warranty.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If String.IsNullOrWhiteSpace(_txtWCDesc.Text) Then
            MessageBox.Show("Please provide a description of the defect.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()
            Dim q As String = "INSERT INTO WARRANTY_CLAIM (Warranty_ID, Claim_Date, Claim_Description, Claim_Resolution) VALUES (@wid, CURDATE(), @desc, 'Pending Review')"
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@wid", Convert.ToInt32(_cmbWCWarranty.SelectedValue))
                cmd.Parameters.AddWithValue("@desc", _txtWCDesc.Text)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Warranty Claim filed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearWCForm()
            pnlWCFormWrapper.Visible = False
            pnlWCDashboard.Visible = True
            LoadWarrantyClaimsCards()

        Catch ex As Exception
            MessageBox.Show("Error filing claim: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════
    '  CHECKOUT PANEL
    ' ═══════════════════════════════════════════════════
    
    Private _lblCheckoutTotal As Label
    Private _txtCustomerName As TextBox
    Private _txtContactNumber As TextBox
    Private _txtAddress As TextBox
    Private _pnlCheckoutSummary As FlowLayoutPanel
    Private _optNewCustCheckout As RadioButton
    Private _optExistCustCheckout As RadioButton
    Private _cmbExistCustCheckout As ComboBox
    Private _pnlNewCustCheckout As Panel
    Private _pnlExistCustCheckout As Panel

    Private Sub LoadCustomersToCombo(cmb As ComboBox)
        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()
            Dim dt As New DataTable()
            Dim q As String = "SELECT Customer_ID, Full_Name FROM CUSTOMER"
            Using adapter As New MySqlDataAdapter(q, conn)
                adapter.Fill(dt)
            End Using
            cmb.DataSource = dt
            cmb.DisplayMember = "Full_Name"
            cmb.ValueMember = "Customer_ID"
            cmb.SelectedIndex = -1
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CheckoutContinue_Click(sender As Object, e As EventArgs)
        If _orderItems.Count = 0 Then
            MessageBox.Show("Your order is empty. Please add items to your order first.", "Empty Order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        
        RefreshCheckoutTotals()
        LoadCustomersToCombo(_cmbExistCustCheckout)
        ShowPanel(pnlCheckout)
    End Sub

    Private Function BuildCheckoutPanel() As Panel
        Dim pnl As New Panel()
        pnl.Dock = DockStyle.Fill
        pnl.BackColor = Color.FromArgb(240, 240, 245)
        pnl.Visible = False
        pnl.Padding = New Padding(0)

        ' Title label
        Dim lblTitle As New Label()
        lblTitle.Text = "Checkout"
        lblTitle.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(30, 30, 30)
        lblTitle.Dock = DockStyle.Top
        lblTitle.Padding = New Padding(30, 20, 0, 10)
        lblTitle.Height = 70
        pnl.Controls.Add(lblTitle)

        ' Form fields container
        Dim formContainer As New Panel()
        formContainer.Dock = DockStyle.Top
        formContainer.Padding = New Padding(30, 10, 30, 10)
        formContainer.AutoSize = True
        formContainer.BackColor = Color.White
        formContainer.Location = New Point(30, 80)

        Dim yPos As Integer = 15

        ' Customer Type Selection
        _optNewCustCheckout = New RadioButton() With {.Text = "New Customer", .Font = New Font("Segoe UI", 10, FontStyle.Bold), .Location = New Point(15, yPos), .AutoSize = True, .Checked = True}
        _optExistCustCheckout = New RadioButton() With {.Text = "Existing Customer", .Font = New Font("Segoe UI", 10, FontStyle.Bold), .Location = New Point(160, yPos), .AutoSize = True}
        formContainer.Controls.Add(_optNewCustCheckout)
        formContainer.Controls.Add(_optExistCustCheckout)
        yPos += 35

        ' NEW CUSTOMER PANEL
        _pnlNewCustCheckout = New Panel() With {.Location = New Point(0, yPos), .Size = New Size(formContainer.Width, 195), .BackColor = Color.White}
        Dim ny As Integer = 0
        
        Dim lblName As New Label() With {.Text = "Full Name", .Font = New Font("Segoe UI", 10), .ForeColor = Color.FromArgb(80, 80, 80), .Location = New Point(15, ny), .AutoSize = True}
        _pnlNewCustCheckout.Controls.Add(lblName)
        _txtCustomerName = New TextBox() With {.Font = New Font("Segoe UI", 11), .Location = New Point(15, ny + 25), .Size = New Size(350, 30), .BorderStyle = BorderStyle.FixedSingle}
        _pnlNewCustCheckout.Controls.Add(_txtCustomerName)
        ny += 60

        Dim lblContact As New Label() With {.Text = "Contact Number", .Font = New Font("Segoe UI", 10), .ForeColor = Color.FromArgb(80, 80, 80), .Location = New Point(15, ny), .AutoSize = True}
        _pnlNewCustCheckout.Controls.Add(lblContact)
        _txtContactNumber = New TextBox() With {.Font = New Font("Segoe UI", 11), .Location = New Point(15, ny + 25), .Size = New Size(350, 30), .BorderStyle = BorderStyle.FixedSingle}
        _pnlNewCustCheckout.Controls.Add(_txtContactNumber)
        ny += 60

        Dim lblAddress As New Label() With {.Text = "Home Address", .Font = New Font("Segoe UI", 10), .ForeColor = Color.FromArgb(80, 80, 80), .Location = New Point(15, ny), .AutoSize = True}
        _pnlNewCustCheckout.Controls.Add(lblAddress)
        _txtAddress = New TextBox() With {.Font = New Font("Segoe UI", 11), .Location = New Point(15, ny + 25), .Size = New Size(350, 30), .BorderStyle = BorderStyle.FixedSingle}
        _pnlNewCustCheckout.Controls.Add(_txtAddress)
        formContainer.Controls.Add(_pnlNewCustCheckout)

        ' EXISTING CUSTOMER PANEL
        _pnlExistCustCheckout = New Panel() With {.Location = New Point(0, yPos), .Size = New Size(formContainer.Width, 195), .BackColor = Color.White, .Visible = False}
        Dim lblExist As New Label() With {.Text = "Search by Name:", .Font = New Font("Segoe UI", 10), .ForeColor = Color.FromArgb(80, 80, 80), .Location = New Point(15, 0), .AutoSize = True}
        _pnlExistCustCheckout.Controls.Add(lblExist)
        _cmbExistCustCheckout = New ComboBox() With {.Font = New Font("Segoe UI", 11), .Location = New Point(15, 25), .Size = New Size(350, 30), .DropDownStyle = ComboBoxStyle.DropDown, .AutoCompleteMode = AutoCompleteMode.SuggestAppend, .AutoCompleteSource = AutoCompleteSource.ListItems}
        _pnlExistCustCheckout.Controls.Add(_cmbExistCustCheckout)
        formContainer.Controls.Add(_pnlExistCustCheckout)

        ' Toggle Logic
        AddHandler _optNewCustCheckout.CheckedChanged, Sub() 
                                                           _pnlNewCustCheckout.Visible = _optNewCustCheckout.Checked
                                                           _pnlExistCustCheckout.Visible = _optExistCustCheckout.Checked
                                                       End Sub
        yPos += 195

        ' Order Summary Display
        Dim lblSummaryTitle As New Label() With {.Text = "Order Summary:", .Font = New Font("Segoe UI", 12, FontStyle.Bold), .Location = New Point(15, yPos), .AutoSize = True}
        formContainer.Controls.Add(lblSummaryTitle)
        yPos += 30

        _pnlCheckoutSummary = New FlowLayoutPanel() With {.Location = New Point(15, yPos), .Size = New Size(400, 150), .AutoScroll = True, .BackColor = Color.FromArgb(250, 250, 250), .BorderStyle = BorderStyle.FixedSingle, .Padding = New Padding(5), .FlowDirection = FlowDirection.TopDown, .WrapContents = False}
        formContainer.Controls.Add(_pnlCheckoutSummary)
        yPos += 165

        ' Total Amount Display
        Dim lblTotalTitle As New Label() With {.Text = "Total Amount to Pay:", .Font = New Font("Segoe UI", 12, FontStyle.Bold), .Location = New Point(15, yPos + 10), .AutoSize = True}
        formContainer.Controls.Add(lblTotalTitle)
        
        _lblCheckoutTotal = New Label() With {.Text = "₱0.00", .Font = New Font("Segoe UI", 14, FontStyle.Bold), .ForeColor = Color.FromArgb(0, 120, 215), .Location = New Point(180, yPos + 8), .AutoSize = True}
        formContainer.Controls.Add(_lblCheckoutTotal)
        yPos += 50

        ' Buttons
        Dim btnSubmit As New Button() With {.Text = "Confirm Order", .Font = New Font("Segoe UI", 11, FontStyle.Bold), .ForeColor = Color.White, .BackColor = Color.FromArgb(0, 120, 215), .FlatStyle = FlatStyle.Flat, .Size = New Size(140, 40), .Location = New Point(15, yPos + 10), .Cursor = Cursors.Hand}
        btnSubmit.FlatAppearance.BorderSize = 0
        AddHandler btnSubmit.Click, AddressOf ConfirmCheckout_Click
        formContainer.Controls.Add(btnSubmit)

        Dim btnCancel As New Button() With {.Text = "Back to Sales", .Font = New Font("Segoe UI", 11), .ForeColor = Color.FromArgb(80, 80, 80), .BackColor = Color.White, .FlatStyle = FlatStyle.Flat, .Size = New Size(140, 40), .Location = New Point(165, yPos + 10), .Cursor = Cursors.Hand}
        btnCancel.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200)
        AddHandler btnCancel.Click, Sub() ShowPanel(pnlSales)
        formContainer.Controls.Add(btnCancel)

        pnl.Controls.Add(formContainer)
        formContainer.BringToFront()

        Return pnl
    End Function

    Private Sub RefreshCheckoutTotals()
        Dim subtotal As Decimal = 0
        If _pnlCheckoutSummary IsNot Nothing Then _pnlCheckoutSummary.Controls.Clear()

        For Each kvp In _orderItems
            Dim itemTotal = kvp.Value.Item2 * kvp.Value.Item3
            subtotal += itemTotal

            If _pnlCheckoutSummary IsNot Nothing Then
                Dim lblItem As New Label() With {
                    .Text = $"{kvp.Value.Item3}x {kvp.Value.Item1} - ₱{itemTotal.ToString("N2")}",
                    .Font = New Font("Segoe UI", 11),
                    .AutoSize = True,
                    .Margin = New Padding(0, 0, 0, 5)
                }
                _pnlCheckoutSummary.Controls.Add(lblItem)
            End If
        Next
        If _lblCheckoutTotal IsNot Nothing Then
            _lblCheckoutTotal.Text = "₱" & subtotal.ToString("N2")
        End If
    End Sub

    Private Sub ConfirmCheckout_Click(sender As Object, e As EventArgs)
        Dim custId As Integer
        Dim purchaseId As Integer
        
        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()

            If _optNewCustCheckout.Checked Then
                If String.IsNullOrWhiteSpace(_txtCustomerName.Text) Then
                    MessageBox.Show("Please enter Customer Full Name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                Dim qCustomer As String = "INSERT INTO CUSTOMER (Full_Name, Contact_Number, Home_Address) VALUES (@name, @contact, @address); SELECT LAST_INSERT_ID();"
                Using sqlCmd As New MySqlCommand(qCustomer, conn)
                    sqlCmd.Parameters.AddWithValue("@name", _txtCustomerName.Text)
                    sqlCmd.Parameters.AddWithValue("@contact", _txtContactNumber.Text)
                    sqlCmd.Parameters.AddWithValue("@address", _txtAddress.Text)
                    custId = Convert.ToInt32(sqlCmd.ExecuteScalar())
                End Using
            Else
                If _cmbExistCustCheckout.SelectedValue Is Nothing Then
                    MessageBox.Show("Please select an existing customer from the lookup.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                custId = Convert.ToInt32(_cmbExistCustCheckout.SelectedValue)
            End If

            Dim receiptNo As String = "REC-" & DateTime.Now.ToString("yyyyMMddHHmmss")
            Dim qPurchase As String = "INSERT INTO PURCHASE (Customer_ID, Purchase_Date, Receipt_Number) VALUES (@cid, CURDATE(), @rn); SELECT LAST_INSERT_ID();"
            Using cmdPurch As New MySqlCommand(qPurchase, conn)
                cmdPurch.Parameters.AddWithValue("@cid", custId)
                cmdPurch.Parameters.AddWithValue("@rn", receiptNo)
                purchaseId = Convert.ToInt32(cmdPurch.ExecuteScalar())
            End Using

            Dim qItems As String = "INSERT INTO PURCHASE_ITEMS (Purchase_ID, Product_ID, Quantity, Item_Price) VALUES (@pid, @prodid, @qty, @price)"
            Using cmdItems As New MySqlCommand(qItems, conn)
                For Each kvp In _orderItems
                    cmdItems.Parameters.Clear()
                    cmdItems.Parameters.AddWithValue("@pid", purchaseId)
                    cmdItems.Parameters.AddWithValue("@prodid", kvp.Key)
                    cmdItems.Parameters.AddWithValue("@qty", kvp.Value.Item3)
                    cmdItems.Parameters.AddWithValue("@price", kvp.Value.Item2)
                    cmdItems.ExecuteNonQuery()
                Next
            End Using

            ' Automatically register a 1-year active warranty for this purchase
            Dim qWarranty As String = "INSERT INTO WARRANTY (Purchase_ID, Warranty_Start_Date, Warranty_End_Date, Warranty_Status) VALUES (@pid, CURDATE(), DATE_ADD(CURDATE(), INTERVAL 1 YEAR), 'Active')"
            Using cmdWarranty As New MySqlCommand(qWarranty, conn)
                cmdWarranty.Parameters.AddWithValue("@pid", purchaseId)
                cmdWarranty.ExecuteNonQuery()
            End Using
            
        Catch ex As Exception
            MessageBox.Show("Error saving order data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End Try

        MessageBox.Show("Order has been confirmed successfully for " & _txtCustomerName.Text & "!" & vbCrLf & "Your items have been placed.", "Checkout Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        
        ' Reset
        _orderItems.Clear()
        RefreshOrderPanel()
        _txtCustomerName.Text = ""
        _txtContactNumber.Text = ""
        _txtAddress.Text = ""
        ShowPanel(pnlSales)
    End Sub

    ' ═══════════════════════════════════════════════════
    '  NAVIGATION
    ' ═══════════════════════════════════════════════════

    Private Sub SetActiveButton(btn As Button)
        If _activeButton IsNot Nothing Then
            _activeButton.BackColor = _defaultColor
            _activeButton.ForeColor = Color.White
        End If

        btn.BackColor = _activeColor
        btn.ForeColor = Color.FromArgb(0, 120, 215)
        _activeButton = btn
    End Sub

    Private Sub ShowPanel(panel As Panel)
        For Each ctrl As Control In pnlMainContent.Controls
            ctrl.Visible = False
        Next
        panel.Visible = True
        panel.BringToFront()
    End Sub

    ' --- Navigation Button Click Handlers ---

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        SetActiveButton(btnDashboard)
        ShowPanel(pnlDashboard)
    End Sub

    Private Sub btnSales_Click(sender As Object, e As EventArgs) Handles btnSales.Click
        SetActiveButton(btnSales)
        ShowPanel(pnlSales)
    End Sub

    Private Sub btnServiceRequests_Click(sender As Object, e As EventArgs) Handles btnServiceRequests.Click
        SetActiveButton(btnServiceRequests)
        ShowPanel(pnlServiceReq)
    End Sub

    Private Sub btnWarrantyClaims_Click(sender As Object, e As EventArgs) Handles btnWarrantyClaims.Click
        SetActiveButton(btnWarrantyClaims)
        ShowPanel(pnlWarranty)
    End Sub

    ' Products Dashboard has been deprecated and removed.

    ' ═══════════════════════════════════════════════════
    '  TRANSACTIONS DASHBOARD
    ' ═══════════════════════════════════════════════════
    Private pnlTransactDashboard As Panel
    Private pnlTransactDetailWrapper As Panel
    Private flpTransactions As FlowLayoutPanel
    Private flpTransactionItems As FlowLayoutPanel
    Private lblTransactDetailTitle As Label
    Private lblTransactDetailCustomer As Label
    Private lblTransactDetailDate As Label
    Private lblTransactDetailTotal As Label

    Private Function BuildTransactionsDashboard() As Panel
        Dim pnlMain As New Panel() With {.Dock = DockStyle.Fill, .BackColor = Color.FromArgb(245, 245, 248), .Visible = False}

        ' --- DASHBOARD ---
        pnlTransactDashboard = New Panel() With {.Dock = DockStyle.Fill}
        Dim pnlTop As New Panel() With {.Dock = DockStyle.Top, .Height = 80, .Padding = New Padding(20)}
        Dim lblTitle As New Label() With {.Text = "Transactions Dashboard", .Font = New Font("Segoe UI", 20, FontStyle.Bold), .ForeColor = Color.FromArgb(30, 30, 30), .AutoSize = True, .Location = New Point(20, 20)}
        pnlTop.Controls.Add(lblTitle)
        
        Dim btnRefresh As New Button() With {.Text = "Refresh", .Font = New Font("Segoe UI", 11, FontStyle.Bold), .BackColor = Color.White, .ForeColor = Color.FromArgb(0, 120, 215), .FlatStyle = FlatStyle.Flat, .Size = New Size(100, 40), .Location = New Point(pnlTop.Width - 140, 20), .Anchor = AnchorStyles.Top Or AnchorStyles.Right, .Cursor = Cursors.Hand}
        btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200)
        AddHandler btnRefresh.Click, Sub() LoadTransactionsData()
        pnlTop.Controls.Add(btnRefresh)

        pnlTransactDashboard.Controls.Add(pnlTop)

        flpTransactions = New FlowLayoutPanel() With {
            .Dock = DockStyle.Fill, 
            .AutoScroll = True, 
            .Padding = New Padding(20),
            .BackColor = Color.FromArgb(245, 245, 248)
        }
        pnlTransactDashboard.Controls.Add(flpTransactions)
        flpTransactions.BringToFront()
        pnlMain.Controls.Add(pnlTransactDashboard)

        ' --- DETAIL WRAPPER ---
        pnlTransactDetailWrapper = New Panel() With {.Dock = DockStyle.Fill, .Visible = False, .AutoScroll = True, .Padding = New Padding(30)}
        
        Dim pnlDetailTop As New Panel() With {.Dock = DockStyle.Top, .Height = 120}
        
        Dim btnBack As New Button() With {.Text = "← Back to Transactions", .Font = New Font("Segoe UI", 10), .ForeColor = Color.FromArgb(80, 80, 80), .FlatStyle = FlatStyle.Flat, .Location = New Point(0, 0), .AutoSize = True, .Cursor = Cursors.Hand}
        btnBack.FlatAppearance.BorderSize = 0
        AddHandler btnBack.Click, Sub() 
                                      pnlTransactDetailWrapper.Visible = False
                                      pnlTransactDashboard.Visible = True
                                  End Sub
        pnlDetailTop.Controls.Add(btnBack)

        lblTransactDetailTitle = New Label() With {.Text = "Receipt #", .Font = New Font("Segoe UI", 20, FontStyle.Bold), .ForeColor = Color.FromArgb(30, 30, 30), .Location = New Point(0, 35), .AutoSize = True}
        pnlDetailTop.Controls.Add(lblTransactDetailTitle)
        
        lblTransactDetailCustomer = New Label() With {.Text = "Customer: ", .Font = New Font("Segoe UI", 12), .ForeColor = Color.FromArgb(60, 60, 60), .Location = New Point(0, 75), .AutoSize = True}
        pnlDetailTop.Controls.Add(lblTransactDetailCustomer)
        
        lblTransactDetailDate = New Label() With {.Text = "Date: ", .Font = New Font("Segoe UI", 12), .ForeColor = Color.FromArgb(60, 60, 60), .Location = New Point(300, 75), .AutoSize = True}
        pnlDetailTop.Controls.Add(lblTransactDetailDate)

        pnlTransactDetailWrapper.Controls.Add(pnlDetailTop)

        ' Items Container
        Dim pnlDetailBody As New Panel() With {.Dock = DockStyle.Top, .AutoSize = True, .BackColor = Color.White, .Padding = New Padding(20)}
        
        Dim lblItemsHdr As New Label() With {.Text = "Order Items", .Font = New Font("Segoe UI", 14, FontStyle.Bold), .Dock = DockStyle.Top, .Height = 40}
        pnlDetailBody.Controls.Add(lblItemsHdr)
        
        Dim hdrLine As New Panel() With {.Dock = DockStyle.Top, .Height = 1, .BackColor = Color.FromArgb(200, 200, 200)}
        pnlDetailBody.Controls.Add(hdrLine)

        flpTransactionItems = New FlowLayoutPanel() With {.Dock = DockStyle.Top, .AutoSize = True, .FlowDirection = FlowDirection.TopDown, .WrapContents = False, .Padding = New Padding(0, 10, 0, 10)}
        pnlDetailBody.Controls.Add(flpTransactionItems)
        flpTransactionItems.BringToFront()
        
        Dim botLine As New Panel() With {.Dock = DockStyle.Bottom, .Height = 1, .BackColor = Color.FromArgb(200, 200, 200)}
        pnlDetailBody.Controls.Add(botLine)
        
        lblTransactDetailTotal = New Label() With {.Text = "Total: ₱0.00", .Font = New Font("Segoe UI", 16, FontStyle.Bold), .ForeColor = Color.FromArgb(0, 120, 215), .Dock = DockStyle.Bottom, .Height = 50, .TextAlign = ContentAlignment.MiddleRight, .Padding = New Padding(0, 10, 0, 0)}
        pnlDetailBody.Controls.Add(lblTransactDetailTotal)

        pnlTransactDetailWrapper.Controls.Add(pnlDetailBody)
        pnlMain.Controls.Add(pnlTransactDetailWrapper)

        ' Trigger reload when visible
        AddHandler pnlMain.VisibleChanged, Sub(s, ev)
                                               If pnlMain.Visible Then LoadTransactionsData()
                                           End Sub
        Return pnlMain
    End Function

    Private Sub LoadTransactionsData()
        If flpTransactions Is Nothing Then Return
        flpTransactions.Controls.Clear()

        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()

            Dim q As String = "SELECT P.Purchase_ID as Transaction_ID, P.Receipt_Number as Receipt_No, P.Purchase_Date as Date, C.Full_Name as Customer, IFNULL(SUM(PI.Quantity * PI.Item_Price), 0) as Total_Amount FROM PURCHASE P LEFT JOIN CUSTOMER C ON P.Customer_ID = C.Customer_ID LEFT JOIN PURCHASE_ITEMS PI ON P.Purchase_ID = PI.Purchase_ID GROUP BY P.Purchase_ID, P.Receipt_Number, P.Purchase_Date, C.Full_Name ORDER BY P.Purchase_ID DESC"
            
            Using cmd As New MySqlCommand(q, conn)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim pId = Convert.ToInt32(reader("Transaction_ID"))
                        Dim rNo = reader("Receipt_No").ToString()
                        Dim pDateStr = Convert.ToDateTime(reader("Date")).ToShortDateString()
                        Dim cName = reader("Customer").ToString()
                        Dim totalAmt = Convert.ToDecimal(reader("Total_Amount"))

                        Dim card As New Panel() With {.Size = New Size(280, 140), .Margin = New Padding(10), .BackColor = Color.White, .Cursor = Cursors.Hand}
                        AddHandler card.Paint, Sub(s, ev)
                                                   ev.Graphics.DrawRectangle(Pens.LightGray, 0, 0, card.Width - 1, card.Height - 1)
                                               End Sub
                        
                        Dim lblR As New Label() With {.Text = rNo, .Font = New Font("Segoe UI", 12, FontStyle.Bold), .Location = New Point(15, 15), .AutoSize = True, .ForeColor = Color.FromArgb(30, 30, 30)}
                        card.Controls.Add(lblR)
                        
                        Dim lblD As New Label() With {.Text = pDateStr, .Font = New Font("Segoe UI", 9), .Location = New Point(15, 45), .AutoSize = True, .ForeColor = Color.Gray}
                        card.Controls.Add(lblD)
                        
                        Dim lblC As New Label() With {.Text = cName, .Font = New Font("Segoe UI", 10), .Location = New Point(15, 75), .AutoSize = True, .ForeColor = Color.FromArgb(60, 60, 60)}
                        card.Controls.Add(lblC)
                        
                        Dim lblT As New Label() With {.Text = "₱" & totalAmt.ToString("N2"), .Font = New Font("Segoe UI", 12, FontStyle.Bold), .Location = New Point(15, 100), .AutoSize = True, .ForeColor = Color.FromArgb(0, 120, 215)}
                        card.Controls.Add(lblT)

                        Dim tagData As New Dictionary(Of String, String)
                        tagData("Purchase_ID") = pId.ToString()
                        tagData("Receipt_No") = rNo
                        tagData("Customer") = cName
                        tagData("Date") = pDateStr
                        tagData("Total") = totalAmt.ToString("N2")
                        card.Tag = tagData

                        Dim cardClickHandler = Sub(sCard As Object, eCard As EventArgs)
                                                   Dim tdata = DirectCast(card.Tag, Dictionary(Of String, String))
                                                   ShowTransactionDetails(Convert.ToInt32(tdata("Purchase_ID")), tdata("Receipt_No"), tdata("Customer"), tdata("Date"), Convert.ToDecimal(tdata("Total")))
                                               End Sub

                        AddHandler card.Click, cardClickHandler
                        For Each ctrl As Control In card.Controls
                            AddHandler ctrl.Click, cardClickHandler
                        Next

                        flpTransactions.Controls.Add(card)
                    End While
                End Using
            End Using
        Catch ex As Exception
            ' Handling empty DB initially softly
        End Try
    End Sub

    Private Sub ShowTransactionDetails(purchaseId As Integer, receiptNo As String, customer As String, dt As String, total As Decimal)
        lblTransactDetailTitle.Text = "Receipt " & receiptNo
        lblTransactDetailCustomer.Text = "Customer: " & customer
        lblTransactDetailDate.Text = "Date: " & dt
        lblTransactDetailTotal.Text = "Total: ₱" & total.ToString("N2")

        flpTransactionItems.Controls.Clear()

        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()

            Dim q As String = "SELECT PR.Product_Name as Name, PI.Quantity as Qty, PI.Item_Price as Price, (PI.Quantity * PI.Item_Price) as Subtotal FROM PURCHASE_ITEMS PI JOIN PRODUCT PR ON PI.Product_ID = PR.Product_ID WHERE PI.Purchase_ID = @pid"
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@pid", purchaseId)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim pName = reader("Name").ToString()
                        Dim qty = Convert.ToInt32(reader("Qty"))
                        Dim price = Convert.ToDecimal(reader("Price"))
                        Dim subtotal = Convert.ToDecimal(reader("Subtotal"))

                        Dim row As New Panel() With {.Width = pnlTransactDetailWrapper.Width - 100, .Height = 35}
                        
                        Dim lblName As New Label() With {.Text = pName, .Font = New Font("Segoe UI", 10), .Location = New Point(0, 5), .AutoSize = True}
                        row.Controls.Add(lblName)

                        Dim lblEq As New Label() With {.Text = qty.ToString() & " x ₱" & price.ToString("N2"), .Font = New Font("Segoe UI", 10), .Location = New Point(row.Width - 250, 5), .AutoSize = True, .ForeColor = Color.Gray}
                        row.Controls.Add(lblEq)

                        Dim lblSub As New Label() With {.Text = "₱" & subtotal.ToString("N2"), .Font = New Font("Segoe UI", 10, FontStyle.Bold), .Location = New Point(row.Width - 100, 5), .AutoSize = True, .TextAlign = ContentAlignment.MiddleRight}
                        row.Controls.Add(lblSub)

                        flpTransactionItems.Controls.Add(row)
                    End While
                End Using
            End Using
        Catch ex As Exception
        End Try

        pnlTransactDashboard.Visible = False
        pnlTransactDetailWrapper.Visible = True
    End Sub

    Private Sub LoadDashboardData()
        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()

            Dim dateCondition As String = ""
            Dim dateConditionAct As String = ""
            If _cmbDashTimeFilter IsNot Nothing AndAlso _cmbDashTimeFilter.SelectedItem IsNot Nothing Then
                Select Case _cmbDashTimeFilter.SelectedItem.ToString()
                    Case "Today"
                        dateCondition = " AND DATE({0}) = CURDATE()"
                        dateConditionAct = " WHERE DATE(ActDate) = CURDATE()"
                    Case "This Week"
                        dateCondition = " AND YEARWEEK({0}, 1) = YEARWEEK(CURDATE(), 1)"
                        dateConditionAct = " WHERE YEARWEEK(ActDate, 1) = YEARWEEK(CURDATE(), 1)"
                    Case "This Month"
                        dateCondition = " AND YEAR({0}) = YEAR(CURDATE()) AND MONTH({0}) = MONTH(CURDATE())"
                        dateConditionAct = " WHERE YEAR(ActDate) = YEAR(CURDATE()) AND MONTH(ActDate) = MONTH(CURDATE())"
                    Case "This Year"
                        dateCondition = " AND YEAR({0}) = YEAR(CURDATE())"
                        dateConditionAct = " WHERE YEAR(ActDate) = YEAR(CURDATE())"
                End Select
            End If

            ' Overview Metrics
            Dim qSales = "SELECT IFNULL(SUM(PI.Quantity * PI.Item_Price), 0) FROM PURCHASE_ITEMS PI JOIN PURCHASE P ON PI.Purchase_ID = P.Purchase_ID WHERE 1=1" & String.Format(dateCondition, "P.Purchase_Date")
            Using cmd As New MySqlCommand(qSales, conn)
                lblCard1Value.Text = "₱" & Convert.ToDecimal(cmd.ExecuteScalar()).ToString("N2")
            End Using

            ' Products are general stock, date filter usually doesn't apply to total physical goods.
            Dim qProd = "SELECT COUNT(*) FROM PRODUCT"
            Using cmd As New MySqlCommand(qProd, conn)
                lblCard2Value.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString()
            End Using

            Dim qSvc = "SELECT COUNT(*) FROM SERVICE_REQUEST WHERE Request_Status NOT IN ('Completed', 'Cancelled')" & String.Format(dateCondition, "Request_Date")
            Using cmd As New MySqlCommand(qSvc, conn)
                lblCard3Value.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString()
            End Using

            Dim qWar = "SELECT COUNT(*) FROM WARRANTY WHERE Warranty_Status = 'Active'" & String.Format(dateCondition, "Warranty_Start_Date")
            Using cmd As New MySqlCommand(qWar, conn)
                lblCard4Value.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString()
            End Using

            ' Recent Activity
            If flpRecentActivity IsNot Nothing Then
                flpRecentActivity.Controls.Clear()
                Dim baseQ = "SELECT 'Order' as Type, CONCAT('New purchase receipt ', Receipt_Number) as Activity, Purchase_Date as ActDate FROM PURCHASE " &
                            "UNION ALL " &
                            "SELECT 'Service' as Type, CONCAT('Service request #', Request_ID, ' filed for customer ', Customer_ID) as Activity, Request_Date as ActDate FROM SERVICE_REQUEST " &
                            "UNION ALL " &
                            "SELECT 'Warranty' as Type, CONCAT('Warranty claim #', Claim_ID, ' submitted') as Activity, Claim_Date as ActDate FROM WARRANTY_CLAIM "
                Dim qAct = "SELECT * FROM (" & baseQ & ") AS Combined" & dateConditionAct & " ORDER BY ActDate DESC LIMIT 10"

                Using cmd As New MySqlCommand(qAct, conn)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim type = reader("Type").ToString()
                            Dim act = reader("Activity").ToString()
                            Dim actDate = Convert.ToDateTime(reader("ActDate")).ToShortDateString()

                            Dim row As New Panel() With {.Width = pnlDashboard.Width - 60, .Height = 40, .BackColor = Color.White, .Margin = New Padding(5), .Cursor = Cursors.Hand}
                            
                            Dim lblType As New Label() With {.Text = If(type = "Order", "🛒 Order", If(type = "Service", "🔧 Service", "🛡️ Warranty")), .Font = New Font("Segoe UI", 10, FontStyle.Bold), .Location = New Point(10, 10), .AutoSize = True, .ForeColor = Color.FromArgb(0, 120, 215)}
                            row.Controls.Add(lblType)

                            Dim lblAct As New Label() With {.Text = act, .Font = New Font("Segoe UI", 10), .Location = New Point(120, 10), .AutoSize = True, .ForeColor = Color.FromArgb(60, 60, 60)}
                            row.Controls.Add(lblAct)

                            Dim lblD As New Label() With {.Text = actDate, .Font = New Font("Segoe UI", 9), .Dock = DockStyle.Right, .Padding = New Padding(0, 10, 10, 0), .AutoSize = True, .ForeColor = Color.Gray}
                            row.Controls.Add(lblD)

                            Dim clickHandler = Sub(sRow As Object, eRow As EventArgs)
                                                   If type = "Order" Then btnTransactions_Click(Nothing, EventArgs.Empty)
                                                   If type = "Service" Then btnServiceRequests_Click(Nothing, EventArgs.Empty)
                                                   If type = "Warranty" Then btnWarrantyClaims_Click(Nothing, EventArgs.Empty)
                                               End Sub
                            AddHandler row.Click, clickHandler
                            For Each child As Control In row.Controls
                                AddHandler child.Click, clickHandler
                                child.Cursor = Cursors.Hand
                            Next
                            
                            flpRecentActivity.Controls.Add(row)
                        End While
                    End Using
                End Using
            End If
        Catch ex As Exception
            ' Silent catch
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════
    '  ADMIN MODULE
    ' ═══════════════════════════════════════════════════

    Private Function BuildAdminContainer() As Panel
        Dim pnlMain As New Panel() With {.Dock = DockStyle.Fill, .BackColor = Color.FromArgb(245, 245, 248), .Visible = False}

        ' --- 1. Login State ---
        pnlAdminLogin = New Panel() With {.Dock = DockStyle.Fill, .BackColor = Color.FromArgb(240, 240, 245)}
        Dim pnlLoginBox As New Panel() With {.Size = New Size(350, 300), .BackColor = Color.White}
        
        pnlLoginBox.Location = New Point(Math.Max((pnlMainContent.Width - pnlLoginBox.Width) / 2, 100), Math.Max((pnlMainContent.Height - pnlLoginBox.Height) / 2, 100))
        pnlLoginBox.Anchor = AnchorStyles.None ' to keep it centered
        
        Dim lblLoginTitle As New Label() With {.Text = "Admin Access", .Font = New Font("Segoe UI", 16, FontStyle.Bold), .ForeColor = Color.FromArgb(30, 30, 30), .Location = New Point(30, 30), .AutoSize = True}
        pnlLoginBox.Controls.Add(lblLoginTitle)

        Dim lblU As New Label() With {.Text = "Username", .Font = New Font("Segoe UI", 10), .Location = New Point(30, 80), .AutoSize = True}
        pnlLoginBox.Controls.Add(lblU)
        txtAdminUser = New TextBox() With {.Font = New Font("Segoe UI", 11), .Location = New Point(30, 105), .Width = 290}
        pnlLoginBox.Controls.Add(txtAdminUser)
        
        Dim lblP As New Label() With {.Text = "Password", .Font = New Font("Segoe UI", 10), .Location = New Point(30, 150), .AutoSize = True}
        pnlLoginBox.Controls.Add(lblP)
        txtAdminPass = New TextBox() With {.Font = New Font("Segoe UI", 11), .Location = New Point(30, 175), .Width = 290, .PasswordChar = "*"}
        pnlLoginBox.Controls.Add(txtAdminPass)

        Dim btnLogin As New Button() With {.Text = "Login", .Font = New Font("Segoe UI", 11, FontStyle.Bold), .ForeColor = Color.White, .BackColor = Color.FromArgb(0, 120, 215), .FlatStyle = FlatStyle.Flat, .Location = New Point(30, 230), .Size = New Size(290, 40), .Cursor = Cursors.Hand}
        btnLogin.FlatAppearance.BorderSize = 0
        AddHandler btnLogin.Click, Sub()
                                       Dim approved As Boolean = False
                                       Try
                                           Dim q As String = "SELECT COUNT(*) FROM ADMIN_CREDENTIALS WHERE username=@u AND password=@p AND id=1"
                                           Using cmd As New MySqlCommand(q, conn)
                                               cmd.Parameters.AddWithValue("@u", txtAdminUser.Text)
                                               cmd.Parameters.AddWithValue("@p", txtAdminPass.Text)
                                               If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then approved = True
                                           End Using
                                       Catch e As Exception
                                       End Try

                                       If approved Then
                                           txtAdminUser.Text = ""
                                           txtAdminPass.Text = ""
                                           Dim frmAdmin As New admin()
                                           frmAdmin.StartPosition = FormStartPosition.CenterScreen
                                           
                                           Me.Hide()
                                           frmAdmin.ShowDialog()
                                           
                                           ' Reset to dashboard to avoid lingering on login screen
                                           SetActiveButton(btnDashboard)
                                           ShowPanel(pnlDashboard)
                                           
                                           Me.Show()
                                       Else
                                           MessageBox.Show("Invalid User or Password", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                       End If
                                   End Sub
        pnlLoginBox.Controls.Add(btnLogin)

        ' Logic to center box initially
        AddHandler pnlMain.VisibleChanged, Sub()
                                               If pnlMain.Visible Then
                                                    pnlLoginBox.Location = New Point((pnlMain.Width - pnlLoginBox.Width) / 2, (pnlMain.Height - pnlLoginBox.Height) / 2)
                                               End If
                                           End Sub
        AddHandler pnlMain.Resize, Sub()
                                       pnlLoginBox.Location = New Point((pnlMain.Width - pnlLoginBox.Width) / 2, (pnlMain.Height - pnlLoginBox.Height) / 2)
                                   End Sub

        pnlAdminLogin.Controls.Add(pnlLoginBox)
        pnlMain.Controls.Add(pnlAdminLogin)

        Return pnlMain
    End Function

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Close database connection
        CloseConnection()
    End Sub

End Class
