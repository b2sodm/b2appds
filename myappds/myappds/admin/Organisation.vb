Public Class Organisation
    Private orgcode As Integer
    Private orgname As String
    Private pcode As Integer
    Private pname As String
    Private info As String
    Private ortype As String
    Private opbranch As Integer
    Private notes As String

    Public Sub Organisation(orcode As Integer, orname As String, opcode As Integer, opname As String, opinfo As String, optype As String, orbranch As Integer, ornotes As String)
        orgcode = orcode
        orgname = orname
        pcode = opcode
        pname = opname
        info = opinfo
        ortype = optype
        opbranch = orbranch
        notes = ornotes
    End Sub


End Class
