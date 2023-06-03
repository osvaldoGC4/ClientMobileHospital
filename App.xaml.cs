using Microsoft.Maui;
using Microsoft.Maui.Controls;
using ClientMobileHospital.BaseDatos;

namespace ClientMobileHospital;

public partial class App : Application
{
    public static clsBaseDatos _baseDatos;
    public static clsBaseDatos BaseDatos
    {
        get
        {
            if(_baseDatos == null)
            {
                _baseDatos = new clsBaseDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"dbHospital"));
            }
            return _baseDatos;
        }
    }
	public App()
	{
        BaseDatos.CrearTabla();
        InitializeComponent();
		MainPage = new AppShell();

        //MainPage = new MainPage(); 

    }
}
