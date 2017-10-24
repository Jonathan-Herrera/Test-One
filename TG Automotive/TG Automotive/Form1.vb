Public Class Form1
    Const decOil_Change As Decimal = 36D             'cost of oil change
    Const decLube_Job As Decimal = 28D               'cost of lube job
    Const decRadiator_Flush As Decimal = 50D         'cost of radiator flush
    Const decTransmission_Flush As Decimal = 120D    'cost of transmissino flush
    Const decInspection As Decimal = 15D             'cost of inspection
    Const decReplace_Muffler As Decimal = 200D       'cost of muffler replacement
    Const decTire_Rotation As Decimal = 20D          'cost of tire rotation


    Dim decSandL As Decimal      'holds the service and labor cost
    Dim intLabor As Integer   'hols the minutes of labor
    Dim decParts As Decimal      'holds the parts cost
    Dim decPartsTax As Decimal   'hols the tax on parts
    Dim decTotalfee As Decimal   'hols the total fee



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ValidateInputs()
        CalculateTotalCharges()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Function CalcOilLubeCharges() As Decimal
        Dim decCostofoillube As Decimal = 0D

        If chkOilchange.Checked = True Then
            decCostofoillube += decOil_Change
        End If
        If chkLubejob.Checked = True Then
            decCostofoillube += decLube_Job
        End If
        Return decCostofoillube
    End Function

    Function CalcFlushCharges() As Decimal
        Dim decCostofflushcharges As Decimal = 0D

        If chkRadiatorflush.Checked = True Then
            decCostofflushcharges += decRadiator_Flush
        End If
        If chkTransmissionflush.Checked = True Then
            decCostofflushcharges += decTransmission_Flush
        End If
        Return decCostofflushcharges
    End Function

    Function CalcMiscCharges() As Decimal
        Dim decCostofmisccharges As Decimal = 0D

        If chkInspection.Checked = True Then
            decCostofmisccharges += decInspection
        End If
        If chkReplacemuffler.Checked = True Then
            decCostofmisccharges += decReplace_Muffler
        End If
        If chkTirerotation.Checked = True Then
            decCostofmisccharges += decTire_Rotation
        End If
        Return decCostofmisccharges
    End Function

    Function ValidateInputs() As Boolean

        If Not Decimal.TryParse(txtLabor.Text, decParts) And decParts <= 0 Then
            MessageBox.Show("Invalid input")
            Return False
        End If
        If Not Double.TryParse(txtLabor.Text, intLabor) And intLabor < 0 Then
            MessageBox.Show("Invalid")
            Return False

        End If
        Return True
    End Function
    'If Decimal.TryParse(txtParts.Text, decParts) And IsNumeric(decParts) And decParts >= 0 Then
    'Return True
    'Else MessageBox.Show("invalid input for number of minutes")
    'End If
    'If Integer.TryParse(txtLabor.Text, intLabor) And IsNumeric(intLabor) And intLabor >= 0 Then
    'Return True
    'Else MessageBox.Show("invalid input for cost of parts")
    'End If
    'Return True

    ' End Function

    Sub CalculateTotalCharges()


        decSandL = CalcFlushCharges() + CalcOilLubeCharges() + CalcMiscCharges() + CDec(txtLabor.Text)
        lblParts.Text = decParts.ToString("c")
        lblSandL.Text = decSandL.ToString("c")
            decPartsTax = decParts * 0.06
            lblTaxparts.Text = decPartsTax.ToString("c")
            decTotalfee = decSandL + decPartsTax + decParts
            lblTotalfees.Text = decTotalfee.ToString("c")




    End Sub
End Class
