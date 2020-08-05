Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Data

Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Imports System.Security.Cryptography
Imports System.Web
Imports System.Net.Mail

Public Class Form1


    Sub simpan()
        Try

            'membuat permintaan SSL/TLS 
            ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)

            '===== URL yang dituju untuk request =====
            Dim request As HttpWebRequest = DirectCast(WebRequest.Create("http://localhost:8080/crud/insert.php"), HttpWebRequest)

            '===== Method Reques =====
            request.Method = "POST"

            '===== Data POST dan konversikan ke array byte =====
            Dim PostData As String = "no=" + TextBox5.Text & "&nama=" + TextBox6.Text & "&alamat=" + TextBox7.Text
            Dim byteArraypostData() As Byte = Encoding.UTF8.GetBytes(PostData)

            '===== Tipe Konten dari WebRequest =====
            request.ContentType = "application/x-www-form-urlencoded"

            '===== Panjang Konten dari WebRequest =====
            request.ContentLength = byteArraypostData.Length

            '===== Dapatkan permintaan data =====
            Dim dataStream As Stream = request.GetRequestStream()

            '===== Tuliskan data ke permintaan =====
            dataStream.Write(byteArraypostData, 0, byteArraypostData.Length)

            '===== tutup permintaan data Stream =====
            dataStream.Close()

            '===== Dapatkan tanggapan =====
            Dim response As WebResponse = request.GetResponse()
            response = request.GetResponse()

            '===== Menampilkan Status =======
            'Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            '===== Dapatkan yang berisi konten yang dikembalikan oleh server =======
            dataStream = response.GetResponseStream()

            '===== Buka menggunakan StreamReader untuk akses yang mudah =======
            Dim StreamReader As New StreamReader(dataStream)

            '===== Baca isinya=======
            Dim ResponseFromServer As String
            ResponseFromServer = StreamReader.ReadToEnd()
            Dim mengandung As String = ResponseFromServer
            RichTextBox2.Text = ResponseFromServer


            '===== Tampilkan konten =======


            '===== Bersihkan aliranstreams =======
            StreamReader.Close()
            dataStream.Close()
            response.Close()

            'membersihkan textbox
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""

        Catch ex As Exception

            'Menampilkan pesan jika terjadi Error
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

        End Try
    End Sub


    Sub baca()

        Try
            'Hapus Listview
            ListView1.Items.Clear()

            'membuat permintaan SSL/TLS 
            ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)

            '===== URL yang dituju untuk request =====
            Dim situs As String = "http://localhost:8080/crud/anggota.json"
            Dim request As HttpWebRequest = DirectCast(WebRequest.Create(situs), HttpWebRequest)

            '===== Method Reques =====
            request.Method = "GET"

            '===== Dapatkan tanggapan =====
            Dim response As WebResponse = request.GetResponse()
            Using dataStream As Stream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim responseFromServer As String = reader.ReadToEnd()

                'RichTextBox1.Text = responseFromServer

                Dim objek As JArray = JArray.Parse(responseFromServer)

                For urutan As Integer = 0 To objek.Count - 1

                    Dim no = objek.SelectToken("[" & urutan & "].no")
                    Dim nama = objek.SelectToken("[" & urutan & "].nama")
                    Dim alamat = objek.SelectToken("[" & urutan & "].alamat")

                    'Menampilkan di listview
                    Dim lvl As New ListViewItem
                    lvl.Text = no
                    lvl.SubItems.Add(nama)
                    lvl.SubItems.Add(alamat)
                    ListView1.Items.Add(lvl)
                    lvl = Nothing
                Next urutan
            End Using

            '===== Bersihkan aliranstreams =======
            response.Close()

        Catch ex As Exception

            'Menampilkan pesan jika terjadi Error
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

        End Try
    End Sub


    Sub hapus()
        Try


            'membuat permintaan SSL/TLS 
            ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)

            '===== URL yang dituju untuk request =====
            Dim request As HttpWebRequest = DirectCast(WebRequest.Create("http://localhost:8080/crud/delete.php"), HttpWebRequest)

            '===== Method Reques =====
            request.Method = "POST"

            '===== Data POST dan konversikan ke array byte =====
            Dim PostData As String = "no=" + TextBox5.Text
            Dim byteArraypostData() As Byte = Encoding.UTF8.GetBytes(PostData)

            '===== Tipe Konten dari WebRequest =====
            request.ContentType = "application/x-www-form-urlencoded"

            '===== Panjang Konten dari WebRequest =====
            request.ContentLength = byteArraypostData.Length

            '===== Dapatkan permintaan data =====
            Dim dataStream As Stream = request.GetRequestStream()

            '===== Tuliskan data ke permintaan =====
            dataStream.Write(byteArraypostData, 0, byteArraypostData.Length)

            '===== tutup permintaan data Stream =====
            dataStream.Close()

            '===== Dapatkan tanggapan =====
            Dim response As WebResponse = request.GetResponse()
            response = request.GetResponse()

            '===== Menampilkan Status =======
            'Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            '===== Dapatkan yang berisi konten yang dikembalikan oleh server =======
            dataStream = response.GetResponseStream()

            '===== Buka menggunakan StreamReader untuk akses yang mudah =======
            Dim StreamReader As New StreamReader(dataStream)

            '===== Baca isinya=======
            Dim ResponseFromServer As String
            ResponseFromServer = StreamReader.ReadToEnd()
            Dim mengandung As String = ResponseFromServer
            RichTextBox2.Text = ResponseFromServer


            '===== Tampilkan konten =======


            '===== Bersihkan aliranstreams =======
            StreamReader.Close()
            dataStream.Close()
            response.Close()

            'membersihkan textbox
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""

        Catch ex As Exception

            'Menampilkan pesan jika terjadi Error
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

        End Try
    End Sub


    Sub edit()
        Try


            'membuat permintaan SSL/TLS 
            ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)

            '===== URL yang dituju untuk request =====
            Dim request As HttpWebRequest = DirectCast(WebRequest.Create("http://localhost:8080/crud/update.php"), HttpWebRequest)

            '===== Method Reques =====
            request.Method = "POST"

            '===== Data POST dan konversikan ke array byte =====
            Dim PostData As String = "no=" + TextBox5.Text & "&nama=" + TextBox6.Text & "&alamat=" + TextBox7.Text
            Dim byteArraypostData() As Byte = Encoding.UTF8.GetBytes(PostData)

            '===== Tipe Konten dari WebRequest =====
            request.ContentType = "application/x-www-form-urlencoded"

            '===== Panjang Konten dari WebRequest =====
            request.ContentLength = byteArraypostData.Length

            '===== Dapatkan permintaan data =====
            Dim dataStream As Stream = request.GetRequestStream()

            '===== Tuliskan data ke permintaan =====
            dataStream.Write(byteArraypostData, 0, byteArraypostData.Length)

            '===== tutup permintaan data Stream =====
            dataStream.Close()

            '===== Dapatkan tanggapan =====
            Dim response As WebResponse = request.GetResponse()
            response = request.GetResponse()

            '===== Menampilkan Status =======
            'Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            '===== Dapatkan yang berisi konten yang dikembalikan oleh server =======
            dataStream = response.GetResponseStream()

            '===== Buka menggunakan StreamReader untuk akses yang mudah =======
            Dim StreamReader As New StreamReader(dataStream)

            '===== Baca isinya=======
            Dim ResponseFromServer As String
            ResponseFromServer = StreamReader.ReadToEnd()
            Dim mengandung As String = ResponseFromServer
            RichTextBox2.Text = ResponseFromServer


            '===== Tampilkan konten =======


            '===== Bersihkan aliranstreams =======
            StreamReader.Close()
            dataStream.Close()
            response.Close()

            'membersihkan textbox
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""

        Catch ex As Exception

            'Menampilkan pesan jika terjadi Error
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

        End Try
    End Sub


    Sub token()
        Try


            'membuat permintaan SSL/TLS 
            ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)

            '===== URL yang dituju untuk request =====
            Dim request As HttpWebRequest = DirectCast(WebRequest.Create("http://localhost:8080/token/token.php"), HttpWebRequest)

            '===== Method Reques =====
            request.Method = "POST"

            '===== Data POST dan konversikan ke array byte =====
            Dim PostData As String = "token=" + TextBox2.Text
            Dim byteArraypostData() As Byte = Encoding.UTF8.GetBytes(PostData)

            '===== Tipe Konten dari WebRequest =====
            request.ContentType = "application/x-www-form-urlencoded"

            '===== Panjang Konten dari WebRequest =====
            request.ContentLength = byteArraypostData.Length

            '===== Dapatkan permintaan data =====
            Dim dataStream As Stream = request.GetRequestStream()

            '===== Tuliskan data ke permintaan =====
            dataStream.Write(byteArraypostData, 0, byteArraypostData.Length)

            '===== tutup permintaan data Stream =====
            dataStream.Close()

            '===== Dapatkan tanggapan =====
            Dim response As WebResponse = request.GetResponse()
            response = request.GetResponse()

            '===== Menampilkan Status =======
            'Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            '===== Dapatkan yang berisi konten yang dikembalikan oleh server =======
            dataStream = response.GetResponseStream()

            '===== Buka menggunakan StreamReader untuk akses yang mudah =======
            Dim StreamReader As New StreamReader(dataStream)

            '===== Baca isinya=======
            Dim ResponseFromServer As String
            ResponseFromServer = StreamReader.ReadToEnd()
            Dim mengandung As String = ResponseFromServer
            RichTextBox1.Text = ResponseFromServer


            '===== Tampilkan konten =======
            'Label2.Text = ResponseFromServer
            'Contains = mengandung kata
            If ResponseFromServer.Contains("VALID") Then
                Label4.Text = "OK"
                Label4.ForeColor = Color.LimeGreen

            Else

                Label4.Text = "NG"
                Label4.ForeColor = Color.Maroon
            End If

            '===== Bersihkan aliranstreams =======
            StreamReader.Close()
            dataStream.Close()
            response.Close()

        Catch ex As Exception

            'Menampilkan pesan jika terjadi Error
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

        End Try

    End Sub


    Sub post_data()
        Try
            'membuat permintaan SSL/TLS 
            ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)

            '===== URL yang dituju untuk request =====
            Dim request As HttpWebRequest = DirectCast(WebRequest.Create("http://localhost:8080/post/post.php"), HttpWebRequest)

            '===== Method Reques =====
            request.Method = "POST"

            '===== Data POST dan konversikan ke array byte =====
            Dim PostData As String = "email=" + TextBox3.Text & "&pass=" + TextBox4.Text
            Dim byteArraypostData() As Byte = Encoding.UTF8.GetBytes(PostData)

            '===== Tipe Konten dari WebRequest =====
            request.ContentType = "application/x-www-form-urlencoded"

            '===== Panjang Konten dari WebRequest =====
            request.ContentLength = byteArraypostData.Length

            '===== Dapatkan permintaan data =====
            Dim dataStream As Stream = request.GetRequestStream()

            '===== Tuliskan data ke permintaan =====
            dataStream.Write(byteArraypostData, 0, byteArraypostData.Length)

            '===== tutup permintaan data Stream =====
            dataStream.Close()

            '===== Dapatkan tanggapan =====
            Dim response As WebResponse = request.GetResponse()
            response = request.GetResponse()

            '===== Menampilkan Status =======
            'Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            '===== Dapatkan yang berisi konten yang dikembalikan oleh server =======
            dataStream = response.GetResponseStream()

            '===== Buka menggunakan StreamReader untuk akses yang mudah =======
            Dim StreamReader As New StreamReader(dataStream)

            '===== Baca isinya=======
            Dim ResponseFromServer As String
            ResponseFromServer = StreamReader.ReadToEnd()
            Dim mengandung As String = ResponseFromServer
            RichTextBox2.Text = ResponseFromServer


            '===== Tampilkan konten =======


            '===== Bersihkan aliranstreams =======
            StreamReader.Close()
            dataStream.Close()
            response.Close()

        Catch ex As Exception

            'Menampilkan pesan jika terjadi Error
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call token()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call post_data()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call simpan()
        Call baca()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Call baca()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '========[ Awal Mengatur Market Place ]========
        'mengatur properti
        ListView1.View = View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True

        'menambahkan header kolom
        ListView1.Columns.Add("No", 70, HorizontalAlignment.Center)
        ListView1.Columns.Add("   Nama", 100, HorizontalAlignment.Left)
        ListView1.Columns.Add("Alamat", 100, HorizontalAlignment.Right)
        '========[ Akhir Mengatur Market Place ]========

    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            TextBox5.Text = ListView1.SelectedItems(0).SubItems(0).Text
            TextBox6.Text = ListView1.SelectedItems(0).SubItems(1).Text
            TextBox7.Text = ListView1.SelectedItems(0).SubItems(2).Text
        End If
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Call hapus()
        Call baca()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call edit()
        Call baca()
    End Sub
End Class
