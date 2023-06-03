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

    /*
    private void OnDoctoresClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DoctoresPage());
    }

    private void OnPacienteClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PacientePage());
    }
    */
}

