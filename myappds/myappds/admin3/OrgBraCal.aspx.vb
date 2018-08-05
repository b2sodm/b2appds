Public Class OrgBraCal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim t As DateTime = DateTime.Now()
        lblDate.InnerText = t.ToString()
        calOrg.SelectedDate = t.Date

    End Sub

    Protected Sub calOrg_SelectionChanged(sender As Object, e As EventArgs) Handles calOrg.SelectionChanged
        Dim y As Integer = calOrg.SelectedDate.Year
        Dim m As Integer = calOrg.SelectedDate.Month
        Dim d As Integer = calOrg.SelectedDate.Day
        txbDate.Text = y.ToString() + "/" + m.ToString() + "/" + d.ToString()
    End Sub
End Class