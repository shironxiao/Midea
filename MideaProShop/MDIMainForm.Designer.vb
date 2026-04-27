<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIMainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DashboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewPurchaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageProductsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventoryToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LowStockAlertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StocTransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewServiceRequestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewServiceRequestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageServiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignTechnicianToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WarrantyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewWarrantyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileWarrantyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SatffAndTechnicianToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewStaffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageStaffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaleReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventoryReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServiceReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WarrantyReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageSupplierToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewWarrantyClaimToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DashboardToolStripMenuItem, Me.SaleToolStripMenuItem, Me.InventoryToolStripMenuItem, Me.InventoryToolStripMenuItem1, Me.ServiceToolStripMenuItem, Me.WarrantyToolStripMenuItem, Me.SatffAndTechnicianToolStripMenuItem, Me.ReportToolStripMenuItem, Me.SupplierToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DashboardToolStripMenuItem
        '
        Me.DashboardToolStripMenuItem.Name = "DashboardToolStripMenuItem"
        Me.DashboardToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
        Me.DashboardToolStripMenuItem.Text = "Dashboard"
        '
        'SaleToolStripMenuItem
        '
        Me.SaleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewPurchaseToolStripMenuItem, Me.ViewOrdersToolStripMenuItem})
        Me.SaleToolStripMenuItem.Name = "SaleToolStripMenuItem"
        Me.SaleToolStripMenuItem.Size = New System.Drawing.Size(96, 20)
        Me.SaleToolStripMenuItem.Text = "Sale and Order"
        '
        'AddNewPurchaseToolStripMenuItem
        '
        Me.AddNewPurchaseToolStripMenuItem.Name = "AddNewPurchaseToolStripMenuItem"
        Me.AddNewPurchaseToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AddNewPurchaseToolStripMenuItem.Text = "Add New Order"
        '
        'ViewOrdersToolStripMenuItem
        '
        Me.ViewOrdersToolStripMenuItem.Name = "ViewOrdersToolStripMenuItem"
        Me.ViewOrdersToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ViewOrdersToolStripMenuItem.Text = "View Orders"
        '
        'InventoryToolStripMenuItem
        '
        Me.InventoryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewProductToolStripMenuItem, Me.ManageProductsToolStripMenuItem})
        Me.InventoryToolStripMenuItem.Name = "InventoryToolStripMenuItem"
        Me.InventoryToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.InventoryToolStripMenuItem.Text = "Product"
        '
        'AddNewProductToolStripMenuItem
        '
        Me.AddNewProductToolStripMenuItem.Name = "AddNewProductToolStripMenuItem"
        Me.AddNewProductToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.AddNewProductToolStripMenuItem.Text = "Add New Product"
        '
        'ManageProductsToolStripMenuItem
        '
        Me.ManageProductsToolStripMenuItem.Name = "ManageProductsToolStripMenuItem"
        Me.ManageProductsToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ManageProductsToolStripMenuItem.Text = "Manage Products"
        '
        'InventoryToolStripMenuItem1
        '
        Me.InventoryToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LowStockAlertToolStripMenuItem, Me.StocTransactionToolStripMenuItem})
        Me.InventoryToolStripMenuItem1.Name = "InventoryToolStripMenuItem1"
        Me.InventoryToolStripMenuItem1.Size = New System.Drawing.Size(69, 20)
        Me.InventoryToolStripMenuItem1.Text = "Inventory"
        '
        'LowStockAlertToolStripMenuItem
        '
        Me.LowStockAlertToolStripMenuItem.Name = "LowStockAlertToolStripMenuItem"
        Me.LowStockAlertToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LowStockAlertToolStripMenuItem.Text = "Low Stock Alerts"
        '
        'StocTransactionToolStripMenuItem
        '
        Me.StocTransactionToolStripMenuItem.Name = "StocTransactionToolStripMenuItem"
        Me.StocTransactionToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.StocTransactionToolStripMenuItem.Text = "Stock Transaction"
        '
        'ServiceToolStripMenuItem
        '
        Me.ServiceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewServiceRequestToolStripMenuItem, Me.ViewServiceRequestToolStripMenuItem, Me.ManageServiceToolStripMenuItem, Me.AssignTechnicianToolStripMenuItem})
        Me.ServiceToolStripMenuItem.Name = "ServiceToolStripMenuItem"
        Me.ServiceToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.ServiceToolStripMenuItem.Text = "Service"
        '
        'NewServiceRequestToolStripMenuItem
        '
        Me.NewServiceRequestToolStripMenuItem.Name = "NewServiceRequestToolStripMenuItem"
        Me.NewServiceRequestToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.NewServiceRequestToolStripMenuItem.Text = "New Service Request"
        '
        'ViewServiceRequestToolStripMenuItem
        '
        Me.ViewServiceRequestToolStripMenuItem.Name = "ViewServiceRequestToolStripMenuItem"
        Me.ViewServiceRequestToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ViewServiceRequestToolStripMenuItem.Text = "View Service Request"
        '
        'ManageServiceToolStripMenuItem
        '
        Me.ManageServiceToolStripMenuItem.Name = "ManageServiceToolStripMenuItem"
        Me.ManageServiceToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ManageServiceToolStripMenuItem.Text = "Manage Service"
        '
        'AssignTechnicianToolStripMenuItem
        '
        Me.AssignTechnicianToolStripMenuItem.Name = "AssignTechnicianToolStripMenuItem"
        Me.AssignTechnicianToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.AssignTechnicianToolStripMenuItem.Text = "Assign Technician"
        '
        'WarrantyToolStripMenuItem
        '
        Me.WarrantyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewWarrantyToolStripMenuItem, Me.FileWarrantyToolStripMenuItem, Me.ViewWarrantyClaimToolStripMenuItem})
        Me.WarrantyToolStripMenuItem.Name = "WarrantyToolStripMenuItem"
        Me.WarrantyToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.WarrantyToolStripMenuItem.Text = "Warranty"
        '
        'ViewWarrantyToolStripMenuItem
        '
        Me.ViewWarrantyToolStripMenuItem.Name = "ViewWarrantyToolStripMenuItem"
        Me.ViewWarrantyToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ViewWarrantyToolStripMenuItem.Text = "View Warranty"
        '
        'FileWarrantyToolStripMenuItem
        '
        Me.FileWarrantyToolStripMenuItem.Name = "FileWarrantyToolStripMenuItem"
        Me.FileWarrantyToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.FileWarrantyToolStripMenuItem.Text = "File Warranty Claim"
        '
        'SatffAndTechnicianToolStripMenuItem
        '
        Me.SatffAndTechnicianToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewStaffToolStripMenuItem, Me.ManageStaffToolStripMenuItem})
        Me.SatffAndTechnicianToolStripMenuItem.Name = "SatffAndTechnicianToolStripMenuItem"
        Me.SatffAndTechnicianToolStripMenuItem.Size = New System.Drawing.Size(126, 20)
        Me.SatffAndTechnicianToolStripMenuItem.Text = "Satff and Technician"
        '
        'AddNewStaffToolStripMenuItem
        '
        Me.AddNewStaffToolStripMenuItem.Name = "AddNewStaffToolStripMenuItem"
        Me.AddNewStaffToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AddNewStaffToolStripMenuItem.Text = "Add New Staff"
        '
        'ManageStaffToolStripMenuItem
        '
        Me.ManageStaffToolStripMenuItem.Name = "ManageStaffToolStripMenuItem"
        Me.ManageStaffToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ManageStaffToolStripMenuItem.Text = "Manage Staff"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaleReportToolStripMenuItem, Me.InventoryReportToolStripMenuItem, Me.ServiceReportToolStripMenuItem, Me.WarrantyReportToolStripMenuItem})
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'SaleReportToolStripMenuItem
        '
        Me.SaleReportToolStripMenuItem.Name = "SaleReportToolStripMenuItem"
        Me.SaleReportToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SaleReportToolStripMenuItem.Text = "Sale Report"
        '
        'InventoryReportToolStripMenuItem
        '
        Me.InventoryReportToolStripMenuItem.Name = "InventoryReportToolStripMenuItem"
        Me.InventoryReportToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.InventoryReportToolStripMenuItem.Text = "Inventory Report"
        '
        'ServiceReportToolStripMenuItem
        '
        Me.ServiceReportToolStripMenuItem.Name = "ServiceReportToolStripMenuItem"
        Me.ServiceReportToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ServiceReportToolStripMenuItem.Text = "Service Report"
        '
        'WarrantyReportToolStripMenuItem
        '
        Me.WarrantyReportToolStripMenuItem.Name = "WarrantyReportToolStripMenuItem"
        Me.WarrantyReportToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.WarrantyReportToolStripMenuItem.Text = "Warranty Report"
        '
        'SupplierToolStripMenuItem
        '
        Me.SupplierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManageSupplierToolStripMenuItem1})
        Me.SupplierToolStripMenuItem.Name = "SupplierToolStripMenuItem"
        Me.SupplierToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.SupplierToolStripMenuItem.Text = "Supplier"
        '
        'ManageSupplierToolStripMenuItem1
        '
        Me.ManageSupplierToolStripMenuItem1.Name = "ManageSupplierToolStripMenuItem1"
        Me.ManageSupplierToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.ManageSupplierToolStripMenuItem1.Text = "Manage Supplier"
        '
        'ViewWarrantyClaimToolStripMenuItem
        '
        Me.ViewWarrantyClaimToolStripMenuItem.Name = "ViewWarrantyClaimToolStripMenuItem"
        Me.ViewWarrantyClaimToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ViewWarrantyClaimToolStripMenuItem.Text = "View Warranty Claim"
        '
        'MDIMainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MDIMainForm"
        Me.Text = "MIdeaMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DashboardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddNewPurchaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewOrdersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddNewProductToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManageProductsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LowStockAlertToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ServiceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewServiceRequestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewServiceRequestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManageServiceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AssignTechnicianToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WarrantyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewWarrantyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileWarrantyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SatffAndTechnicianToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddNewStaffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManageStaffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaleReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ServiceReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WarrantyReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents StocTransactionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupplierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManageSupplierToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ViewWarrantyClaimToolStripMenuItem As ToolStripMenuItem
End Class
