using ClientMobileHospital.Broker;
using ClientMobileHospital.Models;

namespace ClientMobileHospital;

public partial class PacientePage : ContentPage
{
    private bPaciente _bPaciente = new bPaciente(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbHospital"));
    public PacientePage()
	{
		InitializeComponent();
        lstPacientes.ItemsSource = _bPaciente.InsertarPacientesServicio();
	}

    private int rowCount = 0;

    private void AddRow_Clicked(object sender, EventArgs e)
    {
        Grid grid = new Grid();
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

        Label nombreLabel = new Label { Text = "Nombre " + rowCount };
        Label apellidoLabel = new Label { Text = "Apellido " + rowCount };
        Label tipoDocLabel = new Label { Text = "Tipo de documento " + rowCount };
        Label docLabel = new Label { Text = "Documento " + rowCount };
        Label fechaNacLabel = new Label { Text = "Fecha de nacimiento " + rowCount };
        Label telefonoLabel = new Label { Text = "Teléfono " + rowCount };
        Label direccionLabel = new Label { Text = "Dirección " + rowCount };
        RowDefinition objRowDefinition = new RowDefinition();
        //grid.ck
        grid.AddRowDefinition(new RowDefinition() { });


        //grid.Children.Add(nombreLabel, 0, 0);
        //grid.Children.Add(apellidoLabel, 1, 0);
        //grid.Children.Add(tipoDocLabel, 2, 0);
        //grid.Children.Add(docLabel, 3, 0);
        //grid.Children.Add(fechaNacLabel, 4, 0);
        //grid.Children.Add(telefonoLabel, 5, 0);
        //grid.Children.Add(direccionLabel, 6, 0);

        dataRowsStackLayout.Children.Add(grid);

        rowCount++;
    }

}