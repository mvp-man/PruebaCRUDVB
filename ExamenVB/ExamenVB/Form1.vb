Public Class Form1

    Dim conexion As conexion = New conexion()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion.conectar()
        MostrarDatos()
    End Sub

    Public Sub MostrarDatos()
        conexion.consulta("select * from datos ", "datos")
        dgvdatos.DataSource = conexion.ds.Tables("datos")
    End Sub

    Private Sub btnagregar_Click(sender As Object, e As EventArgs) Handles btnagregar.Click
        Dim agregar As String = "insert into datos values (" + txtclave.Text.ToUpper.Trim() + ",'" + txtnombre.Text.ToUpper.Trim() + "','" + txtapepat.Text.ToUpper.Trim() + "','" + txtapemat.Text.ToUpper.Trim() + "','" + txtedad.Text.ToUpper.Trim() + "','" + cbsexo.Text.ToUpper.Trim() + "')"

        If (conexion.Insertar(agregar)) Then
            MessageBox.Show("Datos agregados correctamente")
            MostrarDatos()
        Else
            MessageBox.Show("Error al conectar")
        End If

    End Sub

    Private Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        If (conexion.Eliminar("datos", "clave = " + txtclave.Text)) Then
            MessageBox.Show("Datos eliminados correctamente")
            MostrarDatos()
        Else
            MessageBox.Show("Error al eliminar")
        End If

    End Sub
    Private Sub btnmodificar_Click(sender As Object, e As EventArgs) Handles btnmodificar.Click
        Dim actualizar As String = "nombre = '" + txtnombre.Text.ToUpper.Trim() + "', apellido_paterno= '" + txtapepat.Text.ToUpper.Trim() + "', apellido_materno= '" + txtapemat.Text.ToUpper.Trim() + "'" +
            ", edad ='" + txtedad.Text.ToUpper.Trim() + "', sexo = '" + cbsexo.Text.ToUpper.Trim() + "'"
        If (conexion.Actualizar("datos", actualizar, "clave = " + txtclave.Text)) Then
            MessageBox.Show("Datos actualizados correctamente")
            MostrarDatos()
        Else
            MessageBox.Show("Error al actualizar")
        End If

    End Sub

    Private Sub dgvdatos_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdatos.RowEnter
        Dim dgv As DataGridViewRow = dgvdatos.Rows(e.RowIndex)
        txtclave.Text = dgv.Cells(0).Value.ToString()
        txtnombre.Text = dgv.Cells(1).Value.ToString()
        txtapepat.Text = dgv.Cells(2).Value.ToString()
        txtapemat.Text = dgv.Cells(3).Value.ToString()
        txtedad.Text = dgv.Cells(4).Value.ToString()
        cbsexo.Text = dgv.Cells(5).Value.ToString()
    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        txtclave.Text = ""
        txtnombre.Text = ""
        txtapepat.Text = ""
        txtapemat.Text = ""
        txtedad.Text = ""
        cbsexo.Text = ""
    End Sub
End Class
