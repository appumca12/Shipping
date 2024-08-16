Imports Xceed.FileSystem
Imports Xceed.Ftp
Imports System.IO
Public Class FTP

    Public Sub New()
        Xceed.Ftp.Licenser.LicenseKey = "FTN33-XH013-KH5NH-3T2A"
    End Sub

    Public Sub UploadFile(ByVal Folder As String, ByVal File As String)

        Dim Ftp As New FtpClient

        Dim aDir() As String
        aDir = Split(Folder, "\")


        Try
            Ftp.Connect(My.Settings.FTPServer, 21)
        Catch ex As Exception
            MsgBox("No Connection to server !")
            Exit Sub
        End Try

        Try
            Ftp.Login(My.Settings.FTPUser, My.Settings.FTPPass)
        Catch ex As Exception
            MsgBox("Login Failed !")
            Exit Sub
        End Try

        For Each F As String In aDir
            Try
                Ftp.ChangeCurrentFolder(F)
            Catch ex As Exception
                Ftp.CreateFolder(F)
                Ftp.ChangeCurrentFolder(F)

            End Try
       Next

        'If Ftp.GetCurrentFolder <> Folder Then
        '    Ftp.Disconnect()
        '    MsgBox("Can Not Connect To FTP !")
        '    Exit Sub
        'End If
    
        Try
            Ftp.DeleteFile(File)
        Catch ex As Exception
        End Try

        Try
            Ftp.SendFile(File)
        Catch ex As Exception
            MsgBox("can of save file " & File)
        End Try
        Ftp.Disconnect()

    End Sub

    Public Sub DownloadFile(ByVal Folder As String, ByVal File As String, ByVal SaveFileAs As String)

        Dim FTP As New FtpClient
        Dim IFList As Xceed.Ftp.FtpItemInfoList
        
        IFList = FTP.GetFolderContents(Folder)

        Try
            FTP.ReceiveFile(File, SaveFileAs)
        Catch ex As Exception
            MsgBox("No File For Download !")
        End Try

        Beep()

    End Sub

    Public Sub DownloadAllFileInFolder(ByVal Folder As String, ByVal SavePath As String, ByVal KeepOldFiles As Boolean)

        Dim FTP As New FtpClient
        Dim IFList As Xceed.Ftp.FtpItemInfoList
        Dim IFile As Xceed.Ftp.FtpItemInfo
        Dim Files() As String
        Dim Fle As String


        Try
            FTP.Connect(My.Settings.FTPServer, 21)
        Catch ex As Exception
            MsgBox("No Connection to server !")
            Exit Sub
        End Try

        Try
            FTP.Login(My.Settings.FTPUser, My.Settings.FTPPass)
        Catch ex As Exception
            MsgBox("Login Failed !")
            Exit Sub
        End Try

        FTP.ChangeCurrentFolder(Folder)
        IFList = FTP.GetFolderContents()

        If KeepOldFiles = False Then
            Files = Directory.GetFiles(SavePath)
            For Each Fle In Files
                File.Delete(Fle)
            Next
            Directory.Delete(SavePath)
            MkDir(SavePath)
        Else
            If Dir(SavePath, FileAttribute.Directory) = "" Then
                MkDir(SavePath)
            End If
        End If
        Files = Directory.GetFiles(SavePath)

        For Each IFile In IFList
            Try
                FTP.ReceiveFile(IFile.Name, SavePath & "\" & IFile.Name)
            Catch ex As Exception
                MsgBox("No File For Download !")
            End Try
        Next

        FTP.Disconnect()
    End Sub

    Public Sub DownloadAllFileToAlist(ByVal Folder As String, ByRef aResult As ArrayList, ByVal aFileName As ArrayList)

        Dim FTP As New FtpClient
        Dim IFList As Xceed.Ftp.FtpItemInfoList
        Dim IFile As Xceed.Ftp.FtpItemInfo
        Dim PicInByte() As Byte
        Dim Fle As File
        Dim S As String

        Try
            FTP.Connect(My.Settings.FTPServer, 21)
        Catch ex As Exception
            MsgBox("No Connection to server !")
            Exit Sub
        End Try

        Try
            FTP.Login(My.Settings.FTPUser, My.Settings.FTPPass)
        Catch ex As Exception
            MsgBox("Login Failed !")
            Exit Sub
        End Try

        Try
            FTP.ChangeCurrentFolder(Folder)
            IFList = FTP.GetFolderContents()
            For Each IFile In IFList

                Try
                    FTP.ReceiveFile(IFile.Name, "c:\tmp\tmp.tmp")
                    PicInByte = File.ReadAllBytes("c:\tmp\tmp.tmp")
                    aResult.Add(PicInByte)
                    aFileName.Add(IFile.Name)
                    Kill("c:\tmp\tmp.tmp")
                Catch ex As Exception
                    MsgBox("No File For Download !")
                End Try
            Next

        Catch ex As Exception

        End Try
        FTP.Disconnect()


    End Sub

    Public Sub DeleteFile(ByVal sFolder As String, ByVal sFileName As String, ByVal lresult As Boolean)

        Dim FTP As New FtpClient
        lresult = False

        Try
            FTP.Connect(My.Settings.FTPServer, 21)
        Catch ex As Exception
            MsgBox("No Connection to server !")
            Exit Sub
        End Try

        Try
            FTP.Login(My.Settings.FTPUser, My.Settings.FTPPass)
        Catch ex As Exception
            MsgBox("Login Failed !")
            FTP.Disconnect()
            Exit Sub
        End Try

        Try
            FTP.ChangeCurrentFolder(sFolder)
        Catch ex As Exception
            FTP.Disconnect()
            MsgBox("Directory not found !")
        End Try

        Try
            FTP.DeleteFile(sFileName)
            lresult = True
            FTP.Disconnect()
        Catch ex As Exception

        End Try



    End Sub


End Class
