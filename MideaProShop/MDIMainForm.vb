Public Class MDIMainForm

    ' Keep reference to the master Childform
    Private _dashboardForm As Childform

    Private Sub MideaMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load Dashboard by default
        InitializeChildForm()
        _dashboardForm.HideAllPanels()
        _dashboardForm.pnlDashboardMain.Visible = True
    End Sub

    Private Sub DashboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DashboardToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.HideAllPanels()
        _dashboardForm.pnlDashboardMain.Visible = True
    End Sub

    Private Sub AddNewPurchaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewPurchaseToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.HideAllPanels()
        _dashboardForm.pnlOrderMain.Visible = True
    End Sub

    Private Sub ViewOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewOrdersToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.HideAllPanels()
        _dashboardForm.pnlViewOrdersMain.Visible = True
    End Sub

    Private Sub AddNewProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewProductToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.HideAllPanels()
        _dashboardForm.pnlAddProductMain.Visible = True
    End Sub

    Private Sub ManageProductsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageProductsToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.HideAllPanels()
        _dashboardForm.pnlManageProductsMain.Visible = True
    End Sub

    Private Sub LowStockAlertToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LowStockAlertToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.HideAllPanels()
        _dashboardForm.pnlLowStockMain.Visible = True
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
        End If
        
        _dashboardForm.Show()
        _dashboardForm.BringToFront()
    End Sub

    Private Sub SaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaleToolStripMenuItem.Click
    End Sub

    Private Sub ManageServiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageServiceToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.HideAllPanels()
        _dashboardForm.pnlManageServiceMain.Visible = True
    End Sub

    Private Sub NewServiceRequestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewServiceRequestToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.HideAllPanels()
        _dashboardForm.pnlAddServiceRequestMain.Visible = True
    End Sub

    Private Sub ViewServiceRequestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewServiceRequestToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.HideAllPanels()
        _dashboardForm.pnlViewServiceRequestsMain.Visible = True
    End Sub

    Private Sub StocTransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StocTransactionToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.HideAllPanels()
        _dashboardForm.pnlStockTransactionMain.Visible = True
    End Sub

    Private Sub ViewWarrantyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewWarrantyToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.HideAllPanels()
        _dashboardForm.pnlViewWarrantyMain.Visible = True
        _dashboardForm.WR_LoadWarranties()
    End Sub

    Private Sub FileWarrantyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileWarrantyToolStripMenuItem.Click
        InitializeChildForm()
        _dashboardForm.HideAllPanels()
        _dashboardForm.pnlFileClaimMain.Visible = True
        _dashboardForm.FC_LoadCustomers()
    End Sub

End Class