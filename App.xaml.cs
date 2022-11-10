using PokeInfo.Class;
using PokeInfo.Service;

namespace PokeInfo;

public partial class App : Application
{
    public static int iPokemonCount = 0;
    public static PokeService PokeService = new PokeService();
	public static List<PokemonDto> lstPokemon = new List<PokemonDto>();
    public App()
	{
		InitializeComponent();
        MainPage = new MainPage();
    }
}
