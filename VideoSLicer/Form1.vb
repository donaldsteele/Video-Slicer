Imports System.IO
Imports Vlc.DotNet
Imports Vlc.DotNet.Core

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub checkdir2(sender As Object, e As Forms.VlcLibDirectoryNeededEventArgs) Handles VlcControl1.VlcLibDirectoryNeeded
        Dim aP As String

        If Environment.Is64BitOperatingSystem Then
            aP = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "VideoLAN\VLC")
        Else
            aP = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "VideoLAN\VLC")
        End If
        If Not File.Exists(Path.Combine(aP, "libvlc.dll")) Then
            Using fbdDialog As New FolderBrowserDialog()
                fbdDialog.Description = "Select VLC Path"
                fbdDialog.SelectedPath = Path.Combine(aP, "VideoLAN\VLC")

                If fbdDialog.ShowDialog() = DialogResult.OK Then
                    e.VlcLibDirectory = New DirectoryInfo(fbdDialog.SelectedPath)
                End If
            End Using
        Else
            e.VlcLibDirectory = New DirectoryInfo(aP)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.click
       


       
        If VlcControl1.IsPlaying
            VlcControl1.Stop

        End If
         OpenFileDialog1.ShowDialog
         VlcControl1.SetMedia(New IO.FileInfo(OpenFileDialog1.FileName ))
        VlcControl1.Play()
    End Sub

    Private Sub VlcControl1_PositionChanged(sender As Object, e As VlcMediaPlayerPositionChangedEventArgs) Handles VlcControl1.PositionChanged
        
        
        Label2.InvokeThreadSafeMethod(Sub() Label2.Text = VlcControl1.Length.ToString )
      


        
             TrackBar1.InvokeThreadSafeMethod(Sub() TrackBar1.Maximum  =  VlcControl1.Length / 1000)
             TrackBar1.InvokeThreadSafeMethod(Sub() TrackBar1.Value =  VlcControl1.Time / 1000)

Dim t As TimeSpan = TimeSpan.FromMilliseconds(VlcControl1.Time)
Dim answer As String = String.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", t.Hours, t.Minutes, t.Seconds, t.Milliseconds)

         label1.InvokeThreadSafeMethod(Sub() Label1.Text = answer   )
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs)  Handles TrackBar1.Scroll
        VlcControl1.Time = TrackBar1.Value * 1000
     


    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

         VlcControl1.Rate = ComboBox1.SelectedItem.ToString



    End Sub

    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

End Class
