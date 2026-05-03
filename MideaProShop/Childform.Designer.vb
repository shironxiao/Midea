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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.pnlDashboardMain = New System.Windows.Forms.TabPage()
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
        Me.lblDashTitle = New System.Windows.Forms.Label()
        Me.pnlOrderMain = New System.Windows.Forms.TabPage()
        Me.o_pnlCheckoutForm = New System.Windows.Forms.Panel()
        Me.o_lblCheckoutTitle = New System.Windows.Forms.Label()
        Me.o_flpCheckoutSummary = New System.Windows.Forms.FlowLayoutPanel()
        Me.o_lblFinalTotalTitle = New System.Windows.Forms.Label()
        Me.o_lblFinalTotal = New System.Windows.Forms.Label()
        Me.o_lblCustomerSelectTitle = New System.Windows.Forms.Label()
        Me.o_optExistingCustomer = New System.Windows.Forms.RadioButton()
        Me.o_cmbExistingCustomer = New System.Windows.Forms.ComboBox()
        Me.o_lblAssignStaff = New System.Windows.Forms.Label()
        Me.o_cmbAssignStaff = New System.Windows.Forms.ComboBox()
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
        Me.o_dgvProducts = New System.Windows.Forms.DataGridView()
        Me.o_colProductID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.o_colProductName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.o_colBrand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.o_colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.o_colPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.o_colStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.o_colActionAdd = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.o_colActionRemove = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.o_pnlCategories = New System.Windows.Forms.FlowLayoutPanel()
        Me.o_pnlCart = New System.Windows.Forms.Panel()
        Me.o_flpCartItems = New System.Windows.Forms.FlowLayoutPanel()
        Me.o_lblCartTitle = New System.Windows.Forms.Label()
        Me.o_pnlTotal = New System.Windows.Forms.Panel()
        Me.o_lblTotalLabel = New System.Windows.Forms.Label()
        Me.o_lblTotal = New System.Windows.Forms.Label()
        Me.o_btnContinue = New System.Windows.Forms.Button()
        Me.pnlViewOrdersMain = New System.Windows.Forms.TabPage()
        Me.v_dgvOrders = New System.Windows.Forms.DataGridView()
        Me.v_colPurchaseID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.v_colReceipt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.v_colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.v_colCustomer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.v_colStaff = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.v_colProducts = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.v_colTotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.v_colActionEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.v_colActionDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.v_colActionPrint = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.v_pnlHeader = New System.Windows.Forms.Panel()
        Me.v_lblTitle = New System.Windows.Forms.Label()
        Me.v_lblDateRange = New System.Windows.Forms.Label()
        Me.v_dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.v_lblTo = New System.Windows.Forms.Label()
        Me.v_dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.v_btnFilter = New System.Windows.Forms.Button()
        Me.v_lblSearch = New System.Windows.Forms.Label()
        Me.v_txtSearch = New System.Windows.Forms.TextBox()
        Me.v_pnlDetailForm = New System.Windows.Forms.Panel()
        Me.v_lblDetailTitle = New System.Windows.Forms.Label()
        Me.v_lblDetailReceipt = New System.Windows.Forms.Label()
        Me.v_lblDetailCustomer = New System.Windows.Forms.Label()
        Me.v_lblDetailStaff = New System.Windows.Forms.Label()
        Me.v_lblDetailDate = New System.Windows.Forms.Label()
        Me.v_lblDetailProducts = New System.Windows.Forms.Label()
        Me.v_lblDetailTotal = New System.Windows.Forms.Label()
        Me.v_btnDetailEdit = New System.Windows.Forms.Button()
        Me.v_btnDetailClose = New System.Windows.Forms.Button()
        Me.pnlAddProductMain = New System.Windows.Forms.TabPage()
        Me.a_lblTitle = New System.Windows.Forms.Label()
        Me.a_pnlForm = New System.Windows.Forms.Panel()
        Me.a_lblProdName = New System.Windows.Forms.Label()
        Me.a_txtProdName = New System.Windows.Forms.TextBox()
        Me.a_lblProdBrand = New System.Windows.Forms.Label()
        Me.a_cmbBrand = New System.Windows.Forms.ComboBox()
        Me.a_chkNewBrand = New System.Windows.Forms.CheckBox()
        Me.a_txtNewBrand = New System.Windows.Forms.TextBox()
        Me.a_lblCategory = New System.Windows.Forms.Label()
        Me.a_cmbCategory = New System.Windows.Forms.ComboBox()
        Me.a_lblProdDesc = New System.Windows.Forms.Label()
        Me.a_txtProdDesc = New System.Windows.Forms.TextBox()
        Me.a_lblPrice = New System.Windows.Forms.Label()
        Me.a_numPrice = New System.Windows.Forms.NumericUpDown()
        Me.a_lblStock = New System.Windows.Forms.Label()
        Me.a_numStock = New System.Windows.Forms.NumericUpDown()
        Me.a_lblReorder = New System.Windows.Forms.Label()
        Me.a_numReorder = New System.Windows.Forms.NumericUpDown()
        Me.a_lblSupplierTitle = New System.Windows.Forms.Label()
        Me.a_optExistingSupplier = New System.Windows.Forms.RadioButton()
        Me.a_cmbExistingSupplier = New System.Windows.Forms.ComboBox()
        Me.a_optNewSupplier = New System.Windows.Forms.RadioButton()
        Me.a_pnlNewSupplier = New System.Windows.Forms.Panel()
        Me.a_lblSupName = New System.Windows.Forms.Label()
        Me.a_txtSupName = New System.Windows.Forms.TextBox()
        Me.a_lblSupContact = New System.Windows.Forms.Label()
        Me.a_txtSupContact = New System.Windows.Forms.TextBox()
        Me.a_lblSupAddress = New System.Windows.Forms.Label()
        Me.a_txtSupAddress = New System.Windows.Forms.TextBox()
        Me.a_btnSave = New System.Windows.Forms.Button()
        Me.a_btnCancel = New System.Windows.Forms.Button()
        Me.pnlManageProductsMain = New System.Windows.Forms.TabPage()
        Me.m_pnlEditProduct = New System.Windows.Forms.Panel()
        Me.m_lblEditTitle = New System.Windows.Forms.Label()
        Me.m_lblEditName = New System.Windows.Forms.Label()
        Me.m_txtEditName = New System.Windows.Forms.TextBox()
        Me.m_lblEditBrand = New System.Windows.Forms.Label()
        Me.m_txtEditBrand = New System.Windows.Forms.TextBox()
        Me.m_lblEditCategory = New System.Windows.Forms.Label()
        Me.m_cmbEditCategory = New System.Windows.Forms.ComboBox()
        Me.m_lblEditPrice = New System.Windows.Forms.Label()
        Me.m_numEditPrice = New System.Windows.Forms.NumericUpDown()
        Me.m_lblEditStock = New System.Windows.Forms.Label()
        Me.m_numEditStock = New System.Windows.Forms.NumericUpDown()
        Me.m_lblEditReorder = New System.Windows.Forms.Label()
        Me.m_numEditReorder = New System.Windows.Forms.NumericUpDown()
        Me.m_btnUpdate = New System.Windows.Forms.Button()
        Me.m_btnCancel = New System.Windows.Forms.Button()
        Me.m_dgvProducts = New System.Windows.Forms.DataGridView()
        Me.m_colProductID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_colProductName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_colBrand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_colPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_colStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_colReorder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.m_colActionEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.m_colActionDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.m_pnlCategories = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlLowStockMain = New System.Windows.Forms.TabPage()
        Me.l_dgvAlerts = New System.Windows.Forms.DataGridView()
        Me.l_colProductID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.l_colProductName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.l_colBrand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.l_colStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.l_colReorder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.l_colSupplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.l_colActionAddStock = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.l_pnlCategories = New System.Windows.Forms.FlowLayoutPanel()
        Me.l_pnlHeader = New System.Windows.Forms.Panel()
        Me.l_lblTitle = New System.Windows.Forms.Label()
        Me.pnlStockTransactionMain = New System.Windows.Forms.TabPage()
        Me.s_dgvHistory = New System.Windows.Forms.DataGridView()
        Me.s_colTransID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_colProduct = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_colType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_colQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_colRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.s_colActionEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.s_colActionDelete = New System.Windows.Forms.DataGridViewButtonColumn()
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
        Me.s_lblTitle = New System.Windows.Forms.Label()
        Me.s_pnlEditForm = New System.Windows.Forms.Panel()
        Me.s_lblEditTransTitle = New System.Windows.Forms.Label()
        Me.s_lblEditProduct = New System.Windows.Forms.Label()
        Me.s_cmbEditProduct = New System.Windows.Forms.ComboBox()
        Me.s_lblEditDate = New System.Windows.Forms.Label()
        Me.s_lblEditType = New System.Windows.Forms.Label()
        Me.s_cmbEditType = New System.Windows.Forms.ComboBox()
        Me.s_lblEditQty = New System.Windows.Forms.Label()
        Me.s_numEditQuantity = New System.Windows.Forms.NumericUpDown()
        Me.s_lblEditRemarks = New System.Windows.Forms.Label()
        Me.s_txtEditRemarks = New System.Windows.Forms.TextBox()
        Me.s_btnEditSave = New System.Windows.Forms.Button()
        Me.s_btnEditClose = New System.Windows.Forms.Button()
        Me.s_pnlHeader = New System.Windows.Forms.Panel()
        Me.s_lblFilter = New System.Windows.Forms.Label()
        Me.s_cmbQuickFilter = New System.Windows.Forms.ComboBox()
        Me.s_lblSearch = New System.Windows.Forms.Label()
        Me.s_txtSearch = New System.Windows.Forms.TextBox()
        Me.pnlManageServiceMain = New System.Windows.Forms.TabPage()
        Me.sv_dgvServices = New System.Windows.Forms.DataGridView()
        Me.sv_colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sv_colType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sv_colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sv_colFee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sv_colActionEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.sv_colActionDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.sv_pnlForm = New System.Windows.Forms.Panel()
        Me.sv_lblType = New System.Windows.Forms.Label()
        Me.sv_txtType = New System.Windows.Forms.TextBox()
        Me.sv_lblDesc = New System.Windows.Forms.Label()
        Me.sv_txtDesc = New System.Windows.Forms.TextBox()
        Me.sv_lblFee = New System.Windows.Forms.Label()
        Me.sv_numFee = New System.Windows.Forms.NumericUpDown()
        Me.sv_btnSave = New System.Windows.Forms.Button()
        Me.sv_btnCancel = New System.Windows.Forms.Button()
        Me.sv_lblTitle = New System.Windows.Forms.Label()
        Me.pnlAddServiceRequestMain = New System.Windows.Forms.TabPage()
        Me.sr_pnlForm = New System.Windows.Forms.Panel()
        Me.sr_lblSectionCustomer = New System.Windows.Forms.Label()
        Me.sr_optExistingCust = New System.Windows.Forms.RadioButton()
        Me.sr_optNewCust = New System.Windows.Forms.RadioButton()
        Me.sr_lblCust = New System.Windows.Forms.Label()
        Me.sr_cmbExistingCust = New System.Windows.Forms.ComboBox()
        Me.sr_txtCustName = New System.Windows.Forms.TextBox()
        Me.sr_txtCustContact = New System.Windows.Forms.TextBox()
        Me.sr_txtCustAddress = New System.Windows.Forms.TextBox()
        Me.sr_lblSectionService = New System.Windows.Forms.Label()
        Me.sr_lblService = New System.Windows.Forms.Label()
        Me.sr_cmbService = New System.Windows.Forms.ComboBox()
        Me.sr_lblAddress = New System.Windows.Forms.Label()
        Me.sr_txtAddress = New System.Windows.Forms.TextBox()
        Me.sr_lblSectionStaff = New System.Windows.Forms.Label()
        Me.sr_lblStaff = New System.Windows.Forms.Label()
        Me.sr_cmbStaff = New System.Windows.Forms.ComboBox()
        Me.sr_lblTech = New System.Windows.Forms.Label()
        Me.sr_cmbTech = New System.Windows.Forms.ComboBox()
        Me.sr_lblReqDate = New System.Windows.Forms.Label()
        Me.sr_dtpRequest = New System.Windows.Forms.DateTimePicker()
        Me.sr_lblScheduled = New System.Windows.Forms.Label()
        Me.sr_dtpScheduled = New System.Windows.Forms.DateTimePicker()
        Me.sr_lblStatus = New System.Windows.Forms.Label()
        Me.sr_cmbStatus = New System.Windows.Forms.ComboBox()
        Me.sr_btnSave = New System.Windows.Forms.Button()
        Me.sr_btnCancel = New System.Windows.Forms.Button()
        Me.sr_lblTitle = New System.Windows.Forms.Label()
        Me.pnlViewServiceRequestsMain = New System.Windows.Forms.TabPage()
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
        Me.vr_colActionDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.vr_pnlFilter = New System.Windows.Forms.Panel()
        Me.vr_lblSearch = New System.Windows.Forms.Label()
        Me.vr_txtSearch = New System.Windows.Forms.TextBox()
        Me.vr_cmbFilterStatus = New System.Windows.Forms.ComboBox()
        Me.vr_lblTitle = New System.Windows.Forms.Label()
        Me.vr_pnlDetail = New System.Windows.Forms.Panel()
        Me.vr_lblDetailTitle = New System.Windows.Forms.Label()
        Me.vr_lblDetailCustHdr = New System.Windows.Forms.Label()
        Me.vr_txtDetailCust = New System.Windows.Forms.TextBox()
        Me.vr_lblDetailDate = New System.Windows.Forms.Label()
        Me.vr_lblDetailServiceHdr = New System.Windows.Forms.Label()
        Me.vr_cmbDetailService = New System.Windows.Forms.ComboBox()
        Me.vr_lblDetailStaffHdr = New System.Windows.Forms.Label()
        Me.vr_cmbDetailStaff = New System.Windows.Forms.ComboBox()
        Me.vr_lblDetailTechHdr = New System.Windows.Forms.Label()
        Me.vr_cmbDetailTech = New System.Windows.Forms.ComboBox()
        Me.vr_lblDetailAddrHdr = New System.Windows.Forms.Label()
        Me.vr_txtDetailAddress = New System.Windows.Forms.TextBox()
        Me.vr_lblDetailSchedHdr = New System.Windows.Forms.Label()
        Me.vr_dtpDetailSched = New System.Windows.Forms.DateTimePicker()
        Me.vr_lblDetailStatusHdr = New System.Windows.Forms.Label()
        Me.vr_cmbDetailStatus = New System.Windows.Forms.ComboBox()
        Me.vr_btnDetailUpdate = New System.Windows.Forms.Button()
        Me.vr_btnDetailClose = New System.Windows.Forms.Button()
        Me.pnlViewWarrantyMain = New System.Windows.Forms.TabPage()
        Me.wr_dgvWarranties = New System.Windows.Forms.DataGridView()
        Me.wr_colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wr_colCust = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wr_colProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wr_colStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wr_colEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wr_colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wr_colActionEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.wr_colActionDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.wr_pnlFilter = New System.Windows.Forms.Panel()
        Me.wr_txtSearch = New System.Windows.Forms.TextBox()
        Me.wr_cmbFilterStatus = New System.Windows.Forms.ComboBox()
        Me.wr_lblTitle = New System.Windows.Forms.Label()
        Me.pnlFileClaimMain = New System.Windows.Forms.TabPage()
        Me.fc_pnlForm = New System.Windows.Forms.Panel()
        Me.fc_lblCust = New System.Windows.Forms.Label()
        Me.fc_cmbCustomer = New System.Windows.Forms.ComboBox()
        Me.fc_lblProd = New System.Windows.Forms.Label()
        Me.fc_cmbProduct = New System.Windows.Forms.ComboBox()
        Me.fc_lblStart = New System.Windows.Forms.Label()
        Me.fc_txtStart = New System.Windows.Forms.TextBox()
        Me.fc_lblEnd = New System.Windows.Forms.Label()
        Me.fc_txtEnd = New System.Windows.Forms.TextBox()
        Me.fc_lblStatus = New System.Windows.Forms.Label()
        Me.fc_txtStatus = New System.Windows.Forms.TextBox()
        Me.fc_lblIssue = New System.Windows.Forms.Label()
        Me.fc_txtIssue = New System.Windows.Forms.TextBox()
        Me.fc_btnSubmit = New System.Windows.Forms.Button()
        Me.fc_lblTitle = New System.Windows.Forms.Label()
        Me.tpStaffMain = New System.Windows.Forms.TabPage()
        Me.tpSupplierMain = New System.Windows.Forms.TabPage()
        Me.tpReportMain = New System.Windows.Forms.TabPage()
        Me.tpViewWarrantyClaimMain = New System.Windows.Forms.TabPage()
        Me.pre_st_lblTitle = New System.Windows.Forms.Label()
        Me.pre_st_pnlForm = New System.Windows.Forms.Panel()
        Me.pre_st_lblHint = New System.Windows.Forms.Label()
        Me.pre_ms_lblTitle = New System.Windows.Forms.Label()
        Me.pre_ms_txtSearch = New System.Windows.Forms.TextBox()
        Me.pre_ms_grid = New System.Windows.Forms.DataGridView()
        Me.pre_sup_lblTitle = New System.Windows.Forms.Label()
        Me.pre_sup_pnlForm = New System.Windows.Forms.Panel()
        Me.pre_sup_grid = New System.Windows.Forms.DataGridView()
        Me.pre_rpt_lblTitle = New System.Windows.Forms.Label()
        Me.pre_rpt_cmbFilter = New System.Windows.Forms.ComboBox()
        Me.pre_rpt_lblAmount = New System.Windows.Forms.Label()
        Me.pre_rpt_grid = New System.Windows.Forms.DataGridView()
        Me.tcMain.SuspendLayout()
        Me.pnlDashboardMain.SuspendLayout()
        Me.flpCards.SuspendLayout()
        Me.pnlCard1.SuspendLayout()
        Me.pnlCard2.SuspendLayout()
        Me.pnlCard3.SuspendLayout()
        Me.pnlCard4.SuspendLayout()
        Me.pnlOrderMain.SuspendLayout()
        Me.o_pnlCheckoutForm.SuspendLayout()
        Me.o_pnlNewCustomer.SuspendLayout()
        CType(Me.o_dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.o_pnlCart.SuspendLayout()
        Me.o_pnlTotal.SuspendLayout()
        Me.pnlViewOrdersMain.SuspendLayout()
        CType(Me.v_dgvOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.v_pnlHeader.SuspendLayout()
        Me.pnlAddProductMain.SuspendLayout()
        Me.a_pnlForm.SuspendLayout()
        CType(Me.a_numPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.a_numStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.a_numReorder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.a_pnlNewSupplier.SuspendLayout()
        Me.pnlManageProductsMain.SuspendLayout()
        Me.m_pnlEditProduct.SuspendLayout()
        CType(Me.m_numEditPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_numEditStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_numEditReorder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLowStockMain.SuspendLayout()
        CType(Me.l_dgvAlerts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.l_pnlHeader.SuspendLayout()
        Me.pnlStockTransactionMain.SuspendLayout()
        CType(Me.s_dgvHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.s_pnlForm.SuspendLayout()
        CType(Me.s_numQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlManageServiceMain.SuspendLayout()
        CType(Me.sv_dgvServices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sv_pnlForm.SuspendLayout()
        CType(Me.sv_numFee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAddServiceRequestMain.SuspendLayout()
        Me.sr_pnlForm.SuspendLayout()
        Me.pnlViewServiceRequestsMain.SuspendLayout()
        CType(Me.vr_dgvRequests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.vr_pnlFilter.SuspendLayout()
        Me.pnlViewWarrantyMain.SuspendLayout()
        CType(Me.wr_dgvWarranties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.wr_pnlFilter.SuspendLayout()
        Me.pnlFileClaimMain.SuspendLayout()
        Me.fc_pnlForm.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcMain
        '
        Me.tcMain.Controls.Add(Me.pnlDashboardMain)
        Me.tcMain.Controls.Add(Me.pnlOrderMain)
        Me.tcMain.Controls.Add(Me.pnlViewOrdersMain)
        Me.tcMain.Controls.Add(Me.pnlAddProductMain)
        Me.tcMain.Controls.Add(Me.pnlManageProductsMain)
        Me.tcMain.Controls.Add(Me.pnlLowStockMain)
        Me.tcMain.Controls.Add(Me.pnlStockTransactionMain)
        Me.tcMain.Controls.Add(Me.pnlManageServiceMain)
        Me.tcMain.Controls.Add(Me.pnlAddServiceRequestMain)
        Me.tcMain.Controls.Add(Me.pnlViewServiceRequestsMain)
        Me.tcMain.Controls.Add(Me.pnlViewWarrantyMain)
        Me.tcMain.Controls.Add(Me.pnlFileClaimMain)
        Me.tcMain.Controls.Add(Me.tpStaffMain)
        Me.tcMain.Controls.Add(Me.tpSupplierMain)
        Me.tcMain.Controls.Add(Me.tpReportMain)
        Me.tcMain.Controls.Add(Me.tpViewWarrantyClaimMain)
        Me.tcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcMain.Location = New System.Drawing.Point(0, 0)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(1361, 607)
        Me.tcMain.TabIndex = 0
        '
        'pnlDashboardMain
        '
        Me.pnlDashboardMain.Controls.Add(Me.flpCards)
        Me.pnlDashboardMain.Controls.Add(Me.lblDashTitle)
        Me.pnlDashboardMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDashboardMain.Location = New System.Drawing.Point(4, 22)
        Me.pnlDashboardMain.Name = "pnlDashboardMain"
        Me.pnlDashboardMain.Size = New System.Drawing.Size(1353, 581)
        Me.pnlDashboardMain.TabIndex = 0
        Me.pnlDashboardMain.Text = "Dashboard"
        '
        'flpCards
        '
        Me.flpCards.Controls.Add(Me.pnlCard1)
        Me.flpCards.Controls.Add(Me.pnlCard2)
        Me.flpCards.Controls.Add(Me.pnlCard3)
        Me.flpCards.Controls.Add(Me.pnlCard4)
        Me.flpCards.Dock = System.Windows.Forms.DockStyle.Top
        Me.flpCards.Location = New System.Drawing.Point(0, 70)
        Me.flpCards.Name = "flpCards"
        Me.flpCards.Padding = New System.Windows.Forms.Padding(25, 10, 25, 10)
        Me.flpCards.Size = New System.Drawing.Size(1353, 160)
        Me.flpCards.TabIndex = 0
        '
        'pnlCard1
        '
        Me.pnlCard1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.pnlCard1.Controls.Add(Me.lblCard1Value)
        Me.pnlCard1.Controls.Add(Me.lblCard1Title)
        Me.pnlCard1.Location = New System.Drawing.Point(28, 13)
        Me.pnlCard1.Margin = New System.Windows.Forms.Padding(3, 3, 15, 3)
        Me.pnlCard1.Name = "pnlCard1"
        Me.pnlCard1.Size = New System.Drawing.Size(185, 130)
        Me.pnlCard1.TabIndex = 0
        '
        'lblCard1Value
        '
        Me.lblCard1Value.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCard1Value.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblCard1Value.ForeColor = System.Drawing.Color.White
        Me.lblCard1Value.Location = New System.Drawing.Point(0, 45)
        Me.lblCard1Value.Name = "lblCard1Value"
        Me.lblCard1Value.Size = New System.Drawing.Size(185, 85)
        Me.lblCard1Value.TabIndex = 0
        Me.lblCard1Value.Text = "0"
        Me.lblCard1Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCard1Title
        '
        Me.lblCard1Title.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCard1Title.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblCard1Title.ForeColor = System.Drawing.Color.White
        Me.lblCard1Title.Location = New System.Drawing.Point(0, 0)
        Me.lblCard1Title.Name = "lblCard1Title"
        Me.lblCard1Title.Padding = New System.Windows.Forms.Padding(15, 15, 0, 0)
        Me.lblCard1Title.Size = New System.Drawing.Size(185, 45)
        Me.lblCard1Title.TabIndex = 1
        Me.lblCard1Title.Text = "Total Sales"
        '
        'pnlCard2
        '
        Me.pnlCard2.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.pnlCard2.Controls.Add(Me.lblCard2Value)
        Me.pnlCard2.Controls.Add(Me.lblCard2Title)
        Me.pnlCard2.Location = New System.Drawing.Point(231, 13)
        Me.pnlCard2.Margin = New System.Windows.Forms.Padding(3, 3, 15, 3)
        Me.pnlCard2.Name = "pnlCard2"
        Me.pnlCard2.Size = New System.Drawing.Size(185, 130)
        Me.pnlCard2.TabIndex = 1
        '
        'lblCard2Value
        '
        Me.lblCard2Value.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCard2Value.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblCard2Value.ForeColor = System.Drawing.Color.White
        Me.lblCard2Value.Location = New System.Drawing.Point(0, 45)
        Me.lblCard2Value.Name = "lblCard2Value"
        Me.lblCard2Value.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.lblCard2Value.Size = New System.Drawing.Size(185, 85)
        Me.lblCard2Value.TabIndex = 0
        Me.lblCard2Value.Text = "0"
        '
        'lblCard2Title
        '
        Me.lblCard2Title.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCard2Title.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblCard2Title.ForeColor = System.Drawing.Color.White
        Me.lblCard2Title.Location = New System.Drawing.Point(0, 0)
        Me.lblCard2Title.Name = "lblCard2Title"
        Me.lblCard2Title.Padding = New System.Windows.Forms.Padding(15, 15, 0, 0)
        Me.lblCard2Title.Size = New System.Drawing.Size(185, 45)
        Me.lblCard2Title.TabIndex = 1
        Me.lblCard2Title.Text = "Transactions"
        '
        'pnlCard3
        '
        Me.pnlCard3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlCard3.Controls.Add(Me.lblCard3Value)
        Me.pnlCard3.Controls.Add(Me.lblCard3Title)
        Me.pnlCard3.Location = New System.Drawing.Point(434, 13)
        Me.pnlCard3.Margin = New System.Windows.Forms.Padding(3, 3, 15, 3)
        Me.pnlCard3.Name = "pnlCard3"
        Me.pnlCard3.Size = New System.Drawing.Size(185, 130)
        Me.pnlCard3.TabIndex = 2
        '
        'lblCard3Value
        '
        Me.lblCard3Value.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCard3Value.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblCard3Value.ForeColor = System.Drawing.Color.White
        Me.lblCard3Value.Location = New System.Drawing.Point(0, 45)
        Me.lblCard3Value.Name = "lblCard3Value"
        Me.lblCard3Value.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.lblCard3Value.Size = New System.Drawing.Size(185, 85)
        Me.lblCard3Value.TabIndex = 0
        Me.lblCard3Value.Text = "0"
        '
        'lblCard3Title
        '
        Me.lblCard3Title.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCard3Title.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblCard3Title.ForeColor = System.Drawing.Color.White
        Me.lblCard3Title.Location = New System.Drawing.Point(0, 0)
        Me.lblCard3Title.Name = "lblCard3Title"
        Me.lblCard3Title.Padding = New System.Windows.Forms.Padding(15, 15, 0, 0)
        Me.lblCard3Title.Size = New System.Drawing.Size(185, 45)
        Me.lblCard3Title.TabIndex = 1
        Me.lblCard3Title.Text = "Service Requests"
        '
        'pnlCard4
        '
        Me.pnlCard4.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.pnlCard4.Controls.Add(Me.lblCard4Value)
        Me.pnlCard4.Controls.Add(Me.lblCard4Title)
        Me.pnlCard4.Location = New System.Drawing.Point(637, 13)
        Me.pnlCard4.Margin = New System.Windows.Forms.Padding(3, 3, 15, 3)
        Me.pnlCard4.Name = "pnlCard4"
        Me.pnlCard4.Size = New System.Drawing.Size(185, 130)
        Me.pnlCard4.TabIndex = 3
        '
        'lblCard4Value
        '
        Me.lblCard4Value.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCard4Value.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblCard4Value.ForeColor = System.Drawing.Color.White
        Me.lblCard4Value.Location = New System.Drawing.Point(0, 45)
        Me.lblCard4Value.Name = "lblCard4Value"
        Me.lblCard4Value.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.lblCard4Value.Size = New System.Drawing.Size(185, 85)
        Me.lblCard4Value.TabIndex = 0
        Me.lblCard4Value.Text = "0"
        '
        'lblCard4Title
        '
        Me.lblCard4Title.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCard4Title.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblCard4Title.ForeColor = System.Drawing.Color.White
        Me.lblCard4Title.Location = New System.Drawing.Point(0, 0)
        Me.lblCard4Title.Name = "lblCard4Title"
        Me.lblCard4Title.Padding = New System.Windows.Forms.Padding(15, 15, 0, 0)
        Me.lblCard4Title.Size = New System.Drawing.Size(185, 45)
        Me.lblCard4Title.TabIndex = 1
        Me.lblCard4Title.Text = "Warranty Claims"
        '
        'lblDashTitle
        '
        Me.lblDashTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDashTitle.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblDashTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.lblDashTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblDashTitle.Name = "lblDashTitle"
        Me.lblDashTitle.Padding = New System.Windows.Forms.Padding(30, 20, 0, 10)
        Me.lblDashTitle.Size = New System.Drawing.Size(1353, 70)
        Me.lblDashTitle.TabIndex = 1
        Me.lblDashTitle.Text = "Dashboard"
        '
        'pnlOrderMain
        '
        Me.pnlOrderMain.Controls.Add(Me.o_pnlCheckoutForm)
        Me.pnlOrderMain.Controls.Add(Me.o_dgvProducts)
        Me.pnlOrderMain.Controls.Add(Me.o_pnlCategories)
        Me.pnlOrderMain.Controls.Add(Me.o_pnlCart)
        Me.pnlOrderMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOrderMain.Location = New System.Drawing.Point(4, 22)
        Me.pnlOrderMain.Name = "pnlOrderMain"
        Me.pnlOrderMain.Size = New System.Drawing.Size(1353, 581)
        Me.pnlOrderMain.TabIndex = 1
        Me.pnlOrderMain.Text = "Order"
        Me.pnlOrderMain.Visible = False
        '
        'o_pnlCheckoutForm
        '
        Me.o_pnlCheckoutForm.BackColor = System.Drawing.Color.White
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_lblCheckoutTitle)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_flpCheckoutSummary)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_lblFinalTotalTitle)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_lblFinalTotal)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_lblCustomerSelectTitle)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_optExistingCustomer)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_cmbExistingCustomer)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_lblAssignStaff)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_cmbAssignStaff)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_optNewCustomer)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_pnlNewCustomer)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_btnConfirmOrder)
        Me.o_pnlCheckoutForm.Controls.Add(Me.o_btnBackToSales)
        Me.o_pnlCheckoutForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.o_pnlCheckoutForm.Location = New System.Drawing.Point(0, 60)
        Me.o_pnlCheckoutForm.Name = "o_pnlCheckoutForm"
        Me.o_pnlCheckoutForm.Size = New System.Drawing.Size(1003, 521)
        Me.o_pnlCheckoutForm.TabIndex = 0
        Me.o_pnlCheckoutForm.Visible = False
        '
        'o_lblCheckoutTitle
        '
        Me.o_lblCheckoutTitle.AutoSize = True
        Me.o_lblCheckoutTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.o_lblCheckoutTitle.Location = New System.Drawing.Point(30, 20)
        Me.o_lblCheckoutTitle.Name = "o_lblCheckoutTitle"
        Me.o_lblCheckoutTitle.Size = New System.Drawing.Size(236, 32)
        Me.o_lblCheckoutTitle.TabIndex = 0
        Me.o_lblCheckoutTitle.Text = "Checkout Summary"
        '
        'o_flpCheckoutSummary
        '
        Me.o_flpCheckoutSummary.AutoScroll = True
        Me.o_flpCheckoutSummary.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.o_flpCheckoutSummary.Location = New System.Drawing.Point(30, 70)
        Me.o_flpCheckoutSummary.Name = "o_flpCheckoutSummary"
        Me.o_flpCheckoutSummary.Size = New System.Drawing.Size(300, 300)
        Me.o_flpCheckoutSummary.TabIndex = 1
        '
        'o_lblFinalTotalTitle
        '
        Me.o_lblFinalTotalTitle.AutoSize = True
        Me.o_lblFinalTotalTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.o_lblFinalTotalTitle.Location = New System.Drawing.Point(30, 390)
        Me.o_lblFinalTotalTitle.Name = "o_lblFinalTotalTitle"
        Me.o_lblFinalTotalTitle.Size = New System.Drawing.Size(137, 25)
        Me.o_lblFinalTotalTitle.TabIndex = 2
        Me.o_lblFinalTotalTitle.Text = "Final Amount:"
        '
        'o_lblFinalTotal
        '
        Me.o_lblFinalTotal.AutoSize = True
        Me.o_lblFinalTotal.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.o_lblFinalTotal.ForeColor = System.Drawing.Color.Crimson
        Me.o_lblFinalTotal.Location = New System.Drawing.Point(180, 385)
        Me.o_lblFinalTotal.Name = "o_lblFinalTotal"
        Me.o_lblFinalTotal.Size = New System.Drawing.Size(78, 32)
        Me.o_lblFinalTotal.TabIndex = 3
        Me.o_lblFinalTotal.Text = "₱0.00"
        '
        'o_lblCustomerSelectTitle
        '
        Me.o_lblCustomerSelectTitle.AutoSize = True
        Me.o_lblCustomerSelectTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.o_lblCustomerSelectTitle.Location = New System.Drawing.Point(400, 70)
        Me.o_lblCustomerSelectTitle.Name = "o_lblCustomerSelectTitle"
        Me.o_lblCustomerSelectTitle.Size = New System.Drawing.Size(162, 25)
        Me.o_lblCustomerSelectTitle.TabIndex = 4
        Me.o_lblCustomerSelectTitle.Text = "Customer Details"
        '
        'o_optExistingCustomer
        '
        Me.o_optExistingCustomer.AutoSize = True
        Me.o_optExistingCustomer.Checked = True
        Me.o_optExistingCustomer.Location = New System.Drawing.Point(400, 110)
        Me.o_optExistingCustomer.Name = "o_optExistingCustomer"
        Me.o_optExistingCustomer.Size = New System.Drawing.Size(108, 17)
        Me.o_optExistingCustomer.TabIndex = 5
        Me.o_optExistingCustomer.TabStop = True
        Me.o_optExistingCustomer.Text = "Existing Customer"
        '
        'o_cmbExistingCustomer
        '
        Me.o_cmbExistingCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.o_cmbExistingCustomer.Location = New System.Drawing.Point(420, 135)
        Me.o_cmbExistingCustomer.Name = "o_cmbExistingCustomer"
        Me.o_cmbExistingCustomer.Size = New System.Drawing.Size(250, 21)
        Me.o_cmbExistingCustomer.TabIndex = 6
        '
        'o_lblAssignStaff
        '
        Me.o_lblAssignStaff.AutoSize = True
        Me.o_lblAssignStaff.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.o_lblAssignStaff.Location = New System.Drawing.Point(700, 70)
        Me.o_lblAssignStaff.Name = "o_lblAssignStaff"
        Me.o_lblAssignStaff.Size = New System.Drawing.Size(162, 25)
        Me.o_lblAssignStaff.TabIndex = 11
        Me.o_lblAssignStaff.Text = "Assign Staff"
        '
        'o_cmbAssignStaff
        '
        Me.o_cmbAssignStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.o_cmbAssignStaff.Location = New System.Drawing.Point(700, 100)
        Me.o_cmbAssignStaff.Name = "o_cmbAssignStaff"
        Me.o_cmbAssignStaff.Size = New System.Drawing.Size(250, 21)
        Me.o_cmbAssignStaff.TabIndex = 12
        '
        'o_optNewCustomer
        '
        Me.o_optNewCustomer.AutoSize = True
        Me.o_optNewCustomer.Location = New System.Drawing.Point(400, 180)
        Me.o_optNewCustomer.Name = "o_optNewCustomer"
        Me.o_optNewCustomer.Size = New System.Drawing.Size(94, 17)
        Me.o_optNewCustomer.TabIndex = 7
        Me.o_optNewCustomer.Text = "New Customer"
        '
        'o_pnlNewCustomer
        '
        Me.o_pnlNewCustomer.Controls.Add(Me.o_lblCustName)
        Me.o_pnlNewCustomer.Controls.Add(Me.o_txtCustName)
        Me.o_pnlNewCustomer.Controls.Add(Me.o_lblCustContact)
        Me.o_pnlNewCustomer.Controls.Add(Me.o_txtCustContact)
        Me.o_pnlNewCustomer.Controls.Add(Me.o_lblCustAddress)
        Me.o_pnlNewCustomer.Controls.Add(Me.o_txtCustAddress)
        Me.o_pnlNewCustomer.Location = New System.Drawing.Point(420, 210)
        Me.o_pnlNewCustomer.Name = "o_pnlNewCustomer"
        Me.o_pnlNewCustomer.Size = New System.Drawing.Size(300, 170)
        Me.o_pnlNewCustomer.TabIndex = 8
        '
        'o_lblCustName
        '
        Me.o_lblCustName.AutoSize = True
        Me.o_lblCustName.Location = New System.Drawing.Point(0, 0)
        Me.o_lblCustName.Name = "o_lblCustName"
        Me.o_lblCustName.Size = New System.Drawing.Size(54, 13)
        Me.o_lblCustName.TabIndex = 0
        Me.o_lblCustName.Text = "Full Name"
        '
        'o_txtCustName
        '
        Me.o_txtCustName.Location = New System.Drawing.Point(0, 20)
        Me.o_txtCustName.Name = "o_txtCustName"
        Me.o_txtCustName.Size = New System.Drawing.Size(250, 20)
        Me.o_txtCustName.TabIndex = 1
        '
        'o_lblCustContact
        '
        Me.o_lblCustContact.AutoSize = True
        Me.o_lblCustContact.Location = New System.Drawing.Point(0, 55)
        Me.o_lblCustContact.Name = "o_lblCustContact"
        Me.o_lblCustContact.Size = New System.Drawing.Size(84, 13)
        Me.o_lblCustContact.TabIndex = 2
        Me.o_lblCustContact.Text = "Contact Number"
        '
        'o_txtCustContact
        '
        Me.o_txtCustContact.Location = New System.Drawing.Point(0, 75)
        Me.o_txtCustContact.Name = "o_txtCustContact"
        Me.o_txtCustContact.Size = New System.Drawing.Size(250, 20)
        Me.o_txtCustContact.TabIndex = 3
        '
        'o_lblCustAddress
        '
        Me.o_lblCustAddress.AutoSize = True
        Me.o_lblCustAddress.Location = New System.Drawing.Point(0, 110)
        Me.o_lblCustAddress.Name = "o_lblCustAddress"
        Me.o_lblCustAddress.Size = New System.Drawing.Size(45, 13)
        Me.o_lblCustAddress.TabIndex = 4
        Me.o_lblCustAddress.Text = "Address"
        '
        'o_txtCustAddress
        '
        Me.o_txtCustAddress.Location = New System.Drawing.Point(0, 130)
        Me.o_txtCustAddress.Name = "o_txtCustAddress"
        Me.o_txtCustAddress.Size = New System.Drawing.Size(250, 20)
        Me.o_txtCustAddress.TabIndex = 5
        '
        'o_btnConfirmOrder
        '
        Me.o_btnConfirmOrder.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.o_btnConfirmOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.o_btnConfirmOrder.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.o_btnConfirmOrder.ForeColor = System.Drawing.Color.White
        Me.o_btnConfirmOrder.Location = New System.Drawing.Point(400, 390)
        Me.o_btnConfirmOrder.Name = "o_btnConfirmOrder"
        Me.o_btnConfirmOrder.Size = New System.Drawing.Size(200, 45)
        Me.o_btnConfirmOrder.TabIndex = 9
        Me.o_btnConfirmOrder.Text = "Confirm Order"
        Me.o_btnConfirmOrder.UseVisualStyleBackColor = False
        '
        'o_btnBackToSales
        '
        Me.o_btnBackToSales.BackColor = System.Drawing.Color.Gray
        Me.o_btnBackToSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.o_btnBackToSales.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.o_btnBackToSales.ForeColor = System.Drawing.Color.White
        Me.o_btnBackToSales.Location = New System.Drawing.Point(620, 390)
        Me.o_btnBackToSales.Name = "o_btnBackToSales"
        Me.o_btnBackToSales.Size = New System.Drawing.Size(100, 45)
        Me.o_btnBackToSales.TabIndex = 10
        Me.o_btnBackToSales.Text = "Back"
        Me.o_btnBackToSales.UseVisualStyleBackColor = False
        '
        'o_dgvProducts
        '
        Me.o_dgvProducts.AllowUserToAddRows = False
        Me.o_dgvProducts.AllowUserToDeleteRows = False
        Me.o_dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.o_dgvProducts.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.o_dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.o_dgvProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.o_colProductID, Me.o_colProductName, Me.o_colBrand, Me.o_colDesc, Me.o_colPrice, Me.o_colStock, Me.o_colActionAdd, Me.o_colActionRemove})
        Me.o_dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.o_dgvProducts.Location = New System.Drawing.Point(0, 60)
        Me.o_dgvProducts.Name = "o_dgvProducts"
        Me.o_dgvProducts.RowHeadersVisible = False
        Me.o_dgvProducts.RowTemplate.Height = 50
        Me.o_dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.o_dgvProducts.Size = New System.Drawing.Size(1003, 521)
        Me.o_dgvProducts.TabIndex = 1
        '
        'o_colProductID
        '
        Me.o_colProductID.Name = "o_colProductID"
        Me.o_colProductID.Visible = False
        '
        'o_colProductName
        '
        Me.o_colProductName.HeaderText = "Product"
        Me.o_colProductName.Name = "o_colProductName"
        '
        'o_colBrand
        '
        Me.o_colBrand.HeaderText = "Brand"
        Me.o_colBrand.Name = "o_colBrand"
        '
        'o_colDesc
        '
        Me.o_colDesc.HeaderText = "Description"
        Me.o_colDesc.Name = "o_colDesc"
        '
        'o_colPrice
        '
        DataGridViewCellStyle13.Format = "C2"
        Me.o_colPrice.DefaultCellStyle = DataGridViewCellStyle13
        Me.o_colPrice.HeaderText = "Price"
        Me.o_colPrice.Name = "o_colPrice"
        '
        'o_colStock
        '
        Me.o_colStock.HeaderText = "Stock"
        Me.o_colStock.Name = "o_colStock"
        '
        'o_colActionAdd
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        Me.o_colActionAdd.DefaultCellStyle = DataGridViewCellStyle14
        Me.o_colActionAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.o_colActionAdd.HeaderText = "Add"
        Me.o_colActionAdd.Name = "o_colActionAdd"
        Me.o_colActionAdd.Text = "Add to Cart"
        Me.o_colActionAdd.UseColumnTextForButtonValue = True
        '
        'o_colActionRemove
        '
        Me.o_colActionRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.o_colActionRemove.HeaderText = "Remove"
        Me.o_colActionRemove.Name = "o_colActionRemove"
        Me.o_colActionRemove.Text = "Remove from Cart"
        Me.o_colActionRemove.UseColumnTextForButtonValue = True
        '
        'o_pnlCategories
        '
        Me.o_pnlCategories.Dock = System.Windows.Forms.DockStyle.Top
        Me.o_pnlCategories.Location = New System.Drawing.Point(0, 0)
        Me.o_pnlCategories.Name = "o_pnlCategories"
        Me.o_pnlCategories.Padding = New System.Windows.Forms.Padding(10)
        Me.o_pnlCategories.Size = New System.Drawing.Size(1003, 60)
        Me.o_pnlCategories.TabIndex = 2
        '
        'o_pnlCart
        '
        Me.o_pnlCart.BackColor = System.Drawing.Color.White
        Me.o_pnlCart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.o_pnlCart.Controls.Add(Me.o_flpCartItems)
        Me.o_pnlCart.Controls.Add(Me.o_lblCartTitle)
        Me.o_pnlCart.Controls.Add(Me.o_pnlTotal)
        Me.o_pnlCart.Dock = System.Windows.Forms.DockStyle.Right
        Me.o_pnlCart.Location = New System.Drawing.Point(1003, 0)
        Me.o_pnlCart.Name = "o_pnlCart"
        Me.o_pnlCart.Size = New System.Drawing.Size(350, 581)
        Me.o_pnlCart.TabIndex = 3
        '
        'o_flpCartItems
        '
        Me.o_flpCartItems.AutoScroll = True
        Me.o_flpCartItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.o_flpCartItems.Location = New System.Drawing.Point(0, 40)
        Me.o_flpCartItems.Name = "o_flpCartItems"
        Me.o_flpCartItems.Size = New System.Drawing.Size(348, 439)
        Me.o_flpCartItems.TabIndex = 0
        '
        'o_lblCartTitle
        '
        Me.o_lblCartTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.o_lblCartTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.o_lblCartTitle.Location = New System.Drawing.Point(0, 0)
        Me.o_lblCartTitle.Name = "o_lblCartTitle"
        Me.o_lblCartTitle.Size = New System.Drawing.Size(348, 40)
        Me.o_lblCartTitle.TabIndex = 1
        Me.o_lblCartTitle.Text = "Current Order"
        Me.o_lblCartTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'o_pnlTotal
        '
        Me.o_pnlTotal.Controls.Add(Me.o_lblTotalLabel)
        Me.o_pnlTotal.Controls.Add(Me.o_lblTotal)
        Me.o_pnlTotal.Controls.Add(Me.o_btnContinue)
        Me.o_pnlTotal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.o_pnlTotal.Location = New System.Drawing.Point(0, 479)
        Me.o_pnlTotal.Name = "o_pnlTotal"
        Me.o_pnlTotal.Size = New System.Drawing.Size(348, 100)
        Me.o_pnlTotal.TabIndex = 2
        '
        'o_lblTotalLabel
        '
        Me.o_lblTotalLabel.AutoSize = True
        Me.o_lblTotalLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.o_lblTotalLabel.Location = New System.Drawing.Point(20, 15)
        Me.o_lblTotalLabel.Name = "o_lblTotalLabel"
        Me.o_lblTotalLabel.Size = New System.Drawing.Size(52, 21)
        Me.o_lblTotalLabel.TabIndex = 0
        Me.o_lblTotalLabel.Text = "Total:"
        '
        'o_lblTotal
        '
        Me.o_lblTotal.AutoSize = True
        Me.o_lblTotal.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.o_lblTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.o_lblTotal.Location = New System.Drawing.Point(150, 10)
        Me.o_lblTotal.Name = "o_lblTotal"
        Me.o_lblTotal.Size = New System.Drawing.Size(72, 30)
        Me.o_lblTotal.TabIndex = 1
        Me.o_lblTotal.Text = "₱0.00"
        '
        'o_btnContinue
        '
        Me.o_btnContinue.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.o_btnContinue.Enabled = False
        Me.o_btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.o_btnContinue.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.o_btnContinue.ForeColor = System.Drawing.Color.White
        Me.o_btnContinue.Location = New System.Drawing.Point(20, 50)
        Me.o_btnContinue.Name = "o_btnContinue"
        Me.o_btnContinue.Size = New System.Drawing.Size(310, 40)
        Me.o_btnContinue.TabIndex = 2
        Me.o_btnContinue.Text = "Continue Checkout"
        Me.o_btnContinue.UseVisualStyleBackColor = False
        '
        'pnlViewOrdersMain
        '
        Me.pnlViewOrdersMain.Controls.Add(Me.v_dgvOrders)
        Me.pnlViewOrdersMain.Controls.Add(Me.v_pnlDetailForm)
        Me.pnlViewOrdersMain.Controls.Add(Me.v_pnlHeader)
        Me.pnlViewOrdersMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlViewOrdersMain.Location = New System.Drawing.Point(4, 22)
        Me.pnlViewOrdersMain.Name = "pnlViewOrdersMain"
        Me.pnlViewOrdersMain.Size = New System.Drawing.Size(1353, 581)
        Me.pnlViewOrdersMain.TabIndex = 2
        Me.pnlViewOrdersMain.Text = "ViewOrders"
        Me.pnlViewOrdersMain.Visible = False
        '
        'v_dgvOrders
        '
        Me.v_dgvOrders.AllowUserToAddRows = False
        Me.v_dgvOrders.AllowUserToDeleteRows = False
        Me.v_dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.v_dgvOrders.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.v_dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.v_dgvOrders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.v_colPurchaseID, Me.v_colReceipt, Me.v_colDate, Me.v_colCustomer, Me.v_colStaff, Me.v_colProducts, Me.v_colTotalAmount, Me.v_colActionEdit, Me.v_colActionDelete, Me.v_colActionPrint})
        Me.v_dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.v_dgvOrders.Location = New System.Drawing.Point(0, 80)
        Me.v_dgvOrders.Name = "v_dgvOrders"
        Me.v_dgvOrders.RowHeadersVisible = False
        Me.v_dgvOrders.RowTemplate.Height = 40
        Me.v_dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.v_dgvOrders.Size = New System.Drawing.Size(1353, 501)
        Me.v_dgvOrders.TabIndex = 0
        '
        'v_colPurchaseID
        '
        Me.v_colPurchaseID.Name = "v_colPurchaseID"
        Me.v_colPurchaseID.Visible = False
        '
        'v_colReceipt
        '
        Me.v_colReceipt.HeaderText = "Receipt Number"
        Me.v_colReceipt.Name = "v_colReceipt"
        '
        'v_colDate
        '
        Me.v_colDate.HeaderText = "Date"
        Me.v_colDate.Name = "v_colDate"
        '
        'v_colCustomer
        '
        Me.v_colCustomer.HeaderText = "Customer"
        Me.v_colCustomer.Name = "v_colCustomer"
        '
        'v_colStaff
        '
        Me.v_colStaff.HeaderText = "Assign Staff"
        Me.v_colStaff.Name = "v_colStaff"
        '
        'v_colProducts
        '
        Me.v_colProducts.HeaderText = "Products"
        Me.v_colProducts.Name = "v_colProducts"
        '
        'v_colTotalAmount
        '
        DataGridViewCellStyle15.Format = "C2"
        Me.v_colTotalAmount.DefaultCellStyle = DataGridViewCellStyle15
        Me.v_colTotalAmount.HeaderText = "Total Amount"
        Me.v_colTotalAmount.Name = "v_colTotalAmount"
        '
        'v_colActionEdit
        '
        Me.v_colActionEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.v_colActionEdit.HeaderText = "Action"
        Me.v_colActionEdit.Name = "v_colActionEdit"
        Me.v_colActionEdit.Text = "Edit"
        Me.v_colActionEdit.UseColumnTextForButtonValue = True
        '
        'v_colActionDelete
        '
        Me.v_colActionDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.v_colActionDelete.HeaderText = "Action"
        Me.v_colActionDelete.Name = "v_colActionDelete"
        Me.v_colActionDelete.Text = "Delete"
        Me.v_colActionDelete.UseColumnTextForButtonValue = True
        '
        'v_colActionPrint
        '
        Me.v_colActionPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.v_colActionPrint.HeaderText = "Action"
        Me.v_colActionPrint.Name = "v_colActionPrint"
        Me.v_colActionPrint.Text = "Print Receipt"
        Me.v_colActionPrint.UseColumnTextForButtonValue = True
        '
        'v_pnlHeader
        '
        Me.v_pnlHeader.BackColor = System.Drawing.Color.White
        Me.v_pnlHeader.Controls.Add(Me.v_lblTitle)
        Me.v_pnlHeader.Controls.Add(Me.v_lblDateRange)
        Me.v_pnlHeader.Controls.Add(Me.v_dtpStart)
        Me.v_pnlHeader.Controls.Add(Me.v_lblTo)
        Me.v_pnlHeader.Controls.Add(Me.v_dtpEnd)
        Me.v_pnlHeader.Controls.Add(Me.v_btnFilter)
        Me.v_pnlHeader.Controls.Add(Me.v_lblSearch)
        Me.v_pnlHeader.Controls.Add(Me.v_txtSearch)
        Me.v_pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.v_pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.v_pnlHeader.Name = "v_pnlHeader"
        Me.v_pnlHeader.Size = New System.Drawing.Size(1353, 80)
        Me.v_pnlHeader.TabIndex = 1
        '
        'v_lblTitle
        '
        Me.v_lblTitle.AutoSize = True
        Me.v_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.v_lblTitle.Location = New System.Drawing.Point(20, 20)
        Me.v_lblTitle.Name = "v_lblTitle"
        Me.v_lblTitle.Size = New System.Drawing.Size(215, 30)
        Me.v_lblTitle.TabIndex = 0
        Me.v_lblTitle.Text = "Transaction History"
        '
        'v_lblDateRange
        '
        Me.v_lblDateRange.AutoSize = True
        Me.v_lblDateRange.Location = New System.Drawing.Point(300, 30)
        Me.v_lblDateRange.Name = "v_lblDateRange"
        Me.v_lblDateRange.Size = New System.Drawing.Size(68, 13)
        Me.v_lblDateRange.TabIndex = 1
        Me.v_lblDateRange.Text = "Date Range:"
        '
        'v_dtpStart
        '
        Me.v_dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.v_dtpStart.Location = New System.Drawing.Point(380, 25)
        Me.v_dtpStart.Name = "v_dtpStart"
        Me.v_dtpStart.Size = New System.Drawing.Size(120, 20)
        Me.v_dtpStart.TabIndex = 2
        '
        'v_lblTo
        '
        Me.v_lblTo.AutoSize = True
        Me.v_lblTo.Location = New System.Drawing.Point(510, 30)
        Me.v_lblTo.Name = "v_lblTo"
        Me.v_lblTo.Size = New System.Drawing.Size(16, 13)
        Me.v_lblTo.TabIndex = 3
        Me.v_lblTo.Text = "to"
        '
        'v_dtpEnd
        '
        Me.v_dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.v_dtpEnd.Location = New System.Drawing.Point(540, 25)
        Me.v_dtpEnd.Name = "v_dtpEnd"
        Me.v_dtpEnd.Size = New System.Drawing.Size(120, 20)
        Me.v_dtpEnd.TabIndex = 4
        '
        'v_btnFilter
        '
        Me.v_btnFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.v_btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.v_btnFilter.ForeColor = System.Drawing.Color.White
        Me.v_btnFilter.Location = New System.Drawing.Point(680, 20)
        Me.v_btnFilter.Name = "v_btnFilter"
        Me.v_btnFilter.Size = New System.Drawing.Size(80, 35)
        Me.v_btnFilter.TabIndex = 5
        Me.v_btnFilter.Text = "Filter"
        Me.v_btnFilter.UseVisualStyleBackColor = False
        '
        'v_lblSearch
        '
        Me.v_lblSearch.AutoSize = True
        Me.v_lblSearch.Location = New System.Drawing.Point(660, 30)
        Me.v_lblSearch.Name = "v_lblSearch"
        Me.v_lblSearch.Size = New System.Drawing.Size(44, 13)
        Me.v_lblSearch.TabIndex = 6
        Me.v_lblSearch.Text = "Search:"
        '
        'v_txtSearch
        '
        Me.v_txtSearch.Location = New System.Drawing.Point(710, 27)
        Me.v_txtSearch.Name = "v_txtSearch"
        Me.v_txtSearch.Size = New System.Drawing.Size(300, 20)
        Me.v_txtSearch.TabIndex = 7
        '
        'v_pnlDetailForm
        '
        Me.v_pnlDetailForm.BackColor = System.Drawing.Color.White
        Me.v_pnlDetailForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.v_pnlDetailForm.Controls.Add(Me.v_lblDetailTitle)
        Me.v_pnlDetailForm.Controls.Add(Me.v_lblDetailReceipt)
        Me.v_pnlDetailForm.Controls.Add(Me.v_lblDetailCustomer)
        Me.v_pnlDetailForm.Controls.Add(Me.v_lblDetailStaff)
        Me.v_pnlDetailForm.Controls.Add(Me.v_lblDetailDate)
        Me.v_pnlDetailForm.Controls.Add(Me.v_lblDetailProducts)
        Me.v_pnlDetailForm.Controls.Add(Me.v_lblDetailTotal)
        Me.v_pnlDetailForm.Controls.Add(Me.v_btnDetailEdit)
        Me.v_pnlDetailForm.Controls.Add(Me.v_btnDetailClose)
        Me.v_pnlDetailForm.Dock = System.Windows.Forms.DockStyle.Right
        Me.v_pnlDetailForm.Name = "v_pnlDetailForm"
        Me.v_pnlDetailForm.Padding = New System.Windows.Forms.Padding(20)
        Me.v_pnlDetailForm.Size = New System.Drawing.Size(330, 581)
        Me.v_pnlDetailForm.TabIndex = 5
        Me.v_pnlDetailForm.Visible = False
        '
        'v_lblDetailTitle
        '
        Me.v_lblDetailTitle.AutoSize = True
        Me.v_lblDetailTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.v_lblDetailTitle.Location = New System.Drawing.Point(20, 20)
        Me.v_lblDetailTitle.Name = "v_lblDetailTitle"
        Me.v_lblDetailTitle.TabIndex = 0
        Me.v_lblDetailTitle.Text = "Order Details"
        '
        'v_lblDetailReceipt
        '
        Me.v_lblDetailReceipt.Location = New System.Drawing.Point(20, 55)
        Me.v_lblDetailReceipt.Name = "v_lblDetailReceipt"
        Me.v_lblDetailReceipt.Size = New System.Drawing.Size(290, 20)
        Me.v_lblDetailReceipt.TabIndex = 1
        '
        'v_lblDetailCustomer
        '
        Me.v_lblDetailCustomer.Location = New System.Drawing.Point(20, 80)
        Me.v_lblDetailCustomer.Name = "v_lblDetailCustomer"
        Me.v_lblDetailCustomer.Size = New System.Drawing.Size(290, 20)
        Me.v_lblDetailCustomer.TabIndex = 2
        '
        'v_lblDetailStaff
        '
        Me.v_lblDetailStaff.Location = New System.Drawing.Point(20, 105)
        Me.v_lblDetailStaff.Name = "v_lblDetailStaff"
        Me.v_lblDetailStaff.Size = New System.Drawing.Size(290, 20)
        Me.v_lblDetailStaff.TabIndex = 3
        '
        'v_lblDetailDate
        '
        Me.v_lblDetailDate.Location = New System.Drawing.Point(20, 130)
        Me.v_lblDetailDate.Name = "v_lblDetailDate"
        Me.v_lblDetailDate.Size = New System.Drawing.Size(290, 20)
        Me.v_lblDetailDate.TabIndex = 4
        '
        'v_lblDetailProducts
        '
        Me.v_lblDetailProducts.Location = New System.Drawing.Point(20, 160)
        Me.v_lblDetailProducts.Name = "v_lblDetailProducts"
        Me.v_lblDetailProducts.Size = New System.Drawing.Size(290, 80)
        Me.v_lblDetailProducts.TabIndex = 5
        '
        'v_lblDetailTotal
        '
        Me.v_lblDetailTotal.AutoSize = True
        Me.v_lblDetailTotal.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.v_lblDetailTotal.Location = New System.Drawing.Point(20, 250)
        Me.v_lblDetailTotal.Name = "v_lblDetailTotal"
        Me.v_lblDetailTotal.TabIndex = 6
        '
        'v_btnDetailEdit
        '
        Me.v_btnDetailEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.v_btnDetailEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.v_btnDetailEdit.ForeColor = System.Drawing.Color.White
        Me.v_btnDetailEdit.Location = New System.Drawing.Point(20, 290)
        Me.v_btnDetailEdit.Name = "v_btnDetailEdit"
        Me.v_btnDetailEdit.Size = New System.Drawing.Size(290, 35)
        Me.v_btnDetailEdit.TabIndex = 7
        Me.v_btnDetailEdit.Text = "Edit This Order"
        Me.v_btnDetailEdit.UseVisualStyleBackColor = False
        '
        'v_btnDetailClose
        '
        Me.v_btnDetailClose.BackColor = System.Drawing.Color.Gray
        Me.v_btnDetailClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.v_btnDetailClose.ForeColor = System.Drawing.Color.White
        Me.v_btnDetailClose.Location = New System.Drawing.Point(20, 335)
        Me.v_btnDetailClose.Name = "v_btnDetailClose"
        Me.v_btnDetailClose.Size = New System.Drawing.Size(290, 35)
        Me.v_btnDetailClose.TabIndex = 8
        Me.v_btnDetailClose.Text = "Close"
        Me.v_btnDetailClose.UseVisualStyleBackColor = False
        '
        'pnlAddProductMain
        '
        Me.pnlAddProductMain.Controls.Add(Me.a_lblTitle)
        Me.pnlAddProductMain.Controls.Add(Me.a_pnlForm)
        Me.pnlAddProductMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAddProductMain.Location = New System.Drawing.Point(4, 22)
        Me.pnlAddProductMain.Name = "pnlAddProductMain"
        Me.pnlAddProductMain.Size = New System.Drawing.Size(1353, 581)
        Me.pnlAddProductMain.TabIndex = 3
        Me.pnlAddProductMain.Text = "AddProduct"
        Me.pnlAddProductMain.Visible = False
        '
        'a_lblTitle
        '
        Me.a_lblTitle.AutoSize = True
        Me.a_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.a_lblTitle.Location = New System.Drawing.Point(30, 20)
        Me.a_lblTitle.Name = "a_lblTitle"
        Me.a_lblTitle.Size = New System.Drawing.Size(198, 30)
        Me.a_lblTitle.TabIndex = 0
        Me.a_lblTitle.Text = "Add New Product"
        '
        'a_pnlForm
        '
        Me.a_pnlForm.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.a_pnlForm.AutoScroll = True
        Me.a_pnlForm.BackColor = System.Drawing.Color.White
        Me.a_pnlForm.Controls.Add(Me.a_lblProdName)
        Me.a_pnlForm.Controls.Add(Me.a_txtProdName)
        Me.a_pnlForm.Controls.Add(Me.a_lblProdBrand)
        Me.a_pnlForm.Controls.Add(Me.a_cmbBrand)
        Me.a_pnlForm.Controls.Add(Me.a_chkNewBrand)
        Me.a_pnlForm.Controls.Add(Me.a_txtNewBrand)
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
        Me.a_pnlForm.Location = New System.Drawing.Point(30, 70)
        Me.a_pnlForm.Name = "a_pnlForm"
        Me.a_pnlForm.Size = New System.Drawing.Size(1903, 931)
        Me.a_pnlForm.TabIndex = 1
        '
        'a_lblProdName
        '
        Me.a_lblProdName.AutoSize = True
        Me.a_lblProdName.Location = New System.Drawing.Point(30, 30)
        Me.a_lblProdName.Name = "a_lblProdName"
        Me.a_lblProdName.Size = New System.Drawing.Size(75, 13)
        Me.a_lblProdName.TabIndex = 0
        Me.a_lblProdName.Text = "Product Name"
        '
        'a_txtProdName
        '
        Me.a_txtProdName.Location = New System.Drawing.Point(30, 50)
        Me.a_txtProdName.Name = "a_txtProdName"
        Me.a_txtProdName.Size = New System.Drawing.Size(250, 20)
        Me.a_txtProdName.TabIndex = 1
        '
        'a_lblProdBrand
        '
        Me.a_lblProdBrand.AutoSize = True
        Me.a_lblProdBrand.Location = New System.Drawing.Point(30, 90)
        Me.a_lblProdBrand.Name = "a_lblProdBrand"
        Me.a_lblProdBrand.Size = New System.Drawing.Size(35, 13)
        Me.a_lblProdBrand.TabIndex = 2
        Me.a_lblProdBrand.Text = "Brand"
        '
        'a_cmbBrand
        '
        Me.a_cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.a_cmbBrand.Items.AddRange(New Object() {"Midea", "Kolin", "TCL", "Panasonic"})
        Me.a_cmbBrand.Location = New System.Drawing.Point(30, 110)
        Me.a_cmbBrand.Name = "a_cmbBrand"
        Me.a_cmbBrand.Size = New System.Drawing.Size(180, 21)
        Me.a_cmbBrand.TabIndex = 3
        '
        'a_chkNewBrand
        '
        Me.a_chkNewBrand.AutoSize = True
        Me.a_chkNewBrand.Location = New System.Drawing.Point(220, 112)
        Me.a_chkNewBrand.Name = "a_chkNewBrand"
        Me.a_chkNewBrand.Size = New System.Drawing.Size(60, 17)
        Me.a_chkNewBrand.TabIndex = 4
        Me.a_chkNewBrand.Text = "+ New"
        '
        'a_txtNewBrand
        '
        Me.a_txtNewBrand.Location = New System.Drawing.Point(30, 137)
        Me.a_txtNewBrand.Name = "a_txtNewBrand"
        Me.a_txtNewBrand.Size = New System.Drawing.Size(250, 20)
        Me.a_txtNewBrand.TabIndex = 5
        Me.a_txtNewBrand.Visible = False
        '
        'a_lblCategory
        '
        Me.a_lblCategory.AutoSize = True
        Me.a_lblCategory.Location = New System.Drawing.Point(30, 165)
        Me.a_lblCategory.Name = "a_lblCategory"
        Me.a_lblCategory.Size = New System.Drawing.Size(49, 13)
        Me.a_lblCategory.TabIndex = 6
        Me.a_lblCategory.Text = "Category"
        '
        'a_cmbCategory
        '
        Me.a_cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.a_cmbCategory.Items.AddRange(New Object() {"Air Conditioners", "Washing Machines", "Televisions", "Refrigerators"})
        Me.a_cmbCategory.Location = New System.Drawing.Point(30, 185)
        Me.a_cmbCategory.Name = "a_cmbCategory"
        Me.a_cmbCategory.Size = New System.Drawing.Size(250, 21)
        Me.a_cmbCategory.TabIndex = 7
        '
        'a_lblProdDesc
        '
        Me.a_lblProdDesc.AutoSize = True
        Me.a_lblProdDesc.Location = New System.Drawing.Point(30, 210)
        Me.a_lblProdDesc.Name = "a_lblProdDesc"
        Me.a_lblProdDesc.Size = New System.Drawing.Size(60, 13)
        Me.a_lblProdDesc.TabIndex = 6
        Me.a_lblProdDesc.Text = "Description"
        '
        'a_txtProdDesc
        '
        Me.a_txtProdDesc.Location = New System.Drawing.Point(30, 230)
        Me.a_txtProdDesc.Multiline = True
        Me.a_txtProdDesc.Name = "a_txtProdDesc"
        Me.a_txtProdDesc.Size = New System.Drawing.Size(250, 50)
        Me.a_txtProdDesc.TabIndex = 7
        '
        'a_lblPrice
        '
        Me.a_lblPrice.AutoSize = True
        Me.a_lblPrice.Location = New System.Drawing.Point(320, 30)
        Me.a_lblPrice.Name = "a_lblPrice"
        Me.a_lblPrice.Size = New System.Drawing.Size(69, 13)
        Me.a_lblPrice.TabIndex = 8
        Me.a_lblPrice.Text = "Unit Price (₱)"
        '
        'a_numPrice
        '
        Me.a_numPrice.DecimalPlaces = 2
        Me.a_numPrice.Location = New System.Drawing.Point(320, 50)
        Me.a_numPrice.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.a_numPrice.Name = "a_numPrice"
        Me.a_numPrice.Size = New System.Drawing.Size(120, 20)
        Me.a_numPrice.TabIndex = 9
        '
        'a_lblStock
        '
        Me.a_lblStock.AutoSize = True
        Me.a_lblStock.Location = New System.Drawing.Point(320, 90)
        Me.a_lblStock.Name = "a_lblStock"
        Me.a_lblStock.Size = New System.Drawing.Size(62, 13)
        Me.a_lblStock.TabIndex = 10
        Me.a_lblStock.Text = "Initial Stock"
        '
        'a_numStock
        '
        Me.a_numStock.Location = New System.Drawing.Point(320, 110)
        Me.a_numStock.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.a_numStock.Name = "a_numStock"
        Me.a_numStock.Size = New System.Drawing.Size(120, 20)
        Me.a_numStock.TabIndex = 11
        '
        'a_lblReorder
        '
        Me.a_lblReorder.AutoSize = True
        Me.a_lblReorder.Location = New System.Drawing.Point(320, 150)
        Me.a_lblReorder.Name = "a_lblReorder"
        Me.a_lblReorder.Size = New System.Drawing.Size(74, 13)
        Me.a_lblReorder.TabIndex = 12
        Me.a_lblReorder.Text = "Reorder Level"
        '
        'a_numReorder
        '
        Me.a_numReorder.Location = New System.Drawing.Point(320, 170)
        Me.a_numReorder.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.a_numReorder.Name = "a_numReorder"
        Me.a_numReorder.Size = New System.Drawing.Size(120, 20)
        Me.a_numReorder.TabIndex = 13
        '
        'a_lblSupplierTitle
        '
        Me.a_lblSupplierTitle.AutoSize = True
        Me.a_lblSupplierTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.a_lblSupplierTitle.Location = New System.Drawing.Point(480, 30)
        Me.a_lblSupplierTitle.Name = "a_lblSupplierTitle"
        Me.a_lblSupplierTitle.Size = New System.Drawing.Size(170, 21)
        Me.a_lblSupplierTitle.TabIndex = 14
        Me.a_lblSupplierTitle.Text = "Supplier Information"
        '
        'a_optExistingSupplier
        '
        Me.a_optExistingSupplier.AutoSize = True
        Me.a_optExistingSupplier.Checked = True
        Me.a_optExistingSupplier.Location = New System.Drawing.Point(480, 60)
        Me.a_optExistingSupplier.Name = "a_optExistingSupplier"
        Me.a_optExistingSupplier.Size = New System.Drawing.Size(102, 17)
        Me.a_optExistingSupplier.TabIndex = 15
        Me.a_optExistingSupplier.TabStop = True
        Me.a_optExistingSupplier.Text = "Existing Supplier"
        '
        'a_cmbExistingSupplier
        '
        Me.a_cmbExistingSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.a_cmbExistingSupplier.Location = New System.Drawing.Point(500, 85)
        Me.a_cmbExistingSupplier.Name = "a_cmbExistingSupplier"
        Me.a_cmbExistingSupplier.Size = New System.Drawing.Size(200, 21)
        Me.a_cmbExistingSupplier.TabIndex = 16
        '
        'a_optNewSupplier
        '
        Me.a_optNewSupplier.AutoSize = True
        Me.a_optNewSupplier.Location = New System.Drawing.Point(480, 120)
        Me.a_optNewSupplier.Name = "a_optNewSupplier"
        Me.a_optNewSupplier.Size = New System.Drawing.Size(88, 17)
        Me.a_optNewSupplier.TabIndex = 17
        Me.a_optNewSupplier.Text = "New Supplier"
        '
        'a_pnlNewSupplier
        '
        Me.a_pnlNewSupplier.Controls.Add(Me.a_lblSupName)
        Me.a_pnlNewSupplier.Controls.Add(Me.a_txtSupName)
        Me.a_pnlNewSupplier.Controls.Add(Me.a_lblSupContact)
        Me.a_pnlNewSupplier.Controls.Add(Me.a_txtSupContact)
        Me.a_pnlNewSupplier.Controls.Add(Me.a_lblSupAddress)
        Me.a_pnlNewSupplier.Controls.Add(Me.a_txtSupAddress)
        Me.a_pnlNewSupplier.Location = New System.Drawing.Point(500, 145)
        Me.a_pnlNewSupplier.Name = "a_pnlNewSupplier"
        Me.a_pnlNewSupplier.Size = New System.Drawing.Size(220, 180)
        Me.a_pnlNewSupplier.TabIndex = 18
        '
        'a_lblSupName
        '
        Me.a_lblSupName.AutoSize = True
        Me.a_lblSupName.Location = New System.Drawing.Point(0, 0)
        Me.a_lblSupName.Name = "a_lblSupName"
        Me.a_lblSupName.Size = New System.Drawing.Size(76, 13)
        Me.a_lblSupName.TabIndex = 0
        Me.a_lblSupName.Text = "Supplier Name"
        '
        'a_txtSupName
        '
        Me.a_txtSupName.Location = New System.Drawing.Point(0, 20)
        Me.a_txtSupName.Name = "a_txtSupName"
        Me.a_txtSupName.Size = New System.Drawing.Size(200, 20)
        Me.a_txtSupName.TabIndex = 1
        '
        'a_lblSupContact
        '
        Me.a_lblSupContact.AutoSize = True
        Me.a_lblSupContact.Location = New System.Drawing.Point(0, 55)
        Me.a_lblSupContact.Name = "a_lblSupContact"
        Me.a_lblSupContact.Size = New System.Drawing.Size(84, 13)
        Me.a_lblSupContact.TabIndex = 2
        Me.a_lblSupContact.Text = "Contact Number"
        '
        'a_txtSupContact
        '
        Me.a_txtSupContact.Location = New System.Drawing.Point(0, 75)
        Me.a_txtSupContact.Name = "a_txtSupContact"
        Me.a_txtSupContact.Size = New System.Drawing.Size(200, 20)
        Me.a_txtSupContact.TabIndex = 3
        '
        'a_lblSupAddress
        '
        Me.a_lblSupAddress.AutoSize = True
        Me.a_lblSupAddress.Location = New System.Drawing.Point(0, 110)
        Me.a_lblSupAddress.Name = "a_lblSupAddress"
        Me.a_lblSupAddress.Size = New System.Drawing.Size(45, 13)
        Me.a_lblSupAddress.TabIndex = 4
        Me.a_lblSupAddress.Text = "Address"
        '
        'a_txtSupAddress
        '
        Me.a_txtSupAddress.Location = New System.Drawing.Point(0, 130)
        Me.a_txtSupAddress.Name = "a_txtSupAddress"
        Me.a_txtSupAddress.Size = New System.Drawing.Size(200, 20)
        Me.a_txtSupAddress.TabIndex = 5
        '
        'a_btnSave
        '
        Me.a_btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.a_btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.a_btnSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.a_btnSave.ForeColor = System.Drawing.Color.White
        Me.a_btnSave.Location = New System.Drawing.Point(30, 310)
        Me.a_btnSave.Name = "a_btnSave"
        Me.a_btnSave.Size = New System.Drawing.Size(150, 40)
        Me.a_btnSave.TabIndex = 19
        Me.a_btnSave.Text = "Save Product"
        Me.a_btnSave.UseVisualStyleBackColor = False
        '
        'a_btnCancel
        '
        Me.a_btnCancel.BackColor = System.Drawing.Color.White
        Me.a_btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.a_btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.a_btnCancel.Location = New System.Drawing.Point(190, 310)
        Me.a_btnCancel.Name = "a_btnCancel"
        Me.a_btnCancel.Size = New System.Drawing.Size(120, 40)
        Me.a_btnCancel.TabIndex = 20
        Me.a_btnCancel.Text = "Clear Fields"
        Me.a_btnCancel.UseVisualStyleBackColor = False
        '
        'pnlManageProductsMain
        '
        Me.pnlManageProductsMain.Controls.Add(Me.m_pnlEditProduct)
        Me.pnlManageProductsMain.Controls.Add(Me.m_dgvProducts)
        Me.pnlManageProductsMain.Controls.Add(Me.m_pnlCategories)
        Me.pnlManageProductsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlManageProductsMain.Location = New System.Drawing.Point(4, 22)
        Me.pnlManageProductsMain.Name = "pnlManageProductsMain"
        Me.pnlManageProductsMain.Size = New System.Drawing.Size(1353, 581)
        Me.pnlManageProductsMain.TabIndex = 4
        Me.pnlManageProductsMain.Text = "ManageProducts"
        Me.pnlManageProductsMain.Visible = False
        '
        'm_pnlEditProduct
        '
        Me.m_pnlEditProduct.BackColor = System.Drawing.Color.White
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
        Me.m_pnlEditProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_pnlEditProduct.Location = New System.Drawing.Point(0, 60)
        Me.m_pnlEditProduct.Name = "m_pnlEditProduct"
        Me.m_pnlEditProduct.Size = New System.Drawing.Size(1353, 521)
        Me.m_pnlEditProduct.TabIndex = 0
        Me.m_pnlEditProduct.Visible = False
        '
        'm_lblEditTitle
        '
        Me.m_lblEditTitle.AutoSize = True
        Me.m_lblEditTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.m_lblEditTitle.Location = New System.Drawing.Point(30, 30)
        Me.m_lblEditTitle.Name = "m_lblEditTitle"
        Me.m_lblEditTitle.Size = New System.Drawing.Size(143, 30)
        Me.m_lblEditTitle.TabIndex = 0
        Me.m_lblEditTitle.Text = "Edit Product"
        '
        'm_lblEditName
        '
        Me.m_lblEditName.AutoSize = True
        Me.m_lblEditName.Location = New System.Drawing.Point(30, 80)
        Me.m_lblEditName.Name = "m_lblEditName"
        Me.m_lblEditName.Size = New System.Drawing.Size(75, 13)
        Me.m_lblEditName.TabIndex = 1
        Me.m_lblEditName.Text = "Product Name"
        '
        'm_txtEditName
        '
        Me.m_txtEditName.Location = New System.Drawing.Point(30, 100)
        Me.m_txtEditName.Name = "m_txtEditName"
        Me.m_txtEditName.Size = New System.Drawing.Size(250, 20)
        Me.m_txtEditName.TabIndex = 2
        '
        'm_lblEditBrand
        '
        Me.m_lblEditBrand.AutoSize = True
        Me.m_lblEditBrand.Location = New System.Drawing.Point(30, 140)
        Me.m_lblEditBrand.Name = "m_lblEditBrand"
        Me.m_lblEditBrand.Size = New System.Drawing.Size(35, 13)
        Me.m_lblEditBrand.TabIndex = 3
        Me.m_lblEditBrand.Text = "Brand"
        '
        'm_txtEditBrand
        '
        Me.m_txtEditBrand.Location = New System.Drawing.Point(30, 160)
        Me.m_txtEditBrand.Name = "m_txtEditBrand"
        Me.m_txtEditBrand.Size = New System.Drawing.Size(250, 20)
        Me.m_txtEditBrand.TabIndex = 4
        '
        'm_lblEditCategory
        '
        Me.m_lblEditCategory.AutoSize = True
        Me.m_lblEditCategory.Location = New System.Drawing.Point(30, 200)
        Me.m_lblEditCategory.Name = "m_lblEditCategory"
        Me.m_lblEditCategory.Size = New System.Drawing.Size(49, 13)
        Me.m_lblEditCategory.TabIndex = 5
        Me.m_lblEditCategory.Text = "Category"
        '
        'm_cmbEditCategory
        '
        Me.m_cmbEditCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cmbEditCategory.Items.AddRange(New Object() {"Air Conditioners", "Washing Machines", "Televisions", "Refrigerators"})
        Me.m_cmbEditCategory.Location = New System.Drawing.Point(30, 220)
        Me.m_cmbEditCategory.Name = "m_cmbEditCategory"
        Me.m_cmbEditCategory.Size = New System.Drawing.Size(250, 21)
        Me.m_cmbEditCategory.TabIndex = 6
        '
        'm_lblEditPrice
        '
        Me.m_lblEditPrice.AutoSize = True
        Me.m_lblEditPrice.Location = New System.Drawing.Point(320, 80)
        Me.m_lblEditPrice.Name = "m_lblEditPrice"
        Me.m_lblEditPrice.Size = New System.Drawing.Size(53, 13)
        Me.m_lblEditPrice.TabIndex = 7
        Me.m_lblEditPrice.Text = "Unit Price"
        '
        'm_numEditPrice
        '
        Me.m_numEditPrice.DecimalPlaces = 2
        Me.m_numEditPrice.Location = New System.Drawing.Point(320, 100)
        Me.m_numEditPrice.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.m_numEditPrice.Name = "m_numEditPrice"
        Me.m_numEditPrice.Size = New System.Drawing.Size(120, 20)
        Me.m_numEditPrice.TabIndex = 8
        '
        'm_lblEditStock
        '
        Me.m_lblEditStock.AutoSize = True
        Me.m_lblEditStock.Location = New System.Drawing.Point(320, 140)
        Me.m_lblEditStock.Name = "m_lblEditStock"
        Me.m_lblEditStock.Size = New System.Drawing.Size(77, 13)
        Me.m_lblEditStock.TabIndex = 9
        Me.m_lblEditStock.Text = "Stock Quantity"
        '
        'm_numEditStock
        '
        Me.m_numEditStock.Location = New System.Drawing.Point(320, 160)
        Me.m_numEditStock.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.m_numEditStock.Name = "m_numEditStock"
        Me.m_numEditStock.Size = New System.Drawing.Size(120, 20)
        Me.m_numEditStock.TabIndex = 10
        '
        'm_lblEditReorder
        '
        Me.m_lblEditReorder.AutoSize = True
        Me.m_lblEditReorder.Location = New System.Drawing.Point(320, 200)
        Me.m_lblEditReorder.Name = "m_lblEditReorder"
        Me.m_lblEditReorder.Size = New System.Drawing.Size(74, 13)
        Me.m_lblEditReorder.TabIndex = 11
        Me.m_lblEditReorder.Text = "Reorder Level"
        '
        'm_numEditReorder
        '
        Me.m_numEditReorder.Location = New System.Drawing.Point(320, 220)
        Me.m_numEditReorder.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.m_numEditReorder.Name = "m_numEditReorder"
        Me.m_numEditReorder.Size = New System.Drawing.Size(120, 20)
        Me.m_numEditReorder.TabIndex = 12
        '
        'm_btnUpdate
        '
        Me.m_btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.m_btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.m_btnUpdate.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.m_btnUpdate.ForeColor = System.Drawing.Color.White
        Me.m_btnUpdate.Location = New System.Drawing.Point(30, 280)
        Me.m_btnUpdate.Name = "m_btnUpdate"
        Me.m_btnUpdate.Size = New System.Drawing.Size(150, 40)
        Me.m_btnUpdate.TabIndex = 13
        Me.m_btnUpdate.Text = "Update Product"
        Me.m_btnUpdate.UseVisualStyleBackColor = False
        '
        'm_btnCancel
        '
        Me.m_btnCancel.BackColor = System.Drawing.Color.White
        Me.m_btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.m_btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.m_btnCancel.Location = New System.Drawing.Point(190, 280)
        Me.m_btnCancel.Name = "m_btnCancel"
        Me.m_btnCancel.Size = New System.Drawing.Size(100, 40)
        Me.m_btnCancel.TabIndex = 14
        Me.m_btnCancel.Text = "Cancel"
        Me.m_btnCancel.UseVisualStyleBackColor = False
        '
        'm_dgvProducts
        '
        Me.m_dgvProducts.AllowUserToAddRows = False
        Me.m_dgvProducts.AllowUserToDeleteRows = False
        Me.m_dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.m_dgvProducts.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.m_dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.m_dgvProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.m_colProductID, Me.m_colProductName, Me.m_colBrand, Me.m_colDesc, Me.m_colPrice, Me.m_colStock, Me.m_colReorder, Me.m_colActionEdit, Me.m_colActionDelete})
        Me.m_dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_dgvProducts.Location = New System.Drawing.Point(0, 60)
        Me.m_dgvProducts.Name = "m_dgvProducts"
        Me.m_dgvProducts.RowHeadersVisible = False
        Me.m_dgvProducts.RowTemplate.Height = 40
        Me.m_dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.m_dgvProducts.Size = New System.Drawing.Size(1353, 521)
        Me.m_dgvProducts.TabIndex = 1
        '
        'm_colProductID
        '
        Me.m_colProductID.Name = "m_colProductID"
        Me.m_colProductID.Visible = False
        '
        'm_colProductName
        '
        Me.m_colProductName.HeaderText = "Product Name"
        Me.m_colProductName.Name = "m_colProductName"
        '
        'm_colBrand
        '
        Me.m_colBrand.HeaderText = "Brand"
        Me.m_colBrand.Name = "m_colBrand"
        '
        'm_colDesc
        '
        Me.m_colDesc.HeaderText = "Description"
        Me.m_colDesc.Name = "m_colDesc"
        '
        'm_colPrice
        '
        DataGridViewCellStyle16.Format = "C2"
        Me.m_colPrice.DefaultCellStyle = DataGridViewCellStyle16
        Me.m_colPrice.HeaderText = "Price"
        Me.m_colPrice.Name = "m_colPrice"
        '
        'm_colStock
        '
        Me.m_colStock.HeaderText = "Stock"
        Me.m_colStock.Name = "m_colStock"
        '
        'm_colReorder
        '
        Me.m_colReorder.HeaderText = "Reorder Level"
        Me.m_colReorder.Name = "m_colReorder"
        '
        'm_colActionEdit
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
        Me.m_colActionEdit.DefaultCellStyle = DataGridViewCellStyle17
        Me.m_colActionEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.m_colActionEdit.HeaderText = "Action"
        Me.m_colActionEdit.Name = "m_colActionEdit"
        Me.m_colActionEdit.Text = "Edit"
        Me.m_colActionEdit.UseColumnTextForButtonValue = True
        '
        'm_colActionDelete
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
        Me.m_colActionDelete.DefaultCellStyle = DataGridViewCellStyle18
        Me.m_colActionDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.m_colActionDelete.HeaderText = "Action"
        Me.m_colActionDelete.Name = "m_colActionDelete"
        Me.m_colActionDelete.Text = "Delete"
        Me.m_colActionDelete.UseColumnTextForButtonValue = True
        '
        'm_pnlCategories
        '
        Me.m_pnlCategories.Dock = System.Windows.Forms.DockStyle.Top
        Me.m_pnlCategories.Location = New System.Drawing.Point(0, 0)
        Me.m_pnlCategories.Name = "m_pnlCategories"
        Me.m_pnlCategories.Padding = New System.Windows.Forms.Padding(10)
        Me.m_pnlCategories.Size = New System.Drawing.Size(1353, 60)
        Me.m_pnlCategories.TabIndex = 2
        '
        'pnlLowStockMain
        '
        Me.pnlLowStockMain.Controls.Add(Me.l_dgvAlerts)
        Me.pnlLowStockMain.Controls.Add(Me.l_pnlCategories)
        Me.pnlLowStockMain.Controls.Add(Me.l_pnlHeader)
        Me.pnlLowStockMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLowStockMain.Location = New System.Drawing.Point(4, 22)
        Me.pnlLowStockMain.Name = "pnlLowStockMain"
        Me.pnlLowStockMain.Size = New System.Drawing.Size(1353, 581)
        Me.pnlLowStockMain.TabIndex = 5
        Me.pnlLowStockMain.Text = "LowStock"
        Me.pnlLowStockMain.Visible = False
        '
        'l_dgvAlerts
        '
        Me.l_dgvAlerts.AllowUserToAddRows = False
        Me.l_dgvAlerts.AllowUserToDeleteRows = False
        Me.l_dgvAlerts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.l_dgvAlerts.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.l_dgvAlerts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.l_dgvAlerts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.l_colProductID, Me.l_colProductName, Me.l_colBrand, Me.l_colStock, Me.l_colReorder, Me.l_colSupplier, Me.l_colActionAddStock})
        Me.l_dgvAlerts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.l_dgvAlerts.Location = New System.Drawing.Point(0, 120)
        Me.l_dgvAlerts.Name = "l_dgvAlerts"
        Me.l_dgvAlerts.RowHeadersVisible = False
        Me.l_dgvAlerts.RowTemplate.Height = 40
        Me.l_dgvAlerts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.l_dgvAlerts.Size = New System.Drawing.Size(1353, 461)
        Me.l_dgvAlerts.TabIndex = 0
        '
        'l_colProductID
        '
        Me.l_colProductID.Name = "l_colProductID"
        Me.l_colProductID.Visible = False
        '
        'l_colProductName
        '
        Me.l_colProductName.HeaderText = "Product Name"
        Me.l_colProductName.Name = "l_colProductName"
        '
        'l_colBrand
        '
        Me.l_colBrand.HeaderText = "Brand"
        Me.l_colBrand.Name = "l_colBrand"
        '
        'l_colStock
        '
        Me.l_colStock.HeaderText = "Current Stock"
        Me.l_colStock.Name = "l_colStock"
        '
        'l_colReorder
        '
        Me.l_colReorder.HeaderText = "Reorder Level"
        Me.l_colReorder.Name = "l_colReorder"
        '
        'l_colSupplier
        '
        Me.l_colSupplier.HeaderText = "Supplier"
        Me.l_colSupplier.Name = "l_colSupplier"
        '
        'l_colActionAddStock
        '
        Me.l_colActionAddStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.l_colActionAddStock.HeaderText = "Action"
        Me.l_colActionAddStock.Name = "l_colActionAddStock"
        Me.l_colActionAddStock.Text = "+ Add Stock"
        Me.l_colActionAddStock.UseColumnTextForButtonValue = True
        '
        'l_pnlCategories
        '
        Me.l_pnlCategories.Dock = System.Windows.Forms.DockStyle.Top
        Me.l_pnlCategories.Location = New System.Drawing.Point(0, 60)
        Me.l_pnlCategories.Name = "l_pnlCategories"
        Me.l_pnlCategories.Padding = New System.Windows.Forms.Padding(10)
        Me.l_pnlCategories.Size = New System.Drawing.Size(1353, 60)
        Me.l_pnlCategories.TabIndex = 1
        '
        'l_pnlHeader
        '
        Me.l_pnlHeader.BackColor = System.Drawing.Color.White
        Me.l_pnlHeader.Controls.Add(Me.l_lblTitle)
        Me.l_pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.l_pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.l_pnlHeader.Name = "l_pnlHeader"
        Me.l_pnlHeader.Size = New System.Drawing.Size(1353, 60)
        Me.l_pnlHeader.TabIndex = 2
        '
        'l_lblTitle
        '
        Me.l_lblTitle.AutoSize = True
        Me.l_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.l_lblTitle.ForeColor = System.Drawing.Color.Black
        Me.l_lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.l_lblTitle.Name = "l_lblTitle"
        Me.l_lblTitle.Size = New System.Drawing.Size(185, 30)
        Me.l_lblTitle.TabIndex = 0
        Me.l_lblTitle.Text = "Low Stock Alerts"
        '
        'pnlStockTransactionMain
        '
        Me.pnlStockTransactionMain.Controls.Add(Me.s_dgvHistory)
        Me.pnlStockTransactionMain.Controls.Add(Me.s_pnlEditForm)
        Me.pnlStockTransactionMain.Controls.Add(Me.s_pnlHeader)
        Me.pnlStockTransactionMain.Controls.Add(Me.s_pnlForm)
        Me.pnlStockTransactionMain.Controls.Add(Me.s_lblTitle)
        Me.pnlStockTransactionMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlStockTransactionMain.Location = New System.Drawing.Point(4, 22)
        Me.pnlStockTransactionMain.Name = "pnlStockTransactionMain"
        Me.pnlStockTransactionMain.Size = New System.Drawing.Size(1353, 581)
        Me.pnlStockTransactionMain.TabIndex = 6
        Me.pnlStockTransactionMain.Text = "StockTransaction"
        Me.pnlStockTransactionMain.Visible = False
        '
        's_dgvHistory
        '
        Me.s_dgvHistory.AllowUserToAddRows = False
        Me.s_dgvHistory.AllowUserToDeleteRows = False
        Me.s_dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.s_dgvHistory.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.s_dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.s_dgvHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.s_colTransID, Me.s_colProduct, Me.s_colType, Me.s_colQty, Me.s_colDate, Me.s_colRemarks, Me.s_colActionEdit, Me.s_colActionDelete})
        Me.s_dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.s_dgvHistory.Location = New System.Drawing.Point(350, 0)
        Me.s_dgvHistory.Name = "s_dgvHistory"
        Me.s_dgvHistory.RowHeadersVisible = False
        Me.s_dgvHistory.RowTemplate.Height = 40
        Me.s_dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.s_dgvHistory.Size = New System.Drawing.Size(1003, 581)
        Me.s_dgvHistory.TabIndex = 0
        '
        's_colTransID
        '
        Me.s_colTransID.Name = "s_colTransID"
        Me.s_colTransID.Visible = False
        '
        's_colProduct
        '
        Me.s_colProduct.HeaderText = "Product Name"
        Me.s_colProduct.Name = "s_colProduct"
        '
        's_colType
        '
        Me.s_colType.HeaderText = "Transaction Type"
        Me.s_colType.Name = "s_colType"
        '
        's_colQty
        '
        Me.s_colQty.HeaderText = "Qty"
        Me.s_colQty.Name = "s_colQty"
        '
        's_colDate
        '
        Me.s_colDate.HeaderText = "Date"
        Me.s_colDate.Name = "s_colDate"
        '
        's_colRemarks
        '
        Me.s_colRemarks.HeaderText = "Remarks"
        Me.s_colRemarks.Name = "s_colRemarks"
        '
        's_colActionEdit
        '
        Me.s_colActionEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.s_colActionEdit.HeaderText = "Action"
        Me.s_colActionEdit.Name = "s_colActionEdit"
        Me.s_colActionEdit.Text = "Edit"
        Me.s_colActionEdit.UseColumnTextForButtonValue = True
        '
        's_colActionDelete
        '
        Me.s_colActionDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.s_colActionDelete.HeaderText = "Action"
        Me.s_colActionDelete.Name = "s_colActionDelete"
        Me.s_colActionDelete.Text = "Delete"
        Me.s_colActionDelete.UseColumnTextForButtonValue = True
        '
        's_pnlForm
        '
        Me.s_pnlForm.BackColor = System.Drawing.Color.White
        Me.s_pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.s_pnlForm.Controls.Add(Me.s_lblProduct)
        Me.s_pnlForm.Controls.Add(Me.s_cmbProduct)
        Me.s_pnlForm.Controls.Add(Me.s_lblType)
        Me.s_pnlForm.Controls.Add(Me.s_cmbType)
        Me.s_pnlForm.Controls.Add(Me.s_lblQuantity)
        Me.s_pnlForm.Controls.Add(Me.s_numQuantity)
        Me.s_pnlForm.Controls.Add(Me.s_lblRemarks)
        Me.s_pnlForm.Controls.Add(Me.s_txtRemarks)
        Me.s_pnlForm.Controls.Add(Me.s_btnSave)
        Me.s_pnlForm.Dock = System.Windows.Forms.DockStyle.Left
        Me.s_pnlForm.Location = New System.Drawing.Point(0, 0)
        Me.s_pnlForm.Name = "s_pnlForm"
        Me.s_pnlForm.Padding = New System.Windows.Forms.Padding(20)
        Me.s_pnlForm.Size = New System.Drawing.Size(350, 581)
        Me.s_pnlForm.TabIndex = 1
        '
        's_lblProduct
        '
        Me.s_lblProduct.AutoSize = True
        Me.s_lblProduct.Location = New System.Drawing.Point(20, 20)
        Me.s_lblProduct.Name = "s_lblProduct"
        Me.s_lblProduct.Size = New System.Drawing.Size(77, 13)
        Me.s_lblProduct.TabIndex = 0
        Me.s_lblProduct.Text = "Select Product"
        '
        's_cmbProduct
        '
        Me.s_cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.s_cmbProduct.Location = New System.Drawing.Point(20, 40)
        Me.s_cmbProduct.Name = "s_cmbProduct"
        Me.s_cmbProduct.Size = New System.Drawing.Size(300, 21)
        Me.s_cmbProduct.TabIndex = 1
        '
        's_lblType
        '
        Me.s_lblType.AutoSize = True
        Me.s_lblType.Location = New System.Drawing.Point(20, 80)
        Me.s_lblType.Name = "s_lblType"
        Me.s_lblType.Size = New System.Drawing.Size(90, 13)
        Me.s_lblType.TabIndex = 2
        Me.s_lblType.Text = "Transaction Type"
        '
        's_cmbType
        '
        Me.s_cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.s_cmbType.Items.AddRange(New Object() {"Restock", "Sale", "Damage", "Correction"})
        Me.s_cmbType.Location = New System.Drawing.Point(20, 100)
        Me.s_cmbType.Name = "s_cmbType"
        Me.s_cmbType.Size = New System.Drawing.Size(300, 21)
        Me.s_cmbType.TabIndex = 3
        '
        's_lblQuantity
        '
        Me.s_lblQuantity.AutoSize = True
        Me.s_lblQuantity.Location = New System.Drawing.Point(20, 140)
        Me.s_lblQuantity.Name = "s_lblQuantity"
        Me.s_lblQuantity.Size = New System.Drawing.Size(46, 13)
        Me.s_lblQuantity.TabIndex = 4
        Me.s_lblQuantity.Text = "Quantity"
        '
        's_numQuantity
        '
        Me.s_numQuantity.Location = New System.Drawing.Point(20, 160)
        Me.s_numQuantity.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.s_numQuantity.Name = "s_numQuantity"
        Me.s_numQuantity.Size = New System.Drawing.Size(120, 20)
        Me.s_numQuantity.TabIndex = 5
        '
        's_lblRemarks
        '
        Me.s_lblRemarks.AutoSize = True
        Me.s_lblRemarks.Location = New System.Drawing.Point(20, 200)
        Me.s_lblRemarks.Name = "s_lblRemarks"
        Me.s_lblRemarks.Size = New System.Drawing.Size(97, 13)
        Me.s_lblRemarks.TabIndex = 6
        Me.s_lblRemarks.Text = "Remarks (Optional)"
        '
        's_txtRemarks
        '
        Me.s_txtRemarks.Location = New System.Drawing.Point(20, 220)
        Me.s_txtRemarks.Multiline = True
        Me.s_txtRemarks.Name = "s_txtRemarks"
        Me.s_txtRemarks.Size = New System.Drawing.Size(300, 60)
        Me.s_txtRemarks.TabIndex = 7
        '
        's_btnSave
        '
        Me.s_btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.s_btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.s_btnSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.s_btnSave.ForeColor = System.Drawing.Color.White
        Me.s_btnSave.Location = New System.Drawing.Point(20, 300)
        Me.s_btnSave.Name = "s_btnSave"
        Me.s_btnSave.Size = New System.Drawing.Size(300, 40)
        Me.s_btnSave.TabIndex = 8
        Me.s_btnSave.Text = "Submit Transaction"
        Me.s_btnSave.UseVisualStyleBackColor = False
        '
        's_pnlEditForm
        '
        Me.s_pnlEditForm.BackColor = System.Drawing.Color.White
        Me.s_pnlEditForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.s_pnlEditForm.Controls.Add(Me.s_lblEditTransTitle)
        Me.s_pnlEditForm.Controls.Add(Me.s_lblEditProduct)
        Me.s_pnlEditForm.Controls.Add(Me.s_cmbEditProduct)
        Me.s_pnlEditForm.Controls.Add(Me.s_lblEditDate)
        Me.s_pnlEditForm.Controls.Add(Me.s_lblEditType)
        Me.s_pnlEditForm.Controls.Add(Me.s_cmbEditType)
        Me.s_pnlEditForm.Controls.Add(Me.s_lblEditQty)
        Me.s_pnlEditForm.Controls.Add(Me.s_numEditQuantity)
        Me.s_pnlEditForm.Controls.Add(Me.s_lblEditRemarks)
        Me.s_pnlEditForm.Controls.Add(Me.s_txtEditRemarks)
        Me.s_pnlEditForm.Controls.Add(Me.s_btnEditSave)
        Me.s_pnlEditForm.Controls.Add(Me.s_btnEditClose)
        Me.s_pnlEditForm.Dock = System.Windows.Forms.DockStyle.Right
        Me.s_pnlEditForm.Location = New System.Drawing.Point(1053, 50)
        Me.s_pnlEditForm.Name = "s_pnlEditForm"
        Me.s_pnlEditForm.Padding = New System.Windows.Forms.Padding(20)
        Me.s_pnlEditForm.Size = New System.Drawing.Size(300, 531)
        Me.s_pnlEditForm.TabIndex = 4
        Me.s_pnlEditForm.Visible = False
        '
        's_lblEditTransTitle
        '
        Me.s_lblEditTransTitle.AutoSize = True
        Me.s_lblEditTransTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.s_lblEditTransTitle.Location = New System.Drawing.Point(20, 20)
        Me.s_lblEditTransTitle.Name = "s_lblEditTransTitle"
        Me.s_lblEditTransTitle.Size = New System.Drawing.Size(130, 21)
        Me.s_lblEditTransTitle.TabIndex = 0
        Me.s_lblEditTransTitle.Text = "Edit Transaction"
        '
        's_lblEditProduct
        '
        Me.s_lblEditProduct.AutoSize = True
        Me.s_lblEditProduct.Location = New System.Drawing.Point(20, 50)
        Me.s_lblEditProduct.Name = "s_lblEditProduct"
        Me.s_lblEditProduct.Size = New System.Drawing.Size(44, 13)
        Me.s_lblEditProduct.TabIndex = 1
        Me.s_lblEditProduct.Text = "Product"
        '
        's_cmbEditProduct
        '
        Me.s_cmbEditProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.s_cmbEditProduct.Location = New System.Drawing.Point(20, 70)
        Me.s_cmbEditProduct.Name = "s_cmbEditProduct"
        Me.s_cmbEditProduct.Size = New System.Drawing.Size(260, 21)
        Me.s_cmbEditProduct.TabIndex = 2
        '
        's_lblEditDate
        '
        Me.s_lblEditDate.Location = New System.Drawing.Point(20, 100)
        Me.s_lblEditDate.Name = "s_lblEditDate"
        Me.s_lblEditDate.Size = New System.Drawing.Size(260, 20)
        Me.s_lblEditDate.TabIndex = 3
        Me.s_lblEditDate.Text = "Date:"
        '
        's_lblEditType
        '
        Me.s_lblEditType.AutoSize = True
        Me.s_lblEditType.Location = New System.Drawing.Point(20, 125)
        Me.s_lblEditType.Name = "s_lblEditType"
        Me.s_lblEditType.Size = New System.Drawing.Size(90, 13)
        Me.s_lblEditType.TabIndex = 4
        Me.s_lblEditType.Text = "Transaction Type"
        '
        's_cmbEditType
        '
        Me.s_cmbEditType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.s_cmbEditType.Items.AddRange(New Object() {"Restock", "Sale", "Damage", "Correction"})
        Me.s_cmbEditType.Location = New System.Drawing.Point(20, 145)
        Me.s_cmbEditType.Name = "s_cmbEditType"
        Me.s_cmbEditType.Size = New System.Drawing.Size(120, 21)
        Me.s_cmbEditType.TabIndex = 5
        '
        's_lblEditQty
        '
        Me.s_lblEditQty.AutoSize = True
        Me.s_lblEditQty.Location = New System.Drawing.Point(160, 125)
        Me.s_lblEditQty.Name = "s_lblEditQty"
        Me.s_lblEditQty.Size = New System.Drawing.Size(46, 13)
        Me.s_lblEditQty.TabIndex = 6
        '
        's_numEditQuantity
        '
        Me.s_numEditQuantity.Location = New System.Drawing.Point(160, 145)
        Me.s_numEditQuantity.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.s_numEditQuantity.Name = "s_numEditQuantity"
        Me.s_numEditQuantity.Size = New System.Drawing.Size(120, 20)
        Me.s_numEditQuantity.TabIndex = 7
        '
        's_lblEditRemarks
        '
        Me.s_lblEditRemarks.AutoSize = True
        Me.s_lblEditRemarks.Location = New System.Drawing.Point(20, 175)
        Me.s_lblEditRemarks.Name = "s_lblEditRemarks"
        Me.s_lblEditRemarks.Size = New System.Drawing.Size(49, 13)
        Me.s_lblEditRemarks.TabIndex = 8
        Me.s_lblEditRemarks.Text = "Remarks"
        '
        's_txtEditRemarks
        '
        Me.s_txtEditRemarks.Location = New System.Drawing.Point(20, 195)
        Me.s_txtEditRemarks.Multiline = True
        Me.s_txtEditRemarks.Name = "s_txtEditRemarks"
        Me.s_txtEditRemarks.Size = New System.Drawing.Size(260, 75)
        Me.s_txtEditRemarks.TabIndex = 9
        '
        's_btnEditSave
        '
        Me.s_btnEditSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.s_btnEditSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.s_btnEditSave.ForeColor = System.Drawing.Color.White
        Me.s_btnEditSave.Location = New System.Drawing.Point(20, 280)
        Me.s_btnEditSave.Name = "s_btnEditSave"
        Me.s_btnEditSave.Size = New System.Drawing.Size(260, 35)
        Me.s_btnEditSave.TabIndex = 3
        Me.s_btnEditSave.Text = "Save Remarks"
        Me.s_btnEditSave.UseVisualStyleBackColor = False
        '
        's_btnEditClose
        '
        Me.s_btnEditClose.BackColor = System.Drawing.Color.Gray
        Me.s_btnEditClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.s_btnEditClose.ForeColor = System.Drawing.Color.White
        Me.s_btnEditClose.Location = New System.Drawing.Point(20, 325)
        Me.s_btnEditClose.Name = "s_btnEditClose"
        Me.s_btnEditClose.Size = New System.Drawing.Size(260, 35)
        Me.s_btnEditClose.TabIndex = 4
        Me.s_btnEditClose.Text = "Close"
        Me.s_btnEditClose.UseVisualStyleBackColor = False
        '
        's_lblTitle
        '
        Me.s_lblTitle.AutoSize = True
        Me.s_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.s_lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.s_lblTitle.Name = "s_lblTitle"
        Me.s_lblTitle.Size = New System.Drawing.Size(204, 30)
        Me.s_lblTitle.TabIndex = 2
        Me.s_lblTitle.Text = "Stock Transactions"
        '
        's_pnlHeader
        '
        Me.s_pnlHeader.BackColor = System.Drawing.Color.White
        Me.s_pnlHeader.Controls.Add(Me.s_lblFilter)
        Me.s_pnlHeader.Controls.Add(Me.s_cmbQuickFilter)
        Me.s_pnlHeader.Controls.Add(Me.s_lblSearch)
        Me.s_pnlHeader.Controls.Add(Me.s_txtSearch)
        Me.s_pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.s_pnlHeader.Location = New System.Drawing.Point(350, 0)
        Me.s_pnlHeader.Name = "s_pnlHeader"
        Me.s_pnlHeader.Size = New System.Drawing.Size(1003, 50)
        Me.s_pnlHeader.TabIndex = 3
        '
        's_lblFilter
        '
        Me.s_lblFilter.AutoSize = True
        Me.s_lblFilter.Location = New System.Drawing.Point(20, 18)
        Me.s_lblFilter.Name = "s_lblFilter"
        Me.s_lblFilter.Size = New System.Drawing.Size(63, 13)
        Me.s_lblFilter.TabIndex = 0
        Me.s_lblFilter.Text = "Quick Filter:"
        '
        's_cmbQuickFilter
        '
        Me.s_cmbQuickFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.s_cmbQuickFilter.Items.AddRange(New Object() {"All", "Today", "This Week", "This Month", "Last 30 Days", "This Year"})
        Me.s_cmbQuickFilter.Location = New System.Drawing.Point(90, 15)
        Me.s_cmbQuickFilter.Name = "s_cmbQuickFilter"
        Me.s_cmbQuickFilter.Size = New System.Drawing.Size(121, 21)
        Me.s_cmbQuickFilter.TabIndex = 1
        '
        's_lblSearch
        '
        Me.s_lblSearch.AutoSize = True
        Me.s_lblSearch.Location = New System.Drawing.Point(230, 18)
        Me.s_lblSearch.Name = "s_lblSearch"
        Me.s_lblSearch.Size = New System.Drawing.Size(44, 13)
        Me.s_lblSearch.TabIndex = 2
        Me.s_lblSearch.Text = "Search:"
        '
        's_txtSearch
        '
        Me.s_txtSearch.Location = New System.Drawing.Point(280, 15)
        Me.s_txtSearch.Name = "s_txtSearch"
        Me.s_txtSearch.Size = New System.Drawing.Size(200, 20)
        Me.s_txtSearch.TabIndex = 2
        '
        'pnlManageServiceMain
        '
        Me.pnlManageServiceMain.Controls.Add(Me.sv_dgvServices)
        Me.pnlManageServiceMain.Controls.Add(Me.sv_pnlForm)
        Me.pnlManageServiceMain.Controls.Add(Me.sv_lblTitle)
        Me.pnlManageServiceMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlManageServiceMain.Location = New System.Drawing.Point(4, 22)
        Me.pnlManageServiceMain.Name = "pnlManageServiceMain"
        Me.pnlManageServiceMain.Size = New System.Drawing.Size(1353, 581)
        Me.pnlManageServiceMain.TabIndex = 7
        Me.pnlManageServiceMain.Text = "ManageService"
        Me.pnlManageServiceMain.Visible = False
        '
        'sv_dgvServices
        '
        Me.sv_dgvServices.AllowUserToAddRows = False
        Me.sv_dgvServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.sv_dgvServices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sv_colID, Me.sv_colType, Me.sv_colDesc, Me.sv_colFee, Me.sv_colActionEdit, Me.sv_colActionDelete})
        Me.sv_dgvServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sv_dgvServices.Location = New System.Drawing.Point(350, 0)
        Me.sv_dgvServices.Name = "sv_dgvServices"
        Me.sv_dgvServices.RowHeadersVisible = False
        Me.sv_dgvServices.Size = New System.Drawing.Size(1003, 581)
        Me.sv_dgvServices.TabIndex = 0
        '
        'sv_colID
        '
        Me.sv_colID.Name = "sv_colID"
        Me.sv_colID.Visible = False
        '
        'sv_colType
        '
        Me.sv_colType.HeaderText = "Type"
        Me.sv_colType.Name = "sv_colType"
        '
        'sv_colDesc
        '
        Me.sv_colDesc.HeaderText = "Description"
        Me.sv_colDesc.Name = "sv_colDesc"
        '
        'sv_colFee
        '
        Me.sv_colFee.HeaderText = "Fee"
        Me.sv_colFee.Name = "sv_colFee"
        '
        'sv_colActionEdit
        '
        Me.sv_colActionEdit.HeaderText = "Action"
        Me.sv_colActionEdit.Name = "sv_colActionEdit"
        Me.sv_colActionEdit.Text = "Edit"
        Me.sv_colActionEdit.UseColumnTextForButtonValue = True
        '
        'sv_colActionDelete
        '
        Me.sv_colActionDelete.HeaderText = "Action"
        Me.sv_colActionDelete.Name = "sv_colActionDelete"
        Me.sv_colActionDelete.Text = "Delete"
        Me.sv_colActionDelete.UseColumnTextForButtonValue = True
        '
        'sv_pnlForm
        '
        Me.sv_pnlForm.BackColor = System.Drawing.Color.White
        Me.sv_pnlForm.Controls.Add(Me.sv_lblType)
        Me.sv_pnlForm.Controls.Add(Me.sv_txtType)
        Me.sv_pnlForm.Controls.Add(Me.sv_lblDesc)
        Me.sv_pnlForm.Controls.Add(Me.sv_txtDesc)
        Me.sv_pnlForm.Controls.Add(Me.sv_lblFee)
        Me.sv_pnlForm.Controls.Add(Me.sv_numFee)
        Me.sv_pnlForm.Controls.Add(Me.sv_btnSave)
        Me.sv_pnlForm.Controls.Add(Me.sv_btnCancel)
        Me.sv_pnlForm.Dock = System.Windows.Forms.DockStyle.Left
        Me.sv_pnlForm.Location = New System.Drawing.Point(0, 0)
        Me.sv_pnlForm.Name = "sv_pnlForm"
        Me.sv_pnlForm.Padding = New System.Windows.Forms.Padding(20)
        Me.sv_pnlForm.Size = New System.Drawing.Size(350, 581)
        Me.sv_pnlForm.TabIndex = 1
        '
        'sv_lblType
        '
        Me.sv_lblType.Location = New System.Drawing.Point(20, 20)
        Me.sv_lblType.Name = "sv_lblType"
        Me.sv_lblType.Size = New System.Drawing.Size(100, 23)
        Me.sv_lblType.TabIndex = 0
        Me.sv_lblType.Text = "Service Type"
        '
        'sv_txtType
        '
        Me.sv_txtType.Location = New System.Drawing.Point(20, 40)
        Me.sv_txtType.Name = "sv_txtType"
        Me.sv_txtType.Size = New System.Drawing.Size(300, 20)
        Me.sv_txtType.TabIndex = 1
        '
        'sv_lblDesc
        '
        Me.sv_lblDesc.Location = New System.Drawing.Point(20, 80)
        Me.sv_lblDesc.Name = "sv_lblDesc"
        Me.sv_lblDesc.Size = New System.Drawing.Size(100, 23)
        Me.sv_lblDesc.TabIndex = 2
        Me.sv_lblDesc.Text = "Description"
        '
        'sv_txtDesc
        '
        Me.sv_txtDesc.Location = New System.Drawing.Point(20, 100)
        Me.sv_txtDesc.Multiline = True
        Me.sv_txtDesc.Name = "sv_txtDesc"
        Me.sv_txtDesc.Size = New System.Drawing.Size(300, 60)
        Me.sv_txtDesc.TabIndex = 3
        '
        'sv_lblFee
        '
        Me.sv_lblFee.Location = New System.Drawing.Point(20, 180)
        Me.sv_lblFee.Name = "sv_lblFee"
        Me.sv_lblFee.Size = New System.Drawing.Size(100, 23)
        Me.sv_lblFee.TabIndex = 4
        Me.sv_lblFee.Text = "Service Fee (₱)"
        '
        'sv_numFee
        '
        Me.sv_numFee.DecimalPlaces = 2
        Me.sv_numFee.Location = New System.Drawing.Point(20, 200)
        Me.sv_numFee.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.sv_numFee.Name = "sv_numFee"
        Me.sv_numFee.Size = New System.Drawing.Size(150, 20)
        Me.sv_numFee.TabIndex = 5
        '
        'sv_btnSave
        '
        Me.sv_btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.sv_btnSave.ForeColor = System.Drawing.Color.White
        Me.sv_btnSave.Location = New System.Drawing.Point(20, 250)
        Me.sv_btnSave.Name = "sv_btnSave"
        Me.sv_btnSave.Size = New System.Drawing.Size(145, 40)
        Me.sv_btnSave.TabIndex = 6
        Me.sv_btnSave.Text = "Save Service"
        Me.sv_btnSave.UseVisualStyleBackColor = False
        '
        'sv_btnCancel
        '
        Me.sv_btnCancel.BackColor = System.Drawing.Color.LightCoral
        Me.sv_btnCancel.ForeColor = System.Drawing.Color.White
        Me.sv_btnCancel.Location = New System.Drawing.Point(175, 250)
        Me.sv_btnCancel.Name = "sv_btnCancel"
        Me.sv_btnCancel.Size = New System.Drawing.Size(145, 40)
        Me.sv_btnCancel.TabIndex = 7
        Me.sv_btnCancel.Text = "Cancel"
        Me.sv_btnCancel.UseVisualStyleBackColor = False
        Me.sv_btnCancel.Visible = False
        '
        'sv_lblTitle
        '
        Me.sv_lblTitle.AutoSize = True
        Me.sv_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.sv_lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.sv_lblTitle.Name = "sv_lblTitle"
        Me.sv_lblTitle.Size = New System.Drawing.Size(188, 30)
        Me.sv_lblTitle.TabIndex = 2
        Me.sv_lblTitle.Text = "Manage Services"
        '
        'pnlAddServiceRequestMain
        '
        Me.pnlAddServiceRequestMain.Controls.Add(Me.sr_pnlForm)
        Me.pnlAddServiceRequestMain.Controls.Add(Me.sr_lblTitle)
        Me.pnlAddServiceRequestMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAddServiceRequestMain.Location = New System.Drawing.Point(4, 22)
        Me.pnlAddServiceRequestMain.Name = "pnlAddServiceRequestMain"
        Me.pnlAddServiceRequestMain.Size = New System.Drawing.Size(1353, 581)
        Me.pnlAddServiceRequestMain.TabIndex = 8
        Me.pnlAddServiceRequestMain.Text = "AddServiceRequest"
        Me.pnlAddServiceRequestMain.Visible = False
        '
        'sr_pnlForm
        '
        Me.sr_pnlForm.BackColor = System.Drawing.Color.White
        Me.sr_pnlForm.Controls.Add(Me.sr_lblSectionCustomer)
        Me.sr_pnlForm.Controls.Add(Me.sr_optExistingCust)
        Me.sr_pnlForm.Controls.Add(Me.sr_optNewCust)
        Me.sr_pnlForm.Controls.Add(Me.sr_lblCust)
        Me.sr_pnlForm.Controls.Add(Me.sr_cmbExistingCust)
        Me.sr_pnlForm.Controls.Add(Me.sr_txtCustName)
        Me.sr_pnlForm.Controls.Add(Me.sr_txtCustContact)
        Me.sr_pnlForm.Controls.Add(Me.sr_txtCustAddress)
        Me.sr_pnlForm.Controls.Add(Me.sr_lblSectionService)
        Me.sr_pnlForm.Controls.Add(Me.sr_lblService)
        Me.sr_pnlForm.Controls.Add(Me.sr_cmbService)
        Me.sr_pnlForm.Controls.Add(Me.sr_lblAddress)
        Me.sr_pnlForm.Controls.Add(Me.sr_txtAddress)
        Me.sr_pnlForm.Controls.Add(Me.sr_lblSectionStaff)
        Me.sr_pnlForm.Controls.Add(Me.sr_lblStaff)
        Me.sr_pnlForm.Controls.Add(Me.sr_cmbStaff)
        Me.sr_pnlForm.Controls.Add(Me.sr_lblTech)
        Me.sr_pnlForm.Controls.Add(Me.sr_cmbTech)
        Me.sr_pnlForm.Controls.Add(Me.sr_lblReqDate)
        Me.sr_pnlForm.Controls.Add(Me.sr_dtpRequest)
        Me.sr_pnlForm.Controls.Add(Me.sr_lblScheduled)
        Me.sr_pnlForm.Controls.Add(Me.sr_dtpScheduled)
        Me.sr_pnlForm.Controls.Add(Me.sr_lblStatus)
        Me.sr_pnlForm.Controls.Add(Me.sr_cmbStatus)
        Me.sr_pnlForm.Controls.Add(Me.sr_btnSave)
        Me.sr_pnlForm.Controls.Add(Me.sr_btnCancel)
        Me.sr_pnlForm.Location = New System.Drawing.Point(20, 70)
        Me.sr_pnlForm.Name = "sr_pnlForm"
        Me.sr_pnlForm.Size = New System.Drawing.Size(650, 780)
        Me.sr_pnlForm.TabIndex = 0
        '
        'sr_lblSectionCustomer
        '
        Me.sr_lblSectionCustomer.AutoSize = True
        Me.sr_lblSectionCustomer.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.sr_lblSectionCustomer.Location = New System.Drawing.Point(20, 20)
        Me.sr_lblSectionCustomer.Name = "sr_lblSectionCustomer"
        Me.sr_lblSectionCustomer.Size = New System.Drawing.Size(158, 21)
        Me.sr_lblSectionCustomer.TabIndex = 0
        Me.sr_lblSectionCustomer.Text = "Customer Selection"
        '
        'sr_optExistingCust
        '
        Me.sr_optExistingCust.AutoSize = True
        Me.sr_optExistingCust.Checked = True
        Me.sr_optExistingCust.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.sr_optExistingCust.Location = New System.Drawing.Point(170, 50)
        Me.sr_optExistingCust.Name = "sr_optExistingCust"
        Me.sr_optExistingCust.Size = New System.Drawing.Size(146, 23)
        Me.sr_optExistingCust.TabIndex = 1
        Me.sr_optExistingCust.TabStop = True
        Me.sr_optExistingCust.Text = "Existing Customer"
        '
        'sr_optNewCust
        '
        Me.sr_optNewCust.AutoSize = True
        Me.sr_optNewCust.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.sr_optNewCust.Location = New System.Drawing.Point(20, 50)
        Me.sr_optNewCust.Name = "sr_optNewCust"
        Me.sr_optNewCust.Size = New System.Drawing.Size(125, 23)
        Me.sr_optNewCust.TabIndex = 2
        Me.sr_optNewCust.Text = "New Customer"
        '
        'sr_lblCust
        '
        Me.sr_lblCust.AutoSize = True
        Me.sr_lblCust.Location = New System.Drawing.Point(20, 80)
        Me.sr_lblCust.Name = "sr_lblCust"
        Me.sr_lblCust.Size = New System.Drawing.Size(130, 13)
        Me.sr_lblCust.TabIndex = 3
        Me.sr_lblCust.Text = "Search Existing Customer:"
        '
        'sr_cmbExistingCust
        '
        Me.sr_cmbExistingCust.Location = New System.Drawing.Point(20, 100)
        Me.sr_cmbExistingCust.Name = "sr_cmbExistingCust"
        Me.sr_cmbExistingCust.Size = New System.Drawing.Size(400, 21)
        Me.sr_cmbExistingCust.TabIndex = 4
        '
        'sr_txtCustName
        '
        Me.sr_txtCustName.Location = New System.Drawing.Point(20, 100)
        Me.sr_txtCustName.Name = "sr_txtCustName"
        Me.sr_txtCustName.Size = New System.Drawing.Size(190, 20)
        Me.sr_txtCustName.TabIndex = 5
        Me.sr_txtCustName.Text = "Name..."
        Me.sr_txtCustName.Visible = False
        '
        'sr_txtCustContact
        '
        Me.sr_txtCustContact.Location = New System.Drawing.Point(230, 100)
        Me.sr_txtCustContact.Name = "sr_txtCustContact"
        Me.sr_txtCustContact.Size = New System.Drawing.Size(190, 20)
        Me.sr_txtCustContact.TabIndex = 6
        Me.sr_txtCustContact.Text = "Contact..."
        Me.sr_txtCustContact.Visible = False
        '
        'sr_txtCustAddress
        '
        Me.sr_txtCustAddress.Location = New System.Drawing.Point(20, 130)
        Me.sr_txtCustAddress.Name = "sr_txtCustAddress"
        Me.sr_txtCustAddress.Size = New System.Drawing.Size(400, 20)
        Me.sr_txtCustAddress.TabIndex = 7
        Me.sr_txtCustAddress.Text = "Customer Home Address..."
        Me.sr_txtCustAddress.Visible = False
        '
        'sr_lblSectionService
        '
        Me.sr_lblSectionService.AutoSize = True
        Me.sr_lblSectionService.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.sr_lblSectionService.Location = New System.Drawing.Point(20, 260)
        Me.sr_lblSectionService.Name = "sr_lblSectionService"
        Me.sr_lblSectionService.Size = New System.Drawing.Size(123, 21)
        Me.sr_lblSectionService.TabIndex = 8
        Me.sr_lblSectionService.Text = "Service Details"
        '
        'sr_lblService
        '
        Me.sr_lblService.AutoSize = True
        Me.sr_lblService.Location = New System.Drawing.Point(20, 290)
        Me.sr_lblService.Name = "sr_lblService"
        Me.sr_lblService.Size = New System.Drawing.Size(77, 13)
        Me.sr_lblService.TabIndex = 9
        Me.sr_lblService.Text = "Service Target"
        '
        'sr_cmbService
        '
        Me.sr_cmbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sr_cmbService.Location = New System.Drawing.Point(20, 310)
        Me.sr_cmbService.Name = "sr_cmbService"
        Me.sr_cmbService.Size = New System.Drawing.Size(400, 21)
        Me.sr_cmbService.TabIndex = 10
        '
        'sr_lblAddress
        '
        Me.sr_lblAddress.AutoSize = True
        Me.sr_lblAddress.Location = New System.Drawing.Point(20, 340)
        Me.sr_lblAddress.Name = "sr_lblAddress"
        Me.sr_lblAddress.Size = New System.Drawing.Size(79, 13)
        Me.sr_lblAddress.TabIndex = 11
        Me.sr_lblAddress.Text = "Repair Address"
        '
        'sr_txtAddress
        '
        Me.sr_txtAddress.Location = New System.Drawing.Point(20, 360)
        Me.sr_txtAddress.Multiline = True
        Me.sr_txtAddress.Name = "sr_txtAddress"
        Me.sr_txtAddress.Size = New System.Drawing.Size(400, 60)
        Me.sr_txtAddress.TabIndex = 12
        '
        'sr_lblSectionStaff
        '
        Me.sr_lblSectionStaff.AutoSize = True
        Me.sr_lblSectionStaff.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.sr_lblSectionStaff.Location = New System.Drawing.Point(20, 440)
        Me.sr_lblSectionStaff.Name = "sr_lblSectionStaff"
        Me.sr_lblSectionStaff.Size = New System.Drawing.Size(136, 21)
        Me.sr_lblSectionStaff.TabIndex = 13
        Me.sr_lblSectionStaff.Text = "Scheduling Staff"
        '
        'sr_lblStaff
        '
        Me.sr_lblStaff.AutoSize = True
        Me.sr_lblStaff.Location = New System.Drawing.Point(20, 470)
        Me.sr_lblStaff.Name = "sr_lblStaff"
        Me.sr_lblStaff.Size = New System.Drawing.Size(120, 13)
        Me.sr_lblStaff.TabIndex = 14
        Me.sr_lblStaff.Text = "Assign Staff Coordinator"
        '
        'sr_cmbStaff
        '
        Me.sr_cmbStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sr_cmbStaff.Location = New System.Drawing.Point(20, 490)
        Me.sr_cmbStaff.Name = "sr_cmbStaff"
        Me.sr_cmbStaff.Size = New System.Drawing.Size(400, 21)
        Me.sr_cmbStaff.TabIndex = 15
        '
        'sr_lblTech
        '
        Me.sr_lblTech.AutoSize = True
        Me.sr_lblTech.Location = New System.Drawing.Point(20, 520)
        Me.sr_lblTech.Name = "sr_lblTech"
        Me.sr_lblTech.Size = New System.Drawing.Size(94, 13)
        Me.sr_lblTech.TabIndex = 16
        Me.sr_lblTech.Text = "Assign Technician"
        '
        'sr_cmbTech
        '
        Me.sr_cmbTech.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sr_cmbTech.Location = New System.Drawing.Point(20, 540)
        Me.sr_cmbTech.Name = "sr_cmbTech"
        Me.sr_cmbTech.Size = New System.Drawing.Size(400, 21)
        Me.sr_cmbTech.TabIndex = 17
        '
        'sr_lblReqDate
        '
        Me.sr_lblReqDate.AutoSize = True
        Me.sr_lblReqDate.Location = New System.Drawing.Point(20, 570)
        Me.sr_lblReqDate.Name = "sr_lblReqDate"
        Me.sr_lblReqDate.Size = New System.Drawing.Size(73, 13)
        Me.sr_lblReqDate.TabIndex = 18
        Me.sr_lblReqDate.Text = "Request Date"
        '
        'sr_dtpRequest
        '
        Me.sr_dtpRequest.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.sr_dtpRequest.Location = New System.Drawing.Point(20, 590)
        Me.sr_dtpRequest.Name = "sr_dtpRequest"
        Me.sr_dtpRequest.Size = New System.Drawing.Size(190, 20)
        Me.sr_dtpRequest.TabIndex = 19
        '
        'sr_lblScheduled
        '
        Me.sr_lblScheduled.AutoSize = True
        Me.sr_lblScheduled.Location = New System.Drawing.Point(230, 570)
        Me.sr_lblScheduled.Name = "sr_lblScheduled"
        Me.sr_lblScheduled.Size = New System.Drawing.Size(84, 13)
        Me.sr_lblScheduled.TabIndex = 20
        Me.sr_lblScheduled.Text = "Scheduled Date"
        '
        'sr_dtpScheduled
        '
        Me.sr_dtpScheduled.Checked = False
        Me.sr_dtpScheduled.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.sr_dtpScheduled.Location = New System.Drawing.Point(230, 590)
        Me.sr_dtpScheduled.Name = "sr_dtpScheduled"
        Me.sr_dtpScheduled.ShowCheckBox = True
        Me.sr_dtpScheduled.Size = New System.Drawing.Size(190, 20)
        Me.sr_dtpScheduled.TabIndex = 21
        '
        'sr_lblStatus
        '
        Me.sr_lblStatus.AutoSize = True
        Me.sr_lblStatus.Location = New System.Drawing.Point(20, 620)
        Me.sr_lblStatus.Name = "sr_lblStatus"
        Me.sr_lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.sr_lblStatus.TabIndex = 22
        Me.sr_lblStatus.Text = "Status"
        '
        'sr_cmbStatus
        '
        Me.sr_cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sr_cmbStatus.Items.AddRange(New Object() {"Pending", "Scheduled", "In Progress", "Completed", "Cancelled"})
        Me.sr_cmbStatus.Location = New System.Drawing.Point(20, 640)
        Me.sr_cmbStatus.Name = "sr_cmbStatus"
        Me.sr_cmbStatus.Size = New System.Drawing.Size(400, 21)
        Me.sr_cmbStatus.TabIndex = 23
        '
        'sr_btnSave
        '
        Me.sr_btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.sr_btnSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.sr_btnSave.ForeColor = System.Drawing.Color.White
        Me.sr_btnSave.Location = New System.Drawing.Point(20, 690)
        Me.sr_btnSave.Name = "sr_btnSave"
        Me.sr_btnSave.Size = New System.Drawing.Size(180, 40)
        Me.sr_btnSave.TabIndex = 24
        Me.sr_btnSave.Text = "Save Request"
        Me.sr_btnSave.UseVisualStyleBackColor = False
        '
        'sr_btnCancel
        '
        Me.sr_btnCancel.BackColor = System.Drawing.Color.White
        Me.sr_btnCancel.ForeColor = System.Drawing.Color.Black
        Me.sr_btnCancel.Location = New System.Drawing.Point(210, 690)
        Me.sr_btnCancel.Name = "sr_btnCancel"
        Me.sr_btnCancel.Size = New System.Drawing.Size(180, 40)
        Me.sr_btnCancel.TabIndex = 25
        Me.sr_btnCancel.Text = "Cancel"
        Me.sr_btnCancel.UseVisualStyleBackColor = False
        '
        'sr_lblTitle
        '
        Me.sr_lblTitle.AutoSize = True
        Me.sr_lblTitle.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.sr_lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.sr_lblTitle.Name = "sr_lblTitle"
        Me.sr_lblTitle.Size = New System.Drawing.Size(376, 37)
        Me.sr_lblTitle.TabIndex = 1
        Me.sr_lblTitle.Text = "Create New Service Request"
        '
        'pnlViewServiceRequestsMain
        '
        Me.pnlViewServiceRequestsMain.Controls.Add(Me.vr_dgvRequests)
        Me.pnlViewServiceRequestsMain.Controls.Add(Me.vr_pnlDetail)
        Me.pnlViewServiceRequestsMain.Controls.Add(Me.vr_pnlFilter)
        Me.pnlViewServiceRequestsMain.Controls.Add(Me.vr_lblTitle)
        Me.pnlViewServiceRequestsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlViewServiceRequestsMain.Location = New System.Drawing.Point(4, 22)
        Me.pnlViewServiceRequestsMain.Name = "pnlViewServiceRequestsMain"
        Me.pnlViewServiceRequestsMain.Size = New System.Drawing.Size(1353, 581)
        Me.pnlViewServiceRequestsMain.TabIndex = 9
        Me.pnlViewServiceRequestsMain.Text = "ViewServiceRequests"
        Me.pnlViewServiceRequestsMain.Visible = False
        '
        'vr_dgvRequests
        '
        Me.vr_dgvRequests.AllowUserToAddRows = False
        Me.vr_dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.vr_dgvRequests.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.vr_colReqID, Me.vr_colCust, Me.vr_colService, Me.vr_colStaff, Me.vr_colTech, Me.vr_colDate, Me.vr_colSched, Me.vr_colStatus, Me.vr_colActionUpdate, Me.vr_colActionDelete})
        Me.vr_dgvRequests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vr_dgvRequests.Location = New System.Drawing.Point(0, 50)
        Me.vr_dgvRequests.Name = "vr_dgvRequests"
        Me.vr_dgvRequests.RowHeadersVisible = False
        Me.vr_dgvRequests.Size = New System.Drawing.Size(1353, 531)
        Me.vr_dgvRequests.TabIndex = 0
        '
        'vr_colReqID
        '
        Me.vr_colReqID.HeaderText = "Req ID"
        Me.vr_colReqID.Name = "vr_colReqID"
        '
        'vr_colCust
        '
        Me.vr_colCust.HeaderText = "Customer"
        Me.vr_colCust.Name = "vr_colCust"
        '
        'vr_colService
        '
        Me.vr_colService.HeaderText = "Service"
        Me.vr_colService.Name = "vr_colService"
        '
        'vr_colStaff
        '
        Me.vr_colStaff.HeaderText = "Staff"
        Me.vr_colStaff.Name = "vr_colStaff"
        '
        'vr_colTech
        '
        Me.vr_colTech.HeaderText = "Tech"
        Me.vr_colTech.Name = "vr_colTech"
        '
        'vr_colDate
        '
        Me.vr_colDate.HeaderText = "Date Filed"
        Me.vr_colDate.Name = "vr_colDate"
        '
        'vr_colSched
        '
        Me.vr_colSched.HeaderText = "Scheduled"
        Me.vr_colSched.Name = "vr_colSched"
        '
        'vr_colStatus
        '
        Me.vr_colStatus.HeaderText = "Status"
        Me.vr_colStatus.Name = "vr_colStatus"
        '
        'vr_colActionUpdate
        '
        Me.vr_colActionUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.vr_colActionUpdate.HeaderText = "Action"
        Me.vr_colActionUpdate.Name = "vr_colActionUpdate"
        Me.vr_colActionUpdate.Text = "Update"
        Me.vr_colActionUpdate.UseColumnTextForButtonValue = True
        '
        'vr_colActionDelete
        '
        Me.vr_colActionDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.vr_colActionDelete.HeaderText = "Delete"
        Me.vr_colActionDelete.Name = "vr_colActionDelete"
        Me.vr_colActionDelete.Text = "Delete"
        Me.vr_colActionDelete.UseColumnTextForButtonValue = True
        '
        'vr_pnlFilter
        '
        Me.vr_pnlFilter.Controls.Add(Me.vr_lblSearch)
        Me.vr_pnlFilter.Controls.Add(Me.vr_txtSearch)
        Me.vr_pnlFilter.Controls.Add(Me.vr_cmbFilterStatus)
        Me.vr_pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.vr_pnlFilter.Location = New System.Drawing.Point(0, 0)
        Me.vr_pnlFilter.Name = "vr_pnlFilter"
        Me.vr_pnlFilter.Padding = New System.Windows.Forms.Padding(10)
        Me.vr_pnlFilter.Size = New System.Drawing.Size(1353, 50)
        Me.vr_pnlFilter.TabIndex = 1
        '
        'vr_txtSearch
        '
        Me.vr_lblSearch.AutoSize = True
        Me.vr_lblSearch.Location = New System.Drawing.Point(20, 18)
        Me.vr_lblSearch.Name = "vr_lblSearch"
        Me.vr_lblSearch.TabIndex = 2
        Me.vr_lblSearch.Text = "Search:"
        '
        'vr_txtSearch
        '
        Me.vr_txtSearch.Location = New System.Drawing.Point(70, 15)
        Me.vr_txtSearch.Name = "vr_txtSearch"
        Me.vr_txtSearch.Size = New System.Drawing.Size(250, 20)
        Me.vr_txtSearch.TabIndex = 0
        Me.vr_txtSearch.Text = "Search by Customer Name..."
        '
        'vr_cmbFilterStatus
        '
        Me.vr_cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.vr_cmbFilterStatus.Items.AddRange(New Object() {"All", "Pending", "Scheduled", "In Progress", "Completed", "Cancelled"})
        Me.vr_cmbFilterStatus.Location = New System.Drawing.Point(340, 15)
        Me.vr_cmbFilterStatus.Name = "vr_cmbFilterStatus"
        Me.vr_cmbFilterStatus.Size = New System.Drawing.Size(200, 21)
        Me.vr_cmbFilterStatus.TabIndex = 1
        '
        'vr_pnlDetail
        '
        Me.vr_pnlDetail.BackColor = System.Drawing.Color.White
        Me.vr_pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vr_pnlDetail.Controls.Add(Me.vr_lblDetailTitle)
        Me.vr_pnlDetail.Controls.Add(Me.vr_lblDetailCustHdr)
        Me.vr_pnlDetail.Controls.Add(Me.vr_txtDetailCust)
        Me.vr_pnlDetail.Controls.Add(Me.vr_lblDetailDate)
        Me.vr_pnlDetail.Controls.Add(Me.vr_lblDetailServiceHdr)
        Me.vr_pnlDetail.Controls.Add(Me.vr_cmbDetailService)
        Me.vr_pnlDetail.Controls.Add(Me.vr_lblDetailStaffHdr)
        Me.vr_pnlDetail.Controls.Add(Me.vr_cmbDetailStaff)
        Me.vr_pnlDetail.Controls.Add(Me.vr_lblDetailTechHdr)
        Me.vr_pnlDetail.Controls.Add(Me.vr_cmbDetailTech)
        Me.vr_pnlDetail.Controls.Add(Me.vr_lblDetailAddrHdr)
        Me.vr_pnlDetail.Controls.Add(Me.vr_txtDetailAddress)
        Me.vr_pnlDetail.Controls.Add(Me.vr_lblDetailSchedHdr)
        Me.vr_pnlDetail.Controls.Add(Me.vr_dtpDetailSched)
        Me.vr_pnlDetail.Controls.Add(Me.vr_lblDetailStatusHdr)
        Me.vr_pnlDetail.Controls.Add(Me.vr_cmbDetailStatus)
        Me.vr_pnlDetail.Controls.Add(Me.vr_btnDetailUpdate)
        Me.vr_pnlDetail.Controls.Add(Me.vr_btnDetailClose)
        Me.vr_pnlDetail.Dock = System.Windows.Forms.DockStyle.Right
        Me.vr_pnlDetail.Name = "vr_pnlDetail"
        Me.vr_pnlDetail.Padding = New System.Windows.Forms.Padding(20)
        Me.vr_pnlDetail.Size = New System.Drawing.Size(350, 581)
        Me.vr_pnlDetail.TabIndex = 10
        Me.vr_pnlDetail.Visible = False
        '
        'vr_lblDetailTitle
        '
        Me.vr_lblDetailTitle.AutoSize = True
        Me.vr_lblDetailTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.vr_lblDetailTitle.Location = New System.Drawing.Point(20, 20)
        Me.vr_lblDetailTitle.Name = "vr_lblDetailTitle"
        Me.vr_lblDetailTitle.TabIndex = 0
        Me.vr_lblDetailTitle.Text = "Request Details"
        '
        'vr_lblDetailCustHdr
        '
        Me.vr_lblDetailCustHdr.AutoSize = True
        Me.vr_lblDetailCustHdr.Location = New System.Drawing.Point(20, 55)
        Me.vr_lblDetailCustHdr.Name = "vr_lblDetailCustHdr"
        Me.vr_lblDetailCustHdr.TabIndex = 1
        Me.vr_lblDetailCustHdr.Text = "Customer Name:"
        '
        'vr_txtDetailCust
        '
        Me.vr_txtDetailCust.Location = New System.Drawing.Point(20, 72)
        Me.vr_txtDetailCust.Name = "vr_txtDetailCust"
        Me.vr_txtDetailCust.Size = New System.Drawing.Size(310, 20)
        Me.vr_txtDetailCust.TabIndex = 2
        '
        'vr_lblDetailDate
        '
        Me.vr_lblDetailDate.Location = New System.Drawing.Point(20, 98)
        Me.vr_lblDetailDate.Name = "vr_lblDetailDate"
        Me.vr_lblDetailDate.Size = New System.Drawing.Size(310, 20)
        Me.vr_lblDetailDate.TabIndex = 3
        '
        'vr_lblDetailServiceHdr
        '
        Me.vr_lblDetailServiceHdr.AutoSize = True
        Me.vr_lblDetailServiceHdr.Location = New System.Drawing.Point(20, 125)
        Me.vr_lblDetailServiceHdr.Name = "vr_lblDetailServiceHdr"
        Me.vr_lblDetailServiceHdr.TabIndex = 4
        Me.vr_lblDetailServiceHdr.Text = "Service:"
        '
        'vr_cmbDetailService
        '
        Me.vr_cmbDetailService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.vr_cmbDetailService.Location = New System.Drawing.Point(20, 142)
        Me.vr_cmbDetailService.Name = "vr_cmbDetailService"
        Me.vr_cmbDetailService.Size = New System.Drawing.Size(310, 21)
        Me.vr_cmbDetailService.TabIndex = 5
        '
        'vr_lblDetailStaffHdr
        '
        Me.vr_lblDetailStaffHdr.AutoSize = True
        Me.vr_lblDetailStaffHdr.Location = New System.Drawing.Point(20, 172)
        Me.vr_lblDetailStaffHdr.Name = "vr_lblDetailStaffHdr"
        Me.vr_lblDetailStaffHdr.TabIndex = 6
        Me.vr_lblDetailStaffHdr.Text = "Staff Coordinator:"
        '
        'vr_cmbDetailStaff
        '
        Me.vr_cmbDetailStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.vr_cmbDetailStaff.Location = New System.Drawing.Point(20, 189)
        Me.vr_cmbDetailStaff.Name = "vr_cmbDetailStaff"
        Me.vr_cmbDetailStaff.Size = New System.Drawing.Size(310, 21)
        Me.vr_cmbDetailStaff.TabIndex = 7
        '
        'vr_lblDetailTechHdr
        '
        Me.vr_lblDetailTechHdr.AutoSize = True
        Me.vr_lblDetailTechHdr.Location = New System.Drawing.Point(20, 219)
        Me.vr_lblDetailTechHdr.Name = "vr_lblDetailTechHdr"
        Me.vr_lblDetailTechHdr.TabIndex = 8
        Me.vr_lblDetailTechHdr.Text = "Technician:"
        '
        'vr_cmbDetailTech
        '
        Me.vr_cmbDetailTech.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.vr_cmbDetailTech.Location = New System.Drawing.Point(20, 236)
        Me.vr_cmbDetailTech.Name = "vr_cmbDetailTech"
        Me.vr_cmbDetailTech.Size = New System.Drawing.Size(310, 21)
        Me.vr_cmbDetailTech.TabIndex = 9
        '
        'vr_lblDetailAddrHdr
        '
        Me.vr_lblDetailAddrHdr.AutoSize = True
        Me.vr_lblDetailAddrHdr.Location = New System.Drawing.Point(20, 266)
        Me.vr_lblDetailAddrHdr.Name = "vr_lblDetailAddrHdr"
        Me.vr_lblDetailAddrHdr.TabIndex = 10
        Me.vr_lblDetailAddrHdr.Text = "Service Address:"
        '
        'vr_txtDetailAddress
        '
        Me.vr_txtDetailAddress.Location = New System.Drawing.Point(20, 283)
        Me.vr_txtDetailAddress.Multiline = True
        Me.vr_txtDetailAddress.Name = "vr_txtDetailAddress"
        Me.vr_txtDetailAddress.Size = New System.Drawing.Size(310, 45)
        Me.vr_txtDetailAddress.TabIndex = 11
        '
        'vr_lblDetailSchedHdr
        '
        Me.vr_lblDetailSchedHdr.AutoSize = True
        Me.vr_lblDetailSchedHdr.Location = New System.Drawing.Point(20, 337)
        Me.vr_lblDetailSchedHdr.Name = "vr_lblDetailSchedHdr"
        Me.vr_lblDetailSchedHdr.TabIndex = 12
        Me.vr_lblDetailSchedHdr.Text = "Scheduled Date:"
        '
        'vr_dtpDetailSched
        '
        Me.vr_dtpDetailSched.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.vr_dtpDetailSched.Location = New System.Drawing.Point(20, 354)
        Me.vr_dtpDetailSched.Name = "vr_dtpDetailSched"
        Me.vr_dtpDetailSched.ShowCheckBox = True
        Me.vr_dtpDetailSched.Size = New System.Drawing.Size(200, 20)
        Me.vr_dtpDetailSched.TabIndex = 13
        '
        'vr_lblDetailStatusHdr
        '
        Me.vr_lblDetailStatusHdr.AutoSize = True
        Me.vr_lblDetailStatusHdr.Location = New System.Drawing.Point(20, 384)
        Me.vr_lblDetailStatusHdr.Name = "vr_lblDetailStatusHdr"
        Me.vr_lblDetailStatusHdr.TabIndex = 14
        Me.vr_lblDetailStatusHdr.Text = "Status:"
        '
        'vr_cmbDetailStatus
        '
        Me.vr_cmbDetailStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.vr_cmbDetailStatus.Items.AddRange(New Object() {"Pending", "Scheduled", "In Progress", "Completed", "Cancelled"})
        Me.vr_cmbDetailStatus.Location = New System.Drawing.Point(20, 401)
        Me.vr_cmbDetailStatus.Name = "vr_cmbDetailStatus"
        Me.vr_cmbDetailStatus.Size = New System.Drawing.Size(200, 21)
        Me.vr_cmbDetailStatus.TabIndex = 15
        '
        'vr_btnDetailUpdate
        '
        Me.vr_btnDetailUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.vr_btnDetailUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.vr_btnDetailUpdate.ForeColor = System.Drawing.Color.White
        Me.vr_btnDetailUpdate.Location = New System.Drawing.Point(20, 435)
        Me.vr_btnDetailUpdate.Name = "vr_btnDetailUpdate"
        Me.vr_btnDetailUpdate.Size = New System.Drawing.Size(310, 35)
        Me.vr_btnDetailUpdate.TabIndex = 16
        Me.vr_btnDetailUpdate.Text = "Save Changes"
        Me.vr_btnDetailUpdate.UseVisualStyleBackColor = False
        '
        'vr_btnDetailClose
        '
        Me.vr_btnDetailClose.BackColor = System.Drawing.Color.Gray
        Me.vr_btnDetailClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.vr_btnDetailClose.ForeColor = System.Drawing.Color.White
        Me.vr_btnDetailClose.Location = New System.Drawing.Point(20, 480)
        Me.vr_btnDetailClose.Name = "vr_btnDetailClose"
        Me.vr_btnDetailClose.Size = New System.Drawing.Size(310, 35)
        Me.vr_btnDetailClose.TabIndex = 17
        Me.vr_btnDetailClose.Text = "Close"
        Me.vr_btnDetailClose.UseVisualStyleBackColor = False
        '
        'vr_lblTitle
        '
        Me.vr_lblTitle.AutoSize = True
        Me.vr_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.vr_lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.vr_lblTitle.Name = "vr_lblTitle"
        Me.vr_lblTitle.Size = New System.Drawing.Size(244, 30)
        Me.vr_lblTitle.TabIndex = 2
        Me.vr_lblTitle.Text = "View Service Requests"
        '
        'pnlViewWarrantyMain
        '
        Me.pnlViewWarrantyMain.Controls.Add(Me.wr_dgvWarranties)
        Me.pnlViewWarrantyMain.Controls.Add(Me.wr_pnlFilter)
        Me.pnlViewWarrantyMain.Controls.Add(Me.wr_lblTitle)
        Me.pnlViewWarrantyMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlViewWarrantyMain.Location = New System.Drawing.Point(4, 22)
        Me.pnlViewWarrantyMain.Name = "pnlViewWarrantyMain"
        Me.pnlViewWarrantyMain.Size = New System.Drawing.Size(1353, 581)
        Me.pnlViewWarrantyMain.TabIndex = 10
        Me.pnlViewWarrantyMain.Text = "ViewWarranty"
        Me.pnlViewWarrantyMain.Visible = False
        '
        'wr_dgvWarranties
        '
        Me.wr_dgvWarranties.AllowUserToAddRows = False
        Me.wr_dgvWarranties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.wr_dgvWarranties.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.wr_colID, Me.wr_colCust, Me.wr_colProd, Me.wr_colStart, Me.wr_colEnd, Me.wr_colStatus, Me.wr_colActionEdit, Me.wr_colActionDelete})
        Me.wr_dgvWarranties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wr_dgvWarranties.Location = New System.Drawing.Point(0, 50)
        Me.wr_dgvWarranties.Name = "wr_dgvWarranties"
        Me.wr_dgvWarranties.RowHeadersVisible = False
        Me.wr_dgvWarranties.Size = New System.Drawing.Size(1353, 531)
        Me.wr_dgvWarranties.TabIndex = 0
        '
        'wr_colID
        '
        Me.wr_colID.Name = "wr_colID"
        Me.wr_colID.Visible = False
        '
        'wr_colCust
        '
        Me.wr_colCust.HeaderText = "Customer Name"
        Me.wr_colCust.Name = "wr_colCust"
        '
        'wr_colProd
        '
        Me.wr_colProd.HeaderText = "Product Name"
        Me.wr_colProd.Name = "wr_colProd"
        '
        'wr_colStart
        '
        Me.wr_colStart.HeaderText = "Start Date"
        Me.wr_colStart.Name = "wr_colStart"
        '
        'wr_colEnd
        '
        Me.wr_colEnd.HeaderText = "End Date"
        Me.wr_colEnd.Name = "wr_colEnd"
        '
        'wr_colStatus
        '
        Me.wr_colStatus.HeaderText = "Status"
        Me.wr_colStatus.Name = "wr_colStatus"
        '
        'wr_colActionEdit
        '
        Me.wr_colActionEdit.HeaderText = "Update"
        Me.wr_colActionEdit.Name = "wr_colActionEdit"
        Me.wr_colActionEdit.Text = "Update"
        Me.wr_colActionEdit.UseColumnTextForButtonValue = True
        '
        'wr_colActionDelete
        '
        Me.wr_colActionDelete.HeaderText = "Delete"
        Me.wr_colActionDelete.Name = "wr_colActionDelete"
        Me.wr_colActionDelete.Text = "Delete"
        Me.wr_colActionDelete.UseColumnTextForButtonValue = True
        '
        'wr_pnlFilter
        '
        Me.wr_pnlFilter.Controls.Add(Me.wr_txtSearch)
        Me.wr_pnlFilter.Controls.Add(Me.wr_cmbFilterStatus)
        Me.wr_pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.wr_pnlFilter.Location = New System.Drawing.Point(0, 0)
        Me.wr_pnlFilter.Name = "wr_pnlFilter"
        Me.wr_pnlFilter.Padding = New System.Windows.Forms.Padding(10)
        Me.wr_pnlFilter.Size = New System.Drawing.Size(1353, 50)
        Me.wr_pnlFilter.TabIndex = 1
        '
        'wr_txtSearch
        '
        Me.wr_txtSearch.Location = New System.Drawing.Point(20, 15)
        Me.wr_txtSearch.Name = "wr_txtSearch"
        Me.wr_txtSearch.Size = New System.Drawing.Size(300, 20)
        Me.wr_txtSearch.TabIndex = 0
        Me.wr_txtSearch.Text = "Search by Customer or Product..."
        '
        'wr_cmbFilterStatus
        '
        Me.wr_cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.wr_cmbFilterStatus.Items.AddRange(New Object() {"All", "Active", "Expired"})
        Me.wr_cmbFilterStatus.Location = New System.Drawing.Point(340, 15)
        Me.wr_cmbFilterStatus.Name = "wr_cmbFilterStatus"
        Me.wr_cmbFilterStatus.Size = New System.Drawing.Size(200, 21)
        Me.wr_cmbFilterStatus.TabIndex = 1
        '
        'wr_lblTitle
        '
        Me.wr_lblTitle.AutoSize = True
        Me.wr_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.wr_lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.wr_lblTitle.Name = "wr_lblTitle"
        Me.wr_lblTitle.Size = New System.Drawing.Size(167, 30)
        Me.wr_lblTitle.TabIndex = 2
        Me.wr_lblTitle.Text = "View Warranty"
        '
        'pnlFileClaimMain
        '
        Me.pnlFileClaimMain.Controls.Add(Me.fc_pnlForm)
        Me.pnlFileClaimMain.Controls.Add(Me.fc_lblTitle)
        Me.pnlFileClaimMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFileClaimMain.Location = New System.Drawing.Point(4, 22)
        Me.pnlFileClaimMain.Name = "pnlFileClaimMain"
        Me.pnlFileClaimMain.Size = New System.Drawing.Size(1353, 581)
        Me.pnlFileClaimMain.TabIndex = 11
        Me.pnlFileClaimMain.Text = "FileClaim"
        Me.pnlFileClaimMain.Visible = False
        '
        'fc_pnlForm
        '
        Me.fc_pnlForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.fc_pnlForm.Controls.Add(Me.fc_lblCust)
        Me.fc_pnlForm.Controls.Add(Me.fc_cmbCustomer)
        Me.fc_pnlForm.Controls.Add(Me.fc_lblProd)
        Me.fc_pnlForm.Controls.Add(Me.fc_cmbProduct)
        Me.fc_pnlForm.Controls.Add(Me.fc_lblStart)
        Me.fc_pnlForm.Controls.Add(Me.fc_txtStart)
        Me.fc_pnlForm.Controls.Add(Me.fc_lblEnd)
        Me.fc_pnlForm.Controls.Add(Me.fc_txtEnd)
        Me.fc_pnlForm.Controls.Add(Me.fc_lblStatus)
        Me.fc_pnlForm.Controls.Add(Me.fc_txtStatus)
        Me.fc_pnlForm.Controls.Add(Me.fc_lblIssue)
        Me.fc_pnlForm.Controls.Add(Me.fc_txtIssue)
        Me.fc_pnlForm.Controls.Add(Me.fc_btnSubmit)
        Me.fc_pnlForm.Location = New System.Drawing.Point(20, 56)
        Me.fc_pnlForm.Name = "fc_pnlForm"
        Me.fc_pnlForm.Size = New System.Drawing.Size(760, 470)
        Me.fc_pnlForm.TabIndex = 0
        '
        'fc_lblCust
        '
        Me.fc_lblCust.AutoSize = True
        Me.fc_lblCust.Location = New System.Drawing.Point(20, 20)
        Me.fc_lblCust.Name = "fc_lblCust"
        Me.fc_lblCust.Size = New System.Drawing.Size(98, 13)
        Me.fc_lblCust.TabIndex = 0
        Me.fc_lblCust.Text = "Customer Selection"
        '
        'fc_cmbCustomer
        '
        Me.fc_cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fc_cmbCustomer.Location = New System.Drawing.Point(20, 42)
        Me.fc_cmbCustomer.Name = "fc_cmbCustomer"
        Me.fc_cmbCustomer.Size = New System.Drawing.Size(620, 21)
        Me.fc_cmbCustomer.TabIndex = 1
        '
        'fc_lblProd
        '
        Me.fc_lblProd.AutoSize = True
        Me.fc_lblProd.Location = New System.Drawing.Point(20, 82)
        Me.fc_lblProd.Name = "fc_lblProd"
        Me.fc_lblProd.Size = New System.Drawing.Size(91, 13)
        Me.fc_lblProd.TabIndex = 2
        Me.fc_lblProd.Text = "Product Selection"
        '
        'fc_cmbProduct
        '
        Me.fc_cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fc_cmbProduct.Location = New System.Drawing.Point(20, 104)
        Me.fc_cmbProduct.Name = "fc_cmbProduct"
        Me.fc_cmbProduct.Size = New System.Drawing.Size(620, 21)
        Me.fc_cmbProduct.TabIndex = 3
        '
        'fc_lblStart
        '
        Me.fc_lblStart.AutoSize = True
        Me.fc_lblStart.Location = New System.Drawing.Point(20, 148)
        Me.fc_lblStart.Name = "fc_lblStart"
        Me.fc_lblStart.Size = New System.Drawing.Size(101, 13)
        Me.fc_lblStart.TabIndex = 6
        Me.fc_lblStart.Text = "Warranty Start Date"
        '
        'fc_txtStart
        '
        Me.fc_txtStart.Location = New System.Drawing.Point(20, 170)
        Me.fc_txtStart.Name = "fc_txtStart"
        Me.fc_txtStart.ReadOnly = True
        Me.fc_txtStart.Size = New System.Drawing.Size(290, 20)
        Me.fc_txtStart.TabIndex = 7
        '
        'fc_lblEnd
        '
        Me.fc_lblEnd.AutoSize = True
        Me.fc_lblEnd.Location = New System.Drawing.Point(340, 148)
        Me.fc_lblEnd.Name = "fc_lblEnd"
        Me.fc_lblEnd.Size = New System.Drawing.Size(98, 13)
        Me.fc_lblEnd.TabIndex = 8
        Me.fc_lblEnd.Text = "Warranty End Date"
        '
        'fc_txtEnd
        '
        Me.fc_txtEnd.Location = New System.Drawing.Point(340, 170)
        Me.fc_txtEnd.Name = "fc_txtEnd"
        Me.fc_txtEnd.ReadOnly = True
        Me.fc_txtEnd.Size = New System.Drawing.Size(300, 20)
        Me.fc_txtEnd.TabIndex = 9
        '
        'fc_lblStatus
        '
        Me.fc_lblStatus.AutoSize = True
        Me.fc_lblStatus.Location = New System.Drawing.Point(20, 210)
        Me.fc_lblStatus.Name = "fc_lblStatus"
        Me.fc_lblStatus.Size = New System.Drawing.Size(83, 13)
        Me.fc_lblStatus.TabIndex = 10
        Me.fc_lblStatus.Text = "Warranty Status"
        '
        'fc_txtStatus
        '
        Me.fc_txtStatus.Location = New System.Drawing.Point(20, 232)
        Me.fc_txtStatus.Name = "fc_txtStatus"
        Me.fc_txtStatus.ReadOnly = True
        Me.fc_txtStatus.Size = New System.Drawing.Size(290, 20)
        Me.fc_txtStatus.TabIndex = 11
        '
        'fc_lblIssue
        '
        Me.fc_lblIssue.AutoSize = True
        Me.fc_lblIssue.Location = New System.Drawing.Point(20, 272)
        Me.fc_lblIssue.Name = "fc_lblIssue"
        Me.fc_lblIssue.Size = New System.Drawing.Size(88, 13)
        Me.fc_lblIssue.TabIndex = 12
        Me.fc_lblIssue.Text = "Issue Description"
        '
        'fc_txtIssue
        '
        Me.fc_txtIssue.Location = New System.Drawing.Point(20, 294)
        Me.fc_txtIssue.Multiline = True
        Me.fc_txtIssue.Name = "fc_txtIssue"
        Me.fc_txtIssue.Size = New System.Drawing.Size(620, 108)
        Me.fc_txtIssue.TabIndex = 13
        '
        'fc_btnSubmit
        '
        Me.fc_btnSubmit.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.fc_btnSubmit.ForeColor = System.Drawing.Color.White
        Me.fc_btnSubmit.Location = New System.Drawing.Point(20, 414)
        Me.fc_btnSubmit.Name = "fc_btnSubmit"
        Me.fc_btnSubmit.Size = New System.Drawing.Size(200, 40)
        Me.fc_btnSubmit.TabIndex = 14
        Me.fc_btnSubmit.Text = "Submit Claim"
        Me.fc_btnSubmit.UseVisualStyleBackColor = False
        '
        'fc_lblTitle
        '
        Me.fc_lblTitle.AutoSize = True
        Me.fc_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.fc_lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.fc_lblTitle.Name = "fc_lblTitle"
        Me.fc_lblTitle.Size = New System.Drawing.Size(215, 30)
        Me.fc_lblTitle.TabIndex = 1
        Me.fc_lblTitle.Text = "File Warranty Claim"
        '
        'tpStaffMain
        '
        Me.tpStaffMain.Location = New System.Drawing.Point(4, 22)
        Me.tpStaffMain.Name = "tpStaffMain"
        Me.tpStaffMain.Size = New System.Drawing.Size(1353, 581)
        Me.tpStaffMain.TabIndex = 12
        Me.tpStaffMain.Text = "Add Staff"
        Me.tpStaffMain.Controls.Add(Me.pre_st_lblTitle)
        Me.tpStaffMain.Controls.Add(Me.pre_st_pnlForm)
        '
        'pre_st_lblTitle
        '
        Me.pre_st_lblTitle.AutoSize = True
        Me.pre_st_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.pre_st_lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.pre_st_lblTitle.Name = "pre_st_lblTitle"
        Me.pre_st_lblTitle.Size = New System.Drawing.Size(307, 30)
        Me.pre_st_lblTitle.TabIndex = 0
        Me.pre_st_lblTitle.Text = "Add New Staff / Technician"
        '
        'pre_st_pnlForm
        '
        Me.pre_st_pnlForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pre_st_pnlForm.Controls.Add(Me.pre_st_lblHint)
        Me.pre_st_pnlForm.Location = New System.Drawing.Point(20, 55)
        Me.pre_st_pnlForm.Name = "pre_st_pnlForm"
        Me.pre_st_pnlForm.Size = New System.Drawing.Size(780, 470)
        Me.pre_st_pnlForm.TabIndex = 1
        '
        'pre_st_lblHint
        '
        Me.pre_st_lblHint.AutoSize = True
        Me.pre_st_lblHint.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.pre_st_lblHint.Location = New System.Drawing.Point(20, 20)
        Me.pre_st_lblHint.Name = "pre_st_lblHint"
        Me.pre_st_lblHint.Size = New System.Drawing.Size(431, 19)
        Me.pre_st_lblHint.TabIndex = 0
        Me.pre_st_lblHint.Text = "Design preview area for Add Staff form (runtime fields load automatically)."
        '
        'tpSupplierMain
        '
        Me.tpSupplierMain.Location = New System.Drawing.Point(4, 22)
        Me.tpSupplierMain.Name = "tpSupplierMain"
        Me.tpSupplierMain.Size = New System.Drawing.Size(1353, 581)
        Me.tpSupplierMain.TabIndex = 13
        Me.tpSupplierMain.Text = "Manage Supplier"
        Me.tpSupplierMain.Controls.Add(Me.pre_sup_lblTitle)
        Me.tpSupplierMain.Controls.Add(Me.pre_sup_pnlForm)
        Me.tpSupplierMain.Controls.Add(Me.pre_sup_grid)
        '
        'pre_sup_lblTitle
        '
        Me.pre_sup_lblTitle.AutoSize = True
        Me.pre_sup_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.pre_sup_lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.pre_sup_lblTitle.Name = "pre_sup_lblTitle"
        Me.pre_sup_lblTitle.Size = New System.Drawing.Size(188, 30)
        Me.pre_sup_lblTitle.TabIndex = 0
        Me.pre_sup_lblTitle.Text = "Manage Supplier"
        '
        'pre_sup_pnlForm
        '
        Me.pre_sup_pnlForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pre_sup_pnlForm.Location = New System.Drawing.Point(20, 55)
        Me.pre_sup_pnlForm.Name = "pre_sup_pnlForm"
        Me.pre_sup_pnlForm.Size = New System.Drawing.Size(820, 140)
        Me.pre_sup_pnlForm.TabIndex = 1
        '
        'pre_sup_grid
        '
        Me.pre_sup_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.pre_sup_grid.Location = New System.Drawing.Point(20, 245)
        Me.pre_sup_grid.Name = "pre_sup_grid"
        Me.pre_sup_grid.Size = New System.Drawing.Size(820, 290)
        Me.pre_sup_grid.TabIndex = 2
        '
        'tpReportMain
        '
        Me.tpReportMain.Location = New System.Drawing.Point(4, 22)
        Me.tpReportMain.Name = "tpReportMain"
        Me.tpReportMain.Size = New System.Drawing.Size(1353, 581)
        Me.tpReportMain.TabIndex = 14
        Me.tpReportMain.Text = "Sales Report"
        Me.tpReportMain.Controls.Add(Me.pre_rpt_lblTitle)
        Me.tpReportMain.Controls.Add(Me.pre_rpt_cmbFilter)
        Me.tpReportMain.Controls.Add(Me.pre_rpt_lblAmount)
        Me.tpReportMain.Controls.Add(Me.pre_rpt_grid)
        '
        'pre_rpt_lblTitle
        '
        Me.pre_rpt_lblTitle.AutoSize = True
        Me.pre_rpt_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.pre_rpt_lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.pre_rpt_lblTitle.Name = "pre_rpt_lblTitle"
        Me.pre_rpt_lblTitle.Size = New System.Drawing.Size(129, 30)
        Me.pre_rpt_lblTitle.TabIndex = 0
        Me.pre_rpt_lblTitle.Text = "Sales Report"
        '
        'pre_rpt_cmbFilter
        '
        Me.pre_rpt_cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.pre_rpt_cmbFilter.FormattingEnabled = True
        Me.pre_rpt_cmbFilter.Items.AddRange(New Object() {"Today", "This Week", "This Month", "Last 30 Days", "This Year", "All"})
        Me.pre_rpt_cmbFilter.Location = New System.Drawing.Point(275, 60)
        Me.pre_rpt_cmbFilter.Name = "pre_rpt_cmbFilter"
        Me.pre_rpt_cmbFilter.Size = New System.Drawing.Size(170, 21)
        Me.pre_rpt_cmbFilter.TabIndex = 1
        '
        'pre_rpt_lblAmount
        '
        Me.pre_rpt_lblAmount.AutoSize = True
        Me.pre_rpt_lblAmount.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.pre_rpt_lblAmount.Location = New System.Drawing.Point(470, 60)
        Me.pre_rpt_lblAmount.Name = "pre_rpt_lblAmount"
        Me.pre_rpt_lblAmount.Size = New System.Drawing.Size(111, 20)
        Me.pre_rpt_lblAmount.TabIndex = 2
        Me.pre_rpt_lblAmount.Text = "Total: 0.00"
        '
        'pre_rpt_grid
        '
        Me.pre_rpt_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.pre_rpt_grid.Location = New System.Drawing.Point(20, 125)
        Me.pre_rpt_grid.Name = "pre_rpt_grid"
        Me.pre_rpt_grid.Size = New System.Drawing.Size(820, 410)
        Me.pre_rpt_grid.TabIndex = 3
        '
        'tpViewWarrantyClaimMain
        '
        Me.tpViewWarrantyClaimMain.Location = New System.Drawing.Point(4, 22)
        Me.tpViewWarrantyClaimMain.Name = "tpViewWarrantyClaimMain"
        Me.tpViewWarrantyClaimMain.Size = New System.Drawing.Size(1353, 581)
        Me.tpViewWarrantyClaimMain.TabIndex = 15
        Me.tpViewWarrantyClaimMain.Text = "Manage Staff"
        Me.tpViewWarrantyClaimMain.Controls.Add(Me.pre_ms_lblTitle)
        Me.tpViewWarrantyClaimMain.Controls.Add(Me.pre_ms_txtSearch)
        Me.tpViewWarrantyClaimMain.Controls.Add(Me.pre_ms_grid)
        '
        'pre_ms_lblTitle
        '
        Me.pre_ms_lblTitle.AutoSize = True
        Me.pre_ms_lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.pre_ms_lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.pre_ms_lblTitle.Name = "pre_ms_lblTitle"
        Me.pre_ms_lblTitle.Size = New System.Drawing.Size(247, 30)
        Me.pre_ms_lblTitle.TabIndex = 0
        Me.pre_ms_lblTitle.Text = "Manage Staff Technician"
        '
        'pre_ms_txtSearch
        '
        Me.pre_ms_txtSearch.Location = New System.Drawing.Point(20, 58)
        Me.pre_ms_txtSearch.Name = "pre_ms_txtSearch"
        Me.pre_ms_txtSearch.Size = New System.Drawing.Size(320, 20)
        Me.pre_ms_txtSearch.TabIndex = 1
        Me.pre_ms_txtSearch.Text = "Search by name or contact..."
        '
        'pre_ms_grid
        '
        Me.pre_ms_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.pre_ms_grid.Location = New System.Drawing.Point(20, 90)
        Me.pre_ms_grid.Name = "pre_ms_grid"
        Me.pre_ms_grid.Size = New System.Drawing.Size(820, 440)
        Me.pre_ms_grid.TabIndex = 2
        '
        'Childform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1361, 607)
        Me.Controls.Add(Me.tcMain)
        Me.Name = "Childform"
        Me.Text = "Midea Pro Shop"
        Me.tcMain.ResumeLayout(False)
        Me.pnlDashboardMain.ResumeLayout(False)
        Me.flpCards.ResumeLayout(False)
        Me.pnlCard1.ResumeLayout(False)
        Me.pnlCard2.ResumeLayout(False)
        Me.pnlCard3.ResumeLayout(False)
        Me.pnlCard4.ResumeLayout(False)
        Me.pnlOrderMain.ResumeLayout(False)
        Me.o_pnlCheckoutForm.ResumeLayout(False)
        Me.o_pnlCheckoutForm.PerformLayout()
        Me.o_pnlNewCustomer.ResumeLayout(False)
        Me.o_pnlNewCustomer.PerformLayout()
        CType(Me.o_dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.o_pnlCart.ResumeLayout(False)
        Me.o_pnlTotal.ResumeLayout(False)
        Me.o_pnlTotal.PerformLayout()
        Me.pnlViewOrdersMain.ResumeLayout(False)
        CType(Me.v_dgvOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.v_pnlHeader.ResumeLayout(False)
        Me.v_pnlHeader.PerformLayout()
        Me.pnlAddProductMain.ResumeLayout(False)
        Me.pnlAddProductMain.PerformLayout()
        Me.a_pnlForm.ResumeLayout(False)
        Me.a_pnlForm.PerformLayout()
        CType(Me.a_numPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.a_numStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.a_numReorder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.a_pnlNewSupplier.ResumeLayout(False)
        Me.a_pnlNewSupplier.PerformLayout()
        Me.pnlManageProductsMain.ResumeLayout(False)
        Me.m_pnlEditProduct.ResumeLayout(False)
        Me.m_pnlEditProduct.PerformLayout()
        CType(Me.m_numEditPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_numEditStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_numEditReorder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLowStockMain.ResumeLayout(False)
        CType(Me.l_dgvAlerts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.l_pnlHeader.ResumeLayout(False)
        Me.l_pnlHeader.PerformLayout()
        Me.pnlStockTransactionMain.ResumeLayout(False)
        Me.pnlStockTransactionMain.PerformLayout()
        CType(Me.s_dgvHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.s_pnlForm.ResumeLayout(False)
        Me.s_pnlForm.PerformLayout()
        CType(Me.s_numQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlManageServiceMain.ResumeLayout(False)
        Me.pnlManageServiceMain.PerformLayout()
        CType(Me.sv_dgvServices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sv_pnlForm.ResumeLayout(False)
        Me.sv_pnlForm.PerformLayout()
        CType(Me.sv_numFee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAddServiceRequestMain.ResumeLayout(False)
        Me.pnlAddServiceRequestMain.PerformLayout()
        Me.sr_pnlForm.ResumeLayout(False)
        Me.sr_pnlForm.PerformLayout()
        Me.pnlViewServiceRequestsMain.ResumeLayout(False)
        Me.pnlViewServiceRequestsMain.PerformLayout()
        CType(Me.vr_dgvRequests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.vr_pnlFilter.ResumeLayout(False)
        Me.vr_pnlFilter.PerformLayout()
        Me.pnlViewWarrantyMain.ResumeLayout(False)
        Me.pnlViewWarrantyMain.PerformLayout()
        CType(Me.wr_dgvWarranties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.wr_pnlFilter.ResumeLayout(False)
        Me.wr_pnlFilter.PerformLayout()
        Me.pnlFileClaimMain.ResumeLayout(False)
        Me.pnlFileClaimMain.PerformLayout()
        Me.fc_pnlForm.ResumeLayout(False)
        Me.fc_pnlForm.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    ' Variables
    Friend WithEvents pnlDashboardMain As System.Windows.Forms.TabPage
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

    Friend WithEvents pnlOrderMain As System.Windows.Forms.TabPage
    Friend WithEvents o_pnlCategories As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents o_dgvProducts As System.Windows.Forms.DataGridView
    Friend WithEvents o_colProductID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents o_colProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents o_colBrand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents o_colDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents o_colPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents o_colStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents o_colActionAdd As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents o_colActionRemove As System.Windows.Forms.DataGridViewButtonColumn
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
    Friend WithEvents o_lblAssignStaff As System.Windows.Forms.Label
    Friend WithEvents o_cmbAssignStaff As System.Windows.Forms.ComboBox
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

    Friend WithEvents pnlViewOrdersMain As System.Windows.Forms.TabPage
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
    Friend WithEvents v_colStaff As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents v_colProducts As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents v_colTotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents v_colActionEdit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents v_colActionDelete As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents v_colActionPrint As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents v_lblSearch As System.Windows.Forms.Label
    Friend WithEvents v_txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents v_pnlDetailForm As System.Windows.Forms.Panel
    Friend WithEvents v_lblDetailTitle As System.Windows.Forms.Label
    Friend WithEvents v_lblDetailReceipt As System.Windows.Forms.Label
    Friend WithEvents v_lblDetailCustomer As System.Windows.Forms.Label
    Friend WithEvents v_lblDetailStaff As System.Windows.Forms.Label
    Friend WithEvents v_lblDetailDate As System.Windows.Forms.Label
    Friend WithEvents v_lblDetailProducts As System.Windows.Forms.Label
    Friend WithEvents v_lblDetailTotal As System.Windows.Forms.Label
    Friend WithEvents v_btnDetailEdit As System.Windows.Forms.Button
    Friend WithEvents v_btnDetailClose As System.Windows.Forms.Button

    Friend WithEvents pnlAddProductMain As System.Windows.Forms.TabPage
    Friend WithEvents a_lblTitle As System.Windows.Forms.Label
    Friend WithEvents a_pnlForm As System.Windows.Forms.Panel
    Friend WithEvents a_btnSave As System.Windows.Forms.Button
    Friend WithEvents a_btnCancel As System.Windows.Forms.Button
    Friend WithEvents a_lblProdName As System.Windows.Forms.Label
    Friend WithEvents a_txtProdName As System.Windows.Forms.TextBox
    Friend WithEvents a_lblProdBrand As System.Windows.Forms.Label
    Friend WithEvents a_cmbBrand As System.Windows.Forms.ComboBox
    Friend WithEvents a_chkNewBrand As System.Windows.Forms.CheckBox
    Friend WithEvents a_txtNewBrand As System.Windows.Forms.TextBox
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

    Friend WithEvents pnlManageProductsMain As System.Windows.Forms.TabPage
    Friend WithEvents m_pnlCategories As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents m_dgvProducts As System.Windows.Forms.DataGridView
    Friend WithEvents m_colProductID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents m_colProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents m_colBrand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents m_colDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents m_colPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents m_colStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents m_colReorder As System.Windows.Forms.DataGridViewTextBoxColumn
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

    Friend WithEvents pnlLowStockMain As System.Windows.Forms.TabPage
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

    Friend WithEvents pnlStockTransactionMain As System.Windows.Forms.TabPage
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
    Friend WithEvents s_pnlEditForm As System.Windows.Forms.Panel
    Friend WithEvents s_lblEditTransTitle As System.Windows.Forms.Label
    Friend WithEvents s_lblEditProduct As System.Windows.Forms.Label
    Friend WithEvents s_cmbEditProduct As System.Windows.Forms.ComboBox
    Friend WithEvents s_lblEditDate As System.Windows.Forms.Label
    Friend WithEvents s_lblEditType As System.Windows.Forms.Label
    Friend WithEvents s_cmbEditType As System.Windows.Forms.ComboBox
    Friend WithEvents s_lblEditQty As System.Windows.Forms.Label
    Friend WithEvents s_numEditQuantity As System.Windows.Forms.NumericUpDown
    Friend WithEvents s_lblEditRemarks As System.Windows.Forms.Label
    Friend WithEvents s_txtEditRemarks As System.Windows.Forms.TextBox
    Friend WithEvents s_btnEditSave As System.Windows.Forms.Button
    Friend WithEvents s_btnEditClose As System.Windows.Forms.Button
    Friend WithEvents s_pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents s_lblFilter As System.Windows.Forms.Label
    Friend WithEvents s_cmbQuickFilter As System.Windows.Forms.ComboBox
    Friend WithEvents s_lblSearch As System.Windows.Forms.Label
    Friend WithEvents s_txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents s_dgvHistory As System.Windows.Forms.DataGridView
    Friend WithEvents s_colTransID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_colProduct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_colType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_colQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_colDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_colRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents s_colActionEdit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents s_colActionDelete As System.Windows.Forms.DataGridViewButtonColumn

    Friend WithEvents pnlManageServiceMain As System.Windows.Forms.TabPage
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

    Friend WithEvents pnlAddServiceRequestMain As System.Windows.Forms.TabPage
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

    Friend WithEvents pnlViewServiceRequestsMain As System.Windows.Forms.TabPage
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
    Friend WithEvents vr_colActionDelete As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents vr_lblSearch As System.Windows.Forms.Label
    Friend WithEvents vr_pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents vr_lblDetailTitle As System.Windows.Forms.Label
    Friend WithEvents vr_lblDetailCustHdr As System.Windows.Forms.Label
    Friend WithEvents vr_txtDetailCust As System.Windows.Forms.TextBox
    Friend WithEvents vr_lblDetailDate As System.Windows.Forms.Label
    Friend WithEvents vr_lblDetailServiceHdr As System.Windows.Forms.Label
    Friend WithEvents vr_cmbDetailService As System.Windows.Forms.ComboBox
    Friend WithEvents vr_lblDetailStaffHdr As System.Windows.Forms.Label
    Friend WithEvents vr_cmbDetailStaff As System.Windows.Forms.ComboBox
    Friend WithEvents vr_lblDetailTechHdr As System.Windows.Forms.Label
    Friend WithEvents vr_cmbDetailTech As System.Windows.Forms.ComboBox
    Friend WithEvents vr_lblDetailAddrHdr As System.Windows.Forms.Label
    Friend WithEvents vr_txtDetailAddress As System.Windows.Forms.TextBox
    Friend WithEvents vr_lblDetailSchedHdr As System.Windows.Forms.Label
    Friend WithEvents vr_dtpDetailSched As System.Windows.Forms.DateTimePicker
    Friend WithEvents vr_lblDetailStatusHdr As System.Windows.Forms.Label
    Friend WithEvents vr_cmbDetailStatus As System.Windows.Forms.ComboBox
    Friend WithEvents vr_btnDetailUpdate As System.Windows.Forms.Button
    Friend WithEvents vr_btnDetailClose As System.Windows.Forms.Button
    Friend WithEvents pnlViewWarrantyMain As System.Windows.Forms.TabPage
    Friend WithEvents wr_lblTitle As System.Windows.Forms.Label
    Friend WithEvents wr_pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents wr_txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents wr_cmbFilterStatus As System.Windows.Forms.ComboBox
    Friend WithEvents wr_dgvWarranties As System.Windows.Forms.DataGridView
    Friend WithEvents wr_colCust As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wr_colProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wr_colStart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wr_colEnd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wr_colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wr_colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wr_colActionEdit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents wr_colActionDelete As System.Windows.Forms.DataGridViewButtonColumn

    Friend WithEvents pnlFileClaimMain As System.Windows.Forms.TabPage
    Friend WithEvents fc_lblTitle As System.Windows.Forms.Label
    Friend WithEvents fc_pnlForm As System.Windows.Forms.Panel
    Friend WithEvents fc_lblCust As System.Windows.Forms.Label
    Friend WithEvents fc_cmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents fc_lblProd As System.Windows.Forms.Label
    Friend WithEvents fc_cmbProduct As System.Windows.Forms.ComboBox
    Friend WithEvents fc_lblStart As System.Windows.Forms.Label
    Friend WithEvents fc_txtStart As System.Windows.Forms.TextBox
    Friend WithEvents fc_lblEnd As System.Windows.Forms.Label
    Friend WithEvents fc_txtEnd As System.Windows.Forms.TextBox
    Friend WithEvents fc_lblStatus As System.Windows.Forms.Label
    Friend WithEvents fc_txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents fc_lblIssue As System.Windows.Forms.Label
    Friend WithEvents fc_txtIssue As System.Windows.Forms.TextBox
    Friend WithEvents fc_btnSubmit As System.Windows.Forms.Button

        Friend WithEvents tpStaffMain As System.Windows.Forms.TabPage
    Friend WithEvents tpSupplierMain As System.Windows.Forms.TabPage
    Friend WithEvents tpReportMain As System.Windows.Forms.TabPage
    Friend WithEvents tpViewWarrantyClaimMain As System.Windows.Forms.TabPage
    Friend WithEvents pre_st_lblTitle As System.Windows.Forms.Label
    Friend WithEvents pre_st_pnlForm As System.Windows.Forms.Panel
    Friend WithEvents pre_st_lblHint As System.Windows.Forms.Label
    Friend WithEvents pre_ms_lblTitle As System.Windows.Forms.Label
    Friend WithEvents pre_ms_txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents pre_ms_grid As System.Windows.Forms.DataGridView
    Friend WithEvents pre_sup_lblTitle As System.Windows.Forms.Label
    Friend WithEvents pre_sup_pnlForm As System.Windows.Forms.Panel
    Friend WithEvents pre_sup_grid As System.Windows.Forms.DataGridView
    Friend WithEvents pre_rpt_lblTitle As System.Windows.Forms.Label
    Friend WithEvents pre_rpt_cmbFilter As System.Windows.Forms.ComboBox
    Friend WithEvents pre_rpt_lblAmount As System.Windows.Forms.Label
    Friend WithEvents pre_rpt_grid As System.Windows.Forms.DataGridView
    Friend WithEvents tcMain As System.Windows.Forms.TabControl
End Class






