$vbContent = Get-Content "Childform.vb" -Raw

# 1. Remove manual Enter/Leave events for Name and Address
$vbContent = $vbContent -replace '(?sm)Private Sub sr_txtCustName_Enter.*?End Sub\s*Private Sub sr_txtCustName_Leave.*?End Sub', ''
$vbContent = $vbContent -replace '(?sm)Private Sub sr_txtCustAddress_Enter.*?End Sub\s*Private Sub sr_txtCustAddress_Leave.*?End Sub', ''

# 2. Update validation to not check for "Name..."
$oldVal = @"
                If String.IsNullOrWhiteSpace(sr_txtCustName.Text) OrElse sr_txtCustName.Text = "Customer Name..." Then
                    MessageBox.Show("Please enter a customer name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
"@
$newVal = @"
                If String.IsNullOrWhiteSpace(sr_txtCustName.Text) Then
                    MessageBox.Show("Please enter a customer name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
"@
$vbContent = $vbContent.Replace($oldVal, $newVal)

# 3. Add SetPlaceholder in Childform_Load right after ApplyPhoneFormat
$oldLoad = @"
        ' Apply Philippine phone format to all contact fields
        ApplyPhoneFormat(o_txtCustContact)
        ApplyPhoneFormat(a_txtSupContact)
        ApplyPhoneFormat(sr_txtCustContact)
"@
$newLoad = @"
        ' Apply Philippine phone format to all contact fields
        ApplyPhoneFormat(o_txtCustContact)
        ApplyPhoneFormat(a_txtSupContact)
        ApplyPhoneFormat(sr_txtCustContact)
        
        ' Set native placeholders for other fields without labels
        SetPlaceholder(sr_txtCustName, "Customer Name...")
        SetPlaceholder(sr_txtCustAddress, "Customer Home Address...")
"@
$vbContent = $vbContent.Replace($oldLoad, $newLoad)

Set-Content "Childform.vb" $vbContent

# 4. Remove default text from Designer
$designerContent = Get-Content "Childform.Designer.vb" -Raw
$designerContent = $designerContent -replace 'Me.sr_txtCustName.Text = "Name..."', 'Me.sr_txtCustName.Text = ""'
$designerContent = $designerContent -replace 'Me.sr_txtCustAddress.Text = "Customer Home Address..."', 'Me.sr_txtCustAddress.Text = ""'
Set-Content "Childform.Designer.vb" $designerContent
