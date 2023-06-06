using ClientMobileHospital.Broker;
using ClientMobileHospital.Models;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;

namespace ClientMobileHospital;

public partial class TratamientoPage : ContentPage
{
    private bTratamiento _bTratamiento = new bTratamiento(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbHospital"));
    public TratamientoPage()
	{
		InitializeComponent();
	}

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        //Toma los datos para grabar el usuario
        int IdTratamiento;
        if (string.IsNullOrEmpty(txtId.Text)) { IdTratamiento = 0; }
        else { IdTratamiento = Convert.ToInt32(txtId.Text); }
        string Nombre = txtNomTratamiento.Text;
        string Descripcion = txtDescripcion.Text;
        decimal Costo = Convert.ToDecimal(txtCosto.Text);

        Tratamiento tratamiento = new Tratamiento();

        tratamiento.Id = IdTratamiento;
        tratamiento.Nombre = Nombre;
        tratamiento.Descripcion = Descripcion;
        tratamiento.Costo = Costo;



        int Rpta = await _bTratamiento.GrabarTratamiento(tratamiento);
        if (Rpta >= 0)
        {
            lblMensaje.Text = "Se grabó en la base de datos el Tratamiento: " + Nombre;
        }
        else
        {
            lblMensaje.Text = _bTratamiento.Error;
        }
    }

    private async void btnConsultar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtId.Text))
        {
            lblMensaje.Text = "Debe definir el código a consultar";
        }
        else
        {
            int IdTratamiento = Convert.ToInt32(txtId.Text);
            Tratamiento tratamiento = await (_bTratamiento.Consultar(IdTratamiento));
            if (tratamiento == null)
            {
                lblMensaje.Text = "No se encontró un usuario en la base de datos con el id: " + IdTratamiento;
            }
            else
            {
                txtNomTratamiento.Text = tratamiento.Nombre;
                txtDescripcion.Text = tratamiento.Descripcion;
                txtCosto.Text = Convert.ToString(tratamiento.Costo);
            }
        }
    }


    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtId.Text))
        {
            lblMensaje.Text = "Debe definir el código a eliminar";
        }
        else
        {
            int IdTratamiento = Convert.ToInt32(txtId.Text);
            await _bTratamiento.Eliminar(IdTratamiento);
            NavegarLista();
        }
    }

    private void btnTodos_Clicked(object sender, EventArgs e)
    {
        NavegarLista();
    }

    private void NavegarLista()
    {
        Navigation.PushAsync(new ListTratamientos());
    }

}