import sys

with open("c:\\Code Practice\\MideaProShop\\MideaProShop\\Childform.Designer.vb", "r") as f:
    content = f.read()

# 1. Declarations around line 250
decl_target = "        Me.vr_colStaff = New System.Windows.Forms.DataGridViewTextBoxColumn()"
decl_injection = """
        Me.pnlViewWarrantyMain = New System.Windows.Forms.Panel()
        Me.wr_lblTitle = New System.Windows.Forms.Label()
        Me.wr_pnlFilter = New System.Windows.Forms.Panel()
        Me.wr_txtSearch = New System.Windows.Forms.TextBox()
        Me.wr_cmbFilterStatus = New System.Windows.Forms.ComboBox()
        Me.wr_dgvWarranties = New System.Windows.Forms.DataGridView()
        Me.wr_colCust = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wr_colProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wr_colPurchDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wr_colStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wr_colEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wr_colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wr_colActionDetails = New System.Windows.Forms.DataGridViewButtonColumn()

        Me.pnlFileClaimMain = New System.Windows.Forms.Panel()
        Me.fc_lblTitle = New System.Windows.Forms.Label()
        Me.fc_pnlForm = New System.Windows.Forms.Panel()
        Me.fc_lblCust = New System.Windows.Forms.Label()
        Me.fc_cmbCustomer = New System.Windows.Forms.ComboBox()
        Me.fc_lblProd = New System.Windows.Forms.Label()
        Me.fc_cmbProduct = New System.Windows.Forms.ComboBox()
        Me.fc_lblPurchDate = New System.Windows.Forms.Label()
        Me.fc_txtPurchDate = New System.Windows.Forms.TextBox()
        Me.fc_lblStart = New System.Windows.Forms.Label()
        Me.fc_txtStart = New System.Windows.Forms.TextBox()
        Me.fc_lblEnd = New System.Windows.Forms.Label()
        Me.fc_txtEnd = New System.Windows.Forms.TextBox()
        Me.fc_lblStatus = New System.Windows.Forms.Label()
        Me.fc_txtStatus = New System.Windows.Forms.TextBox()
        Me.fc_lblIssue = New System.Windows.Forms.Label()
        Me.fc_txtIssue = New System.Windows.Forms.TextBox()
        Me.fc_btnSubmit = New System.Windows.Forms.Button()
"""
content = content.replace(decl_target, decl_target + decl_injection)

# 2. Initialization after view service requests
init_target = """        Me.vr_colActionUpdate.UseColumnTextForButtonValue = True"""
init_injection = """
        ' ==============================
        ' VIEW WARRANTY
        ' ==============================
        Me.pnlViewWarrantyMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlViewWarrantyMain.Visible = False
        Me.pnlViewWarrantyMain.Controls.Add(Me.wr_dgvWarranties)
        Me.pnlViewWarrantyMain.Controls.Add(Me.wr_pnlFilter)
        Me.pnlViewWarrantyMain.Controls.Add(Me.wr_lblTitle)

        Me.wr_lblTitle.AutoSize = True
        Me.wr_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.wr_lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.wr_lblTitle.Text = "View Warranty"

        Me.wr_pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.wr_pnlFilter.Height = 50
        Me.wr_pnlFilter.Padding = New System.Windows.Forms.Padding(10)

        Me.wr_txtSearch.Location = New System.Drawing.Point(20, 15)
        Me.wr_txtSearch.Width = 300
        Me.wr_txtSearch.Text = "Search by Customer or Product..."
        
        Me.wr_cmbFilterStatus.Location = New System.Drawing.Point(340, 15)
        Me.wr_cmbFilterStatus.Width = 200
        Me.wr_cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.wr_cmbFilterStatus.Items.AddRange(New Object() {"All", "Active", "Expired"})
        Me.wr_cmbFilterStatus.SelectedIndex = 0

        Me.wr_pnlFilter.Controls.Add(Me.wr_txtSearch)
        Me.wr_pnlFilter.Controls.Add(Me.wr_cmbFilterStatus)

        Me.wr_dgvWarranties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wr_dgvWarranties.AllowUserToAddRows = False
        Me.wr_dgvWarranties.RowHeadersVisible = False
        Me.wr_dgvWarranties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.wr_dgvWarranties.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.wr_colCust, Me.wr_colProd, Me.wr_colPurchDate, Me.wr_colStart, Me.wr_colEnd, Me.wr_colStatus, Me.wr_colActionDetails})
        
        Me.wr_colCust.Name = "wr_colCust"
        Me.wr_colCust.HeaderText = "Customer Name"
        Me.wr_colProd.Name = "wr_colProd"
        Me.wr_colProd.HeaderText = "Product Name"
        Me.wr_colPurchDate.Name = "wr_colPurchDate"
        Me.wr_colPurchDate.HeaderText = "Purchase Date"
        Me.wr_colStart.Name = "wr_colStart"
        Me.wr_colStart.HeaderText = "Start Date"
        Me.wr_colEnd.Name = "wr_colEnd"
        Me.wr_colEnd.HeaderText = "End Date"
        Me.wr_colStatus.Name = "wr_colStatus"
        Me.wr_colStatus.HeaderText = "Status"
        
        Me.wr_colActionDetails.Name = "wr_colActionDetails"
        Me.wr_colActionDetails.HeaderText = "Action"
        Me.wr_colActionDetails.Text = "View Details"
        Me.wr_colActionDetails.UseColumnTextForButtonValue = True

        ' ==============================
        ' FILE WARRANTY CLAIM
        ' ==============================
        Me.pnlFileClaimMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFileClaimMain.Visible = False
        Me.pnlFileClaimMain.Controls.Add(Me.fc_pnlForm)
        Me.pnlFileClaimMain.Controls.Add(Me.fc_lblTitle)

        Me.fc_lblTitle.AutoSize = True
        Me.fc_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.fc_lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.fc_lblTitle.Text = "File Warranty Claim"

        Me.fc_pnlForm.Location = New System.Drawing.Point(20, 50)
        Me.fc_pnlForm.Size = New System.Drawing.Size(600, 500)
        Me.fc_pnlForm.BackColor = System.Drawing.Color.White

        Me.fc_lblCust.Text = "Customer Selection"
        Me.fc_lblCust.Location = New System.Drawing.Point(20, 20)
        Me.fc_lblCust.AutoSize = True

        Me.fc_cmbCustomer.Location = New System.Drawing.Point(20, 40)
        Me.fc_cmbCustomer.Width = 400
        Me.fc_cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

        Me.fc_lblProd.Text = "Product Selection"
        Me.fc_lblProd.Location = New System.Drawing.Point(20, 80)
        Me.fc_lblProd.AutoSize = True

        Me.fc_cmbProduct.Location = New System.Drawing.Point(20, 100)
        Me.fc_cmbProduct.Width = 400
        Me.fc_cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

        Me.fc_lblPurchDate.Text = "Purchase Date"
        Me.fc_lblPurchDate.Location = New System.Drawing.Point(20, 140)
        Me.fc_lblPurchDate.AutoSize = True

        Me.fc_txtPurchDate.Location = New System.Drawing.Point(20, 160)
        Me.fc_txtPurchDate.Width = 190
        Me.fc_txtPurchDate.ReadOnly = True

        Me.fc_lblStart.Text = "Warranty Start Date"
        Me.fc_lblStart.Location = New System.Drawing.Point(230, 140)
        Me.fc_lblStart.AutoSize = True

        Me.fc_txtStart.Location = New System.Drawing.Point(230, 160)
        Me.fc_txtStart.Width = 190
        Me.fc_txtStart.ReadOnly = True

        Me.fc_lblEnd.Text = "Warranty End Date"
        Me.fc_lblEnd.Location = New System.Drawing.Point(20, 200)
        Me.fc_lblEnd.AutoSize = True

        Me.fc_txtEnd.Location = New System.Drawing.Point(20, 220)
        Me.fc_txtEnd.Width = 190
        Me.fc_txtEnd.ReadOnly = True

        Me.fc_lblStatus.Text = "Warranty Status"
        Me.fc_lblStatus.Location = New System.Drawing.Point(230, 200)
        Me.fc_lblStatus.AutoSize = True

        Me.fc_txtStatus.Location = New System.Drawing.Point(230, 220)
        Me.fc_txtStatus.Width = 190
        Me.fc_txtStatus.ReadOnly = True

        Me.fc_lblIssue.Text = "Issue Description"
        Me.fc_lblIssue.Location = New System.Drawing.Point(20, 260)
        Me.fc_lblIssue.AutoSize = True

        Me.fc_txtIssue.Location = New System.Drawing.Point(20, 280)
        Me.fc_txtIssue.Width = 400
        Me.fc_txtIssue.Height = 100
        Me.fc_txtIssue.Multiline = True

        Me.fc_btnSubmit.Text = "Submit Claim"
        Me.fc_btnSubmit.Location = New System.Drawing.Point(20, 400)
        Me.fc_btnSubmit.Size = New System.Drawing.Size(180, 40)
        Me.fc_btnSubmit.BackColor = System.Drawing.Color.FromArgb(40, 167, 69)
        Me.fc_btnSubmit.ForeColor = System.Drawing.Color.White

        Me.fc_pnlForm.Controls.Add(Me.fc_lblCust)
        Me.fc_pnlForm.Controls.Add(Me.fc_cmbCustomer)
        Me.fc_pnlForm.Controls.Add(Me.fc_lblProd)
        Me.fc_pnlForm.Controls.Add(Me.fc_cmbProduct)
        Me.fc_pnlForm.Controls.Add(Me.fc_lblPurchDate)
        Me.fc_pnlForm.Controls.Add(Me.fc_txtPurchDate)
        Me.fc_pnlForm.Controls.Add(Me.fc_lblStart)
        Me.fc_pnlForm.Controls.Add(Me.fc_txtStart)
        Me.fc_pnlForm.Controls.Add(Me.fc_lblEnd)
        Me.fc_pnlForm.Controls.Add(Me.fc_txtEnd)
        Me.fc_pnlForm.Controls.Add(Me.fc_lblStatus)
        Me.fc_pnlForm.Controls.Add(Me.fc_txtStatus)
        Me.fc_pnlForm.Controls.Add(Me.fc_lblIssue)
        Me.fc_pnlForm.Controls.Add(Me.fc_txtIssue)
        Me.fc_pnlForm.Controls.Add(Me.fc_btnSubmit)
"""
content = content.replace(init_target, init_target + init_injection)

# 3. Add to Main Controls
main_ctrl_target = "        Me.Controls.Add(Me.pnlViewServiceRequestsMain)"
main_ctrl_injection = """
        Me.Controls.Add(Me.pnlViewWarrantyMain)
        Me.Controls.Add(Me.pnlFileClaimMain)"""
content = content.replace(main_ctrl_target, main_ctrl_target + main_ctrl_injection)

# 4. Friend WithEvents Declarations
friends_target = "    Friend WithEvents vr_colActionUpdate As System.Windows.Forms.DataGridViewButtonColumn"
friends_injection = """
    Friend WithEvents pnlViewWarrantyMain As System.Windows.Forms.Panel
    Friend WithEvents wr_lblTitle As System.Windows.Forms.Label
    Friend WithEvents wr_pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents wr_txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents wr_cmbFilterStatus As System.Windows.Forms.ComboBox
    Friend WithEvents wr_dgvWarranties As System.Windows.Forms.DataGridView
    Friend WithEvents wr_colCust As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wr_colProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wr_colPurchDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wr_colStart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wr_colEnd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wr_colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wr_colActionDetails As System.Windows.Forms.DataGridViewButtonColumn

    Friend WithEvents pnlFileClaimMain As System.Windows.Forms.Panel
    Friend WithEvents fc_lblTitle As System.Windows.Forms.Label
    Friend WithEvents fc_pnlForm As System.Windows.Forms.Panel
    Friend WithEvents fc_lblCust As System.Windows.Forms.Label
    Friend WithEvents fc_cmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents fc_lblProd As System.Windows.Forms.Label
    Friend WithEvents fc_cmbProduct As System.Windows.Forms.ComboBox
    Friend WithEvents fc_lblPurchDate As System.Windows.Forms.Label
    Friend WithEvents fc_txtPurchDate As System.Windows.Forms.TextBox
    Friend WithEvents fc_lblStart As System.Windows.Forms.Label
    Friend WithEvents fc_txtStart As System.Windows.Forms.TextBox
    Friend WithEvents fc_lblEnd As System.Windows.Forms.Label
    Friend WithEvents fc_txtEnd As System.Windows.Forms.TextBox
    Friend WithEvents fc_lblStatus As System.Windows.Forms.Label
    Friend WithEvents fc_txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents fc_lblIssue As System.Windows.Forms.Label
    Friend WithEvents fc_txtIssue As System.Windows.Forms.TextBox
    Friend WithEvents fc_btnSubmit As System.Windows.Forms.Button
"""
content = content.replace(friends_target, friends_target + friends_injection)

with open("c:\\Code Practice\\MideaProShop\\MideaProShop\\Childform.Designer.vb", "w") as f:
    f.write(content)
print("Done")
