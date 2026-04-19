Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO

Public Class admin
    ' Global DB config
    Private connString As String = "server=localhost;userid=root;password=;database=mideaproshop"
    Private conn As MySqlConnection

    ' UI Components
    Private pnlAdminMainContent As Panel
    Private flpRecentActivity As FlowLayoutPanel
    Private _cmbDashTimeFilter As ComboBox
    Private lblCard1Value, lblCard2Value, lblCard3Value, lblCard4Value As Label

    Private _activeAdminButton As Button = Nothing
    Private _panels As New Dictionary(Of String, Panel)

    ' Inventory Components
    Private pnlInvenDashboard As Panel
    Private flpInvenStockCards As FlowLayoutPanel
    Private _activeInvenCategoryBtn As Button = Nothing
    Private pnlInvenEditor As Panel

    ' Reports Components
    Private pnlAdminReports As Panel
    Private chartSales As Chart
    Private dgvOrders As DataGridView
    Private txtAdminRepoSearch As TextBox

    ' Service Requests Components
    Private pnlAdminSRDashboard As Panel
    Private flpAdminSRCards As FlowLayoutPanel
    Private _cmbAdminSRStatusFilter As ComboBox
    Private pnlAdminSREditor As Panel
    Private _editSRId As Integer = 0
    Private cmbAdminSREditStatus As ComboBox
    Private dtpAdminSREditSched As DateTimePicker
    Private _optSRNewCust As RadioButton
    Private _optSRExistCust As RadioButton
    Private _pnlSRNewCust, _pnlSRExistCust As Panel
    Private _txtSRNewCustName, _txtSRNewCustContact, _txtSRNewCustAddress As TextBox
    Private _cmbSRExistCust, _cmbSRService, _cmbSRStaff, _cmbSRTechnician, _cmbSRWarranty As ComboBox
    Private dtpSRRequestDate, dtpSRCompleted As DateTimePicker
    Private txtSRAddress As TextBox

    ' Warranty Claims Components
    Private pnlAdminWCDashboard As Panel
    Private flpAdminWCCards As FlowLayoutPanel
    Private _cmbAdminWCStatusFilter As ComboBox
    Private pnlAdminWCEditor As Panel
    Private _editWCId As Integer = 0
    Private cmbAdminWCEditStatus As ComboBox

    ' Editor Fields
    Private _editProductId As Integer = 0
    Private txtInvName, txtInvBrand, txtInvDesc As TextBox
    Private numInvPrice, numInvStock, numInvReorder As NumericUpDown
    Private cmbInvCategory As ComboBox

    ' Settings Fields
    Private txtSettingsUser, txtSettingsPass As TextBox

    Private Sub OpenConnection()
        If conn Is Nothing Then conn = New MySqlConnection(connString)
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub

    Private Sub CloseConnection()
        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
    End Sub

    Private Sub admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1084, 700)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.BackColor = Color.FromArgb(245, 245, 248)
        Me.Text = "Admin Dashboard"

        Dim pnlAdminInterface As New Panel() With {.Dock = DockStyle.Fill, .Visible = True, .BackColor = Color.FromArgb(245, 245, 248)}

        ' --- SIDEBAR ---
        Dim pnlAdminSidebar As New Panel() With {.Dock = DockStyle.Left, .Width = 220, .BackColor = Color.FromArgb(30, 30, 40)}
        Dim lblAdminSideTitle As New Label() With {.Text = "ADMIN PANEL", .Font = New Font("Segoe UI", 16, FontStyle.Bold), .ForeColor = Color.White, .Dock = DockStyle.Top, .Height = 80, .TextAlign = ContentAlignment.MiddleCenter}
        pnlAdminSidebar.Controls.Add(lblAdminSideTitle)

        Dim btnLogout As New Button() With {.Dock = DockStyle.Bottom, .Height = 50, .FlatStyle = FlatStyle.Flat, .Text = "   Logout", .TextAlign = ContentAlignment.MiddleLeft, .Font = New Font("Segoe UI", 10, FontStyle.Bold), .ForeColor = Color.FromArgb(250, 100, 100), .Cursor = Cursors.Hand, .Padding = New Padding(15, 0, 0, 0)}
        btnLogout.FlatAppearance.BorderSize = 0
        AddHandler btnLogout.Click, Sub() Me.Close()
        pnlAdminSidebar.Controls.Add(btnLogout)

        InitializeAdminPanel(pnlAdminInterface, pnlAdminSidebar, lblAdminSideTitle)
    End Sub

    Private Sub InitializeAdminPanel(pnlAdminInterface As Panel, pnlSidebar As Panel, lblAdminSideTitle As Label)
        pnlAdminMainContent = New Panel() With {.Dock = DockStyle.Fill, .BackColor = Color.FromArgb(245, 245, 248)}
        pnlAdminInterface.Controls.Add(pnlAdminMainContent)
        pnlAdminInterface.Controls.Add(pnlSidebar)
        Me.Controls.Add(pnlAdminInterface)

        ' Build panels
        _panels.Add("Dashboard", BuildDashboardPanel())
        _panels.Add("Reports", BuildAdminReports())
        _panels.Add("Service Requests", BuildAdminServiceRequests())
        _panels.Add("Warranty Claims", BuildAdminWarrantyClaims())
        _panels.Add("Inventory", BuildInventoryDashboard())
        _panels.Add("Settings", BuildSettingsPanel())

        Dim btnNames() As String = {"Settings", "Reports", "Service Requests", "Warranty Claims", "Inventory", "Dashboard"}
        Dim navBtns As New List(Of Button)

        For Each bName In btnNames
            pnlAdminMainContent.Controls.Add(_panels(bName))

            Dim btn As New Button() With {.Dock = DockStyle.Top, .Height = 50, .FlatStyle = FlatStyle.Flat, .Text = "   " & bName, .TextAlign = ContentAlignment.MiddleLeft, .Font = New Font("Segoe UI", 10), .ForeColor = Color.White, .Cursor = Cursors.Hand, .Padding = New Padding(15, 0, 0, 0)}
            btn.FlatAppearance.BorderSize = 0
            btn.Tag = bName
            pnlSidebar.Controls.Add(btn)
            navBtns.Add(btn)

            AddHandler btn.Click, Sub(s, ev)
                                      For Each nb In navBtns
                                          nb.BackColor = Color.FromArgb(30, 30, 40)
                                      Next
                                      btn.BackColor = Color.FromArgb(60, 60, 70)

                                      For Each p In _panels.Values
                                          p.Visible = False
                                      Next
                                      _panels(btn.Tag.ToString()).Visible = True

                                      If btn.Tag.ToString() = "Dashboard" Then LoadDashboardData()
                                  End Sub
        Next

        lblAdminSideTitle.SendToBack()
        navBtns.First(Function(b) b.Tag.ToString() = "Dashboard").PerformClick()
    End Sub

    ' ═══════════════════════════════════════════════════
    '  SETTINGS PANEL
    ' ═══════════════════════════════════════════════════
    Private Function BuildSettingsPanel() As Panel
        Dim pnl As New Panel() With {.Dock = DockStyle.Fill, .BackColor = Color.FromArgb(245, 245, 248), .Visible = False}

        ' Title bar
        Dim pnlTop As New Panel() With {.Dock = DockStyle.Top, .Height = 80, .Padding = New Padding(20)}
        Dim lblTitle As New Label() With {.Text = "System Settings", .Font = New Font("Segoe UI", 20, FontStyle.Bold), .ForeColor = Color.FromArgb(30, 30, 30), .AutoSize = True, .Location = New Point(20, 20)}
        pnlTop.Controls.Add(lblTitle)
        pnl.Controls.Add(pnlTop)

        Dim pnlContent As New Panel() With {.Location = New Point(20, 100), .Size = New Size(500, 300), .BackColor = Color.White, .BorderStyle = BorderStyle.FixedSingle}

        Dim lblHeader As New Label() With {.Text = "Admin Credentials", .Font = New Font("Segoe UI", 16, FontStyle.Bold), .Location = New Point(20, 20), .AutoSize = True}
        pnlContent.Controls.Add(lblHeader)

        Dim lblU As New Label() With {.Text = "Username:", .Font = New Font("Segoe UI", 10), .Location = New Point(20, 80), .AutoSize = True}
        txtSettingsUser = New TextBox() With {.Location = New Point(150, 80), .Width = 260, .Font = New Font("Segoe UI", 10)}
        pnlContent.Controls.Add(lblU)
        pnlContent.Controls.Add(txtSettingsUser)

        Dim lblP As New Label() With {.Text = "Password:", .Font = New Font("Segoe UI", 10), .Location = New Point(20, 120), .AutoSize = True}
        txtSettingsPass = New TextBox() With {.Location = New Point(150, 120), .Width = 260, .Font = New Font("Segoe UI", 10), .PasswordChar = "*"}
        pnlContent.Controls.Add(lblP)
        pnlContent.Controls.Add(txtSettingsPass)

        Dim cbShowP As New CheckBox() With {.Text = "Show Password", .Location = New Point(150, 160), .AutoSize = True, .Font = New Font("Segoe UI", 9)}
        AddHandler cbShowP.CheckedChanged, Sub() txtSettingsPass.PasswordChar = If(cbShowP.Checked, ControlChars.NullChar, "*"c)
        pnlContent.Controls.Add(cbShowP)

        Dim btnSaveSettings As New Button() With {.Text = "Save Credentials", .Font = New Font("Segoe UI", 10, FontStyle.Bold), .BackColor = Color.FromArgb(0, 120, 215), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Location = New Point(150, 210), .Size = New Size(260, 40), .Cursor = Cursors.Hand}
        btnSaveSettings.FlatAppearance.BorderSize = 0
        AddHandler btnSaveSettings.Click, AddressOf SaveSettings_Click
        pnlContent.Controls.Add(btnSaveSettings)

        pnl.Controls.Add(pnlContent)

        ' Pre-load logic when panel becomes visible
        AddHandler pnl.VisibleChanged, Sub(s, ev)
                                           If pnl.Visible Then LoadSettingsCredentials()
                                       End Sub

        Return pnl
    End Function

    Private Sub LoadSettingsCredentials()
        Try
            OpenConnection()
            Dim q As String = "SELECT username, password FROM ADMIN_CREDENTIALS WHERE id=1"
            Using cmd As New MySqlCommand(q, conn)
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        txtSettingsUser.Text = reader("username").ToString()
                        txtSettingsPass.Text = reader("password").ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SaveSettings_Click(sender As Object, e As EventArgs)
        If txtSettingsUser.Text.Trim() = "" Or txtSettingsPass.Text.Trim() = "" Then
            MessageBox.Show("Credentials cannot be blank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Try
            OpenConnection()
            Dim q As String = "UPDATE ADMIN_CREDENTIALS SET username=@u, password=@p WHERE id=1"
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@u", txtSettingsUser.Text.Trim())
                cmd.Parameters.AddWithValue("@p", txtSettingsPass.Text.Trim())
                cmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("Admin credentials updated successfully!" & vbCrLf & "Please use these upon your next login.", "Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Failed to update credentials: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════
    '  REPORTS & DATA VISUALIZATION
    ' ═══════════════════════════════════════════════════
    Private Function BuildAdminReports() As Panel
        pnlAdminReports = New Panel() With {.Dock = DockStyle.Fill, .BackColor = Color.FromArgb(245, 245, 248), .Visible = False}

        ' Top Title Bar
        Dim pnlTop As New Panel() With {.Dock = DockStyle.Top, .Height = 80, .Padding = New Padding(20)}
        Dim lblTitle As New Label() With {.Text = "Sales Report", .Font = New Font("Segoe UI", 20, FontStyle.Bold), .ForeColor = Color.FromArgb(30, 30, 30), .AutoSize = True, .Location = New Point(20, 20)}
        pnlTop.Controls.Add(lblTitle)

        Dim lblSearch As New Label() With {.Text = "Search:", .Font = New Font("Segoe UI", 10), .AutoSize = True}
        pnlTop.Controls.Add(lblSearch)

        txtAdminRepoSearch = New TextBox() With {.Font = New Font("Segoe UI", 10), .Size = New Size(200, 25)}
        AddHandler txtAdminRepoSearch.TextChanged, Sub() LoadAdminReportsData()
        pnlTop.Controls.Add(txtAdminRepoSearch)

        Dim btnRefresh As New Button() With {.Text = "Refresh Data", .Font = New Font("Segoe UI", 10, FontStyle.Bold), .BackColor = Color.FromArgb(0, 120, 215), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Size = New Size(140, 35), .Cursor = Cursors.Hand}
        btnRefresh.FlatAppearance.BorderSize = 0
        AddHandler btnRefresh.Click, Sub() LoadAdminReportsData()
        pnlTop.Controls.Add(btnRefresh)

        Dim btnExport As New Button() With {.Text = "Export Excel", .Font = New Font("Segoe UI", 10, FontStyle.Bold), .BackColor = Color.FromArgb(40, 167, 69), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Size = New Size(140, 35), .Cursor = Cursors.Hand}
        btnExport.FlatAppearance.BorderSize = 0
        AddHandler btnExport.Click, Sub() ExportReportsToExcel()
        pnlTop.Controls.Add(btnExport)

        AddHandler pnlTop.Resize, Sub()
                                      btnRefresh.Location = New Point(pnlTop.Width - 160, 25)
                                      btnExport.Location = New Point(pnlTop.Width - 310, 25)
                                      txtAdminRepoSearch.Location = New Point(pnlTop.Width - 530, 28)
                                      lblSearch.Location = New Point(pnlTop.Width - 590, 30)
                                  End Sub

        pnlAdminReports.Controls.Add(pnlTop)

        ' Container for Graph & Table
        Dim pnlContent As New Panel() With {.Dock = DockStyle.Fill, .Padding = New Padding(20)}
        pnlAdminReports.Controls.Add(pnlContent)
        pnlContent.BringToFront()

        ' Split structure
        Dim tlpHolder As New TableLayoutPanel() With {.Dock = DockStyle.Fill, .RowCount = 2, .ColumnCount = 1}
        tlpHolder.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
        tlpHolder.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
        pnlContent.Controls.Add(tlpHolder)

        ' 1. The Chart
        chartSales = New Chart() With {.Dock = DockStyle.Fill, .BackColor = Color.White, .MinimumSize = New Size(10, 10)}
        Dim chartArea As New ChartArea("SalesArea")
        chartArea.AxisX.MajorGrid.LineColor = Color.LightGray
        chartArea.AxisY.MajorGrid.LineColor = Color.LightGray
        chartSales.ChartAreas.Add(chartArea)

        Dim series As New Series("Gross Sales")
        series.ChartType = SeriesChartType.SplineArea
        series.BorderWidth = 3
        series.Color = Color.FromArgb(150, 0, 120, 215)
        series.BorderColor = Color.FromArgb(0, 120, 215)
        chartSales.Series.Add(series)

        Dim pnlChartBdr As New Panel() With {.Dock = DockStyle.Fill, .Margin = New Padding(0, 0, 0, 10), .Padding = New Padding(1), .BackColor = Color.LightGray}
        pnlChartBdr.Controls.Add(chartSales)
        tlpHolder.Controls.Add(pnlChartBdr, 0, 0)

        ' 2. The Data Table
        dgvOrders = New DataGridView() With {
            .Dock = DockStyle.Fill,
            .BackgroundColor = Color.White,
            .BorderStyle = BorderStyle.None,
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .ReadOnly = True,
            .RowHeadersVisible = False,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            .Font = New Font("Segoe UI", 10),
            .GridColor = Color.FromArgb(230, 230, 230)
        }
        Dim pnlGridBdr As New Panel() With {.Dock = DockStyle.Fill, .Margin = New Padding(0, 10, 0, 0), .Padding = New Padding(1), .BackColor = Color.LightGray}
        pnlGridBdr.Controls.Add(dgvOrders)
        tlpHolder.Controls.Add(pnlGridBdr, 0, 1)

        AddHandler pnlAdminReports.VisibleChanged, Sub(s, ev)
                                                       If pnlAdminReports.Visible Then LoadAdminReportsData()
                                                   End Sub
        Return pnlAdminReports
    End Function

    Private Sub LoadAdminReportsData()
        Try
            OpenConnection()

            ' 1. Load Chart Data (Sales per day)
            Dim qChart As String = "SELECT DATE(P.Purchase_Date) as SalesDate, IFNULL(SUM(PI.Quantity * PI.Item_Price), 0) as DailyTotal " &
                                   "FROM PURCHASE P " &
                                   "LEFT JOIN PURCHASE_ITEMS PI ON P.Purchase_ID = PI.Purchase_ID " &
                                   "GROUP BY DATE(P.Purchase_Date) ORDER BY SalesDate ASC LIMIT 30"
            Using cmd As New MySqlCommand(qChart, conn)
                Using reader = cmd.ExecuteReader()
                    chartSales.Series("Gross Sales").Points.Clear()
                    While reader.Read()
                        Dim sDate = Convert.ToDateTime(reader("SalesDate")).ToShortDateString()
                        Dim dTotal = Convert.ToDouble(reader("DailyTotal"))
                        chartSales.Series("Gross Sales").Points.AddXY(sDate, dTotal)
                    End While
                End Using
            End Using

            ' 2. Load Table Data (Recent Orders)
            Dim qTable As String = "SELECT P.Purchase_ID as 'Order ID', C.Full_Name as Customer, P.Purchase_Date as 'Date', " &
                                   "IFNULL((SELECT SUM(Quantity * Item_Price) FROM PURCHASE_ITEMS WHERE Purchase_ID = P.Purchase_ID), 0) as 'Total' " &
                                   "FROM PURCHASE P JOIN CUSTOMER C ON P.Customer_ID = C.Customer_ID "

            Dim searchTxt = If(txtAdminRepoSearch IsNot Nothing, txtAdminRepoSearch.Text.Trim(), "")
            If Not String.IsNullOrEmpty(searchTxt) Then
                qTable &= "WHERE C.Full_Name LIKE @search OR P.Purchase_ID LIKE @search "
            End If
            qTable &= "ORDER BY P.Purchase_Date DESC"

            Dim dtOrders As New DataTable()
            Using da As New MySqlDataAdapter(qTable, conn)
                If Not String.IsNullOrEmpty(searchTxt) Then
                    da.SelectCommand.Parameters.AddWithValue("@search", "%" & searchTxt & "%")
                End If
                da.Fill(dtOrders)
            End Using
            dgvOrders.DataSource = dtOrders

            If dgvOrders.Columns.Count > 0 Then
                dgvOrders.Columns("Total").DefaultCellStyle.Format = "N2"
                dgvOrders.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub ExportReportsToExcel()
        If dgvOrders Is Nothing OrElse dgvOrders.Rows.Count = 0 Then
            MessageBox.Show("There is no order data to export.", "Export Blocked", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using sfd As New SaveFileDialog()
            sfd.Filter = "CSV Excel Format (*.csv)|*.csv|All files (*.*)|*.*"
            sfd.FileName = "MideaProShop_Reports_" & DateTime.Now.ToString("yyyyMMdd") & ".csv"
            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    Using sw As New StreamWriter(sfd.FileName)
                        Dim headers As New List(Of String)
                        For Each col As DataGridViewColumn In dgvOrders.Columns
                            headers.Add("""" & col.HeaderText & """")
                        Next
                        sw.WriteLine(String.Join(",", headers))

                        For Each row As DataGridViewRow In dgvOrders.Rows
                            If Not row.IsNewRow Then
                                Dim cells As New List(Of String)
                                For Each cell As DataGridViewCell In row.Cells
                                    Dim cellVal = If(cell.Value IsNot Nothing, cell.Value.ToString().Replace("""", """"""), "")
                                    cells.Add("""" & cellVal & """")
                                Next
                                sw.WriteLine(String.Join(",", cells))
                            End If
                        Next
                    End Using
                    MessageBox.Show("Data successfully exported to Excel format!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Error writing file: " & ex.Message, "Output Fault", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    ' ═══════════════════════════════════════════════════
    '  SERVICE REQUESTS CRUD PANEL
    ' ═══════════════════════════════════════════════════
    Private Function BuildAdminServiceRequests() As Panel
        pnlAdminSRDashboard = New Panel() With {.Dock = DockStyle.Fill, .BackColor = Color.FromArgb(245, 245, 248), .Visible = False}

        ' Title bar
        Dim pnlTop As New Panel() With {.Dock = DockStyle.Top, .Height = 80, .Padding = New Padding(20)}
        Dim lblTitle As New Label() With {.Text = "Service Requests Management", .Font = New Font("Segoe UI", 20, FontStyle.Bold), .ForeColor = Color.FromArgb(30, 30, 30), .AutoSize = True, .Location = New Point(20, 20)}
        pnlTop.Controls.Add(lblTitle)

        Dim lblFilter As New Label() With {.Text = "Filter Status:", .Font = New Font("Segoe UI", 10), .AutoSize = True}
        pnlTop.Controls.Add(lblFilter)
        _cmbAdminSRStatusFilter = New ComboBox() With {.DropDownStyle = ComboBoxStyle.DropDownList, .Font = New Font("Segoe UI", 10), .Size = New Size(150, 25)}
        _cmbAdminSRStatusFilter.Items.AddRange(New String() {"All", "Pending", "Scheduled", "In Progress", "Completed", "Cancelled"})
        _cmbAdminSRStatusFilter.SelectedIndex = 0
        AddHandler _cmbAdminSRStatusFilter.SelectedIndexChanged, Sub() LoadAdminServiceRequestsCards()
        pnlTop.Controls.Add(_cmbAdminSRStatusFilter)

        Dim btnAdd As New Button() With {.Text = "+ Add Request", .Font = New Font("Segoe UI", 10, FontStyle.Bold), .BackColor = Color.FromArgb(0, 153, 102), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Size = New Size(140, 35), .Cursor = Cursors.Hand}
        btnAdd.FlatAppearance.BorderSize = 0
        AddHandler btnAdd.Click, Sub() ShowAdminSREditor(0)
        pnlTop.Controls.Add(btnAdd)

        AddHandler pnlTop.Resize, Sub()
                                      btnAdd.Location = New Point(pnlTop.Width - 170, 25)
                                      _cmbAdminSRStatusFilter.Location = New Point(pnlTop.Width - 340, 28)
                                      lblFilter.Location = New Point(pnlTop.Width - 430, 30)
                                  End Sub

        pnlAdminSRDashboard.Controls.Add(pnlTop)

        flpAdminSRCards = New FlowLayoutPanel() With {.Dock = DockStyle.Fill, .AutoScroll = True, .Padding = New Padding(20), .BackColor = Color.FromArgb(245, 245, 248)}
        pnlAdminSRDashboard.Controls.Add(flpAdminSRCards)
        flpAdminSRCards.BringToFront()

        BuildAdminSREditor()

        AddHandler pnlAdminSRDashboard.Resize, Sub() If pnlAdminSREditor.Visible Then pnlAdminSREditor.Location = New Point((pnlAdminSRDashboard.Width - pnlAdminSREditor.Width) / 2, (pnlAdminSRDashboard.Height - pnlAdminSREditor.Height) / 2)

        AddHandler pnlAdminSRDashboard.VisibleChanged, Sub(s, ev)
                                                           If pnlAdminSRDashboard.Visible Then LoadAdminServiceRequestsCards()
                                                       End Sub
        Return pnlAdminSRDashboard
    End Function

    Private Sub BuildAdminSREditor()
        pnlAdminSREditor = New Panel() With {.Size = New Size(540, 640), .BackColor = Color.White, .Visible = False, .BorderStyle = BorderStyle.FixedSingle, .AutoScroll = True}

        Dim lblHeader As New Label() With {.Text = "Service Request Form", .Font = New Font("Segoe UI", 16, FontStyle.Bold), .Location = New Point(20, 15), .AutoSize = True}
        pnlAdminSREditor.Controls.Add(lblHeader)

        Dim yLoc As Integer = 55

        Dim lblCustSel As New Label() With {.Text = "Customer Selection", .Font = New Font("Segoe UI", 10, FontStyle.Bold), .Location = New Point(20, yLoc), .AutoSize = True}
        pnlAdminSREditor.Controls.Add(lblCustSel)
        yLoc += 25

        _optSRNewCust = New RadioButton() With {.Text = "New Customer", .Font = New Font("Segoe UI", 9.5F), .Location = New Point(20, yLoc), .AutoSize = True, .Checked = True}
        _optSRExistCust = New RadioButton() With {.Text = "Existing Customer", .Font = New Font("Segoe UI", 9.5F), .Location = New Point(150, yLoc), .AutoSize = True}
        pnlAdminSREditor.Controls.Add(_optSRNewCust)
        pnlAdminSREditor.Controls.Add(_optSRExistCust)
        yLoc += 25

        _pnlSRNewCust = New Panel() With {.Location = New Point(20, yLoc), .Size = New Size(480, 100), .BackColor = Color.White}
        Dim ny As Integer = 0
        Dim addTxt = Function(lblText As String, pnl As Panel) As TextBox
                         Dim lbl As New Label() With {.Text = lblText, .Font = New Font("Segoe UI", 9.0F), .Location = New Point(0, ny), .AutoSize = True}
                         pnl.Controls.Add(lbl)
                         Dim txt As New TextBox() With {.Font = New Font("Segoe UI", 9.5F), .Location = New Point(120, ny - 2), .Width = 340}
                         pnl.Controls.Add(txt)
                         ny += 30
                         Return txt
                     End Function
        _txtSRNewCustName = addTxt("Full Name:", _pnlSRNewCust)
        _txtSRNewCustContact = addTxt("Contact Number:", _pnlSRNewCust)
        _txtSRNewCustAddress = addTxt("Home Address:", _pnlSRNewCust)
        pnlAdminSREditor.Controls.Add(_pnlSRNewCust)

        _pnlSRExistCust = New Panel() With {.Location = New Point(20, yLoc), .Size = New Size(480, 100), .BackColor = Color.White, .Visible = False}
        Dim lblE1 As New Label() With {.Text = "Search Customer:", .Font = New Font("Segoe UI", 9.0F), .Location = New Point(0, 5), .AutoSize = True}
        _pnlSRExistCust.Controls.Add(lblE1)
        _cmbSRExistCust = New ComboBox() With {.Font = New Font("Segoe UI", 9.5F), .Location = New Point(120, 3), .Size = New Size(340, 25), .DropDownStyle = ComboBoxStyle.DropDown}
        AddHandler _cmbSRExistCust.SelectedIndexChanged, Sub() LoadAdminSRWarrantiesForCustomer()
        _pnlSRExistCust.Controls.Add(_cmbSRExistCust)

        Dim lblE2 As New Label() With {.Text = "Assoc. Warranty:", .Font = New Font("Segoe UI", 9.0F), .Location = New Point(0, 40), .AutoSize = True}
        _pnlSRExistCust.Controls.Add(lblE2)
        _cmbSRWarranty = New ComboBox() With {.Font = New Font("Segoe UI", 9.5F), .Location = New Point(120, 38), .Size = New Size(340, 25), .DropDownStyle = ComboBoxStyle.DropDownList}
        _pnlSRExistCust.Controls.Add(_cmbSRWarranty)
        pnlAdminSREditor.Controls.Add(_pnlSRExistCust)

        AddHandler _optSRNewCust.CheckedChanged, Sub()
                                                     _pnlSRNewCust.Visible = _optSRNewCust.Checked
                                                     _pnlSRExistCust.Visible = _optSRExistCust.Checked
                                                 End Sub
        yLoc += 110

        Dim addCombo = Function(lblText As String) As ComboBox
                           Dim lbl As New Label() With {.Text = lblText, .Location = New Point(20, yLoc), .AutoSize = True, .Font = New Font("Segoe UI", 9.5F)}
                           pnlAdminSREditor.Controls.Add(lbl)
                           Dim cmb As New ComboBox() With {.Location = New Point(160, yLoc - 2), .Width = 320, .DropDownStyle = ComboBoxStyle.DropDownList, .Font = New Font("Segoe UI", 9.5F)}
                           pnlAdminSREditor.Controls.Add(cmb)
                           yLoc += 35
                           Return cmb
                       End Function

        _cmbSRService = addCombo("Service Target:")
        _cmbSRStaff = addCombo("Staff Coordinator:")
        _cmbSRTechnician = addCombo("Technician (Optional):")

        Dim addField = Function(lblText As String, ctrl As Control) As Control
                           Dim lbl As New Label() With {.Text = lblText, .Location = New Point(20, yLoc), .AutoSize = True, .Font = New Font("Segoe UI", 9.5F)}
                           pnlAdminSREditor.Controls.Add(lbl)
                           ctrl.Location = New Point(160, yLoc - 2)
                           ctrl.Width = 320
                           ctrl.Font = New Font("Segoe UI", 9.5F)
                           pnlAdminSREditor.Controls.Add(ctrl)
                           yLoc += 35
                           Return ctrl
                       End Function

        dtpSRRequestDate = addField("Request Date:", New DateTimePicker() With {.Format = DateTimePickerFormat.Short})
        dtpAdminSREditSched = addField("Schedule Date:", New DateTimePicker() With {.Format = DateTimePickerFormat.Short, .ShowCheckBox = True})
        dtpSRCompleted = addField("Completed Date:", New DateTimePicker() With {.Format = DateTimePickerFormat.Short, .ShowCheckBox = True})

        txtSRAddress = addField("Repair Address:", New TextBox() With {.Multiline = True, .Height = 50})
        yLoc += 15

        cmbAdminSREditStatus = addField("Status:", New ComboBox() With {.DropDownStyle = ComboBoxStyle.DropDownList})
        cmbAdminSREditStatus.Items.AddRange(New String() {"Pending", "Scheduled", "In Progress", "Completed", "Cancelled"})

        yLoc += 20

        Dim btnSave As New Button() With {.Text = "Save Form", .BackColor = Color.FromArgb(0, 120, 215), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Location = New Point(160, yLoc), .Size = New Size(115, 35), .Cursor = Cursors.Hand}
        btnSave.FlatAppearance.BorderSize = 0
        AddHandler btnSave.Click, AddressOf SaveAdminSR
        pnlAdminSREditor.Controls.Add(btnSave)

        Dim btnCancel As New Button() With {.Text = "Cancel", .BackColor = Color.LightGray, .FlatStyle = FlatStyle.Flat, .Location = New Point(285, yLoc), .Size = New Size(115, 35), .Cursor = Cursors.Hand}
        btnCancel.FlatAppearance.BorderSize = 0
        AddHandler btnCancel.Click, Sub() pnlAdminSREditor.Visible = False
        pnlAdminSREditor.Controls.Add(btnCancel)

        pnlAdminSRDashboard.Controls.Add(pnlAdminSREditor)
        pnlAdminSREditor.BringToFront()
    End Sub

    Private Sub LoadAdminSREditorData()
        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()

            Dim dtCust As New DataTable()
            Using da As New MySqlDataAdapter("SELECT Customer_ID, Full_Name FROM CUSTOMER", conn)
                da.Fill(dtCust)
            End Using
            _cmbSRExistCust.DataSource = dtCust
            _cmbSRExistCust.DisplayMember = "Full_Name"
            _cmbSRExistCust.ValueMember = "Customer_ID"
            _cmbSRExistCust.SelectedIndex = -1

            Dim dtSvc As New DataTable()
            Using da As New MySqlDataAdapter("SELECT Service_ID, Service_Type FROM SERVICE", conn)
                da.Fill(dtSvc)
            End Using
            _cmbSRService.DataSource = dtSvc
            _cmbSRService.DisplayMember = "Service_Type"
            _cmbSRService.ValueMember = "Service_ID"

            Dim dtStaff As New DataTable()
            Using da As New MySqlDataAdapter("SELECT Staff_ID, Full_Name FROM STAFF", conn)
                da.Fill(dtStaff)
            End Using
            _cmbSRStaff.DataSource = dtStaff
            _cmbSRStaff.DisplayMember = "Full_Name"
            _cmbSRStaff.ValueMember = "Staff_ID"

            Dim dtTech As New DataTable()
            Using da As New MySqlDataAdapter("SELECT T.Technician_ID, S.Full_Name FROM TECHNICIAN T JOIN STAFF S ON T.Staff_ID = S.Staff_ID", conn)
                da.Fill(dtTech)
            End Using
            _cmbSRTechnician.DataSource = dtTech
            _cmbSRTechnician.DisplayMember = "Full_Name"
            _cmbSRTechnician.ValueMember = "Technician_ID"
            _cmbSRTechnician.SelectedIndex = -1
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadAdminSRWarrantiesForCustomer()
        If _cmbSRWarranty Is Nothing Then Return
        If _cmbSRExistCust.SelectedValue Is Nothing Then
            _cmbSRWarranty.DataSource = Nothing
            Return
        End If

        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()
            Dim custId = _cmbSRExistCust.SelectedValue
            If TypeOf custId Is DataRowView Then Return

            Dim dtW As New DataTable()
            Dim q As String = "SELECT W.Warranty_ID, CONCAT('Warranty ', W.Warranty_ID, ' (Exp: ', W.Warranty_End_Date, ')') as DescName " &
                              "FROM WARRANTY W JOIN PURCHASE P ON W.Purchase_ID = P.Purchase_ID " &
                              "WHERE P.Customer_ID = @cid AND W.Warranty_Status = 'Active'"
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@cid", Convert.ToInt32(custId))
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

    Private Sub LoadAdminServiceRequestsCards()
        If flpAdminSRCards Is Nothing Then Return
        flpAdminSRCards.SuspendLayout()
        flpAdminSRCards.Controls.Clear()

        Try
            OpenConnection()
            Dim statusFilter = If(_cmbAdminSRStatusFilter IsNot Nothing AndAlso _cmbAdminSRStatusFilter.SelectedItem IsNot Nothing, _cmbAdminSRStatusFilter.SelectedItem.ToString(), "All")

            Dim q As String = "SELECT SR.Request_ID, C.Full_Name as Customer, SR.Request_Date, SR.Scheduled_Date, SR.Completed_Date, SR.Service_Address, SR.Request_Status, SR.Technician_ID " &
                              "FROM SERVICE_REQUEST SR " &
                              "JOIN CUSTOMER C ON SR.Customer_ID = C.Customer_ID"

            If statusFilter <> "All" Then q &= " WHERE SR.Request_Status = @status"

            Using cmd As New MySqlCommand(q, conn)
                If statusFilter <> "All" Then cmd.Parameters.AddWithValue("@status", statusFilter)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim rId = Convert.ToInt32(reader("Request_ID"))
                        Dim cName = reader("Customer").ToString()
                        Dim reqDate = Convert.ToDateTime(reader("Request_Date")).ToShortDateString()

                        Dim schedDate = "Not Set"
                        If Not IsDBNull(reader("Scheduled_Date")) Then schedDate = Convert.ToDateTime(reader("Scheduled_Date")).ToShortDateString()

                        Dim addr = reader("Service_Address").ToString()
                        Dim stat = reader("Request_Status").ToString()

                        Dim card As New Panel() With {.Size = New Size(300, 210), .Margin = New Padding(10), .BackColor = Color.White, .BorderStyle = BorderStyle.FixedSingle}

                        card.Controls.Add(New Label() With {.Text = "REQ-" & rId.ToString("D4"), .Font = New Font("Segoe UI", 9, FontStyle.Bold), .ForeColor = Color.Gray, .Location = New Point(10, 10), .AutoSize = True})
                        card.Controls.Add(New Label() With {.Text = cName, .Font = New Font("Segoe UI", 12, FontStyle.Bold), .ForeColor = Color.FromArgb(30, 30, 30), .Location = New Point(10, 30), .AutoSize = True})

                        card.Controls.Add(New Label() With {.Text = "Requested: " & reqDate, .Font = New Font("Segoe UI", 9), .ForeColor = Color.DimGray, .Location = New Point(10, 55), .AutoSize = True})
                        card.Controls.Add(New Label() With {.Text = "Scheduled: " & schedDate, .Font = New Font("Segoe UI", 9), .ForeColor = Color.DimGray, .Location = New Point(10, 75), .AutoSize = True})
                        card.Controls.Add(New Label() With {.Text = If(addr.Length > 35, addr.Substring(0, 35) & "...", addr), .Font = New Font("Segoe UI", 9), .ForeColor = Color.DimGray, .Location = New Point(10, 95), .AutoSize = True})

                        Dim lblStat As New Label() With {.Text = stat, .Font = New Font("Segoe UI", 10, FontStyle.Bold), .Location = New Point(10, 125), .AutoSize = True}
                        Select Case stat
                            Case "Pending" : lblStat.ForeColor = Color.Orange
                            Case "Scheduled" : lblStat.ForeColor = Color.CadetBlue
                            Case "In Progress" : lblStat.ForeColor = Color.Blue
                            Case "Completed" : lblStat.ForeColor = Color.Green
                            Case "Cancelled" : lblStat.ForeColor = Color.Red
                            Case Else : lblStat.ForeColor = Color.Gray
                        End Select
                        card.Controls.Add(lblStat)

                        Dim btnEdit As New Button() With {.Text = "Edit / Info", .Size = New Size(110, 30), .Location = New Point(10, 160), .FlatStyle = FlatStyle.Flat, .BackColor = Color.FromArgb(0, 120, 215), .ForeColor = Color.White, .Cursor = Cursors.Hand}
                        btnEdit.FlatAppearance.BorderSize = 0
                        AddHandler btnEdit.Click, Sub() ShowAdminSREditor(rId)
                        card.Controls.Add(btnEdit)

                        Dim btnDel As New Button() With {.Text = "Delete", .Size = New Size(90, 30), .Location = New Point(130, 160), .FlatStyle = FlatStyle.Flat, .BackColor = Color.FromArgb(220, 53, 69), .ForeColor = Color.White, .Cursor = Cursors.Hand}
                        btnDel.FlatAppearance.BorderSize = 0
                        AddHandler btnDel.Click, Sub() DeleteAdminSR(rId)
                        card.Controls.Add(btnDel)

                        flpAdminSRCards.Controls.Add(card)
                    End While
                End Using
            End Using
        Catch ex As Exception
        End Try
        flpAdminSRCards.ResumeLayout()
    End Sub

    Private Sub ShowAdminSREditor(rId As Integer)
        _editSRId = rId
        LoadAdminSREditorData()

        If rId = 0 Then
            ' Clear UI to add new request
            _optSRNewCust.Checked = True
            _txtSRNewCustName.Clear()
            _txtSRNewCustContact.Clear()
            _txtSRNewCustAddress.Clear()
            If _cmbSRExistCust.Items.Count > 0 Then _cmbSRExistCust.SelectedIndex = -1
            If _cmbSRService.Items.Count > 0 Then _cmbSRService.SelectedIndex = -1
            If _cmbSRStaff.Items.Count > 0 Then _cmbSRStaff.SelectedIndex = -1
            If _cmbSRTechnician.Items.Count > 0 Then _cmbSRTechnician.SelectedIndex = -1

            dtpSRRequestDate.Value = DateTime.Now
            dtpSRRequestDate.Checked = True
            dtpAdminSREditSched.Checked = False
            dtpSRCompleted.Checked = False
            txtSRAddress.Clear()
            cmbAdminSREditStatus.SelectedItem = "Pending"
        Else
            Try
                OpenConnection()
                Dim q As String = "SELECT * FROM SERVICE_REQUEST WHERE Request_ID=@id"
                Using cmd As New MySqlCommand(q, conn)
                    cmd.Parameters.AddWithValue("@id", rId)
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            _optSRExistCust.Checked = True

                            _cmbSRExistCust.SelectedValue = Convert.ToInt32(reader("Customer_ID"))
                            _cmbSRService.SelectedValue = Convert.ToInt32(reader("Service_ID"))
                            _cmbSRStaff.SelectedValue = Convert.ToInt32(reader("Staff_ID"))

                            If Not IsDBNull(reader("Technician_ID")) Then _cmbSRTechnician.SelectedValue = Convert.ToInt32(reader("Technician_ID"))
                            If Not IsDBNull(reader("Warranty_ID")) Then _cmbSRWarranty.SelectedValue = Convert.ToInt32(reader("Warranty_ID"))

                            dtpSRRequestDate.Value = Convert.ToDateTime(reader("Request_Date"))

                            If Not IsDBNull(reader("Scheduled_Date")) Then
                                dtpAdminSREditSched.Checked = True
                                dtpAdminSREditSched.Value = Convert.ToDateTime(reader("Scheduled_Date"))
                            Else
                                dtpAdminSREditSched.Checked = False
                            End If

                            If Not IsDBNull(reader("Completed_Date")) Then
                                dtpSRCompleted.Checked = True
                                dtpSRCompleted.Value = Convert.ToDateTime(reader("Completed_Date"))
                            Else
                                dtpSRCompleted.Checked = False
                            End If

                            txtSRAddress.Text = reader("Service_Address").ToString()
                            cmbAdminSREditStatus.SelectedItem = reader("Request_Status").ToString()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading SR data: " & ex.Message)
            End Try
        End If

        pnlAdminSREditor.Visible = True
        pnlAdminSREditor.Location = New Point((pnlAdminSRDashboard.Width - pnlAdminSREditor.Width) / 2, (pnlAdminSRDashboard.Height - pnlAdminSREditor.Height) / 2)
        pnlAdminSREditor.BringToFront()
    End Sub

    Private Sub SaveAdminSR(sender As Object, e As EventArgs)
        Dim custId As Integer

        Try
            OpenConnection()

            If _optSRNewCust.Checked Then
                If String.IsNullOrWhiteSpace(_txtSRNewCustName.Text) Then
                    MessageBox.Show("Please enter Customer Full Name.")
                    Return
                End If
                Dim qCust As String = "INSERT INTO CUSTOMER (Full_Name, Contact_Number, Home_Address) VALUES (@name, @contact, @address); SELECT LAST_INSERT_ID();"
                Using cmdCust As New MySqlCommand(qCust, conn)
                    cmdCust.Parameters.AddWithValue("@name", _txtSRNewCustName.Text)
                    cmdCust.Parameters.AddWithValue("@contact", _txtSRNewCustContact.Text)
                    cmdCust.Parameters.AddWithValue("@address", _txtSRNewCustAddress.Text)
                    custId = Convert.ToInt32(cmdCust.ExecuteScalar())
                End Using
            Else
                If _cmbSRExistCust.SelectedValue Is Nothing Then
                    MessageBox.Show("Please select an existing customer.")
                    Return
                End If
                custId = Convert.ToInt32(_cmbSRExistCust.SelectedValue)
            End If

            If _cmbSRService.SelectedValue Is Nothing Then
                MessageBox.Show("Service Target is required.")
                Return
            End If
            If _cmbSRStaff.SelectedValue Is Nothing Then
                MessageBox.Show("Staff Coordinator is required.")
                Return
            End If

            Dim q As String
            If _editSRId = 0 Then
                q = "INSERT INTO SERVICE_REQUEST (Customer_ID, Service_ID, Staff_ID, Technician_ID, Warranty_ID, Request_Date, Scheduled_Date, Completed_Date, Service_Address, Request_Status) " &
                    "VALUES (@cId, @sId, @stfId, @techId, @warId, @reqDate, @schedDate, @compDate, @addr, @stat)"
            Else
                q = "UPDATE SERVICE_REQUEST SET Customer_ID=@cId, Service_ID=@sId, Staff_ID=@stfId, Technician_ID=@techId, Warranty_ID=@warId, " &
                    "Request_Date=@reqDate, Scheduled_Date=@schedDate, Completed_Date=@compDate, Service_Address=@addr, Request_Status=@stat " &
                    "WHERE Request_ID=@id"
            End If

            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@cId", custId)
                cmd.Parameters.AddWithValue("@sId", Convert.ToInt32(_cmbSRService.SelectedValue))
                cmd.Parameters.AddWithValue("@stfId", Convert.ToInt32(_cmbSRStaff.SelectedValue))

                cmd.Parameters.AddWithValue("@techId", If(_cmbSRTechnician.SelectedValue Is Nothing, DBNull.Value, Convert.ToInt32(_cmbSRTechnician.SelectedValue)))
                cmd.Parameters.AddWithValue("@warId", If(_cmbSRWarranty.SelectedValue Is Nothing, DBNull.Value, Convert.ToInt32(_cmbSRWarranty.SelectedValue)))

                cmd.Parameters.AddWithValue("@reqDate", dtpSRRequestDate.Value.Date)
                cmd.Parameters.AddWithValue("@schedDate", If(dtpAdminSREditSched.Checked, dtpAdminSREditSched.Value.Date, CObj(DBNull.Value)))
                cmd.Parameters.AddWithValue("@compDate", If(dtpSRCompleted.Checked, dtpSRCompleted.Value.Date, CObj(DBNull.Value)))

                cmd.Parameters.AddWithValue("@addr", txtSRAddress.Text.Trim())
                cmd.Parameters.AddWithValue("@stat", If(cmbAdminSREditStatus.SelectedItem, "Pending").ToString())

                If _editSRId > 0 Then cmd.Parameters.AddWithValue("@id", _editSRId)

                cmd.ExecuteNonQuery()
            End Using

            pnlAdminSREditor.Visible = False
            LoadAdminServiceRequestsCards()
        Catch ex As Exception
            MessageBox.Show("Error saving SR: " & ex.Message)
        End Try
    End Sub

    Private Sub DeleteAdminSR(rId As Integer)
        If MessageBox.Show("Are you sure you want to permanently delete this Service Request?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Try
                OpenConnection()
                Using cmd As New MySqlCommand("DELETE FROM SERVICE_REQUEST WHERE Request_ID=@id", conn)
                    cmd.Parameters.AddWithValue("@id", rId)
                    cmd.ExecuteNonQuery()
                End Using
                LoadAdminServiceRequestsCards()
            Catch ex As Exception
                MessageBox.Show("Cannot delete this request due to constraints: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' ═══════════════════════════════════════════════════
    '  WARRANTY CLAIMS CRUD PANEL
    ' ═══════════════════════════════════════════════════
    Private Function BuildAdminWarrantyClaims() As Panel
        pnlAdminWCDashboard = New Panel() With {.Dock = DockStyle.Fill, .BackColor = Color.FromArgb(245, 245, 248), .Visible = False}

        Dim pnlTop As New Panel() With {.Dock = DockStyle.Top, .Height = 80, .Padding = New Padding(20)}
        Dim lblTitle As New Label() With {.Text = "Warranty Claims Master Tracker", .Font = New Font("Segoe UI", 20, FontStyle.Bold), .ForeColor = Color.FromArgb(30,30,30), .AutoSize = True, .Location = New Point(20, 20)}
        pnlTop.Controls.Add(lblTitle)
        
        Dim lblFilter As New Label() With {.Text = "Filter Status:", .Font = New Font("Segoe UI", 10), .AutoSize = True, .Location = New Point(450, 30)}
        pnlTop.Controls.Add(lblFilter)
        _cmbAdminWCStatusFilter = New ComboBox() With {.DropDownStyle = ComboBoxStyle.DropDownList, .Font = New Font("Segoe UI", 10), .Location = New Point(550, 28), .Size = New Size(180, 25)}
        _cmbAdminWCStatusFilter.Items.AddRange(New String() {"All", "Pending Review", "Approved - Fixing", "Approved - Replaced", "Denied"})
        _cmbAdminWCStatusFilter.SelectedIndex = 0
        AddHandler _cmbAdminWCStatusFilter.SelectedIndexChanged, Sub() LoadAdminWarrantyClaimsCards()
        pnlTop.Controls.Add(_cmbAdminWCStatusFilter)

        pnlAdminWCDashboard.Controls.Add(pnlTop)

        flpAdminWCCards = New FlowLayoutPanel() With {.Dock = DockStyle.Fill, .AutoScroll = True, .Padding = New Padding(20), .BackColor = Color.FromArgb(245, 245, 248)}
        pnlAdminWCDashboard.Controls.Add(flpAdminWCCards)
        flpAdminWCCards.BringToFront()
        
        BuildAdminWCEditor()

        AddHandler pnlAdminWCDashboard.Resize, Sub() If pnlAdminWCEditor.Visible Then pnlAdminWCEditor.Location = New Point((pnlAdminWCDashboard.Width - pnlAdminWCEditor.Width) / 2, (pnlAdminWCDashboard.Height - pnlAdminWCEditor.Height) / 2)

        AddHandler pnlAdminWCDashboard.VisibleChanged, Sub(s, ev)
                                                       If pnlAdminWCDashboard.Visible Then LoadAdminWarrantyClaimsCards()
                                                   End Sub
        Return pnlAdminWCDashboard
    End Function

    Private Sub BuildAdminWCEditor()
        pnlAdminWCEditor = New Panel() With {.Size = New Size(400, 250), .BackColor = Color.White, .Visible = False, .BorderStyle = BorderStyle.FixedSingle}
        
        Dim lblHeader As New Label() With {.Text = "Edit Claim Resolution", .Font = New Font("Segoe UI", 16, FontStyle.Bold), .Location = New Point(20, 20), .AutoSize = True}
        pnlAdminWCEditor.Controls.Add(lblHeader)

        Dim yLoc As Integer = 70
        Dim addField = Function(lblText As String, ctrl As Control) As Control
                           Dim lbl As New Label() With {.Text = lblText, .Location = New Point(20, yLoc), .AutoSize = True, .Font = New Font("Segoe UI", 10)}
                           pnlAdminWCEditor.Controls.Add(lbl)
                           ctrl.Location = New Point(150, yLoc)
                           ctrl.Width = 220
                           ctrl.Font = New Font("Segoe UI", 10)
                           pnlAdminWCEditor.Controls.Add(ctrl)
                           yLoc += 45
                           Return ctrl
                       End Function

        cmbAdminWCEditStatus = addField("Resolution:", New ComboBox() With {.DropDownStyle = ComboBoxStyle.DropDownList})
        cmbAdminWCEditStatus.Items.AddRange(New String() {"Pending Review", "Approved - Fixing", "Approved - Replaced", "Denied"})
        
        yLoc += 20

        Dim btnSave As New Button() With {.Text = "Save", .BackColor = Color.FromArgb(0, 120, 215), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Location = New Point(150, yLoc), .Size = New Size(100, 35), .Cursor = Cursors.Hand}
        btnSave.FlatAppearance.BorderSize = 0
        AddHandler btnSave.Click, AddressOf SaveAdminWC
        pnlAdminWCEditor.Controls.Add(btnSave)

        Dim btnCancel As New Button() With {.Text = "Cancel", .BackColor = Color.LightGray, .FlatStyle = FlatStyle.Flat, .Location = New Point(270, yLoc), .Size = New Size(100, 35), .Cursor = Cursors.Hand}
        btnCancel.FlatAppearance.BorderSize = 0
        AddHandler btnCancel.Click, Sub() pnlAdminWCEditor.Visible = False
        pnlAdminWCEditor.Controls.Add(btnCancel)

        pnlAdminWCDashboard.Controls.Add(pnlAdminWCEditor)
        pnlAdminWCEditor.BringToFront()
    End Sub

    Private Sub LoadAdminWarrantyClaimsCards()
        If flpAdminWCCards Is Nothing Then Return
        flpAdminWCCards.SuspendLayout()
        flpAdminWCCards.Controls.Clear()

        Try
            OpenConnection()
            Dim statusFilter = If(_cmbAdminWCStatusFilter IsNot Nothing AndAlso _cmbAdminWCStatusFilter.SelectedItem IsNot Nothing, _cmbAdminWCStatusFilter.SelectedItem.ToString(), "All")
            
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

                        Dim card As New Panel() With {.Size = New Size(280, 190), .Margin = New Padding(10), .BackColor = Color.White, .BorderStyle = BorderStyle.FixedSingle}
                        
                        card.Controls.Add(New Label() With {.Text = "CLM-" & cId.ToString("D4"), .Font = New Font("Segoe UI", 9, FontStyle.Bold), .ForeColor = Color.Gray, .Location = New Point(10, 10), .AutoSize = True})
                        card.Controls.Add(New Label() With {.Text = cName, .Font = New Font("Segoe UI", 12, FontStyle.Bold), .ForeColor = Color.FromArgb(30, 30, 30), .Location = New Point(10, 30), .AutoSize = True})
                        card.Controls.Add(New Label() With {.Text = "Date: " & claimDateStr, .Font = New Font("Segoe UI", 9), .ForeColor = Color.DimGray, .Location = New Point(10, 55), .AutoSize = True})
                        
                        Dim lblDesc As New Label() With {.Text = If(cDesc.Length > 60, cDesc.Substring(0, 60) & "...", cDesc), .Font = New Font("Segoe UI", 9), .ForeColor = Color.DimGray, .Location = New Point(10, 75), .Size = New Size(260, 35)}
                        card.Controls.Add(lblDesc)

                        Dim lblStat As New Label() With {.Text = cRes, .Font = New Font("Segoe UI", 10, FontStyle.Bold), .Location = New Point(10, 115), .AutoSize = True}
                        Select Case cRes
                            Case "Pending Review": lblStat.ForeColor = Color.Orange
                            Case "Approved - Fixing": lblStat.ForeColor = Color.CadetBlue
                            Case "Approved - Replaced": lblStat.ForeColor = Color.Green
                            Case "Denied": lblStat.ForeColor = Color.Red
                            Case Else: lblStat.ForeColor = Color.Gray
                        End Select
                        card.Controls.Add(lblStat)

                        Dim btnEdit As New Button() With {.Text = "Edit", .Size = New Size(95, 30), .Location = New Point(10, 145), .FlatStyle = FlatStyle.Flat, .BackColor = Color.FromArgb(0, 120, 215), .ForeColor = Color.White, .Cursor = Cursors.Hand}
                        btnEdit.FlatAppearance.BorderSize = 0
                        AddHandler btnEdit.Click, Sub() ShowAdminWCEditor(cId, cRes)
                        card.Controls.Add(btnEdit)

                        Dim btnDel As New Button() With {.Text = "Delete", .Size = New Size(95, 30), .Location = New Point(115, 145), .FlatStyle = FlatStyle.Flat, .BackColor = Color.FromArgb(220, 53, 69), .ForeColor = Color.White, .Cursor = Cursors.Hand}
                        btnDel.FlatAppearance.BorderSize = 0
                        AddHandler btnDel.Click, Sub() DeleteAdminWC(cId)
                        card.Controls.Add(btnDel)

                        flpAdminWCCards.Controls.Add(card)
                    End While
                End Using
            End Using
        Catch ex As Exception
        End Try
        flpAdminWCCards.ResumeLayout()
    End Sub

    Private Sub ShowAdminWCEditor(cId As Integer, currentRes As String)
        _editWCId = cId
        cmbAdminWCEditStatus.SelectedItem = currentRes
        pnlAdminWCEditor.Visible = True
        pnlAdminWCEditor.Location = New Point((pnlAdminWCDashboard.Width - pnlAdminWCEditor.Width) / 2, (pnlAdminWCDashboard.Height - pnlAdminWCEditor.Height) / 2)
        pnlAdminWCEditor.BringToFront()
    End Sub

    Private Sub SaveAdminWC(sender As Object, e As EventArgs)
        Try
            OpenConnection()
            Using cmd As New MySqlCommand("UPDATE WARRANTY_CLAIM SET Claim_Resolution=@res WHERE Claim_ID=@id", conn)
                cmd.Parameters.AddWithValue("@res", cmbAdminWCEditStatus.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@id", _editWCId)
                cmd.ExecuteNonQuery()
            End Using
            pnlAdminWCEditor.Visible = False
            LoadAdminWarrantyClaimsCards()
        Catch ex As Exception
            MessageBox.Show("Error updating Claim: " & ex.Message)
        End Try
    End Sub

    Private Sub DeleteAdminWC(cId As Integer)
        If MessageBox.Show("Are you sure you want to permanently delete this Warranty Claim?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Try
                OpenConnection()
                Using cmd As New MySqlCommand("DELETE FROM WARRANTY_CLAIM WHERE Claim_ID=@id", conn)
                    cmd.Parameters.AddWithValue("@id", cId)
                    cmd.ExecuteNonQuery()
                End Using
                LoadAdminWarrantyClaimsCards()
            Catch ex As Exception
                MessageBox.Show("Cannot delete this claim due to constraints: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' ═══════════════════════════════════════════════════
    '  INVENTORY CRUD PANEL
    ' ═══════════════════════════════════════════════════
    Private Function BuildInventoryDashboard() As Panel
        pnlInvenDashboard = New Panel() With {.Dock = DockStyle.Fill, .BackColor = Color.FromArgb(245, 245, 248), .Visible = False}

        ' Title bar
        Dim pnlTop As New Panel() With {.Dock = DockStyle.Top, .Height = 80, .Padding = New Padding(20)}
        Dim lblTitle As New Label() With {.Text = "Inventory Tracking & CRUD", .Font = New Font("Segoe UI", 20, FontStyle.Bold), .ForeColor = Color.FromArgb(30, 30, 30), .AutoSize = True, .Location = New Point(20, 20)}
        pnlTop.Controls.Add(lblTitle)
        
        Dim btnAdd As New Button() With {.Text = "+ Add Product", .Font = New Font("Segoe UI", 10, FontStyle.Bold), .BackColor = Color.FromArgb(0, 153, 102), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Size = New Size(140, 40), .Cursor = Cursors.Hand}
        btnAdd.FlatAppearance.BorderSize = 0
        AddHandler pnlTop.Resize, Sub() btnAdd.Location = New Point(pnlTop.Width - 170, 20)
        AddHandler btnAdd.Click, Sub() ShowProductEditor(0)
        pnlTop.Controls.Add(btnAdd)
        
        pnlInvenDashboard.Controls.Add(pnlTop)

        ' Category Filters
        Dim pnlFilters As New FlowLayoutPanel() With {.Dock = DockStyle.Top, .Height = 55, .BackColor = Color.FromArgb(245, 245, 248), .Padding = New Padding(22, 5, 10, 5), .WrapContents = False, .AutoScroll = True}
        Dim categories() As String = {"All", "Air Conditioners", "Washing Machines", "Televisions", "Refrigerators"}
        For Each cat As String In categories
            Dim btn As New Button() With {.Text = cat, .Font = New Font("Segoe UI", 9.5F, FontStyle.Regular), .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand, .AutoSize = True, .Padding = New Padding(12, 2, 12, 2), .Margin = New Padding(3, 3, 6, 3), .Height = 34, .BackColor = Color.White, .ForeColor = Color.FromArgb(60, 60, 60), .Tag = cat}
            btn.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200)
            btn.FlatAppearance.BorderSize = 1
            AddHandler btn.Click, AddressOf InvenCategoryFilter_Click
            pnlFilters.Controls.Add(btn)
        Next
        pnlInvenDashboard.Controls.Add(pnlFilters)
        pnlFilters.BringToFront()

        ' Stock Cards Grid
        flpInvenStockCards = New FlowLayoutPanel() With {.Dock = DockStyle.Fill, .AutoScroll = True, .Padding = New Padding(20), .BackColor = Color.FromArgb(245, 245, 248)}
        pnlInvenDashboard.Controls.Add(flpInvenStockCards)
        flpInvenStockCards.BringToFront()
        
        ' Overlay Editor
        BuildInventoryEditor()
        
        AddHandler pnlInvenDashboard.Resize, Sub() If pnlInvenEditor.Visible Then pnlInvenEditor.Location = New Point((pnlInvenDashboard.Width - pnlInvenEditor.Width) / 2, (pnlInvenDashboard.Height - pnlInvenEditor.Height) / 2)

        AddHandler pnlInvenDashboard.VisibleChanged, Sub(s, ev)
                                                       If pnlInvenDashboard.Visible Then 
                                                           If _activeInvenCategoryBtn Is Nothing AndAlso pnlFilters.Controls.Count > 0 Then
                                                               InvenCategoryFilter_Click(pnlFilters.Controls(0), EventArgs.Empty)
                                                           ElseIf _activeInvenCategoryBtn IsNot Nothing Then
                                                               LoadInventoryCards(_activeInvenCategoryBtn.Tag.ToString())
                                                           End If
                                                       End If
                                                   End Sub
        Return pnlInvenDashboard
    End Function

    Private Sub BuildInventoryEditor()
        pnlInvenEditor = New Panel() With {.Size = New Size(450, 480), .BackColor = Color.White, .Visible = False, .BorderStyle = BorderStyle.FixedSingle}
        
        Dim lblHeader As New Label() With {.Text = "Product Editor", .Font = New Font("Segoe UI", 16, FontStyle.Bold), .Location = New Point(20, 20), .AutoSize = True}
        pnlInvenEditor.Controls.Add(lblHeader)

        Dim yLoc As Integer = 70
        Dim addField = Function(lblText As String, ctrl As Control) As Control
                           Dim lbl As New Label() With {.Text = lblText, .Location = New Point(20, yLoc), .AutoSize = True, .Font = New Font("Segoe UI", 10)}
                           pnlInvenEditor.Controls.Add(lbl)
                           ctrl.Location = New Point(150, yLoc)
                           ctrl.Width = 260
                           ctrl.Font = New Font("Segoe UI", 10)
                           pnlInvenEditor.Controls.Add(ctrl)
                           yLoc += 40
                           Return ctrl
                       End Function

        txtInvName = addField("Name:", New TextBox())
        txtInvBrand = addField("Brand:", New TextBox())
        
        cmbInvCategory = addField("Category:", New ComboBox() With {.DropDownStyle = ComboBoxStyle.DropDownList})
        cmbInvCategory.Items.AddRange({"Air Conditioners", "Washing Machines", "Televisions", "Refrigerators"})
        
        numInvPrice = addField("Unit Price:", New NumericUpDown() With {.Maximum = 1000000, .DecimalPlaces = 2})
        numInvStock = addField("Stock Qty:", New NumericUpDown() With {.Maximum = 10000})
        numInvReorder = addField("Reorder Lvl:", New NumericUpDown() With {.Maximum = 10000})
        
        txtInvDesc = addField("Description:", New TextBox() With {.Multiline = True, .Height = 60})
        yLoc += 30 ' padding after multiline

        Dim btnSave As New Button() With {.Text = "Save", .BackColor = Color.FromArgb(0, 120, 215), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Location = New Point(150, yLoc), .Size = New Size(120, 35), .Cursor = Cursors.Hand}
        btnSave.FlatAppearance.BorderSize = 0
        AddHandler btnSave.Click, AddressOf SaveProduct
        pnlInvenEditor.Controls.Add(btnSave)

        Dim btnCancel As New Button() With {.Text = "Cancel", .BackColor = Color.LightGray, .FlatStyle = FlatStyle.Flat, .Location = New Point(290, yLoc), .Size = New Size(120, 35), .Cursor = Cursors.Hand}
        btnCancel.FlatAppearance.BorderSize = 0
        AddHandler btnCancel.Click, Sub() pnlInvenEditor.Visible = False
        pnlInvenEditor.Controls.Add(btnCancel)

        pnlInvenDashboard.Controls.Add(pnlInvenEditor)
        pnlInvenEditor.BringToFront()
    End Sub

    Private Sub InvenCategoryFilter_Click(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        If _activeInvenCategoryBtn IsNot Nothing Then
            _activeInvenCategoryBtn.BackColor = Color.White
            _activeInvenCategoryBtn.ForeColor = Color.FromArgb(60, 60, 60)
            _activeInvenCategoryBtn.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200)
            _activeInvenCategoryBtn.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
        End If
        btn.BackColor = Color.FromArgb(30, 30, 30)
        btn.ForeColor = Color.White
        btn.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30)
        btn.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        _activeInvenCategoryBtn = btn
        LoadInventoryCards(btn.Tag.ToString())
    End Sub

    Private Sub LoadInventoryCards(category As String)
        If flpInvenStockCards Is Nothing Then Return
        flpInvenStockCards.SuspendLayout()
        flpInvenStockCards.Controls.Clear()

        Try
            OpenConnection()
            Dim q As String = "SELECT Product_ID, Product_Name, Brand, Unit_Price, Product_Description, Stock_Quantity, Reorder_Level FROM PRODUCT"
            If category <> "All" Then q &= " WHERE Product_Category = @cat"

            Using cmd As New MySqlCommand(q, conn)
                If category <> "All" Then cmd.Parameters.AddWithValue("@cat", category)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim pId = Convert.ToInt32(reader("Product_ID"))
                        Dim pName = reader("Product_Name").ToString()
                        Dim pBrand = reader("Brand").ToString()
                        Dim pDesc = reader("Product_Description").ToString()
                        Dim stock = Convert.ToInt32(reader("Stock_Quantity"))
                        Dim reorder = Convert.ToInt32(reader("Reorder_Level"))

                        Dim card As New Panel() With {.Size = New Size(240, 190), .Margin = New Padding(10), .BackColor = Color.White}
                        AddHandler card.Paint, Sub(s, ev) ev.Graphics.DrawRectangle(Pens.LightGray, 0, 0, card.Width - 1, card.Height - 1)
                        
                        card.Controls.Add(New Label() With {.Text = pName, .Font = New Font("Segoe UI", 11, FontStyle.Bold), .Location = New Point(10, 10), .AutoSize = True})
                        card.Controls.Add(New Label() With {.Text = pBrand, .Font = New Font("Segoe UI", 9), .ForeColor = Color.Gray, .Location = New Point(10, 35), .AutoSize = True})
                        
                        Dim lblDesc As New Label() With {.Text = If(pDesc.Length > 50, pDesc.Substring(0, 50) & "...", pDesc), .Font = New Font("Segoe UI", 8), .ForeColor = Color.DimGray, .Location = New Point(10, 55), .Size = New Size(220, 30)}
                        card.Controls.Add(lblDesc)

                        Dim isLow = (stock <= reorder)
                        Dim lblQty As New Label() With {.Text = "Stock: " & stock, .Font = New Font("Segoe UI", 12, FontStyle.Bold), .Location = New Point(10, 95), .AutoSize = True}
                        lblQty.ForeColor = If(isLow, Color.FromArgb(220, 53, 69), Color.FromArgb(0, 153, 102))
                        card.Controls.Add(lblQty)

                        Dim btnEdit As New Button() With {.Text = "Edit", .Size = New Size(95, 30), .Location = New Point(10, 140), .FlatStyle = FlatStyle.Flat, .BackColor = Color.FromArgb(0, 120, 215), .ForeColor = Color.White, .Cursor = Cursors.Hand}
                        btnEdit.FlatAppearance.BorderSize = 0
                        AddHandler btnEdit.Click, Sub() ShowProductEditor(pId)
                        card.Controls.Add(btnEdit)

                        Dim btnDel As New Button() With {.Text = "Delete", .Size = New Size(95, 30), .Location = New Point(115, 140), .FlatStyle = FlatStyle.Flat, .BackColor = Color.FromArgb(220, 53, 69), .ForeColor = Color.White, .Cursor = Cursors.Hand}
                        btnDel.FlatAppearance.BorderSize = 0
                        AddHandler btnDel.Click, Sub() DeleteProduct(pId, pName)
                        card.Controls.Add(btnDel)

                        flpInvenStockCards.Controls.Add(card)
                    End While
                End Using
            End Using
        Catch ex As Exception
        End Try
        flpInvenStockCards.ResumeLayout()
    End Sub

    Private Sub ShowProductEditor(pId As Integer)
        _editProductId = pId
        If pId = 0 Then
            txtInvName.Text = ""
            txtInvBrand.Text = ""
            txtInvDesc.Text = ""
            numInvPrice.Value = 0
            numInvStock.Value = 0
            numInvReorder.Value = 0
            If cmbInvCategory.Items.Count > 0 Then cmbInvCategory.SelectedIndex = 0
        Else
            Try
                OpenConnection()
                Using cmd As New MySqlCommand("SELECT * FROM PRODUCT WHERE Product_ID=@id", conn)
                    cmd.Parameters.AddWithValue("@id", pId)
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtInvName.Text = reader("Product_Name").ToString()
                            txtInvBrand.Text = reader("Brand").ToString()
                            txtInvDesc.Text = reader("Product_Description").ToString()
                            numInvPrice.Value = Math.Min(numInvPrice.Maximum, Convert.ToDecimal(reader("Unit_Price")))
                            numInvStock.Value = Math.Min(numInvStock.Maximum, Convert.ToInt32(reader("Stock_Quantity")))
                            numInvReorder.Value = Math.Min(numInvReorder.Maximum, Convert.ToInt32(reader("Reorder_Level")))
                            cmbInvCategory.SelectedItem = reader("Product_Category").ToString()
                        End If
                    End Using
                End Using
            Catch ex As Exception
            End Try
        End If
        
        pnlInvenEditor.Location = New Point((pnlInvenDashboard.Width - pnlInvenEditor.Width) / 2, (pnlInvenDashboard.Height - pnlInvenEditor.Height) / 2)
        pnlInvenEditor.Visible = True
        pnlInvenEditor.BringToFront()
    End Sub

    Private Sub SaveProduct(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtInvName.Text) Then
            MessageBox.Show("Name cannot be empty.", "Validation Error")
            Return
        End If

        Try
            OpenConnection()
            Dim q As String
            If _editProductId = 0 Then
                q = "INSERT INTO PRODUCT (Product_Name, Brand, Unit_Price, Product_Category, Product_Description, Stock_Quantity, Reorder_Level, Supplier_ID) VALUES (@n, @b, @p, @c, @d, @s, @r, 1)"
            Else
                q = "UPDATE PRODUCT SET Product_Name=@n, Brand=@b, Unit_Price=@p, Product_Category=@c, Product_Description=@d, Stock_Quantity=@s, Reorder_Level=@r WHERE Product_ID=@id"
            End If

            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@n", txtInvName.Text)
                cmd.Parameters.AddWithValue("@b", txtInvBrand.Text)
                cmd.Parameters.AddWithValue("@p", numInvPrice.Value)
                cmd.Parameters.AddWithValue("@c", If(cmbInvCategory.SelectedItem, "Air Conditioners"))
                cmd.Parameters.AddWithValue("@d", txtInvDesc.Text)
                cmd.Parameters.AddWithValue("@s", numInvStock.Value)
                cmd.Parameters.AddWithValue("@r", numInvReorder.Value)
                If _editProductId > 0 Then cmd.Parameters.AddWithValue("@id", _editProductId)
                cmd.ExecuteNonQuery()
            End Using
            
            pnlInvenEditor.Visible = False
            If _activeInvenCategoryBtn IsNot Nothing Then LoadInventoryCards(_activeInvenCategoryBtn.Tag.ToString())
        Catch ex As Exception
            MessageBox.Show("Error saving: " & ex.Message)
        End Try
    End Sub

    Private Sub DeleteProduct(pId As Integer, pName As String)
        If MessageBox.Show("Are you sure you want to delete '" & pName & "'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Try
                OpenConnection()
                Using cmd As New MySqlCommand("DELETE FROM PRODUCT WHERE Product_ID=@id", conn)
                    cmd.Parameters.AddWithValue("@id", pId)
                    cmd.ExecuteNonQuery()
                End Using
                If _activeInvenCategoryBtn IsNot Nothing Then LoadInventoryCards(_activeInvenCategoryBtn.Tag.ToString())
            Catch ex As Exception
                MessageBox.Show("Cannot delete product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' ═══════════════════════════════════════════════════
    '  DASHBOARD PANEL RECREATION
    ' ═══════════════════════════════════════════════════
    Private Function BuildPlaceholderPanel(title As String) As Panel
        Dim pnl As New Panel() With {.Dock = DockStyle.Fill, .BackColor = Color.FromArgb(245, 245, 248), .Visible = False, .Padding = New Padding(20)}
        Dim lblTitle As New Label() With {.Text = title, .Font = New Font("Segoe UI", 20, FontStyle.Bold), .ForeColor = Color.FromArgb(30, 30, 30), .AutoSize = True, .Location = New Point(20, 20)}
        pnl.Controls.Add(lblTitle)
        Return pnl
    End Function

    Private Function BuildDashboardPanel() As Panel
        Dim pnl As New Panel() With {.Dock = DockStyle.Fill, .BackColor = Color.FromArgb(245, 245, 248), .Visible = False}
        
        Dim lblTitle As New Label() With {.Text = "Dashboard", .Font = New Font("Segoe UI", 24, FontStyle.Bold), .ForeColor = Color.FromArgb(30, 30, 30), .AutoSize = True, .Location = New Point(30, 20)}
        pnl.Controls.Add(lblTitle)

        ' Timed Filter
        _cmbDashTimeFilter = New ComboBox() With {
            .DropDownStyle = ComboBoxStyle.DropDownList,
            .Font = New Font("Segoe UI", 11),
            .Width = 150,
            .Location = New Point(680, 30),
            .Cursor = Cursors.Hand
        }
        _cmbDashTimeFilter.Items.AddRange({"Today", "This Week", "This Month", "This Year", "All Time"})
        _cmbDashTimeFilter.SelectedIndex = 4
        AddHandler _cmbDashTimeFilter.SelectedIndexChanged, Sub() LoadDashboardData()
        pnl.Controls.Add(_cmbDashTimeFilter)

        ' CARDS
        Dim cardColors() As Color = {Color.FromArgb(0, 120, 215), Color.FromArgb(0, 153, 102), Color.FromArgb(255, 140, 0), Color.FromArgb(220, 53, 69)}
        Dim cardTitles() As String = {"Total Sales", "Products", "Service Requests", "Warranty Claims"}
        Dim locsX() As Integer = {30, 240, 450, 660}
        
        lblCard1Value = New Label()
        lblCard2Value = New Label()
        lblCard3Value = New Label()
        lblCard4Value = New Label()
        Dim valLabels() As Label = {lblCard1Value, lblCard2Value, lblCard3Value, lblCard4Value}

        For i As Integer = 0 To 3
            Dim cPnl As New Panel() With {.Size = New Size(200, 110), .Location = New Point(locsX(i), 80), .BackColor = cardColors(i)}
            
            Dim cTitle As New Label() With {.Text = cardTitles(i), .Font = New Font("Segoe UI", 11), .ForeColor = Color.White, .AutoSize = True, .Location = New Point(15, 15)}
            cPnl.Controls.Add(cTitle)
            
            Dim cVal = valLabels(i)
            cVal.Text = "0"
            cVal.Font = New Font("Segoe UI", 22, FontStyle.Bold)
            cVal.ForeColor = Color.White
            cVal.AutoSize = True
            cVal.Location = New Point(15, 45)
            cPnl.Controls.Add(cVal)
            
            pnl.Controls.Add(cPnl)
        Next

        ' Recent Activity
        Dim lblRecTitle As New Label() With {.Text = "Recent Activity Log", .Font = New Font("Segoe UI", 16, FontStyle.Bold), .ForeColor = Color.FromArgb(60, 60, 60), .AutoSize = True, .Location = New Point(30, 220)}
        pnl.Controls.Add(lblRecTitle)

        flpRecentActivity = New FlowLayoutPanel() With {
            .Location = New Point(30, 260),
            .Size = New Size(830, 400),
            .BackColor = Color.FromArgb(245, 245, 248),
            .AutoScroll = True,
            .FlowDirection = FlowDirection.TopDown,
            .WrapContents = False
        }
        pnl.Controls.Add(flpRecentActivity)

        Return pnl
    End Function

    Private Sub LoadDashboardData()
        Try
            OpenConnection()

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

                            Dim row As New Panel() With {.Width = flpRecentActivity.Width - 30, .Height = 40, .BackColor = Color.White, .Margin = New Padding(5)}
                            
                            Dim lblType As New Label() With {.Text = If(type = "Order", "🛒 Order", If(type = "Service", "🔧 Service", "🛡️ Warranty")), .Font = New Font("Segoe UI", 10, FontStyle.Bold), .Location = New Point(10, 10), .AutoSize = True, .ForeColor = Color.FromArgb(0, 120, 215)}
                            row.Controls.Add(lblType)

                            Dim lblAct As New Label() With {.Text = act, .Font = New Font("Segoe UI", 10), .Location = New Point(120, 10), .AutoSize = True, .ForeColor = Color.FromArgb(60, 60, 60)}
                            row.Controls.Add(lblAct)

                            Dim lblD As New Label() With {.Text = actDate, .Font = New Font("Segoe UI", 9), .Dock = DockStyle.Right, .Padding = New Padding(0, 10, 10, 0), .AutoSize = True, .ForeColor = Color.Gray}
                            row.Controls.Add(lblD)

                            flpRecentActivity.Controls.Add(row)
                        End While
                    End Using
                End Using
            End If
        Catch ex As Exception
            ' Silent catch empty db records during init sequence
        End Try
    End Sub

    Private Sub admin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CloseConnection()
    End Sub

End Class