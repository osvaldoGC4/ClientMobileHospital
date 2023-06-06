using ClientMobileHospital.Broker;
using ClientMobileHospital.Models;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;


namespace ClientMobileHospital;

public partial class MedicamentosPage : ContentPage
{

    private bMedicamento _bMedicamento = new bMedicamento(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbHospital"));
    public MedicamentosPage()
	{
		InitializeComponent();
	}

	private async void btnGuardar_Clicked(object sender, EventArgs e)
	{
        //Toma los datos para grabar el usuario
        int IdMedicamento;
        if (string.IsNullOrEmpty(txtId.Text)) { IdMedicamento = 0; }
        else { IdMedicamento = Convert.ToInt32(txtId.Text); }
        string Nombre = txtNomMedicamento.Text;
        string Descripcion = txtDescripcion.Text;
        string Tipo = txtTipo.Text;
        int Cantidad = Convert.ToInt32(txtCantidad.Text);

        Medicamento medicamento = new Medicamento();

        medicamento.Id = IdMedicamento;
        medicamento.Nombre = Nombre;
        medicamento.Descripcion = Descripcion;
        medicamento.Tipo = Tipo;
        medicamento.Cantidad = Cantidad;
        
        

        int Rpta = await _bMedicamento.GrabarMedicamento(medicamento);
        if (Rpta >= 0)
        {
            lblMensaje.Text = "Se grab� en la base de datos el Medicamento: " + Nombre;
        }
        else
        {
            lblMensaje.Text = _bMedicamento.Error;
        }
    }

    private async void btnConsultar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtId.Text))
        {
            lblMensaje.Text = "Debe definir el c�digo a consultar";
        }
        else
        {
            int IdMedicamento = Convert.ToInt32(txtId.Text);
            Medicamento medicamento = await (_bMedicamento.Consultar(IdMedicamento));
            if (medicamento == null)
            {
                lblMensaje.Text = "No se encontr� un usuario en la base de datos con el id: " + IdMedicamento;
            }
            else
            {
                txtNomMedicamento.Text = medicamento.Nombre;
                txtDescripcion.Text = medicamento.Descripcion;
                txtTipo.Text = medicamento.Tipo;
                txtCantidad.Text = Convert.ToString(medicamento.Cantidad);
            }
        }
    }
    
    
    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtId.Text))
        {
            lblMensaje.Text = "Debe definir el c�digo a eliminar";
        }
        else
        {
            int IdMedicamento = Convert.ToInt32(txtId.Text);
            await _bMedicamento.Eliminar(IdMedicamento);
            NavegarLista();
        }
    }
    
    private void btnTodos_Clicked(object sender, EventArgs e)
    {
        NavegarLista();
    }

    private void NavegarLista()
    {
        Navigation.PushAsync(new ListMedicamentos());
    }
    
}