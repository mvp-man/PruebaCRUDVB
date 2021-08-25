Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class conexion

    'Dim conexionstring As String = "Data Source=DESKTOP-03SH2PG\SQLEXPRESS;Initial Catalog=Ejemplo;Integrated Security = True"
    'Dim conexionstring As String = "Server=192.168.10.3; Initial Catalog=Northwind; User ID=sa;Password=123"
    Dim conexionstring As String = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ejemplo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
    Public conexion As SqlConnection = New SqlConnection(conexionstring)
    Private cmb As SqlCommandBuilder
    Public ds As DataSet = New DataSet()
    Public da As SqlDataAdapter
    Public comando As SqlCommand

    Public Sub conectar()
        Try
            conexion.Open()
            MessageBox.Show("Conectado.")
        Catch ex As Exception
            conexion.Close()
            MessageBox.Show("Desconectado.")
        End Try
    End Sub

    Public Sub consulta(ByVal sql As String, ByVal tabla As String)
        Try
            ds.Tables.Clear()
            da = New SqlDataAdapter(sql, conexion)
            cmb = New SqlCommandBuilder(da)
            da.Fill(ds, tabla)
        Catch ex As Exception
            MessageBox.Show("No se pudo realizar la consulta.")
        Finally
            conexion.Close()
        End Try

    End Sub

    Function Insertar(ByVal sql)
        Try
            conexion.Open()
            comando = New SqlCommand(sql, conexion)
            Dim i As Integer = comando.ExecuteNonQuery()
            conexion.Close()
            If i > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            conexion.Close()
            MessageBox.Show("No se pudo realizar la inserción.")
        End Try
    End Function

    Function Eliminar(ByVal tabla, ByVal condicion)
        Try
            conexion.Open()
            Dim elimina As String = "delete from " + tabla + " where " + condicion
            comando = New SqlCommand(elimina, conexion)
            Dim i As Integer = comando.ExecuteNonQuery()
            conexion.Close()
            If (i > 0) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            conexion.Close()
            Return False
        End Try
    End Function

    Function Actualizar(ByVal tabla, ByVal campos, ByVal condicion)
        Try
            conexion.Open()
            Dim actualiza As String = "update " + tabla + " set " + campos + " where " + condicion
            comando = New SqlCommand(actualiza, conexion)
            Dim i As Integer = comando.ExecuteNonQuery()
            conexion.Close()
            If (i > 0) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            conexion.Close()
            MessageBox.Show("No se pudo realizar la inserción.")
        End Try
    End Function
End Class
