using PokeInfo.Service;

namespace PokeInfo;

public partial class App : Application
{
    public static PokeService PokeService = new PokeService();
    public App()
	{
		InitializeComponent();

		MainPage = new MainPage();
	}
}
