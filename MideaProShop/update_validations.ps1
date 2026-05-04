$content = Get-Content "Childform.vb" -Raw

# 1. O_ProcessOrder
$oldOrderVal = @"
        If o_optNewCustomer.Checked Then
            If String.IsNullOrWhiteSpace(o_txtCustName.Text) OrElse String.IsNullOrWhiteSpace(o_txtCustContact.Text) Then
                MessageBox.Show("Please provide both name and contact number for the new customer.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
"@
$newOrderVal = @"
        If o_optNewCustomer.Checked Then
            If String.IsNullOrWhiteSpace(o_txtCustName.Text) Then
                MessageBox.Show("Please provide a name for the new customer.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If Not ValidatePhilippineNumber(o_txtCustContact, "Customer Contact") Then Return
"@
$content = $content.Replace($oldOrderVal, $newOrderVal)

$content = $content -replace 'cmdCust.Parameters.AddWithValue\("@contact", o_txtCustContact.Text\)', 'cmdCust.Parameters.AddWithValue("@contact", GetPhoneForStorage(o_txtCustContact))'

# 2. A_SaveProduct
$oldAVal = @"
        If a_optNewSupplier.Checked Then
            If String.IsNullOrWhiteSpace(a_txtSupName.Text) OrElse String.IsNullOrWhiteSpace(a_txtSupContact.Text) Then
                MessageBox.Show("Please provide name and contact for the new supplier.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
"@
$newAVal = @"
        If a_optNewSupplier.Checked Then
            If String.IsNullOrWhiteSpace(a_txtSupName.Text) Then
                MessageBox.Show("Please provide a name for the new supplier.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If Not ValidatePhilippineNumber(a_txtSupContact, "Supplier Contact") Then Return
"@
$content = $content.Replace($oldAVal, $newAVal)

$content = $content -replace 'cmdSup.Parameters.AddWithValue\("@contact", a_txtSupContact.Text\)', 'cmdSup.Parameters.AddWithValue("@contact", GetPhoneForStorage(a_txtSupContact))'

# 3. M_SaveEditProduct (inline supplier)
$oldMVal = @"
                If optNew.Checked Then
                    If String.IsNullOrWhiteSpace(txtSupName.Text) OrElse String.IsNullOrWhiteSpace(txtSupContact.Text) Then
                        MessageBox.Show("Please provide supplier name and contact.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
"@
$newMVal = @"
                If optNew.Checked Then
                    If String.IsNullOrWhiteSpace(txtSupName.Text) Then
                        MessageBox.Show("Please provide supplier name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                    If Not ValidatePhilippineNumber(txtSupContact, "Supplier Contact") Then Return
"@
$content = $content.Replace($oldMVal, $newMVal)

$content = $content -replace 'cmd.Parameters.AddWithValue\("@c", txtSupContact.Text.Trim\(\)\)', 'cmd.Parameters.AddWithValue("@c", GetPhoneForStorage(txtSupContact))'

# 4. SR_SaveRequest (sr_txtCustContact)
$oldSRVal = @"
                If String.IsNullOrWhiteSpace(sr_txtCustContact.Text) OrElse sr_txtCustContact.Text = "Contact..." Then
                    MessageBox.Show("Please enter a contact number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
"@
$newSRVal = @"
                If Not ValidatePhilippineNumber(sr_txtCustContact, "Customer Contact") Then Return
"@
$content = $content.Replace($oldSRVal, $newSRVal)

$content = $content -replace 'cmdCust.Parameters.AddWithValue\("@contact", sr_txtCustContact.Text\)', 'cmdCust.Parameters.AddWithValue("@contact", GetPhoneForStorage(sr_txtCustContact))'

# Remove sr_txtCustContact placeholder logic
$content = $content -replace '(?sm)Private Sub sr_txtCustContact_Enter.*?End Sub\s*Private Sub sr_txtCustContact_Leave.*?End Sub', ''

# 5. SUP_SaveSupplier (sup_txtContact)
$oldSupVal = @"
        If String.IsNullOrWhiteSpace(sup_txtContact.Text) Then
            MessageBox.Show("Please provide a contact number.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
"@
$newSupVal = @"
        If Not ValidatePhilippineNumber(sup_txtContact, "Supplier Contact") Then Return
"@
$content = $content.Replace($oldSupVal, $newSupVal)

$content = $content -replace 'cmd.Parameters.AddWithValue\("@c", sup_txtContact.Text.Trim\(\)\)', 'cmd.Parameters.AddWithValue("@c", GetPhoneForStorage(sup_txtContact))'

# 6. ST_SaveStaff (st_txtContact)
$oldSTVal = @"
        If String.IsNullOrWhiteSpace(st_txtContact.Text) Then
            MessageBox.Show("Please provide a contact number.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
"@
$newSTVal = @"
        If Not ValidatePhilippineNumber(st_txtContact, "Staff Contact") Then Return
"@
$content = $content.Replace($oldSTVal, $newSTVal)

$content = $content -replace 'cmd.Parameters.AddWithValue\("@c", st_txtContact.Text.Trim\(\)\)', 'cmd.Parameters.AddWithValue("@c", GetPhoneForStorage(st_txtContact))'

Set-Content "Childform.vb" $content
