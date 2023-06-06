using Microsoft.Maui.Controls;

namespace ClientMobileHospital;

public partial class MainPage : ContentPage
{
	
	public MainPage()
	{
		InitializeComponent();
	}
    private void OnMedicamentosClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MedicamentosPage());
    }
    private void OnPacientesClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PacientePage());
    }

    private void OnTratamientosClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TratamientoPage());
    }

    
}

