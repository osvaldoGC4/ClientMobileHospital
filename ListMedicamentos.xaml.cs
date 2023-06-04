using ClientMobileHospital.Broker;
using ClientMobileHospital.Models;

namespace ClientMobileHospital;

public partial class ListMedicamentos : ContentPage
{
     bMedicamento _bMedicamento = new bMedicamento(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbHospital"));
    public ListMedicamentos()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //Cargar los datos del collectionView con la información de todos los usuarios
        lstMedicamentos.ItemsSource = _bMedicamento.GetAll().Result;
    }


}