Imports System.Runtime.CompilerServices

Module ThreadSafe
    Private Delegate Sub InvokeThreadSafeMethodDelegate(ByVal control As Control, ByVal method As [Delegate])

    <Extension()> _
    Public Sub InvokeThreadSafeMethod(ByVal control As Control, ByVal method As [Delegate])
        If (control.InvokeRequired) Then
            Dim del = New InvokeThreadSafeMethodDelegate(AddressOf InvokeThreadSafeMethod)
            If Not control.IsDisposed
                control.Invoke(del, control, method)
            End If
            
        Else
            method.DynamicInvoke()
        End If
    End Sub
End Module
