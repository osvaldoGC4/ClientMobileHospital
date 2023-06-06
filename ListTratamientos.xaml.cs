using ClientMobileHospital.Broker;
using ClientMobileHospital.Models;

namespace ClientMobileHospital;

public partial class ListTratamientos : ContentPage
{
    bTratamiento _bTratamiento = new bTratamiento(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbHospital"));
    public ListTratamientos()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        //Cargar los datos del collectionView con la información de todos los usuarios
        lstTratamientos.ItemsSource = _bTratamiento.GetAll().Result;
    }
}