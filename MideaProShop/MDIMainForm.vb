Public Class MDIMainForm

    ' Keep reference to the master Childform
    Private _dashboardForm As Childform

    Private Sub MideaMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Apply user role permissions
        ApplyUserPermissions()

        ' Load default child form (role check is now handled inside InitializeChildForm)
        InitializeChildForm()
    End Sub

    Private Sub ApplyUserPermissions()
        If MideaProShopModule.CurrentUserRole = "user" Then
            ' Hide unauthorized main menus
            DashboardToolStripMenuItem.Visible = False
            InventoryToolStripMenuItem.Visible = False
            SatffAndTechnicianToolStripMenuItem.Visible = False
            ReportToolStripMenuItem.Visible = False
            SupplierToolStripMenuItem.Visible = False

            ' Hide unauthorized sub-menus
            ManageServiceToolStripMenuItem.Visible = False
            BackupRestoreToolStripMenuItem.Visible = False
        Else
            ' Admin or other roles show everything
            DashboardToolStripMenuItem.Visible = True
            InventoryToolStripMenuItem.Visible = True
            SatffAndTechnicianToolStripMenuItem.Visible = True
            ReportToolStripMenuItem.Visible = True
            SupplierToolStripMenuItem.Visible = True
            ManageServiceToolStripMenuItem.Visible = True
            BackupRestoreToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub DashboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DashboardToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.tcMain.SelectedTab = _dashboardForm.pnlDashboardMain
    End Sub

    Private Sub AddNewPurchaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewPurchaseToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.tcMain.SelectedTab = _dashboardForm.pnlOrderMain
    End Sub

    Private Sub ViewOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewOrdersToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.tcMain.SelectedTab = _dashboardForm.pnlViewOrdersMain
    End Sub

    Private Sub AddNewProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewProductToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.tcMain.SelectedTab = _dashboardForm.pnlAddProductMain
    End Sub

    Private Sub ManageProductsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageProductsToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.tcMain.SelectedTab = _dashboardForm.pnlManageProductsMain
    End Sub

    Private Sub LowStockAlertToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LowStockAlertToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.tcMain.SelectedTab = _dashboardForm.pnlLowStockMain
    End Sub

    Private Sub InitializeChildForm()
        If _dashboardForm Is Nothing OrElse _dashboardForm.IsDisposed Then
            _dashboardForm = New Childform()
            _dashboardForm.MdiParent = Me
            _dashboardForm.FormBorderStyle = FormBorderStyle.None
            _dashboardForm.ControlBox = False
            _dashboardForm.Text = ""
            _dashboardForm.ShowIcon = False
            _dashboardForm.Dock = DockStyle.Fill

            ' Set the initial tab BEFORE calling .Show() to avoid flashing the dashboard
            If MideaProShopModule.CurrentUserRole = "user" Then
                _dashboardForm.tcMain.SelectedTab = _dashboardForm.pnlOrderMain
            Else
                _dashboardForm.tcMain.SelectedTab = _dashboardForm.pnlDashboardMain
            End If
        End If
        
        _dashboardForm.Show()
        _dashboardForm.BringToFront()
    End Sub

    Private Sub SaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaleToolStripMenuItem.Click
    End Sub

    Private Sub ManageServiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageServiceToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.tcMain.SelectedTab = _dashboardForm.pnlManageServiceMain
    End Sub

    Private Sub NewServiceRequestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewServiceRequestToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.tcMain.SelectedTab = _dashboardForm.pnlAddServiceRequestMain
    End Sub

    Private Sub ViewServiceRequestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewServiceRequestToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.tcMain.SelectedTab = _dashboardForm.pnlViewServiceRequestsMain
    End Sub

    Private Sub StocTransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StocTransactionToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.tcMain.SelectedTab = _dashboardForm.pnlStockTransactionMain
    End Sub

    Private Sub ViewWarrantyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewWarrantyToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.tcMain.SelectedTab = _dashboardForm.pnlViewWarrantyMain
        _dashboardForm.WR_LoadWarranties()
    End Sub

    Private Sub FileWarrantyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileWarrantyToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.tcMain.SelectedTab = _dashboardForm.pnlFileClaimMain
        _dashboardForm.FC_LoadCustomers()
    End Sub

    Private Sub ViewWarrantyClaimToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewWarrantyClaimToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.VC_ShowWarrantyClaims()
    End Sub

    Private Sub AddNewStaffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewStaffToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.ST_ShowAddStaff()
    End Sub

    Private Sub ManageStaffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageStaffToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.ST_ShowManageStaff()
    End Sub

    Private Sub ManageSupplierToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ManageSupplierToolStripMenuItem1.Click
        InitializeChildForm()
        _dashboardForm.SUP_ShowManageSupplier()
    End Sub

    Private Sub SaleReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaleReportToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.RPT_ShowSalesReport()
    End Sub

    Private Sub BackupRestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupRestoreToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.BR_ShowBackupRestore()
    End Sub

    Private Sub AccountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.ACC_ShowAccountSettings()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        ' Clear current user role
        MideaProShopModule.CurrentUserRole = ""
        
        ' Show login form and close this one
        ConfigPage.Show()
        Me.Close()
    End Sub


End Class
