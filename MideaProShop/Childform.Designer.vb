<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Childform
    Inherits System.Windows.Forms.Form

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()

        ' DASHBOARD CONTROLS
        Me.pnlDashboardMain = New System.Windows.Forms.Panel()
        Me.lblDashTitle = New System.Windows.Forms.Label()
        Me.flpCards = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlCard1 = New System.Windows.Forms.Panel()
        Me.lblCard1Value = New System.Windows.Forms.Label()
        Me.lblCard1Title = New System.Windows.Forms.Label()
        Me.pnlCard2 = New System.Windows.Forms.Panel()
        Me.lblCard2Value = New System.Windows.Forms.Label()
        Me.lblCard2Title = New System.Windows.Forms.Label()
        Me.pnlCard3 = New System.Windows.Forms.Panel()
        Me.lblCard3Value = New System.Windows.Forms.Label()
        Me.lblCard3Title = New System.Windows.Forms.Label()
        Me.pnlCard4 = New System.Windows.Forms.Panel()
        Me.lblCard4Value = New System.Windows.Forms.Label()
        Me.lblCard4Title = New System.Windows.Forms.Label()

        ' ORDER CONTROLS
        Me.pnlOrderMain = New System.Windows.Forms.Panel()
        Me.o_pnlCategories = New System.Windows.Forms.FlowLayoutPanel()
        Me.o_dgvProducts = New System.Windows.Forms.DataGridView()
        Me.o_colProductID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.o_colProductName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.o_colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.o_colPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.o_colStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.o_colActionAdd = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.o_pnlCart = New System.Windows.Forms.Panel()
        Me.o_lblCartTitle = New System.Windows.Forms.Label()
        Me.o_flpCartItems = New System.Windows.Forms.FlowLayoutPanel()
        Me.o_pnlTotal = New System.Windows.Forms.Panel()
        Me.o_lblTotalLabel = New System.Windows.Forms.Label()
        Me.o_lblTotal = New System.Windows.Forms.Label()
        Me.o_btnContinue = New System.Windows.Forms.Button()
        Me.o_pnlCheckoutForm = New System.Windows.Forms.Panel()
        Me.o_lblCheckoutTitle = New System.Windows.Forms.Label()
        Me.o_flpCheckoutSummary = New System.Windows.Forms.FlowLayoutPanel()
        Me.o_lblFinalTotalTitle = New System.Windows.Forms.Label()
        Me.o_lblFinalTotal = New System.Windows.Forms.Label()
        Me.o_lblCustomerSelectTitle = New System.Windows.Forms.Label()
        Me.o_optExistingCustomer = New System.Windows.Forms.RadioButton()
        Me.o_cmbExistingCustomer = New System.Windows.Forms.ComboBox()
        Me.o_optNewCustomer = New System.Windows.Forms.RadioButton()
        Me.o_pnlNewCustomer = New System.Windows.Forms.Panel()
        Me.o_lblCustName = New System.Windows.Forms.Label()
        Me.o_txtCustName = New System.Windows.Forms.TextBox()
        Me.o_lblCustContact = New System.Windows.Forms.Label()
        Me.o_txtCustContact = New System.Windows.Forms.TextBox()
        Me.o_lblCustAddress = New System.Windows.Forms.Label()
        Me.o_txtCustAddress = New System.Windows.Forms.TextBox()
        Me.o_btnConfirmOrder = New System.Windows.Forms.Button()
        Me.o_btnBackToSales = New System.Windows.Forms.Button()

        ' VIEW ORDERS CONTROLS
        Me.pnlViewOrdersMain = New System.Windows.Forms.Panel()
        Me.v_pnlHeader = New System.Windows.Forms.Panel()
        Me.v_lblTitle = New System.Windows.Forms.Label()
        Me.v_lblDateRange = New System.Windows.Forms.Label()
        Me.v_dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.v_lblTo = New System.Windows.Forms.Label()
        Me.v_dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.v_btnFilter = New System.Windows.Forms.Button()
        Me.v_dgvOrders = New System.Windows.Forms.DataGridView()
        Me.v_colPurchaseID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.v_colReceipt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.v_colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.v_colCustomer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.v_colTotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()

        ' ADD PRODUCT CONTROLS
        Me.pnlAddProductMain = New System.Windows.Forms.Panel()
        Me.a_lblTitle = New System.Windows.Forms.Label()
        Me.a_pnlForm = New System.Windows.Forms.Panel()
        Me.a_btnSave = New System.Windows.Forms.Button()
        Me.a_btnCancel = New System.Windows.Forms.Button()
        Me.a_lblProdName = New System.Windows.Forms.Label()
        Me.a_txtProdName = New System.Windows.Forms.TextBox()
        Me.a_lblProdBrand = New System.Windows.Forms.Label()
        Me.a_txtProdBrand = New System.Windows.Forms.TextBox()
        Me.a_lblProdDesc = New System.Windows.Forms.Label()
        Me.a_txtProdDesc = New System.Windows.Forms.TextBox()
        Me.a_lblCategory = New System.Windows.Forms.Label()
        Me.a_cmbCategory = New System.Windows.Forms.ComboBox()
        Me.a_lblPrice = New System.Windows.Forms.Label()
        Me.a_numPrice = New System.Windows.Forms.NumericUpDown()
        Me.a_lblStock = New System.Windows.Forms.Label()
        Me.a_numStock = New System.Windows.Forms.NumericUpDown()
        Me.a_lblReorder = New System.Windows.Forms.Label()
        Me.a_numReorder = New System.Windows.Forms.NumericUpDown()
        Me.a_lblSupplierTitle = New System.Windows.Forms.Label()
        Me.a_optExistingSupplier = New System.Windows.Forms.RadioButton()
        Me.a_optNewSupplier = New System.Windows.Forms.RadioButton()
        Me.a_cmbExistingSupplier = New System.Windows.Forms.ComboBox()
        Me.a_pnlNewSupplier = New System.Windows.Forms.Panel()
        Me.a_lblSupName = New System.Windows.Forms.Label()
        Me.a_txtSupName = New System.Windows.Forms.TextBox()
        Me.a_lblSupContact = New System.Windows.Forms.Label()
        Me.a_txtSupContact = New System.Windows.Forms.TextBox()
        Me.a_lblSupAddress = New System.Windows.Forms.Label()
        Me.a_txtSupAddress = New System.Windows.Forms.TextBox()

        ' MANAGE PRODUCTS CONTROLS
        Me.pnlManageProductsMain = New System.Windows.Forms.Panel()
        Me.m_pnlCategories = New System.Windows.Forms.FlowLayoutPanel()
        Me.m_dgvProducts = New System.Windows.Forms.DataGridView()
        Me.m_colProductID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_colProductName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_colBrand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_colPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_colStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_colActionEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.m_colActionDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.m_pnlEditProduct = New System.Windows.Forms.Panel()
        Me.m_lblEditTitle = New System.Windows.Forms.Label()
        Me.m_lblEditName = New System.Windows.Forms.Label()
        Me.m_txtEditName = New System.Windows.Forms.TextBox()
        Me.m_lblEditBrand = New System.Windows.Forms.Label()
        Me.m_txtEditBrand = New System.Windows.Forms.TextBox()
        Me.m_lblEditPrice = New System.Windows.Forms.Label()
        Me.m_numEditPrice = New System.Windows.Forms.NumericUpDown()
        Me.m_lblEditStock = New System.Windows.Forms.Label()
        Me.m_numEditStock = New System.Windows.Forms.NumericUpDown()
        Me.m_lblEditReorder = New System.Windows.Forms.Label()
        Me.m_numEditReorder = New System.Windows.Forms.NumericUpDown()
        Me.m_lblEditCategory = New System.Windows.Forms.Label()
        Me.m_cmbEditCategory = New System.Windows.Forms.ComboBox()
        Me.m_btnUpdate = New System.Windows.Forms.Button()
        Me.m_btnCancel = New System.Windows.Forms.Button()

        ' LOW STOCK ALERTS CONTROLS
        Me.pnlLowStockMain = New System.Windows.Forms.Panel()
        Me.l_pnlHeader = New System.Windows.Forms.Panel()
        Me.l_lblTitle = New System.Windows.Forms.Label()
        Me.l_pnlCategories = New System.Windows.Forms.FlowLayoutPanel()
        Me.l_dgvAlerts = New System.Windows.Forms.DataGridView()
        Me.l_colProductID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.l_colProductName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.l_colBrand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.l_colStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.l_colReorder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.l_colSupplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.l_colActionAddStock = New System.Windows.Forms.DataGridViewButtonColumn()

        ' STOCK TRANSACTIONS CONTROLS
        Me.pnlStockTransactionMain = New System.Windows.Forms.Panel()
        Me.s_lblTitle = New System.Windows.Forms.Label()
        Me.s_pnlForm = New System.Windows.Forms.Panel()
        Me.s_lblProduct = New System.Windows.Forms.Label()
        Me.s_cmbProduct = New System.Windows.Forms.ComboBox()
        Me.s_lblType = New System.Windows.Forms.Label()
        Me.s_cmbType = New System.Windows.Forms.ComboBox()
        Me.s_lblQuantity = New System.Windows.Forms.Label()
        Me.s_numQuantity = New System.Windows.Forms.NumericUpDown()
        Me.s_lblRemarks = New System.Windows.Forms.Label()
        Me.s_txtRemarks = New System.Windows.Forms.TextBox()
        Me.s_btnSave = New System.Windows.Forms.Button()
        Me.s_dgvHistory = New System.Windows.Forms.DataGridView()
        Me.s_colTransID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_colProduct = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_colType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_colQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_colRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()

        ' SERVICE MODULE CONTROLS
        Me.pnlManageServiceMain = New System.Windows.Forms.Panel()
        Me.sv_lblTitle = New System.Windows.Forms.Label()
        Me.sv_pnlForm = New System.Windows.Forms.Panel()
        Me.sv_lblType = New System.Windows.Forms.Label()
        Me.sv_txtType = New System.Windows.Forms.TextBox()
        Me.sv_lblDesc = New System.Windows.Forms.Label()
        Me.sv_txtDesc = New System.Windows.Forms.TextBox()
        Me.sv_lblFee = New System.Windows.Forms.Label()
        Me.sv_numFee = New System.Windows.Forms.NumericUpDown()
        Me.sv_btnSave = New System.Windows.Forms.Button()
        Me.sv_btnCancel = New System.Windows.Forms.Button()
        Me.sv_dgvServices = New System.Windows.Forms.DataGridView()
        Me.sv_colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sv_colType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sv_colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sv_colFee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sv_colActionEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.sv_colActionDelete = New System.Windows.Forms.DataGridViewButtonColumn()

        Me.pnlAddServiceRequestMain = New System.Windows.Forms.Panel()
        Me.sr_lblTitle = New System.Windows.Forms.Label()
        Me.sr_pnlForm = New System.Windows.Forms.Panel()
        Me.sr_optExistingCust = New System.Windows.Forms.RadioButton()
        Me.sr_optNewCust = New System.Windows.Forms.RadioButton()
        Me.sr_cmbExistingCust = New System.Windows.Forms.ComboBox()
        Me.sr_txtCustName = New System.Windows.Forms.TextBox()
        Me.sr_txtCustContact = New System.Windows.Forms.TextBox()
        Me.sr_cmbService = New System.Windows.Forms.ComboBox()
        Me.sr_cmbStaff = New System.Windows.Forms.ComboBox()
        Me.sr_cmbTech = New System.Windows.Forms.ComboBox()
        Me.sr_txtAddress = New System.Windows.Forms.TextBox()
        Me.sr_dtpScheduled = New System.Windows.Forms.DateTimePicker()
        Me.sr_cmbStatus = New System.Windows.Forms.ComboBox()
        Me.sr_btnSave = New System.Windows.Forms.Button()

        Me.sr_lblService = New System.Windows.Forms.Label()
        Me.sr_lblStaff = New System.Windows.Forms.Label()
        Me.sr_lblTech = New System.Windows.Forms.Label()
        Me.sr_lblAddress = New System.Windows.Forms.Label()
        Me.sr_lblScheduled = New System.Windows.Forms.Label()
        Me.sr_lblStatus = New System.Windows.Forms.Label()

        Me.sr_lblSectionCustomer = New System.Windows.Forms.Label()
        Me.sr_lblSectionService = New System.Windows.Forms.Label()
        Me.sr_lblSectionStaff = New System.Windows.Forms.Label()
        Me.sr_lblCust = New System.Windows.Forms.Label()
        Me.sr_txtCustAddress = New System.Windows.Forms.TextBox()
        Me.sr_lblReqDate = New System.Windows.Forms.Label()
        Me.sr_dtpRequest = New System.Windows.Forms.DateTimePicker()
        Me.sr_btnCancel = New System.Windows.Forms.Button()

        Me.pnlViewServiceRequestsMain = New System.Windows.Forms.Panel()
        Me.vr_lblTitle = New System.Windows.Forms.Label()
        Me.vr_pnlFilter = New System.Windows.Forms.Panel()
        Me.vr_txtSearch = New System.Windows.Forms.TextBox()
        Me.vr_cmbFilterStatus = New System.Windows.Forms.ComboBox()
        Me.vr_dgvRequests = New System.Windows.Forms.DataGridView()
        Me.vr_colReqID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vr_colCust = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vr_colService = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vr_colStaff = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vr_colTech = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vr_colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vr_colSched = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vr_colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vr_colActionUpdate = New System.Windows.Forms.DataGridViewButtonColumn()

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
        Me.wr_colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wr_colActionEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.wr_colActionDelete = New System.Windows.Forms.DataGridViewButtonColumn()

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
        ' INITS
        Me.flpCards.SuspendLayout()
        Me.pnlCard1.SuspendLayout()
        Me.pnlCard2.SuspendLayout()
        Me.pnlCard3.SuspendLayout()
        Me.pnlCard4.SuspendLayout()
        Me.pnlDashboardMain.SuspendLayout()
        
        CType(Me.o_dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.o_pnlCart.SuspendLayout()
        Me.o_pnlTotal.SuspendLayout()
        Me.o_pnlCheckoutForm.SuspendLayout()
        Me.o_pnlNewCustomer.SuspendLayout()
        Me.pnlOrderMain.SuspendLayout()

        Me.v_pnlHeader.SuspendLayout()
        CType(Me.v_dgvOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlViewOrdersMain.SuspendLayout()

        Me.a_pnlForm.SuspendLayout()
        CType(Me.a_numPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.a_numStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.a_numReorder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.a_pnlNewSupplier.SuspendLayout()
        Me.pnlAddProductMain.SuspendLayout()

        CType(Me.m_dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.m_pnlEditProduct.SuspendLayout()
        CType(Me.m_numEditPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_numEditStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_numEditReorder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlManageProductsMain.SuspendLayout()

        Me.l_pnlHeader.SuspendLayout()
        CType(Me.l_dgvAlerts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLowStockMain.SuspendLayout()

        Me.pnlStockTransactionMain.SuspendLayout()
        Me.s_pnlForm.SuspendLayout()
        CType(Me.s_numQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.s_dgvHistory, System.ComponentModel.ISupportInitialize).BeginInit()

        Me.pnlManageServiceMain.SuspendLayout()
        Me.sv_pnlForm.SuspendLayout()
        CType(Me.sv_numFee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sv_dgvServices, System.ComponentModel.ISupportInitialize).BeginInit()
        
        Me.pnlAddServiceRequestMain.SuspendLayout()
        Me.sr_pnlForm.SuspendLayout()

        Me.pnlViewServiceRequestsMain.SuspendLayout()
        Me.vr_pnlFilter.SuspendLayout()
        CType(Me.vr_dgvRequests, System.ComponentModel.ISupportInitialize).BeginInit()

        Me.SuspendLayout()

        ' ==============================
        ' DASHBOARD
        ' ==============================
        Me.pnlDashboardMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDashboardMain.Controls.Add(Me.flpCards)
        Me.pnlDashboardMain.Controls.Add(Me.lblDashTitle)
        
        Me.lblDashTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDashTitle.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblDashTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30)
        Me.lblDashTitle.Text = "Dashboard"
        Me.lblDashTitle.Size = New System.Drawing.Size(864, 70)
        Me.lblDashTitle.Padding = New System.Windows.Forms.Padding(30, 20, 0, 10)

        Me.flpCards.Dock = System.Windows.Forms.DockStyle.Top
        Me.flpCards.Size = New System.Drawing.Size(864, 160)
        Me.flpCards.Padding = New System.Windows.Forms.Padding(25, 10, 25, 10)
        Me.flpCards.Controls.Add(Me.pnlCard1)
        Me.flpCards.Controls.Add(Me.pnlCard2)
        Me.flpCards.Controls.Add(Me.pnlCard3)
        Me.flpCards.Controls.Add(Me.pnlCard4)

        ' Cards
        Me.pnlCard1.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.pnlCard1.Size = New System.Drawing.Size(185, 130)
        Me.pnlCard1.Margin = New System.Windows.Forms.Padding(3, 3, 15, 3)
        Me.pnlCard1.Controls.Add(Me.lblCard1Value)
        Me.pnlCard1.Controls.Add(Me.lblCard1Title)

        Me.lblCard1Value.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCard1Value.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblCard1Value.ForeColor = System.Drawing.Color.White
        Me.lblCard1Value.Text = "0"
        Me.lblCard1Value.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)

        Me.lblCard1Title.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCard1Title.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblCard1Title.ForeColor = System.Drawing.Color.White
        Me.lblCard1Title.Text = "Total Sales"
        Me.lblCard1Title.Padding = New System.Windows.Forms.Padding(15, 15, 0, 0)
        Me.lblCard1Title.Size = New System.Drawing.Size(185, 45)

        Me.pnlCard2.BackColor = System.Drawing.Color.FromArgb(40, 167, 69)
        Me.pnlCard2.Size = New System.Drawing.Size(185, 130)
        Me.pnlCard2.Margin = New System.Windows.Forms.Padding(3, 3, 15, 3)
        Me.pnlCard2.Controls.Add(Me.lblCard2Value)
        Me.pnlCard2.Controls.Add(Me.lblCard2Title)

        Me.lblCard2Value.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCard2Value.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblCard2Value.ForeColor = System.Drawing.Color.White
        Me.lblCard2Value.Text = "0"
        Me.lblCard2Value.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)

        Me.lblCard2Title.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCard2Title.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblCard2Title.ForeColor = System.Drawing.Color.White
        Me.lblCard2Title.Text = "Transactions"
        Me.lblCard2Title.Padding = New System.Windows.Forms.Padding(15, 15, 0, 0)
        Me.lblCard2Title.Size = New System.Drawing.Size(185, 45)

        Me.pnlCard3.BackColor = System.Drawing.Color.FromArgb(255, 152, 0)
        Me.pnlCard3.Size = New System.Drawing.Size(185, 130)
        Me.pnlCard3.Margin = New System.Windows.Forms.Padding(3, 3, 15, 3)
        Me.pnlCard3.Controls.Add(Me.lblCard3Value)
        Me.pnlCard3.Controls.Add(Me.lblCard3Title)

        Me.lblCard3Value.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCard3Value.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblCard3Value.ForeColor = System.Drawing.Color.White
        Me.lblCard3Value.Text = "0"
        Me.lblCard3Value.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)

        Me.lblCard3Title.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCard3Title.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblCard3Title.ForeColor = System.Drawing.Color.White
        Me.lblCard3Title.Text = "Service Requests"
        Me.lblCard3Title.Padding = New System.Windows.Forms.Padding(15, 15, 0, 0)
        Me.lblCard3Title.Size = New System.Drawing.Size(185, 45)

        Me.pnlCard4.BackColor = System.Drawing.Color.FromArgb(220, 53, 69)
        Me.pnlCard4.Size = New System.Drawing.Size(185, 130)
        Me.pnlCard4.Margin = New System.Windows.Forms.Padding(3, 3, 15, 3)
        Me.pnlCard4.Controls.Add(Me.lblCard4Value)
        Me.pnlCard4.Controls.Add(Me.lblCard4Title)

        Me.lblCard4Value.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCard4Value.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblCard4Value.ForeColor = System.Drawing.Color.White
        Me.lblCard4Value.Text = "0"
        Me.lblCard4Value.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)

        Me.lblCard4Title.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCard4Title.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblCard4Title.ForeColor = System.Drawing.Color.White
        Me.lblCard4Title.Text = "Warranty Claims"
        Me.lblCard4Title.Padding = New System.Windows.Forms.Padding(15, 15, 0, 0)
        Me.lblCard4Title.Size = New System.Drawing.Size(185, 45)

        ' ==============================
        ' ORDER 
        ' ==============================
        Me.pnlOrderMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOrderMain.Visible = False
        Me.pnlOrderMain.Controls.Add(Me.o_pnlCheckoutForm)
        Me.pnlOrderMain.Controls.Add(Me.o_dgvProducts)
        Me.pnlOrderMain.Controls.Add(Me.o_pnlCategories)
        Me.pnlOrderMain.Controls.Add(Me.o_pnlCart)
        
        Me.o_pnlCategories.Dock = System.Windows.Forms.DockStyle.Top
        Me.o_pnlCategories.Padding = New System.Windows.Forms.Padding(10)
        Me.o_pnlCategories.Size = New System.Drawing.Size(800, 60)
        
        Me.o_pnlCart.Dock = System.Windows.Forms.DockStyle.Right
        Me.o_pnlCart.Width = 350
        Me.o_pnlCart.BackColor = System.Drawing.Color.White
        Me.o_pnlCart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.o_pnlCart.Controls.Add(Me.o_flpCartItems)
        Me.o_pnlCart.Controls.Add(Me.o_lblCartTitle)
        Me.o_pnlCart.Controls.Add(Me.o_pnlTotal)
        
        Me.o_lblCartTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.o_lblCartTitle.Text = "Current Order"
        Me.o_lblCartTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.o_lblCartTitle.Size = New System.Drawing.Size(350, 40)
        Me.o_lblCartTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        Me.o_flpCartItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.o_flpCartItems.AutoScroll = True

        Me.o_pnlTotal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.o_pnlTotal.Size = New System.Drawing.Size(350, 100)
        Me.o_pnlTotal.Controls.Add(Me.o_lblTotalLabel)
        Me.o_pnlTotal.Controls.Add(Me.o_lblTotal)
        Me.o_pnlTotal.Controls.Add(Me.o_btnContinue)
        
        Me.o_lblTotalLabel.Text = "Total:"
        Me.o_lblTotalLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.o_lblTotalLabel.Location = New System.Drawing.Point(20, 15)
        Me.o_lblTotalLabel.AutoSize = True
        
        Me.o_lblTotal.Text = "₱0.00"
        Me.o_lblTotal.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.o_lblTotal.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69)
        Me.o_lblTotal.Location = New System.Drawing.Point(150, 10)
        Me.o_lblTotal.AutoSize = True

        Me.o_btnContinue.Text = "Continue Checkout"
        Me.o_btnContinue.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.o_btnContinue.ForeColor = System.Drawing.Color.White
        Me.o_btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.o_btnContinue.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.o_btnContinue.Size = New System.Drawing.Size(310, 40)
        Me.o_btnContinue.Location = New System.Drawing.Point(20, 50)
        Me.o_btnContinue.Enabled = False

        Me.o_dgvProducts.AllowUserToAddRows = False
        Me.o_dgvProducts.AllowUserToDeleteRows = False
        Me.o_dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.o_dgvProducts.BackgroundColor = System.Drawing.Color.FromArgb(245, 245, 248)
        Me.o_dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.o_dgvProducts.RowHeadersVisible = False
        Me.o_dgvProducts.RowTemplate.Height = 50
        Me.o_dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.o_dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.o_dgvProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.o_colProductID, Me.o_colProductName, Me.o_colDesc, Me.o_colPrice, Me.o_colStock, Me.o_colActionAdd})

        Me.o_colProductID.Name = "o_colProductID"
        Me.o_colProductID.Visible = False

        Me.o_colProductName.HeaderText = "Product"
        Me.o_colProductName.Name = "o_colProductName"

        Me.o_colDesc.HeaderText = "Description"
        Me.o_colDesc.Name = "o_colDesc"

        DataGridViewCellStyle1.Format = "C2"
        Me.o_colPrice.DefaultCellStyle = DataGridViewCellStyle1
        Me.o_colPrice.HeaderText = "Price"
        Me.o_colPrice.Name = "o_colPrice"

        Me.o_colStock.HeaderText = "Stock"
        Me.o_colStock.Name = "o_colStock"

        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.o_colActionAdd.DefaultCellStyle = DataGridViewCellStyle2
        Me.o_colActionAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.o_colActionAdd.HeaderText = "Action"
        Me.o_colActionAdd.Name = "o_colActionAdd"
        Me.o_colActionAdd.Text = "Add to Cart"
        Me.o_colActionAdd.UseColumnTextForButtonValue = True

        ' Checkout Form Panel
        Me.o_pnlCheckoutForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.o_pnlCheckoutForm.BackColor = System.Drawing.Color.White
        Me.o_pnlCheckoutForm.Visible = False

        Me.o_lblCheckoutTitle.AutoSize = True
        Me.o_lblCheckoutTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.o_lblCheckoutTitle.Location = New System.Drawing.Point(30, 20)
        Me.o_lblCheckoutTitle.Text = "Checkout Summary"

        Me.o_flpCheckoutSummary.Location = New System.Drawing.Point(30, 70)
        Me.o_flpCheckoutSummary.Size = New System.Drawing.Size(300, 300)
        Me.o_flpCheckoutSummary.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.o_flpCheckoutSummary.AutoScroll = True

        Me.o_lblFinalTotalTitle.AutoSize = True
        Me.o_lblFinalTotalTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.o_lblFinalTotalTitle.Location = New System.Drawing.Point(30, 390)
        Me.o_lblFinalTotalTitle.Text = "Final Amount:"

        Me.o_lblFinalTotal.AutoSize = True
        Me.o_lblFinalTotal.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.o_lblFinalTotal.ForeColor = System.Drawing.Color.Crimson
        Me.o_lblFinalTotal.Location = New System.Drawing.Point(180, 385)
        Me.o_lblFinalTotal.Text = "₱0.00"

        Me.o_lblCustomerSelectTitle.AutoSize = True
        Me.o_lblCustomerSelectTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.o_lblCustomerSelectTitle.Location = New System.Drawing.Point(400, 70)
        Me.o_lblCustomerSelectTitle.Text = "Customer Details"

        Me.o_optExistingCustomer.AutoSize = True
        Me.o_optExistingCustomer.Location = New System.Drawing.Point(400, 110)
        Me.o_optExistingCustomer.Text = "Existing Customer"
        Me.o_optExistingCustomer.Checked = True

        Me.o_cmbExistingCustomer.Location = New System.Drawing.Point(420, 135)
        Me.o_cmbExistingCustomer.Size = New System.Drawing.Size(250, 25)
        Me.o_cmbExistingCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

        Me.o_optNewCustomer.AutoSize = True
        Me.o_optNewCustomer.Location = New System.Drawing.Point(400, 180)
        Me.o_optNewCustomer.Text = "New Customer"

        Me.o_pnlNewCustomer.Location = New System.Drawing.Point(420, 210)
        Me.o_pnlNewCustomer.Size = New System.Drawing.Size(300, 170)
        
        Me.o_lblCustName.AutoSize = True
        Me.o_lblCustName.Location = New System.Drawing.Point(0, 0)
        Me.o_lblCustName.Text = "Full Name"
        Me.o_txtCustName.Location = New System.Drawing.Point(0, 20)
        Me.o_txtCustName.Size = New System.Drawing.Size(250, 25)

        Me.o_lblCustContact.AutoSize = True
        Me.o_lblCustContact.Location = New System.Drawing.Point(0, 55)
        Me.o_lblCustContact.Text = "Contact Number"
        Me.o_txtCustContact.Location = New System.Drawing.Point(0, 75)
        Me.o_txtCustContact.Size = New System.Drawing.Size(250, 25)

        Me.o_lblCustAddress.AutoSize = True
        Me.o_lblCustAddress.Location = New System.Drawing.Point(0, 110)
        Me.o_lblCustAddress.Text = "Address"
        Me.o_txtCustAddress.Location = New System.Drawing.Point(0, 130)
        Me.o_txtCustAddress.Size = New System.Drawing.Size(250, 25)

        Me.o_pnlNewCustomer.Controls.Add(Me.o_lblCustName)
        Me.o_pnlNewCustomer.Controls.Add(Me.o_txtCustName)
        Me.o_pnlNewCustomer.Controls.Add(Me.o_lblCustContact)
        Me.o_pnlNewCustomer.Controls.Add(Me.o_txtCustContact)
        Me.o_pnlNewCustomer.Controls.Add(Me.o_lblCustAddress)
        Me.o_pnlNewCustomer.Controls.Add(Me.o_txtCustAddress)

        Me.o_btnConfirmOrder.Text = "Confirm Order"
        Me.o_btnConfirmOrder.BackColor = System.Drawing.Color.FromArgb(40, 167, 69)
        Me.o_btnConfirmOrder.ForeColor = System.Drawing.Color.White
        Me.o_btnConfirmOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.o_btnConfirmOrder.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.o_btnConfirmOrder.Location = New System.Drawing.Point(400, 390)
        Me.o_btnConfirmOrder.Size = New System.Drawing.Size(200, 45)

        Me.o_btnBackToSales.Text = "Back"
        Me.o_btnBackToSales.BackColor = System.Drawing.Color.Gray
        Me.o_btnBackToSales.ForeColor = System.Drawing.Color.White
        Me.o_btnBackToSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.o_btnBackToSales.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.o_btnBackToSales.Location = New System.Drawing.Point(620, 390)
        Me.o_btnBackToSales.Size = New System.Drawing.Size(100, 45)

        Me.o_pnlCheckoutForm.Controls.Add(Me.o_lblCheckoutTitle)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_flpCheckoutSummary)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_lblFinalTotalTitle)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_lblFinalTotal)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_lblCustomerSelectTitle)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_optExistingCustomer)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_cmbExistingCustomer)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_optNewCustomer)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_pnlNewCustomer)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_btnConfirmOrder)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_btnBackToSales)


        ' ==============================
        ' VIEW ORDERS
        ' ==============================
        Me.pnlViewOrdersMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlViewOrdersMain.Visible = False
        Me.pnlViewOrdersMain.Controls.Add(Me.v_dgvOrders)
        Me.pnlViewOrdersMain.Controls.Add(Me.v_pnlHeader)

        Me.v_pnlHeader.BackColor = System.Drawing.Color.White
        Me.v_pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.v_pnlHeader.Size = New System.Drawing.Size(800, 80)
        Me.v_pnlHeader.Controls.Add(Me.v_lblTitle)
        Me.v_pnlHeader.Controls.Add(Me.v_lblDateRange)
        Me.v_pnlHeader.Controls.Add(Me.v_dtpStart)
        Me.v_pnlHeader.Controls.Add(Me.v_lblTo)
        Me.v_pnlHeader.Controls.Add(Me.v_dtpEnd)
        Me.v_pnlHeader.Controls.Add(Me.v_btnFilter)

        Me.v_lblTitle.AutoSize = True
        Me.v_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.v_lblTitle.Location = New System.Drawing.Point(20, 20)
        Me.v_lblTitle.Text = "Transaction History"

        Me.v_lblDateRange.AutoSize = True
        Me.v_lblDateRange.Location = New System.Drawing.Point(300, 30)
        Me.v_lblDateRange.Text = "Date Range:"

        Me.v_dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.v_dtpStart.Location = New System.Drawing.Point(380, 25)
        Me.v_dtpStart.Size = New System.Drawing.Size(120, 25)

        Me.v_lblTo.AutoSize = True
        Me.v_lblTo.Location = New System.Drawing.Point(510, 30)
        Me.v_lblTo.Text = "to"

        Me.v_dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.v_dtpEnd.Location = New System.Drawing.Point(540, 25)
        Me.v_dtpEnd.Size = New System.Drawing.Size(120, 25)

        Me.v_btnFilter.Text = "Filter"
        Me.v_btnFilter.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.v_btnFilter.ForeColor = System.Drawing.Color.White
        Me.v_btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.v_btnFilter.Location = New System.Drawing.Point(680, 20)
        Me.v_btnFilter.Size = New System.Drawing.Size(80, 35)

        Me.v_dgvOrders.AllowUserToAddRows = False
        Me.v_dgvOrders.AllowUserToDeleteRows = False
        Me.v_dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.v_dgvOrders.BackgroundColor = System.Drawing.Color.FromArgb(245, 245, 248)
        Me.v_dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.v_dgvOrders.RowHeadersVisible = False
        Me.v_dgvOrders.RowTemplate.Height = 40
        Me.v_dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.v_dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.v_dgvOrders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.v_colPurchaseID, Me.v_colReceipt, Me.v_colDate, Me.v_colCustomer, Me.v_colTotalAmount})

        Me.v_colPurchaseID.Name = "v_colPurchaseID"
        Me.v_colPurchaseID.Visible = False
        Me.v_colReceipt.HeaderText = "Receipt Number"
        Me.v_colReceipt.Name = "v_colReceipt"
        Me.v_colDate.HeaderText = "Date"
        Me.v_colDate.Name = "v_colDate"
        Me.v_colCustomer.HeaderText = "Customer"
        Me.v_colCustomer.Name = "v_colCustomer"
        DataGridViewCellStyle3.Format = "C2"
        Me.v_colTotalAmount.DefaultCellStyle = DataGridViewCellStyle3
        Me.v_colTotalAmount.HeaderText = "Total Amount"
        Me.v_colTotalAmount.Name = "v_colTotalAmount"

        ' ==============================
        ' ADD PRODUCT
        ' ==============================
        Me.pnlAddProductMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAddProductMain.Visible = False
        Me.pnlAddProductMain.Controls.Add(Me.a_lblTitle)
        Me.pnlAddProductMain.Controls.Add(Me.a_pnlForm)

        Me.a_lblTitle.AutoSize = True
        Me.a_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.a_lblTitle.Location = New System.Drawing.Point(30, 20)
        Me.a_lblTitle.Text = "Add New Product"

        Me.a_pnlForm.AutoScroll = True
        Me.a_pnlForm.BackColor = System.Drawing.Color.White
        Me.a_pnlForm.Location = New System.Drawing.Point(30, 70)
        Me.a_pnlForm.Size = New System.Drawing.Size(750, 450)
        Me.a_pnlForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

        Me.a_lblProdName.Location = New System.Drawing.Point(30, 30)
        Me.a_lblProdName.Text = "Product Name"
        Me.a_lblProdName.AutoSize = True
        Me.a_txtProdName.Location = New System.Drawing.Point(30, 50)
        Me.a_txtProdName.Size = New System.Drawing.Size(250, 25)

        Me.a_lblProdBrand.Location = New System.Drawing.Point(30, 90)
        Me.a_lblProdBrand.Text = "Brand"
        Me.a_lblProdBrand.AutoSize = True
        Me.a_txtProdBrand.Location = New System.Drawing.Point(30, 110)
        Me.a_txtProdBrand.Size = New System.Drawing.Size(250, 25)

        Me.a_lblCategory.Location = New System.Drawing.Point(30, 150)
        Me.a_lblCategory.Text = "Category"
        Me.a_lblCategory.AutoSize = True
        Me.a_cmbCategory.Location = New System.Drawing.Point(30, 170)
        Me.a_cmbCategory.Size = New System.Drawing.Size(250, 25)
        Me.a_cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.a_cmbCategory.Items.AddRange(New Object() {"Air Conditioners", "Washing Machines", "Televisions", "Refrigerators"})

        Me.a_lblProdDesc.Location = New System.Drawing.Point(30, 210)
        Me.a_lblProdDesc.Text = "Description"
        Me.a_lblProdDesc.AutoSize = True
        Me.a_txtProdDesc.Location = New System.Drawing.Point(30, 230)
        Me.a_txtProdDesc.Size = New System.Drawing.Size(250, 50)
        Me.a_txtProdDesc.Multiline = True

        Me.a_lblPrice.Location = New System.Drawing.Point(320, 30)
        Me.a_lblPrice.Text = "Unit Price (₱)"
        Me.a_lblPrice.AutoSize = True
        Me.a_numPrice.Location = New System.Drawing.Point(320, 50)
        Me.a_numPrice.Size = New System.Drawing.Size(120, 25)
        Me.a_numPrice.DecimalPlaces = 2
        Me.a_numPrice.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})

        Me.a_lblStock.Location = New System.Drawing.Point(320, 90)
        Me.a_lblStock.Text = "Initial Stock"
        Me.a_lblStock.AutoSize = True
        Me.a_numStock.Location = New System.Drawing.Point(320, 110)
        Me.a_numStock.Size = New System.Drawing.Size(120, 25)
        Me.a_numStock.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})

        Me.a_lblReorder.Location = New System.Drawing.Point(320, 150)
        Me.a_lblReorder.Text = "Reorder Level"
        Me.a_lblReorder.AutoSize = True
        Me.a_numReorder.Location = New System.Drawing.Point(320, 170)
        Me.a_numReorder.Size = New System.Drawing.Size(120, 25)
        Me.a_numReorder.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})

        Me.a_lblSupplierTitle.Location = New System.Drawing.Point(480, 30)
        Me.a_lblSupplierTitle.Text = "Supplier Information"
        Me.a_lblSupplierTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.a_lblSupplierTitle.AutoSize = True

        Me.a_optExistingSupplier.Location = New System.Drawing.Point(480, 60)
        Me.a_optExistingSupplier.Text = "Existing Supplier"
        Me.a_optExistingSupplier.AutoSize = True
        Me.a_optExistingSupplier.Checked = True

        Me.a_cmbExistingSupplier.Location = New System.Drawing.Point(500, 85)
        Me.a_cmbExistingSupplier.Size = New System.Drawing.Size(200, 25)
        Me.a_cmbExistingSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

        Me.a_optNewSupplier.Location = New System.Drawing.Point(480, 120)
        Me.a_optNewSupplier.Text = "New Supplier"
        Me.a_optNewSupplier.AutoSize = True

        Me.a_pnlNewSupplier.Location = New System.Drawing.Point(500, 145)
        Me.a_pnlNewSupplier.Size = New System.Drawing.Size(220, 180)

        Me.a_lblSupName.Location = New System.Drawing.Point(0, 0)
        Me.a_lblSupName.Text = "Supplier Name"
        Me.a_lblSupName.AutoSize = True
        Me.a_txtSupName.Location = New System.Drawing.Point(0, 20)
        Me.a_txtSupName.Size = New System.Drawing.Size(200, 25)

        Me.a_lblSupContact.Location = New System.Drawing.Point(0, 55)
        Me.a_lblSupContact.Text = "Contact Number"
        Me.a_lblSupContact.AutoSize = True
        Me.a_txtSupContact.Location = New System.Drawing.Point(0, 75)
        Me.a_txtSupContact.Size = New System.Drawing.Size(200, 25)

        Me.a_lblSupAddress.Location = New System.Drawing.Point(0, 110)
        Me.a_lblSupAddress.Text = "Address"
        Me.a_lblSupAddress.AutoSize = True
        Me.a_txtSupAddress.Location = New System.Drawing.Point(0, 130)
        Me.a_txtSupAddress.Size = New System.Drawing.Size(200, 25)

        Me.a_pnlNewSupplier.Controls.Add(Me.a_lblSupName)
        Me.a_pnlNewSupplier.Controls.Add(Me.a_txtSupName)
        Me.a_pnlNewSupplier.Controls.Add(Me.a_lblSupContact)
        Me.a_pnlNewSupplier.Controls.Add(Me.a_txtSupContact)
        Me.a_pnlNewSupplier.Controls.Add(Me.a_lblSupAddress)
        Me.a_pnlNewSupplier.Controls.Add(Me.a_txtSupAddress)

        Me.a_btnSave.Text = "Save Product"
        Me.a_btnSave.BackColor = System.Drawing.Color.FromArgb(40, 167, 69)
        Me.a_btnSave.ForeColor = System.Drawing.Color.White
        Me.a_btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.a_btnSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.a_btnSave.Location = New System.Drawing.Point(30, 310)
        Me.a_btnSave.Size = New System.Drawing.Size(150, 40)

        Me.a_btnCancel.Text = "Clear Fields"
        Me.a_btnCancel.BackColor = System.Drawing.Color.White
        Me.a_btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.a_btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.a_btnCancel.Location = New System.Drawing.Point(190, 310)
        Me.a_btnCancel.Size = New System.Drawing.Size(120, 40)

        Me.a_pnlForm.Controls.Add(Me.a_lblProdName)
        Me.a_pnlForm.Controls.Add(Me.a_txtProdName)
        Me.a_pnlForm.Controls.Add(Me.a_lblProdBrand)
        Me.a_pnlForm.Controls.Add(Me.a_txtProdBrand)
        Me.a_pnlForm.Controls.Add(Me.a_lblCategory)
        Me.a_pnlForm.Controls.Add(Me.a_cmbCategory)
        Me.a_pnlForm.Controls.Add(Me.a_lblProdDesc)
        Me.a_pnlForm.Controls.Add(Me.a_txtProdDesc)
        Me.a_pnlForm.Controls.Add(Me.a_lblPrice)
        Me.a_pnlForm.Controls.Add(Me.a_numPrice)
        Me.a_pnlForm.Controls.Add(Me.a_lblStock)
        Me.a_pnlForm.Controls.Add(Me.a_numStock)
        Me.a_pnlForm.Controls.Add(Me.a_lblReorder)
        Me.a_pnlForm.Controls.Add(Me.a_numReorder)
        Me.a_pnlForm.Controls.Add(Me.a_lblSupplierTitle)
        Me.a_pnlForm.Controls.Add(Me.a_optExistingSupplier)
        Me.a_pnlForm.Controls.Add(Me.a_cmbExistingSupplier)
        Me.a_pnlForm.Controls.Add(Me.a_optNewSupplier)
        Me.a_pnlForm.Controls.Add(Me.a_pnlNewSupplier)
        Me.a_pnlForm.Controls.Add(Me.a_btnSave)
        Me.a_pnlForm.Controls.Add(Me.a_btnCancel)

        ' ==============================
        ' MANAGE PRODUCTS
        ' ==============================
        Me.pnlManageProductsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlManageProductsMain.Visible = False
        Me.pnlManageProductsMain.Controls.Add(Me.m_pnlEditProduct)
        Me.pnlManageProductsMain.Controls.Add(Me.m_dgvProducts)
        Me.pnlManageProductsMain.Controls.Add(Me.m_pnlCategories)

        Me.m_pnlCategories.Dock = System.Windows.Forms.DockStyle.Top
        Me.m_pnlCategories.Padding = New System.Windows.Forms.Padding(10)
        Me.m_pnlCategories.Size = New System.Drawing.Size(800, 60)

        Me.m_dgvProducts.AllowUserToAddRows = False
        Me.m_dgvProducts.AllowUserToDeleteRows = False
        Me.m_dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.m_dgvProducts.BackgroundColor = System.Drawing.Color.FromArgb(245, 245, 248)
        Me.m_dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.m_dgvProducts.RowHeadersVisible = False
        Me.m_dgvProducts.RowTemplate.Height = 40
        Me.m_dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.m_dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_dgvProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.m_colProductID, Me.m_colProductName, Me.m_colBrand, Me.m_colPrice, Me.m_colStock, Me.m_colActionEdit, Me.m_colActionDelete})

        Me.m_colProductID.Name = "m_colProductID"
        Me.m_colProductID.Visible = False
        Me.m_colProductName.HeaderText = "Product Name"
        Me.m_colProductName.Name = "m_colProductName"
        Me.m_colBrand.HeaderText = "Brand"
        Me.m_colBrand.Name = "m_colBrand"
        DataGridViewCellStyle4.Format = "C2"
        Me.m_colPrice.DefaultCellStyle = DataGridViewCellStyle4
        Me.m_colPrice.HeaderText = "Price"
        Me.m_colPrice.Name = "m_colPrice"
        Me.m_colStock.HeaderText = "Stock"
        Me.m_colStock.Name = "m_colStock"

        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        Me.m_colActionEdit.DefaultCellStyle = DataGridViewCellStyle5
        Me.m_colActionEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.m_colActionEdit.HeaderText = "Action"
        Me.m_colActionEdit.Name = "m_colActionEdit"
        Me.m_colActionEdit.Text = "Edit"
        Me.m_colActionEdit.UseColumnTextForButtonValue = True

        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        Me.m_colActionDelete.DefaultCellStyle = DataGridViewCellStyle6
        Me.m_colActionDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.m_colActionDelete.HeaderText = "Action"
        Me.m_colActionDelete.Name = "m_colActionDelete"
        Me.m_colActionDelete.Text = "Delete"
        Me.m_colActionDelete.UseColumnTextForButtonValue = True

        Me.m_pnlEditProduct.BackColor = System.Drawing.Color.White
        Me.m_pnlEditProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_pnlEditProduct.Visible = False
        Me.m_pnlEditProduct.Controls.Add(Me.m_lblEditTitle)
        Me.m_pnlEditProduct.Controls.Add(Me.m_lblEditName)
        Me.m_pnlEditProduct.Controls.Add(Me.m_txtEditName)
        Me.m_pnlEditProduct.Controls.Add(Me.m_lblEditBrand)
        Me.m_pnlEditProduct.Controls.Add(Me.m_txtEditBrand)
        Me.m_pnlEditProduct.Controls.Add(Me.m_lblEditCategory)
        Me.m_pnlEditProduct.Controls.Add(Me.m_cmbEditCategory)
        Me.m_pnlEditProduct.Controls.Add(Me.m_lblEditPrice)
        Me.m_pnlEditProduct.Controls.Add(Me.m_numEditPrice)
        Me.m_pnlEditProduct.Controls.Add(Me.m_lblEditStock)
        Me.m_pnlEditProduct.Controls.Add(Me.m_numEditStock)
        Me.m_pnlEditProduct.Controls.Add(Me.m_lblEditReorder)
        Me.m_pnlEditProduct.Controls.Add(Me.m_numEditReorder)
        Me.m_pnlEditProduct.Controls.Add(Me.m_btnUpdate)
        Me.m_pnlEditProduct.Controls.Add(Me.m_btnCancel)

        Me.m_lblEditTitle.AutoSize = True
        Me.m_lblEditTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.m_lblEditTitle.Location = New System.Drawing.Point(30, 30)
        Me.m_lblEditTitle.Text = "Edit Product"

        Me.m_lblEditName.AutoSize = True
        Me.m_lblEditName.Location = New System.Drawing.Point(30, 80)
        Me.m_lblEditName.Text = "Product Name"
        Me.m_txtEditName.Location = New System.Drawing.Point(30, 100)
        Me.m_txtEditName.Size = New System.Drawing.Size(250, 25)

        Me.m_lblEditBrand.AutoSize = True
        Me.m_lblEditBrand.Location = New System.Drawing.Point(30, 140)
        Me.m_lblEditBrand.Text = "Brand"
        Me.m_txtEditBrand.Location = New System.Drawing.Point(30, 160)
        Me.m_txtEditBrand.Size = New System.Drawing.Size(250, 25)

        Me.m_lblEditCategory.AutoSize = True
        Me.m_lblEditCategory.Location = New System.Drawing.Point(30, 200)
        Me.m_lblEditCategory.Text = "Category"
        Me.m_cmbEditCategory.Location = New System.Drawing.Point(30, 220)
        Me.m_cmbEditCategory.Size = New System.Drawing.Size(250, 25)
        Me.m_cmbEditCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cmbEditCategory.Items.AddRange(New Object() {"Air Conditioners", "Washing Machines", "Televisions", "Refrigerators"})

        Me.m_lblEditPrice.AutoSize = True
        Me.m_lblEditPrice.Location = New System.Drawing.Point(320, 80)
        Me.m_lblEditPrice.Text = "Unit Price"
        Me.m_numEditPrice.Location = New System.Drawing.Point(320, 100)
        Me.m_numEditPrice.Size = New System.Drawing.Size(120, 25)
        Me.m_numEditPrice.DecimalPlaces = 2
        Me.m_numEditPrice.Maximum = 999999

        Me.m_lblEditStock.AutoSize = True
        Me.m_lblEditStock.Location = New System.Drawing.Point(320, 140)
        Me.m_lblEditStock.Text = "Stock Quantity"
        Me.m_numEditStock.Location = New System.Drawing.Point(320, 160)
        Me.m_numEditStock.Size = New System.Drawing.Size(120, 25)
        Me.m_numEditStock.Maximum = 9999

        Me.m_lblEditReorder.AutoSize = True
        Me.m_lblEditReorder.Location = New System.Drawing.Point(320, 200)
        Me.m_lblEditReorder.Text = "Reorder Level"
        Me.m_numEditReorder.Location = New System.Drawing.Point(320, 220)
        Me.m_numEditReorder.Size = New System.Drawing.Size(120, 25)
        Me.m_numEditReorder.Maximum = 9999

        Me.m_btnUpdate.Text = "Update Product"
        Me.m_btnUpdate.BackColor = System.Drawing.Color.FromArgb(40, 167, 69)
        Me.m_btnUpdate.ForeColor = System.Drawing.Color.White
        Me.m_btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.m_btnUpdate.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.m_btnUpdate.Location = New System.Drawing.Point(30, 280)
        Me.m_btnUpdate.Size = New System.Drawing.Size(150, 40)

        Me.m_btnCancel.Text = "Cancel"
        Me.m_btnCancel.BackColor = System.Drawing.Color.White
        Me.m_btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.m_btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.m_btnCancel.Location = New System.Drawing.Point(190, 280)
        Me.m_btnCancel.Size = New System.Drawing.Size(100, 40)

        ' ==============================
        ' LOW STOCK ALERTS
        ' ==============================
        Me.pnlLowStockMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLowStockMain.Visible = False
        Me.pnlLowStockMain.Controls.Add(Me.l_dgvAlerts)
        Me.pnlLowStockMain.Controls.Add(Me.l_pnlCategories)
        Me.pnlLowStockMain.Controls.Add(Me.l_pnlHeader)

        Me.l_pnlCategories.Dock = System.Windows.Forms.DockStyle.Top
        Me.l_pnlCategories.Padding = New System.Windows.Forms.Padding(10)
        Me.l_pnlCategories.Size = New System.Drawing.Size(800, 60)

        Me.l_pnlHeader.BackColor = System.Drawing.Color.White
        Me.l_pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.l_pnlHeader.Size = New System.Drawing.Size(800, 60)
        Me.l_pnlHeader.Controls.Add(Me.l_lblTitle)

        Me.l_lblTitle.AutoSize = True
        Me.l_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.l_lblTitle.ForeColor = System.Drawing.Color.Crimson
        Me.l_lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.l_lblTitle.Text = "⚠️ Low Stock Alerts"

        Me.l_dgvAlerts.AllowUserToAddRows = False
        Me.l_dgvAlerts.AllowUserToDeleteRows = False
        Me.l_dgvAlerts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.l_dgvAlerts.BackgroundColor = System.Drawing.Color.FromArgb(245, 245, 248)
        Me.l_dgvAlerts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.l_dgvAlerts.RowHeadersVisible = False
        Me.l_dgvAlerts.RowTemplate.Height = 40
        Me.l_dgvAlerts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.l_dgvAlerts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.l_dgvAlerts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.l_colProductID, Me.l_colProductName, Me.l_colBrand, Me.l_colStock, Me.l_colReorder, Me.l_colSupplier, Me.l_colActionAddStock})

        Me.l_colProductID.Name = "l_colProductID"
        Me.l_colProductID.Visible = False
        Me.l_colProductName.HeaderText = "Product Name"
        Me.l_colProductName.Name = "l_colProductName"
        Me.l_colBrand.HeaderText = "Brand"
        Me.l_colBrand.Name = "l_colBrand"
        Me.l_colStock.HeaderText = "Current Stock"
        Me.l_colStock.Name = "l_colStock"
        Me.l_colReorder.HeaderText = "Reorder Level"
        Me.l_colReorder.Name = "l_colReorder"
        Me.l_colSupplier.HeaderText = "Supplier"
        Me.l_colSupplier.Name = "l_colSupplier"

        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(40, 167, 69)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        Me.l_colActionAddStock.DefaultCellStyle = DataGridViewCellStyle6
        Me.l_colActionAddStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.l_colActionAddStock.HeaderText = "Action"
        Me.l_colActionAddStock.Name = "l_colActionAddStock"
        Me.l_colActionAddStock.Text = "+ Add Stock"
        Me.l_colActionAddStock.UseColumnTextForButtonValue = True

        ' ==============================
        ' STOCK TRANSACTIONS
        ' ==============================
        Me.pnlStockTransactionMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlStockTransactionMain.Visible = False
        Me.pnlStockTransactionMain.Controls.Add(Me.s_dgvHistory)
        Me.pnlStockTransactionMain.Controls.Add(Me.s_pnlForm)
        Me.pnlStockTransactionMain.Controls.Add(Me.s_lblTitle)

        Me.s_lblTitle.AutoSize = True
        Me.s_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.s_lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.s_lblTitle.Text = "Stock Transactions"

        Me.s_pnlForm.Dock = System.Windows.Forms.DockStyle.Left
        Me.s_pnlForm.Width = 350
        Me.s_pnlForm.BackColor = System.Drawing.Color.White
        Me.s_pnlForm.Padding = New System.Windows.Forms.Padding(20)
        Me.s_pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        
        Me.s_lblProduct.AutoSize = True
        Me.s_lblProduct.Location = New System.Drawing.Point(20, 20)
        Me.s_lblProduct.Text = "Select Product"
        Me.s_cmbProduct.Location = New System.Drawing.Point(20, 40)
        Me.s_cmbProduct.Size = New System.Drawing.Size(300, 25)
        Me.s_cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

        Me.s_lblType.AutoSize = True
        Me.s_lblType.Location = New System.Drawing.Point(20, 80)
        Me.s_lblType.Text = "Transaction Type"
        Me.s_cmbType.Location = New System.Drawing.Point(20, 100)
        Me.s_cmbType.Size = New System.Drawing.Size(300, 25)
        Me.s_cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.s_cmbType.Items.AddRange(New Object() {"Restock", "Sale", "Damage", "Correction"})

        Me.s_lblQuantity.AutoSize = True
        Me.s_lblQuantity.Location = New System.Drawing.Point(20, 140)
        Me.s_lblQuantity.Text = "Quantity"
        Me.s_numQuantity.Location = New System.Drawing.Point(20, 160)
        Me.s_numQuantity.Size = New System.Drawing.Size(120, 25)
        Me.s_numQuantity.Maximum = 9999

        Me.s_lblRemarks.AutoSize = True
        Me.s_lblRemarks.Location = New System.Drawing.Point(20, 200)
        Me.s_lblRemarks.Text = "Remarks (Optional)"
        Me.s_txtRemarks.Location = New System.Drawing.Point(20, 220)
        Me.s_txtRemarks.Size = New System.Drawing.Size(300, 60)
        Me.s_txtRemarks.Multiline = True

        Me.s_btnSave.Text = "Submit Transaction"
        Me.s_btnSave.BackColor = System.Drawing.Color.FromArgb(40, 167, 69)
        Me.s_btnSave.ForeColor = System.Drawing.Color.White
        Me.s_btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.s_btnSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.s_btnSave.Location = New System.Drawing.Point(20, 300)
        Me.s_btnSave.Size = New System.Drawing.Size(300, 40)

        Me.s_pnlForm.Controls.Add(Me.s_lblProduct)
        Me.s_pnlForm.Controls.Add(Me.s_cmbProduct)
        Me.s_pnlForm.Controls.Add(Me.s_lblType)
        Me.s_pnlForm.Controls.Add(Me.s_cmbType)
        Me.s_pnlForm.Controls.Add(Me.s_lblQuantity)
        Me.s_pnlForm.Controls.Add(Me.s_numQuantity)
        Me.s_pnlForm.Controls.Add(Me.s_lblRemarks)
        Me.s_pnlForm.Controls.Add(Me.s_txtRemarks)
        Me.s_pnlForm.Controls.Add(Me.s_btnSave)

        Me.s_dgvHistory.AllowUserToAddRows = False
        Me.s_dgvHistory.AllowUserToDeleteRows = False
        Me.s_dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.s_dgvHistory.BackgroundColor = System.Drawing.Color.FromArgb(245, 245, 248)
        Me.s_dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.s_dgvHistory.RowHeadersVisible = False
        Me.s_dgvHistory.RowTemplate.Height = 40
        Me.s_dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.s_dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.s_dgvHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.s_colTransID, Me.s_colProduct, Me.s_colType, Me.s_colQty, Me.s_colDate, Me.s_colRemarks})

        Me.s_colTransID.Name = "s_colTransID"
        Me.s_colTransID.Visible = False
        Me.s_colProduct.HeaderText = "Product Name"
        Me.s_colProduct.Name = "s_colProduct"
        Me.s_colType.HeaderText = "Transaction Type"
        Me.s_colType.Name = "s_colType"
        Me.s_colQty.HeaderText = "Qty"
        Me.s_colQty.Name = "s_colQty"
        Me.s_colDate.HeaderText = "Date"
        Me.s_colDate.Name = "s_colDate"
        Me.s_colRemarks.HeaderText = "Remarks"
        Me.s_colRemarks.Name = "s_colRemarks"

        ' ==============================
        ' MANAGE SERVICE
        ' ==============================
        Me.pnlManageServiceMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlManageServiceMain.Visible = False
        Me.pnlManageServiceMain.Controls.Add(Me.sv_dgvServices)
        Me.pnlManageServiceMain.Controls.Add(Me.sv_pnlForm)
        Me.pnlManageServiceMain.Controls.Add(Me.sv_lblTitle)

        Me.sv_lblTitle.AutoSize = True
        Me.sv_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.sv_lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.sv_lblTitle.Text = "Manage Services"

        Me.sv_pnlForm.Dock = System.Windows.Forms.DockStyle.Left
        Me.sv_pnlForm.Width = 350
        Me.sv_pnlForm.BackColor = System.Drawing.Color.White
        Me.sv_pnlForm.Padding = New System.Windows.Forms.Padding(20)
        
        Me.sv_lblType.Text = "Service Type"
        Me.sv_lblType.Location = New System.Drawing.Point(20, 20)
        Me.sv_txtType.Location = New System.Drawing.Point(20, 40)
        Me.sv_txtType.Width = 300
        
        Me.sv_lblDesc.Text = "Description"
        Me.sv_lblDesc.Location = New System.Drawing.Point(20, 80)
        Me.sv_txtDesc.Location = New System.Drawing.Point(20, 100)
        Me.sv_txtDesc.Width = 300
        Me.sv_txtDesc.Multiline = True
        Me.sv_txtDesc.Height = 60
        
        Me.sv_lblFee.Text = "Service Fee (₱)"
        Me.sv_lblFee.Location = New System.Drawing.Point(20, 180)
        Me.sv_numFee.Location = New System.Drawing.Point(20, 200)
        Me.sv_numFee.Width = 150
        Me.sv_numFee.DecimalPlaces = 2
        Me.sv_numFee.Maximum = 999999
        
        Me.sv_btnSave.Text = "Save Service"
        Me.sv_btnSave.Location = New System.Drawing.Point(20, 250)
        Me.sv_btnSave.Size = New System.Drawing.Size(145, 40)
        Me.sv_btnSave.BackColor = System.Drawing.Color.FromArgb(40, 167, 69)
        Me.sv_btnSave.ForeColor = System.Drawing.Color.White

        Me.sv_btnCancel.Text = "Cancel"
        Me.sv_btnCancel.Location = New System.Drawing.Point(175, 250)
        Me.sv_btnCancel.Size = New System.Drawing.Size(145, 40)
        Me.sv_btnCancel.BackColor = System.Drawing.Color.LightCoral
        Me.sv_btnCancel.ForeColor = System.Drawing.Color.White
        Me.sv_btnCancel.Visible = False

        Me.sv_pnlForm.Controls.Add(Me.sv_lblType)
        Me.sv_pnlForm.Controls.Add(Me.sv_txtType)
        Me.sv_pnlForm.Controls.Add(Me.sv_lblDesc)
        Me.sv_pnlForm.Controls.Add(Me.sv_txtDesc)
        Me.sv_pnlForm.Controls.Add(Me.sv_lblFee)
        Me.sv_pnlForm.Controls.Add(Me.sv_numFee)
        Me.sv_pnlForm.Controls.Add(Me.sv_btnSave)
        Me.sv_pnlForm.Controls.Add(Me.sv_btnCancel)

        Me.sv_dgvServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sv_dgvServices.AllowUserToAddRows = False
        Me.sv_dgvServices.RowHeadersVisible = False
        Me.sv_dgvServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.sv_dgvServices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sv_colID, Me.sv_colType, Me.sv_colDesc, Me.sv_colFee, Me.sv_colActionEdit, Me.sv_colActionDelete})
        Me.sv_colID.Name = "sv_colID"
        Me.sv_colID.Visible = False
        Me.sv_colType.Name = "sv_colType"
        Me.sv_colType.HeaderText = "Type"
        Me.sv_colDesc.Name = "sv_colDesc"
        Me.sv_colDesc.HeaderText = "Description"
        Me.sv_colFee.Name = "sv_colFee"
        Me.sv_colFee.HeaderText = "Fee"
        Me.sv_colActionEdit.Name = "sv_colActionEdit"
        Me.sv_colActionEdit.HeaderText = "Action"
        Me.sv_colActionEdit.Text = "Edit"
        Me.sv_colActionEdit.UseColumnTextForButtonValue = True
        Me.sv_colActionDelete.Name = "sv_colActionDelete"
        Me.sv_colActionDelete.HeaderText = "Action"
        Me.sv_colActionDelete.Text = "Delete"
        Me.sv_colActionDelete.UseColumnTextForButtonValue = True

        ' ==============================
        ' ADD SERVICE REQUEST
        ' ==============================
        Me.pnlAddServiceRequestMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAddServiceRequestMain.Visible = False
        Me.pnlAddServiceRequestMain.Controls.Add(Me.sr_pnlForm)
        Me.pnlAddServiceRequestMain.Controls.Add(Me.sr_lblTitle)

        Me.sr_lblTitle.AutoSize = True
        Me.sr_lblTitle.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.sr_lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.sr_lblTitle.Text = "Create New Service Request"

        Me.sr_pnlForm.Location = New System.Drawing.Point(20, 70)
        Me.sr_pnlForm.Size = New System.Drawing.Size(650, 780)
        Me.sr_pnlForm.BackColor = System.Drawing.Color.White
        Me.sr_pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.None

        ' Section: Customer Selection
        Me.sr_lblSectionCustomer.Text = "Customer Selection"
        Me.sr_lblSectionCustomer.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.sr_lblSectionCustomer.Location = New System.Drawing.Point(20, 20)
        Me.sr_lblSectionCustomer.AutoSize = True

        Me.sr_optNewCust.Text = "New Customer"
        Me.sr_optNewCust.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.sr_optNewCust.Location = New System.Drawing.Point(20, 50)
        Me.sr_optNewCust.AutoSize = True
        
        Me.sr_optExistingCust.Text = "Existing Customer"
        Me.sr_optExistingCust.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.sr_optExistingCust.Location = New System.Drawing.Point(170, 50)
        Me.sr_optExistingCust.AutoSize = True
        Me.sr_optExistingCust.Checked = True

        Me.sr_lblCust.Text = "Search Existing Customer:"
        Me.sr_lblCust.Location = New System.Drawing.Point(20, 80)
        Me.sr_lblCust.AutoSize = True

        Me.sr_cmbExistingCust.Location = New System.Drawing.Point(20, 100)
        Me.sr_cmbExistingCust.Width = 400
        Me.sr_cmbExistingCust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        
        Me.sr_txtCustName.Location = New System.Drawing.Point(20, 100)
        Me.sr_txtCustName.Width = 190
        Me.sr_txtCustName.Visible = False
        Me.sr_txtCustName.Text = "Name..."
        Me.sr_txtCustContact.Location = New System.Drawing.Point(230, 100)
        Me.sr_txtCustContact.Width = 190
        Me.sr_txtCustContact.Visible = False
        Me.sr_txtCustContact.Text = "Contact..."
        Me.sr_txtCustAddress.Location = New System.Drawing.Point(20, 130)
        Me.sr_txtCustAddress.Width = 400
        Me.sr_txtCustAddress.Visible = False
        Me.sr_txtCustAddress.Text = "Customer Home Address..."

        ' Section: Service Details
        Me.sr_lblSectionService.Text = "Service Details"
        Me.sr_lblSectionService.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.sr_lblSectionService.Location = New System.Drawing.Point(20, 260)
        Me.sr_lblSectionService.AutoSize = True

        Me.sr_lblService.Text = "Service Target"
        Me.sr_lblService.Location = New System.Drawing.Point(20, 290)
        Me.sr_lblService.AutoSize = True

        Me.sr_cmbService.Location = New System.Drawing.Point(20, 310)
        Me.sr_cmbService.Width = 400
        Me.sr_cmbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        
        Me.sr_lblAddress.Text = "Repair Address"
        Me.sr_lblAddress.Location = New System.Drawing.Point(20, 340)
        Me.sr_lblAddress.AutoSize = True

        Me.sr_txtAddress.Location = New System.Drawing.Point(20, 360)
        Me.sr_txtAddress.Width = 400
        Me.sr_txtAddress.Multiline = True
        Me.sr_txtAddress.Height = 60
        Me.sr_txtAddress.Text = ""

        ' Section: Scheduling Staff
        Me.sr_lblSectionStaff.Text = "Scheduling Staff"
        Me.sr_lblSectionStaff.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.sr_lblSectionStaff.Location = New System.Drawing.Point(20, 440)
        Me.sr_lblSectionStaff.AutoSize = True

        Me.sr_lblStaff.Text = "Assign Staff Coordinator"
        Me.sr_lblStaff.Location = New System.Drawing.Point(20, 470)
        Me.sr_lblStaff.AutoSize = True

        Me.sr_cmbStaff.Location = New System.Drawing.Point(20, 490)
        Me.sr_cmbStaff.Width = 400
        Me.sr_cmbStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

        Me.sr_lblTech.Text = "Assign Technician"
        Me.sr_lblTech.Location = New System.Drawing.Point(20, 520)
        Me.sr_lblTech.AutoSize = True

        Me.sr_cmbTech.Location = New System.Drawing.Point(20, 540)
        Me.sr_cmbTech.Width = 400
        Me.sr_cmbTech.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

        Me.sr_lblReqDate.Text = "Request Date"
        Me.sr_lblReqDate.Location = New System.Drawing.Point(20, 570)
        Me.sr_lblReqDate.AutoSize = True

        Me.sr_dtpRequest.Location = New System.Drawing.Point(20, 590)
        Me.sr_dtpRequest.Width = 190
        Me.sr_dtpRequest.Format = System.Windows.Forms.DateTimePickerFormat.Short

        Me.sr_lblScheduled.Text = "Scheduled Date"
        Me.sr_lblScheduled.Location = New System.Drawing.Point(230, 570)
        Me.sr_lblScheduled.AutoSize = True

        Me.sr_dtpScheduled.Location = New System.Drawing.Point(230, 590)
        Me.sr_dtpScheduled.Width = 190
        Me.sr_dtpScheduled.ShowCheckBox = True
        Me.sr_dtpScheduled.Checked = False
        Me.sr_dtpScheduled.Format = System.Windows.Forms.DateTimePickerFormat.Short
        
        Me.sr_lblStatus.Text = "Status"
        Me.sr_lblStatus.Location = New System.Drawing.Point(20, 620)
        Me.sr_lblStatus.AutoSize = True

        Me.sr_cmbStatus.Location = New System.Drawing.Point(20, 640)
        Me.sr_cmbStatus.Width = 400
        Me.sr_cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sr_cmbStatus.Items.AddRange(New Object() {"Pending", "Scheduled", "In Progress", "Completed", "Cancelled"})
        Me.sr_cmbStatus.SelectedIndex = 0
        
        Me.sr_btnSave.Text = "Save Request"
        Me.sr_btnSave.Location = New System.Drawing.Point(20, 690)
        Me.sr_btnSave.Size = New System.Drawing.Size(180, 40)
        Me.sr_btnSave.BackColor = System.Drawing.Color.FromArgb(0, 123, 255)
        Me.sr_btnSave.ForeColor = System.Drawing.Color.White
        Me.sr_btnSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)

        Me.sr_btnCancel.Text = "Cancel"
        Me.sr_btnCancel.Location = New System.Drawing.Point(210, 690)
        Me.sr_btnCancel.Size = New System.Drawing.Size(180, 40)
        Me.sr_btnCancel.BackColor = System.Drawing.Color.White
        Me.sr_btnCancel.ForeColor = System.Drawing.Color.Black

        Me.sr_pnlForm.Controls.AddRange(New System.Windows.Forms.Control() {
            Me.sr_lblSectionCustomer, Me.sr_optExistingCust, Me.sr_optNewCust, Me.sr_lblCust, Me.sr_cmbExistingCust, 
            Me.sr_txtCustName, Me.sr_txtCustContact, Me.sr_txtCustAddress,
            Me.sr_lblSectionService, Me.sr_lblService, Me.sr_cmbService, Me.sr_lblAddress, Me.sr_txtAddress,
            Me.sr_lblSectionStaff, Me.sr_lblStaff, Me.sr_cmbStaff, Me.sr_lblTech, Me.sr_cmbTech, 
            Me.sr_lblReqDate, Me.sr_dtpRequest, Me.sr_lblScheduled, Me.sr_dtpScheduled, Me.sr_lblStatus, Me.sr_cmbStatus, 
            Me.sr_btnSave, Me.sr_btnCancel
        })

        ' ==============================
        ' VIEW SERVICE REQUESTS
        ' ==============================
        Me.pnlViewServiceRequestsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlViewServiceRequestsMain.Visible = False
        Me.pnlViewServiceRequestsMain.Controls.Add(Me.vr_dgvRequests)
        Me.pnlViewServiceRequestsMain.Controls.Add(Me.vr_pnlFilter)
        Me.pnlViewServiceRequestsMain.Controls.Add(Me.vr_lblTitle)

        Me.vr_lblTitle.AutoSize = True
        Me.vr_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.vr_lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.vr_lblTitle.Text = "View Service Requests"

        Me.vr_pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.vr_pnlFilter.Height = 50
        Me.vr_pnlFilter.Padding = New System.Windows.Forms.Padding(10)
        
        Me.vr_txtSearch.Location = New System.Drawing.Point(20, 15)
        Me.vr_txtSearch.Width = 300
        Me.vr_txtSearch.Text = "Search by Customer Name..."
        
        Me.vr_cmbFilterStatus.Location = New System.Drawing.Point(340, 15)
        Me.vr_cmbFilterStatus.Width = 200
        Me.vr_cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.vr_cmbFilterStatus.Items.AddRange(New Object() {"All", "Pending", "Scheduled", "In Progress", "Completed", "Cancelled"})
        Me.vr_cmbFilterStatus.SelectedIndex = 0

        Me.vr_pnlFilter.Controls.Add(Me.vr_txtSearch)
        Me.vr_pnlFilter.Controls.Add(Me.vr_cmbFilterStatus)

        Me.vr_dgvRequests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vr_dgvRequests.AllowUserToAddRows = False
        Me.vr_dgvRequests.RowHeadersVisible = False
        Me.vr_dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.vr_dgvRequests.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.vr_colReqID, Me.vr_colCust, Me.vr_colService, Me.vr_colStaff, Me.vr_colTech, Me.vr_colDate, Me.vr_colSched, Me.vr_colStatus, Me.vr_colActionUpdate})
        
        Me.vr_colReqID.Name = "vr_colReqID"
        Me.vr_colReqID.HeaderText = "Req ID"
        Me.vr_colCust.Name = "vr_colCust"
        Me.vr_colCust.HeaderText = "Customer"
        Me.vr_colService.Name = "vr_colService"
        Me.vr_colService.HeaderText = "Service"
        Me.vr_colStaff.Name = "vr_colStaff"
        Me.vr_colStaff.HeaderText = "Staff"
        Me.vr_colTech.Name = "vr_colTech"
        Me.vr_colTech.HeaderText = "Tech"
        Me.vr_colDate.Name = "vr_colDate"
        Me.vr_colDate.HeaderText = "Date Filed"
        Me.vr_colSched.Name = "vr_colSched"
        Me.vr_colSched.HeaderText = "Scheduled"
        Me.vr_colStatus.Name = "vr_colStatus"
        Me.vr_colStatus.HeaderText = "Status"
        
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(23, 162, 184)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        Me.vr_colActionUpdate.DefaultCellStyle = DataGridViewCellStyle6
        Me.vr_colActionUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.vr_colActionUpdate.HeaderText = "Action"
        Me.vr_colActionUpdate.Name = "vr_colActionUpdate"
        Me.vr_colActionUpdate.Text = "Update Status"
        Me.vr_colActionUpdate.UseColumnTextForButtonValue = True

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
        Me.wr_dgvWarranties.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.wr_colID, Me.wr_colCust, Me.wr_colProd, Me.wr_colPurchDate, Me.wr_colStart, Me.wr_colEnd, Me.wr_colStatus, Me.wr_colActionEdit, Me.wr_colActionDelete})
        
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
        
        Me.wr_colID.Name = "wr_colID"
        Me.wr_colID.Visible = False
        
        Me.wr_colActionEdit.Name = "wr_colActionEdit"
        Me.wr_colActionEdit.HeaderText = "Edit"
        Me.wr_colActionEdit.Text = "Edit"
        Me.wr_colActionEdit.UseColumnTextForButtonValue = True
        
        Me.wr_colActionDelete.Name = "wr_colActionDelete"
        Me.wr_colActionDelete.HeaderText = "Delete"
        Me.wr_colActionDelete.Text = "Delete"
        Me.wr_colActionDelete.UseColumnTextForButtonValue = True

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
        Me.fc_pnlForm.BackColor = System.Drawing.Color.FromArgb(245, 245, 248)

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

        ' ==============================
        ' MAIN FORM ADDITIONS
        ' ==============================
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(245, 245, 248)
        Me.ClientSize = New System.Drawing.Size(864, 601)
        Me.Controls.Add(Me.pnlOrderMain)
        Me.Controls.Add(Me.pnlViewOrdersMain)
        Me.Controls.Add(Me.pnlAddProductMain)
        Me.Controls.Add(Me.pnlManageProductsMain)
        Me.Controls.Add(Me.pnlLowStockMain)
        Me.Controls.Add(Me.pnlManageServiceMain)
        Me.Controls.Add(Me.pnlAddServiceRequestMain)
        Me.Controls.Add(Me.pnlViewServiceRequestsMain)
        Me.Controls.Add(Me.pnlStockTransactionMain)
        Me.Controls.Add(Me.pnlViewWarrantyMain)
        Me.Controls.Add(Me.pnlFileClaimMain)
        Me.Controls.Add(Me.pnlDashboardMain)
        Me.Name = "Childform"
        Me.Text = "Midea Pro Shop"

        Me.flpCards.ResumeLayout(False)
        Me.pnlCard1.ResumeLayout(False)
        Me.pnlCard2.ResumeLayout(False)
        Me.pnlCard3.ResumeLayout(False)
        Me.pnlCard4.ResumeLayout(False)
        Me.pnlDashboardMain.ResumeLayout(False)
        
        CType(Me.o_dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.o_pnlCart.ResumeLayout(False)
        Me.o_pnlTotal.ResumeLayout(False)
        Me.o_pnlCheckoutForm.ResumeLayout(False)
        Me.o_pnlNewCustomer.ResumeLayout(False)
        Me.pnlOrderMain.ResumeLayout(False)

        Me.v_pnlHeader.ResumeLayout(False)
        CType(Me.v_dgvOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlViewOrdersMain.ResumeLayout(False)

        Me.a_pnlForm.ResumeLayout(False)
        CType(Me.a_numPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.a_numStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.a_numReorder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.a_pnlNewSupplier.ResumeLayout(False)
        Me.pnlAddProductMain.ResumeLayout(False)

        CType(Me.m_dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.m_pnlEditProduct.ResumeLayout(False)
        CType(Me.m_numEditPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_numEditStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_numEditReorder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlManageProductsMain.ResumeLayout(False)

        Me.l_pnlHeader.ResumeLayout(False)
        CType(Me.l_dgvAlerts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLowStockMain.ResumeLayout(False)

        Me.pnlStockTransactionMain.ResumeLayout(False)
        Me.s_pnlForm.ResumeLayout(False)
        CType(Me.s_numQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.s_dgvHistory, System.ComponentModel.ISupportInitialize).EndInit()

        Me.pnlManageServiceMain.ResumeLayout(False)
        Me.sv_pnlForm.ResumeLayout(False)
        CType(Me.sv_numFee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sv_dgvServices, System.ComponentModel.ISupportInitialize).EndInit()
        
        Me.pnlAddServiceRequestMain.ResumeLayout(False)
        Me.sr_pnlForm.ResumeLayout(False)

        Me.pnlViewServiceRequestsMain.ResumeLayout(False)
        Me.vr_pnlFilter.ResumeLayout(False)
        CType(Me.vr_dgvRequests, System.ComponentModel.ISupportInitialize).EndInit()

        Me.ResumeLayout(False)
    End Sub

    ' Variables
    Friend WithEvents pnlDashboardMain As System.Windows.Forms.Panel
    Friend WithEvents lblDashTitle As System.Windows.Forms.Label
    Friend WithEvents flpCards As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlCard1 As System.Windows.Forms.Panel
    Friend WithEvents lblCard1Value As System.Windows.Forms.Label
    Friend WithEvents lblCard1Title As System.Windows.Forms.Label
    Friend WithEvents pnlCard2 As System.Windows.Forms.Panel
    Friend WithEvents lblCard2Value As System.Windows.Forms.Label
    Friend WithEvents lblCard2Title As System.Windows.Forms.Label
    Friend WithEvents pnlCard3 As System.Windows.Forms.Panel
    Friend WithEvents lblCard3Value As System.Windows.Forms.Label
    Friend WithEvents lblCard3Title As System.Windows.Forms.Label
    Friend WithEvents pnlCard4 As System.Windows.Forms.Panel
    Friend WithEvents lblCard4Value As System.Windows.Forms.Label
    Friend WithEvents lblCard4Title As System.Windows.Forms.Label

    Friend WithEvents pnlOrderMain As System.Windows.Forms.Panel
    Friend WithEvents o_pnlCategories As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents o_dgvProducts As System.Windows.Forms.DataGridView
    Friend WithEvents o_colProductID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents o_colProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents o_colDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents o_colPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents o_colStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents o_colActionAdd As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents o_pnlCart As System.Windows.Forms.Panel
    Friend WithEvents o_lblCartTitle As System.Windows.Forms.Label
    Friend WithEvents o_flpCartItems As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents o_pnlTotal As System.Windows.Forms.Panel
    Friend WithEvents o_lblTotalLabel As System.Windows.Forms.Label
    Friend WithEvents o_lblTotal As System.Windows.Forms.Label
    Friend WithEvents o_btnContinue As System.Windows.Forms.Button
    Friend WithEvents o_pnlCheckoutForm As System.Windows.Forms.Panel
    Friend WithEvents o_lblCheckoutTitle As System.Windows.Forms.Label
    Friend WithEvents o_flpCheckoutSummary As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents o_lblFinalTotalTitle As System.Windows.Forms.Label
    Friend WithEvents o_lblFinalTotal As System.Windows.Forms.Label
    Friend WithEvents o_lblCustomerSelectTitle As System.Windows.Forms.Label
    Friend WithEvents o_optExistingCustomer As System.Windows.Forms.RadioButton
    Friend WithEvents o_cmbExistingCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents o_optNewCustomer As System.Windows.Forms.RadioButton
    Friend WithEvents o_pnlNewCustomer As System.Windows.Forms.Panel
    Friend WithEvents o_lblCustName As System.Windows.Forms.Label
    Friend WithEvents o_txtCustName As System.Windows.Forms.TextBox
    Friend WithEvents o_lblCustContact As System.Windows.Forms.Label
    Friend WithEvents o_txtCustContact As System.Windows.Forms.TextBox
    Friend WithEvents o_lblCustAddress As System.Windows.Forms.Label
    Friend WithEvents o_txtCustAddress As System.Windows.Forms.TextBox
    Friend WithEvents o_btnConfirmOrder As System.Windows.Forms.Button
    Friend WithEvents o_btnBackToSales As System.Windows.Forms.Button

    Friend WithEvents pnlViewOrdersMain As System.Windows.Forms.Panel
    Friend WithEvents v_pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents v_lblTitle As System.Windows.Forms.Label
    Friend WithEvents v_lblDateRange As System.Windows.Forms.Label
    Friend WithEvents v_dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents v_lblTo As System.Windows.Forms.Label
    Friend WithEvents v_dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents v_btnFilter As System.Windows.Forms.Button
    Friend WithEvents v_dgvOrders As System.Windows.Forms.DataGridView
    Friend WithEvents v_colPurchaseID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents v_colReceipt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents v_colDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents v_colCustomer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents v_colTotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn

    Friend WithEvents pnlAddProductMain As System.Windows.Forms.Panel
    Friend WithEvents a_lblTitle As System.Windows.Forms.Label
    Friend WithEvents a_pnlForm As System.Windows.Forms.Panel
    Friend WithEvents a_btnSave As System.Windows.Forms.Button
    Friend WithEvents a_btnCancel As System.Windows.Forms.Button
    Friend WithEvents a_lblProdName As System.Windows.Forms.Label
    Friend WithEvents a_txtProdName As System.Windows.Forms.TextBox
    Friend WithEvents a_lblProdBrand As System.Windows.Forms.Label
    Friend WithEvents a_txtProdBrand As System.Windows.Forms.TextBox
    Friend WithEvents a_lblProdDesc As System.Windows.Forms.Label
    Friend WithEvents a_txtProdDesc As System.Windows.Forms.TextBox
    Friend WithEvents a_lblCategory As System.Windows.Forms.Label
    Friend WithEvents a_cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents a_lblPrice As System.Windows.Forms.Label
    Friend WithEvents a_numPrice As System.Windows.Forms.NumericUpDown
    Friend WithEvents a_lblStock As System.Windows.Forms.Label
    Friend WithEvents a_numStock As System.Windows.Forms.NumericUpDown
    Friend WithEvents a_lblReorder As System.Windows.Forms.Label
    Friend WithEvents a_numReorder As System.Windows.Forms.NumericUpDown
    Friend WithEvents a_lblSupplierTitle As System.Windows.Forms.Label
    Friend WithEvents a_optExistingSupplier As System.Windows.Forms.RadioButton
    Friend WithEvents a_optNewSupplier As System.Windows.Forms.RadioButton
    Friend WithEvents a_cmbExistingSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents a_pnlNewSupplier As System.Windows.Forms.Panel
    Friend WithEvents a_lblSupName As System.Windows.Forms.Label
    Friend WithEvents a_txtSupName As System.Windows.Forms.TextBox
    Friend WithEvents a_lblSupContact As System.Windows.Forms.Label
    Friend WithEvents a_txtSupContact As System.Windows.Forms.TextBox
    Friend WithEvents a_lblSupAddress As System.Windows.Forms.Label
    Friend WithEvents a_txtSupAddress As System.Windows.Forms.TextBox

    Friend WithEvents pnlManageProductsMain As System.Windows.Forms.Panel
    Friend WithEvents m_pnlCategories As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents m_dgvProducts As System.Windows.Forms.DataGridView
    Friend WithEvents m_colProductID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents m_colProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents m_colBrand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents m_colPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents m_colStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents m_colActionEdit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents m_colActionDelete As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents m_pnlEditProduct As System.Windows.Forms.Panel
    Friend WithEvents m_lblEditTitle As System.Windows.Forms.Label
    Friend WithEvents m_lblEditName As System.Windows.Forms.Label
    Friend WithEvents m_txtEditName As System.Windows.Forms.TextBox
    Friend WithEvents m_lblEditBrand As System.Windows.Forms.Label
    Friend WithEvents m_txtEditBrand As System.Windows.Forms.TextBox
    Friend WithEvents m_lblEditPrice As System.Windows.Forms.Label
    Friend WithEvents m_numEditPrice As System.Windows.Forms.NumericUpDown
    Friend WithEvents m_lblEditStock As System.Windows.Forms.Label
    Friend WithEvents m_numEditStock As System.Windows.Forms.NumericUpDown
    Friend WithEvents m_lblEditReorder As System.Windows.Forms.Label
    Friend WithEvents m_numEditReorder As System.Windows.Forms.NumericUpDown
    Friend WithEvents m_lblEditCategory As System.Windows.Forms.Label
    Friend WithEvents m_cmbEditCategory As System.Windows.Forms.ComboBox
    Friend WithEvents m_btnUpdate As System.Windows.Forms.Button
    Friend WithEvents m_btnCancel As System.Windows.Forms.Button

    Friend WithEvents pnlLowStockMain As System.Windows.Forms.Panel
    Friend WithEvents l_pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents l_lblTitle As System.Windows.Forms.Label
    Friend WithEvents l_pnlCategories As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents l_dgvAlerts As System.Windows.Forms.DataGridView
    Friend WithEvents l_colProductID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents l_colProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents l_colBrand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents l_colStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents l_colReorder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents l_colSupplier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents l_colActionAddStock As System.Windows.Forms.DataGridViewButtonColumn

    Friend WithEvents pnlStockTransactionMain As System.Windows.Forms.Panel
    Friend WithEvents s_lblTitle As System.Windows.Forms.Label
    Friend WithEvents s_pnlForm As System.Windows.Forms.Panel
    Friend WithEvents s_lblProduct As System.Windows.Forms.Label
    Friend WithEvents s_cmbProduct As System.Windows.Forms.ComboBox
    Friend WithEvents s_lblType As System.Windows.Forms.Label
    Friend WithEvents s_cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents s_lblQuantity As System.Windows.Forms.Label
    Friend WithEvents s_numQuantity As System.Windows.Forms.NumericUpDown
    Friend WithEvents s_lblRemarks As System.Windows.Forms.Label
    Friend WithEvents s_txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents s_btnSave As System.Windows.Forms.Button
    Friend WithEvents s_dgvHistory As System.Windows.Forms.DataGridView
    Friend WithEvents s_colTransID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_colProduct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_colType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_colQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_colDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_colRemarks As System.Windows.Forms.DataGridViewTextBoxColumn

    Friend WithEvents pnlManageServiceMain As System.Windows.Forms.Panel
    Friend WithEvents sv_lblTitle As System.Windows.Forms.Label
    Friend WithEvents sv_pnlForm As System.Windows.Forms.Panel
    Friend WithEvents sv_lblType As System.Windows.Forms.Label
    Friend WithEvents sv_txtType As System.Windows.Forms.TextBox
    Friend WithEvents sv_lblDesc As System.Windows.Forms.Label
    Friend WithEvents sv_txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents sv_lblFee As System.Windows.Forms.Label
    Friend WithEvents sv_numFee As System.Windows.Forms.NumericUpDown
    Friend WithEvents sv_btnSave As System.Windows.Forms.Button
    Friend WithEvents sv_dgvServices As System.Windows.Forms.DataGridView
    Friend WithEvents sv_colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sv_colType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sv_colDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sv_colFee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sv_btnCancel As System.Windows.Forms.Button
    Friend WithEvents sv_colActionEdit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents sv_colActionDelete As System.Windows.Forms.DataGridViewButtonColumn

    Friend WithEvents pnlAddServiceRequestMain As System.Windows.Forms.Panel
    Friend WithEvents sr_lblTitle As System.Windows.Forms.Label
    Friend WithEvents sr_pnlForm As System.Windows.Forms.Panel
    Friend WithEvents sr_optExistingCust As System.Windows.Forms.RadioButton
    Friend WithEvents sr_optNewCust As System.Windows.Forms.RadioButton
    Friend WithEvents sr_cmbExistingCust As System.Windows.Forms.ComboBox
    Friend WithEvents sr_txtCustName As System.Windows.Forms.TextBox
    Friend WithEvents sr_txtCustContact As System.Windows.Forms.TextBox
    Friend WithEvents sr_cmbService As System.Windows.Forms.ComboBox
    Friend WithEvents sr_cmbStaff As System.Windows.Forms.ComboBox
    Friend WithEvents sr_cmbTech As System.Windows.Forms.ComboBox
    Friend WithEvents sr_txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents sr_dtpScheduled As System.Windows.Forms.DateTimePicker
    Friend WithEvents sr_cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents sr_btnSave As System.Windows.Forms.Button
    Friend WithEvents sr_lblService As System.Windows.Forms.Label
    Friend WithEvents sr_lblStaff As System.Windows.Forms.Label
    Friend WithEvents sr_lblTech As System.Windows.Forms.Label
    Friend WithEvents sr_lblAddress As System.Windows.Forms.Label
    Friend WithEvents sr_lblScheduled As System.Windows.Forms.Label
    Friend WithEvents sr_lblStatus As System.Windows.Forms.Label
    Friend WithEvents sr_lblSectionCustomer As System.Windows.Forms.Label
    Friend WithEvents sr_lblSectionService As System.Windows.Forms.Label
    Friend WithEvents sr_lblSectionStaff As System.Windows.Forms.Label
    Friend WithEvents sr_lblCust As System.Windows.Forms.Label
    Friend WithEvents sr_txtCustAddress As System.Windows.Forms.TextBox
    Friend WithEvents sr_lblReqDate As System.Windows.Forms.Label
    Friend WithEvents sr_dtpRequest As System.Windows.Forms.DateTimePicker
    Friend WithEvents sr_btnCancel As System.Windows.Forms.Button

    Friend WithEvents pnlViewServiceRequestsMain As System.Windows.Forms.Panel
    Friend WithEvents vr_lblTitle As System.Windows.Forms.Label
    Friend WithEvents vr_pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents vr_txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents vr_cmbFilterStatus As System.Windows.Forms.ComboBox
    Friend WithEvents vr_dgvRequests As System.Windows.Forms.DataGridView
    Friend WithEvents vr_colReqID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vr_colCust As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vr_colService As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vr_colStaff As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vr_colTech As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vr_colDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vr_colSched As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vr_colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vr_colActionUpdate As System.Windows.Forms.DataGridViewButtonColumn
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
    Friend WithEvents wr_colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wr_colActionEdit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents wr_colActionDelete As System.Windows.Forms.DataGridViewButtonColumn

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

End Class

